using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models
{
  public  class AssignmentGrade
    {
      public int RosterId { get; set; }
      public int AssignmentId { get; set; }
      public int Points { get; set; }
      public decimal Score { get; set; }
    }
}
