namespace Constructora
{
    partial class Disenio
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cmbArquitecto = new System.Windows.Forms.ComboBox();
            this.lbl0 = new System.Windows.Forms.Label();
            this.lbl0.Text = "Arquitecto";
            this.lbl0.AutoSize = true;
            this.lbl0.Location = new System.Drawing.Point(20, 20);
            this.cmbArquitecto.Name = "cmbArquitecto";
            this.cmbArquitecto.Location = new System.Drawing.Point(20, 45);
            this.cmbArquitecto.Size = new System.Drawing.Size(260, 25);
            this.cmbArquitecto.TabIndex = 0;
            this.cmbArquitecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Controls.Add(this.lbl0);
            this.Controls.Add(this.cmbArquitecto);
            this.cmbProyecto = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl1.Text = "Proyecto";
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(20, 85);
            this.cmbProyecto.Name = "cmbProyecto";
            this.cmbProyecto.Location = new System.Drawing.Point(20, 110);
            this.cmbProyecto.Size = new System.Drawing.Size(260, 25);
            this.cmbProyecto.TabIndex = 1;
            this.cmbProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.cmbProyecto);
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl2.Text = "Nombre del diseño";
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(20, 150);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Location = new System.Drawing.Point(20, 175);
            this.txtNombre.Size = new System.Drawing.Size(260, 25);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.MaxLength = 200;
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtNombre);
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl3.Text = "Fecha de creación";
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(20, 215);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Location = new System.Drawing.Point(20, 240);
            this.dtpFechaCreacion.Size = new System.Drawing.Size(260, 25);
            this.dtpFechaCreacion.TabIndex = 3;
            this.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCreacion.MinDate = new System.DateTime(1753, 1, 1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.dtpFechaCreacion);
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl4.Text = "Descripción";
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(20, 280);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Location = new System.Drawing.Point(20, 305);
            this.txtDescripcion.Size = new System.Drawing.Size(260, 85);
            this.txtDescripcion.TabIndex = 4;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.MaxLength = 0;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.txtDescripcion);
            this.nudCostoDisenio = new System.Windows.Forms.NumericUpDown();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl5.Text = "Costo del diseño";
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(20, 405);
            this.nudCostoDisenio.Name = "nudCostoDisenio";
            this.nudCostoDisenio.Location = new System.Drawing.Point(20, 430);
            this.nudCostoDisenio.Size = new System.Drawing.Size(260, 25);
            this.nudCostoDisenio.TabIndex = 5;
            this.nudCostoDisenio.DecimalPlaces = 2;
            this.nudCostoDisenio.Maximum = 922337203685477.58M;
            this.nudCostoDisenio.ThousandsSeparator = true;
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.nudCostoDisenio);
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(20, 485);
            this.btnAgregar.Size = new System.Drawing.Size(80, 32);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.Controls.Add(this.btnAgregar);
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Location = new System.Drawing.Point(110, 485);
            this.btnModificar.Size = new System.Drawing.Size(80, 32);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            this.Controls.Add(this.btnModificar);
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(200, 485);
            this.btnEliminar.Size = new System.Drawing.Size(80, 32);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.Controls.Add(this.btnEliminar);

            this.dgvDisenio = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisenio)).BeginInit();
            this.dgvDisenio.Location = new System.Drawing.Point(305, 20);
            this.dgvDisenio.Size = new System.Drawing.Size(775, 497);
            this.dgvDisenio.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDisenio.ReadOnly = true;
            this.dgvDisenio.AllowUserToAddRows = false;
            this.dgvDisenio.AllowUserToDeleteRows = false;
            this.dgvDisenio.MultiSelect = false;
            this.dgvDisenio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisenio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisenio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisenio_CellClick);
            this.Controls.Add(this.dgvDisenio);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 540);
            this.MinimumSize = new System.Drawing.Size(1000, 580);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "Disenio";
            this.Text = "Diseño";
            this.Load += new System.EventHandler(this.Disenio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisenio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ComboBox cmbArquitecto;
        private System.Windows.Forms.Label lbl0;
        private System.Windows.Forms.ComboBox cmbProyecto;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.NumericUpDown nudCostoDisenio;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvDisenio;
    }
}

