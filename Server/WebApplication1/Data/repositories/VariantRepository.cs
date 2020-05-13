using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class VariantRepository
    {
        string connectionString = "Server=LocalHost;Database=Project_Database;Trusted_Connection=True;";
        public List<Variant> GetVariants()
        {
            List<Variant> variants = new List<Variant>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                variants = db.Query<Variant>("SELECT * FROM Variant").ToList();
            }
            return variants;
        }
        public Variant Get(int id)
        {
            Variant variant = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                variant = db.Query<Variant>("SELECT * FROM Variant WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return variant;
        }
        public Variant Create(Variant variant)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Variant (name, Id_Poll) VALUES(@Name, @Id_Poll); SELECT CAST(SCOPE_IDENTITY() as int)";
                int variantId = db.Query<int>(sqlQuery, variant).FirstOrDefault();
                variant.Id = variantId;
            }
            return variant;
        }
        public void Update(Variant variant)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Variant SET Name = @Name, Id_Poll = @Id_Poll WHERE Id = @Id";
                db.Execute(sqlQuery, variant);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Variant WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
