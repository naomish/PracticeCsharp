using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookManager.BLL;
using AddressBookManager.DTOs;

namespace AddressBookManager.UI
{
    public class ContactPrinter
    {
        public void PrintSingleContact(Contact person)
        {
            Console.WriteLine("Name: {0} {1} ", person.FirstName, person.LastName);
            Console.WriteLine("------------------------------");
            foreach (var phone in person.Phones)
            {
                Console.WriteLine("{0} Phone: {1}", phone.PhoneType, phone.PhoneNumber);
            }

            Console.WriteLine("----------------------------------");

            foreach (var address in person.Addresses)
            {
                Console.WriteLine("{0} Address: {1}, {2}, {3}, {4}", address.AddressType, address.Street, address.City, address.State, address.Zip);
            }

            Console.WriteLine("---------------------------------------");

            foreach (var email in person.Emails)
            {
                Console.WriteLine("{0} email: {1}", email.EmailType, email.EmailAddress);
            }

            Console.WriteLine("---------------------------------------");

            Console.WriteLine("You entered these notes about {0} {1}: \n{2}", person.FirstName, person.LastName, person.NotesField);
            Console.ReadLine();
        }

        public void PrintContactList(List<Contact> contactList)
        {
            int count = 0;
            foreach (var contact in contactList)
            {
                count++;

                Console.WriteLine("{0}. {1} {2} Phone: ", count, contact.FirstName, contact.LastName);

                foreach (var p in contact.Phones)
                {
                    Console.WriteLine("     {0} - {1}", p.PhoneType, p.PhoneNumber);
                }

            }
        }
    }
}
