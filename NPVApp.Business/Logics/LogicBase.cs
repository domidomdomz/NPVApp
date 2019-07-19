using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public abstract class LogicBase<TEntity> : ILogic<TEntity>
        where TEntity : EntityBase, new()
    {
        protected IDB DB;
        protected string DefaultQuery;
        protected string TableName;

        public LogicBase(IDB db)
        {
            DB = db;
            var tEntity = new TEntity();
            DefaultQuery = tEntity.DefaultQuery;
            TableName = Util.GetTableName(typeof(TEntity));
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            var entity = await DB.GetAsync<TEntity>(id);
            return entity;
        }

        public async Task<IList<TEntity>> GetAllAsync(string whereCondition, object sqlParams = null, string orderBy = null)
        {
            var sql = $@"
{DefaultQuery}
{ (string.IsNullOrEmpty(whereCondition) ? " " : $" WHERE {whereCondition}") }
{ (string.IsNullOrEmpty(orderBy) ? " " : $" ORDER BY {orderBy}") }
";
            var entities = await DB.QueryAsync<TEntity>(sql, sqlParams);
            return entities;
        }
    }
}
