using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusServicoController : ControllerBase
    {
        private readonly IStatusServicoService _statusServicoService;

        public StatusServicoController(IStatusServicoService statusServicoService)
        {
            _statusServicoService = statusServicoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusServicoModel>>> GetStatusServicos()
        {
            var statusServicos = await _statusServicoService.GetAllStatusServicosAsync();
            return Ok(statusServicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusServicoModel>> GetStatusServicoById(int id)
        {
            var statusServico = await _statusServicoService.GetStatusServicoByIdAsync(id);

            if (statusServico == null)
            {
                return NotFound();
            }

            return Ok(statusServico);
        }

        [HttpPost]
        public async Task<ActionResult<StatusServicoModel>> AddStatusServico(StatusServicoModel statusServico)
        {
            await _statusServicoService.AddStatusServicoAsync(statusServico);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatusServico(int id, StatusServicoModel statusServico)
        {
            if (id != statusServico.Id)
            {
                return BadRequest();
            }

            await _statusServicoService.UpdateStatusServicoAsync(statusServico);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusServico(int id)
        {
            await _statusServicoService.DeleteStatusServicoAsync(id);
            return NoContent();
        }
    }
}
