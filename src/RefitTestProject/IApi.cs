using System.Threading.Tasks;
using Refit;

namespace RefitTest
{
    public interface IApi
    {
        [Get("/api/header")]
        Task<ApiString> GetHeader([Header("x-header")] string header);
    }
}
