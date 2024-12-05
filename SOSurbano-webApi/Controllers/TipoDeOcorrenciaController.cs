using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeOcorrenciaController : ControllerBase
    {
        private readonly ITipoDeOcorrenciaService _tipoDeOcorrenciaService;

        public TipoDeOcorrenciaController(ITipoDeOcorrenciaService tipoDeOcorrenciaService)
        {
            _tipoDeOcorrenciaService = tipoDeOcorrenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeOcorrenciaModel>>> GetTiposDeOcorrencia()
        {
            var tiposDeOcorrencia = await _tipoDeOcorrenciaService.GetAllTiposDeOcorrenciaAsync();
            return Ok(tiposDeOcorrencia);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeOcorrenciaModel>> GetTipoDeOcorrenciaById(int id)
        {
            var tipoDeOcorrencia = await _tipoDeOcorrenciaService.GetTipoDeOcorrenciaByIdAsync(id);

            if (tipoDeOcorrencia == null)
            {
                return NotFound();
            }

            return Ok(tipoDeOcorrencia);
        }

        [HttpPost]
        public async Task<ActionResult<TipoDeOcorrenciaModel>> AddTipoDeOcorrencia(TipoDeOcorrenciaModel tipoDeOcorrencia)
        {
            await _tipoDeOcorrenciaService.AddTipoDeOcorrenciaAsync(tipoDeOcorrencia);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoDeOcorrencia(int id, TipoDeOcorrenciaModel tipoDeOcorrencia)
        {
            if (id != tipoDeOcorrencia.Id)
            {
                return BadRequest();
            }

            await _tipoDeOcorrenciaService.UpdateTipoDeOcorrenciaAsync(tipoDeOcorrencia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeOcorrencia(int id)
        {
            await _tipoDeOcorrenciaService.DeleteTipoDeOcorrenciaAsync(id);
            return NoContent();
        }
    }
}
