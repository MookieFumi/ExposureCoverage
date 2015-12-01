using System.Collections.Generic;

namespace ExposureCoverage.CA.Services
{
    public interface ICompanyService
    {
        IEnumerable<CompanyChannelBrandDTO> GetCompanies();
    }
}