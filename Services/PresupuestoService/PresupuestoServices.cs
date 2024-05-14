using CashFlyingServer.Data;
using CashFlyingServer.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlyingServer.Services.PresupuestoService
{
    public class PresupuestoServices : IPresupuestoService
    {
        private readonly DataContext context;

        public PresupuestoServices(DataContext context)
        {
            this.context = context;
        }
        public async Task<List<Presupuesto>> AgregarPresupuesto(Presupuesto nuevoPresupuesto)

        {
            context.Presupuestos.Add(nuevoPresupuesto);
            await context.SaveChangesAsync();
            return await ObtenerSaldo();
        }

        public async Task<List<Presupuesto>> ObtenerSaldo()
        {
            var dbSaldo = await context.Presupuestos.ToListAsync();
            return dbSaldo;
        }
       
    }
}
