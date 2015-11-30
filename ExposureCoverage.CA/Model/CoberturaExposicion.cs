using System.Collections.Generic;

namespace ExposureCoverage.CA.Model
{
    public class CoberturaExposicion
    {
        public CoberturaExposicion()
        {
            CoberturasExposicionPorTamañoTienda = new HashSet<CoberturaExposicionPorTamañoTienda>();
        }

        public int CoberturaExposicionId { get; set; }
        public int EmpresaId { get; set; }
        public int CanalId { get; set; }

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

        public bool Bloqueado { get; set; }
        public bool Consolidado { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<CoberturaExposicionPorTamañoTienda> CoberturasExposicionPorTamañoTienda { get; set; }
    }
}