using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SWCLMS.Data;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.UI.Models.GradeBook;

namespace SWCLMS.UI.Controllers
{
    [Authorize(Roles="Teacher")]
    public class GradeBookController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IRosterRepository _rosterRepository;
        private readonly IGradeBookRepository _gradeBookRepository;

        public GradeBookController(ITeacherRepository teacherRepository, IRosterRepository rosterRepository, IGradeBookRepository gradeBookRepository)
        {
            _teacherRepository = teacherRepository;
            _rosterRepository = rosterRepository;
            _gradeBookRepository = gradeBookRepository;
        }

        //should i comment this out now that I am using ApiController with angular?
        public ActionResult GradeBookDisplay(int id)  //takes a classId
        {
            var gradeBook = new GradeBook();

            gradeBook.StudentsEnrolled = _rosterRepository.GetStudentsEnrolledIn(id);
            gradeBook.Course = _teacherRepository.GetCourseById(id);
            gradeBook.AssignmentList = _gradeBookRepository.GetListOfAssignmentsById(id);
            gradeBook.StudentPerformances = _gradeBookRepository.GetListOfStudentPerformanceById(gradeBook.StudentsEnrolled);
            return View(gradeBook);
        }

        public ActionResult AddAssignment(int id) //takes in classId
        {
            var assignment = new AssignmentView();
            var newAssignment = new Assignment();
            assignment.NewAssignment = newAssignment;
           assignment.NewAssignment.ClassId = id;
            assignment.ClassName = _teacherRepository.GetCourseById(id).Name;

         return View(assignment);

        }

        [HttpPost]
        public ActionResult AddAssignment(AssignmentView assignmentView)
        {
            if (ModelState.IsValid)
            {
               _gradeBookRepository.CreateAssignment(assignmentView.NewAssignment);
                return RedirectToAction("EditAssignment", new {id = assignmentView.NewAssignment.AssignmentId});
            }
           // var newEntry = new AssignmentView();
           // newEntry.NewAssignment = assignment;
            assignmentView.ClassName = _teacherRepository.GetCourseById(assignmentView.NewAssignment.ClassId).Name;
            return View(assignmentView);
        }

        public ActionResult EditAssignment(int id) //assignmentId
        {
            var assignmentView = new AssignmentView();
            var assignment = _gradeBookRepository.GetAssignment(id);
            assignmentView.ClassName = _teacherRepository.GetCourseById(assignment.ClassId).Name;
            assignmentView.NewAssignment = assignment;
            return View(assignmentView);
        }

        [HttpPost]
        public ActionResult EditAssignment(AssignmentView assignmentView) //assignmentId
        {
            _gradeBookRepository.EditAssignment(assignmentView.NewAssignment);
            int classId = 0;
            var gradeBook = new GradeBook();
            var course = new Course();
            classId=_gradeBookRepository.GetAssignment(assignmentView.NewAssignment.AssignmentId).ClassId;
            
            course = _teacherRepository.GetCourseById(classId);
            gradeBook.Course = course;
            gradeBook.AssignmentList = _gradeBookRepository.GetListOfAssignmentsById(classId);


            return View("GradeBookDisplay", gradeBook);
        }

        [HttpPost]
        public ActionResult DeleteAssignment(int id) //assignmentId
        {
       
           var assignment= _gradeBookRepository.GetAssignment(id);
            var classId = assignment.ClassId;
           var  course = _teacherRepository.GetCourseById(assignment.ClassId);
            var gradebook = new GradeBook();
            gradebook.Course = course;
            _gradeBookRepository.DeleteAssignment(id);
            gradebook.AssignmentList = _gradeBookRepository.GetListOfAssignmentsById(classId);
           
            return View("GradeBookDisplay", gradebook);
        }
	}
}