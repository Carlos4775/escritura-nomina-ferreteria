using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ProgramaEscribirArchivo
{
    public partial class Form1 : Form
    {
        private string fileName = @"c:\files\Nomina.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection ocon = Conexion.getConnection();
                SqlDataReader reader;
                string sSQL = "select Clave_Nomina, Tipo_Doc, No_Doc, Nombre, Primer_Apellido, Segundo_Apellido, Sexo, Fecha_Nacimiento, Salario_Cotizable, Aporte_Voluntario, Salario_ISR, Otras_Remuneraciones, RNC_Cedula, Ingresos_Exentos, Saldo_Favor, Salario_INFOTEP, Tipo_Ingreso ";
                sSQL += "from NominasBanco ";
                SqlCommand ocmd = new SqlCommand(sSQL, ocon);

                reader = ocmd.ExecuteReader();
                while (reader.Read())
                {
                    writeFileLine(reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4) + "," + reader.GetValue(5) + "," + reader.GetValue(6) + "," + reader.GetValue(7) + "," + reader.GetValue(8) + "," + reader.GetValue(9) + "," + reader.GetValue(10) + "," + reader.GetValue(11) + "," + reader.GetValue(12) + "," + reader.GetValue(13) + "," + reader.GetValue(14) + "," + reader.GetValue(15) + "," + reader.GetValue(16));
                }
                reader.Close();
                ocmd.Dispose();
                ocon.Close();
                MessageBox.Show("Archivo generado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los datos de la nomina... ");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void writeFileLine(string pLine)
        {
            using (System.IO.StreamWriter w = File.AppendText(fileName))
            {
                w.WriteLine(pLine);
            }
        }
    }
}
