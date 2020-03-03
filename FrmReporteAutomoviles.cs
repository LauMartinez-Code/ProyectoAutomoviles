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
    public partial class FrmReporteAutomoviles : Form
    {        
        public FrmReporteAutomoviles()
        {
            InitializeComponent();
        }

        ReporteAutomoviles report = new ReporteAutomoviles();   //tipo: class rpt
        string SQL_Query; //guarda la consulta a enviar como parametro al metodo de la clase Acceso a Datos
        int c = 0;  //usado en los metodos de validación. Cuenta la cantidad de caracteres incorrectos ingresados antes de mostrar el MessageBox con la Advertencia

        private void FrmReporteAutomoviles_Load(object sender, EventArgs e)
        {
            SQL_Query = $"SELECT * FROM viewMostrarAutos"; 

            ActualizarReporte(report);

            txtCodigo.Enabled = false;
            txtMarca.Enabled = false;
            txtColor.Enabled = false;
            txtAño.Enabled = false;

            //WindowState = FormWindowState.Maximized;
        }

        private void FrmReporteAutomoviles_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMenu.FrmChildClosed = true;
        }

        private void ActualizarReporte(ReporteAutomoviles report)
        {
            report.SetDataSource(AccesoDatos.ConsultaSQL(SQL_Query));
            crystalReportAutos.ReportSource = report;
            crystalReportAutos.Refresh();
            crystalReportAutos.Show();
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            if (checkBoxCodigo.Checked)
            {
                if (txtCodigo.Text != string.Empty)
                {
                    SQL_Query = $"SELECT * FROM viewMostrarAutos WHERE Codigo = {txtCodigo.Text}";

                    ActualizarReporte(report);
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

                    ActualizarReporte(report);
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

                    ActualizarReporte(report);
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

                    ActualizarReporte(report);
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

                ActualizarReporte(report);

                checkBoxTodo.Checked = false;
            }
            else
            {
                MessageBox.Show("No se a seleccionado un ningún filtro de busqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Clear();

            if (checkBoxCodigo.Checked)
            {
                txtCodigo.Enabled = true;
                checkBoxMarca.Enabled = false;
                checkBoxColor.Enabled = false;
                checkBoxAño.Enabled = false;
                checkBoxTodo.Enabled = false;
                txtCodigo.Focus();
            }
            else
            {
                checkBoxMarca.Enabled = true;
                checkBoxColor.Enabled = true;
                checkBoxAño.Enabled = true;
                checkBoxTodo.Enabled = true;
                txtCodigo.Enabled = false;
            }
        }

        private void checkBoxMarca_CheckedChanged(object sender, EventArgs e)
        {
            txtMarca.Clear();

            if (checkBoxMarca.Checked)
            {
                checkBoxCodigo.Enabled = false;
                checkBoxColor.Enabled = false;
                checkBoxAño.Enabled = false;
                checkBoxTodo.Enabled = false;
                txtMarca.Enabled = true;
                txtMarca.Focus();
            }
            else
            {
                checkBoxCodigo.Enabled = true;
                checkBoxColor.Enabled = true;
                checkBoxAño.Enabled = true;
                checkBoxTodo.Enabled = true;
                txtMarca.Enabled = false;
            }
        }

        private void checkBoxAño_CheckedChanged(object sender, EventArgs e)
        {
            txtAño.Clear();

            if (checkBoxAño.Checked)
            {
                checkBoxCodigo.Enabled = false;
                checkBoxMarca.Enabled = false;
                checkBoxColor.Enabled = false;
                checkBoxTodo.Enabled = false;
                txtAño.Enabled = true;
                txtAño.Focus();
            }
            else
            {
                checkBoxCodigo.Enabled = true;
                checkBoxMarca.Enabled = true;
                checkBoxColor.Enabled = true;
                checkBoxTodo.Enabled = true;
                txtAño.Enabled = false;
            }
        }

        private void checkBoxColor_CheckedChanged(object sender, EventArgs e)
        {
            txtColor.Clear();

            if (checkBoxColor.Checked)
            {
                checkBoxCodigo.Enabled = false;
                checkBoxAño.Enabled = false;
                checkBoxMarca.Enabled = false;
                checkBoxTodo.Enabled = false;
                txtColor.Enabled = true;
                txtColor.Focus();
            }
            else
            {
                checkBoxCodigo.Enabled = true;
                checkBoxAño.Enabled = true;
                checkBoxMarca.Enabled = true;
                checkBoxTodo.Enabled = true;
                txtColor.Enabled = false;
            }
        }

        private void checkBoxTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTodo.Checked)
            {
                checkBoxCodigo.Enabled = false;
                checkBoxAño.Enabled = false;
                checkBoxMarca.Enabled = false;
                checkBoxColor.Enabled = false;
                BtnConsulta.Text = "Consultar Todo";
            }
            else
            {
                checkBoxCodigo.Enabled = true;
                checkBoxAño.Enabled = true;
                checkBoxMarca.Enabled = true;
                checkBoxColor.Enabled = true;
                BtnConsulta.Text = "Consultar con Filtros";
            }
        }
       
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;

                c++;
                if (c == 2)
                {
                    MessageBox.Show("Ingrese solo Números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c = 0;
                }
            }
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;

                c++;
                if (c == 2)
                {
                    MessageBox.Show("Ingrese solo Números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c = 0;
                }
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
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
        
    }
}
