using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.AccesoDatos.Data.Repository.iRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        
        ICategoriaRepository Categoria { get; }
        IProductoRepository Producto { get; }

        IClienteRepository Cliente { get; }

        IProveedorRepository Proveedor { get; }

        IEmpleadoRepository Empleado { get; }

        IPagoRepository Pago { get; }

        IVentaRepository Venta { get; }

        void Save();
    }
}