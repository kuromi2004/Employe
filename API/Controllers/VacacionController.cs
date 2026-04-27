using Employees.Aplicacion.CustomException;
using Employees.Aplicacion.dtos;
using Employees.Aplicacion.servicio.IServicios;
using Microsoft.AspNetCore.Mvc;

namespace Employees.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacacionController : ControllerBase
    {
        private readonly IVacacionReadService _readService;
        private readonly IVacacionWriteService _writeService;

        public VacacionController(IVacacionReadService readService, IVacacionWriteService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        // --- QUERIES (Devuelven VacacionResponseDTO) ---

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacacionDto.VacacionResponseDTO>>> GetAll()
        {
            try
            {
                var vacaciones = await _readService.GetAllAsync();
                return Ok(vacaciones);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VacacionDto.VacacionResponseDTO>> GetById(int id)
        {
            try
            {
                var vacacion = await _readService.GetByIdAsync(id);
                return Ok(vacacion);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // --- COMMANDS (Reciben VacacionCreateDTO) ---

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] VacacionDto.VacacionCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _writeService.AddAsync(dto);

            
            return Ok(new { message = "Solicitud de vacaciones creada exitosamente." });
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] VacacionDto.VacacionCreateDTO dto)
        {
            // Para este ejemplo básico usamos el Update genérico, pero ten en cuenta
            // que podrías necesitar lógica específica en VacacionWriteService.UpdateAsync
            await _writeService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _writeService.DeleteAsync(id);
            return NoContent();
        }
       

        [HttpPatch("{id}/evaluar")]
        public async Task<ActionResult> EvaluarSolicitud(int id, [FromBody] VacacionDto.VacacionAprobacionDTO dto)
        {
            if (id != dto.VacacionId)
            {
                return BadRequest(new { message = "El ID de la ruta no coincide con el del objeto." });
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _writeService.EvaluarVacacionAsync(dto);

                return Ok(new { message = $"La solicitud de vacaciones ha sido {dto.EstadoDecision.ToLower()} con éxito." });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message }); // 400 Bad Request si rompe la regla de negocio
            }
        }
    }
}