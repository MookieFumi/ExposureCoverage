using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            ToTable("Empresas");
        }
    }
}