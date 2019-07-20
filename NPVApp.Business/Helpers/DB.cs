using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public class DB : IDB
    {
        public DB()
        {
        }

        private IDbConnection OpenConnection(string connectionStringKey = "Db")
        {
            var connection = new SqlConnection(Util.ConnectionString(connectionStringKey));
            connection.Open();
            return connection;
        }



        public async Task<int> InsertAsync<TEntity>(TEntity entity)
            where TEntity : EntityBase, new()
        {
            try
            {
                using (var connection = OpenConnection())
                {
                    entity.Id = 0;
                    var id = await connection.InsertAsync(entity);
                    entity.Id = id ?? 0;
                    return entity.Id;
                }
            }
            catch (Exception ex)
            {
                // Put logging here
                throw;
            }
        }



        public async Task InsertListAsync<TEntity>(List<TEntity> entities)
            where TEntity : EntityBase, new()
        {
            try
            {
                foreach (var entity in entities)
                {
                    await InsertAsync(entity);
                }
            }
            catch (Exception ex)
            {
                // Put logging here
                throw;
            }
        }


        public async Task<TEntity> GetAsync<TEntity>(int id)
            where TEntity : EntityBase, new()
        {
            try
            {
                using (var connection = OpenConnection())
                {
                    var table = Util.GetTableName(typeof(TEntity));
                    var sql = $@"
{new TEntity().DefaultQuery}
WHERE {table}.Id=@Id";
                    var sqlParams = new { Id = id };
                    var entity = await connection.QueryFirstOrDefaultAsync<TEntity>(sql, sqlParams);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                // Put logging here
                throw;
            }
        }


        public async Task<IList<TEntity>> GetAllAsync<TEntity>()
            where TEntity : EntityBase, new()
        {
            try
            {
                using (var connection = OpenConnection())
                {
                    var table = Util.GetTableName(typeof(TEntity));
                    var sql = $@"
{new TEntity().DefaultQuery}";
                    var entities = await connection.QueryAsync<TEntity>(sql);
                    return entities.AsList();
                }
            }
            catch (Exception ex)
            {
                // Put logging here
                throw;
            }
        }

        public async Task<IList<T>> QueryAsync<T>(string sql, object sqlParams = null)
        {
            try
            {
                using (var connection = OpenConnection())
                {
                    var entities = await connection.QueryAsync<T>(sql, sqlParams);
                    return entities.AsList();
                }
            }
            catch (Exception ex)
            {
                // Put logging here
                throw;
            }
        }
    }
}
