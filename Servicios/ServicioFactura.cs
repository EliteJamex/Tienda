using Tienda_Prueba.Models;
using Tienda_Prueba.Interface;
using Microsoft.Data.SqlClient;
using Tienda_Prueba.Utilities;
using Dapper;

namespace Tienda_Prueba.Servicios
{
    public class ServicioFactura : IFacturacion
    {
        private string CadenaConexion;
        public ServicioFactura(ConexionBD conexion)
        {
            CadenaConexion = conexion.CadenaConexionSql;
        }
        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }
        public Factura FacturaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factura> ListaFacturas()
        {
            SqlConnection sqlConexion = conexion();
            List<Factura> ListaProductos = new List<Factura>();
            try
            {
                sqlConexion.Open();
                var r = sqlConexion.Query<Factura>("select * from Factura");
                ListaProductos = r.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener las facturas \"" + ex.Message);
            }
            finally
            {
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return ListaProductos;
            //return _ListaEmpleados.Where(e => 
        }

        public void InsertarFactura(Factura factura)
        {
            SqlConnection sqlConexion = conexion();
            var InsertFactura = "INSERT INTO Factura (observacion,usuario_id,created) values ('"+factura.Observacion+"','"+factura.Usuario_id+"',GETDATE())";
            try
            {
                sqlConexion.Open();
                sqlConexion.Query(InsertFactura);

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al insertar factura \"" + ex.Message);
            }
            finally
            {
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
        }
    }
}
