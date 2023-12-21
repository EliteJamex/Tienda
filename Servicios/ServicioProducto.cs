using Dapper;
using Microsoft.Data.SqlClient;
using Tienda_Prueba.Interface;
using Tienda_Prueba.Models;
using Tienda_Prueba.Utilities;

namespace Tienda_Prueba.Servicios
{
    public class ServicioProducto : IProducto
    {
        private string CadenaConexion;


        public ServicioProducto(ConexionBD conexion)
        {
            CadenaConexion = conexion.CadenaConexionSql;
        }

        public IEnumerable<Producto> ListaProductos()
        {
            SqlConnection sqlConexion = conexion();
            List<Producto> ListaProductos = new List<Producto>();
            try
            {
                sqlConexion.Open();
                var r = sqlConexion.Query<Producto>("select * from Producto");
                ListaProductos = r.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener los empleados \"" + ex.Message);
            }
            finally
            {
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return ListaProductos;
        }

        public IEnumerable<Producto> ProductoPorNombre(string CadenaBusqueda)
        {
            if(CadenaBusqueda != "")
            {
                SqlConnection sqlConexion = conexion();
                List<Producto> ListaProductos = new List<Producto>();
                try
                {
                    sqlConexion.Open();
                    var r = sqlConexion.Query<Producto>("select * from Producto where nombre like '%" + CadenaBusqueda + "%'");
                    ListaProductos = r.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Se produjo un error al obtener los empleados \"" + ex.Message);
                }
                finally
                {
                    sqlConexion.Close();
                    sqlConexion.Dispose();
                }
                return ListaProductos;
            }
            else
            {
                this.ListaProductos();
            }
            //return _ListaEmpleados.Where(e => e.Nombre == CadenaBusqueda);
            return null;
        }

        public Producto ProductoPorId(int Id)
        {
            SqlConnection sqlConexion = conexion();
            Producto productoencontrado = new Producto();
            try
            {
                sqlConexion.Open();
                var r = sqlConexion.Query<Producto>("select * from Producto where id = "+ Id);
                productoencontrado = r.Single();
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener los producto\"" + ex.Message);
            }
            finally
            {
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return productoencontrado;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}
