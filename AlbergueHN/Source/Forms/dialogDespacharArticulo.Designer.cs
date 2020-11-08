namespace AlbergueHN.Source.Forms
{
    partial class dialogDespacharArticulo
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
            this.tablaDespacho = new System.Windows.Forms.DataGridView();
            this.listaProductos = new System.Windows.Forms.ListView();
            this.tipoArticulo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tallaArticulo = new System.Windows.Forms.ComboBox();
            this.btnDespachar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDespacho)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaDespacho
            // 
            this.tablaDespacho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDespacho.Location = new System.Drawing.Point(336, 26);
            this.tablaDespacho.Name = "tablaDespacho";
            this.tablaDespacho.Size = new System.Drawing.Size(935, 687);
            this.tablaDespacho.TabIndex = 0;
            // 
            // listaProductos
            // 
            this.listaProductos.HideSelection = false;
            this.listaProductos.Location = new System.Drawing.Point(12, 202);
            this.listaProductos.Name = "listaProductos";
            this.listaProductos.Size = new System.Drawing.Size(308, 464);
            this.listaProductos.TabIndex = 2;
            this.listaProductos.UseCompatibleStateImageBehavior = false;
            // 
            // tipoArticulo
            // 
            this.tipoArticulo.FormattingEnabled = true;
            this.tipoArticulo.Items.AddRange(new object[] {
            "Ropa",
            "Calzado",
            "Alimento",
            "Bebida",
            "Bioseguridad",
            "Otros"});
            this.tipoArticulo.Location = new System.Drawing.Point(59, 141);
            this.tipoArticulo.Name = "tipoArticulo";
            this.tipoArticulo.Size = new System.Drawing.Size(121, 21);
            this.tipoArticulo.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Tipo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Buscar:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(59, 173);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(261, 20);
            this.txtFiltro.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Talla:";
            // 
            // tallaArticulo
            // 
            this.tallaArticulo.Enabled = false;
            this.tallaArticulo.FormattingEnabled = true;
            this.tallaArticulo.Location = new System.Drawing.Point(225, 141);
            this.tallaArticulo.Name = "tallaArticulo";
            this.tallaArticulo.Size = new System.Drawing.Size(94, 21);
            this.tallaArticulo.TabIndex = 43;
            // 
            // btnDespachar
            // 
            this.btnDespachar.Location = new System.Drawing.Point(12, 672);
            this.btnDespachar.Name = "btnDespachar";
            this.btnDespachar.Size = new System.Drawing.Size(151, 41);
            this.btnDespachar.TabIndex = 44;
            this.btnDespachar.Text = "Despachar";
            this.btnDespachar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(169, 672);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(151, 41);
            this.btnLimpiar.TabIndex = 45;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // dialogDespacharArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 725);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnDespachar);
            this.Controls.Add(this.tallaArticulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tipoArticulo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listaProductos);
            this.Controls.Add(this.tablaDespacho);
            this.Name = "dialogDespacharArticulo";
            this.Text = "Despachar articulos";
            this.Load += new System.EventHandler(this.DialogDespacharProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDespacho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaDespacho;
        private System.Windows.Forms.ListView listaProductos;
        private System.Windows.Forms.ComboBox tipoArticulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tallaArticulo;
        private System.Windows.Forms.Button btnDespachar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}