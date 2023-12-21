namespace Tienda_Prueba.Utilities
{
    public class ConexionBD
    {
        private string cadenaConexionSql;
        public string CadenaConexionSql { get => cadenaConexionSql; } 

        public ConexionBD(string ConexionSql)
        {
            cadenaConexionSql = ConexionSql;
        }
    }
}
