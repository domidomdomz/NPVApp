using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }

        [Dapper.ReadOnly(true)]
        public virtual DateTime CreateDate { get; set; }


        #region ---- Default Query

        [JsonIgnore]
        [Dapper.NotMapped]
        public virtual string DefaultQuery
        {
            get
            {
                var tableName = Util.GetTableName(GetType());
                return $@"
SELECT {tableName}.*
FROM {tableName}";
            }
        }

        #endregion

    }
}
