using CashFlyingServer.Data;
using CashFlyingServer.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlyingServer.Services.GastoServices
{
    public class GastoServices : IGastoServices
    {
       
        private readonly DataContext context;

        public GastoServices(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Gasto>> AgregarGasto(Gasto nuevoGasto)
        {
            context.Gastos.Add(nuevoGasto);
            await context.SaveChangesAsync();
            return await ListadoGastos();
        }
        public async Task<List<Gasto>> ListadoGastos()
        {
            var dbGastos = await context.Gastos.ToListAsync();
            return dbGastos;
        }
        public async Task<Gasto> VerGasto(int id)
        {
            var dbGastos = await context.Gastos.FindAsync(id);
            if (dbGastos == null)
            {
                throw new Exception("El gasto seleccionado no existe");
            }
            return dbGastos;
        }
        public async Task<List<Gasto>> ActualizarGasto(int id, Gasto actualizarGasto)
        {
            var dbGastos = await context.Gastos.FindAsync(id);
            if (dbGastos == null)
            {
                throw new Exception("El gasto que quieres actualizar no existe");
            }
            context.Entry(dbGastos).CurrentValues.SetValues(actualizarGasto);
            await context.SaveChangesAsync();
            return await ListadoGastos();
        }

        public async Task<List<Gasto>> EliminarGasto(int id)
        {
            var dbGastos = await context.Gastos.FindAsync(id);
            if (dbGastos == null)
            {
                throw new Exception("El gasto no existe");
            }
            context.Gastos.Remove(dbGastos);
            await context.SaveChangesAsync();
            return await ListadoGastos();
        }
    }
}
