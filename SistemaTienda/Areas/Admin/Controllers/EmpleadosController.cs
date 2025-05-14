using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Models;


namespace SistemaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmpleadoController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public EmpleadoController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var empleados = _contenedorTrabajo.Empleado.GetAll();
            return Json(new { data = empleados });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Empleado.Add(empleado);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var empleadoFromDb = _contenedorTrabajo.Empleado.Get(id);
            if (empleadoFromDb == null)
            {
                return NotFound();
            }
            return View(empleadoFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var empleadoDesdeDb = _contenedorTrabajo.Empleado.Get(empleado.Id);
                if (empleadoDesdeDb == null)
                    return NotFound();

                empleadoDesdeDb.Nombre = empleado.Nombre;
                empleadoDesdeDb.Apellido = empleado.Apellido;
                empleadoDesdeDb.Correo = empleado.Correo;
                empleadoDesdeDb.Telefono = empleado.Telefono;
                empleadoDesdeDb.Rol = empleado.Rol;
                empleadoDesdeDb.Estado = empleado.Estado;

                _contenedorTrabajo.Empleado.Update(empleadoDesdeDb);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var empleadoFromDb = _contenedorTrabajo.Empleado.Get(id);
            if (empleadoFromDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar el empleado" });
            }
            _contenedorTrabajo.Empleado.Remove(empleadoFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Empleado eliminado correctamente" });
        }
    }
}
