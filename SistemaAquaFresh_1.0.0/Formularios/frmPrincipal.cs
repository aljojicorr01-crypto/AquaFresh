using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAquaFresh_1._0._0.Formularios
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formularioAbierto = this.MdiChildren.FirstOrDefault(f => f is frmVentas);

            if (formularioAbierto != null)
            {
                formularioAbierto.BringToFront();
            }
            else
            {
                frmVentas frmHijo = new frmVentas();
                frmHijo.MdiParent = this;
                frmHijo.WindowState = FormWindowState.Maximized;
                frmHijo.Show();
            }
        }

        private void reporteDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient mdiContenedor)
                {
                    mdiContenedor.BackgroundImage = this.BackgroundImage;
                    mdiContenedor.BackgroundImageLayout = this.BackgroundImageLayout;
                    break;
                }
            }
        }

        private void generarReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formularioAbierto = this.MdiChildren.FirstOrDefault(f => f is frmReportes);

            if (formularioAbierto != null)
            {
                formularioAbierto.BringToFront();
            }
            else
            {
                frmReportes frmHijo = new frmReportes();
                frmHijo.MdiParent = this;
                frmHijo.WindowState = FormWindowState.Maximized;
                frmHijo.Show();
            }
        }
    }
}
