using ADOWinForms.ADO;
using ADOWinForms.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWinForms
{
    public partial class Form2 : Form
    {
        EstatusAlumno _eAlumn = new EstatusAlumno();
        ADOEstatusAlumno _ADOa = new ADOEstatusAlumno();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Text = "Agregar";
            refrescar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADOEstatusAlumno ado = new ADOEstatusAlumno();
            EstatusAlumno ac = (EstatusAlumno)cbxEstatus.SelectedItem;
            cbxEstatus.DataSource = ado.Consultar();

            txtNombre.Text = ac.nombre;
            txtClave.Text = ac.clave;
            lblPruebas.Text = Convert.ToString(ac.id);

            panel1.Visible = true;
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Text = "Actualizar";
            refrescar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Text = "Eliminar";
            
            txtClave.Enabled = false;
            txtNombre.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        public void refrescar()
        {
            ADOEstatusAlumno aDO= new ADOEstatusAlumno();
            cbxEstatus.DataSource = aDO.Consultar();
            cbxEstatus.DisplayMember = "nombre";
            cbxEstatus.ValueMember = "id";
            dgvEstatus.DataSource = aDO.Consultar();
           // panel1.Visible = false;
            this.Refresh();
        }
        public void LimpiarCancelar()
        {
            txtClave.Clear();
            txtNombre.Clear();

            btnGuardar.Text = "";
            txtClave.Enabled = true;
            txtNombre.Enabled = true;
            panel1.Visible = false;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            refrescar();
        }
            private void panel1_Paint(object sender, PaintEventArgs e)
            {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

  

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(btnGuardar.Text == "Agregar")
            {
                
                Console.WriteLine();    
                string nombre = txtNombre.Text;
                string clave = txtClave.Text;

                _eAlumn.clave = clave;
                _eAlumn.nombre = nombre;
                _ADOa.Agregar(_eAlumn);
                LimpiarCancelar();
                refrescar();
            }
            else if(btnGuardar.Text == "Actualizar")
            {
                cbxEstatus.DataSource = _ADOa.Consultar();
                cbxEstatus.DisplayMember = "nombre";
                cbxEstatus.ValueMember = "id";

                int id;
                id = Convert.ToInt32(lblPruebas.Text);
                string nombre = txtNombre.Text;
                string clave = txtClave.Text;
                _eAlumn.id = id;
                _eAlumn.clave = clave;
                _eAlumn.nombre= nombre;
                _ADOa.Actulizar(_eAlumn);
                LimpiarCancelar();
                refrescar();
            }
            else if(btnGuardar.Text == "Eliminar")
            {
                string id = cbxEstatus.SelectedValue.ToString();
                lblPruebas.Text = id;
                _eAlumn.id = Convert.ToInt32(id);
                _ADOa.Eliminar(_eAlumn);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LimpiarCancelar();
            refrescar();
        }
    }
}
