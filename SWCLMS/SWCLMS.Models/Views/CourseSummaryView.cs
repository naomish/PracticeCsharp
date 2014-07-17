using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models.Views
{
    public class CourseSummaryView
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        public bool IsArchived { get; set; }
    }
}
