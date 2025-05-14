using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Models;

namespace SistemaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public PagosController(IContenedorTrabajo contenedorTrabajo)
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
            var pagos = _contenedorTrabajo.Pago.GetAll();
            return Json(new { data = pagos });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pagos pago)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Pago.Add(pago);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(pago);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pagoDesdeDb = _contenedorTrabajo.Pago.Get(id);
            if (pagoDesdeDb == null)
            {
                return NotFound();
            }
            return View(pagoDesdeDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pagos pago)
        {
            if (ModelState.IsValid)
            {
                var pagoDesdeDb = _contenedorTrabajo.Pago.Get(pago.Id);
                if (pagoDesdeDb == null)
                    return NotFound();

               
                pagoDesdeDb.FechaPago = pago.FechaPago;
                pagoDesdeDb.Monto = pago.Monto;
                pagoDesdeDb.MetodoPago = pago.MetodoPago;
                pagoDesdeDb.EstadoPago = pago.EstadoPago;

                _contenedorTrabajo.Pago.Update(pagoDesdeDb);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(pago);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pagoDesdeDb = _contenedorTrabajo.Pago.Get(id);
            if (pagoDesdeDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar el pago" });
            }
            _contenedorTrabajo.Pago.Remove(pagoDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Pago eliminado correctamente" });
        }
    }
}