using System.Data.SqlClient;

namespace WebStoreApplication.Models
{
    public static class CoroNacessitiesDBContext
    {
        private static SqlConnection connection;
        static CoroNacessitiesDBContext()
        {
            connection = new SqlConnection ("Data Source=BBD-DL\\SQLEXPRESS;Database=CoroNacessitiesDB;Integrated Security=SSPI;");
            connection.Open();
        }

        public static SqlConnection getConnection()
        {
            return connection;
        }
    }
}
