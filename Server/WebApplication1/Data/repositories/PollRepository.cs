using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PollRepository
    {
        string connectionString = "Server=LocalHost;Database=Project_Database;Trusted_Connection=True;";
        public List<Poll> GetPolls()
        {
            List<Poll> polls = new List<Poll>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var temp = db.Query<Poll>("SELECT * FROM Poll").ToArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i].variants = db.Query<Variant>("Select * from Variant Where Id_Poll=@Id", new { temp[i].Id }).ToArray();
                    polls.Add(temp[i]);
                }
            }
            return polls;
        }
        public Poll Get(int id)
        {
            Poll poll = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                poll = db.Query<Poll>("SELECT * FROM Poll WHERE Id = @id", new { id }).FirstOrDefault();
                poll.variants = db.Query<Variant>("Select * from Variant Where Id_Poll=@Id", new { poll.Id }).ToArray();
            }
            return poll;
        }
        public Poll Create(Poll poll)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Poll (Name, DatePublication, DeadLine, Author_Id, MaxVariantByUser) VALUES(@Name, @DatePublication,@DeadLine, @Author_Id, @MaxVariantByUser); SELECT CAST(SCOPE_IDENTITY() as int)";
                int pollId = db.Query<int>(sqlQuery, poll).FirstOrDefault();
                poll.Id = pollId;
            }
            return poll;
        }
        public void Update(Poll poll)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Poll SET Name = @Name, DatePublication = @DatePublication, DeadLine = @DeadLine, Author_Id = @Author_Id, MaxVariantByUser = @MaxVariantByUser WHERE Id = @Id";
                db.Execute(sqlQuery, poll);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Poll WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
