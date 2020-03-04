using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WFAppTPi_ProgramacionII
{
    public partial class FrmABMAutomovil : Form
    {
        List<Automovil> Autito = new List<Automovil>();  //guarda todos los datos levantados de la BD como objetos de tipo Automovil para luego modificarlos desde esta y tmb mostrarlos en la listBox del formulario
        bool NuevoRegistro; //indica si el registro sobre el que se está trabajando es uno nuevo o ya existente, en caso de ser nuevo el SQL_Query es un Insert y sino un Update
        string SQL_Query;   //guarda la consulta a enviar como parametro al metodo de la clase Acceso a Datos
        int c = 0;  //usado en los metodos de validación. Cuenta la cantidad de caracteres incorrectos ingresados antes de mostrar el MessageBox con la Advertencia
        double validarNumeros; //usado en el metodo ValidarCamposVacios()  para verificar que los números ingresados tengan formato correcto
        public FrmABMAutomovil()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }


        /////////////////////////////////////__Eventos__\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        private void FrmABMAutomovil_Load(object sender, EventArgs e)
        {
            CargarCombo(cboMarca, "Marcas");
            CargarCombo(cboCombustible, "Combustibles");
            CargarCombo(cboCajaVeloc, "Tipos_Cajas_Velocidad");
            CargarCombo(cboTipoDirecc, "Tipos_Direcciones");
            CargarCombo(cboColor, "Colores");

            CargarListBox("viewCargarAutos");

            txtCodigo.Enabled = false;  //Constante a lo largo de todo el programa
            HabilitarBotones(false);
        }

        private void FrmABMAutomovil_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult BtnSeleccionado = DialogResult.No;

            if (!iconBtnCerrar.Enabled)
            {
                BtnSeleccionado = MessageBox.Show("Guarde o Cancele la operación en curso para cerrar la aplicación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                BtnSeleccionado = MessageBox.Show("¿Seguro que desea cerrar el formulario actual?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            }            

            if (BtnSeleccionado == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void FrmABMAutomovil_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMenu.FrmChildClosed = true;
        }

        //Botones
        private void iconBtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarBotones(true);
            LimpiarCampos();

            NuevoRegistro = true;            
            txtCodigo.Text = "Autogenerado";
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            HabilitarBotones(true);

            NuevoRegistro = false;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult Confirmacion = DialogResult.No;            
            
            if (ValidarCamposVacios())
            {
                Automovil aux = new Automovil();    //var auxiliar de Automovil dnd se guardan los valores ingresados en los campos para usarlos como parametros en las Sentencias SQL posteriormente

                aux = LevantarValoresDeCampos();

                if (NuevoRegistro)  //Confirma si se desea realizar la Operacion y guardar los cambios
                {
                    Confirmacion = MessageBox.Show("¿Esta seguro que desea registrar un nuevo Automovil con los valores indicados?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                }
                else
                {
                    Confirmacion = MessageBox.Show($"¿Esta seguro que desea modificar el registro seleccionado?\n Código: {Autito[ListBoxAutos.SelectedIndex].Id}", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                }

                if (Confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        if (NuevoRegistro)
                        {
                            SQL_Query = $"INSERT INTO Autos VALUES({aux.IdMarca}, '{aux.Modelo}', {aux.Año}, '{aux.Dimenciones}', " +
                                $"'{aux.Motor}', {aux.IdCombustible}, {aux.IdCajaVeloc}, {aux.Velocidades}, {aux.IdTipoDireccion}, {aux.IdColor}, " +
                                $"{aux.CantPuertas}, '{aux.TamañoLlantas}', {aux.CantAirBags}, {C(aux.CamaraRetroceso)}, {C(aux.SensorLLuvia)}, " +
                                $"{C(aux.TechoCielo)}, {C(aux.ClimaBiZona)}, {C(aux.LevantaVidrioAutom)}, '{aux.AudioConectividad}', {C(aux.CierreCentralizado)})";

                            AccesoDatos.ActualizarBD(SQL_Query);

                            LimpiarCampos();
                            CargarListBox("viewCargarAutos");
                        }
                        else
                        {
                            SQL_Query = $"UPDATE Autos SET id_marca = {aux.IdMarca}, modelo = '{aux.Modelo}', año = {aux.Año}, " +
                                $"dimenciones = '{aux.Dimenciones}', motor = '{aux.Motor}', id_combustible = {aux.IdCombustible}, " +
                                $"id_cajaVelocidad =  {aux.IdCajaVeloc}, velocidades = {aux.Velocidades}, id_tipoDireccion = {aux.IdTipoDireccion}, " +
                                $"id_color = {aux.IdColor}, cantidad_puertas = {aux.CantPuertas}, tamaño_llantas = '{aux.TamañoLlantas}', " +
                                $"cantidad_AirBags = {aux.CantAirBags}, Camara_de_Retroceso = {C(aux.CamaraRetroceso)}, sensores_lluvia_parabrisas = {C(aux.SensorLLuvia)}, " +
                                $"techo_cielo = {C(aux.TechoCielo)}, climatizador_BiZona = {C(aux.ClimaBiZona)}, LevantaVidrio_Automatico = {C(aux.LevantaVidrioAutom)}, " +
                                $"Audio_Conectividad = '{aux.AudioConectividad}', Cierre_Centralizado = {C(aux.CierreCentralizado)} WHERE id_automovil = {aux.Id}";

                            AccesoDatos.ActualizarBD(SQL_Query);

                            LimpiarCampos();
                            CargarListBox("viewCargarAutos");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al intentar realizar la operación.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AccesoDatos.Connection.Close();
                    }

                    HabilitarBotones(false);
                    NuevoRegistro = false;
                }
            }
        }
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            HabilitarBotones(false);

            DialogResult BtnSeleccionado = MessageBox.Show($"¿Borrar el registro seleccionado?\n Código: {Autito[ListBoxAutos.SelectedIndex].Id}  de la Marca: {cboMarca.Text}",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (BtnSeleccionado == DialogResult.Yes)
            {
                try
                {
                    SQL_Query = $"DELETE Detalle_Factura WHERE id_producto = {Autito[ListBoxAutos.SelectedIndex].IdProducto}";   //Por Integridad Referencial primero se borra el registro de la tabla Detalles de Facturas para luego poder borrarlo de la tabla Productos
                    AccesoDatos.ActualizarBD(SQL_Query);

                    SQL_Query = $"DELETE Productos WHERE id_automovil = {Autito[ListBoxAutos.SelectedIndex].Id}";   //Por Integridad Referencial primero se borra el registro de la tabla Productos para luego poder borrarlo de la tabla Automoviles
                    AccesoDatos.ActualizarBD(SQL_Query);

                    SQL_Query = $"DELETE Autos WHERE id_automovil = {Autito[ListBoxAutos.SelectedIndex].Id}";
                    AccesoDatos.ActualizarBD(SQL_Query);

                    CargarListBox("viewCargarAutos");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al intentar realizar la operación.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AccesoDatos.Connection.Close();
                }                
            }
        }

        private byte C(bool x) //metodo Convert.ToByte() abreviado
        {
            byte b;

            b = Convert.ToByte(x);

            return b;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarBotones(false);
            NuevoRegistro = false;
            txtAlto.Clear(); //porque las dimenciones se muestran en un label y no en cada textbox
            txtAncho.Clear();
            txtLargo.Clear();
            ListBoxAutos.SelectedIndex = 0;
        }
        private void BtnListaCompleta_Click(object sender, EventArgs e)
        {
            FrmTablaAutos tablaAutos = new FrmTablaAutos();

            tablaAutos.ShowDialog();
        }


        //Eventos CheckBox. Evita que quede un opcion sin selecionar
        private void checkBoxCantPuertas_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCantPuertas_3.Checked)
            {
                checkBoxCantPuertas_5.Checked = false;
            }
            else
            {
                checkBoxCantPuertas_5.Checked = true;
            }
        }

        private void checkBoxCantPuertas_5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCantPuertas_5.Checked)
            {
                checkBoxCantPuertas_3.Checked = false;
            }
            else
            {
                checkBoxCantPuertas_3.Checked = true;
            }
        }

        private void checkBoxCamRetroceso_Si_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCamRetroceso_Si.Checked)
            {
                checkBoxCamRetroceso_No.Checked = false;
            }
            else
            {
                checkBoxCamRetroceso_No.Checked = true;
            }
        }

        private void checkBoxCamRetroceso_No_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCamRetroceso_No.Checked)
            {
                checkBoxCamRetroceso_Si.Checked = false;
            }
            else
            {
                checkBoxCamRetroceso_Si.Checked = true;
            }
        }

        private void checkBoxSensLuvia_Si_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSensLuvia_Si.Checked)
            {
                checkBoxSensLuvia_No.Checked = false;
            }
            else
            {
                checkBoxSensLuvia_No.Checked = true;
            }
        }

        private void checkBoxSensLuvia_No_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSensLuvia_No.Checked)
            {
                checkBoxSensLuvia_Si.Checked = false;
            }
            else
            {
                checkBoxSensLuvia_Si.Checked = true;
            }
        }

        private void checkBoxTechoCielo_Si_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTechoCielo_Si.Checked)
            {
                checkBoxTechoCielo_No.Checked = false;
            }
            else
            {
                checkBoxTechoCielo_No.Checked = true;
            }
        }

        private void checkBoxTechoCielo_No_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTechoCielo_No.Checked)
            {
                checkBoxTechoCielo_Si.Checked = false;
            }
            else
            {
                checkBoxTechoCielo_Si.Checked = true;
            }
        }

        private void checkBoxClimatizador_Si_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClimatizador_Si.Checked)
            {
                checkBoxClimatizador_No.Checked = false;
            }
            else
            {
                checkBoxClimatizador_No.Checked = true;
            }
        }

        private void checkBoxClimatizador_No_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClimatizador_No.Checked)
            {
                checkBoxClimatizador_Si.Checked = false;
            }
            else
            {
                checkBoxClimatizador_Si.Checked = true;
            }
        }

        private void checkBoxLevantaVidrio_Si_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLevantaVidrio_Si.Checked)
            {
                checkBoxLevantaVidrio_No.Checked = false;
            }
            else
            {
                checkBoxLevantaVidrio_No.Checked = true;
            }
        }

        private void checkBoxLevantaVidrio_No_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLevantaVidrio_No.Checked)
            {
                checkBoxLevantaVidrio_Si.Checked = false;
            }
            else
            {
                checkBoxLevantaVidrio_Si.Checked = true;
            }
        }

        private void checkBoxCierreCentral_Si_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCierreCentral_Si.Checked)
            {
                checkBoxCierreCentral_No.Checked = false;
            }
            else
            {
                checkBoxCierreCentral_No.Checked = true;
            }
        }

        private void checkBoxCierreCentral_No_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCierreCentral_No.Checked)
            {
                checkBoxCierreCentral_Si.Checked = false;
            }
            else
            {
                checkBoxCierreCentral_Si.Checked = true;
            }
        }


        /////////////////////////////////////__Metodos__\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void CargarCombo(ComboBox combo, string nombreTabla)    //Completa los Combox del Formulario con los datos de la tabla indicada
        {
            DataTable table = new DataTable();
            table = AccesoDatos.ConsultarTablaDT(nombreTabla);

            combo.DataSource = table;
            combo.ValueMember = table.Columns[0].ColumnName;
            combo.DisplayMember = table.Columns[1].ColumnName;
            combo.SelectedIndex = -1;
        }

        private void CargarListBox(string nombreTabla)  //Carga objetos del tipo Automovil con los datos de la tabla inicada y los guarda en la lista de Automoviles(Autito),dicha lista luego se muetra en el ListBox del Formulario
        {
            Autito.Clear();
            ListBoxAutos.Items.Clear();            

            AccesoDatos.ConsultarTablaDR(nombreTabla);

            while(AccesoDatos.Lector.Read())
            {
                Automovil aux = new Automovil();

                if (!AccesoDatos.Lector.IsDBNull(0))
                    aux.Id = AccesoDatos.Lector.GetInt32(0);
                if (!AccesoDatos.Lector.IsDBNull(1))
                    aux.IdMarca = AccesoDatos.Lector.GetInt32(1);
                if (!AccesoDatos.Lector.IsDBNull(2))
                    aux.Modelo = AccesoDatos.Lector.GetString(2);
                if (!AccesoDatos.Lector.IsDBNull(3))
                    aux.Año = AccesoDatos.Lector.GetInt32(3);
                if (!AccesoDatos.Lector.IsDBNull(4))
                    aux.Dimenciones = AccesoDatos.Lector.GetString(4);
                if (!AccesoDatos.Lector.IsDBNull(5))
                    aux.Motor = AccesoDatos.Lector.GetString(5);
                if (!AccesoDatos.Lector.IsDBNull(6))
                    aux.IdCombustible = AccesoDatos.Lector.GetInt32(6);
                if (!AccesoDatos.Lector.IsDBNull(7))
                    aux.IdCajaVeloc = AccesoDatos.Lector.GetInt32(7);
                if (!AccesoDatos.Lector.IsDBNull(8))
                    aux.Velocidades = Convert.ToUInt16(AccesoDatos.Lector[8]);
                if (!AccesoDatos.Lector.IsDBNull(9))
                    aux.IdTipoDireccion = AccesoDatos.Lector.GetInt32(9);
                if (!AccesoDatos.Lector.IsDBNull(10))
                    aux.IdColor = AccesoDatos.Lector.GetInt32(10);
                if (!AccesoDatos.Lector.IsDBNull(11))
                    aux.CantPuertas = Convert.ToUInt16(AccesoDatos.Lector[11]);
                if (!AccesoDatos.Lector.IsDBNull(12))
                    aux.TamañoLlantas = AccesoDatos.Lector.GetString(12);
                if (!AccesoDatos.Lector.IsDBNull(13))
                    aux.CantAirBags = Convert.ToUInt16(AccesoDatos.Lector[13]);
                if (!AccesoDatos.Lector.IsDBNull(14))
                    aux.CamaraRetroceso = AccesoDatos.Lector.GetBoolean(14);
                if (!AccesoDatos.Lector.IsDBNull(15))
                    aux.SensorLLuvia = AccesoDatos.Lector.GetBoolean(15);
                if (!AccesoDatos.Lector.IsDBNull(16))
                    aux.TechoCielo = AccesoDatos.Lector.GetBoolean(16);
                if (!AccesoDatos.Lector.IsDBNull(17))
                    aux.ClimaBiZona = AccesoDatos.Lector.GetBoolean(17);
                if (!AccesoDatos.Lector.IsDBNull(18))
                    aux.LevantaVidrioAutom = AccesoDatos.Lector.GetBoolean(18);
                if (!AccesoDatos.Lector.IsDBNull(19))
                    aux.AudioConectividad = AccesoDatos.Lector.GetString(19);
                if (!AccesoDatos.Lector.IsDBNull(20))
                    aux.CierreCentralizado = AccesoDatos.Lector.GetBoolean(20);
                if (!AccesoDatos.Lector.IsDBNull(21))
                    aux.IdProducto = AccesoDatos.Lector.GetInt32(21);
                else { aux.IdProducto = 0; }

                Autito.Add(aux);
            }

            AccesoDatos.Lector.Close();
            AccesoDatos.Connection.Close();

            for (int i = 0; i < Autito.Count; i++)
            {
                ListBoxAutos.Items.Add(Autito[i].ToString());
            }

            ListBoxAutos.SelectedIndex = 0;
        }

        private void ListBoxAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompletarCampos(ListBoxAutos.SelectedIndex);    //completa los campos del formulario con los datos del automovil correspondiente al indice selecionado en la lista
        }

        private void CompletarCampos(int indice)
        {
            txtCodigo.Text = Autito[indice].Id.ToString();
            cboMarca.SelectedValue = Autito[indice].IdMarca;
            txtModelo.Text = Autito[indice].Modelo;
            numericAño.Value = Autito[indice].Año;
            lblDimenciones_Out.Text = Autito[indice].Dimenciones;   //no se completan los campos de dimenciones x separado por que en la BD se guardan como un solo valor
            txtMotor.Text = Autito[indice].Motor;
            cboCombustible.SelectedValue = Autito[indice].IdCombustible;
            cboCajaVeloc.SelectedValue = Autito[indice].IdCajaVeloc;
            numericVelocidades.Value = Autito[indice].Velocidades;
            cboTipoDirecc.SelectedValue = Autito[indice].IdTipoDireccion;
            cboColor.SelectedValue = Autito[indice].IdColor;
            txtTamLlantas.Text = Autito[indice].TamañoLlantas;
            numericCantAirbag.Value = Autito[indice].CantAirBags;
            if (Autito[indice].CantPuertas == 3)
            {
                checkBoxCantPuertas_3.Checked = true;
            }
            else
            {
                checkBoxCantPuertas_5.Checked = true;
            }

            if (Autito[indice].CamaraRetroceso)
            {
                checkBoxCamRetroceso_Si.Checked = true;
            }
            else
            {
                checkBoxCamRetroceso_No.Checked = true;
            }

            if (Autito[indice].SensorLLuvia)
            {
                checkBoxSensLuvia_Si.Checked = true;
            }
            else
            {
                checkBoxSensLuvia_No.Checked = true;
            }

            if (Autito[indice].TechoCielo)
            {
                checkBoxTechoCielo_Si.Checked = true;
            }
            else
            {
                checkBoxTechoCielo_No.Checked = true;
            }

            if (Autito[indice].ClimaBiZona)
            {
                checkBoxClimatizador_Si.Checked = true;
            }
            else
            {
                checkBoxClimatizador_No.Checked = true;
            }

            if (Autito[indice].LevantaVidrioAutom)
            {
                checkBoxLevantaVidrio_Si.Checked = true;
            }
            else
            {
                checkBoxLevantaVidrio_No.Checked = true;
            }

            if (Autito[indice].CierreCentralizado)
                checkBoxCierreCentral_Si.Checked = true;
            else
                checkBoxCierreCentral_No.Checked = true;

            txtAudioConectividad.Text = Autito[indice].AudioConectividad;
        }

        private void HabilitarBotones(bool x)   // habilita o deshabilita los campos y botones según la operacion que se esté realizando en el Form
        {
            groupBoxCargaAuto.Enabled = x;
            BtnCancelar.Enabled = x;
            BtnGuardar.Enabled = x;

            BtnNuevo.Enabled = !x;
            iconBtnCerrar.Enabled = !x;            
            BtnEditar.Enabled = !x;
            BtnBorrar.Enabled = !x;
            BtnListaCompleta.Enabled = !x;
            lblPulgadasLlantas.Text = "";
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "Autogenerado";
            txtCodigo.Clear();
            cboMarca.SelectedIndex = -1;
            txtModelo.Clear();
            numericAño.Value = 2017;
            lblDimenciones_Out.Text = "";
            txtLargo.Clear();
            txtAncho.Clear();
            txtAlto.Clear();
            txtMotor.Clear();
            cboCombustible.SelectedIndex = -1;
            cboCajaVeloc.SelectedIndex = -1;
            numericVelocidades.Value = 5;
            cboTipoDirecc.SelectedIndex = -1;
            cboColor.SelectedIndex = -1;
            txtTamLlantas.Clear();
            lblPulgadasLlantas.Text = "\"";
            numericCantAirbag.Value = 2;
            checkBoxCantPuertas_3.Checked = false;
            checkBoxCamRetroceso_Si.Checked = false;
            checkBoxSensLuvia_Si.Checked = false;
            checkBoxClimatizador_Si.Checked = false;
            checkBoxLevantaVidrio_Si.Checked = false;
            checkBoxCierreCentral_Si.Checked = false;
            txtAudioConectividad.Clear();
        }       

        private Automovil LevantarValoresDeCampos() // despues de ser validados todos los valores, guarda los datos ingresados en el formulario en un objeto Automovil para usarlos como parametros en las Sentencias SQL posteriormente
        {
            Automovil a = new Automovil();

            if (!NuevoRegistro) // si el registro no es nuevo,levanto el valor del campo Codigo para usarlo como condición en el Where del Update
            {
                a.Id = Convert.ToInt32(txtCodigo.Text);
            }           
            a.IdMarca = Convert.ToInt32(cboMarca.SelectedValue);
            a.Modelo = txtModelo.Text;
            a.Año = Convert.ToInt32(numericAño.Value);
            a.Dimenciones = $"{txtLargo.Text}x{txtAncho.Text}x{txtAlto.Text}mm";
            a.Motor = txtMotor.Text;
            a.IdCombustible = Convert.ToInt32(cboCombustible.SelectedValue);
            a.IdCajaVeloc = Convert.ToInt32(cboCajaVeloc.SelectedValue);
            a.Velocidades = Convert.ToUInt16(numericVelocidades.Value);
            a.IdTipoDireccion = Convert.ToInt32(cboTipoDirecc.SelectedValue);
            a.IdColor = Convert.ToInt32(cboColor.SelectedValue);
            if (checkBoxCantPuertas_3.Checked)
            {
                a.CantPuertas = 3;
            }
            else
            {
                a.CantPuertas = 5;
            }
            a.TamañoLlantas = $"{txtTamLlantas.Text}\"";
            a.CantAirBags = Convert.ToUInt16(numericCantAirbag.Value);
            if (checkBoxCamRetroceso_Si.Checked)
            {
                a.CamaraRetroceso = true;
            }
            else
            {
                a.CamaraRetroceso = false;
            }

            if (checkBoxCantPuertas_3.Checked)
            {
                a.CantPuertas = 3;
            }
            else
            {
                a.CantPuertas = 5;
            }

            if (checkBoxSensLuvia_Si.Checked)
            {
                a.SensorLLuvia = true;
            }
            else
            {
                a.SensorLLuvia = false;
            }

            if (checkBoxSensLuvia_Si.Checked)
            {
                a.SensorLLuvia = true;
            }
            else
            {
                a.SensorLLuvia = false;
            }

            if (checkBoxTechoCielo_Si.Checked)
            {
                a.TechoCielo = true;
            }
            else
            {
                a.TechoCielo = false;
            }

            if (checkBoxClimatizador_Si.Checked)
            {
                a.ClimaBiZona = true;
            }
            else
            {
                a.ClimaBiZona = false;
            }

            if (checkBoxLevantaVidrio_Si.Checked)
            {
                a.LevantaVidrioAutom = true;
            }
            else
            {
                a.LevantaVidrioAutom = false;
            }

            if (checkBoxCierreCentral_Si.Checked)
            {
                a.CierreCentralizado = true;
            }
            else
            {
                a.CierreCentralizado = false;
            }

            a.AudioConectividad = txtAudioConectividad.Text;


            return a;
        }

        private bool ValidarCamposVacios()  //verifica que los campos no esten sin completar y que los valores ingresados sean correctos
        {
            bool salida = false;

            if (cboMarca.SelectedIndex == -1)
            {
                MessageBox.Show("El campo \"Marcas\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMarca.Focus();
            }
            else if (cboCombustible.SelectedIndex == -1)
            {
                MessageBox.Show("El campo \"Combustible\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCombustible.Focus();
            }
            else if (cboTipoDirecc.SelectedIndex == -1)
            {
                MessageBox.Show("El campo \"Tipo de Dirección\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipoDirecc.Focus();
            }
            else if (cboCajaVeloc.SelectedIndex == -1)
            {
                MessageBox.Show("El campo \"Caja de Velocidad\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCajaVeloc.Focus();
            }
            else if (cboColor.SelectedIndex == -1)
            {
                MessageBox.Show("El campo \"Color\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboColor.Focus();
            }
            else if (txtModelo.Text == string.Empty)
            {
                MessageBox.Show("El campo \"Modelo\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelo.Focus();
            }
            else if (txtLargo.Text == string.Empty)
            {
                MessageBox.Show("El campo de \"Dimenciones: Largo\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLargo.Focus();
            }
            else if (!double.TryParse(txtLargo.Text, out validarNumeros))
            {
                MessageBox.Show("El campo de \"Dimenciones: Largo\" contiene un número no válido.\nPara números no enteros utilice puntos(.) o comas(,)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLargo.Focus();
            }
            else if (txtAncho.Text == string.Empty)
            {
                MessageBox.Show("El campo de \"Dimenciones: Ancho\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAncho.Focus();
            }
            else if (!double.TryParse(txtAncho.Text, out validarNumeros))
            {
                MessageBox.Show("El campo de \"Dimenciones: Ancho\" contiene un número no válido.\nPara números no enteros utilice puntos(.) o comas(,)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAncho.Focus();
            }
            else if (txtAlto.Text == string.Empty)
            {
                MessageBox.Show("El campo de \"Dimenciones: Ancho\" esta vacío", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAncho.Focus();
            }
            else if (!double.TryParse(txtAlto.Text, out validarNumeros))
            {
                MessageBox.Show("El campo de \"Dimenciones: Ancho\" contiene un número no válido.\nPara números no enteros utilice puntos(.) o comas(,)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAncho.Focus();
            }
            else if (txtMotor.Text == string.Empty)
            {
                MessageBox.Show("El campo \"Motor\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMotor.Focus();
            }
            else if (!double.TryParse(txtMotor.Text, out validarNumeros))
            {
                MessageBox.Show("El campo \"Motor\" contiene un número no válido.\nPara números no enteros utilice puntos(.) o comas(,)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMotor.Focus();
            }
            else if (txtTamLlantas.Text == string.Empty)
            {
                MessageBox.Show("El campo \"Tamaño de Llantas\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTamLlantas.Focus();
            }
            else if (!double.TryParse(txtTamLlantas.Text, out validarNumeros))
            {
                MessageBox.Show("El campo \"Tamaño de Llantas\" contiene un valor incorrecto.\nPara números no enteros utilice puntos(.) o comas(,).\nSi esta realizando una Edicion, elimine caracteres especiales como comillas(\"). ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTamLlantas.Focus();
            }
            else if (txtAudioConectividad.Text == string.Empty)
            {
                MessageBox.Show("El campo \"Audio y Conectividad\" esta vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAudioConectividad.Focus();
            }
            else
            {
                salida = true;
            }

            return salida;
        }

        private void ValidarSoloNumeros(KeyPressEventArgs e)    //Metodo que solo perimite que se lean por teclado números o puntuaciones y la tecla de borrado
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && !char.IsPunctuation(e.KeyChar))
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

        private void txtLargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtAncho_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtAlto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtMotor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }

        private void txtTamLlantas_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e);
        }       
    }
}
