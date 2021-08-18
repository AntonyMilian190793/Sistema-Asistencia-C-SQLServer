using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_Asistencia.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panelBienvenida.Dock = DockStyle.Fill;
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            PanelPadre.Controls.Clear();
            Personal control = new Personal();
            control.Dock = DockStyle.Fill;
            PanelPadre.Controls.Add(control);
        }
    }
}
