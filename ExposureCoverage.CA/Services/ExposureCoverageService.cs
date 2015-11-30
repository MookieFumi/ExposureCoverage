using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AutoMapper;
using ExposureCoverage.CA.Model;
using ExposureCoverage.CA.Model.Extensions;

namespace ExposureCoverage.CA.Services
{
    public class ExposureCoverageService : IExposureCoverageService
    {
        private const int FlujoDefinicionIdCoberturaExposicion = 14;
        private readonly ExposureCoverageContext _context;

        public ExposureCoverageService(ExposureCoverageContext context)
        {
            _context = context;
            CreateMappings();
        }

        public void GenerateExposureCoverages(int companyId)
        {
            var exposureCoverages = Enumerable.Empty<CoberturaExposicion>().ToList();

            var brands = _context.Marcas.Where(p => p.EmpresaId == companyId).ToList();
            var shopSizes = _context.TamañosTienda.Where(p => p.EmpresaId == companyId).Select(p => p.TamañoTiendaId);
            foreach (var brand in brands)
            {
                Console.WriteLine("{0} - {1}", brand.MarcaId, brand.Nombre);
                var levels = GetClassificacionLevelsSelected(brand.MarcaId).ToList();
                if (levels.Count > 0)
                {
                    var values = _context.Database
                        .SqlQuery<ClassificationLevelValueDTO>(
                            GetClassificationLevelValueSql(_context.GetTableName<Producto>(), levels),
                            new SqlParameter("@companyId", companyId), new SqlParameter("@brandId", brand.MarcaId))
                        .ToList();
                    var channels = _context.Canales.Where(p => p.EmpresaId == companyId).Select(p => p.CanalId).ToList();

                    foreach (var channelId in channels)
                    {
                        var activatedFlow = _context.SecuenciaUsuarios.Any(p => p.CanalId == channelId && p.FlujoDefinicionId == FlujoDefinicionIdCoberturaExposicion);
                        if (!activatedFlow)
                        {
                            foreach (var value in values)
                            {
                                var sqlParameters = GetExposureCoverageParameters(companyId, brand.MarcaId, channelId, levels, value).ToArray();
                                var query = _context.CoberturasExposicion.SqlQuery(GetExposureCoverageSql(levels), sqlParameters).ToList();
                                if (!query.Any())
                                {
                                    var exposureCoverage = CreateExposureCoverage(companyId, channelId, brand.MarcaId, value, shopSizes);
                                    exposureCoverages.Add(exposureCoverage);
                                }
                            }
                        }
                    }
                }
            }

            if (exposureCoverages.Any())
            {
                _context.CoberturasExposicion.AddRange(exposureCoverages);
                _context.SaveChanges();
                _context.CoberturasExposicionMirror.AddRange(Mapper.Map<IEnumerable<CoberturaExposicion>, IEnumerable<CoberturaExposicionMirror>>(exposureCoverages));
                _context.SaveChanges();
            }
        }

        private static void CreateMappings()
        {
            Mapper.CreateMap<ClassificationLevelValueDTO, CoberturaExposicion>();

            Mapper.CreateMap<CoberturaExposicion, CoberturaExposicionMirror>()
                .ForMember(dst => dst.CoberturaExposicionMirrorId, opt => opt.MapFrom(src => src.CoberturaExposicionId));

            Mapper.CreateMap<CoberturaExposicionPorTamañoTienda, CoberturaExposicionPorTamañoTiendaMirror>()
                .ForMember(dst => dst.CoberturaExposicionMirrorId, opt => opt.MapFrom(src => src.CoberturaExposicionId))
                .ForMember(dst => dst.CoberturaExposicionPorTamañoTiendaMirrorId,
                    opt => opt.MapFrom(src => src.CoberturaExposicionPorTamañoTiendaId));
        }

        private CoberturaExposicion CreateExposureCoverage(int companyId, int channelId, int brandId, ClassificationLevelValueDTO value, IEnumerable<int> shopSizes)
        {
            var exposureCoverage = Mapper.Map<ClassificationLevelValueDTO, CoberturaExposicion>(value);
            exposureCoverage.EmpresaId = companyId;
            exposureCoverage.CanalId = channelId;
            exposureCoverage.MarcaId = brandId;
            exposureCoverage.CoberturaMinima = 0;
            exposureCoverage.CoberturaMedia = 0;
            exposureCoverage.CoberturaMaxima = 0;
            exposureCoverage.Consolidado = true;
            foreach (var shopSize in shopSizes)
            {
                exposureCoverage.CoberturasExposicionPorTamañoTienda.Add(new CoberturaExposicionPorTamañoTienda
                {
                    TamañoTiendaId = shopSize,
                    ValorExposicion = 0,
                    Consolidado = true
                });
            }
            return exposureCoverage;
        }

