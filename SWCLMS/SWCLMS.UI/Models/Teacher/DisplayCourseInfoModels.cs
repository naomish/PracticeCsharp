using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models;
using SWCLMS.Models.Views;

namespace SWCLMS.UI.Models
{
    public class DisplayCourseInfoModels
    {
        public int ClassId { get; set; }
        public Course Course { get; set; }
        public StudentCount StudentCount { get; set; }//maybe just use primitive type here?
        public StudentGrade StudentGrade { get; set; }  
        public List<StudentGrade> StudentGrades { get; set; }
      
    }
}