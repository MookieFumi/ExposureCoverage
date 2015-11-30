using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class CoberturaExposicionConfiguration : EntityTypeConfiguration<CoberturaExposicion>
    {
        public CoberturaExposicionConfiguration()
        {
            ToTable("CoberturasExposicion");
        }
    }
}