namespace AlbergueHN
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exportar2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panelControlRopa = new System.Windows.Forms.Panel();
            this.comboTalla = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTalla = new System.Windows.Forms.Label();
            this.radioCualquiera = new System.Windows.Forms.RadioButton();
            this.radioFemenino = new System.Windows.Forms.RadioButton();
            this.radioMasculino = new System.Windows.Forms.RadioButton();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tablaSuministros = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.exportar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboFiltro = new System.Windows.Forms.ComboBox();
            this.txtFiltro1 = new System.Windows.Forms.TextBox();
            this.tablaPersonas = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refrescarListadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despacharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vestimentaCalzadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vestimentaCalzadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelControlRopa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaSuministros)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPersonas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.exportar2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panelControlRopa);
            this.tabPage2.Controls.Add(this.txtFiltro);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboTipo);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tablaSuministros);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1255, 625);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Productos";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.SizeChanged += new System.EventHandler(this.TabPage2_SizeChanged);
            this.tabPage2.Click += new System.EventHandler(this.TabPage2_Click);
            // 
            // exportar2
            // 
            this.exportar2.Image = global::AlbergueHN.Properties.Resources.Excel_2013_23480;
            this.exportar2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.exportar2.Location = new System.Drawing.Point(880, 54);
            this.exportar2.Name = "exportar2";
            this.exportar2.Size = new System.Drawing.Size(162, 42);
            this.exportar2.TabIndex = 57;
            this.exportar2.Text = "Exportar a Excel";
            this.exportar2.UseVisualStyleBackColor = true;
            this.exportar2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(6, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1246, 48);
            this.panel2.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1246, 48);
            this.label8.TabIndex = 12;
            this.label8.Text = "Productos";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControlRopa
            // 
            this.panelControlRopa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlRopa.Controls.Add(this.comboTalla);
            this.panelControlRopa.Controls.Add(this.label1);
            this.panelControlRopa.Controls.Add(this.labelTalla);
            this.panelControlRopa.Controls.Add(this.radioCualquiera);
            this.panelControlRopa.Controls.Add(this.radioFemenino);
            this.panelControlRopa.Controls.Add(this.radioMasculino);
            this.panelControlRopa.Location = new System.Drawing.Point(1048, 46);
            this.panelControlRopa.Name = "panelControlRopa";
            this.panelControlRopa.Size = new System.Drawing.Size(200, 56);
            this.panelControlRopa.TabIndex = 55;
            // 
            // comboTalla
            // 
            this.comboTalla.FormattingEnabled = true;
            this.comboTalla.Location = new System.Drawing.Point(67, 8);
            this.comboTalla.MaxLength = 5;
            this.comboTalla.Name = "comboTalla";
            this.comboTalla.Size = new System.Drawing.Size(94, 21);
            this.comboTalla.TabIndex = 43;
            this.comboTalla.SelectedIndexChanged += new System.EventHandler(this.ComboTalla_SelectedIndexChanged);
            this.comboTalla.TextChanged += new System.EventHandler(this.ComboTalla_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Genero:";
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
            this.radioCualquiera.CheckedChanged += new System.EventHandler(this.RadioCualquiera_CheckedChanged);
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
            this.radioFemenino.CheckedChanged += new System.EventHandler(this.RadioFemenino_CheckedChanged);
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
            this.radioMasculino.CheckedChanged += new System.EventHandler(this.RadioMasculino_CheckedChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(55, 80);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(261, 20);
            this.txtFiltro.TabIndex = 54;
            this.txtFiltro.TextChanged += new System.EventHandler(this.TxtFiltro_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Buscar:";
            // 
            // comboTipo
            // 
            this.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(55, 48);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(121, 21);
            this.comboTipo.TabIndex = 52;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.ComboTipo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Tipo:";
            // 
            // tablaSuministros
            // 
            this.tablaSuministros.AllowUserToAddRows = false;
            this.tablaSuministros.AllowUserToDeleteRows = false;
            this.tablaSuministros.AllowUserToResizeColumns = false;
            this.tablaSuministros.AllowUserToResizeRows = false;
            this.tablaSuministros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaSuministros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaSuministros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaSuministros.Location = new System.Drawing.Point(3, 108);
            this.tablaSuministros.Name = "tablaSuministros";
            this.tablaSuministros.ReadOnly = true;
            this.tablaSuministros.RowHeadersVisible = false;
            this.tablaSuministros.RowHeadersWidth = 62;
            this.tablaSuministros.Size = new System.Drawing.Size(1252, 514);
            this.tablaSuministros.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.exportar);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.comboFiltro);
            this.tabPage1.Controls.Add(this.txtFiltro1);
            this.tabPage1.Controls.Add(this.tablaPersonas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1255, 625);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personas";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.SizeChanged += new System.EventHandler(this.TabPage1_SizeChanged);
            this.tabPage1.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // exportar
            // 
            this.exportar.Image = global::AlbergueHN.Properties.Resources.Excel_2013_23480;
            this.exportar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.exportar.Location = new System.Drawing.Point(880, 54);
            this.exportar.Name = "exportar";
            this.exportar.Size = new System.Drawing.Size(162, 42);
            this.exportar.TabIndex = 44;
            this.exportar.Text = "Exportar a Excel";
            this.exportar.UseVisualStyleBackColor = true;
            this.exportar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(8, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 50);
            this.panel1.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1244, 50);
            this.label3.TabIndex = 13;
            this.label3.Text = "Personas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Buscar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Buscar por: ";
            // 
            // comboFiltro
            // 
            this.comboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFiltro.FormattingEnabled = true;
            this.comboFiltro.Items.AddRange(new object[] {
            "Nombre",
            "Identidad",
            "# Estudiante/Empleado"});
            this.comboFiltro.Location = new System.Drawing.Point(72, 53);
            this.comboFiltro.Name = "comboFiltro";
            this.comboFiltro.Size = new System.Drawing.Size(202, 21);
            this.comboFiltro.TabIndex = 39;
            this.comboFiltro.SelectedIndexChanged += new System.EventHandler(this.comboFiltro_SelectedIndexChanged);
            // 
            // txtFiltro1
            // 
            this.txtFiltro1.Location = new System.Drawing.Point(72, 79);
            this.txtFiltro1.Name = "txtFiltro1";
            this.txtFiltro1.Size = new System.Drawing.Size(507, 20);
            this.txtFiltro1.TabIndex = 38;
            this.txtFiltro1.TextChanged += new System.EventHandler(this.txtFiltro1_TextChanged);
            // 
            // tablaPersonas
            // 
            this.tablaPersonas.AllowUserToAddRows = false;
            this.tablaPersonas.AllowUserToDeleteRows = false;
            this.tablaPersonas.AllowUserToResizeColumns = false;
            this.tablaPersonas.AllowUserToResizeRows = false;
            this.tablaPersonas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaPersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPersonas.Location = new System.Drawing.Point(3, 108);
            this.tablaPersonas.Name = "tablaPersonas";
            this.tablaPersonas.ReadOnly = true;
            this.tablaPersonas.RowHeadersVisible = false;
            this.tablaPersonas.RowHeadersWidth = 62;
            this.tablaPersonas.Size = new System.Drawing.Size(1252, 510);
            this.tablaPersonas.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1263, 651);
            this.tabControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.accionesToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refrescarListadosToolStripMenuItem,
            this.conexionToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // refrescarListadosToolStripMenuItem
            // 
            this.refrescarListadosToolStripMenuItem.Name = "refrescarListadosToolStripMenuItem";
            this.refrescarListadosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refrescarListadosToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.refrescarListadosToolStripMenuItem.Text = "Refrescar datos";
            this.refrescarListadosToolStripMenuItem.Click += new System.EventHandler(this.RefrescarListadosToolStripMenuItem_Click);
            // 
            // conexionToolStripMenuItem
            // 
            this.conexionToolStripMenuItem.Name = "conexionToolStripMenuItem";
            this.conexionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.conexionToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.conexionToolStripMenuItem.Text = "Configurar conexión";
            this.conexionToolStripMenuItem.Click += new System.EventHandler(this.ConexionToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.CerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despacharToolStripMenuItem,
            this.ingresarToolStripMenuItem,
            this.administrarToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // despacharToolStripMenuItem
            // 
            this.despacharToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.vestimentaCalzadoToolStripMenuItem});
            this.despacharToolStripMenuItem.Name = "despacharToolStripMenuItem";
            this.despacharToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.despacharToolStripMenuItem.Text = "Despachar...";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.ProductosToolStripMenuItem_Click);
            // 
            // vestimentaCalzadoToolStripMenuItem
            // 
            this.vestimentaCalzadoToolStripMenuItem.Name = "vestimentaCalzadoToolStripMenuItem";
            this.vestimentaCalzadoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.vestimentaCalzadoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.vestimentaCalzadoToolStripMenuItem.Text = "Vestimenta/Calzado";
            this.vestimentaCalzadoToolStripMenuItem.Click += new System.EventHandler(this.VestimentaCalzadoToolStripMenuItem_Click);
            // 
            // ingresarToolStripMenuItem
            // 
            this.ingresarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem1,
            this.vestimentaCalzadoToolStripMenuItem1});
            this.ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            this.ingresarToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.ingresarToolStripMenuItem.Text = "Ingresar...";
            // 
            // productosToolStripMenuItem1
            // 
            this.productosToolStripMenuItem1.Name = "productosToolStripMenuItem1";
            this.productosToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.productosToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.productosToolStripMenuItem1.Text = "Productos";
            this.productosToolStripMenuItem1.Click += new System.EventHandler(this.ProductosToolStripMenuItem1_Click);
            // 
            // vestimentaCalzadoToolStripMenuItem1
            // 
            this.vestimentaCalzadoToolStripMenuItem1.Name = "vestimentaCalzadoToolStripMenuItem1";
            this.vestimentaCalzadoToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.vestimentaCalzadoToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.vestimentaCalzadoToolStripMenuItem1.Text = "Vestimenta/Calzado";
            this.vestimentaCalzadoToolStripMenuItem1.Click += new System.EventHandler(this.VestimentaCalzadoToolStripMenuItem1_Click);
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personasToolStripMenuItem,
            this.productosToolStripMenuItem2});
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.administrarToolStripMenuItem.Text = "Administrar...";
            // 
            // personasToolStripMenuItem
            // 
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.personasToolStripMenuItem.Text = "Personas";
            this.personasToolStripMenuItem.Click += new System.EventHandler(this.PersonasToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem2
            // 
            this.productosToolStripMenuItem2.Name = "productosToolStripMenuItem2";
            this.productosToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.productosToolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.productosToolStripMenuItem2.Text = "Productos";
            this.productosToolStripMenuItem2.Click += new System.EventHandler(this.ProductosToolStripMenuItem2_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versiónToolStripMenuItem});
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // versiónToolStripMenuItem
            // 
            this.versiónToolStripMenuItem.Name = "versiónToolStripMenuItem";
            this.versiónToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.versiónToolStripMenuItem.Text = "Versión";
            this.versiónToolStripMenuItem.Click += new System.EventHandler(this.VersiónToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 690);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlbergueHN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelControlRopa.ResumeLayout(false);
            this.panelControlRopa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaSuministros)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaPersonas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView tablaSuministros;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView tablaPersonas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboFiltro;
        private System.Windows.Forms.TextBox txtFiltro1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelControlRopa;
        private System.Windows.Forms.ComboBox comboTalla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTalla;
        private System.Windows.Forms.RadioButton radioCualquiera;
        private System.Windows.Forms.RadioButton radioFemenino;
        private System.Windows.Forms.RadioButton radioMasculino;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem refrescarListadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despacharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vestimentaCalzadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vestimentaCalzadoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem2;
        private System.Windows.Forms.Button exportar;
        private System.Windows.Forms.Button exportar2;
    }
}

