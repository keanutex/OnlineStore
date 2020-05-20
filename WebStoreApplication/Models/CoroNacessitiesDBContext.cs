using System.Data.SqlClient;

namespace WebStoreApplication.Models
{
    public static class CoroNacessitiesDBContext
    {
        private static SqlConnection connection;
        static CoroNacessitiesDBContext()
        {
            connection = new SqlConnection ("Data Source=VIGNESHIY\\SQLEXPRESS;Database=CoroNacessitiesDB;User Id=database;Password=111226;");
            connection.Open();
        }

        public static SqlConnection getConnection()
        {
            return connection;
        }
    }
}