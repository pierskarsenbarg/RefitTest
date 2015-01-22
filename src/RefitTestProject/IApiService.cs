using System.Threading.Tasks;

namespace RefitTest
{
    public interface IApiService
    {
        Task<string> GetHeaderAsync(string header);
        string GetHeader(string header);
    }
}
