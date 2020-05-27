using System.Threading.Tasks;
namespace WebStoreApplication.Models
{
    public interface IAccessPayPalAPI
    {
        public Task<string> getToken();
        public Task<string> createPayment(string total);
        public void ExecutePayment(string payerid);
    }    
}