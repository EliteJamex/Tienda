using Microsoft.AspNetCore.Mvc;
using Tienda_Prueba.Models;
using Tienda_Prueba.Interface;
using Tienda_Prueba.Repository;
using Tienda_Prueba.Servicios;

namespace Tienda_Prueba.Controllers
{
    public class VentaController : Controller
    {
        private readonly IProducto _servicioProducto;
        private RepositoryCarritoCompra _CarritoCompra;

        public VentaController(RepositoryCarritoCompra carritoCompra, IProducto Servicio)
        {
            _servicioProducto = Servicio;
            _CarritoCompra = carritoCompra;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BusquedaProductos()
        {
            var ListaProductos = _servicioProducto.ListaProductos();
            return View("BusquedaProductos", ListaProductos);
        }

        [HttpPost]
        public IActionResult BusquedaProductos(string AbvProducto)
        {
            var ListaProductos = _servicioProducto.ProductoPorNombre(AbvProducto);
            return View("BusquedaProductos", ListaProductos);
        }

        [HttpPost]
        public IActionResult AgregarAlCarrito(int idProducto)
        {
            var producto = _servicioProducto.ProductoPorId(idProducto);
            _CarritoCompra.AnnadirItems(producto);
            var ListaProductos = _servicioProducto.ListaProductos();
            return View("BusquedaProductos", ListaProductos);
        }
    }
}
