using Tienda_Prueba.Models;

namespace Tienda_Prueba.Interface
{
    public interface IProducto
    {
        public IEnumerable<Producto> ListaProductos();
        public IEnumerable<Producto> ProductoPorNombre(string CadenaBusqueda);
        public Producto ProductoPorId(int Id);
    }
}
