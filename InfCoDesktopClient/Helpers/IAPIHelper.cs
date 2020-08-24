using InfCoDesktopClient.Models;
using System.Threading.Tasks;

namespace InfCoDesktopClient.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}