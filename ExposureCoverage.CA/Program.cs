using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Transactions;
using ExposureCoverage.CA.Infrastructure;
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

            var exposureCoverageService = new ExposureCoverageService(context);
            var companieService = new CompanyService(context);
            var companies = companieService.GetCompanies();

            Console.WriteLine("{0}: {1}", "Connected to", context.Database.Connection.DataSource);
            using (var tran = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromMinutes(25)))
            {
                foreach (var company in companies)
                {
                    Console.WriteLine("{0} company {1}", "processing", company.CompanyName);
                    foreach (var brand in company.Brands)
                    {
                        Console.WriteLine("\t \t brand {0}", brand.Name);
                        exposureCoverageService.GenerateExposureCoverages(company.CompanyId, company.Channels, brand.BrandId);
                    }
                }
                tran.Complete();
            }

            stopwatch.Stop();
            Console.WriteLine("{0} seconds/ {1} minutes", stopwatch.ElapsedMilliseconds / 1000, stopwatch.ElapsedMilliseconds / 1000 / 60);
            Console.ReadLine();
        }

        private static void ExecuteFixExistingData(DbContext context)
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
