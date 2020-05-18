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
                var Poll_Process = db.Query<PollProcess>("select * from Poll_Process").ToArray();
                var Users = db.Query<User>("select * from users").ToArray();
                int UsersCounter = 0;


                for (int index = 0; index < temp.Length; index++)
                {
                    temp[index].variants = db.Query<Variant>("Select * from Variant Where Id_Poll=@Id", new { temp[index].Id }).ToArray();
                   

                    for (int i = 0; i < temp[index].variants.Length; i++)
                    {
                        temp[index].variants[i].users = new User[0];
                        for (int j = 0; j < Poll_Process.Length; j++)
                        {
                            if (Poll_Process[j].Id_Variant == temp[index].variants[i].Id)
                            {
                                for (int k = 0; k < Users.Length; k++)
                                {
                                    if (Users[k].Id == Poll_Process[j].Id_User)
                                    {
                                        Array.Resize(ref temp[index].variants[i].users, UsersCounter+1);
                                        temp[index].variants[i].users[UsersCounter] = Users[k];
                                    }
                                }
                                UsersCounter++;
                            }
                        }
                        UsersCounter = 0;
                    }

                    polls.Add(temp[index]);
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
                var poll = this.Get(id);
                var Variants = db.Query<Variant>("Select * from Variant Where Id_Poll=@Id", new {poll.Id }).ToArray();
                PollProcess[] Poll_Process = db.Query<PollProcess>("Select * from Poll_Process").ToArray();
                if(Variants.Length > 0)
                {
                    for (int i = 0; i < Poll_Process.Length; i++)
                    {
                        if (Poll_Process[i].Id_Variant == Variants[i].Id)
                        {
                            var sqlQuery1 = "DELETE FROM Poll_Process WHERE Id_Variant = @id";
                            db.Execute(sqlQuery1, new { Variants[i].Id });
                        }
                    }
                    for (int i = 0; i < Variants.Length; i++)
                    {
                        if (Variants[i].Id_Poll == id)
                        {
                            var sqlQuery1 = "DELETE FROM Variant WHERE Id_Poll = @id";
                            db.Execute(sqlQuery1, new { id });
                        }
                    }
                }
                var sqlQuery = "DELETE FROM Poll WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
