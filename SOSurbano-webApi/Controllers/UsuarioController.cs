﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SosUrbano.Application.DTOs;
using SosUrbano.Domain.Enums;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioByIdAsync(ObjectId id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration([FromBody] RequestUserRegistrationDto usuario)
        {
            if (usuario == null)
            {
                return BadRequest("User cannot be null.");
            }

            var novoUsuario = new UsuarioModel
            {
                Id = ObjectId.GenerateNewId(),
                Nome = usuario.Nome,
                Email = usuario.Email,
                CPF = usuario.CPF,
                DataNascimento = usuario.DataNascimento,
                Senha = usuario.Senha,
                CellPhone = usuario.CellPhone,
                RoleId = (RoleEnum)usuario.RoleId,
                Ativo = usuario.Ativo,
                Genero = usuario.Genero
            };

            await _usuarioService.AddAsync(novoUsuario);
            return Ok(usuario);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuarioAsync(ObjectId id, [FromBody] UsuarioModel usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Invalid data.");
            }

            await _usuarioService.UpdateAsync(id, usuario);
            return NoContent();
        }
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioAsync(ObjectId id)
        {
            await _usuarioService.DeleteAsync(id);
            return NoContent();
        }
    }
}
