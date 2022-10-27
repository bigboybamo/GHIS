using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorkSales.Repository.Contract
{
   public interface ICommandQuery
    {
       
        int Create<T>(string query, T obj);
        Task<int> CreateAsync<T>(string query, object obj);
        T Get<T>(string query, T obj);
        Task<T> GetAsync<T>(string query, T obj);
        IEnumerable<T> GetAll<T>(string query, T objt);
        Task<IEnumerable<T>> GetAllAsync<T>(string query, object obj);
        int Update<T>(string query, T obj);
        Task<int> UpdateAsync<T>(string query, object obj);
    }
}
