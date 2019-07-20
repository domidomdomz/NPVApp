using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public interface ILogic<TEntity>
        where TEntity : EntityBase, new()
    {
        Task<TEntity> GetAsync(int id);
        Task<IList<TEntity>> GetAllAsync(string whereCondition, object sqlParams = null, string orderBy = null);

    }
}
