using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;

        public ChamadoController(IChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChamadoModel>> GetChamadoById(int id)
        {
            var chamado = await _chamadoService.GetChamadoByIdAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }
            return Ok(chamado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoModel>>> GetAllChamados()
        {
            var chamados = await _chamadoService.GetAllChamadosAsync();
            return Ok(chamados);
        }

        [HttpPost]
        public async Task<ActionResult> AddChamado(ChamadoModel chamado)
        {
            await _chamadoService.AddChamadoAsync(chamado);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChamado(int id, ChamadoModel chamado)
        {
            if (id != chamado.Id)
            {
                return BadRequest();
            }
            await _chamadoService.UpdateChamadoAsync(chamado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChamado(int id)
        {
            await _chamadoService.DeleteChamadoAsync(id);
            return NoContent();
        }
    }
}
