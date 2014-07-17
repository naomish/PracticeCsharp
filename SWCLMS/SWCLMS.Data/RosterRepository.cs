using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Requests;
using SWCLMS.Models.Views;

namespace SWCLMS.Data
{
    public class RosterRepository : IRosterRepository
    {
        public List<RosterStudent> GetStudentsEnrolledIn(int classId)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", classId);

                return
                    cn.Query<RosterStudent>("RosterGetStudents", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }

        public void DeleteStudent(int rosterId)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@RosterId", rosterId);
                cn.Execute("RosterDelete", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<RosterSearchRecord> Search(RosterSearchRequest request)
        {
            if (string.IsNullOrEmpty(request.LastName))
            {
                return RosterSearchByGradeLevel(request);

            }

            if (request.GradeLevel == null)
            {
                return RosterSearchByLastName(request);
            }

            return RosterSearchByLastNameAndGradeLevel(request);
        }

        private List<RosterSearchRecord> RosterSearchByLastNameAndGradeLevel(RosterSearchRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", request.ClassId);
                p.Add("@GradeLevel", request.GradeLevel);
                p.Add("@LastName", request.LastName);

                return
                    cn.Query<RosterSearchRecord>("RosterSearchByLastNameAndGradeLevel", p,
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<RosterSearchRecord> RosterSearchByLastName(RosterSearchRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", request.ClassId);
                p.Add("@LastName", request.LastName);

                return
                    cn.Query<RosterSearchRecord>("RosterSearchByLastName", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }

        public List<RosterSearchRecord> RosterSearchByGradeLevel(RosterSearchRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", request.ClassId);
                p.Add("@GradeLevel", request.GradeLevel);

                return
                    cn.Query<RosterSearchRecord>("RosterSearchByGradeLevel", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }


        public void AddToRoster(RosterAddRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@RosterId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@UserId", request.UserId);
                p.Add("@ClassId", request.ClassId);

                cn.Execute("RosterInsert", p, commandType: CommandType.StoredProcedure);

                request.RosterId = p.Get<int>("@RosterId");
            }
        }

    }
}
