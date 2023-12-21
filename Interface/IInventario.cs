using Tienda_Prueba.Models;

namespace Tienda_Prueba.Interface
{
    public interface IInventario
    {
        public Inventario InventarioPorIdProducto(int id_producto);
    }
}
