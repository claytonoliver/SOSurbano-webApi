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
            var veiculos = await _veiculoService.GetAllAsync();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoModel>> GetVeiculoById(ObjectId id)
        {
            var veiculo = await _veiculoService.GetByIdAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoModel>> AddVeiculo(VeiculoModel veiculo)
        {
            await _veiculoService.AddAsync(veiculo);
            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVeiculo(ObjectId id, VeiculoModel veiculo)
        {
            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            await _veiculoService.UpdateAsync(id, veiculo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(ObjectId id)
        {
            await _veiculoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
