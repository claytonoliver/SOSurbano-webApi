using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;

namespace SOSurbano_webApi.Controllers
{
    [Authorize(Roles = "3")]
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
        public async Task<ActionResult<StatusChamadoModel>> GetStatusChamadoById(ObjectId id)
        {
            var statusChamado = await _statusChamadoService.GetByIdAsync(id);
            if (statusChamado == null)
            {
                return NotFound();
            }
            return Ok(statusChamado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusChamadoModel>>> GetAllStatusChamados()
        {
            var statusChamados = await _statusChamadoService.GetAllAsync();
            return Ok(statusChamados);
        }

        [HttpPost]
        public async Task<ActionResult> AddStatusChamado(StatusChamadoModel statusChamado)
        {
            await _statusChamadoService.AddAsync(statusChamado);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatusChamado(ObjectId id, StatusChamadoModel statusChamado)
        {
            if (id != statusChamado.Id)
            {
                return BadRequest();
            }
            await _statusChamadoService.UpdateAsync(id, statusChamado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusChamado(ObjectId id)
        {
            await _statusChamadoService.DeleteAsync(id);
            return NoContent();
        }
    }
}