namespace WFAppTPi_ProgramacionII
{
    partial class FrmReporteAutomoviles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteAutomoviles));
            this.crystalReportAutos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.checkBoxTodo = new System.Windows.Forms.CheckBox();
            this.checkBoxColor = new System.Windows.Forms.CheckBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.checkBoxAño = new System.Windows.Forms.CheckBox();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.checkBoxMarca = new System.Windows.Forms.CheckBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.checkBoxCodigo = new System.Windows.Forms.CheckBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.BtnConsulta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportAutos
            // 
            this.crystalReportAutos.ActiveViewIndex = -1;
            this.crystalReportAutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportAutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportAutos.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportAutos.Location = new System.Drawing.Point(1, 1);
            this.crystalReportAutos.Name = "crystalReportAutos";
            this.crystalReportAutos.ShowCloseButton = false;
            this.crystalReportAutos.ShowGroupTreeButton = false;
            this.crystalReportAutos.ShowParameterPanelButton = false;
            this.crystalReportAutos.Size = new System.Drawing.Size(851, 470);
            this.crystalReportAutos.TabIndex = 1;
            this.crystalReportAutos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // checkBoxTodo
            // 
            this.checkBoxTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxTodo.AutoSize = true;
            this.checkBoxTodo.Location = new System.Drawing.Point(14, 539);
            this.checkBoxTodo.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTodo.Name = "checkBoxTodo";
            this.checkBoxTodo.Size = new System.Drawing.Size(98, 17);
            this.checkBoxTodo.TabIndex = 18;
            this.checkBoxTodo.Text = "Consultar Todo";
            this.checkBoxTodo.UseVisualStyleBackColor = true;
            this.checkBoxTodo.CheckedChanged += new System.EventHandler(this.checkBoxTodo_CheckedChanged);
            // 
            // checkBoxColor
            // 
            this.checkBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxColor.AutoSize = true;
            this.checkBoxColor.Location = new System.Drawing.Point(444, 484);
            this.checkBoxColor.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxColor.Name = "checkBoxColor";
            this.checkBoxColor.Size = new System.Drawing.Size(50, 17);
            this.checkBoxColor.TabIndex = 16;
            this.checkBoxColor.Text = "Color";
            this.checkBoxColor.UseVisualStyleBackColor = true;
            this.checkBoxColor.CheckedChanged += new System.EventHandler(this.checkBoxColor_CheckedChanged);
            // 
            // txtColor
            // 
            this.txtColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtColor.Location = new System.Drawing.Point(444, 505);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(69, 20);
            this.txtColor.TabIndex = 17;
            this.txtColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColor_KeyPress);
            // 
            // checkBoxAño
            // 
            this.checkBoxAño.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAño.AutoSize = true;
            this.checkBoxAño.Location = new System.Drawing.Point(348, 484);
            this.checkBoxAño.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAño.Name = "checkBoxAño";
            this.checkBoxAño.Size = new System.Drawing.Size(45, 17);
            this.checkBoxAño.TabIndex = 14;
            this.checkBoxAño.Text = "Año";
            this.checkBoxAño.UseVisualStyleBackColor = true;
            this.checkBoxAño.CheckedChanged += new System.EventHandler(this.checkBoxAño_CheckedChanged);
            // 
            // txtAño
            // 
            this.txtAño.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAño.Location = new System.Drawing.Point(348, 505);
            this.txtAño.Margin = new System.Windows.Forms.Padding(2);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(69, 20);
            this.txtAño.TabIndex = 15;
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // checkBoxMarca
            // 
            this.checkBoxMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxMarca.AutoSize = true;
            this.checkBoxMarca.Location = new System.Drawing.Point(252, 484);
            this.checkBoxMarca.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMarca.Name = "checkBoxMarca";
            this.checkBoxMarca.Size = new System.Drawing.Size(56, 17);
            this.checkBoxMarca.TabIndex = 12;
            this.checkBoxMarca.Text = "Marca";
            this.checkBoxMarca.UseVisualStyleBackColor = true;
            this.checkBoxMarca.CheckedChanged += new System.EventHandler(this.checkBoxMarca_CheckedChanged);
            // 
            // txtMarca
            // 
            this.txtMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMarca.Location = new System.Drawing.Point(252, 505);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(2);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(69, 20);
            this.txtMarca.TabIndex = 13;
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarca_KeyPress);
            // 
            // checkBoxCodigo
            // 
            this.checkBoxCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCodigo.AutoSize = true;
            this.checkBoxCodigo.Location = new System.Drawing.Point(156, 484);
            this.checkBoxCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxCodigo.Name = "checkBoxCodigo";
            this.checkBoxCodigo.Size = new System.Drawing.Size(59, 17);
            this.checkBoxCodigo.TabIndex = 10;
            this.checkBoxCodigo.Text = "Codigo";
            this.checkBoxCodigo.UseVisualStyleBackColor = true;
            this.checkBoxCodigo.CheckedChanged += new System.EventHandler(this.checkBoxCodigo_CheckedChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodigo.Location = new System.Drawing.Point(156, 505);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(69, 20);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // BtnConsulta
            // 
            this.BtnConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsulta.Image = ((System.Drawing.Image)(resources.GetObject("BtnConsulta.Image")));
            this.BtnConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConsulta.Location = new System.Drawing.Point(12, 484);
            this.BtnConsulta.Name = "BtnConsulta";
            this.BtnConsulta.Padding = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.BtnConsulta.Size = new System.Drawing.Size(130, 41);
            this.BtnConsulta.TabIndex = 19;
            this.BtnConsulta.Text = "Consultar con Filtros";
            this.BtnConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConsulta.UseVisualStyleBackColor = true;
            this.BtnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // FrmReporteAutomoviles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(852, 563);
            this.Controls.Add(this.checkBoxTodo);
            this.Controls.Add(this.checkBoxColor);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.checkBoxAño);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.checkBoxMarca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.checkBoxCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.BtnConsulta);
            this.Controls.Add(this.crystalReportAutos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteAutomoviles";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Reporte Automoviles";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReporteAutomoviles_FormClosed);
            this.Load += new System.EventHandler(this.FrmReporteAutomoviles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportAutos;
        private System.Windows.Forms.CheckBox checkBoxTodo;
        private System.Windows.Forms.CheckBox checkBoxColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.CheckBox checkBoxAño;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.CheckBox checkBoxMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.CheckBox checkBoxCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button BtnConsulta;
    }
}