using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySernaConexionBD
{
    internal class clsConexion
    {
        //cadena de conexion
        string cadenaConexion = "Server=localhost;Database=Comercio;Trusted_Connection=True;";


        //conector
        SqlConnection coneccionBaseDatos;

        //comando
        SqlCommand comandoBaseDatos;

        public string nombreBaseDeDatos;


        public void ConectarBD()
        {
            try
            {
                coneccionBaseDatos = new SqlConnection(cadenaConexion);

                nombreBaseDeDatos = coneccionBaseDatos.Database;

                coneccionBaseDatos.Open();

                MessageBox.Show("Conectado a " + nombreBaseDeDatos);
            }
            catch (Exception error)
            {
                MessageBox.Show("Tiene un errorcito - " + error.Message);
            }

        }

        public void MostrarDatos(DataGridView dgv)
        {
            try
            {
                /* conexionBaseDatos = new SqlConnection(cadenaConexion);
                nombreBaseDeDatos = conexionBaseDatos.Database;
                conexionBaseDatos.Open(); */

                ConectarBD(); //<---- Invocando a este metodo se ejecuta exactamente lo mismo que esta arriba

                string query = "SELECT * FROM Contactos";
                comandoBaseDatos = new SqlCommand(query, coneccionBaseDatos);

                //Crear un DataTable
                DataTable productos = new DataTable();

                //Llenar el DataTable
                using (SqlDataReader reader = comandoBaseDatos.ExecuteReader())
                {
                    productos.Load(reader);
                }
                //Mostrar en grilla
                dgv.DataSource = productos;
            }
            catch (Exception error)
            {
                MessageBox.Show("Tiene un errorcito - " + error.Message);
            }
            finally
            {
                coneccionBaseDatos.Close();
            }
        }



    }
}
