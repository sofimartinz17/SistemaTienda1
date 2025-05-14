using SistemaTienda.AccesoDatos.Data.Repository;
using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Data;
using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaTienda.AccesoDatos.Data.Repository
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
{
    private readonly ApplicationDbContext _db;

    public VentaRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    // Obtener todas las ventas
    public IEnumerable<Venta> GetAll(string includeProperties)
    {
        return _db.Venta.ToList();
    }

    // Obtener una venta por su FechaPago y MetodoPago (puedes ajustar según la combinación de claves que uses)
    public Venta GetVentaByDetails(DateTime fechaPago, string metodoPago)
    {
        return _db.Venta.FirstOrDefault(v => v.FechaPago == fechaPago && v.MetodoPago == metodoPago);
    }

    // Actualizar una venta
    public void Update(Venta venta)
    {
        var objDesdeDB = _db.Venta.FirstOrDefault(v => v.Id == venta.Id);
            if (objDesdeDB != null)
            {
                // Actualizar los campos
                objDesdeDB.Namecliente = venta.Namecliente;
                objDesdeDB.DUI = venta.DUI;
                objDesdeDB.Namecarro = venta.Namecarro;
                objDesdeDB.FechaPago = venta.FechaPago;
                objDesdeDB.Monto = venta.Monto;
                objDesdeDB.MetodoPago = venta.MetodoPago;
                objDesdeDB.EstadoPago = venta.EstadoPago;

                // Guardar los cambios
                _db.SaveChanges();
            }
    }

    // Eliminar una venta
    public void Delete(DateTime fechaPago, string metodoPago)
    {
        var venta = GetVentaByDetails(fechaPago, metodoPago);
        if (venta != null)
        {
            _db.Venta.Remove(venta);
            _db.SaveChanges();
        }
    }

    // Agregar una nueva venta
    public void Add(Venta venta)
    {
        _db.Venta.Add(venta);
        _db.SaveChanges();
    }

        public IEnumerable<Venta> GetAllVenta()
        {
            throw new NotImplementedException();
        }

        string? IVentaRepository.GetVentaByDetails(DateTime fechaPago, string metodoPago)
        {
            throw new NotImplementedException();
        }

        public void Remove(string ventaFromDb)
        {
            throw new NotImplementedException();
        }

        public void Update(string ventaDesdeDb)
        {
            throw new NotImplementedException();
        }
    }
}
