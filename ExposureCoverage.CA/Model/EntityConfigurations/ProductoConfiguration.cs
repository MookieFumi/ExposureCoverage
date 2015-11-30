using System.Data.Entity.ModelConfiguration;

namespace ExposureCoverage.CA.Model.EntityConfigurations
{
    public class ProductoConfiguration : EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguration()
        {
            ToTable("Productos");
        }
    }
}