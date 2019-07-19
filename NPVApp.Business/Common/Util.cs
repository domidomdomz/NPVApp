using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public static class Util
    {
        public const string AnErrorHasOccured = "An error has occured.";

        public static string ConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static string GetTableName(Type type)
        {
            var tableName = type.Name;
            var customAttrinbutes = type.GetCustomAttributes(true);
            var tableAttributes = customAttrinbutes.SingleOrDefault(m => m.GetType().Name == typeof(Dapper.TableAttribute).Name) as dynamic;
            tableName = tableAttributes?.Name ?? tableName;
            return tableName;
        }
    }
}
