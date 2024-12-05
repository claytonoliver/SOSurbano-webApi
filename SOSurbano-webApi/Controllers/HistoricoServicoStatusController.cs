using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoServicoStatusController : ControllerBase
    {
        private readonly IHistoricoServicoStatusService _historicoServicoStatusService;

        public HistoricoServicoStatusController(IHistoricoServicoStatusService historicoServicoStatusService)
        {
            _historicoServicoStatusService = historicoServicoStatusService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoServicoStatusModel>> GetHistoricoServicoStatus(int id)
        {
            var historicoServicoStatus = await _historicoServicoStatusService.GetHistoricoServicoStatusByIdAsync(id);

            if (historicoServicoStatus == null)
            {
                return NotFound();
            }

            return Ok(historicoServicoStatus);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoServicoStatusModel>>> GetAllHistoricoServicoStatus()
        {
            var historicoServicoStatuses = await _historicoServicoStatusService.GetAllHistoricoServicoStatusAsync();
            return Ok(historicoServicoStatuses);
        }

        [HttpPost]
        public async Task<ActionResult<HistoricoServicoStatusModel>> PostHistoricoServicoStatus(HistoricoServicoStatusModel historicoServicoStatus)
        {
            await _historicoServicoStatusService.AddHistoricoServicoStatusAsync(historicoServicoStatus);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricoServicoStatus(int id, HistoricoServicoStatusModel historicoServicoStatus)
        {
            if (id != historicoServicoStatus.Id)
            {
                return BadRequest();
            }

            await _historicoServicoStatusService.UpdateHistoricoServicoStatusAsync(historicoServicoStatus);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricoServicoStatus(int id)
        {
            var historicoServicoStatus = await _historicoServicoStatusService.GetHistoricoServicoStatusByIdAsync(id);
            if (historicoServicoStatus == null)
            {
                return NotFound();
            }

            await _historicoServicoStatusService.DeleteHistoricoServicoStatusAsync(id);
            return NoContent();
        }
    }
}
