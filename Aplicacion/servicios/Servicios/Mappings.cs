using AutoMapper;
using Employees.Dominio.Entidades;
using Employees.Dominio.interfaces;
using Employees.Aplicacion.dtos;
using Employees.Aplicacion.servicio.IServicios;
using Employees.Aplicacion.CustomException;

namespace Employees.Aplicacion.servicio.servicios
{

    public class EmpresaWriteService : WriteServiceAsync<Empresa, EmpresaDto>, IEmpresaWriteService
    {
        public EmpresaWriteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }


    public class PeriodoWriteService : WriteServiceAsync<Periodo, PeriodoDto>, IPeriodoWriteService
    {
        public PeriodoWriteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }

    public class RegistroJornadaWriteService : WriteServiceAsync<RegistroJornada, RegistroJornadaDto>, IRegistroJornadaWriteService
    {
        public RegistroJornadaWriteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }
    public class EmpresaReadService : ReadServiceAsync<Empresa, EmpresaDto>, IEmpresaReadService
    {
        public EmpresaReadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }


    public class PeriodoReadService : ReadServiceAsync<Periodo, PeriodoDto>, IPeriodoReadService
    {
        public PeriodoReadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }


    public class RegistroJornadaReadService : ReadServiceAsync<RegistroJornada, RegistroJornadaDto>, IRegistroJornadaReadService
    {
        public RegistroJornadaReadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }

   
    public class VacacionReadService : ReadServiceAsync<Vacacion, VacacionDto.VacacionResponseDTO>, IVacacionReadService
    {
        public VacacionReadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }

    // 5. USUARIO (Ojo aquí: usa UsuarioResponseDTO)
    public class UsuarioReadService : ReadServiceAsync<Usuario, UsuarioResponseDTO>, IUsuarioReadService
    {
        public UsuarioReadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }
    public class VacacionWriteService : WriteServiceAsync<Vacacion, VacacionDto.VacacionCreateDTO>, IVacacionWriteService
    {
        public VacacionWriteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task EvaluarVacacionAsync(VacacionDto.VacacionAprobacionDTO dto)
        {
            // 1. Buscamos la solicitud en la base de datos
            var vacacion = await _unitOfWork.Repository<Vacacion>().GetByIdAsync(dto.VacacionId);

            if (vacacion == null)
            {
                throw new EntityNotFoundException($"No se encontró la solicitud de vacación con ID {dto.VacacionId}");
            }


            if (vacacion.EstadoAprobacion != "Pendiente")
            {
                throw new InvalidOperationException("Esta solicitud ya fue evaluada anteriormente.");
            }

            vacacion.EstadoAprobacion = dto.EstadoDecision;
            vacacion.AprobadorId = dto.AprobadorId;


            await _unitOfWork.Repository<Vacacion>().UpdateAsync(vacacion);
            await _unitOfWork.SaveChangesAsync();
        } }

    public class UsuarioWriteService : WriteServiceAsync<Usuario, UsuarioCreateDTO>, IUsuarioWriteService
    {
        public UsuarioWriteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task AddAsync(UsuarioCreateDTO dto)
        {
            var usuarioEntity = _mapper.Map<Usuario>(dto);

            // Hashear la contraseña
            // 
            usuarioEntity.Contrasena = HashearContrasenaSegura(dto.ContrasenaPlana);


            await _unitOfWork.Repository<Usuario>().AddAsync(usuarioEntity);
            await _unitOfWork.SaveChangesAsync();
        }


        private byte[] HashearContrasenaSegura(string contrasenaPlana)
        {
            // 
            // En tu código real, aquí usarías tu lógica de hashing con tu "Salt" o "Secret" de Azure
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                return hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasenaPlana));
            }
        }
    } }