using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Views;
using Dapper;

namespace SWCLMS.Data
{
    public class TeacherRepository : ITeacherRepository
    {
        // convert to dapper
        public List<CourseSummaryView> GetCourseSummariesFor(string teacherId)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", teacherId);

                return
                    cn.Query<CourseSummaryView>("ClassSummaryGetList", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
            //List<CourseSummaryView> courses = new List<CourseSummaryView>();

            //using (var cn = new SqlConnection(Config.GetConnectionString()))
            //{
            //    var cmd = new SqlCommand("ClassSummaryGetList", cn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@UserId", teacherId);

            //    cn.Open();

            //    using (var dr = cmd.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            courses.Add(new CourseSummaryView()
            //            {
            //                ClassId = (int)dr["ClassId"],
            //                Name = dr["Name"].ToString(),
            //                IsArchived = (bool)dr["IsArchived"],
            //                NumberOfStudents = (int)dr["NumberOfStudents"]
            //            });
            //        }
            //    }
            //}

            //return courses;
        }

        // ado example
        public Course GetCourseById(int id)
        {
            Course course = null;

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("ClassGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClassId", id);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        course = new Course()
                        {
                            ClassId = (int)dr["ClassId"],
                            UserId = dr["UserId"].ToString(),
                            Name = dr["Name"].ToString(),
                            GradeLevel = (byte)dr["GradeLevel"],
                            IsArchived = (bool)dr["IsArchived"],
                            Subject = dr["Subject"].ToString(),
                            StartDate = (DateTime)dr["StartDate"],
                            EndDate = (DateTime)dr["EndDate"],
                            Description = dr["Description"].ToString()
                        };
                    }
                }
            }

            return course;
        }


        public void CreateCourse(Course course)
        {
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", course.UserId);
                p.Add("@Name", course.Name);
                p.Add("@GradeLevel", course.GradeLevel);
                p.Add("@Subject", course.Subject);
                p.Add("@StartDate", course.StartDate);
                p.Add("@EndDate", course.EndDate);
                p.Add("@Description", course.Description);
                p.Add("@ClassId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                cn.Execute("ClassInsert", p, commandType: CommandType.StoredProcedure);

                course.ClassId = p.Get<int>("@ClassId");
            }
        }

        public List<StudentGrade> GetCumulativeGradesList(int id)
        {
            {
               // var gradeList = new List<StudentGrade>();

                using (var cn = new SqlConnection(Config.GetConnectionString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@classId", id);
                   

                    return
                        cn.Query<StudentGrade>("GradeCount_GetByClassId", p, commandType: CommandType.StoredProcedure)
                            .ToList();
                }
            }
        }

        public void EditCourse(Course course)
        {
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", course.UserId);
                p.Add("@Name", course.Name);
                p.Add("@GradeLevel", course.GradeLevel);
                p.Add("@Subject", course.Subject);
                p.Add("@StartDate", course.StartDate);
                p.Add("@EndDate", course.EndDate);
                p.Add("@IsArchived", course.IsArchived);
                p.Add("@Description", course.Description);
                p.Add("@ClassId", course.ClassId);

                cn.Execute("ClassUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public StudentCount GetStudentCount(int id)
        {
            {
                
            var count = new StudentCount();
            count.ClassId = id;
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "StudentCount_GetByClassId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ClassId", id);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        count.Students = (int) dr["StudentCount"];
                    }
                }
            }
            return count;
        }
        }
    }
}
