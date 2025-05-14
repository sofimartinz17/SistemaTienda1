using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Data;
using SistemaTienda.Models;

namespace SistemaTienda.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
            Producto = new ProductoRepository(_db);
            Cliente = new ClienteRepository(_db);
            Proveedor = new ProveedorRepository(_db);
            Empleado = new EmpleadoRepository(_db);
            Pago = new PagoRepository(_db);
            Venta = new VentaRepository(_db);

        }

        public ICategoriaRepository Categoria { get; private set; }

        public IProductoRepository Producto { get; private set; }

        public IClienteRepository Cliente { get; private set; }

        public IProveedorRepository Proveedor { get; private set; }

        public IEmpleadoRepository Empleado { get; private set; }

        public IPagoRepository Pago { get; private set; }

        public IVentaRepository Venta { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges(); 
        }
    }
}
