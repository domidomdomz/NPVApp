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
        public const string FieldRequired = @"{0} is required.";
        public const string ValidationIssues = @"Unable to save record as there were validation issues.";
        public const string MustBeGreaterThanOrEqualTo = @"{0} must be greater than or equal to {1}";
        public const string AtLeast001 = @"{0} should be at least 0.01";

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

        public static Boolean IsEmpty(this string str)
        {
            return (str ?? "").Trim().Length == 0;
        }

        public static Boolean IsNotEmpty(this string str)
        {
            return !str.IsEmpty();
        }
    }
}
