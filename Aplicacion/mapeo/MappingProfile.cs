using AutoMapper;
using Employees.Aplicacion.dtos;
using Employees.Dominio.Entidades;
using EMPLOYEES.Aplicacion.dtos;
using static Employees.Aplicacion.dtos.VacacionDto;

namespace Employees.Aplicacion.mapeo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Empresa, EmpresaDto>()
                .ForMember(dest => dest.IDEmpresa, opt => opt.MapFrom(src => src.IdEmpresa))
                .ReverseMap();

            CreateMap<Periodo, PeriodoDto>()
                .ForMember(dest => dest.PeriodoID, opt => opt.MapFrom(src => src.PeriodoId))
                .ReverseMap();

            CreateMap<RegistroJornada, RegistroJornadaDto>()
                .ForMember(dest => dest.RegistroID, opt => opt.MapFrom(src => src.RegistroId))
                .ReverseMap();

           
            CreateMap<UsuarioCreateDTO, Usuario>()
                .ForMember(dest => dest.Contrasena, opt => opt.Ignore());

            
            CreateMap<Usuario, UsuarioResponseDTO>()
                .ForMember(dest => dest.NombreCompleto,
                    opt => opt.MapFrom(src => $"{src.Nombres} {src.Apellidos}"))
               
                .ForMember(dest => dest.NumeroEmpleadoFormateado,
                    opt => opt.MapFrom(src => src.NumeroEmpleado.ToString("D5")));

            // Command
            CreateMap<VacacionDto.VacacionCreateDTO, Vacacion>()
                .ForMember(dest => dest.EstadoAprobacion, opt => opt.Ignore())
                .ForMember(dest => dest.AprobadorId, opt => opt.Ignore());

            // Query
            CreateMap<Vacacion, VacacionDto.VacacionResponseDTO>()
                .ForMember(dest => dest.NombreSolicitante,
                    opt => opt.MapFrom(src => src.Solicitante != null
                        ? $"{src.Solicitante.Nombres} {src.Solicitante.Apellidos}"
                        : "Desconocido"))
                .ForMember(dest => dest.NombreAprobador,
                    opt => opt.MapFrom(src => src.Aprobador != null
                        ? $"{src.Aprobador.Nombres} {src.Aprobador.Apellidos}"
                        : "Sin asignar"));
        }
    }

}