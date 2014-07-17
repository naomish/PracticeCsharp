using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Views;

namespace SWCLMS.Models.Interfaces
{
  public  interface IGradeBookRepository
  {
      void CreateAssignment(Assignment assignment);
      Assignment GetAssignment (int assignmentId);
      void DeleteAssignment(int assignmentId);
      void EditAssignment(Assignment assignment);
      void EditGradebook(GradeBookView.StudentGrade gbUpdate);

      List<Assignment> GetListOfAssignmentsById(int classId);
      List<GradeBookView.StudentPerformance> GetListOfStudentPerformanceById(List<RosterStudent> enrolledStudents);
  }
}
