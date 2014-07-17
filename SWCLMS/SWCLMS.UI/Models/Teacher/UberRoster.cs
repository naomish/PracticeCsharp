using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Views;

namespace SWCLMS.UI.Models.Teacher
{
    public class UberRoster
    {
        public List<RosterSearchRecord> SearchResults { get; set; }
        public List<RosterStudent> EnrolledStudents { get; set; }
        public string CourseName { get; set; }
        public RosterSearchRequest SearchRequest { get; set; }
        public RosterAddRequest AddRequest { get; set; }
        public int ClassId { get; set; }
     
    }
}

