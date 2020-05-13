using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PollProcessRepository
    {
        string connectionString = "Server=LocalHost;Database=Project_Database;Trusted_Connection=True;";
        public List<PollProcess> GetProcesses()
        {
            List<PollProcess> processes = new List<PollProcess>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                processes = db.Query<PollProcess>("SELECT * FROM Poll_Process").ToList();
            }
            return processes;
        }
        public PollProcess Get(int id)
        {
            PollProcess process = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                process = db.Query<PollProcess>("SELECT * FROM Poll_Process WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return process;
        }
        public PollProcess Create(PollProcess process)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Poll_Process (Id_User, Id_Variant) VALUES(@Id_User, @Id_Variant); SELECT CAST(SCOPE_IDENTITY() as int)";
                int processId = db.Query<int>(sqlQuery, process).FirstOrDefault();
                process.Id = processId;
            }
            return process;
        }
        public void Update(PollProcess process)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Poll_Process SET Id_User = @Id_User, Id_Variant = @Id_Variant WHERE Id = @Id";
                db.Execute(sqlQuery, process);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Poll_Process WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
