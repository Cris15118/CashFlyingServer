using CashFlyingServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CashFlyingServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(u =>
            {
                u.HasKey(col => col.Id);
                u.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            modelBuilder.Entity<PerfilUsuario>(p =>
            {
                p.HasKey(col => col.Id);
                p.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            });

        }
    }
}
