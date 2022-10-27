using AdventureWorkSales.Repository.Contract;
using AdventureWorksSales.Core.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace AdventureWorkSales.Repository.Implementation
{
    public class CommandQuery : ICommandQuery
    {
        private static readonly string _conn = ConfigurationManager.ConnectionStrings["connectionname"].ToString();
        private readonly IDbConnection _db;


        public CommandQuery()
        {
            _db = new SqlConnection(_conn);
        }


        public T Get<T>(string query, T obj )
        {
            return _db.QueryFirstOrDefault<T>(query, obj);
        }
        public Task<T> GetAsync<T>(string query, T obj )
        {
            return _db.QueryFirstOrDefaultAsync<T>(query, obj);
        }
       
        public Task<IEnumerable<T>> GetAllAsync<T>(string query, object obj)
        {
            return _db.QueryAsync<T>(query, obj);
        }
 

        public int Create<T>(string query, T obj)
        {
            return _db.Execute(query, obj);
        }

        public Task<int> CreateAsync<T>(string query, object obj)
        {
            return _db.ExecuteAsync(query, obj);
        }

        public IEnumerable<T> GetAll<T>(string query, T obj)
        {
            return _db.Query<T>(query, obj);
        }

        public int Update<T>(string query, T obj)
        {
            return _db.Execute(query, obj);
        }

        public Task<int> UpdateAsync<T>(string query, object obj)
        {
            return _db.ExecuteAsync(query, obj);
        }
    }
}
