using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookManager.BLL;
namespace AddressBookManager.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var contactAdder = new AddNewContact();
            //var singleContact = contactAdder.Execute();
            //var printer = new ContactPrinter();
            //printer.PrintSingleContact(singleContact);
            //Console.ReadLine();

            var menu = new Menu();
            menu.RunApplication();


        }
    }
}
