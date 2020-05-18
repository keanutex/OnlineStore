using System.Text.Json;
using System.IO;

namespace WebStoreApplication.Models
{
    public static class ProductsContext
    {
        public static ProductsAggregate aggregate;
        public static int nextProductID = 1;

        static ProductsContext()
        {
            string jsonString  = File.ReadAllText("Data\\Products.json");
            aggregate = JsonSerializer.Deserialize<ProductsAggregate>(jsonString);
        }
    }
}