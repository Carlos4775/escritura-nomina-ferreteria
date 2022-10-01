using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProgramaEscribirArchivo
{
    class Conexion
    {
        public static SqlConnection getConnection()
        {
            SqlConnection ocon = new SqlConnection("Data Source=DESKTOP-O4K30AB;Initial Catalog=NominasBD;Integrated Security=True");
            ocon.Open();
            return ocon;
        }
    }
}
