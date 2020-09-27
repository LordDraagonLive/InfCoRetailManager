using InfiniumDataManager.Library.Internal.DataAccess;
using InfiniumDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniumDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ProductModel, dynamic>("[dbo].[spProduct_GetAll]", new { }, "InfCoData");

            return output;
        }
    }
}
