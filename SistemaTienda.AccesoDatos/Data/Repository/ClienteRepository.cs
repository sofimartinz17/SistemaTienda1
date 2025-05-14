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
    public class ClienteRepository : Repository<Clientes>, IClienteRepository
    {
        private readonly ApplicationDbContext _db;

        public ClienteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Clientes> GetAllClientes()
        {
            return _db.Clientes.ToList();
        }

        public void Update(Clientes cliente)
        {
            var clienteDesdeDb = _db.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (clienteDesdeDb != null)
            {
                clienteDesdeDb.Nombre = cliente.Nombre;
                clienteDesdeDb.Apellido = cliente.Apellido;
                clienteDesdeDb.DUI = cliente.DUI;
                clienteDesdeDb.Correo = cliente.Correo;
                clienteDesdeDb.Telefono = cliente.Telefono;
                clienteDesdeDb.Estado = cliente.Estado;

                _db.SaveChanges();
            }
        }
    }
}
