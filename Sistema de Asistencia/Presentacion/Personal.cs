using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema_de_Asistencia.Logica;
using Sistema_de_Asistencia.Datos;

namespace Sistema_de_Asistencia.Presentacion
{
    public partial class Personal : UserControl
    {
        public Personal()
        {
            InitializeComponent();
        }
        int Idcargo;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LocalizarDtvCargos();
            PanelCargos.Visible = false;
            PanelPaginado.Visible = false;
            PanelRegistros.Visible = true;
            PanelRegistros.Dock = DockStyle.Fill;
            btnGuardarPersonal.Visible = true;
            btnGuardarCambiosPersonal.Visible = false;
            Limpiar();
        }
        private void LocalizarDtvCargos()
        {
            dataListadoCargos.Location = new Point(txtSueldoHora.Location.X, txtSueldoHora.Location.Y);
            dataListadoCargos.Size = new Size(469, 141);
            dataListadoCargos.Visible = true;
            lblSueldo.Visible = false;
            dataListadoCargos.Visible = false;

        }
        private void Limpiar()
        {
            txtNombres.Clear();
            txtIdentificacion.Clear();
            txtCargo.Clear();
            txtSueldoHora.Clear();
            BuscarCargos();
        }

        private void btnGuardarPersonal_Click(object sender, EventArgs e)
        {

        }
        private void Insertar_Personal()
        {
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();
            parametros.Nombres = txtNombres.Text;
            parametros.Identificacion = txtIdentificacion.Text;
            parametros.Pais = cbxPais.Text;
        }
        private void InsertarCargos()
        {
            if (!string.IsNullOrEmpty(txtCargoG.Text))
            {
                if (!string.IsNullOrEmpty(txtSuelgoG.Text))
                {
                    Lcargos parametros = new Lcargos();
                    Dcargos funcion = new Dcargos();
                    parametros.Cargo = txtCargoG.Text;
                    parametros.SueldoPorHora = Convert.ToDouble(txtSuelgoG.Text);

                    if (funcion.insertar_Cargo(parametros) == true)
                    {
                        txtCargo.Clear();
                        BuscarCargos();
                        PanelCargos.Visible = false;

                    }
                }
                else
                {
                    MessageBox.Show("Agrege el sueldo", "Falta el sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Agrege el cargo", "Falta el cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void BuscarCargos()
        {
            DataTable dt = new DataTable();
            Dcargos funcion = new Dcargos();
            funcion.buscarCargos(ref dt, txtCargo.Text);
            dataListadoCargos.DataSource = dt;
            Bases.DiseñoDtv(ref dataListadoCargos);
            dataListadoCargos.Columns[1].Visible = false;
            dataListadoCargos.Columns[3].Visible = false;
            dataListadoCargos.Visible = true;
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            BuscarCargos();
        }

        private void btnAgregarCargo_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = true;
            PanelCargos.Dock = DockStyle.Fill;
            PanelCargos.BringToFront();
            btnGuardarC.Visible = true;
            btnGuardarCambiosC.Visible = true;
            txtCargoG.Clear();
            txtSuelgoG.Clear();

        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            InsertarCargos();
        }

        private void txtSuelgoG_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSuelgoG, e);
        }

        private void txtSuelgoG_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtSueldoHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSuelgoG, e);
        }

        private void dataListadoCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoCargos.Columns["EditarC"].Index)
            {
                ObtenerCargosEditar();
            }
            if (e.ColumnIndex == dataListadoCargos.Columns["Cargo"].Index)
            {
                ObtenerDatosCargos();
            }
        }
        private void ObtenerDatosCargos()
        {
            Idcargo = Convert.ToInt32(dataListadoCargos.SelectedCells[1].Value);
            txtCargo.Text = dataListadoCargos.SelectedCells[2].Value.ToString();
            txtSueldoHora.Text = dataListadoCargos.SelectedCells[3].Value.ToString();
            dataListadoCargos.Visible = false;
            PanelBtnGuardarPersonal.Visible = true;
            lblSueldo.Visible = true;
        }
        private void ObtenerCargosEditar()
        {
            Idcargo = Convert.ToInt32(dataListadoCargos.SelectedCells[1].Value);
            txtCargoG.Text = dataListadoCargos.SelectedCells[2].Value.ToString();
            txtSuelgoG.Text = dataListadoCargos.SelectedCells[3].Value.ToString();
            btnGuardarC.Visible = false;
            btnGuardarCambiosC.Visible = true;
            txtCargoG.Focus();
            txtCargoG.SelectAll();
            PanelCargos.Visible = true;
            PanelCargos.Dock = DockStyle.Fill;
            PanelCargos.BringToFront();
        }

        private void btnVolverCargos_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = false;
        }

        private void btnVolverPersonal_Click(object sender, EventArgs e)
        {
            PanelRegistros.Visible = false;
        }

        private void btnGuardarCambiosC_Click(object sender, EventArgs e)
        {
            EditarCargos();
        }
        private void EditarCargos()
        {
            Lcargos parametros = new Lcargos();
            Dcargos funcion = new Dcargos();
            parametros.Id_cargo = Idcargo;
            parametros.Cargo = txtCargoG.Text;
            parametros.SueldoPorHora = Convert.ToDouble(txtSuelgoG.Text);
            if (funcion.editar_Cargo(parametros) == true)
            {
                txtCargo.Clear();
                BuscarCargos();
                PanelCargos.Visible = false;
            }
        }
    }
}
