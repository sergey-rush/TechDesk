using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace TechDesk.Data
{
    public interface IDbContext
    {
        dynamic SelectFirst(string sql);
        
        IEnumerable<dynamic> Select(string sql);

        T SelectFirst<T>(string sql) where T : class, new();

        Task<T> SelectFirst<T>(string sql, object obj) where T : class, new();

        Task<IEnumerable<T>> Select<T>(string sql) where T : class, new();

        Task<IEnumerable<T>> Select<T>(string sql, object obj) where T : class, new();

        SqlMapper.GridReader SelectMultiple(string sql);

        Task<int> Update(string sql);
        
        Task<int> Update<T>(string sql, object obj) where T : class, new();
        
        int Update(List<Tuple<string, object>> param);

        int Delete(string sql);
        
        int Delete<T>(string sql, object obj) where T : class, new();
        
        int Delete(List<Tuple<string, object>> param);

        int Insert(string sql);
        
        int Insert<T>(string sql, object obj) where T : class, new();
        
        int Insert(List<Tuple<string, object>> param);
    }
}