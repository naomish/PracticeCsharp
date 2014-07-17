using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Views;

namespace SWCLMS.Models.Interfaces
{
   public interface IRosterRepository
   {
       List<RosterStudent> GetStudentsEnrolledIn(int classId);
       void DeleteStudent(int rosterId);
       List<RosterSearchRecord> Search(RosterSearchRequest request);
       List<RosterSearchRecord> RosterSearchByLastName(RosterSearchRequest request);
       List<RosterSearchRecord> RosterSearchByGradeLevel(RosterSearchRequest request);
       void AddToRoster(RosterAddRequest request);
   }
}
