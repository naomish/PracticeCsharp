using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.Data
{
   public class ProductRespository
    {

        public List<Product> LoadProductsFromFile()
        {
            string fileName = "Products.txt";
            string[] allLines = File.ReadAllLines(fileName);
            return ProductListFromArray(allLines);
        }

        private List<Product> ProductListFromArray(string[] allLines)
        {
            var products = new List<Product>();
            foreach (var line in allLines.Skip(1))
            {
                string[] columns = line.Split('|');
                var productInfo = new Product();

                productInfo.ProductType = columns[0];
                productInfo.CostPerSqauareFoot = decimal.Parse(columns[1]);
                productInfo.LaborCostPerSquareFoot = decimal.Parse(columns[2]);
                products.Add(productInfo);
            }
            return products;
        }

    }
}
