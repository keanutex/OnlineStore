using System.Threading.Tasks;
namespace WebStoreApplication.Models
{
    public interface IAccessPayPalAPI
    {
        public Task<string> GetToken();
        public Task<string> CreatePayment(string total);
        public Task<string> ExecutePayment(string payerid);
    }    
}