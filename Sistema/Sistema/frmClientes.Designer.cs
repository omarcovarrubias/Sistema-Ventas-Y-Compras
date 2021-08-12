namespace Sistema
{
    partial class frmClientes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCallee = new System.Windows.Forms.TextBox();
            this.txtNombree = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnDesHabilitar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtNumeroe = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCorreoElectronicoe = new System.Windows.Forms.TextBox();
            this.dbgClientes = new System.Windows.Forms.DataGridView();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtColoniae = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnHabilitar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCerrar2 = new System.Windows.Forms.Button();
            this.btnLimpiar2 = new System.Windows.Forms.Button();
            this.txtCodigoe = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tlbInactivos = new System.Windows.Forms.TabPage();
            this.dbgClientese = new System.Windows.Forms.DataGridView();
            this.btnBuscare = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tlbActivos = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dbgClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tlbInactivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgClientese)).BeginInit();
            this.tlbActivos.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(203, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 20);
            this.label12.TabIndex = 55;
            this.label12.Text = "Colonia:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(199, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 20);
            this.label14.TabIndex = 53;
            this.label14.Text = "Dirección:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker2.CustomFormat = "HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorProvider1.SetIconAlignment(this.dateTimePicker2, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.dateTimePicker2.Location = new System.Drawing.Point(663, 243);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(183, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:MM:ss";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(663, 216);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.BackgroundImage")));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(600, 415);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(95, 60);
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(320, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 60);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(448, 415);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(109, 60);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(308, 6);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(145, 26);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(186, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 20);
            this.label19.TabIndex = 49;
            this.label19.Text = "Codigo";
            // 
            // txtCallee
            // 
            this.txtCallee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCallee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCallee.Location = new System.Drawing.Point(271, 172);
            this.txtCallee.Name = "txtCallee";
            this.txtCallee.Size = new System.Drawing.Size(127, 26);
            this.txtCallee.TabIndex = 3;
            // 
            // txtNombree
            // 
            this.txtNombree.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombree.Location = new System.Drawing.Point(325, 51);
            this.txtNombree.Name = "txtNombree";
            this.txtNombree.Size = new System.Drawing.Size(145, 26);
            this.txtNombree.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(224, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 20);
            this.label10.TabIndex = 57;
            this.label10.Text = "Correo Electrónico:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(422, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 56;
            this.label11.Text = "Número:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(459, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(105, 60);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnNuevo, "Nuevo");
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(505, 86);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 44);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnDesHabilitar
            // 
            this.btnDesHabilitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDesHabilitar.BackgroundImage")));
            this.btnDesHabilitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesHabilitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesHabilitar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesHabilitar.Location = new System.Drawing.Point(688, 75);
            this.btnDesHabilitar.Name = "btnDesHabilitar";
            this.btnDesHabilitar.Size = new System.Drawing.Size(124, 55);
            this.btnDesHabilitar.TabIndex = 12;
            this.btnDesHabilitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDesHabilitar.UseVisualStyleBackColor = true;
            this.btnDesHabilitar.Click += new System.EventHandler(this.btnDesHabilitar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.BackgroundImage")));
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(691, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(124, 60);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip3.SetToolTip(this.btnActualizar, "Modificar");
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtNumeroe
            // 
            this.txtNumeroe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroe.Location = new System.Drawing.Point(510, 172);
            this.txtNumeroe.Name = "txtNumeroe";
            this.txtNumeroe.Size = new System.Drawing.Size(166, 26);
            this.txtNumeroe.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(215, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.TabIndex = 54;
            this.label13.Text = "Calle:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(570, 6);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(115, 60);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip2.SetToolTip(this.btnAgregar, "Agregar");
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCorreoElectronicoe
            // 
            this.txtCorreoElectronicoe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorreoElectronicoe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoElectronicoe.Location = new System.Drawing.Point(380, 240);
            this.txtCorreoElectronicoe.Name = "txtCorreoElectronicoe";
            this.txtCorreoElectronicoe.Size = new System.Drawing.Size(238, 26);
            this.txtCorreoElectronicoe.TabIndex = 5;
            // 
            // dbgClientes
            // 
            this.dbgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgClientes.Cursor = System.Windows.Forms.Cursors.No;
            this.dbgClientes.Enabled = false;
            this.dbgClientes.Location = new System.Drawing.Point(40, 269);
            this.dbgClientes.Name = "dbgClientes";
            this.dbgClientes.Size = new System.Drawing.Size(1020, 140);
            this.dbgClientes.TabIndex = 16;
            this.dbgClientes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbgClientes_MouseDoubleClick);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(354, 231);
            this.txtCorreo.MaxLength = 50;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(256, 26);
            this.txtCorreo.TabIndex = 5;
            // 
            // txtCalle
            // 
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalle.Location = new System.Drawing.Point(249, 169);
            this.txtCalle.MaxLength = 50;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(145, 26);
            this.txtCalle.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(308, 41);
            this.txtNombre.MaxLength = 44;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(145, 26);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(186, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "Correo Electrónico:";
            // 
            // txtColoniae
            // 
            this.txtColoniae.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColoniae.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColoniae.Location = new System.Drawing.Point(325, 95);
            this.txtColoniae.Name = "txtColoniae";
            this.txtColoniae.Size = new System.Drawing.Size(145, 26);
            this.txtColoniae.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(202, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 24);
            this.label17.TabIndex = 50;
            this.label17.Text = "Nombre:";
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHabilitar.BackgroundImage")));
            this.btnHabilitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHabilitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHabilitar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitar.Location = new System.Drawing.Point(687, 17);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(129, 90);
            this.btnHabilitar.TabIndex = 9;
            this.btnHabilitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCerrar2
            // 
            this.btnCerrar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar2.BackgroundImage")));
            this.btnCerrar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar2.Location = new System.Drawing.Point(551, 415);
            this.btnCerrar2.Name = "btnCerrar2";
            this.btnCerrar2.Size = new System.Drawing.Size(111, 71);
            this.btnCerrar2.TabIndex = 11;
            this.btnCerrar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar2.UseVisualStyleBackColor = true;
            this.btnCerrar2.Click += new System.EventHandler(this.btnCerrar2_Click);
            // 
            // btnLimpiar2
            // 
            this.btnLimpiar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar2.BackgroundImage")));
            this.btnLimpiar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar2.Location = new System.Drawing.Point(338, 415);
            this.btnLimpiar2.Name = "btnLimpiar2";
            this.btnLimpiar2.Size = new System.Drawing.Size(111, 71);
            this.btnLimpiar2.TabIndex = 10;
            this.btnLimpiar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiar2.UseVisualStyleBackColor = true;
            this.btnLimpiar2.Click += new System.EventHandler(this.btnLimpiar2_Click);
            // 
            // txtCodigoe
            // 
            this.txtCodigoe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoe.Location = new System.Drawing.Point(325, 17);
            this.txtCodigoe.MaxLength = 5;
            this.txtCodigoe.Name = "txtCodigoe";
            this.txtCodigoe.Size = new System.Drawing.Size(145, 26);
            this.txtCodigoe.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(201, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 20);
            this.label20.TabIndex = 72;
            this.label20.Text = "Codigo";
            // 
            // tlbInactivos
            // 
            this.tlbInactivos.BackColor = System.Drawing.SystemColors.Info;
            this.tlbInactivos.Controls.Add(this.btnCerrar2);
            this.tlbInactivos.Controls.Add(this.btnLimpiar2);
            this.tlbInactivos.Controls.Add(this.txtCodigoe);
            this.tlbInactivos.Controls.Add(this.label20);
            this.tlbInactivos.Controls.Add(this.dbgClientese);
            this.tlbInactivos.Controls.Add(this.txtCorreoElectronicoe);
            this.tlbInactivos.Controls.Add(this.txtColoniae);
            this.tlbInactivos.Controls.Add(this.txtNumeroe);
            this.tlbInactivos.Controls.Add(this.txtCallee);
            this.tlbInactivos.Controls.Add(this.txtNombree);
            this.tlbInactivos.Controls.Add(this.label10);
            this.tlbInactivos.Controls.Add(this.label11);
            this.tlbInactivos.Controls.Add(this.label12);
            this.tlbInactivos.Controls.Add(this.label13);
            this.tlbInactivos.Controls.Add(this.label14);
            this.tlbInactivos.Controls.Add(this.label17);
            this.tlbInactivos.Controls.Add(this.btnHabilitar);
            this.tlbInactivos.Controls.Add(this.btnBuscare);
            this.tlbInactivos.Location = new System.Drawing.Point(4, 22);
            this.tlbInactivos.Name = "tlbInactivos";
            this.tlbInactivos.Padding = new System.Windows.Forms.Padding(3);
            this.tlbInactivos.Size = new System.Drawing.Size(1066, 499);
            this.tlbInactivos.TabIndex = 1;
            this.tlbInactivos.Text = "Inativos";
            // 
            // dbgClientese
            // 
            this.dbgClientese.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgClientese.Cursor = System.Windows.Forms.Cursors.No;
            this.dbgClientese.Location = new System.Drawing.Point(40, 269);
            this.dbgClientese.Name = "dbgClientese";
            this.dbgClientese.Size = new System.Drawing.Size(1020, 140);
            this.dbgClientese.TabIndex = 66;
            this.dbgClientese.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgClientese_CellContentClick);
            // 
            // btnBuscare
            // 
            this.btnBuscare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscare.BackgroundImage")));
            this.btnBuscare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscare.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscare.Location = new System.Drawing.Point(533, 20);
            this.btnBuscare.Name = "btnBuscare";
            this.btnBuscare.Size = new System.Drawing.Size(129, 87);
            this.btnBuscare.TabIndex = 8;
            this.btnBuscare.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscare.UseVisualStyleBackColor = true;
            this.btnBuscare.Click += new System.EventHandler(this.btnBuscare_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(159, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Dirección:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(185, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 27;
            this.label2.Text = "Nombre:";
            // 
            // tlbActivos
            // 
            this.tlbActivos.BackColor = System.Drawing.SystemColors.Info;
            this.tlbActivos.Controls.Add(this.btnEliminar);
            this.tlbActivos.Controls.Add(this.txtApellidos);
            this.tlbActivos.Controls.Add(this.label1);
            this.tlbActivos.Controls.Add(this.dateTimePicker2);
            this.tlbActivos.Controls.Add(this.dateTimePicker1);
            this.tlbActivos.Controls.Add(this.btnCerrar);
            this.tlbActivos.Controls.Add(this.btnCancelar);
            this.tlbActivos.Controls.Add(this.btnLimpiar);
            this.tlbActivos.Controls.Add(this.txtCodigo);
            this.tlbActivos.Controls.Add(this.label19);
            this.tlbActivos.Controls.Add(this.btnNuevo);
            this.tlbActivos.Controls.Add(this.btnBuscar);
            this.tlbActivos.Controls.Add(this.btnDesHabilitar);
            this.tlbActivos.Controls.Add(this.btnActualizar);
            this.tlbActivos.Controls.Add(this.btnAgregar);
            this.tlbActivos.Controls.Add(this.dbgClientes);
            this.tlbActivos.Controls.Add(this.txtCorreo);
            this.tlbActivos.Controls.Add(this.txtNumero);
            this.tlbActivos.Controls.Add(this.txtCalle);
            this.tlbActivos.Controls.Add(this.txtNombre);
            this.tlbActivos.Controls.Add(this.label9);
            this.tlbActivos.Controls.Add(this.label8);
            this.tlbActivos.Controls.Add(this.label5);
            this.tlbActivos.Controls.Add(this.label2);
            this.tlbActivos.Location = new System.Drawing.Point(4, 22);
            this.tlbActivos.Name = "tlbActivos";
            this.tlbActivos.Padding = new System.Windows.Forms.Padding(3);
            this.tlbActivos.Size = new System.Drawing.Size(1066, 499);
            this.tlbActivos.TabIndex = 0;
            this.tlbActivos.Text = "Activos";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(688, 152);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 44);
            this.btnEliminar.TabIndex = 55;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtApellidos
            // 
            this.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(308, 82);
            this.txtApellidos.MaxLength = 44;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(145, 26);
            this.txtApellidos.TabIndex = 2;
            this.txtApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidos_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(185, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 54;
            this.label1.Text = "Apellidos:";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(505, 173);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(115, 26);
            this.txtNumero.TabIndex = 4;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(405, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Celular:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tlbActivos);
            this.tabControl1.Controls.Add(this.tlbInactivos);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1074, 525);
            this.tabControl1.TabIndex = 3;
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "Nuevo";
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1084, 538);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbgClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tlbInactivos.ResumeLayout(false);
            this.tlbInactivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgClientese)).EndInit();
            this.tlbActivos.ResumeLayout(false);
            this.tlbActivos.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tlbActivos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnDesHabilitar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dbgClientes;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tlbInactivos;
        private System.Windows.Forms.Button btnCerrar2;
        private System.Windows.Forms.Button btnLimpiar2;
        private System.Windows.Forms.TextBox txtCodigoe;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dbgClientese;
        private System.Windows.Forms.TextBox txtCorreoElectronicoe;
        private System.Windows.Forms.TextBox txtColoniae;
        private System.Windows.Forms.TextBox txtNumeroe;
        private System.Windows.Forms.TextBox txtCallee;
        private System.Windows.Forms.TextBox txtNombree;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnHabilitar;
        private System.Windows.Forms.Button btnBuscare;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
    }
}