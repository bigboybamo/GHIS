using AdventureWorkSales.Repository.Contract;
using AdventureWorkSales.Repository.Implementation;
using AdventureWorksSales.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventureWorkSales.Repository.Services
{
    public class AdventureWorkService : IAdventureWorkService
    {
        private readonly ICommandQuery _commandQuery;
        public AdventureWorkService(ICommandQuery commandQuery)
        {
            _commandQuery = new CommandQuery();
        }

        public async Task<int> GetSalesCount()
        {
            try
            {
                var query = string.Format("select count(*) as SalesCount from SalesOrder");
                return await _commandQuery.GetAsync<int>(query, 0);
            }
            catch (Exception )
            {

                throw;
            }

        }

        public async Task<int> HighestLineTotal()
        {
            try
            {
                var query = string.Format("SELECT TOP 1 LineTotal FROM SalesOrder WHERE LineTotal = ( SELECT MAX(LineTotal) FROM SalesOrder ) ORDER BY SalesOrderID ASC;");
                return await _commandQuery.GetAsync<int>(query, 0);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> GetFrontBakesSales()
        {
            try
            {
                var query = string.Format("SELECT SUM(LineTotal) AS Front_Brakes_Sales FROM SalesOrder where ProductID = '948'");
                return await _commandQuery.GetAsync<int>(query, 0);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<dynamic>> GetProductCategory()
        {
            try
            {
                var query = string.Format("select * from ProductCategory");
                return await _commandQuery.GetAllAsync<dynamic>(query, 0);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ProductCategory> GetProductCategoryById(int id)
        {
            try
            {
                var query = string.Format("select * from ProductCategory where ProductCategoryID =" + id);
                return await _commandQuery.GetAsync<ProductCategory>(query, null);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> CreateProdCategory(ProductCategory productCategory)
        {
            try
            {
                var query = string.Format("INSERT INTO ProductCategory (Name ,rowguid,ModifiedDate) VALUES (@name,@row,@modifiedDate)");
                var result = await _commandQuery.CreateAsync<int>(query, new {name = productCategory.Name, row = Guid.NewGuid(), modifiedDate = DateTime.Now });
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateProdCategory(ProductCategory productCategory)
        {
            try
            {
                var query = string.Format("UPDATE ProductCategory SET Name =@name ,rowguid = @row,ModifiedDate=@modifiedDate WHERE ProductCategoryID = @id");
                var result = await _commandQuery.UpdateAsync<int>(query, new { name = productCategory.Name,id =productCategory.ProductCategoryID ,row = Guid.NewGuid(), modifiedDate = DateTime.Now });
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

  

}
