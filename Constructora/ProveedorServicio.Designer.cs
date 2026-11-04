namespace Constructora
{
    partial class ProveedorServicio
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
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lbl0 = new System.Windows.Forms.Label();
            this.lbl0.Text = "Proveedor";
            this.lbl0.Location = new System.Drawing.Point(20, 20);
            this.lbl0.AutoSize = true;
            this.cmbProveedor.Location = new System.Drawing.Point(20, 45);
            this.cmbProveedor.Size = new System.Drawing.Size(245, 25);
            this.cmbProveedor.TabIndex = 0;
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.lbl0);
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl1.Text = "Servicio";
            this.lbl1.Location = new System.Drawing.Point(20, 105);
            this.lbl1.AutoSize = true;
            this.cmbServicio.Location = new System.Drawing.Point(20, 130);
            this.cmbServicio.Size = new System.Drawing.Size(245, 25);
            this.cmbServicio.TabIndex = 1;
            this.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Controls.Add(this.cmbServicio);
            this.Controls.Add(this.lbl1);
            this.nudCostoBase = new System.Windows.Forms.NumericUpDown();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl2.Text = "Costo base";
            this.lbl2.Location = new System.Drawing.Point(20, 190);
            this.lbl2.AutoSize = true;
            this.nudCostoBase.Location = new System.Drawing.Point(20, 215);
            this.nudCostoBase.Size = new System.Drawing.Size(245, 25);
            this.nudCostoBase.TabIndex = 2;
            this.nudCostoBase.DecimalPlaces = 2;
            this.nudCostoBase.Maximum = 922337203685477.58M;
            this.nudCostoBase.ThousandsSeparator = true;
            this.Controls.Add(this.nudCostoBase);
            this.Controls.Add(this.lbl2);
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Location = new System.Drawing.Point(20, 300);
            this.btnAgregar.Size = new System.Drawing.Size(117, 32);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.Controls.Add(this.btnAgregar);
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Location = new System.Drawing.Point(148, 300);
            this.btnModificar.Size = new System.Drawing.Size(117, 32);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            this.Controls.Add(this.btnModificar);
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(20, 345);
            this.btnEliminar.Size = new System.Drawing.Size(117, 32);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.Controls.Add(this.btnEliminar);

            this.dgvProveedorServicio = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedorServicio)).BeginInit();
            this.dgvProveedorServicio.Location = new System.Drawing.Point(290, 20);
            this.dgvProveedorServicio.Size = new System.Drawing.Size(670, 365);
            this.dgvProveedorServicio.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProveedorServicio.ReadOnly = true;
            this.dgvProveedorServicio.AllowUserToAddRows = false;
            this.dgvProveedorServicio.AllowUserToDeleteRows = false;
            this.dgvProveedorServicio.MultiSelect = false;
            this.dgvProveedorServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedorServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedorServicio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedorServicio_CellClick);
            this.Controls.Add(this.dgvProveedorServicio);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 410);
            this.MinimumSize = new System.Drawing.Size(850, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "ProveedorServicio";
            this.Text = "Proveedor Servicio";
            this.Load += new System.EventHandler(this.ProveedorServicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedorServicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lbl0;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.NumericUpDown nudCostoBase;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvProveedorServicio;
    }
}

