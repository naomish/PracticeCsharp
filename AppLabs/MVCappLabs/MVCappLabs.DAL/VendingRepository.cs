using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using MVCappLabs.Models.Level2;
using System.Web;


namespace MVCappLabs.DAL
{
  public  class VendingRepository
    {//this will read items from a flat file to create a list of items sold in the vending machine.
      // after first pass, add an interface in Models project to abstract the data layer to allow for future use of DB in place of txt file.  
      //after second pass, update to include an items in stock column in model/txtFile. decrement the stock by one each time a user buys an item and write new in-stock number back into file. Write logic to exclude items < 1 in stock from List.
      public List<VendingItem> LoadItemsFromFile()
      {
          string fileName = "VendingItems.txt";
          string[] allLines = File.ReadAllLines(fileName);  //System.IO.FileNotFoundException: Could not find file 'C:\Program Files (x86)\IIS Express\VendingItems.txt'.  Tried to use Server.MapPath to get around this. unsucessful
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
