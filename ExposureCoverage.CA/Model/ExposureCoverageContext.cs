using System.Data.Entity;
using ExposureCoverage.CA.Model.EntityConfigurations;

namespace ExposureCoverage.CA.Model
{
    public class ExposureCoverageContext : DbContext
    {
        public ExposureCoverageContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer<ExposureCoverageContext>(null);
        }

        public ExposureCoverageContext() : base("ExposureCoverageContext")
        {
            Database.SetInitializer<ExposureCoverageContext>(null);
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Canal> Canales { get; set; }
        public DbSet<CoberturaExposicion> CoberturasExposicion { get; set; }
        public DbSet<CoberturaExposicionMirror> CoberturasExposicionMirror { get; set; }
        public DbSet<NivelClasificacionMarcaParaCoberturaExposicion> NivelesClasificacionMarcaParaCoberturaExposicion { get; set; }
        public DbSet<FlujoConfiguracionSecuenciaUsuario> SecuenciaUsuarios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        //public DbSet<Producto> Productos { get; set; }
        public DbSet<TamañoTienda> TamañosTienda { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CanalConfiguration());
            modelBuilder.Configurations.Add(new CoberturaExposicionConfiguration());
            modelBuilder.Configurations.Add(new CoberturaExposicionPorTamañoTiendaConfiguration());
            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new FlujoConfiguracionSecuenciaUsuarioConfiguration());
            modelBuilder.Configurations.Add(new MarcaConfiguration());
            modelBuilder.Configurations.Add(new NivelClasificacionMarcaParaCoberturaExposicionConfiguration());
            modelBuilder.Configurations.Add(new ProductoConfiguration());
            modelBuilder.Configurations.Add(new TamañoTiendaConfiguration());

            modelBuilder.Configurations.Add(new CoberturaExposicionMirrorConfiguration());
            modelBuilder.Configurations.Add(new CoberturaExposicionPorTamañoTiendaMirrorConfiguration());
        }
    }
}
