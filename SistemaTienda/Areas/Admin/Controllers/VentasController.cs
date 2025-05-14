using Microsoft.AspNetCore.Mvc;
using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Data;
using SistemaTienda.Models;

namespace SistemaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VentasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;

        // Constructor que recibe el contenedor de trabajo
        public VentasController(IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context )
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
        }

        // Acción para mostrar la vista principal de ventas
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Acción para obtener todas las ventas
        [HttpGet]
        public IActionResult GetAll()
        {
            var venta = _contenedorTrabajo.Venta.GetAll();
            return Json(new { data = venta });
        }

        // Acción para mostrar la vista de creación de una venta
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Acción para guardar una nueva venta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                // Agregar la venta al repositorio
                _contenedorTrabajo.Venta.Add(venta);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // Acción para mostrar la vista de edición de una venta
        [HttpGet]
        public IActionResult Edit(DateTime fechaPago, string metodoPago)
        {
            // Buscar la venta por los parámetros
            var ventaFromDb = _contenedorTrabajo.Venta.GetVentaByDetails(fechaPago, metodoPago);
            if (ventaFromDb == null)
            {
                return NotFound();
            }
            return View(ventaFromDb);
        }

        // Acción para guardar los cambios de una venta editada
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venta venta)
        {
            if (ModelState.IsValid)
            {
                var ventaDesdeDb = _contenedorTrabajo.Venta.GetVentaByDetails(venta.FechaPago, venta.MetodoPago);
                if (ventaDesdeDb == null)
                    return NotFound();

         

                // Guardar los cambios
                _contenedorTrabajo.Venta.Update(ventaDesdeDb);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // Acción para eliminar una venta
        [HttpDelete]
        public IActionResult Delete(DateTime fechaPago, string metodoPago)
        {
            var ventaFromDb = _contenedorTrabajo.Venta.GetVentaByDetails(fechaPago, metodoPago);
            if (ventaFromDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar la venta" });
            }

            // Eliminar la venta
            _contenedorTrabajo.Venta.Remove(ventaFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Venta eliminada correctamente" });
        }
    }
}

