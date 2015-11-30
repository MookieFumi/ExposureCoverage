using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExposureCoverage.CA.Model
{
    public class CoberturaExposicionMirror
    {
        public CoberturaExposicionMirror()
        {
            CoberturasExposicionPorTamañoTienda = new Collection<CoberturaExposicionPorTamañoTiendaMirror>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CoberturaExposicionMirrorId { get; set; }
        public int EmpresaId { get; set; }

        public int CanalId { get; set; }
        public virtual Canal Canal { get; set; }

        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

        public string NivelClasificacion1 { get; set; }
        public string NivelClasificacion2 { get; set; }
        public string NivelClasificacion3 { get; set; }
        public string NivelClasificacion4 { get; set; }
        public string NivelClasificacion5 { get; set; }
        public string NivelClasificacion6 { get; set; }
        public string NivelClasificacion7 { get; set; }
        public string NivelClasificacion8 { get; set; }
        public string NivelClasificacion9 { get; set; }
        public string NivelClasificacion10 { get; set; }

        public int CoberturaMinima { get; set; }
        public int CoberturaMedia { get; set; }
        public int CoberturaMaxima { get; set; }

        public virtual ICollection<CoberturaExposicionPorTamañoTiendaMirror> CoberturasExposicionPorTamañoTienda { get; set; }
    }
}