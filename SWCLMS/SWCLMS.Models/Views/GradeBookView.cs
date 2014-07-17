using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Views
{
    public class GradeBookView
    {


        public class StudentPerformance
        {
            // public RosterStudent  EnrolledStudent {get; set; }
            public int RosterId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public decimal? CumulativeGrade { get; set; }//changed to nullible to account for newly added students
            public List<StudentGrade> StudentGrades { get; set; }

        }

        public class StudentGrade
        {
            public int AssignmentId { get; set; }
            public int RosterId { get; set; }
            public int? Points { get; set; }
            public decimal? Score { get; set; }
            public int PossiblePoints { get; set; }
        }
    }
}