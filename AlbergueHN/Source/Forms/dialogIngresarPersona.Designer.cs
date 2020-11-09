namespace AlbergueHN.Source.Forms
{
    partial class dialogIngresarPersona
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
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.radioFemenino = new System.Windows.Forms.RadioButton();
            this.radioMasculino = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.checkFamiliar = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboMunicipio = new System.Windows.Forms.ComboBox();
            this.txtFamiliares = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Location = new System.Drawing.Point(135, 20);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(138, 20);
            this.txtNombres.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Fecha de Nacimiento:";
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Location = new System.Drawing.Point(135, 141);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.fechaNacimiento.TabIndex = 34;
            // 
            // radioFemenino
            // 
            this.radioFemenino.AutoSize = true;
            this.radioFemenino.Location = new System.Drawing.Point(227, 171);
            this.radioFemenino.Name = "radioFemenino";
            this.radioFemenino.Size = new System.Drawing.Size(71, 17);
            this.radioFemenino.TabIndex = 33;
            this.radioFemenino.Text = "Femenino";
            this.radioFemenino.UseVisualStyleBackColor = true;
            // 
            // radioMasculino
            // 
            this.radioMasculino.AutoSize = true;
            this.radioMasculino.Checked = true;
            this.radioMasculino.Location = new System.Drawing.Point(135, 171);
            this.radioMasculino.Name = "radioMasculino";
            this.radioMasculino.Size = new System.Drawing.Size(73, 17);
            this.radioMasculino.TabIndex = 32;
            this.radioMasculino.TabStop = true;
            this.radioMasculino.Text = "Masculino";
            this.radioMasculino.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Genero:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Nombres:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "# de Identidad:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(135, 52);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(221, 20);
            this.txtId.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "# Empleado/Estudiante:";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(135, 82);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(200, 20);
            this.txtCuenta.TabIndex = 44;
            // 
            // checkFamiliar
            // 
            this.checkFamiliar.AutoSize = true;
            this.checkFamiliar.Location = new System.Drawing.Point(341, 83);
            this.checkFamiliar.Name = "checkFamiliar";
            this.checkFamiliar.Size = new System.Drawing.Size(88, 17);
            this.checkFamiliar.TabIndex = 46;
            this.checkFamiliar.Text = "¿Es Familiar?";
            this.checkFamiliar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "# Telefono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(135, 114);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 48;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(341, 310);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 49;
            this.btnAceptar.Text = "Ingresar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(423, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtApellidos
            // 
            this.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidos.Location = new System.Drawing.Point(353, 22);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(138, 20);
            this.txtApellidos.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Apellidos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Municipio:";
            // 
            // comboMunicipio
            // 
            this.comboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMunicipio.FormattingEnabled = true;
            this.comboMunicipio.Location = new System.Drawing.Point(135, 200);
            this.comboMunicipio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboMunicipio.Name = "comboMunicipio";
            this.comboMunicipio.Size = new System.Drawing.Size(192, 21);
            this.comboMunicipio.TabIndex = 57;
            // 
            // txtFamiliares
            // 
            this.txtFamiliares.Location = new System.Drawing.Point(135, 269);
            this.txtFamiliares.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFamiliares.Name = "txtFamiliares";
            this.txtFamiliares.Size = new System.Drawing.Size(200, 20);
            this.txtFamiliares.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "# Familiares:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(135, 235);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 20);
            this.txtDireccion.TabIndex = 56;
            // 
            // dialogIngresarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 346);
            this.Controls.Add(this.txtFamiliares);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboMunicipio);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkFamiliar);
            this.Controls.Add(this.txtCuenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fechaNacimiento);
            this.Controls.Add(this.radioFemenino);
            this.Controls.Add(this.radioMasculino);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Name = "dialogIngresarPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Persona";
            this.Load += new System.EventHandler(this.dialogIngresarPersona_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkFamiliar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtApellidos;
        public System.Windows.Forms.TextBox txtNombres;
        public System.Windows.Forms.DateTimePicker fechaNacimiento;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.TextBox txtCuenta;
        public System.Windows.Forms.TextBox txtTelefono;
        public System.Windows.Forms.RadioButton radioFemenino;
        public System.Windows.Forms.RadioButton radioMasculino;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboMunicipio;
        public System.Windows.Forms.TextBox txtFamiliares;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtDireccion;
    }
}