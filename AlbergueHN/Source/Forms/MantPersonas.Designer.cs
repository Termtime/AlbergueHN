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
            this.btnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(405, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Modificar datos de las personas ingresadas y dar de alta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 82);
            this.label1.TabIndex = 10;
            this.label1.Text = "Administrar Personas";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(1242, 329);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(112, 154);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar Datos";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnDarDeAlta
            // 
            this.btnDarDeAlta.Location = new System.Drawing.Point(1240, 938);
            this.btnDarDeAlta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDarDeAlta.Name = "btnDarDeAlta";
            this.btnDarDeAlta.Size = new System.Drawing.Size(112, 149);
            this.btnDarDeAlta.TabIndex = 7;
            this.btnDarDeAlta.Text = "Dar de alta";
            this.btnDarDeAlta.UseVisualStyleBackColor = true;
            this.btnDarDeAlta.Click += new System.EventHandler(this.BtnDarDeAlta_Click);
            // 
            // tablaPersonas
            // 
            this.tablaPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPersonas.Location = new System.Drawing.Point(20, 165);
            this.tablaPersonas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tablaPersonas.Name = "tablaPersonas";
            this.tablaPersonas.RowHeadersWidth = 62;
            this.tablaPersonas.Size = new System.Drawing.Size(1214, 923);
            this.tablaPersonas.TabIndex = 6;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(1242, 165);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(112, 154);
            this.btnIngresar.TabIndex = 12;
            this.btnIngresar.Text = "Ingresar Persona";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // MantPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 1097);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnDarDeAlta);
            this.Controls.Add(this.tablaPersonas);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MantPersonas";
            this.Text = "Administrar personas";
            this.Load += new System.EventHandler(this.MantPersonas_Load);
            this.SizeChanged += new System.EventHandler(this.MantPersonas_SizeChanged);
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
        private System.Windows.Forms.Button btnIngresar;
    }
}