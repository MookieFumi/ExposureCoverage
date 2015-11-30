using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class CoberturaExposicionPorTamañoTiendaConfiguration : EntityTypeConfiguration<CoberturaExposicionPorTamañoTienda>
    {
        public CoberturaExposicionPorTamañoTiendaConfiguration()
        {
            ToTable("CoberturasExposicionPorTamañoTienda");
        }
    }
}