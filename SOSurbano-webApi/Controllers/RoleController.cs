using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSurbano_webApi.Model;
using SOSurbano_webApi.Services.Interfaces;

namespace SOSurbano_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync([FromBody] RoleModel role)
        {
            if (role == null)
            {
                return BadRequest("Role cannot be null.");
            }

            await _roleService.AddRoleAsync(role);
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id, [FromBody] RoleModel role)
        {
            if (role == null || role.Id != id)
            {
                return BadRequest("Role ID mismatch.");
            }

            var existingRole = await _roleService.GetRoleByIdAsync(id);
            if (existingRole == null)
            {
                return NotFound();
            }

            await _roleService.UpdateRoleAsync(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAsync(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
