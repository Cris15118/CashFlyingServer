using CashFlyingServer.Models;

namespace CashFlyingServer.Services.PerfilServices
{
    public interface IPerfilUsuarioServices
    {
        // GET
        Task<PerfilUsuario> VerPerfil(int id);

        // POST
        Task<PerfilUsuario> CrearPerfil(PerfilUsuario nuevoUsuario);


        //PUT
        Task<PerfilUsuario> ActualizarPerfil(int id, PerfilUsuario actulizarPerfil);

        //Delete
        Task<PerfilUsuario> EliminarPerfil(int id);

    }
}
