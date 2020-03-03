using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;   //mover ventana desde el panel superior
using FontAwesome.Sharp; //para poder interactuar con las propiedades de los objetos fuera del diseñador

namespace WFAppTPi_ProgramacionII
{
    //iconos de botonesdel paquete NuGet: FontAwesome.Sharp
    public partial class FrmMenu : Form
    {
        private Form activeForm = null; //formulario hijo que se encuentra abierto en este menú
        private IconButton currentBtn;  //var aux que guarda el boton que se va a modificar
        private Panel borderBtn;    //pequeño panel que resaltara el borde izquierdo del boton

        static private bool FormChildClosed = false;    //valor que verifica que el formulario hijo se haya cerrado antes de abrir otro formulario

        static public bool FrmChildClosed
        {
            get { return FormChildClosed; }
            set { FormChildClosed = value; }
        }
        public FrmMenu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;  //para que el maximizado no acupe la pantalla completa, sino solo el escritorio
            borderBtn = new Panel();
            borderBtn.Size = new Size(7,40);
            PanelMenuExpandido.Controls.Add(borderBtn);
            timerReloj.Enabled = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]    //librerias del sistema para mover ventana desde el panel superior
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void PanelBarraSuperior_MouseDown(object sender, MouseEventArgs e) //mover ventana desde el panel superior
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Expandir_Contraer_Menu();
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(237, 232, 145);
            public static Color color2 = Color.FromArgb(222, 177, 162);
            //...
        }

        //
        #region Interfaz superior de la ventana 
        private void iconBtnDesplegarMenu_Click(object sender, EventArgs e)
        {
            Expandir_Contraer_Menu();
        }

        private void Expandir_Contraer_Menu()
        {
            if (PanelMenuVertical.Width == 190)
            {
                PanelMenuVertical.Width = 58;
                iconLogoPrincipal.Visible = false;
                iconConfiguration.Visible = true;
                PanelLogos_Menu.Height = 70;
                PanelMenuExpandido.Visible = false;
                PanelMenuContraido.Visible = true;      
            }
            else
            {
                PanelMenuVertical.Width = 190;
                iconConfiguration.Visible = false;
                iconLogoPrincipal.Visible = true;
                PanelLogos_Menu.Height = 105;
                PanelMenuContraido.Visible = false;
                PanelMenuExpandido.Visible = true;
            }

            OcultarSubmenu();
        }

        private void iconBtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconBtnMax_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            iconBtnMax.Visible = false;
            iconBtnRes.Visible = true;
        }

        private void iconBtnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconBtnRes_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            iconBtnMax.Visible = true;
            iconBtnRes.Visible = false;
        }
        #endregion        

        //
        #region Botones del Menu y Submenu Vertical
        private void OcultarSubmenu()   //oculta los paneles de todos los submenus
        {
            if (PanelSubMenuArchivo.Visible)
            {
                PanelSubMenuArchivo.Visible = false;
            }

            if (PanelSubMenuReportes.Visible)
            {
                PanelSubMenuReportes.Visible = false;
            }
        }

        private void MostrarSubMenu(Panel subMenu, object senderBtn, Color RGBcolor)    //oculta los demas submenus y muestra el del boton correspondiente, si ya esta visible, lo oculta
        {
            if (!subMenu.Visible)
            {
                OcultarSubmenu();
                ResaltarBoton(senderBtn, RGBcolor);
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
                RestaurarBoton();
            }
                
                
        }
        //ReDiseño de los botones seleccionados
        private void ResaltarBoton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                RestaurarBoton(); //restaura el boton anterior y resalta el presionado
                currentBtn = (IconButton)senderBtn; //conversion
                currentBtn.BackColor = Color.FromArgb(21, 25, 66);
                currentBtn.ForeColor = color; //color de fuente
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                currentBtn.IconSize = 36;

                borderBtn.BackColor = color;
                borderBtn.Location = new Point(0, currentBtn.Location.Y);
                borderBtn.Visible = true;
                borderBtn.BringToFront();
            }
        }
        private void RestaurarBoton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(11, 7, 17);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconSize = 32;
                borderBtn.Visible = false;
            }
        }

        //Botones del Menu Expandido
        private void btnArchivo_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(PanelSubMenuArchivo, sender, RGBColors.color1);
        }

        private void btnCargarAuto_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmABMAutomovil());
            OcultarSubmenu();
        }

        private void btnAutopartes_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(PanelSubMenuReportes, sender, RGBColors.color2); 
        }

        private void btnReportesAutomoviles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmReporteAutomoviles());
            OcultarSubmenu();
        }

        private void btnReportesAutopartes_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ayuda", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        //Botones del Menu Contraido
        private void btnArchivo2_Click(object sender, EventArgs e)
        {
            Expandir_Contraer_Menu();
            btnArchivo_Click(btnArchivo, e);
        }

        private void btnReportes2_Click(object sender, EventArgs e)
        {
            Expandir_Contraer_Menu();
            btnReportes_Click(btnReportes, e);
        }

        private void btnAyuda2_Click(object sender, EventArgs e)
        {
            btnAyuda_Click(null, e);
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            btnSalir_Click(null, e);
        }
    #endregion

        private void OpenChildForm(Form childForm)    //verifica si ya hay formularios hijos abiertos y los cierra antes de abrir otro
        {
            if (activeForm != null)
            {
                activeForm.Close();

                if (FormChildClosed)
                {
                    OpenForm(childForm);

                    FormChildClosed = false;
                }
            }
            else
            {
                OpenForm(childForm);
            }
        }

        private void OpenForm(Form childForm)   //contiene el codigo necesario para abrir un formulario hijo
        {
            activeForm = childForm;
            childForm.TopLevel = false; //indica que no es un formulario de nivel superior, sino uno secundario, y se comportara igual que un control            
            childForm.Dock = DockStyle.Fill; //acopla el contenido del form al panel contedor
            this.PanelContenedor.Controls.Add(childForm); //agrega el form a la lista de controles del panel Contenedor
            this.PanelContenedor.Tag = childForm; //asociamos el form con el panel
            childForm.BringToFront();  //para aparecer por delante del logo de fondo del panel
            childForm.Show();
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            //lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerReloj.Stop(); // .Enabled = false;
        }
    }
}
 