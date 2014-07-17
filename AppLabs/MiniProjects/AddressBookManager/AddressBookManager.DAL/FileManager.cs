using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AddressBookManager.DAL;
using System.IO;
using AddressBookManager.DTOs;

namespace AddressBookManager.DAL
{
    public class FileManager
    {
        private const string FileTrackerFileName = "CentipedeParade.txt";
       
        public string GetFilePath(string fileName)
        {
            string filePath = fileName + ".txt";
            return filePath;
        }

        public List<FileName> LoadListOfExistingFiles()
        {
            if (File.Exists(FileTrackerFileName))
            {
                string[] allLines = File.ReadAllLines(FileTrackerFileName);
                List<FileName> currentVolumes = new List<FileName>();
                foreach (var line in allLines)
                {
                    FileName volume = new FileName();
                    volume.NameOfFile = line;
                    currentVolumes.Add(volume);
                }
                return currentVolumes;

            }
            return new List<FileName>();

        }

        public void SaveVolumeNamesToFileTracker(List<FileName> volumeNames)
        {
            if (File.Exists(FileTrackerFileName))
                File.Delete(FileTrackerFileName);

            using (var writer = File.AppendText(FileTrackerFileName))
            {
                foreach (var volumeName in volumeNames)
                {
                    
                    writer.WriteLine("{0}", volumeName.NameOfFile);
                }

            }
        }

        public List<Contact> LoadContactsFromFile(string fileName)
        
        
        
        
        
        
        {
        string   filepath= GetFilePath(fileName);//added this to see if it fixes overwrite problem (skipping file.exists and returning empty list when file DOES exist) FIXED!
            if (File.Exists(filepath))//changed from fileName
            {
                string[] allLines = File.ReadAllLines(filepath); //changed from fileName


                return ContactListFromArry(allLines);
            }

            return new List<Contact>();

        }

        public List<Contact> ContactListFromArry(string[] allLines)
        {
            List<Contact> contacts = new List<Contact>();

            foreach (string line in allLines)
            {
                string[] columns = line.Split('|');


                Contact contact = new Contact();
                contact.FirstName = columns[0];
                contact.LastName = columns[1];

                string phoneList = columns[2]; //can i make the next 15 lines into a load phone list method that takes in a string phoneList and returns a List<Phone>?
                //   var allPhones = new List<Phone>(); //does this make an empty list or is it filled with return result of LoadPhoneList?
                List<Phone> allPhones = LoadPhoneList(phoneList);
                contact.Phones = allPhones;

                string addressList = columns[3];
                List<Address> allAddresses = LoadAddressList(addressList);
                contact.Addresses = allAddresses;

                string emailList = columns[4];
                List<Email> allEmails = LoadEmailList(emailList);
                contact.Emails = allEmails;


                contact.NotesField = columns[5];
                contact.VolumeName = columns[6];
                contact.TimesSelected = int.Parse(columns[7]);



                contacts.Add(contact);
            }

            return contacts;
        }

        public List<Email> LoadEmailList(string emailList)
        {
            List<Email> allEmails = new List<Email>();
            string[] emails = emailList.Split('%');

            foreach (string e in emails)
            {
                if (e.Length > 0) //put in to combat last % yielding empty string
                {
                    string[] oneEmail = e.Split('^');

                    Email anEmail = new Email();
                    anEmail.EmailType = oneEmail[0];
                    anEmail.EmailAddress = oneEmail[1];//null ref using '1', changed to 0 - and back
                    allEmails.Add(anEmail);
                }
            }
            return allEmails;
        }

        public List<Phone> LoadPhoneList(string phoneList)
        {
            List<Phone> allPhones = new List<Phone>();

            string[] phones = phoneList.Split('%');

            foreach (string p in phones)
            {
                if (p.Length > 0) //put in to combat last % yielding empty string resulting in "out of range exception"
                {
                    string[] onePhone = p.Split('^');

                    Phone aPhone = new Phone();
                    aPhone.PhoneType = onePhone[0];
                    aPhone.PhoneNumber = onePhone[1];//null ref using '1', changed to 0 - and back
                    allPhones.Add(aPhone);
                }

            }
            return allPhones;
        }

        public List<Address> LoadAddressList(string addressList)
        {
            List<Address> allAddresses = new List<Address>();

            string[] addresses = addressList.Split('%');

            foreach (string a in addresses)
            {
                if (a.Length > 0) //put in to combat last % yielding empty string
                {
                    string[] oneAddress = a.Split('^');

                    Address anAddress = new Address();
                    anAddress.AddressType = oneAddress[0]; //originally i numbered positions 0,1,2,3,4 changing all to 0 to see if works after null ref exception  -changed back
                    anAddress.Street = oneAddress[1];
                    anAddress.City = oneAddress[2];
                    anAddress.State = oneAddress[3];
                    anAddress.Zip = oneAddress[4];
                    allAddresses.Add(anAddress);
                }

            }
            return allAddresses;
        }


