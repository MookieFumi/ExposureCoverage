using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class Tama�oTiendaConfiguration : EntityTypeConfiguration<Tama�oTienda>
    {
        public Tama�oTiendaConfiguration()
        {
            ToTable("Tama�osTienda");
        }
    }
}