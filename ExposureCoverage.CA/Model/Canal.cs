using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExposureCoverage.CA.Model
{
    public class Canal
    {
        public Canal()
        {
            CoberturasExposicion = new Collection<CoberturaExposicion>();
        }

        public int CanalId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int EmpresaId { get; set; }

        public int? NivelMaximoCargoGerenteId { get; set; }

        public int? NivelMaximoCargoVendedorId { get; set; }

        public bool ConGerente { get; set; }
        public bool ConObjetivosCualitativos { get; set; }

        public virtual ICollection<CoberturaExposicion> CoberturasExposicion { get; set; }
    }
}