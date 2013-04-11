using System.Threading.Tasks;
using iRail.Net.Model;

namespace iRail.Net
{
    public interface IRailClient
    {
        Task<Station[]> ListAllStationsAsync(Lang lang);
    }
}