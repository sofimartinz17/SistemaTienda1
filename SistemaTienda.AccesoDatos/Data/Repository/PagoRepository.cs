using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Data;
using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.AccesoDatos.Data.Repository
{
    public class PagoRepository : Repository<Pagos>, IPagoRepository
    {
        private readonly ApplicationDbContext _db;

        public PagoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Pagos Get(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pagos> GetAllPagos()
        {
            return _db.Pagos.ToList();
        }

        public void Update(Pagos pago)
        {
            var pagoDesdeDb = _db.Pagos.FirstOrDefault(p => p.Id == pago.Id);
            if (pagoDesdeDb != null)
            {
                pagoDesdeDb.VentaId = pago.VentaId;
                pagoDesdeDb.FechaPago = pago.FechaPago;
                pagoDesdeDb.Monto = pago.Monto;
                pagoDesdeDb.MetodoPago = pago.MetodoPago;
                pagoDesdeDb.EstadoPago = pago.EstadoPago;

                _db.SaveChanges();
            }
        }
    }
}