using Tienda_Prueba.Models;

namespace Tienda_Prueba.Interface
{
    public interface IFacturacion
    {
        public IEnumerable<Factura> ListaFacturas();
        public Factura FacturaPorId(int id);
        public void InsertarFactura(Factura factura);
    }
}
