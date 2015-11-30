using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class FlujoConfiguracionSecuenciaUsuarioConfiguration : EntityTypeConfiguration<FlujoConfiguracionSecuenciaUsuario>
    {
        public FlujoConfiguracionSecuenciaUsuarioConfiguration()
        {
            ToTable("FlujoConfiguracionSecuenciaUsuarios");
        }
    }
}