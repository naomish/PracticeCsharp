using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookManager.BLL;
using AddressBookManager.DTOs;

namespace AddressBookManager.UI
{
    public class Menu
    {

        public void RunApplication()
        {
            string userChoice;
            do
            {
                DisplayMenu();
                userChoice = PromptUser();
                EvaluateChoice(userChoice);
            } while (userChoice !="Q");
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1. Add a contact ");
            Console.WriteLine("2. Search contacts "); //will search for a single contact within an address book or sort an entire address book by LastName, FIrstName, City, etc...
            Console.WriteLine("3. Display contacts ");
            Console.WriteLine("4. Remove contact ");
            Console.WriteLine("5. Edit contact");
            Console.WriteLine("6. Move a contact ");
            Console.WriteLine("\nEnter 'Q' to quit");
            

        }

        public void EvaluateChoice(string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    var contactAdder = new AddNewContact();
                   var singleContact = contactAdder.Execute();
                    var printer = new ContactPrinter();
                    printer.PrintSingleContact(singleContact);
                    Console.ReadLine();

                    break;
                case "2":
                    Console.Write("coming soon");
                    break;
                case"3":
                    var displayContacts = new DisplayContacts();
               List<Contact> contactList=    displayContacts.Execute();
                    var printer2 = new ContactPrinter();
                    printer2.PrintContactList(contactList);
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("ComingSoon");
                    break;
                case "5":
                    Console.WriteLine("coming soon");
                    break;
                case"6": 
                    Console.WriteLine("Move a contact");
                    break;
                case"Q":
                    break;
                default:
                    Console.WriteLine("That was not a valid choice!");
                    break;

            }
        }

        private string PromptUser()
        {
            Console.WriteLine("Enter choice: ");
            return Console.ReadLine();
        }

    }
}
