using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserPepository
    {
        string connectionString = "Server=LocalHost;Database=Project_Database;Trusted_Connection=True;";
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.Query<User>("SELECT * FROM Users").ToList();
            }
            return users;
        }
        public User Get(int id)
        {
            User user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return user;
        }
        public User Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Email, Password, NickName, Age) VALUES(@Email, @Password, @Nickname, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                int userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                user.Id = userId;
            }
            return user;
        }
        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Email = @Email, Password = @Password, NickName = @NickName, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
