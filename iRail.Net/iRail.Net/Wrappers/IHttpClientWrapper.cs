using System.Threading.Tasks;
using iRail.Net.Requests;

namespace iRail.Net.Wrappers
{
    public interface IHttpClientWrapper
    {
        Task<string> GetAsync(RequestBase request);
    }
}