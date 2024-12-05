using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusChamadoController : ControllerBase
    {
        private readonly IStatusChamadoService _statusChamadoService;

        public StatusChamadoController(IStatusChamadoService statusChamadoService)
        {
            _statusChamadoService = statusChamadoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusChamadoModel>> GetStatusChamadoById(int id)
        {
            var statusChamado = await _statusChamadoService.GetStatusChamadoByIdAsync(id);
            if (statusChamado == null)
            {
                return NotFound();
            }
            return Ok(statusChamado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusChamadoModel>>> GetAllStatusChamados()
        {
            var statusChamados = await _statusChamadoService.GetAllStatusChamadosAsync();
            return Ok(statusChamados);
        }

        [HttpPost]
        public async Task<ActionResult> AddStatusChamado(StatusChamadoModel statusChamado)
        {
            await _statusChamadoService.AddStatusChamadoAsync(statusChamado);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatusChamado(int id, StatusChamadoModel statusChamado)
        {
            if (id != statusChamado.Id)
            {
                return BadRequest();
            }
            await _statusChamadoService.UpdateStatusChamadoAsync(statusChamado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusChamado(int id)
        {
            await _statusChamadoService.DeleteStatusChamadoAsync(id);
            return NoContent();
        }
    }
}