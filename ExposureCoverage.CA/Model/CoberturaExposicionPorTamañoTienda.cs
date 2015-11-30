namespace ExposureCoverage.CA.Model
{
    public class CoberturaExposicionPorTamañoTienda
    {
        public virtual int CoberturaExposicionPorTamañoTiendaId { get; set; }
        public virtual int CoberturaExposicionId { get; set; }
        public virtual CoberturaExposicion CoberturaExposicion { get; set; }
        public virtual int TamañoTiendaId { get; set; }
        public virtual int ValorExposicion { get; set; }
        public virtual bool Consolidado { get; set; }
    }
}