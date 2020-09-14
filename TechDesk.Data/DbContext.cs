using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using TechDesk.Common;

namespace TechDesk.Data
{
    public class DbContext : IDbContext, IDependency
    {
        private IDbConnection DbConnection
        {
            get
            {
                DbConnectionFactory.GetInstance();
                return DbConnectionFactory.OpenCurrentDbConnection();
            }
        }

        public dynamic SelectFirst(string sql)
        {
            return DbConnection.QueryFirst(sql);
        }

        public IEnumerable<dynamic> Select(string sql)
        {
            return DbConnection.Query(sql);
        }

        public T SelectFirst<T>(string sql) where T : class, new()
        {
            return DbConnection.QueryFirst<T>(sql);
        }

        public async Task<T> SelectFirst<T>(string sql, object obj) where T : class, new()
        {
            return await DbConnection.QueryFirstAsync<T>(sql, obj);
        }

        public async Task<IEnumerable<T>> Select<T>(string sql) where T : class, new()
        {
            return await DbConnection.QueryAsync<T>(sql);
        }

        public async Task<IEnumerable<T>> Select<T>(string sql, object obj) where T : class, new()
        {
            return await DbConnection.QueryAsync<T>(sql, obj);
        }

        public SqlMapper.GridReader SelectMultiple(string sql)
        {
            return DbConnection.QueryMultiple(sql);
        }

        public async Task<int> Update(string sql)
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    rows = await DbConnection.ExecuteAsync(sql, null, transaction);
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }

        public async Task<int> Update<T>(string sql, object obj) where T : class, new()
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    rows = await DbConnection.ExecuteAsync(sql, obj, transaction);
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }

        public int Update(List<Tuple<string, object>> param)
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    foreach (var item in param)
                    {
                        rows += DbConnection.Execute(item.Item1, item.Item2, transaction);
                    }
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }

        public int Delete(string sql)
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    rows = DbConnection.Execute(sql, null, transaction);
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }

        public int Delete<T>(string sql, object obj) where T : class, new()
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    rows = DbConnection.Execute(sql, obj, transaction);
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }

        public int Delete(List<Tuple<string, object>> param)
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    foreach (var item in param)
                    {
                        rows += DbConnection.Execute(item.Item1, item.Item2, transaction);
                    }
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }

        public int Insert(string sql)
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    rows = DbConnection.Execute(sql, null, transaction);
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }

        public int Insert<T>(string sql, object obj) where T : class, new()
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    rows = DbConnection.Execute(sql, obj, transaction);
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }

        public int Insert(List<Tuple<string, object>> param)
        {
            int rows = 0;
            using (IDbTransaction transaction = DbConnection.BeginTransaction())
            {
                try
                {
                    foreach (var item in param)
                    {
                        rows += DbConnection.Execute(item.Item1, item.Item2, transaction);
                    }
                }
                catch (DataException)
                {
                    transaction.Rollback();
                }
                transaction.Commit();
            }
            return rows;
        }
    }
}