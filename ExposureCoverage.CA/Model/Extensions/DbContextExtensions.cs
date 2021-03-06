using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;

namespace ExposureCoverage.CA.Model.Extensions
{
    public static class DbContextExtensions
    {
        public static string GetTableName<T>(this DbContext context) where T : class
        {
            var objectContext = ((IObjectContextAdapter) context).ObjectContext;
            return objectContext.GetTableName<T>();
        }

        public static string GetTableName<T>(this ObjectContext context) where T : class
        {
            var sql = context.CreateObjectSet<T>().ToTraceString();
            var regex = new Regex("FROM (?<table>.*) AS");
            var match = regex.Match(sql);
            return match.Groups["table"].Value;
        }
        public static string DumpAsHtml(this DbContext context)
        {
            return ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.DumpAsHtml();
        }
    }
}