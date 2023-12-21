using Tienda_Prueba.Models;

namespace Tienda_Prueba.Interface
{
    public abstract class IFactura_Producto
    {
        public abstract void InsertarFacturaProducto(IEnumerable<Factura_Producto> ListaProductos);
    }
}
