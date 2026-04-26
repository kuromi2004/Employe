using Microsoft.AspNetCore.Mvc;
using Employees.Aplicacion.dtos;
using Employees.Aplicacion.servicio.IServicios;
using Employees.Aplicacion.CustomException;

namespace Employees.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeriodoController : ControllerBase
    {
        private readonly IPeriodoReadService _readService;
        private readonly IPeriodoWriteService _writeService;

        public PeriodoController(IPeriodoReadService readService, IPeriodoWriteService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeriodoDto>>> GetAll()
        {
            try
            {
                var periodos = await _readService.GetAllAsync();
                return Ok(periodos);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PeriodoDto>> GetById(int id)
        {
            try
            {
                var periodo = await _readService.GetByIdAsync(id);
                return Ok(periodo);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PeriodoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _writeService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.PeriodoID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PeriodoDto dto)
        {
            if (id != dto.PeriodoID)
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
    }
}