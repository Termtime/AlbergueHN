﻿namespace AlbergueHN.Source.Forms
{
    partial class dialogModificarPersona
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
            this.spinnerFamiliares = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtID3 = new System.Windows.Forms.MaskedTextBox();
            this.txtID2 = new System.Windows.Forms.MaskedTextBox();
            this.txtID1 = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMunicipio = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkFamiliar = new System.Windows.Forms.CheckBox();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.radioFemenino = new System.Windows.Forms.RadioButton();
            this.radioMasculino = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerFamiliares)).BeginInit();
            this.SuspendLayout();
            // 
            // spinnerFamiliares
            // 
            this.spinnerFamiliares.Location = new System.Drawing.Point(135, 319);
            this.spinnerFamiliares.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.spinnerFamiliares.Name = "spinnerFamiliares";
            this.spinnerFamiliares.Size = new System.Drawing.Size(32, 20);
            this.spinnerFamiliares.TabIndex = 98;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(199, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 13);
            this.label13.TabIndex = 97;
            this.label13.Text = "8 dígitos, sin separaciones.";
            // 
            // txtID3
            // 
            this.txtID3.Enabled = false;
            this.txtID3.Location = new System.Drawing.Point(245, 103);
            this.txtID3.Mask = "99999";
            this.txtID3.Name = "txtID3";
            this.txtID3.Size = new System.Drawing.Size(38, 20);
            this.txtID3.TabIndex = 96;
            this.txtID3.ValidatingType = typeof(int);
            // 
            // txtID2
            // 
            this.txtID2.Enabled = false;
            this.txtID2.Location = new System.Drawing.Point(189, 103);
            this.txtID2.Mask = "9999";
            this.txtID2.Name = "txtID2";
            this.txtID2.Size = new System.Drawing.Size(32, 20);
            this.txtID2.TabIndex = 95;
            this.txtID2.ValidatingType = typeof(int);
            // 
            // txtID1
            // 
            this.txtID1.Enabled = false;
            this.txtID1.Location = new System.Drawing.Point(135, 103);
            this.txtID1.Mask = "9999";
            this.txtID1.Name = "txtID1";
            this.txtID1.Size = new System.Drawing.Size(32, 20);
            this.txtID1.TabIndex = 94;
            this.txtID1.ValidatingType = typeof(int);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(135, 164);
            this.txtTelefono.Mask = "99999999";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(57, 20);
            this.txtTelefono.TabIndex = 93;
            this.txtTelefono.ValidatingType = typeof(int);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(229, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 92;
            this.label12.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(173, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 91;
            this.label11.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "# Familiares:";
            // 
            // comboMunicipio
            // 
            this.comboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMunicipio.FormattingEnabled = true;
            this.comboMunicipio.Location = new System.Drawing.Point(135, 250);
            this.comboMunicipio.Margin = new System.Windows.Forms.Padding(2);
            this.comboMunicipio.Name = "comboMunicipio";
            this.comboMunicipio.Size = new System.Drawing.Size(192, 21);
            this.comboMunicipio.TabIndex = 74;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(135, 285);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.MaxLength = 45;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "Dirección:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Municipio:";
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Location = new System.Drawing.Point(134, 67);
            this.txtApellido.MaxLength = 30;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(201, 20);
            this.txtApellido.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Apellidos:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(423, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 86;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.Location = new System.Drawing.Point(341, 360);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 85;
            this.btnAceptar.Text = "Modificar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 84;
            this.label6.Text = "# Telefono:";
            // 
            // checkFamiliar
            // 
            this.checkFamiliar.AutoSize = true;
            this.checkFamiliar.Enabled = false;
            this.checkFamiliar.Location = new System.Drawing.Point(341, 133);
            this.checkFamiliar.Name = "checkFamiliar";
            this.checkFamiliar.Size = new System.Drawing.Size(88, 17);
            this.checkFamiliar.TabIndex = 83;
            this.checkFamiliar.Text = "¿Es Familiar?";
            this.checkFamiliar.UseVisualStyleBackColor = true;
            // 
            // txtCuenta
            // 
            this.txtCuenta.Enabled = false;
            this.txtCuenta.Location = new System.Drawing.Point(135, 132);
            this.txtCuenta.MaxLength = 11;
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(200, 20);
            this.txtCuenta.TabIndex = 72;
            this.txtCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCuenta_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "# Empleado/Estudiante:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "# de Identidad:";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(134, 30);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(201, 20);
            this.txtNombre.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "Fecha de Nacimiento:";
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Location = new System.Drawing.Point(135, 191);
            this.fechaNacimiento.MaxDate = new System.DateTime(2020, 11, 10, 0, 0, 0, 0);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.fechaNacimiento.TabIndex = 73;
            this.fechaNacimiento.Value = new System.DateTime(2020, 11, 10, 0, 0, 0, 0);
            // 
            // radioFemenino
            // 
            this.radioFemenino.AutoSize = true;
            this.radioFemenino.Location = new System.Drawing.Point(227, 221);
            this.radioFemenino.Name = "radioFemenino";
            this.radioFemenino.Size = new System.Drawing.Size(71, 17);
            this.radioFemenino.TabIndex = 79;
            this.radioFemenino.Text = "Femenino";
            this.radioFemenino.UseVisualStyleBackColor = true;
            // 
            // radioMasculino
            // 
            this.radioMasculino.AutoSize = true;
            this.radioMasculino.Checked = true;
            this.radioMasculino.Location = new System.Drawing.Point(135, 221);
            this.radioMasculino.Name = "radioMasculino";
            this.radioMasculino.Size = new System.Drawing.Size(73, 17);
            this.radioMasculino.TabIndex = 78;
            this.radioMasculino.TabStop = true;
            this.radioMasculino.Text = "Masculino";
            this.radioMasculino.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 77;
            this.label9.Text = "Genero:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 76;
            this.label10.Text = "Nombres:";
            // 
            // dialogModificarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 396);
            this.Controls.Add(this.spinnerFamiliares);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtID3);
            this.Controls.Add(this.txtID2);
            this.Controls.Add(this.txtID1);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboMunicipio);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkFamiliar);
            this.Controls.Add(this.txtCuenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fechaNacimiento);
            this.Controls.Add(this.radioFemenino);
            this.Controls.Add(this.radioMasculino);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Name = "dialogModificarPersona";
            this.Text = "Modificar Persona";
            this.Load += new System.EventHandler(this.DialogModificarPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerFamiliares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown spinnerFamiliares;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.MaskedTextBox txtID3;
        public System.Windows.Forms.MaskedTextBox txtID2;
        public System.Windows.Forms.MaskedTextBox txtID1;
        public System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboMunicipio;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox checkFamiliar;
        public System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker fechaNacimiento;
        public System.Windows.Forms.RadioButton radioFemenino;
        public System.Windows.Forms.RadioButton radioMasculino;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}