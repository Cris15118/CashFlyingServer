using CashFlyingServer.Models;

namespace CashFlyingServer.Services.UsuarioServices
{

    public interface IUsuarioServices
    {
        //POST
        Task<Usuario> RegistrarUsuario(Usuario nuevoUsuario);
        public Task<bool> CheckUserAndPass(string email, string password);
        Task<CambiarPassword> CambiarPassword(int id, string password, string newPassword);
    }
}

