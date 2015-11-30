using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class TamaņoTiendaConfiguration : EntityTypeConfiguration<TamaņoTienda>
    {
        public TamaņoTiendaConfiguration()
        {
            ToTable("TamaņosTienda");
        }
    }
}