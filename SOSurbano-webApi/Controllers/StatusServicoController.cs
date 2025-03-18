using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Authorize(Roles = "1")]
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
            var statusServicos = await _statusServicoService.GetAllAsync();
            return Ok(statusServicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusServicoModel>> GetStatusServicoById(ObjectId id)
        {
            var statusServico = await _statusServicoService.GetByIdAsync(id);

            if (statusServico == null)
            {
                return NotFound();
            }

            return Ok(statusServico);
        }

        [HttpPost]
        public async Task<ActionResult<StatusServicoModel>> AddStatusServico(StatusServicoModel statusServico)
        {
            await _statusServicoService.AddAsync(statusServico);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatusServico(ObjectId id, StatusServicoModel statusServico)
        {
            if (id != statusServico.Id)
            {
                return BadRequest();
            }

            await _statusServicoService.UpdateAsync(id, statusServico);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusServico(ObjectId id)
        {
            await _statusServicoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
