using iRail.Net.Requests;
using System;
using System.Threading.Tasks;

namespace iRail.Net.Wrappers
{
    public interface IHttpClientWrapper
    {
        Task<Tuple<bool, string>> TryGetAsync(JsonRequestBase request);
    }
}