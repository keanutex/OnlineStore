using System.Data.SqlClient;

namespace WebStoreApplication.Models
{
    public static class CoroNacessitiesDBContext
    {
        private static SqlConnection connection;
        static CoroNacessitiesDBContext()
        {
            connection = new SqlConnection ("Data Source=KEANUT;Database=CoroNacessitiesDB;Integrated Security=SSPI;MultipleActiveResultSets=true");
            connection.Open();
        }

        public static SqlConnection getConnection()
        {
            return connection;
        }
    }
}
