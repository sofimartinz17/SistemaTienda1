using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaTienda.Models;

namespace SistemaTienda.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

       
        public DbSet<Categoria> Categoria { get; set; }  
       
        public DbSet<Producto> Producto { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Pagos> Pagos { get; set; }

        public DbSet<Venta> Venta { get; set; }




    }
}
