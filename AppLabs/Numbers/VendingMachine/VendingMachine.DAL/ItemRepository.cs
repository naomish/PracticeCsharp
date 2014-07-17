using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models.DTOs;

namespace VendingMachine.DAL
{
   public class ItemRepository
    {

       public List<VendingItem> LoadItemsFromFile()
       {
           string fileName = "VendingItems.txt";
           string[] allLines = File.ReadAllLines(fileName);
           return ItemListFromArray(allLines);
       }

       private List<VendingItem> ItemListFromArray(string[] allLines)
       {
           var items = new List<VendingItem>();
           foreach (var line in allLines.Skip(1))
           {
               string[] columns = line.Split('|');
               var item = new VendingItem();

               item.Name = columns[0];
               item.Price = decimal.Parse(columns[1]);

               items.Add(item);

           }

           return items;
       }

    }
}
