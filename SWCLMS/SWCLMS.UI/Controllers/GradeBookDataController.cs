using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SWCLMS.Data;
using SWCLMS.Models.Views;
using SWCLMS.UI.Models.GradeBook;

namespace SWCLMS.UI.Controllers
{
    public class GradeBookDataController : ApiController
    {
        public GradeBook Get(int id) //classId
        {
            var gradeBook = new GradeBook();
            var _gradeBookRepository = new GradeBookRepository();
            var _teacherRepository = new TeacherRepository();
            var _rosterRepository = new RosterRepository();

            gradeBook.StudentsEnrolled = _rosterRepository.GetStudentsEnrolledIn(id);
            gradeBook.Course = _teacherRepository.GetCourseById(id);
            gradeBook.AssignmentList = _gradeBookRepository.GetListOfAssignmentsById(id);
            gradeBook.StudentPerformances = _gradeBookRepository.GetListOfStudentPerformanceById(gradeBook.StudentsEnrolled);
            return gradeBook;
        }

        public HttpStatusCode Post(GradeBookView.StudentGrade gbUpdate)
        {
            var gbRepo = new GradeBookRepository();
            gbRepo.EditGradebook(gbUpdate);
            return HttpStatusCode.OK;
        }
    }
}
