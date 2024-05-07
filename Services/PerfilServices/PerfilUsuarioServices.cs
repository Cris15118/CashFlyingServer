using CashFlyingServer.Data;
using CashFlyingServer.Models;

namespace CashFlyingServer.Services.PerfilServices
{
    public class PerfilUsuarioServices : IPerfilUsuarioServices
    {
        private readonly DataContext context;
        public PerfilUsuarioServices(DataContext context)
        {
            this.context = context;
        }
        public async Task<PerfilUsuario> ActualizarPerfil(int id, PerfilUsuario actulizarPerfil)
        {
            var dbPerfilUsuario = await context.PerfilUsuarios.FindAsync(id);
            if (dbPerfilUsuario == null)
            {
                throw new Exception("El perfil de Usuario no Existe");
            }
            context.Entry(dbPerfilUsuario).CurrentValues.SetValues(actulizarPerfil);
            await context.SaveChangesAsync();
            return await VerPerfil(id);
        }
        public async Task<PerfilUsuario> CrearPerfil(PerfilUsuario nuevoUsuario)
        {
            context.PerfilUsuarios.Add(nuevoUsuario);
            await context.SaveChangesAsync();
            return nuevoUsuario;
        }

        public async Task<PerfilUsuario> EliminarPerfil(int id)
        {
            var dbPerfilUsuario = await context.PerfilUsuarios.FindAsync(id);
            if (dbPerfilUsuario == null)
            {
                throw new Exception("El Perfil de Usuario no Existe");
            }
            context.PerfilUsuarios.Remove(dbPerfilUsuario);
            await context.SaveChangesAsync();
            return dbPerfilUsuario;
        }

        public async Task<PerfilUsuario> VerPerfil(int id)
        {
            var dbPerfilUsuario = await context.PerfilUsuarios.FindAsync(id);
            if (dbPerfilUsuario == null)
            {
                throw new Exception("El Usurio no existe");
            }
            return dbPerfilUsuario;
        }
    }
}
