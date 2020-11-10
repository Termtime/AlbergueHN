namespace AlbergueHN.Source.Forms
{
    partial class dialogConectarServidor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.txtBD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP o dirección:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(95, 23);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(193, 20);
            this.txtIP.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(95, 82);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(193, 20);
            this.txtPass.TabIndex = 3;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(95, 144);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.BtnConectar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado:";
            // 
            // labelEstado
            // 
            this.labelEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(302, 49);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(58, 13);
            this.labelEstado.TabIndex = 6;
            this.labelEstado.Text = "Esperando";
            // 
            // btnDetalles
            // 
            this.btnDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalles.Location = new System.Drawing.Point(302, 77);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(89, 23);
            this.btnDetalles.TabIndex = 7;
            this.btnDetalles.Text = "Mas detalles...";
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Visible = false;
            this.btnDetalles.Click += new System.EventHandler(this.BtnDetalles_Click);
            // 
            // txtBD
            // 
            this.txtBD.Location = new System.Drawing.Point(95, 118);
            this.txtBD.Name = "txtBD";
            this.txtBD.Size = new System.Drawing.Size(193, 20);
            this.txtBD.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Base de Datos:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(95, 52);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(193, 20);
            this.txtUsuario.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Usuario:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Limpiar Config.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dialogConectarServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 174);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dialogConectarServidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conectar al servidor";
            this.Load += new System.EventHandler(this.dialogConectarServidor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.TextBox txtBD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}