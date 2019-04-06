using Refit;
using System.Threading.Tasks;
using XamApp.Dto;

namespace XamApp
{
    public interface INetworkService
    {
        [Get("/api/v1/products.json?brand=maybelline")]
        Task<string> GetMakeUps(CardDto cardDto);
    }
}