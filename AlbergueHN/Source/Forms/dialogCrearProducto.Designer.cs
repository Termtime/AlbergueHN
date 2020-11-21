namespace AlbergueHN.Source.Forms
{
    partial class dialogCrearProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dialogCrearProducto));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboGen = new System.Windows.Forms.ComboBox();
            this.comboTalla = new System.Windows.Forms.ComboBox();
            this.checkUsaTalla = new System.Windows.Forms.CheckBox();
            this.checkUsaGenero = new System.Windows.Forms.CheckBox();
            this.radioCualquiera = new System.Windows.Forms.RadioButton();
            this.radioInfante = new System.Windows.Forms.RadioButton();
            this.radioAdulto = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(446, 444);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 42);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(154)))), ((int)(((byte)(191)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(154)))), ((int)(((byte)(191)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAgregar.Location = new System.Drawing.Point(309, 444);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(114, 42);
            this.btnAgregar.TabIndex = 50;
            this.btnAgregar.Text = "Crear";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // comboTipo
            // 
            this.comboTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.comboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(7, 130);
            this.comboTipo.Margin = new System.Windows.Forms.Padding(4);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(160, 28);
            this.comboTipo.TabIndex = 0;
            this.comboTipo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboTipo_DrawItem);
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.TipoArticulo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.label4.Location = new System.Drawing.Point(3, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(3, 172);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.label1.Location = new System.Drawing.Point(3, 235);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Talla:";
            // 
            // txtArticulo
            // 
            this.txtArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.txtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArticulo.Location = new System.Drawing.Point(7, 194);
            this.txtArticulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtArticulo.MaxLength = 39;
            this.txtArticulo.Multiline = true;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(474, 22);
            this.txtArticulo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.label3.Location = new System.Drawing.Point(3, 301);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Genero:";
            // 
            // comboGen
            // 
            this.comboGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.comboGen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGen.Enabled = false;
            this.comboGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGen.FormattingEnabled = true;
            this.comboGen.Location = new System.Drawing.Point(7, 323);
            this.comboGen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboGen.Name = "comboGen";
            this.comboGen.Size = new System.Drawing.Size(108, 28);
            this.comboGen.TabIndex = 4;
            this.comboGen.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboGen_DrawItem);
            // 
            // comboTalla
            // 
            this.comboTalla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.comboTalla.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboTalla.Enabled = false;
            this.comboTalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboTalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTalla.FormattingEnabled = true;
            this.comboTalla.Location = new System.Drawing.Point(7, 259);
            this.comboTalla.Margin = new System.Windows.Forms.Padding(4);
            this.comboTalla.Name = "comboTalla";
            this.comboTalla.Size = new System.Drawing.Size(160, 28);
            this.comboTalla.TabIndex = 56;
            this.comboTalla.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboTalla_DrawItem);
            // 
            // checkUsaTalla
            // 
            this.checkUsaTalla.AutoSize = true;
            this.checkUsaTalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUsaTalla.Location = new System.Drawing.Point(175, 263);
            this.checkUsaTalla.Margin = new System.Windows.Forms.Padding(4);
            this.checkUsaTalla.Name = "checkUsaTalla";
            this.checkUsaTalla.Size = new System.Drawing.Size(116, 24);
            this.checkUsaTalla.TabIndex = 57;
            this.checkUsaTalla.Text = "¿Usa talla?";
            this.checkUsaTalla.UseVisualStyleBackColor = true;
            this.checkUsaTalla.CheckedChanged += new System.EventHandler(this.CheckUsaTalla_CheckedChanged);
            // 
            // checkUsaGenero
            // 
            this.checkUsaGenero.AutoSize = true;
            this.checkUsaGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUsaGenero.Location = new System.Drawing.Point(122, 327);
            this.checkUsaGenero.Margin = new System.Windows.Forms.Padding(4);
            this.checkUsaGenero.Name = "checkUsaGenero";
            this.checkUsaGenero.Size = new System.Drawing.Size(136, 24);
            this.checkUsaGenero.TabIndex = 58;
            this.checkUsaGenero.Text = "¿Usa genero?";
            this.checkUsaGenero.UseVisualStyleBackColor = true;
            this.checkUsaGenero.CheckedChanged += new System.EventHandler(this.CheckUsaGenero_CheckedChanged);
            // 
            // radioCualquiera
            // 
            this.radioCualquiera.AutoSize = true;
            this.radioCualquiera.Checked = true;
            this.radioCualquiera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCualquiera.Location = new System.Drawing.Point(7, 387);
            this.radioCualquiera.Margin = new System.Windows.Forms.Padding(4);
            this.radioCualquiera.Name = "radioCualquiera";
            this.radioCualquiera.Size = new System.Drawing.Size(58, 24);
            this.radioCualquiera.TabIndex = 59;
            this.radioCualquiera.TabStop = true;
            this.radioCualquiera.Text = "N/A";
            this.radioCualquiera.UseVisualStyleBackColor = true;
            // 
            // radioInfante
            // 
            this.radioInfante.AutoSize = true;
            this.radioInfante.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInfante.Location = new System.Drawing.Point(76, 387);
            this.radioInfante.Margin = new System.Windows.Forms.Padding(4);
            this.radioInfante.Name = "radioInfante";
            this.radioInfante.Size = new System.Drawing.Size(80, 24);
            this.radioInfante.TabIndex = 60;
            this.radioInfante.TabStop = true;
            this.radioInfante.Text = "Infante";
            this.radioInfante.UseVisualStyleBackColor = true;
            // 
            // radioAdulto
            // 
            this.radioAdulto.AutoSize = true;
            this.radioAdulto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAdulto.Location = new System.Drawing.Point(168, 387);
            this.radioAdulto.Margin = new System.Windows.Forms.Padding(4);
            this.radioAdulto.Name = "radioAdulto";
            this.radioAdulto.Size = new System.Drawing.Size(77, 24);
            this.radioAdulto.TabIndex = 61;
            this.radioAdulto.TabStop = true;
            this.radioAdulto.Text = "Adulto";
            this.radioAdulto.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.label5.Location = new System.Drawing.Point(3, 363);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "Rango Edad:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(116)))), ((int)(((byte)(155)))));
            this.panel3.Location = new System.Drawing.Point(7, 218);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(473, 2);
            this.panel3.TabIndex = 90;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(176, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 55);
            this.label6.TabIndex = 91;
            this.label6.Text = "Crear Producto";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AlbergueHN.Properties.Resources.noun_boxes_editar;
            this.pictureBox1.Location = new System.Drawing.Point(76, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 92;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.comboTipo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioAdulto);
            this.panel1.Controls.Add(this.txtArticulo);
            this.panel1.Controls.Add(this.radioInfante);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radioCualquiera);
            this.panel1.Controls.Add(this.comboGen);
            this.panel1.Controls.Add(this.checkUsaGenero);
            this.panel1.Controls.Add(this.comboTalla);
            this.panel1.Controls.Add(this.checkUsaTalla);
            this.panel1.Location = new System.Drawing.Point(37, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 421);
            this.panel1.TabIndex = 93;
            // 
            // dialogCrearProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(589, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "dialogCrearProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Producto";
            this.Load += new System.EventHandler(this.dialogProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboTipo;
        public System.Windows.Forms.ComboBox comboGen;
        private System.Windows.Forms.ComboBox comboTalla;
        private System.Windows.Forms.CheckBox checkUsaTalla;
        private System.Windows.Forms.CheckBox checkUsaGenero;
        private System.Windows.Forms.RadioButton radioCualquiera;
        private System.Windows.Forms.RadioButton radioInfante;
        private System.Windows.Forms.RadioButton radioAdulto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}