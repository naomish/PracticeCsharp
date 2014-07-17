using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DAL;

namespace VendingMachine.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var GetItems = new ItemRepository();
          var items =  GetItems.LoadItemsFromFile();
            var menu = new Menu();
            menu.VendMachineGo(items);
            Console.ReadLine();
        }
    }
}
