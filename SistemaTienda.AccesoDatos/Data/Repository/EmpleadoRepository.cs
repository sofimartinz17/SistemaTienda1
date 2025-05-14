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
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        private readonly ApplicationDbContext _db;

        public EmpleadoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Empleado> GetAllEmpleado()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleado> GetAllEmpleados()
        {
            return _db.Empleado.ToList();
        }

        public void Update(Empleado empleado)
        {
            var empleadoDesdeDb = _db.Empleado.FirstOrDefault(e => e.Id == empleado.Id);
            if (empleadoDesdeDb != null)
            {
                empleadoDesdeDb.Nombre = empleado.Nombre;
                empleadoDesdeDb.Apellido = empleado.Apellido;
                empleadoDesdeDb.Correo = empleado.Correo;
                empleadoDesdeDb.Telefono = empleado.Telefono;
                empleadoDesdeDb.Rol = empleado.Rol;
                empleadoDesdeDb.Estado = empleado.Estado;

                _db.SaveChanges();
            }
        }
    }
}
