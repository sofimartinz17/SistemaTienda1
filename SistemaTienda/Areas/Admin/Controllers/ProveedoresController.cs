using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Models;

namespace SistemaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProveedoresController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProveedoresController(IContenedorTrabajo contenedorTrabajo)
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
            var proveedores = _contenedorTrabajo.Proveedor.GetAll();
            return Json(new { data = proveedores });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proveedores proveedor)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Proveedor.Add(proveedor);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var proveedorFromDb = _contenedorTrabajo.Proveedor.Get(id);
            if (proveedorFromDb == null)
            {
                return NotFound();
            }
            return View(proveedorFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Proveedores proveedor)
        {
            if (ModelState.IsValid)
            {
                var proveedorDesdeDb = _contenedorTrabajo.Proveedor.Get(proveedor.Id);
                if (proveedorDesdeDb == null)
                    return NotFound();

                proveedorDesdeDb.Nombre = proveedor.Nombre;
                proveedorDesdeDb.Apellido = proveedor.Apellido;
                proveedorDesdeDb.Correo = proveedor.Correo;
                proveedorDesdeDb.Compania = proveedor.Compania;
                proveedorDesdeDb.Estado = proveedor.Estado;

                _contenedorTrabajo.Proveedor.Update(proveedorDesdeDb);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var proveedorFromDb = _contenedorTrabajo.Proveedor.Get(id);
            if (proveedorFromDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar el proveedor" });
            }
            _contenedorTrabajo.Proveedor.Remove(proveedorFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Proveedor eliminado correctamente" });
        }
    }
}

