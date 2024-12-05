using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoOcorrenciaController : ControllerBase
    {
        private readonly IHistoricoOcorrenciaService _historicoOcorrenciaService;

        public HistoricoOcorrenciaController(IHistoricoOcorrenciaService historicoOcorrenciaService)
        {
            _historicoOcorrenciaService = historicoOcorrenciaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoOcorrenciaModel>> GetHistoricoOcorrencia(int id)
        {
            var historicoOcorrencia = await _historicoOcorrenciaService.GetHistoricoOcorrenciaByIdAsync(id);

            if (historicoOcorrencia == null)
            {
                return NotFound();
            }

            return Ok(historicoOcorrencia);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoOcorrenciaModel>>> GetAllHistoricoOcorrencias()
        {
            var historicoOcorrencias = await _historicoOcorrenciaService.GetAllHistoricoOcorrenciasAsync();
            return Ok(historicoOcorrencias);
        }

        [HttpPost]
        public async Task<ActionResult<HistoricoOcorrenciaModel>> PostHistoricoOcorrencia(HistoricoOcorrenciaModel historicoOcorrencia)
        {
            await _historicoOcorrenciaService.AddHistoricoOcorrenciaAsync(historicoOcorrencia);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricoOcorrencia(int id, HistoricoOcorrenciaModel historicoOcorrencia)
        {
            if (id != historicoOcorrencia.IdOcorrencia)
            {
                return BadRequest();
            }

            await _historicoOcorrenciaService.UpdateHistoricoOcorrenciaAsync(historicoOcorrencia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricoOcorrencia(int id)
        {
            var historicoOcorrencia = await _historicoOcorrenciaService.GetHistoricoOcorrenciaByIdAsync(id);
            if (historicoOcorrencia == null)
            {
                return NotFound();
            }

            await _historicoOcorrenciaService.DeleteHistoricoOcorrenciaAsync(id);
            return NoContent();
        }
    }
}
