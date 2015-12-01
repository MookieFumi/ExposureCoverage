using System.Collections.Generic;

namespace ExposureCoverage.CA.Services
{
    public class CompanyChannelBrandDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<ChannelDTO> Channels { get; set; }
        public IEnumerable<BrandDTO> Brands { get; set; }
    }
}