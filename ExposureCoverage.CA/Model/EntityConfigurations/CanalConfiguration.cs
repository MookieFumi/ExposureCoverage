using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class CanalConfiguration : EntityTypeConfiguration<Canal>
    {
        public CanalConfiguration()
        {
            ToTable("Canales");
        }
    }
}