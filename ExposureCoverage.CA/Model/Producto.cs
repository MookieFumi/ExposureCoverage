namespace ExposureCoverage.CA.Model
{
    public class Producto
    {
        public Producto()
        {
        }

        public virtual int ProductoId { get; set; }

        public virtual int EmpresaId { get; set; }

        public virtual int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

        public virtual string CodigoProducto { get; set; }
        public virtual string CodigoProductoRaiz { get; set; }
        public virtual string CodigoEan { get; set; }
        public virtual string Descripcion { get; set; }

        public virtual string NivelClasificacion1 { get; set; }
        public virtual string NivelClasificacion2 { get; set; }
        public virtual string NivelClasificacion3 { get; set; }
        public virtual string NivelClasificacion4 { get; set; }
        public virtual string NivelClasificacion5 { get; set; }
        public virtual string NivelClasificacion6 { get; set; }
        public virtual string NivelClasificacion7 { get; set; }
        public virtual string NivelClasificacion8 { get; set; }
        public virtual string NivelClasificacion9 { get; set; }
        public virtual string NivelClasificacion10 { get; set; }

        public virtual string ThumbnailUrl { get; set; }
        public virtual string Url { get; set; }

        public virtual string Talla { get; set; }

        public virtual decimal? PrecioCompra { get; set; }
        public virtual decimal? PrecioCompra2 { get; set; }
        public virtual decimal? PrecioCompra3 { get; set; }
        public virtual decimal? PrecioVenta { get; set; }
        public virtual decimal? PrecioVenta2 { get; set; }
        public virtual decimal? PrecioVenta3 { get; set; }

        public virtual bool Novedad { get; set; }
        public virtual bool Descatalogado { get; set; }
    }
}