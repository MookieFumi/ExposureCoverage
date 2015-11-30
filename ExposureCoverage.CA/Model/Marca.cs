using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExposureCoverage.CA.Model
{
    public class Marca
    {
        public Marca()
        {
            Productos = new Collection<Producto>();
            CoberturasExposicion = new Collection<CoberturaExposicion>();
        }

        public  int MarcaId { get; set; }

        public  string CodigoMarca { get; set; }

        public  string Nombre { get; set; }

        public  int EmpresaId { get; set; }

        public  int NivelMaximoClasificacion { get; set; }

        public virtual NivelClasificacionMarcaParaCoberturaExposicion NivelClasificacionMarcaParaCoberturaExposicion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<CoberturaExposicion> CoberturasExposicion { get; set; }
    }
}