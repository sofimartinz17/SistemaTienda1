using Microsoft.EntityFrameworkCore;
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
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Producto> GetALL(string includeProperties)
        {
            IQueryable<Producto> query = _db.Producto;

            foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }

            return query.ToList();
        }

        public void Update(Producto producto)
        {
            var objDesdeDB = _db.Producto.FirstOrDefault(s => s.Id == producto.Id);
            if (objDesdeDB != null)
            {
                objDesdeDB.Nombre = producto.Nombre;
                objDesdeDB.Descripcion = producto.Descripcion;
                objDesdeDB.UrlImagen = producto.UrlImagen;
                objDesdeDB.CategoriaId = producto.CategoriaId;

                objDesdeDB.NumeroPlaca = producto.NumeroPlaca;
                objDesdeDB.Precio = producto.Precio;
                objDesdeDB.Modelo = producto.Modelo;
                objDesdeDB.Año = producto.Año;
                objDesdeDB.ColorDisponible = producto.ColorDisponible;

                _db.SaveChanges();
            }
        }
    }
}
