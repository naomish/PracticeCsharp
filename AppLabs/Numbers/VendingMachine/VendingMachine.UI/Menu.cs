using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendingMachine.Models.DTOs;
using VendingMachine.BLL;

namespace VendingMachine.UI
{
   public class Menu
   {
       public void VendMachineGo(List<VendingItem> items )
       {
         //  var items = new List<VendingItem>();
        items=   DisplayMenu(items);
           var item = new VendingItem();
         item =  SelectItem(items);
          var transaction= GetMoney(item);
           var changeMaker = new ChangeMaker();
         var changeResponse = changeMaker.MakeChange(transaction);
           ChangePrinter(changeResponse);
         //  Console.ReadLine();

       }

       private void ChangePrinter(ChangeResponse changeResponse)
       {
Console.WriteLine("\nYou've got {0:c} coming to you in the form of: ", (decimal)changeResponse.ChangeOwed/100);   
       Console.WriteLine("Silver Dollars - {0}\nQuarters - {1}\nDimes - {2}\nNickels - {3}\nPennies - {4}", changeResponse.Coins.SilverDollars, changeResponse.Coins.Quarters, changeResponse.Coins.Dimes, changeResponse.Coins.Nickels, changeResponse.Coins.Pennies);
       }

       private ChangeRequest GetMoney(VendingItem item)
       {
           var itemTransaction = new ChangeRequest();
           itemTransaction.Item = item;
           bool result;
           decimal userPayment;
           bool isEnough=false;

        Console.WriteLine("Your Selection:{0} costs:{1:c}",item.Name, item.Price);

           do
           {
               Console.Write("How much money are you putting into the vending machine?:");
               string userInput = Console.ReadLine();
              
               result = decimal.TryParse(userInput, out userPayment);
               if (result==false)
               {
                   Console.WriteLine("You entered {0}, you must enter your payment as a number", userInput);
               }

               else if (userPayment<item.Price)
               {
                   Console.WriteLine("Your payment must be more than the price of the item! You entered {0} but {1} costs {2:c}. ", userPayment, item.Name, item.Price); 
               }
               else
               {
                   isEnough = true;
               }
           } while (result==false || isEnough==false); //weird. if i flip order result/isenough it doesn't like it.
           itemTransaction.Payment = (int)(userPayment*100);
           itemTransaction.ChangeOwed = (int)(itemTransaction.Payment - itemTransaction.Item.Price*100);
           return itemTransaction;
       }
       public List<VendingItem> DisplayMenu(List<VendingItem> items )
       {
           int count = 0; //figure out how to do this using List features instead
           Console.WriteLine("Vending Machine Items");
           Console.WriteLine("--------------------------------");


           foreach (var item in items)
           {
               count++;
               Console.WriteLine("{0}. {1,-13}    - {2,11:C}",count, item.Name, item.Price );
           }

          // Console.WriteLine("Hit Q at any time to Quit");
           return items;
       }

       public VendingItem SelectItem(List<VendingItem> items)
       {
           bool result;
           int itemNumber;
           bool inRange=false;
           
           do
           {
               Console.WriteLine("Enter the item number you wish to buy:");
               string choice = Console.ReadLine();
               result = int.TryParse(choice, out itemNumber);
               if (result==false)
               {
                   Console.WriteLine("You entered {0}, try entering a number", choice);
                   
               }

               else if (itemNumber < 1 || itemNumber > items.Count)
               {
                   Console.WriteLine("You entered {0}, that number item is not in the list.", choice);

               }
               else
               {
                   inRange = true;
               }

           } while (result==false||inRange==false);

           VendingItem item = FindItem(itemNumber, items);
           

           return item;
       }

       public VendingItem FindItem(int itemNumber, List<VendingItem> items)
       {
          // var item = new VendingItem();
           var item = items[itemNumber - 1];
           return item;
       }
    }
}
