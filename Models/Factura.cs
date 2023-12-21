namespace Tienda_Prueba.Models
{
    public class Factura
    {
        public int? Id { get; set; }
        public string Observacion { get; set; }
        public int Usuario_id { get; set; }
        public DateTime created { get; set; }

    }
}
