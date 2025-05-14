using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.AccesoDatos.Data.Repository.iRepository
{
    public  interface IProductoRepository: iRepository<Producto>
    {
        IEnumerable<Producto> GetALL(string includeProperties);

        void Update(Producto producto);

    }
}
