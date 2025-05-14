using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SistemaTienda.AccesoDatos.Data.Repository.iRepository
{
    public interface IEmpleadoRepository : iRepository<Empleado>
    {
        IEnumerable<Empleado> GetAllEmpleado();
        void Update(Empleado empleado);
    }
}
