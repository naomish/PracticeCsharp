using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Views  //I am getting confused
{
  public  class StudentCount
    {
      public int ClassId { get; set; }
      public int Students { get; set; } 

    }

    public class StudentGrade 
    {
        public int RosterId { get; set; }
        public decimal? CurrentGrade { get; set; }
    }

    public class GradeList
    {
        public List<StudentGrade> ClassGrades { get; set; }
    }
}
