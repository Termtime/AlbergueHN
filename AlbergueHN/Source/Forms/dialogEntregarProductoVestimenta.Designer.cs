namespace AlbergueHN.Source.Forms
{
    partial class dialogEntregarProductoVestimenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dialogEntregarProductoVestimenta));
            this.tablaDespacho = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.comboPersonas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.panelControlRopa = new System.Windows.Forms.Panel();
            this.comboTalla = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTalla = new System.Windows.Forms.Label();
            this.radioCualquiera = new System.Windows.Forms.RadioButton();
            this.radioFemenino = new System.Windows.Forms.RadioButton();
            this.radioMasculino = new System.Windows.Forms.RadioButton();
            this.btnDespachar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.usuarioID = new System.Windows.Forms.Label();
            this.listaProductos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDespacho)).BeginInit();
            this.panelControlRopa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaDespacho
            // 
            this.tablaDespacho.AllowUserToAddRows = false;
            this.tablaDespacho.AllowUserToResizeColumns = false;
            this.tablaDespacho.AllowUserToResizeRows = false;
            this.tablaDespacho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaDespacho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaDespacho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDespacho.Location = new System.Drawing.Point(725, 15);
            this.tablaDespacho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tablaDespacho.Name = "tablaDespacho";
            this.tablaDespacho.RowHeadersWidth = 51;
            this.tablaDespacho.Size = new System.Drawing.Size(963, 810);
            this.tablaDespacho.TabIndex = 0;
            this.tablaDespacho.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.tablaDespacho_CellValidating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(554, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 75;
            this.label7.Text = "Usuario actual:";
            // 
            // comboPersonas
            // 
            this.comboPersonas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.comboPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPersonas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPersonas.FormattingEnabled = true;
            this.comboPersonas.Location = new System.Drawing.Point(155, 127);
            this.comboPersonas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboPersonas.Name = "comboPersonas";
            this.comboPersonas.Size = new System.Drawing.Size(532, 28);
            this.comboPersonas.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 77;
            this.label2.Text = "A nombre de:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltro.Location = new System.Drawing.Point(34, 191);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltro.Multiline = true;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(347, 20);
            this.txtFiltro.TabIndex = 80;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged_1);
            // 
            // panelControlRopa
            // 
            this.panelControlRopa.Controls.Add(this.comboTalla);
            this.panelControlRopa.Controls.Add(this.label4);
            this.panelControlRopa.Controls.Add(this.labelTalla);
            this.panelControlRopa.Controls.Add(this.radioCualquiera);
            this.panelControlRopa.Controls.Add(this.radioFemenino);
            this.panelControlRopa.Controls.Add(this.radioMasculino);
            this.panelControlRopa.Location = new System.Drawing.Point(438, 170);
            this.panelControlRopa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControlRopa.Name = "panelControlRopa";
            this.panelControlRopa.Size = new System.Drawing.Size(281, 79);
            this.panelControlRopa.TabIndex = 81;
            // 
            // comboTalla
            // 
            this.comboTalla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.comboTalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboTalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTalla.FormattingEnabled = true;
            this.comboTalla.Location = new System.Drawing.Point(85, 6);
            this.comboTalla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboTalla.Name = "comboTalla";
            this.comboTalla.Size = new System.Drawing.Size(161, 28);
            this.comboTalla.TabIndex = 43;
            this.comboTalla.SelectedIndexChanged += new System.EventHandler(this.comboTalla_SelectedIndexChanged);
            this.comboTalla.TextChanged += new System.EventHandler(this.ComboTalla_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "Genero:";
            // 
            // labelTalla
            // 
            this.labelTalla.AutoSize = true;
            this.labelTalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTalla.Location = new System.Drawing.Point(21, 13);
            this.labelTalla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTalla.Name = "labelTalla";
            this.labelTalla.Size = new System.Drawing.Size(50, 20);
            this.labelTalla.TabIndex = 42;
            this.labelTalla.Text = "Talla:";
            // 
            // radioCualquiera
            // 
            this.radioCualquiera.AutoSize = true;
            this.radioCualquiera.Checked = true;
            this.radioCualquiera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCualquiera.Location = new System.Drawing.Point(85, 51);
            this.radioCualquiera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioCualquiera.Name = "radioCualquiera";
            this.radioCualquiera.Size = new System.Drawing.Size(58, 24);
            this.radioCualquiera.TabIndex = 48;
            this.radioCualquiera.TabStop = true;
            this.radioCualquiera.Text = "N/A";
            this.radioCualquiera.UseVisualStyleBackColor = true;
            this.radioCualquiera.CheckedChanged += new System.EventHandler(this.radioCualquiera_CheckedChanged);
            // 
            // radioFemenino
            // 
            this.radioFemenino.AutoSize = true;
            this.radioFemenino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFemenino.Location = new System.Drawing.Point(203, 51);
            this.radioFemenino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioFemenino.Name = "radioFemenino";
            this.radioFemenino.Size = new System.Drawing.Size(40, 24);
            this.radioFemenino.TabIndex = 47;
            this.radioFemenino.TabStop = true;
            this.radioFemenino.Text = "F";
            this.radioFemenino.UseVisualStyleBackColor = true;
            this.radioFemenino.CheckedChanged += new System.EventHandler(this.radioFemenino_CheckedChanged);
            // 
            // radioMasculino
            // 
            this.radioMasculino.AutoSize = true;
            this.radioMasculino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMasculino.Location = new System.Drawing.Point(151, 51);
            this.radioMasculino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioMasculino.Name = "radioMasculino";
            this.radioMasculino.Size = new System.Drawing.Size(44, 24);
            this.radioMasculino.TabIndex = 46;
            this.radioMasculino.TabStop = true;
            this.radioMasculino.Text = "M";
            this.radioMasculino.UseVisualStyleBackColor = true;
            this.radioMasculino.CheckedChanged += new System.EventHandler(this.radioMasculino_CheckedChanged);
            // 
            // btnDespachar
            // 
            this.btnDespachar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDespachar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDespachar.Location = new System.Drawing.Point(100, 784);
            this.btnDespachar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDespachar.Name = "btnDespachar";
            this.btnDespachar.Size = new System.Drawing.Size(309, 50);
            this.btnDespachar.TabIndex = 83;
            this.btnDespachar.Text = "Terminar y despachar";
            this.btnDespachar.UseVisualStyleBackColor = true;
            this.btnDespachar.Click += new System.EventHandler(this.btnDespachar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(441, 784);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(201, 50);
            this.btnLimpiar.TabIndex = 84;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(16, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(699, 2);
            this.label5.TabIndex = 85;
            // 
            // usuarioID
            // 
            this.usuarioID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioID.Location = new System.Drawing.Point(557, 58);
            this.usuarioID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usuarioID.Name = "usuarioID";
            this.usuarioID.Size = new System.Drawing.Size(168, 25);
            this.usuarioID.TabIndex = 86;
            this.usuarioID.Text = "label6";
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
            this.listaProductos.Location = new System.Drawing.Point(22, 261);
            this.listaProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listaProductos.Name = "listaProductos";
            this.listaProductos.Size = new System.Drawing.Size(697, 515);
            this.listaProductos.TabIndex = 2;
            this.listaProductos.UseCompatibleStateImageBehavior = false;
            this.listaProductos.View = System.Windows.Forms.View.Details;
            this.listaProductos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listaProdcutos_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Descripcion";
            this.columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Existencia";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Talla";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tipo";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Genero";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(125, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(418, 55);
            this.label6.TabIndex = 88;
            this.label6.Text = "Despachar Vestimenta";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AlbergueHN.Properties.Resources.noun_Clothes;
            this.pictureBox1.Location = new System.Drawing.Point(18, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 89;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.panel3.Location = new System.Drawing.Point(32, 213);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 2);
            this.panel3.TabIndex = 91;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AlbergueHN.Properties.Resources.noun_Search_1451786;
            this.pictureBox2.Location = new System.Drawing.Point(387, 178);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 92;
            this.pictureBox2.TabStop = false;
            // 
            // dialogEntregarProductoVestimenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1701, 849);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listaProductos);
            this.Controls.Add(this.usuarioID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnDespachar);
            this.Controls.Add(this.panelControlRopa);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboPersonas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tablaDespacho);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "dialogEntregarProductoVestimenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despachar Vestimenta";
            this.Load += new System.EventHandler(this.dialogEntregarProductoVestimenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDespacho)).EndInit();
            this.panelControlRopa.ResumeLayout(false);
            this.panelControlRopa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaDespacho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboPersonas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Panel panelControlRopa;
        private System.Windows.Forms.ComboBox comboTalla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTalla;
        private System.Windows.Forms.RadioButton radioCualquiera;
        private System.Windows.Forms.RadioButton radioFemenino;
        private System.Windows.Forms.RadioButton radioMasculino;
        private System.Windows.Forms.Button btnDespachar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label usuarioID;
        private System.Windows.Forms.ListView listaProductos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}