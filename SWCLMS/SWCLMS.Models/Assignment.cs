using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models
{
  public  class Assignment
    {
      public int     ClassId { get; set; }
      public string Name { get; set; }
      public int PossiblePoints { get; set; }
      public DateTime    DueDate { get; set; }
      public string Description { get; set; }
      public int AssignmentId { get; set; } 
    }
}
