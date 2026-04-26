using Microsoft.AspNetCore.Mvc;
using Employees.Aplicacion.dtos;
using Employees.Aplicacion.servicio.IServicios;
using Employees.Aplicacion.CustomException;

namespace Employees.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaReadService _readService;
        private readonly IEmpresaWriteService _writeService;

        public EmpresaController(IEmpresaReadService readService, IEmpresaWriteService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> GetAll()
        {
            try
            {
                var empresas = await _readService.GetAllAsync();
                return Ok(empresas);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaDto>> GetById(int id)
        {
            try
            {
                var empresa = await _readService.GetByIdAsync(id);
                return Ok(empresa);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmpresaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _writeService.AddAsync(dto);
           
            return CreatedAtAction(nameof(GetById), new { id = dto.IDEmpresa }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EmpresaDto dto)
        {
            if (id != dto.ID_empresa)
                return BadRequest(new { message = "El ID de la ruta no coincide con el del objeto." });

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