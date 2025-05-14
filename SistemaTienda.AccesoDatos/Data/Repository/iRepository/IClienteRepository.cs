using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace SistemaTienda.AccesoDatos.Data.Repository.iRepository
{
    public interface IClienteRepository : iRepository<Clientes>
    {
        IEnumerable<Clientes> GetAllClientes();
        void Update(Clientes cliente);
    }
}


