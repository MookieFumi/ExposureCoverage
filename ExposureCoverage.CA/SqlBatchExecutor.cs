using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ExposureCoverage.CA
{
    internal static class SqlBatchExecutor
    {
        public static void ExecuteResourceStreamFromExecutingAssembly(DbContext context, string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(resourceName);
            string sql;
            using (var reader = new StreamReader(stream))
            {
                sql = reader.ReadToEnd();
            }
            var pattern = "\\s+GO(;|\\s+)";
            var options = RegexOptions.IgnoreCase | RegexOptions.Multiline;
            var tempSentences = Regex.Split(sql, pattern, options);
            var sentences = tempSentences.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
            foreach (var sentence in sentences)
            {
                context.Database.ExecuteSqlCommand(sentence);
            }
        }
    }
}