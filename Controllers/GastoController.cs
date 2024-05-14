using CashFlyingServer.Models;
using CashFlyingServer.Services.GastoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlyingServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly IGastoServices gastoServices;

        public GastoController(IGastoServices gastoServices)
        {
            this.gastoServices = gastoServices;
        }

        [HttpGet("listado-gastos")]
        public async Task<ActionResult<List<Gasto>>> ListadoGastos()
        {
            return Ok(await gastoServices.ListadoGastos());
        }
        [HttpGet("VerGasto/{id}")]
        public async Task<ActionResult<Gasto>> VerGasto(int id)
        {
            return Ok(await gastoServices.VerGasto(id));
        }
        [HttpPost("AgregarGasto")]
        public async Task<ActionResult<List<Gasto>>> AgregarGasto(Gasto nuevoGasto)
        {
            return Ok(await gastoServices.AgregarGasto(nuevoGasto));

        }
        [HttpPut("ActualizarGasto/{id}")]
        public async Task<ActionResult<List<Gasto>>> ActualizarGasto(int id, Gasto actualizarGasto)
        {
            return Ok(await gastoServices.ActualizarGasto(id, actualizarGasto));
        }
        [HttpDelete("ElininarGasto/{id}")]
        public async Task<ActionResult<List<Gasto>>> EliminarGasto(int id)
        {
            return Ok(await gastoServices.EliminarGasto(id));
        }
    }
}

