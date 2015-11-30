namespace ExposureCoverage.CA.Model
{
    public class NivelClasificacionMarcaParaCoberturaExposicion
    {
        public virtual int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual bool Nivel1Seleccionado { get; set; }
        public virtual bool Nivel2Seleccionado { get; set; }
        public virtual bool Nivel3Seleccionado { get; set; }
        public virtual bool Nivel4Seleccionado { get; set; }
        public virtual bool Nivel5Seleccionado { get; set; }
        public virtual bool Nivel6Seleccionado { get; set; }
        public virtual bool Nivel7Seleccionado { get; set; }
        public virtual bool Nivel8Seleccionado { get; set; }
        public virtual bool Nivel9Seleccionado { get; set; }
        public virtual bool Nivel10Seleccionado { get; set; }
    }
}