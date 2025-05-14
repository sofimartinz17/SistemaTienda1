using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepository(ApplicationDbContext db): base(db)
        {
            this._db = db;
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categoria.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(Categoria categoria)
        {
           var objDesdeDb = _db.Categoria.FirstOrDefault(s => s.Id == categoria.Id);
            if (objDesdeDb != null)
            {
                objDesdeDb.Nombre = categoria.Nombre;
                objDesdeDb.Orden = categoria.Orden;
                _db.SaveChanges();
            }


        }
    }
}
