using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class CoberturaExposicionPorTama�oTiendaConfiguration : EntityTypeConfiguration<CoberturaExposicionPorTama�oTienda>
    {
        public CoberturaExposicionPorTama�oTiendaConfiguration()
        {
            ToTable("CoberturasExposicionPorTama�oTienda");
        }
    }
}