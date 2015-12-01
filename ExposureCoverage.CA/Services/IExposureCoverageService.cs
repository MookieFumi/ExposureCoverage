using System.Collections.Generic;

namespace ExposureCoverage.CA.Services
{
    public interface IExposureCoverageService
    {
        int GenerateExposureCoverages(int companyId, IEnumerable<ChannelDTO> channels, int brandId);
    }
}