using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoModel>>> GetVeiculos()
        {
            var veiculos = await _veiculoService.GetAllVeiculosAsync();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoModel>> GetVeiculoById(int id)
        {
            var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoModel>> AddVeiculo(VeiculoModel veiculo)
        {
            await _veiculoService.AddVeiculoAsync(veiculo);
            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVeiculo(int id, VeiculoModel veiculo)
        {
            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            await _veiculoService.UpdateVeiculoAsync(veiculo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            await _veiculoService.DeleteVeiculoAsync(id);
            return NoContent();
        }
    }
}
