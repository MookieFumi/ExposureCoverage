namespace ExposureCoverage.CA.Model
{
    public class FlujoConfiguracionSecuenciaUsuario
    {
        public int FlujoConfiguracionSecuenciaUsuarioId { get; set; }

        public int EmpresaId { get; set; }

        public int? CanalId { get; set; }
        public virtual Canal Canal { get; set; }

        public int UsuarioId { get; set; }

        public int FlujoDefinicionId { get; set; }

        public int Orden { get; set; }
    }
}