using Microsoft.AspNetCore.Mvc;
using Employees.Aplicacion.dtos;
using Employees.Aplicacion.servicio.IServicios;
using Employees.Aplicacion.CustomException


namespace Employees.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")] 
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioReadService _readService;
		private readonly IUsuarioWriteService _writeService;

		public UsuarioController(IUsuarioReadService readService, IUsuarioWriteService writeService)
		{
			_readService = readService;
			_writeService = writeService;
		}

		

		[HttpGet]
		public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetAll()
		{
			try
			{
				var usuarios = await _readService.GetAllAsync();
				return Ok(usuarios);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound(new { message = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UsuarioResponseDTO>> GetById(int id)
		{
			try
			{
				var usuario = await _readService.GetByIdAsync(id);
				return Ok(usuario);
			}
			catch (EntityNotFoundException ex)
			{
				return NotFound(new { message = ex.Message });
			}
		}

		/=====================================

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] UsuarioCreateDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			await _writeService.AddAsync(dto);

		// Retornamos un mensaje de éxito genérico en lugar de devolver el objeto creado,
			// para evitar exponer accidentalmente cualquier dato sensible en tránsito.
			return Ok(new { message = "Usuario creado exitosamente." });
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, [FromBody] UsuarioCreateDTO dto)
		{
			if (id != dto.NumeroEmpleado)
				return BadRequest(new { message = "El ID de la ruta no coincide con el del objeto." });

			if (!ModelState.IsValid) return BadRequest(ModelState);

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