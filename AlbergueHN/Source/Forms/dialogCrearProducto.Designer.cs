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
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(385, 172);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(304, 172);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 50;
            this.btnAgregar.Text = "Ingresar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // comboTipo
            // 
            this.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(99, 18);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(121, 21);
            this.comboTipo.TabIndex = 0;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.TipoArticulo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Talla:";
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(99, 48);
            this.txtArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtArticulo.MaxLength = 39;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(356, 20);
            this.txtArticulo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Genero:";
            // 
            // comboGen
            // 
            this.comboGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGen.Enabled = false;
            this.comboGen.FormattingEnabled = true;
            this.comboGen.Location = new System.Drawing.Point(99, 99);
            this.comboGen.Margin = new System.Windows.Forms.Padding(2);
            this.comboGen.Name = "comboGen";
            this.comboGen.Size = new System.Drawing.Size(82, 21);
            this.comboGen.TabIndex = 4;
            // 
            // comboTalla
            // 
            this.comboTalla.Enabled = false;
            this.comboTalla.FormattingEnabled = true;
            this.comboTalla.Location = new System.Drawing.Point(99, 73);
            this.comboTalla.Name = "comboTalla";
            this.comboTalla.Size = new System.Drawing.Size(121, 21);
            this.comboTalla.TabIndex = 56;
            // 
            // checkUsaTalla
            // 
            this.checkUsaTalla.AutoSize = true;
            this.checkUsaTalla.Location = new System.Drawing.Point(227, 75);
            this.checkUsaTalla.Name = "checkUsaTalla";
            this.checkUsaTalla.Size = new System.Drawing.Size(79, 17);
            this.checkUsaTalla.TabIndex = 57;
            this.checkUsaTalla.Text = "¿Usa talla?";
            this.checkUsaTalla.UseVisualStyleBackColor = true;
            this.checkUsaTalla.CheckedChanged += new System.EventHandler(this.CheckUsaTalla_CheckedChanged);
            // 
            // checkUsaGenero
            // 
            this.checkUsaGenero.AutoSize = true;
            this.checkUsaGenero.Location = new System.Drawing.Point(187, 101);
            this.checkUsaGenero.Name = "checkUsaGenero";
            this.checkUsaGenero.Size = new System.Drawing.Size(93, 17);
            this.checkUsaGenero.TabIndex = 58;
            this.checkUsaGenero.Text = "¿Usa genero?";
            this.checkUsaGenero.UseVisualStyleBackColor = true;
            this.checkUsaGenero.CheckedChanged += new System.EventHandler(this.CheckUsaGenero_CheckedChanged);
            // 
            // radioCualquiera
            // 
            this.radioCualquiera.AutoSize = true;
            this.radioCualquiera.Checked = true;
            this.radioCualquiera.Location = new System.Drawing.Point(99, 134);
            this.radioCualquiera.Name = "radioCualquiera";
            this.radioCualquiera.Size = new System.Drawing.Size(45, 17);
            this.radioCualquiera.TabIndex = 59;
            this.radioCualquiera.TabStop = true;
            this.radioCualquiera.Text = "N/A";
            this.radioCualquiera.UseVisualStyleBackColor = true;
            // 
            // radioInfante
            // 
            this.radioInfante.AutoSize = true;
            this.radioInfante.Location = new System.Drawing.Point(150, 134);
            this.radioInfante.Name = "radioInfante";
            this.radioInfante.Size = new System.Drawing.Size(58, 17);
            this.radioInfante.TabIndex = 60;
            this.radioInfante.TabStop = true;
            this.radioInfante.Text = "Infante";
            this.radioInfante.UseVisualStyleBackColor = true;
            // 
            // radioAdulto
            // 
            this.radioAdulto.AutoSize = true;
            this.radioAdulto.Location = new System.Drawing.Point(214, 134);
            this.radioAdulto.Name = "radioAdulto";
            this.radioAdulto.Size = new System.Drawing.Size(55, 17);
            this.radioAdulto.TabIndex = 61;
            this.radioAdulto.TabStop = true;
            this.radioAdulto.Text = "Adulto";
            this.radioAdulto.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Rango Edad:";
            // 
            // dialogCrearProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 207);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioAdulto);
            this.Controls.Add(this.radioInfante);
            this.Controls.Add(this.radioCualquiera);
            this.Controls.Add(this.checkUsaGenero);
            this.Controls.Add(this.checkUsaTalla);
            this.Controls.Add(this.comboTalla);
            this.Controls.Add(this.comboGen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "dialogCrearProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Producto";
            this.Load += new System.EventHandler(this.dialogProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}