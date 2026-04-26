using Employees.Dominio.Entidades;
using Employees.Aplicacion.dtos;
using Employees.Aplicacion.dtos; 

namespace Employees.Aplicacion.servicio.IServicios
{//leer
    public interface IEmpresaReadService : IReadServiceAsync<Empresa, EmpresaDto> { }
    public interface IPeriodoReadService : IReadServiceAsync<Periodo, PeriodoDto> { }
    public interface IRegistroJornadaReadService : IReadServiceAsync<RegistroJornada, RegistroJornadaDto> { }
    public interface IUsuarioReadService : IReadServiceAsync<Usuario, UsuarioResponseDTO> { }
    public interface IVacacionReadService : IReadServiceAsync<Vacacion, VacacionDto.VacacionResponseDTO> { }

    // escribir
    public interface IEmpresaWriteService : IWriteServiceAsync<Empresa, EmpresaDto> { }
    public interface IPeriodoWriteService : IWriteServiceAsync<Periodo, PeriodoDto> { }
    public interface IRegistroJornadaWriteService : IWriteServiceAsync<RegistroJornada, RegistroJornadaDto> { }
    public interface IUsuarioWriteService : IWriteServiceAsync<Usuario, UsuarioCreateDTO> { }
    public interface IVacacionWriteService : IWriteServiceAsync<Vacacion, VacacionDto.VacacionCreateDTO> { }
    public interface IVacacionWriteService : IWriteServiceAsync<Vacacion, VacacionDto.VacacionCreateDTO>
    {
        Task EvaluarVacacionAsync(VacacionDto.VacacionAprobacionDTO dto);
    }
}