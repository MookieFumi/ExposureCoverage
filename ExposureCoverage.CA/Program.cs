using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using ExposureCoverage.CA.Model;
using ExposureCoverage.CA.Services;

namespace ExposureCoverage.CA
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var context = new ExposureCoverageContext();
            ExecuteFixExistingData(context);

            var companies = context.Empresas.Select(p => new { CompanyId = p.EmpresaId, Name = p.Nombre }).ToList();
            var service = new ExposureCoverageService(context);

            Console.WriteLine("{0}: {1}", "Connected to", context.Database.Connection.DataSource);
            using (var tran = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromMinutes(25)))
            {
                foreach (var company in companies)
                {
                    Console.WriteLine("{0} {1}", "Procesando", company.Name);
                    service.GenerateExposureCoverages(company.CompanyId);
                }

                tran.Complete();
            }

            stopwatch.Stop();
            Console.WriteLine("{0} seconds/ {1} minutes", stopwatch.ElapsedMilliseconds / 1000, stopwatch.ElapsedMilliseconds / 1000 / 60);
            Console.ReadLine();
        }

        private static void ExecuteFixExistingData(ExposureCoverageContext context)
        {
            ExecuteResources(context,
                new[]
                {
                    "ExposureCoverage.CA.fix-existing-data.sql"
                });
        }

        private static void ExecuteResources(DbContext context, IEnumerable<string> resources)
        {
            foreach (var resource in resources)
            {
                SqlBatchExecutor.ExecuteResourceStreamFromExecutingAssembly(context, resource);
            }
        }
    }
}