        // takes in a list of contacts with new contact already added. 
        //gets single contact from  the list and extracts volumeName.
        //destroys file of that same volumeName and rewrites list to new file of same name.
        public void SaveContactsToFile(List<Contact> allContacts)
        {           
            Contact singleContact = allContacts[0];

          string filePathName = GetFilePath(singleContact.VolumeName);

            if (File.Exists(filePathName))
                File.Delete(filePathName);

            using (var writer = File.AppendText(filePathName))
            {
                foreach (var contact in allContacts)
                {
                    string pipeSVLine = ConvertContactToPipeSV(contact);
                    writer.WriteLine(pipeSVLine);
                }
            }

            Console.WriteLine("Contact Saved");
        
        }

        //for writing/saving to file
        private string ConvertContactToPipeSV(Contact contact)

        {
           string phonesToFile =  ConvertPhoneListToPipeSV(contact);
            string addressesToFile = ConvertAddressListToPipeSV(contact);
            string emailToFile = ConvertEmailListToPipeSV(contact);

            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", contact.FirstName, contact.LastName, phonesToFile,
                addressesToFile, emailToFile, contact.NotesField, contact.VolumeName, contact.TimesSelected);

        }

        private string ConvertEmailListToPipeSV(Contact contact)
        {
            List<Email> emailList = contact.Emails;

            if (emailList.Count>1)
            {
                List<string> allEmailStrings = new List<string>();
                foreach (var email in emailList)
                {
                    string emailString = string.Format("{0}^{1}", email.EmailType, email.EmailAddress);
                   
                    allEmailStrings.Add(emailString); //forgoing for-loop
                }
                string completeEmailString = string.Join("%", allEmailStrings) + "%";
                return completeEmailString;
            }
            if (emailList.Count == 1)
            {
                string completeEmailString = string.Format("{0}^{1}", emailList.First().EmailType, emailList.First().EmailAddress);
                return completeEmailString;
            }
         
            string emailMessage = "There are no emails stored for this contact";
            return emailMessage;
            
        }

        private string ConvertAddressListToPipeSV(Contact contact)
        {
            List<Address> addressList = contact.Addresses;
            if (addressList.Count > 1)
            {
                List<string> allAddressStrings = new List<string>();

                foreach (var address in addressList)
                {
                   string addressString =  string.Format("{0}^{1}^{2}^{3}^{4}", address.AddressType, address.Street, address.City, address.State, address.Zip);
                   allAddressStrings.Add(addressString);
                }
                    string completeAddressString = string.Join("%", allAddressStrings) + "%";
                    return completeAddressString;
            }

                if (addressList.Count ==1)
                {
                    string completeAddressString = string.Format("{0}^{1}^{2}^{3}^{4}", addressList.First().AddressType, addressList.First().Street, addressList.First().City, addressList.First().State, addressList.First().Zip);
                    return completeAddressString;
                }
            
            string addressMessage = "There are no addresses stored for this contact";
            return addressMessage;
        }




        public string ConvertPhoneListToPipeSV(Contact contact)
        {

            List<Phone> phoneList = contact.Phones;

            if (phoneList.Count > 1)
            {
                List<string> allPhoneStrings = new List<string>();
                //see if it makes a difference using array vs list here.

                foreach (var phone in phoneList)  
                {
                   
                    string phoneString = string.Format("{0}^{1}", phone.PhoneType, phone.PhoneNumber);
                    allPhoneStrings.Add(phoneString);                   
                }

                string completePhoneString = string.Join("%", allPhoneStrings) + "%";  //can someone remind me why the heck I added the trailing "%"? 5/14/14
                return completePhoneString;
            }
            if (phoneList.Count == 1)
            {
                string completePhoneString = string.Format("{0}^{1}", phoneList.First().PhoneType, phoneList.First().PhoneNumber);
                return completePhoneString;
            }

            string phoneMessage = "There are no phone numbers for this contact";
            return phoneMessage;

        }


//ends up it puts two %% at end of entire phone string instead of between each individual phone.

        //public string ConvertPhoneListToPipeSV(Contact contact)
        //{
             
        //    List<Phone> phoneList = contact.Phones;

        //    if (phoneList.Count > 1)
        //    {
        //        string[] allPhoneStrings = new string[phoneList.Count];
        //            //see if it makes a difference using array vs list here.
                
        //            //whoops guess it does matter since i need index designation to add string to array, whereas List can just use .Add
        //        foreach (var phone in phoneList)  //suppose I could use for loop here instead and use i<phoneList.Count traditional i as position.
        //        {
        //            int count = 0;
        //            string phoneString = string.Format("{0}^{1}", phone.PhoneType, phone.PhoneNumber);
        //            allPhoneStrings[count] += phoneString;
        //            count++; //blech

        //        }
        //        string completePhoneString = string.Join("%", allPhoneStrings) + "%";
        //        //can someone remind me why the heck I added the trailing "%"? 5/14/14
        //        return completePhoneString;
        //    }
        //    if (phoneList.Count==1)
        //        {
        //            string completePhoneString = string.Format("{0}^{1}", phoneList.First().PhoneType, phoneList.First().PhoneNumber);
        //            return completePhoneString;
        //        }
            
        //    string  phoneMessage = "There are no phone numbers for this contact";
           
        //    return phoneMessage;

        //}

    }
}

