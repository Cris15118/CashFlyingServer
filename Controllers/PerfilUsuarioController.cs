using CashFlyingServer.Models;
using CashFlyingServer.Services.PerfilServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlyingServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilUsuarioController : ControllerBase
    {
        private readonly IPerfilUsuarioServices perfilUsuarioServices;
        public PerfilUsuarioController(IPerfilUsuarioServices perfilUsuarioServices)
        {
            this.perfilUsuarioServices = perfilUsuarioServices;
        }
        [HttpGet("VerPerfil/{id}")]
        public async Task<ActionResult<PerfilUsuario>> VerPerfil(int id)
        {
            return Ok(await perfilUsuarioServices.VerPerfil(id));
        }

        [HttpPost("CrearPerfil")]
        public async Task<ActionResult<PerfilUsuario>> CrearPerfil(PerfilUsuario nuevoUsuario)
        {
            return Ok(await perfilUsuarioServices.CrearPerfil(nuevoUsuario));
        }

        [HttpPut("ActualizarPerfil/{id}")]
        public async Task<ActionResult<PerfilUsuario>> ActualizarPerfil(int id, PerfilUsuario actulizarPerfil)
        {
            return Ok(await perfilUsuarioServices.ActualizarPerfil(id, actulizarPerfil));
        }
        [HttpDelete("EliminarPerfil/{id}")]
        public async Task<ActionResult<PerfilUsuario>> EliminarPerfil(int id)
        {
            return Ok(await perfilUsuarioServices.EliminarPerfil(id));
        }
    }
}
