using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;

namespace SOSurbano_webApi.Controllers
{
    [Authorize(Roles = "1")]
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
            var tiposDeOcorrencia = await _tipoDeOcorrenciaService.GetAllAsync();
            return Ok(tiposDeOcorrencia);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeOcorrenciaModel>> GetTipoDeOcorrenciaById(ObjectId id)
        {
            var tipoDeOcorrencia = await _tipoDeOcorrenciaService.GetByIdAsync(id);

            if (tipoDeOcorrencia == null)
            {
                return NotFound();
            }

            return Ok(tipoDeOcorrencia);
        }

        [HttpPost]
        public async Task<ActionResult<TipoDeOcorrenciaModel>> AddTipoDeOcorrencia(TipoDeOcorrenciaModel tipoDeOcorrencia)
        {
            await _tipoDeOcorrenciaService.AddAsync(tipoDeOcorrencia);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoDeOcorrencia(ObjectId id, TipoDeOcorrenciaModel tipoDeOcorrencia)
        {
            if (id != tipoDeOcorrencia.Id)
            {
                return BadRequest();
            }

            await _tipoDeOcorrenciaService.UpdateAsync(id, tipoDeOcorrencia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeOcorrencia(ObjectId id)
        {
            await _tipoDeOcorrenciaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
