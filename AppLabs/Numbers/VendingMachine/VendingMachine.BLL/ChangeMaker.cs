using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models.DTOs;

namespace VendingMachine.BLL
{
    public class ChangeMaker
    {
        public ChangeResponse MakeChange(ChangeRequest transaction)
        {
         
         var changeResponse = CoinReturn(transaction);
            return changeResponse;
        }
        
        public ChangeResponse CoinReturn(ChangeRequest transaction)
        {
            var coinCount = new Change();
       
            coinCount.SilverDollars = transaction.ChangeOwed/100;
            coinCount.Quarters = (transaction.ChangeOwed - coinCount.SilverDollars*100)/25;
            coinCount.Dimes = (transaction.ChangeOwed - (coinCount.SilverDollars*100 + coinCount.Quarters*25))/10;
            coinCount.Nickels = (transaction.ChangeOwed - (coinCount.SilverDollars*100 + coinCount.Quarters*25 + coinCount.Dimes*10))/5;
            coinCount.Pennies = (transaction.ChangeOwed -
                                (coinCount.SilverDollars*100 + coinCount.Quarters*25 + coinCount.Dimes*10 +
                                 coinCount.Nickels*5));

            var changeResponse = new ChangeResponse();
            changeResponse.Coins = coinCount;
            changeResponse.Item = transaction.Item;
            changeResponse.ChangeOwed = transaction.ChangeOwed;
            changeResponse.Payment = transaction.Payment;
            return changeResponse;
        }

        public int FindDifference(VendingItem item, int payment)
        {
          
          return (int)(item.Price - payment)*100;
         
        }
    }
}
