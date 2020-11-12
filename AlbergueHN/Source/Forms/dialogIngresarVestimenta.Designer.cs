namespace AlbergueHN.Source.Forms
{
    partial class dialogIngresarVestimenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dialogIngresarVestimenta));
            this.tablaIngreso = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDonante = new System.Windows.Forms.TextBox();
            this.nuevo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.panelControlRopa = new System.Windows.Forms.Panel();
            this.comboTalla = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTalla = new System.Windows.Forms.Label();
            this.radioCualquiera = new System.Windows.Forms.RadioButton();
            this.radioFemenino = new System.Windows.Forms.RadioButton();
            this.radioMasculino = new System.Windows.Forms.RadioButton();
            this.listaProductos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaIngreso)).BeginInit();
            this.panelControlRopa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaIngreso
            // 
            this.tablaIngreso.AllowUserToAddRows = false;
            this.tablaIngreso.AllowUserToResizeColumns = false;
            this.tablaIngreso.AllowUserToResizeRows = false;
            this.tablaIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaIngreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaIngreso.Location = new System.Drawing.Point(542, 20);
            this.tablaIngreso.Name = "tablaIngreso";
            this.tablaIngreso.RowHeadersWidth = 62;
            this.tablaIngreso.Size = new System.Drawing.Size(722, 645);
            this.tablaIngreso.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 42);
            this.label1.TabIndex = 53;
            this.label1.Text = "Ingreso Vestimenta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Donante:";
            // 
            // txtDonante
            // 
            this.txtDonante.Location = new System.Drawing.Point(69, 78);
            this.txtDonante.MaxLength = 50;
            this.txtDonante.Name = "txtDonante";
            this.txtDonante.Size = new System.Drawing.Size(232, 20);
            this.txtDonante.TabIndex = 62;
            // 
            // nuevo
            // 
            this.nuevo.Location = new System.Drawing.Point(336, 76);
            this.nuevo.Margin = new System.Windows.Forms.Padding(2);
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(112, 23);
            this.nuevo.TabIndex = 67;
            this.nuevo.Text = "Crear nuevo artículo";
            this.nuevo.UseVisualStyleBackColor = true;
            this.nuevo.Click += new System.EventHandler(this.nuevo_Click_1);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(15, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(522, 2);
            this.label5.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Buscar:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(69, 141);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(232, 20);
            this.txtFiltro.TabIndex = 70;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // panelControlRopa
            // 
            this.panelControlRopa.Controls.Add(this.comboTalla);
            this.panelControlRopa.Controls.Add(this.label4);
            this.panelControlRopa.Controls.Add(this.labelTalla);
            this.panelControlRopa.Controls.Add(this.radioCualquiera);
            this.panelControlRopa.Controls.Add(this.radioFemenino);
            this.panelControlRopa.Controls.Add(this.radioMasculino);
            this.panelControlRopa.Location = new System.Drawing.Point(336, 130);
            this.panelControlRopa.Name = "panelControlRopa";
            this.panelControlRopa.Size = new System.Drawing.Size(200, 56);
            this.panelControlRopa.TabIndex = 71;
            // 
            // comboTalla
            // 
            this.comboTalla.FormattingEnabled = true;
            this.comboTalla.Location = new System.Drawing.Point(67, 8);
            this.comboTalla.MaxLength = 5;
            this.comboTalla.Name = "comboTalla";
            this.comboTalla.Size = new System.Drawing.Size(122, 21);
            this.comboTalla.TabIndex = 43;
            this.comboTalla.SelectedIndexChanged += new System.EventHandler(this.comboTalla_SelectedIndexChanged);
            this.comboTalla.TextChanged += new System.EventHandler(this.ComboTalla_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Genero:";
            // 
            // labelTalla
            // 
            this.labelTalla.AutoSize = true;
            this.labelTalla.Location = new System.Drawing.Point(28, 11);
            this.labelTalla.Name = "labelTalla";
            this.labelTalla.Size = new System.Drawing.Size(33, 13);
            this.labelTalla.TabIndex = 42;
            this.labelTalla.Text = "Talla:";
            // 
            // radioCualquiera
            // 
            this.radioCualquiera.AutoSize = true;
            this.radioCualquiera.Checked = true;
            this.radioCualquiera.Location = new System.Drawing.Point(67, 30);
            this.radioCualquiera.Name = "radioCualquiera";
            this.radioCualquiera.Size = new System.Drawing.Size(45, 17);
            this.radioCualquiera.TabIndex = 48;
            this.radioCualquiera.TabStop = true;
            this.radioCualquiera.Text = "N/A";
            this.radioCualquiera.UseVisualStyleBackColor = true;
            this.radioCualquiera.CheckedChanged += new System.EventHandler(this.radioCualquiera_CheckedChanged_1);
            // 
            // radioFemenino
            // 
            this.radioFemenino.AutoSize = true;
            this.radioFemenino.Location = new System.Drawing.Point(158, 30);
            this.radioFemenino.Name = "radioFemenino";
            this.radioFemenino.Size = new System.Drawing.Size(31, 17);
            this.radioFemenino.TabIndex = 47;
            this.radioFemenino.Text = "F";
            this.radioFemenino.UseVisualStyleBackColor = true;
            this.radioFemenino.CheckedChanged += new System.EventHandler(this.radioFemenino_CheckedChanged);
            // 
            // radioMasculino
            // 
            this.radioMasculino.AutoSize = true;
            this.radioMasculino.Location = new System.Drawing.Point(118, 30);
            this.radioMasculino.Name = "radioMasculino";
            this.radioMasculino.Size = new System.Drawing.Size(34, 17);
            this.radioMasculino.TabIndex = 46;
            this.radioMasculino.Text = "M";
            this.radioMasculino.UseVisualStyleBackColor = true;
            this.radioMasculino.CheckedChanged += new System.EventHandler(this.radioMasculino_CheckedChanged);
            // 
            // listaProductos
            // 
            this.listaProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listaProductos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listaProductos.FullRowSelect = true;
            this.listaProductos.HideSelection = false;
            this.listaProductos.Location = new System.Drawing.Point(12, 196);
            this.listaProductos.MultiSelect = false;
            this.listaProductos.Name = "listaProductos";
            this.listaProductos.Size = new System.Drawing.Size(524, 441);
            this.listaProductos.TabIndex = 72;
            this.listaProductos.UseCompatibleStateImageBehavior = false;
            this.listaProductos.View = System.Windows.Forms.View.Details;
            this.listaProductos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listaProductos_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Descripcion";
            this.columnHeader1.Width = 257;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Existencia";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tipo";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Talla";
            this.columnHeader4.Width = 36;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Genero";
            this.columnHeader5.Width = 47;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(84, 643);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(209, 41);
            this.btnIngresar.TabIndex = 73;
            this.btnIngresar.Text = "Terminar e ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(299, 643);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(151, 41);
            this.btnLimpiar.TabIndex = 74;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AlbergueHN.Properties.Resources.blouse;
            this.pictureBox2.Location = new System.Drawing.Point(32, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 88;
            this.pictureBox2.TabStop = false;
            // 
            // dialogIngresarVestimenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 690);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.listaProductos);
            this.Controls.Add(this.panelControlRopa);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nuevo);
            this.Controls.Add(this.txtDonante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablaIngreso);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dialogIngresarVestimenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Vestimenta";
            this.Load += new System.EventHandler(this.dialogIngresarVestimenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaIngreso)).EndInit();
            this.panelControlRopa.ResumeLayout(false);
            this.panelControlRopa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaIngreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDonante;
        private System.Windows.Forms.Button nuevo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Panel panelControlRopa;
        private System.Windows.Forms.ComboBox comboTalla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTalla;
        private System.Windows.Forms.RadioButton radioCualquiera;
        private System.Windows.Forms.RadioButton radioFemenino;
        private System.Windows.Forms.RadioButton radioMasculino;
        private System.Windows.Forms.ListView listaProductos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}