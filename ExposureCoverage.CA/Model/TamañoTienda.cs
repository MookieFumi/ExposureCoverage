using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExposureCoverage.CA.Model
{
    public class TamañoTienda
    {
        public TamañoTienda()
        {
            CoberturaExposicionPorTamañosTienda = new Collection<CoberturaExposicionPorTamañoTienda>();
        }

        public int TamañoTiendaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int EmpresaId { get; set; }

        public virtual ICollection<CoberturaExposicionPorTamañoTienda> CoberturaExposicionPorTamañosTienda { get; set; }
    }
}