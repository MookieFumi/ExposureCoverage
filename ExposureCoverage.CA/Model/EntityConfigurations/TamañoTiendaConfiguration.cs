using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class TamañoTiendaConfiguration : EntityTypeConfiguration<TamañoTienda>
    {
        public TamañoTiendaConfiguration()
        {
            ToTable("TamañosTienda");
        }
    }
}