using Microsoft.AspNetCore.Mvc;
using SistemaTienda.AccesoDatos.Data.Repository.iRepository;
using SistemaTienda.Data;
using SistemaTienda.Models;
using SistemaTienda.Models.ViewModels;

namespace SistemaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductosController(IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var productos = _contenedorTrabajo.Producto.GetALL("Categoria");
            return Json(new { data = productos });
        }


        [HttpGet]
        public IActionResult Create()
        {
            ProductoVM produVM = new ProductoVM
            {
                Producto = new Producto(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };

            return View(produVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductoVM produVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (archivos.Count > 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var carpeta = Path.Combine(rutaPrincipal, "imagenes", "productos");

                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

                    using (var stream = new FileStream(Path.Combine(carpeta, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(stream);
                    }

                    produVM.Producto.UrlImagen = "/imagenes/productos/" + nombreArchivo + extension;
                }

                produVM.Producto.FechaCreacion = DateTime.Now;

               

                _contenedorTrabajo.Producto.Add(produVM.Producto);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            produVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            return View(produVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductoVM produVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var productoDesdeBd = _contenedorTrabajo.Producto.Get(produVM.Producto.Id);
                if (productoDesdeBd == null)
                {
                    return NotFound();
                }

                if (archivos.Count > 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var carpeta = Path.Combine(rutaPrincipal, "imagenes", "productos");

                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

              
                    if (!string.IsNullOrEmpty(productoDesdeBd.UrlImagen))
                    {
                        var rutaimagen = Path.Combine(rutaPrincipal, productoDesdeBd.UrlImagen.TrimStart('/', '\\'));
                        if (System.IO.File.Exists(rutaimagen))
                        {
                            System.IO.File.Delete(rutaimagen);
                        }
                    }

                    using (var stream = new FileStream(Path.Combine(carpeta, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(stream);
                    }

                    produVM.Producto.UrlImagen = "/imagenes/productos/" + nombreArchivo + extension;
                }
                else
                {
                    produVM.Producto.UrlImagen = productoDesdeBd.UrlImagen;
                }

             
                productoDesdeBd.Nombre = produVM.Producto.Nombre;
                productoDesdeBd.Descripcion = produVM.Producto.Descripcion;
                productoDesdeBd.CategoriaId = produVM.Producto.CategoriaId;
                productoDesdeBd.UrlImagen = produVM.Producto.UrlImagen;

                
                productoDesdeBd.NumeroPlaca = produVM.Producto.NumeroPlaca;
                productoDesdeBd.Precio = produVM.Producto.Precio;
                productoDesdeBd.Modelo = produVM.Producto.Modelo;
                productoDesdeBd.Año = produVM.Producto.Año;
                productoDesdeBd.ColorDisponible = produVM.Producto.ColorDisponible;

                _contenedorTrabajo.Producto.Update(productoDesdeBd);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            produVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            return View(produVM);
        }
    }
}
