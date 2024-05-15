using CashFlyingServer.Data;
using CashFlyingServer.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlyingServer.Services.UsuarioServices
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly DataContext context;
        public UsuarioServices(DataContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> RegistrarUsuario(Usuario nuevoUsuario)
        {
            //Generar un hash de la contraseña

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(nuevoUsuario.Password);
            nuevoUsuario.Password = hashedPassword;

            await context.Usuarios.AddAsync(nuevoUsuario);
            await context.SaveChangesAsync();
            return nuevoUsuario;
        }
        public async Task<bool> CheckUserAndPass(string email, string password)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (usuario == null)
            {
                return false; // el usuario no existe
            }
            //Verificar la contraseña con Bcrypt
            return BCrypt.Net.BCrypt.Verify(password, usuario.Password);
        }
        public async Task<CambiarPassword> CambiarPassword(int id, string password, string newPassword)
        {
            var usuario = await context.Usuarios.FindAsync(id);
            //verificar si el usuario existe
            if(usuario == null)
            {
                throw new Exception("El Usuario no existe");
            }
            // verificar que la contraseña anterior coincida
            bool passwordCorreto = BCrypt.Net.BCrypt.Verify(password, usuario.Password);
            if(!passwordCorreto)
            {
                throw new Exception("La Contraseña Anterior no es Correcta");
            }
            string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            //Actualizar la contraseña en la base de datos
            usuario.Password = hashedNewPassword;
            await context.SaveChangesAsync();
            return new CambiarPassword(id, "", password);
             
        }
    }
}
