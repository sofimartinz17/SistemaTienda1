using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.AccesoDatos.Data.Repository.iRepository
{
    public  interface ICategoriaRepository: iRepository<Categoria>
    {
        void Update(Categoria categoria);
        IEnumerable<SelectListItem> GetListaCategorias();
    }
}
