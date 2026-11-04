namespace Constructora
{
    partial class Proyecto
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
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbArquitecto = new System.Windows.Forms.ComboBox();
            this.lbCliente = new System.Windows.Forms.Label();
            this.lbArquitecto = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lbClave = new System.Windows.Forms.Label();
            this.lbEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgvProyecto = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lbFFin = new System.Windows.Forms.Label();
            this.lbFInicio = new System.Windows.Forms.Label();
            this.dtFecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.dtFecha_fin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyecto)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(15, 239);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(232, 28);
            this.cmbCliente.TabIndex = 0;
            // 
            // cmbArquitecto
            // 
            this.cmbArquitecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArquitecto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbArquitecto.FormattingEnabled = true;
            this.cmbArquitecto.Location = new System.Drawing.Point(15, 309);
            this.cmbArquitecto.Name = "cmbArquitecto";
            this.cmbArquitecto.Size = new System.Drawing.Size(232, 28);
            this.cmbArquitecto.TabIndex = 1;
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCliente.Location = new System.Drawing.Point(20, 216);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(144, 20);
            this.lbCliente.TabIndex = 2;
            this.lbCliente.Text = "Seleccione al cliente";
            // 
            // lbArquitecto
            // 
            this.lbArquitecto.AutoSize = true;
            this.lbArquitecto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArquitecto.Location = new System.Drawing.Point(20, 287);
            this.lbArquitecto.Name = "lbArquitecto";
            this.lbArquitecto.Size = new System.Drawing.Size(168, 20);
            this.lbArquitecto.TabIndex = 3;
            this.lbArquitecto.Text = "Seleccione al arquitecto";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(15, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(232, 27);
            this.txtNombre.TabIndex = 4;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(20, 19);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(152, 20);
            this.lbNombre.TabIndex = 5;
            this.lbNombre.Text = "Nombre del proyecto";
            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(15, 108);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(232, 27);
            this.txtClave.TabIndex = 6;
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClave.Location = new System.Drawing.Point(18, 85);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(107, 20);
            this.lbClave.TabIndex = 7;
            this.lbClave.Text = "Clave Catastral";
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstado.Location = new System.Drawing.Point(20, 148);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(54, 20);
            this.lbEstado.TabIndex = 8;
            this.lbEstado.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Planeación",
            "En proceso",
            "Finalizado"});
            this.cmbEstado.Location = new System.Drawing.Point(15, 171);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(232, 28);
            this.cmbEstado.TabIndex = 9;
            // 
            // dgvProyecto
            // 
            this.dgvProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProyecto.Location = new System.Drawing.Point(289, 108);
            this.dgvProyecto.Name = "dgvProyecto";
            this.dgvProyecto.RowHeadersWidth = 51;
            this.dgvProyecto.RowTemplate.Height = 24;
            this.dgvProyecto.Size = new System.Drawing.Size(1201, 705);
            this.dgvProyecto.TabIndex = 18;
            this.dgvProyecto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProyecto_CellClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(628, 42);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(110, 31);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(815, 42);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(113, 31);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1002, 42);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(113, 31);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lbFFin
            // 
            this.lbFFin.AutoSize = true;
            this.lbFFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFFin.Location = new System.Drawing.Point(20, 423);
            this.lbFFin.Name = "lbFFin";
            this.lbFFin.Size = new System.Drawing.Size(68, 20);
            this.lbFFin.TabIndex = 25;
            this.lbFFin.Text = "Fecha fin";
            // 
            // lbFInicio
            // 
            this.lbFInicio.AutoSize = true;
            this.lbFInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFInicio.Location = new System.Drawing.Point(20, 355);
            this.lbFInicio.Name = "lbFInicio";
            this.lbFInicio.Size = new System.Drawing.Size(87, 20);
            this.lbFInicio.TabIndex = 24;
            this.lbFInicio.Text = "Fecha inicio";
            // 
            // dtFecha_inicio
            // 
            this.dtFecha_inicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha_inicio.Location = new System.Drawing.Point(15, 379);
            this.dtFecha_inicio.Name = "dtFecha_inicio";
            this.dtFecha_inicio.Size = new System.Drawing.Size(232, 27);
            this.dtFecha_inicio.TabIndex = 28;
            // 
            // dtFecha_fin
            // 
            this.dtFecha_fin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha_fin.Location = new System.Drawing.Point(15, 446);
            this.dtFecha_fin.Name = "dtFecha_fin";
            this.dtFecha_fin.Size = new System.Drawing.Size(232, 27);
            this.dtFecha_fin.TabIndex = 29;
            // 
            // Proyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 825);
            this.Controls.Add(this.dtFecha_fin);
            this.Controls.Add(this.dtFecha_inicio);
            this.Controls.Add(this.lbFFin);
            this.Controls.Add(this.lbFInicio);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvProyecto);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.lbClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbArquitecto);
            this.Controls.Add(this.lbCliente);
            this.Controls.Add(this.cmbArquitecto);
            this.Controls.Add(this.cmbCliente);
            this.Name = "Proyecto";
            this.Text = "Proyecto";
            this.Load += new System.EventHandler(this.Proyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyecto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbArquitecto;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.Label lbArquitecto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DataGridView dgvProyecto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lbFFin;
        private System.Windows.Forms.Label lbFInicio;
        private System.Windows.Forms.DateTimePicker dtFecha_inicio;
        private System.Windows.Forms.DateTimePicker dtFecha_fin;
    }
}