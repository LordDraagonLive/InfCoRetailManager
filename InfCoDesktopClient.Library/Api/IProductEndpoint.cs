using InfCoDesktopClient.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfCoDesktopClient.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}