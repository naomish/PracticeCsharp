using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models;
using SWCLMS.Models.Views;

namespace SWCLMS.UI.Models.GradeBook
{
    public class GradeBook
    {
       
        public Course Course { get; set; } //
        public List<Assignment> AssignmentList { get; set; } //
        public List<RosterStudent> StudentsEnrolled { get; set; } //rosterID, first, last, userId
        public List<GradeBookView.StudentPerformance> StudentPerformances { get; set; }
        
    }

  
}