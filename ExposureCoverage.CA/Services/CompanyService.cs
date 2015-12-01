using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExposureCoverage.CA.Model;

namespace ExposureCoverage.CA.Services
{
    public class CompanyService : ServiceBase, ICompanyService
    {
        public CompanyService(ExposureCoverageContext context) : base(context)
        {
            SetMappings();
        }

        public IEnumerable<CompanyChannelBrandDTO> GetCompanies()
        {
            return Context.Empresas
                .Include(p => p.Marcas)
                .Include(p => p.Canales)
                .ProjectTo<CompanyChannelBrandDTO>()
                .ToList();
        }

        private static void SetMappings()
        {
            Mapper.CreateMap<Marca, BrandDTO>()
                .ForMember(dst => dst.BrandId, opt => opt.MapFrom(src => src.MarcaId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Nombre));

            Mapper.CreateMap<Canal, ChannelDTO>()
                .ForMember(dst => dst.ChannelId, opt => opt.MapFrom(src => src.CanalId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Nombre));

            Mapper.CreateMap<Empresa, CompanyChannelBrandDTO>()
                .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.EmpresaId))
                .ForMember(dst => dst.CompanyName, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dst => dst.Channels, opt => opt.MapFrom(src => src.Canales))
                .ForMember(dst => dst.Brands, opt => opt.MapFrom(src => src.Marcas));
        }
    }
}