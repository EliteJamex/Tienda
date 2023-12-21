using Tienda_Prueba.Models;

namespace Tienda_Prueba.Repository
{
    public class RepositoryCarritoCompra
    {
        public List<Producto> ListaDeProductos { get; } = new()
        {
            
        };

        public void AnnadirItems(Producto producto)
        {
            this.ListaDeProductos.Add(producto);
        }

        public List<Producto> ObtenerProductos()
        {
            return this.ListaDeProductos;
        }
    }
}
