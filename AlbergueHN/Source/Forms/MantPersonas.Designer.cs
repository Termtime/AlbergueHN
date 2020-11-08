namespace AlbergueHN.Source.Forms
{
    partial class MantPersonas
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnDarDeAlta = new System.Windows.Forms.Button();
            this.tablaPersonas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Modificar datos de las personas ingresadas y dar de alta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 55);
            this.label1.TabIndex = 10;
            this.label1.Text = "Administrar Personas";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(828, 107);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 100);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar Producto";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnDarDeAlta
            // 
            this.btnDarDeAlta.Location = new System.Drawing.Point(827, 610);
            this.btnDarDeAlta.Name = "btnDarDeAlta";
            this.btnDarDeAlta.Size = new System.Drawing.Size(75, 97);
            this.btnDarDeAlta.TabIndex = 7;
            this.btnDarDeAlta.Text = "Dar de alta";
            this.btnDarDeAlta.UseVisualStyleBackColor = true;
            this.btnDarDeAlta.Click += new System.EventHandler(this.BtnDarDeAlta_Click);
            // 
            // tablaPersonas
            // 
            this.tablaPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPersonas.Location = new System.Drawing.Point(13, 107);
            this.tablaPersonas.Name = "tablaPersonas";
            this.tablaPersonas.Size = new System.Drawing.Size(809, 600);
            this.tablaPersonas.TabIndex = 6;
            // 
            // MantPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 713);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnDarDeAlta);
            this.Controls.Add(this.tablaPersonas);
            this.Name = "MantPersonas";
            this.Text = "Administrar personas";
            ((System.ComponentModel.ISupportInitialize)(this.tablaPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDarDeAlta;
        private System.Windows.Forms.DataGridView tablaPersonas;
    }
}