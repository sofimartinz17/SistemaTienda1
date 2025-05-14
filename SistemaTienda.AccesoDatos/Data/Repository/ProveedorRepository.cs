using Microsoft.EntityFrameworkCore;
using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Data;
using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using System.Collections.Generic;
using System.Linq;

namespace SistemaTienda.AccesoDatos.Data.Repository
{
    public class ProveedorRepository : Repository<Proveedores>, IProveedorRepository
    {
        private readonly ApplicationDbContext _db;

        public ProveedorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Proveedores> GetAllProveedores()
        {
            return _db.Proveedores.ToList();
        }

        public void Update(Proveedores proveedor)
        {
            var proveedorDesdeDb = _db.Proveedores.FirstOrDefault(p => p.Id == proveedor.Id);
            if (proveedorDesdeDb != null)
            {
               
                proveedorDesdeDb.Nombre = proveedor.Nombre;
                proveedorDesdeDb.Apellido = proveedor.Apellido;
                proveedorDesdeDb.Correo = proveedor.Correo;
                proveedorDesdeDb.Compania = proveedor.Compania;
                proveedorDesdeDb.Estado = proveedor.Estado;

                _db.SaveChanges();
            }
        }
    }
}
