using System.Data.SqlClient;

namespace WebStoreApplication.Models
{
    public static class CoroNacessitiesDBContext
    {
        private static SqlConnection connection;
        static CoroNacessitiesDBContext()
        {
            connection = new SqlConnection ("Data Source=(LocalDb)\\LocalDBDemo;Database=CoroNacessitiesDB;Integrated Security=SSPI;");
            connection.Open();
        }

        public static SqlConnection getConnection()
        {
            return connection;
        }
    }
}