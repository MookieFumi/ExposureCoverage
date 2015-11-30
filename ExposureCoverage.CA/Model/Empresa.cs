using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExposureCoverage.CA.Model
{
    public class Empresa
    {
        public Empresa()
        {
            Canales = new Collection<Canal>();
            Marcas = new Collection<Marca>();
            FlujoConfiguracionSecuenciaUsuarios = new Collection<FlujoConfiguracionSecuenciaUsuario>();
        }

        public  int EmpresaId { get; set; }
        public  string Nombre { get; set; }
        public  string Descripcion { get; set; }
        public  string Culture { get; set; }
        public  string TimeZoneInfoId { get; set; }
        public int PrimerDiaSemana { get; set; }
        public int DuracionLanzamiento { get; set; }
        public decimal PorcentajeParticipacionEnNuevaColeccion { get; set; }


        public virtual ICollection<Canal> Canales { get; set; }
        public virtual ICollection<Marca> Marcas { get; set; }
        public virtual ICollection<FlujoConfiguracionSecuenciaUsuario> FlujoConfiguracionSecuenciaUsuarios { get; set; }
    }
}