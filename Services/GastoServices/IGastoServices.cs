using CashFlyingServer.Models;

namespace CashFlyingServer.Services.GastoServices
{
    public interface IGastoServices
    {
        //GET
        Task<List<Gasto>> ListadoGastos();
        Task<Gasto> VerGasto(int id);

        //POST
        Task<List<Gasto>> AgregarGasto(Gasto nuevoGasto);

        //PUT
        Task<List<Gasto>> ActualizarGasto(int id, Gasto actualizarGasto);

        //DELETE
        Task<List<Gasto>> EliminarGasto(int id);
    }
}
