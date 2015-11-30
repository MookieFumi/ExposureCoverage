using System.ComponentModel.DataAnnotations.Schema;

namespace ExposureCoverage.CA.Model
{
    public class CoberturaExposicionPorTamañoTiendaMirror
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int CoberturaExposicionPorTamañoTiendaMirrorId { get; set; }

        public virtual int CoberturaExposicionMirrorId { get; set; }
        public virtual CoberturaExposicionMirror CoberturaExposicionMirror { get; set; }

        public virtual int TamañoTiendaId { get; set; }
        public virtual TamañoTienda TamañoTienda { get; set; }

        public virtual int ValorExposicion { get; set; }
    }
}