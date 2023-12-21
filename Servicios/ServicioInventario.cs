using Tienda_Prueba.Interface;
using Tienda_Prueba.Models;

namespace Tienda_Prueba.Servicios
{
    public class ServicioInventario : IInventario
    {
        private readonly List<Inventario> _ListaInventarios = new()
        {
            new Inventario {Id=1, Cantidad=20, Producto_id=1},
            new Inventario {Id=2, Cantidad=0, Producto_id=2},
            new Inventario {Id=2, Cantidad=2, Producto_id=3},
        };

        public Inventario InventarioPorIdProducto(int id_producto)
        {
            return _ListaInventarios.Where(e => e.Producto_id == id_producto).SingleOrDefault();
        }
    }
}
