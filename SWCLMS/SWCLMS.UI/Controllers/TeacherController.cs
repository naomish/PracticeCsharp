using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Views;
using SWCLMS.UI.Models;
using SWCLMS.UI.Models.Teacher;

namespace SWCLMS.UI.Controllers
{
    [Authorize(Roles="Teacher")]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IRosterRepository _rosterRepository;

        public TeacherController(ITeacherRepository teacherRepository, IRosterRepository rosterRepository)
        {
            _teacherRepository = teacherRepository;
            _rosterRepository = rosterRepository;
        }

        public ActionResult Index()
        {
            var courses = _teacherRepository.GetCourseSummariesFor(User.Identity.GetUserId());

            return View(courses);
        }

        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                course.UserId = User.Identity.GetUserId();
                _teacherRepository.CreateCourse(course);
                return RedirectToAction("EditCourse", new { id = course.ClassId });
            }

            return View(course);
        }

        public ActionResult EditCourse(int id)
        {//var course = new Course();
           var  course = _teacherRepository.GetCourseById(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _teacherRepository.EditCourse(course);
                course = _teacherRepository.GetCourseById(course.ClassId);
                ViewBag.Message = "Course created!";
            }

            return View("EditCourse", course);
        }

        public ActionResult DisplayCourseInfo(int id)
        {
            var courseInfo = new DisplayCourseInfoModels();
            var course = _teacherRepository.GetCourseById(id);
            courseInfo.ClassId = course.ClassId;
            var count = _teacherRepository.GetStudentCount(id);
            var gradeList = _teacherRepository.GetCumulativeGradesList(id);
            courseInfo.Course = course;
            courseInfo.StudentCount = count;
            courseInfo.StudentGrades =gradeList;

            return View(courseInfo);
        }

        [HttpPost]
        public ActionResult UpdateCourseInfo(Course course)
        { 
            var courseInfo = new DisplayCourseInfoModels ();
            _teacherRepository.EditCourse(course);
             course = _teacherRepository.GetCourseById(course.ClassId);
            courseInfo.Course = course;
            courseInfo.ClassId = course.ClassId;
           // courseInfo.Course.EndDate = course.EndDate;
            var gradeList = _teacherRepository.GetCumulativeGradesList(course.ClassId);
            courseInfo.StudentGrades = gradeList;
            return View("DisplayCourseInfo", courseInfo);

        }


        public ActionResult ClassRoster(int id)
        {
            var uberModel = new UberRoster();
           // uberModel.SearchRequest.ClassId = id;
            uberModel.ClassId = id;
            uberModel.CourseName = _teacherRepository.GetCourseById(id).Name;
            uberModel.EnrolledStudents = _rosterRepository.GetStudentsEnrolledIn(id);
            uberModel.SearchResults = new List<RosterSearchRecord>();
            uberModel.SearchRequest = new RosterSearchRequest();
            return View(uberModel);
        }

        [HttpPost]
        public ActionResult DeleteStudent(int rosterId, int classId)
        {
            var uberModel = new UberRoster();
            _rosterRepository.DeleteStudent(rosterId);
            uberModel.CourseName = _teacherRepository.GetCourseById(classId).Name;
            uberModel.EnrolledStudents = _rosterRepository.GetStudentsEnrolledIn(classId);
            uberModel.SearchResults = new List<RosterSearchRecord>();
            uberModel.SearchRequest = new RosterSearchRequest();
            return View("ClassRoster", uberModel);
        }

        [HttpPost]
        public ActionResult Search(RosterSearchRequest request)
        {
            var uberModel = new UberRoster();
           // var list = new List<RosterSearchRecord>();
            uberModel.SearchResults = _rosterRepository.Search(request);
            uberModel.CourseName = _teacherRepository.GetCourseById(request.ClassId).Name;
            uberModel.ClassId = request.ClassId;
            uberModel.EnrolledStudents = _rosterRepository.GetStudentsEnrolledIn(request.ClassId);
            uberModel.SearchRequest = request;

            return View("ClassRoster", uberModel);
        }

        public ActionResult AddStudent(string userId, int classId)
        {
            var uberModel = new UberRoster();
            var addRequest = new RosterAddRequest();
            addRequest.UserId = userId;
           // addRequest.RosterId = rosterId;
             
            addRequest.ClassId = classId;
            _rosterRepository.AddToRoster(addRequest);
            uberModel.CourseName = _teacherRepository.GetCourseById(classId).Name;
            uberModel.ClassId = classId;
            uberModel.EnrolledStudents = _rosterRepository.GetStudentsEnrolledIn(classId);
            uberModel.SearchResults = new List<RosterSearchRecord>();
            uberModel.SearchRequest = new RosterSearchRequest();

            return View("ClassRoster", uberModel);
        }
        }
}