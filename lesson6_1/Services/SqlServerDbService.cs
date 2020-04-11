using System.Data.SqlClient;
using lesson6_1.Models;

namespace lesson6_1.Services
{
    public class SqlServerDbService : IDbService
    {
        public bool CheckIndex(string index)
        {
            using (var con =
                new SqlConnection("Data Source=db-mssql;Initial Catalog=s19135;Integrated Security=True"))
            {
                using SqlCommand command = new SqlCommand
                {
                    Connection = con,
                    CommandText = "SELECT IdStudent " +
                                  "FROM Student " +
                                  "WHERE IdStudent=" +
                                  index
                };
                con.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (int.TryParse(dataReader["IdStudent"].ToString(), out _)) 
                        return true;
                }
            }

            return false;
        }
    }
}