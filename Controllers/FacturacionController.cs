using Microsoft.AspNetCore.Mvc;
using Tienda_Prueba.Models;
using Tienda_Prueba.Repository;
using System.Linq;
using Tienda_Prueba.Interface;
using Tienda_Prueba.Servicios;

namespace Tienda_Prueba.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly RepositoryCarritoCompra _CarritoCompra;
        private readonly IFacturacion _servicioFactura;
        public FacturacionController(RepositoryCarritoCompra carritoCompra, IFacturacion Servicio)
        {
            _CarritoCompra = carritoCompra;
            _servicioFactura = Servicio;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FacturaPendiente()
        {
            var ListaProductos = _CarritoCompra.ObtenerProductos();
            List<Producto> ListaCarrito = new List<Producto>();
            List<Factura_Producto> Cantidades = new List<Factura_Producto>();
            double Suma = 0;

            for (int i = 0; i < ListaProductos.Count; i++)
            {
                bool esDuplicado = false;
                for (int j = 0; j < i; j++)
                {
                    if (ListaProductos[i].Id == ListaProductos[j].Id)
                    {
                        var facturaProductoExistente = Cantidades.FirstOrDefault(fp => fp.Producto_id == ListaProductos[i].Id);
                        if (facturaProductoExistente != null)facturaProductoExistente.Cantidad++;
                        Suma += ListaProductos[i].Valor;

                        esDuplicado = true;
                        break;
                    }
                }

                if (!esDuplicado)
                {
                    Cantidades.Add(new Factura_Producto { Id = i, Producto_id = ListaProductos[i].Id , Cantidad = 1 });
                    Suma += ListaProductos[i].Valor;
                    ListaCarrito.Add(ListaProductos[i]);
                }
            }
            ListaCarrito.OrderBy(e => e.Id);
            Cantidades.OrderBy(e => e.Producto_id);


            ViewBag.Total = Suma;
            ViewBag.Componentes = Cantidades;
            return View("FacturaPendiente", ListaCarrito);
        }

        [HttpPost]
        public IActionResult FacturaPendiente(int Saldo,string Observaciones)
        {
           Factura NuevaFactura = new Factura();
            NuevaFactura.Observacion = Observaciones;
            NuevaFactura.Usuario_id = 1;
            NuevaFactura.created = DateTime.Now;

            _servicioFactura.InsertarFactura(NuevaFactura);
            _CarritoCompra.ListaDeProductos.Clear();
            return View("../Home/Index");
        }
        public IActionResult BusquedaFacturas()
        {
            var ListaFacturas = _servicioFactura.ListaFacturas();
            return View("BusquedaFacturas",ListaFacturas);
        }
    }
}
