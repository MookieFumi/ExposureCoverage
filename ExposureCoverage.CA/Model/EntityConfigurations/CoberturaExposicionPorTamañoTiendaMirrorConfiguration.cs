using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class CoberturaExposicionPorTama�oTiendaMirrorConfiguration : EntityTypeConfiguration<CoberturaExposicionPorTama�oTiendaMirror>
    {
        public CoberturaExposicionPorTama�oTiendaMirrorConfiguration()
        {
            ToTable("CoberturasExposicionPorTama�oTiendaMirror");
            Property(p => p.CoberturaExposicionPorTama�oTiendaMirrorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}