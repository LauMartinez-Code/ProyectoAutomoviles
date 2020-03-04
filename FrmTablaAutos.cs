using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAppTPi_ProgramacionII
{
    public partial class FrmTablaAutos : Form
    {
        string SQL_Query;
        short c = 0;
        public FrmTablaAutos()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void FrmTablaAutos_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            txtCodigo.Enabled = txtMarca.Enabled = txtColor.Enabled = txtAño.Enabled = false;

            SQL_Query = "SELECT * FROM viewMostrarAutos";

            dataGridAuto.DataSource = AccesoDatos.ConsultaSQL(SQL_Query);
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            if (checkBoxCodigo.Checked)
            {
                if (txtCodigo.Text != string.Empty)
                {
                    SQL_Query = $"SELECT * FROM viewMostrarAutos WHERE Codigo = {txtCodigo.Text}";

                    dataGridAuto.DataSource = AccesoDatos.ConsultaSQL(SQL_Query);
                }
                else
                {
                    MessageBox.Show("El campo \"Codigo\" esta vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Focus();
                }
            }
            else if (checkBoxMarca.Checked)
            {
                if (txtMarca.Text != string.Empty)
                {
                    SQL_Query = $"SELECT * FROM viewMostrarAutos WHERE Marca like '%{txtMarca.Text}%'";

                    dataGridAuto.DataSource = AccesoDatos.ConsultaSQL(SQL_Query);
                }
                else
                {
                    MessageBox.Show("El campo \"Marca\" esta vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMarca.Focus();
                }
            }
            else if (checkBoxAño.Checked)
            {
                if (txtAño.Text != string.Empty)
                {
                    SQL_Query = $"SELECT * FROM viewMostrarAutos WHERE Año = {txtAño.Text}";

                    dataGridAuto.DataSource = AccesoDatos.ConsultaSQL(SQL_Query);
                }
                else
                {
                    MessageBox.Show("El campo \"Año\" esta vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAño.Focus();
                }               
            }
            else if (checkBoxColor.Checked)
            {
                if (txtColor.Text != string.Empty)
                {
                    SQL_Query = $"SELECT * FROM viewMostrarAutos WHERE Color like '%{txtColor.Text}%'";

                    dataGridAuto.DataSource = AccesoDatos.ConsultaSQL(SQL_Query);
                }
                else
                {
                    MessageBox.Show("El campo \"Color\" esta vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtColor.Focus();
                }
            }
            else if (checkBoxTodo.Checked)
            {
                SQL_Query = $"SELECT * FROM viewMostrarAutos";

                dataGridAuto.DataSource = AccesoDatos.ConsultaSQL(SQL_Query);

                checkBoxTodo.Checked = false;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un ningún filtro de busqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     
        

        private void checkBoxCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Clear();

            if (checkBoxCodigo.Checked)
            {
                txtCodigo.Enabled = true;
                checkBoxTodo.Enabled = checkBoxMarca.Enabled = checkBoxColor.Enabled = checkBoxAño.Enabled = false;
                txtCodigo.Focus();
            }
            else
            {
                checkBoxTodo.Enabled = checkBoxMarca.Enabled = checkBoxColor.Enabled = checkBoxAño.Enabled = true;
                txtCodigo.Enabled = false;
            }            
        }

        private void checkBoxMarca_CheckedChanged(object sender, EventArgs e)
        {
            txtMarca.Clear();

            if (checkBoxMarca.Checked)
            {
                checkBoxTodo.Enabled = checkBoxCodigo.Enabled = checkBoxColor.Enabled = checkBoxAño.Enabled = false;
                txtMarca.Enabled = true;
                txtMarca.Focus();
            }
            else
            {
                checkBoxTodo.Enabled = checkBoxCodigo.Enabled = checkBoxColor.Enabled = checkBoxAño.Enabled = true;
                txtMarca.Enabled = false;
            }            
        }
        private void checkBoxAño_CheckedChanged(object sender, EventArgs e)
        {
            txtAño.Clear();

            if(checkBoxAño.Checked)
            {
                checkBoxTodo.Enabled = checkBoxCodigo.Enabled = checkBoxMarca.Enabled = checkBoxColor.Enabled = false;
                txtAño.Enabled = true;
                txtAño.Focus();
            }
            else
            {
                checkBoxTodo.Enabled = checkBoxCodigo.Enabled = checkBoxMarca.Enabled = checkBoxColor.Enabled = true;
                txtAño.Enabled = false;
            }
        }

        private void checkBoxColor_CheckedChanged(object sender, EventArgs e)
        {
            txtColor.Clear();

            if (checkBoxColor.Checked)
            {
                checkBoxTodo.Enabled = checkBoxCodigo.Enabled = checkBoxMarca.Enabled = checkBoxAño.Enabled = false;
                txtColor.Enabled = true;
                txtColor.Focus();
            }
            else
            {
                checkBoxTodo.Enabled = checkBoxCodigo.Enabled = checkBoxMarca.Enabled = checkBoxAño.Enabled = true;
                txtColor.Enabled = false;
            }
        }
        private void checkBoxTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTodo.Checked)
            {
                checkBoxColor.Enabled = checkBoxCodigo.Enabled = checkBoxMarca.Enabled = checkBoxAño.Enabled = false;
                BtnConsulta.Text = "Consultar Todo";
            }
            else
            {
                checkBoxColor.Enabled = checkBoxCodigo.Enabled = checkBoxMarca.Enabled = checkBoxAño.Enabled = true;
                BtnConsulta.Text = "Consultar con Filtros";
            }
        }

        //Eventos de validacion de Entrada de los TextBox
        private void ValidarSoloNumeros(KeyPressEventArgs e)    //Metodo que solo perimite que se lean por teclado números y la tecla de borrado
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;

                c++;
                if (c == 2) //al ingresar 2 valores no validos se le envía un Advertencia al Usuario
                {
                    MessageBox.Show("Ingrese solo Números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c = 0;
                }
            }
        }
        private void ValidarSoloLetras(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;

                c++;
                if (c == 2)
                {
                    MessageBox.Show("Ingrese solo Letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c = 0;
                }
            }
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloLetras(e);
        }
    }
}
