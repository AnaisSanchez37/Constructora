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
            this.cmbArquitecto = new System.Windows.Forms.ComboBox();
            this.lbl0 = new System.Windows.Forms.Label();
            this.cmbProyecto = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.nudCostoDisenio = new System.Windows.Forms.NumericUpDown();
            this.lbl5 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvDisenio = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostoDisenio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisenio)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbArquitecto
            // 
            this.cmbArquitecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArquitecto.Location = new System.Drawing.Point(27, 55);
            this.cmbArquitecto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbArquitecto.Name = "cmbArquitecto";
            this.cmbArquitecto.Size = new System.Drawing.Size(345, 24);
            this.cmbArquitecto.TabIndex = 0;
            // 
            // lbl0
            // 
            this.lbl0.AutoSize = true;
            this.lbl0.Location = new System.Drawing.Point(27, 25);
            this.lbl0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl0.Name = "lbl0";
            this.lbl0.Size = new System.Drawing.Size(67, 16);
            this.lbl0.TabIndex = 0;
            this.lbl0.Text = "Arquitecto";
            // 
            // cmbProyecto
            // 
            this.cmbProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProyecto.Location = new System.Drawing.Point(27, 135);
            this.cmbProyecto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbProyecto.Name = "cmbProyecto";
            this.cmbProyecto.Size = new System.Drawing.Size(345, 24);
            this.cmbProyecto.TabIndex = 1;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(27, 105);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(61, 16);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Proyecto";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(27, 215);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.MaxLength = 200;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(345, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(27, 185);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(122, 16);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Nombre del diseño";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(27, 289);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.MaxLength = 0;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(345, 104);
            this.txtDescripcion.TabIndex = 4;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(27, 259);
            this.lbl4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(79, 16);
            this.lbl4.TabIndex = 4;
            this.lbl4.Text = "Descripción";
            // 
            // nudCostoDisenio
            // 
            this.nudCostoDisenio.DecimalPlaces = 2;
            this.nudCostoDisenio.Location = new System.Drawing.Point(27, 443);
            this.nudCostoDisenio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudCostoDisenio.Maximum = new decimal(new int[] {
            2061584302,
            21474836,
            0,
            131072});
            this.nudCostoDisenio.Name = "nudCostoDisenio";
            this.nudCostoDisenio.Size = new System.Drawing.Size(347, 22);
            this.nudCostoDisenio.TabIndex = 5;
            this.nudCostoDisenio.ThousandsSeparator = true;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(27, 412);
            this.lbl5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(108, 16);
            this.lbl5.TabIndex = 5;
            this.lbl5.Text = "Costo del diseño";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(27, 511);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 39);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(147, 511);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(107, 39);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(267, 511);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(107, 39);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvDisenio
            // 
            this.dgvDisenio.AllowUserToAddRows = false;
            this.dgvDisenio.AllowUserToDeleteRows = false;
            this.dgvDisenio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDisenio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisenio.ColumnHeadersHeight = 29;
            this.dgvDisenio.Location = new System.Drawing.Point(407, 25);
            this.dgvDisenio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDisenio.MultiSelect = false;
            this.dgvDisenio.Name = "dgvDisenio";
            this.dgvDisenio.ReadOnly = true;
            this.dgvDisenio.RowHeadersWidth = 51;
            this.dgvDisenio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisenio.Size = new System.Drawing.Size(1033, 612);
            this.dgvDisenio.TabIndex = 9;
            this.dgvDisenio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisenio_CellClick);
            // 
            // Disenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 665);
            this.Controls.Add(this.lbl0);
            this.Controls.Add(this.cmbArquitecto);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.cmbProyecto);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.nudCostoDisenio);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvDisenio);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1327, 703);
            this.Name = "Disenio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Diseño";
            this.Load += new System.EventHandler(this.Disenio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCostoDisenio)).EndInit();
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

