using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.Models.Interfaces
{
   public interface ITaxRateRepository
   {
       List<Tax> GetAllTaxRates();
   }
}
