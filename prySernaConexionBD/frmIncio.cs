using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySernaConexionBD
{
    public partial class frmIncio : Form
    {
        public frmIncio()
        {
            InitializeComponent();
        }
        clsConexion conexion = new clsConexion();
        private void frmIncio_Load(object sender, EventArgs e)
        {
           
            conexion.MostrarDatos(dgvMostrar);
        }
    }
}
