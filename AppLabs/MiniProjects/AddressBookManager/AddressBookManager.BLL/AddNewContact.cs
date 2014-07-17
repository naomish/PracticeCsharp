using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using AddressBookManager.DAL;
using AddressBookManager.DTOs;

namespace AddressBookManager.BLL
{
    public class AddNewContact
    {
        public Contact Execute()
        {
            WriteHeader();

           // FillNewContactObject();
            var contact = FillNewContactObject();

            UpdateAddressBookFile(contact);

            Console.WriteLine("{0} {1} has been added to the {2} volume of your address book",contact.FirstName, contact.LastName,contact.VolumeName);
            return contact;
            //can i put something from UI here and print single contact? if so void this method.
        }

        public void UpdateAddressBookFile(Contact contact)
        {
            FileManager fm = new FileManager();
            //  string fileName="";
            string fileName = contact.VolumeName;
            List<Contact> allContacts = fm.LoadContactsFromFile(fileName);
            allContacts.Add(contact);
            fm.SaveContactsToFile(allContacts);
        }

        public Contact FillNewContactObject()
        {
            Contact newContact = new Contact();




           // AllFiles existingFiles = new AllFiles();
            FileName fileName = new FileName();

            FileManager fm = new FileManager();

            List<FileName> volumeNames = fm.LoadListOfExistingFiles();

            Console.WriteLine("Add your contact to an existing addressbook by entering one of the following: ");

            if (volumeNames.Any())
            {
                foreach (var volumeName in volumeNames)
                {
                    Console.WriteLine(volumeName.NameOfFile);
                }
                Console.WriteLine("Or, create a new address book by entering a new title: ");


            }
            else
            {
                Console.WriteLine("\nActually, you have no existing address books! \nCreate your first now:");
            }


            string userInput = Console.ReadLine();
            newContact.VolumeName = userInput;
            fileName.NameOfFile = userInput;
            int count = 0;
           
            foreach (var volumeName in volumeNames)
            {
                if (volumeName.NameOfFile==fileName.NameOfFile)
                {
                    count++;
                }

            }
            if (count == 0)
            {
                volumeNames.Add(fileName);
            }

            //if (!volumeNames.Contains(fileName)) grrrr. why doesn't this work? adds everytime.
            //{
            //    //could add validation"are you sure you want to add the new addressbook "blah"?
            //    volumeNames.Add(fileName);
            //}

            fm.SaveVolumeNamesToFileTracker(volumeNames);
            Console.Clear();

            Console.Write("Enter first name: ");
            newContact.FirstName = Console.ReadLine();
           
            Console.WriteLine();
           
            Console.Write("Enter last name: ");
            newContact.LastName = Console.ReadLine();

            Console.Clear();

            Console.Write("Enter any notes you would like to associate with {0} {1}\nNotes Field: ", newContact.FirstName, newContact.LastName);
            newContact.NotesField = Console.ReadLine();

            Console.Clear();

            PopulatePhonesList(newContact);

            PopulateAddressList(newContact);

            PopulateEmailList(newContact);

            newContact.TimesSelected = 0;
            return newContact;
        }

        private void PopulateEmailList(Contact newContact)
        {
            bool isNoMoreEmails = false;
            do
            {
                //make do while loop to continue adding phones to phones list
                Email newEmail = new Email();
                string userInput;

                Console.Write("What sort of email account is this? \n(work, personal, etc... or hit 'X' to move on): ");
                userInput = Console.ReadLine();
                Console.Clear();
                if (userInput.ToUpper() == "X")
                {
                    isNoMoreEmails = true;
                    Console.Clear();

                }
                else
                {
                    newEmail.EmailType = userInput;

                    Console.Write("Enter {1}'s {0} email: ", newEmail.EmailType, newContact.FirstName);
                    newEmail.EmailAddress = Console.ReadLine();

                    newContact.Emails.Add(newEmail);
                }

            } while (!isNoMoreEmails);
        }

        private void PopulateAddressList(Contact newContact)
        {
            bool isNoMoreAddresses = false;
            do
            {
                Address newAddress = new Address();
                string userInput;

                Console.WriteLine("Enter Address description (i.e. work, home, vacation etc) or 'X' to move on: ");
                userInput = Console.ReadLine();
                Console.Clear();

                if (userInput.ToUpper() == "X")
                {
                    isNoMoreAddresses = true;
                    Console.Clear();


                }
                else
                {
                    newAddress.AddressType = userInput;

                    Console.WriteLine("Enter {1}'s {0} address Street number: ", newAddress.AddressType, newContact.FirstName);
                    newAddress.Street = Console.ReadLine();

                    Console.WriteLine();

                    Console.Write("What city is {0}'s {1} in?: ", newContact.FirstName, newAddress.AddressType);
                    newAddress.City = Console.ReadLine();

                    Console.WriteLine();


                    Console.Write("What State is {0}'s {1} address in?: ", newContact.FirstName, newAddress.AddressType);
                    newAddress.State = Console.ReadLine();

                    Console.WriteLine();

                    Console.Write("What zipcode is {0}'s {1} in: ", newContact.FirstName, newAddress.AddressType);
                    newAddress.Zip = Console.ReadLine();

                    Console.Clear();

                    newContact.Addresses.Add(newAddress);
                }

            } while (!isNoMoreAddresses);
        }

        private void PopulatePhonesList(Contact newContact)
        {
            bool isNoMorePhones = false;
            do
            {

                Phone newPhone = new Phone();
                string userInput;

                Console.Write("Enter Phone description (i.e. work, home, cell etc) or 'X' to move on: ");
                userInput = Console.ReadLine();
                if (userInput.ToUpper() == "X")
                {
                    isNoMorePhones = true;
                    Console.Clear();


                }
                else
                {
                    newPhone.PhoneType = userInput;
                    Console.Clear();
                    Console.Write("Enter {1}'s {0} Phone number: ", newPhone.PhoneType, newContact.FirstName);
                    newPhone.PhoneNumber = Console.ReadLine();

                    newContact.Phones.Add(newPhone);
                }

            } while (!isNoMorePhones);
        }

        private static void WriteHeader()
        {
            Console.Clear();
            Console.WriteLine("Add a new contact");
            Console.WriteLine("----------------------------");
        }
    }
}
