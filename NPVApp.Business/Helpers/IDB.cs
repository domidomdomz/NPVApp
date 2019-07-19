using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public interface IDB
    {
        Task<int> InsertAsync<TEntity>(TEntity entity)
            where TEntity : EntityBase, new();

        Task InsertListAsync<TEntity>(List<TEntity> entity)
            where TEntity : EntityBase, new();

        Task<TEntity> GetAsync<TEntity>(int id)
            where TEntity : EntityBase, new();

        Task<IList<TEntity>> GetAllAsync<TEntity>()
            where TEntity : EntityBase, new();

        Task<IList<T>> QueryAsync<T>(string sql, object sqlParams = null);
    }
}
