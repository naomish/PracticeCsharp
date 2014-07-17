using System.Collections.Generic;
using SWCLMS.Models.Views;

namespace SWCLMS.Models.Interfaces
{
    public interface ITeacherRepository
    {
        List<CourseSummaryView> GetCourseSummariesFor(string teacherId);
        Course GetCourseById(int courseId);
        void CreateCourse(Course course);
        void EditCourse(Course course);
        StudentCount GetStudentCount(int classId);
        List<StudentGrade> GetCumulativeGradesList(int classId);
    }
}
