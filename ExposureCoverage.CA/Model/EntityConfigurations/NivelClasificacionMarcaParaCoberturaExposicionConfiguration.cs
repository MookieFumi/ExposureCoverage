using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class NivelClasificacionMarcaParaCoberturaExposicionConfiguration : EntityTypeConfiguration<NivelClasificacionMarcaParaCoberturaExposicion>
    {
        public NivelClasificacionMarcaParaCoberturaExposicionConfiguration()
        {
            ToTable("NivelesClasificacionMarcaParaCoberturaExposicion");

            HasRequired(x => x.Marca).WithRequiredDependent(x => x.NivelClasificacionMarcaParaCoberturaExposicion).WillCascadeOnDelete(true);
            HasKey(x => x.MarcaId);
        }
    }
}