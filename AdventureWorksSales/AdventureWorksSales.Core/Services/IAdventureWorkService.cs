using AdventureWorksSales.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorkSales.Repository.Services
{
    public interface IAdventureWorkService
    {
       Task<int> GetSalesCount();
       Task<int> HighestLineTotal();
        Task<int> GetFrontBakesSales();
        Task<IEnumerable<dynamic>> GetProductCategory();
        Task<ProductCategory> GetProductCategoryById(int id);
        Task<int> CreateProdCategory(ProductCategory productCategory);
        Task<int> UpdateProdCategory(ProductCategory productCategory);
    }
}
