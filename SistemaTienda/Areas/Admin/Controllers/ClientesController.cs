using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Models;

namespace SistemaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ClientesController(IContenedorTrabajo contenedorTrabajo)
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
            var clientes = _contenedorTrabajo.Cliente.GetAll();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Cliente.Add(cliente);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var clienteFromDb = _contenedorTrabajo.Cliente.Get(id);
            if (clienteFromDb == null)
            {
                return NotFound();
            }
            return View(clienteFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDesdeDb = _contenedorTrabajo.Cliente.Get(cliente.Id);
                if (clienteDesdeDb == null)
                    return NotFound();

                clienteDesdeDb.Nombre = cliente.Nombre;
                clienteDesdeDb.Apellido = cliente.Apellido;
                clienteDesdeDb.DUI = cliente.DUI;
                clienteDesdeDb.Correo = cliente.Correo;
                clienteDesdeDb.Telefono = cliente.Telefono;
                clienteDesdeDb.Estado = cliente.Estado;

                _contenedorTrabajo.Cliente.Update(clienteDesdeDb);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var clienteFromDb = _contenedorTrabajo.Cliente.Get(id);
            if (clienteFromDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar el cliente" });
            }

            _contenedorTrabajo.Cliente.Remove(clienteFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Cliente eliminado correctamente" });
        }
    }
}