        private IEnumerable<SqlParameter> GetExposureCoverageParameters(int companyId, int brandId, int channelId, List<int> selectedLevels, ClassificationLevelValueDTO value)
        {
            IList<SqlParameter> objects = new List<SqlParameter>();
            objects.Add(new SqlParameter("@companyId", companyId));
            objects.Add(new SqlParameter("@brandId", brandId));
            objects.Add(new SqlParameter("@channelId", channelId));
            foreach (var selectedLevel in selectedLevels)
            {
                var propertyInfo =
                    typeof(ClassificationLevelValueDTO).GetProperties()
                        .Single(p => p.Name.Equals("NivelClasificacion" + selectedLevel));
                objects.Add(new SqlParameter("@nivel" + selectedLevel, (string)(propertyInfo.GetValue(value, null))));
            }
            return objects.ToArray();
        }

        private string GetExposureCoverageSql(IList<int> levelsSelected)
        {
            var sql =
                "SELECT * FROM CoberturasExposicion WHERE EmpresaId = @companyId AND CanalId = @channelId AND MarcaId = @brandId AND ";
            for (var i = 0; i < levelsSelected.Count(); i++)
            {
                if (i == levelsSelected.Count() - 1)
                {
                    sql += string.Format("{0}{1} = @nivel{1}", "NivelClasificacion", levelsSelected[i]);
                }
                else
                {
                    sql += string.Format("{0}{1} = @nivel{1} AND ", "NivelClasificacion", levelsSelected[i]);
                }
            }
            return sql;
        }

        private string GetClassificationLevelValueSql(string tableName, IList<int> levelsSelected)
        {
            var sql = "SELECT DISTINCT ";
            for (var i = 0; i < levelsSelected.Count(); i++)
            {
                var field = string.Format("COALESCE({0}{1}, '') AS NivelClasificacion{1}", "NivelClasificacion",
                    levelsSelected[i]);
                if (i == levelsSelected.Count() - 1)
                {
                    sql += field;
                }
                else
                {
                    sql += string.Format("{0}{1}", field, ",");
                }
            }
            sql += string.Format(" FROM {0} WHERE EmpresaId = @companyId AND MarcaId = @brandId", tableName);

            return sql;
        }

        private IEnumerable<int> GetClassificacionLevelsSelected(int brandId)
        {
            var classificacionLevelsSelected = Enumerable.Empty<int>().ToList();

            var classificationLevel =
                _context.NivelesClasificacionMarcaParaCoberturaExposicion.Single(p => p.MarcaId == brandId);
            if (classificationLevel.Nivel1Seleccionado)
            {
                classificacionLevelsSelected.Add(1);
            }
            if (classificationLevel.Nivel2Seleccionado)
            {
                classificacionLevelsSelected.Add(2);
            }
            if (classificationLevel.Nivel3Seleccionado)
            {
                classificacionLevelsSelected.Add(3);
            }
            if (classificationLevel.Nivel4Seleccionado)
            {
                classificacionLevelsSelected.Add(4);
            }
            if (classificationLevel.Nivel5Seleccionado)
            {
                classificacionLevelsSelected.Add(5);
            }
            if (classificationLevel.Nivel6Seleccionado)
            {
                classificacionLevelsSelected.Add(6);
            }
            if (classificationLevel.Nivel7Seleccionado)
            {
                classificacionLevelsSelected.Add(7);
            }
            if (classificationLevel.Nivel8Seleccionado)
            {
                classificacionLevelsSelected.Add(8);
            }
            if (classificationLevel.Nivel9Seleccionado)
            {
                classificacionLevelsSelected.Add(9);
            }
            if (classificationLevel.Nivel10Seleccionado)
            {
                classificacionLevelsSelected.Add(10);
            }

            return classificacionLevelsSelected;
        }
    }
}