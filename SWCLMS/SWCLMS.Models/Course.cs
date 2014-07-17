using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLMS.Models
{
    public class Course
    {
        public int ClassId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public byte GradeLevel { get; set; }
        public bool IsArchived { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
