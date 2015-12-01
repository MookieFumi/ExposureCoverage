using ExposureCoverage.CA.Model;

namespace ExposureCoverage.CA.Services
{
    public abstract class ServiceBase
    {
        protected readonly ExposureCoverageContext Context;

        protected ServiceBase(ExposureCoverageContext context)
        {
            Context = context;
        }
    }
}