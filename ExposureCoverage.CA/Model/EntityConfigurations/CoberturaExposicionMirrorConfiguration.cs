using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class CoberturaExposicionMirrorConfiguration : EntityTypeConfiguration<CoberturaExposicionMirror>
    {
        public CoberturaExposicionMirrorConfiguration()
        {
            ToTable("CoberturasExposicionMirror");
            Property(p => p.CoberturaExposicionMirrorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(p => p.NivelClasificacion1).HasMaxLength(100);
            Property(p => p.NivelClasificacion2).HasMaxLength(100);
            Property(p => p.NivelClasificacion3).HasMaxLength(100);
            Property(p => p.NivelClasificacion4).HasMaxLength(100);
            Property(p => p.NivelClasificacion5).HasMaxLength(100);
            Property(p => p.NivelClasificacion6).HasMaxLength(100);
            Property(p => p.NivelClasificacion7).HasMaxLength(100);
            Property(p => p.NivelClasificacion8).HasMaxLength(100);
            Property(p => p.NivelClasificacion9).HasMaxLength(100);
            Property(p => p.NivelClasificacion10).HasMaxLength(100);

            HasMany(p => p.CoberturasExposicionPorTamañoTienda).WithRequired(p => p.CoberturaExposicionMirror).WillCascadeOnDelete(true);
        }
    }
}