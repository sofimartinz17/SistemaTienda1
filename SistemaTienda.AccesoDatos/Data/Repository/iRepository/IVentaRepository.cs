using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.AccesoDatos.Data.Repository.iRepository
{
    public interface IVentaRepository : iRepository<Venta>
    {
        void Add(Venta venta);
        IEnumerable<Venta> GetAllVenta();
        string? GetVentaByDetails(DateTime fechaPago, string metodoPago);
        void Remove(string ventaFromDb);
        void Update(Venta venta);
        void Update(string ventaDesdeDb);
    }
}

