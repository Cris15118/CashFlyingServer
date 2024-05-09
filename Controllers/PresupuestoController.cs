using CashFlyingServer.Models;
using CashFlyingServer.Services.PresupuestoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlyingServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {
        private readonly IPresupuestoService presupuestoService;

        public PresupuestoController(IPresupuestoService presupuestoService)
        {
            this.presupuestoService = presupuestoService;
        }

        [HttpGet("ObtenerSaldo")]
        public async Task<ActionResult<List<Presupuesto>>> ObtenerSaldo()
        {
            return Ok(await presupuestoService.ObtenerSaldo());
        }
        [HttpPost("AñadirPresupuesto")]
        public async Task<ActionResult<List<Presupuesto>>> AgregarPresupuesto(Presupuesto nuevoPresupuesto)
        {
            return Ok(await presupuestoService.AgregarPresupuesto(nuevoPresupuesto));
        }
        [HttpDelete("ResetearSaldo")]
        public async Task<ActionResult<List<Presupuesto>>> ResetearSaldo(int id)
        {
            return Ok(await presupuestoService.ResetearSaldo(id));
        }
    }
}
