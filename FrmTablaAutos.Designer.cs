namespace WFAppTPi_ProgramacionII
{
    partial class FrmTablaAutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTablaAutos));
            this.dataGridAuto = new System.Windows.Forms.DataGridView();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.checkBoxCodigo = new System.Windows.Forms.CheckBox();
            this.checkBoxMarca = new System.Windows.Forms.CheckBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.checkBoxAño = new System.Windows.Forms.CheckBox();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.checkBoxColor = new System.Windows.Forms.CheckBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.checkBoxTodo = new System.Windows.Forms.CheckBox();
            this.BtnConsulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAuto)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridAuto
            // 
            this.dataGridAuto.AllowUserToAddRows = false;
            this.dataGridAuto.AllowUserToDeleteRows = false;
            this.dataGridAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridAuto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridAuto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridAuto.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridAuto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAuto.Location = new System.Drawing.Point(0, 1);
            this.dataGridAuto.Name = "dataGridAuto";
            this.dataGridAuto.ReadOnly = true;
            this.dataGridAuto.RowHeadersWidth = 62;
            this.dataGridAuto.Size = new System.Drawing.Size(592, 276);
            this.dataGridAuto.TabIndex = 10;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodigo.Location = new System.Drawing.Point(157, 307);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(69, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // checkBoxCodigo
            // 
            this.checkBoxCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCodigo.AutoSize = true;
            this.checkBoxCodigo.Location = new System.Drawing.Point(157, 284);
            this.checkBoxCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxCodigo.Name = "checkBoxCodigo";
            this.checkBoxCodigo.Size = new System.Drawing.Size(59, 17);
            this.checkBoxCodigo.TabIndex = 0;
            this.checkBoxCodigo.Text = "Codigo";
            this.checkBoxCodigo.UseVisualStyleBackColor = true;
            this.checkBoxCodigo.CheckedChanged += new System.EventHandler(this.checkBoxCodigo_CheckedChanged);
            // 
            // checkBoxMarca
            // 
            this.checkBoxMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxMarca.AutoSize = true;
            this.checkBoxMarca.Location = new System.Drawing.Point(253, 284);
            this.checkBoxMarca.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMarca.Name = "checkBoxMarca";
            this.checkBoxMarca.Size = new System.Drawing.Size(56, 17);
            this.checkBoxMarca.TabIndex = 2;
            this.checkBoxMarca.Text = "Marca";
            this.checkBoxMarca.UseVisualStyleBackColor = true;
            this.checkBoxMarca.CheckedChanged += new System.EventHandler(this.checkBoxMarca_CheckedChanged);
            // 
            // txtMarca
            // 
            this.txtMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMarca.Location = new System.Drawing.Point(253, 307);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(2);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(69, 20);
            this.txtMarca.TabIndex = 3;
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarca_KeyPress);
            // 
            // checkBoxAño
            // 
            this.checkBoxAño.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAño.AutoSize = true;
            this.checkBoxAño.Location = new System.Drawing.Point(349, 284);
            this.checkBoxAño.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAño.Name = "checkBoxAño";
            this.checkBoxAño.Size = new System.Drawing.Size(45, 17);
            this.checkBoxAño.TabIndex = 4;
            this.checkBoxAño.Text = "Año";
            this.checkBoxAño.UseVisualStyleBackColor = true;
            this.checkBoxAño.CheckedChanged += new System.EventHandler(this.checkBoxAño_CheckedChanged);
            // 
            // txtAño
            // 
            this.txtAño.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAño.Location = new System.Drawing.Point(349, 307);
            this.txtAño.Margin = new System.Windows.Forms.Padding(2);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(69, 20);
            this.txtAño.TabIndex = 5;
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // checkBoxColor
            // 
            this.checkBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxColor.AutoSize = true;
            this.checkBoxColor.Location = new System.Drawing.Point(445, 284);
            this.checkBoxColor.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxColor.Name = "checkBoxColor";
            this.checkBoxColor.Size = new System.Drawing.Size(50, 17);
            this.checkBoxColor.TabIndex = 6;
            this.checkBoxColor.Text = "Color";
            this.checkBoxColor.UseVisualStyleBackColor = true;
            this.checkBoxColor.CheckedChanged += new System.EventHandler(this.checkBoxColor_CheckedChanged);
            // 
            // txtColor
            // 
            this.txtColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtColor.Location = new System.Drawing.Point(445, 307);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(69, 20);
            this.txtColor.TabIndex = 7;
            this.txtColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColor_KeyPress);
            // 
            // checkBoxTodo
            // 
            this.checkBoxTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxTodo.AutoSize = true;
            this.checkBoxTodo.Location = new System.Drawing.Point(14, 335);
            this.checkBoxTodo.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTodo.Name = "checkBoxTodo";
            this.checkBoxTodo.Size = new System.Drawing.Size(98, 17);
            this.checkBoxTodo.TabIndex = 8;
            this.checkBoxTodo.Text = "Consultar Todo";
            this.checkBoxTodo.UseVisualStyleBackColor = true;
            this.checkBoxTodo.CheckedChanged += new System.EventHandler(this.checkBoxTodo_CheckedChanged);
            // 
            // BtnConsulta
            // 
            this.BtnConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsulta.Image = ((System.Drawing.Image)(resources.GetObject("BtnConsulta.Image")));
            this.BtnConsulta.Location = new System.Drawing.Point(12, 286);
            this.BtnConsulta.Name = "BtnConsulta";
            this.BtnConsulta.Padding = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.BtnConsulta.Size = new System.Drawing.Size(130, 41);
            this.BtnConsulta.TabIndex = 9;
            this.BtnConsulta.Text = "Consultar con Filtros";
            this.BtnConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConsulta.UseVisualStyleBackColor = true;
            this.BtnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // FrmTablaAutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 358);
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
            this.Controls.Add(this.dataGridAuto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTablaAutos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla Autos";
            this.Load += new System.EventHandler(this.FrmTablaAutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAuto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridAuto;
        private System.Windows.Forms.Button BtnConsulta;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.CheckBox checkBoxCodigo;
        private System.Windows.Forms.CheckBox checkBoxMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.CheckBox checkBoxAño;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.CheckBox checkBoxColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.CheckBox checkBoxTodo;
    }
}