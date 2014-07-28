using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.UI.WorkFlows;
using FlooringPrograms.Operations;

namespace FlooringProgram.UI
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
                Console.Clear();
                ProcessUserChoice(userChoice);



            } while (userChoice != "Q");
        }

        private string PromptUser()
        {
            Console.Write("\nEnter choice: ");
            return Console.ReadLine();
        }

        public void DisplayMenu()
        {

            Console.Clear();
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Add an Order");
            Console.WriteLine("3. Edit an Order");
            Console.WriteLine("4. Remove an Order");
            Console.WriteLine("Enter Q to quit");
            // Console.WriteLine("Enter a number or Q to quit.");
           // ProcessUserChoice();
        }

        private static void ProcessUserChoice(string userInput)
        {
           // string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1": //display
                    var d = new DisplayOrdersWorkFlow();
                    d.Execute();
                    break;

                case "2": //add an order
                    var ao = new AddOrderWorkFlow();
                    ao.Execute();
                    break;

                case "3": //edit an order
                    var eo = new EditOrderWorkFlow();
                    eo.Execute();
                    break;

                case "4": //remove an order
                    var r = new RemoveOrderWorkFlow();
                    r.Execute();
                    break;

                case "Q":
                    Console.Clear();
                    Console.WriteLine("\n\nGood Bye!");
                    break;
            }
        }
    }
}
