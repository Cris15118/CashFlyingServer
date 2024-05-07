using CashFlyingServer.Models;

namespace CashFlyingServer.Services.PresupuestoService
{
    public interface IPresupuestoService
    {
        //GET
        Task<List<Presupuesto>> ObtenerSaldo();

        // POST
        Task<List<Presupuesto>> AñadirPresupuesto(Presupuesto nuevoPresupuesto);

        //DELETE
        Task<List<Presupuesto>> ResetearSaldo(int id);
    }
}
