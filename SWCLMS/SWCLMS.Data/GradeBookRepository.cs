using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Views;

namespace SWCLMS.Data
{
   public class GradeBookRepository:IGradeBookRepository
    {
       public void CreateAssignment(Assignment assignment)
       {
           using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
           {
               var p = new DynamicParameters();
               p.Add("@ClassId", assignment.ClassId);
               p.Add("@Name", assignment.Name);
               p.Add("@PossiblePoints", assignment.PossiblePoints);
               p.Add("@DueDate", assignment.DueDate);
               p.Add("@Description", assignment.Description);
               p.Add("@AssignmentId", dbType: DbType.Int32, direction: ParameterDirection.Output);

               cn.Execute("AssignmentInsert", p, commandType: CommandType.StoredProcedure);

               assignment.AssignmentId = p.Get<int>("@AssignmentId");
           }
       }

       public Assignment GetAssignment(int assignmentId) //assignment id  How do i return a single item with Dapper?
       {
           Assignment assignment = null;

           using (var cn = new SqlConnection(Config.GetConnectionString()))
           {
               var cmd = new SqlCommand("AssignmentGetById", cn);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@AssignmentId", assignmentId);

               cn.Open();

               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read())
                   {
                       assignment = new Assignment()
                       {
                           AssignmentId = (int)dr["AssignmentId"],
                           ClassId = (int)dr["ClassId"],
                           Name = dr["Name"].ToString(),
                           PossiblePoints = (int)dr["PossiblePoints"],                      
                           DueDate = (DateTime)dr["DueDate"],                        
                           Description = dr["Description"].ToString()
                       };
                   }
               }
           }

           return assignment;
       }

       public void DeleteAssignment(int assignmentId)
       {
           using (var cn = new SqlConnection(Config.GetConnectionString()))
           {
               var p = new DynamicParameters();
               p.Add("AssignmentId", assignmentId);
               cn.Execute("AssignmentDelete", p, commandType: CommandType.StoredProcedure);
           }
       }

       public void EditAssignment(Assignment assignment)
       {
           using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
           {
               var p = new DynamicParameters();
               p.Add("@AssignmentId", assignment.AssignmentId);
               p.Add("@ClassId", assignment.ClassId);
               p.Add("@Name",assignment.Name);
               p.Add("@PossiblePoints", assignment.PossiblePoints);
               p.Add("@DueDate", assignment.DueDate);
               p.Add("@Description", assignment.Description);

               cn.Execute("AssignmentUpdate", p, commandType: CommandType.StoredProcedure);
           }
       }


       public List<Assignment> GetListOfAssignmentsById(int classId)
       {
           using (var cn = new SqlConnection(Config.GetConnectionString()))
           {
               var p = new DynamicParameters();
               p.Add("@classId", classId);

               return
                   cn.Query<Assignment>("Assignment_GetListByClassId", p, commandType: CommandType.StoredProcedure)
                       .ToList();
           }
       }

       public List<GradeBookView.StudentPerformance> GetListOfStudentPerformanceById(List<RosterStudent> enrolledStudents )
       {
           var performances =
          new List<GradeBookView.StudentPerformance>();
           foreach (var student in enrolledStudents)
           {
               var performance = new GradeBookView.StudentPerformance();
               performance.FirstName = student.FirstName;
               performance.LastName = student.LastName;
               performance.RosterId = student.RosterId;
               performance.CumulativeGrade = GetCurrentGradeFor(performance.RosterId).CurrentGrade;
               performance.StudentGrades = GetAssignmentGradesFor(performance.RosterId);
               performances.Add(performance);
           }
           return performances;
       }

       private List<GradeBookView.StudentGrade> GetAssignmentGradesFor(int rosterId) //do these two, called within the GetListOfStudentPerfomanceById method need to go in interface?
       {
           using (var cn = new SqlConnection(Config.GetConnectionString()))
           {
               var p = new DynamicParameters();
               p.Add("@RosterId", rosterId);

               return
                   cn.Query<GradeBookView.StudentGrade>("AssignmentScores_GetByRosterId", p,
                       commandType: CommandType.StoredProcedure).ToList(); //will this always be in the same order as the return set in sql?
           }
       }

       private StudentGrade GetCurrentGradeFor(int rosterId)
       {
           using (var cn = new SqlConnection(Config.GetConnectionString()))
           {
               var p = new DynamicParameters();
               p.Add("@RosterId", rosterId);

               if (
                   cn.Query<StudentGrade>("GradeCurrent_GetByRosterId", p, commandType: CommandType.StoredProcedure)
                       .Any())
               {
                   return
                       cn.Query<StudentGrade>("GradeCurrent_GetByRosterId", p, commandType: CommandType.StoredProcedure)
                           .First();
               }
               else 
               {
                   var studentGrade = new StudentGrade();
                   studentGrade.RosterId = rosterId;
                   studentGrade.CurrentGrade = null;
                   return studentGrade;
               }
              // return 
             //  cn.Query<StudentGrade>("GradeCurrent_GetByRosterId", p, commandType: CommandType.StoredProcedure).First();
           }
       }

       public void EditGradebook(GradeBookView.StudentGrade gbUpdate)
       {//this approach makes two calls to the database there is probably a way to do this all in one SQL Stored Procedure
           using (var cn = new SqlConnection(Config.GetConnectionString())) 
           {
               var p = new DynamicParameters();
               p.Add("@RosterId", gbUpdate.RosterId);
               p.Add("@AssignmentId", gbUpdate.AssignmentId);
               p.Add("@Points",gbUpdate.Points);
               p.Add("@Score", gbUpdate.Score);

               if (//checks to see if grade exists
                   cn.Query<AssignmentGrade>("AssignmentGrade_GetByRosterIdAndAssignmentId", p,
                       commandType: CommandType.StoredProcedure)
                       .Any())
               {
                   cn.Execute("AssignmentGrade_UpdateScore", p, commandType: CommandType.StoredProcedure); //updates existing grade
               }
               else
               {
                   cn.Execute("AssignmentGrade_Insert", p, commandType: CommandType.StoredProcedure); //creates new grade
               }

           }
       }
    }
}
