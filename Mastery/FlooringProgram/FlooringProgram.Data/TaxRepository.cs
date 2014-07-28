using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;


namespace FlooringProgram.Data
{
   public class TaxRepository
    {
        public List<Tax> LoadTaxesAndStatesFromFile()
        {
            string fileName = "Taxes.txt";
            string[] allLines = File.ReadAllLines(fileName);
            return TaxesListFromArray(allLines);
        }

        private List<Tax> TaxesListFromArray(string[] allLines)
        {
            var taxesByState = new List<Tax>();
      

            foreach (var line in allLines.Skip(1))
            {
                string[] columns = line.Split('|');
                var taxSchedule = new Tax();

                taxSchedule.State = columns[0];
                taxSchedule.TaxRate = decimal.Parse(columns[1]);
                taxesByState.Add(taxSchedule); 
            }
            return taxesByState;
        }
    }
}
