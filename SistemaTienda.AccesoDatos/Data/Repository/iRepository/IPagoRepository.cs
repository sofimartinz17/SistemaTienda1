using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTienda.AccesoDatos.Data.Repository.iRepository
{
    public interface IPagoRepository : iRepository<Pagos>
    {
        Pagos Get(object id);
        IEnumerable<Pagos> GetAllPagos();  
        void Update(Pagos pago);         
    }
}