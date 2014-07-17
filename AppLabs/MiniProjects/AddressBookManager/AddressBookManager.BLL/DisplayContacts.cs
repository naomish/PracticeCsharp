using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookManager.DAL;
using AddressBookManager.DTOs;

namespace AddressBookManager.BLL
{
    public class DisplayContacts
    {
        public List<Contact> Execute()
        {
            var fm = new FileManager();
            List<FileName> volumeNames = fm.LoadListOfExistingFiles();
             
            string volumeName = DisplayVolumes(volumeNames);
            WriteHeader(volumeName);
            string fileName = volumeName;//added this line because seemed to lose filename in WriteHeader method.
          List<Contact> contactList =  fm.LoadContactsFromFile(fileName);//for some reason this is returning an empty list. Why?!
            return contactList;

        }

        private string DisplayVolumes(List<FileName> volumeNames)//should i make this it's own class? use it in AddContact
        {
            Console.WriteLine("choose an addressbook to look at by entering one of the following: ");

            if (volumeNames.Any())
            {
                foreach (var volumeName in volumeNames)
                {
                    Console.WriteLine(volumeName.NameOfFile);
                }
                // Console.WriteLine("Or, create a new address book by entering a new title: ");

            }

            else
            {
                Console.Write("\nActually, you have no existing address books! So there are no contacts to display.");
            }
            string userInput = Console.ReadLine();
            return userInput;
        }


        private void  WriteHeader(string volumeName)
        {
            Console.Clear();
            Console.WriteLine("Your {0} Contacts", volumeName);
            Console.WriteLine("-------------------------------------");
           // return volumeName;
        }
    }
}
