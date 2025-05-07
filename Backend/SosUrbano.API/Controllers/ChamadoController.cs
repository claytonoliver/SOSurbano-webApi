using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SosUrbano.Application.DTOs;
using SosUrbano.Application.Services.Interfaces;
using SosUrbano.Domain.Entities;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;

        public ChamadoController(IChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChamadoModel>> GetChamadoById(ObjectId id)
        {
            var chamado = await _chamadoService.GetByIdAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }
            return Ok(chamado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChamadoModel>>> GetAllChamados()
        {
            var chamados = await _chamadoService.GetAllAsync();
            return Ok(chamados);
        }

        [HttpPost]
        public async Task<ActionResult> AddChamado(RequestNovoChamadoDTO chamado)
        {
            var novoChamado = new ChamadoModel
            {
                Id = ObjectId.GenerateNewId(),
                UsuarioId = chamado.UsuarioId,
                StatusChamado = chamado.StatusChamado,
                DataChamado = chamado.DataChamado,
                Descricao = chamado.Descricao,
                Latitude = chamado.Latitude,
                Longitude = chamado.Longitude,
                Status = chamado.Status
            };

            await _chamadoService.AddAsync(novoChamado);
            return Created("Chamado Criado", new {Id = novoChamado.Id.ToString()});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChamado(ObjectId id, ChamadoModel chamado)
        {
            if (id != chamado.Id)
            {
                return BadRequest();
            }
            await _chamadoService.UpdateAsync(id, chamado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteChamado(ObjectId id)
        {
            await _chamadoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
