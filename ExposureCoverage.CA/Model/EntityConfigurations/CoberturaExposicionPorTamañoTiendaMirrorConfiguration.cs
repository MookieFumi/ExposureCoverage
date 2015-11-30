using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class CoberturaExposicionPorTamañoTiendaMirrorConfiguration : EntityTypeConfiguration<CoberturaExposicionPorTamañoTiendaMirror>
    {
        public CoberturaExposicionPorTamañoTiendaMirrorConfiguration()
        {
            ToTable("CoberturasExposicionPorTamañoTiendaMirror");
            Property(p => p.CoberturaExposicionPorTamañoTiendaMirrorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}