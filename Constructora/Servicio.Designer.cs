namespace Constructora
{
    partial class Servicio
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbl0 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvServicio = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(27, 55);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.MaxLength = 200;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(325, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // lbl0
            // 
            this.lbl0.AutoSize = true;
            this.lbl0.Location = new System.Drawing.Point(27, 25);
            this.lbl0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl0.Name = "lbl0";
            this.lbl0.Size = new System.Drawing.Size(128, 16);
            this.lbl0.TabIndex = 1;
            this.lbl0.Text = "Nombre del servicio";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(113, 148);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(156, 39);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(113, 234);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(156, 39);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(113, 315);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(156, 39);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvServicio
            // 
            this.dgvServicio.AllowUserToAddRows = false;
            this.dgvServicio.AllowUserToDeleteRows = false;
            this.dgvServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicio.ColumnHeadersHeight = 29;
            this.dgvServicio.Location = new System.Drawing.Point(391, 43);
            this.dgvServicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvServicio.MultiSelect = false;
            this.dgvServicio.Name = "dgvServicio";
            this.dgvServicio.ReadOnly = true;
            this.dgvServicio.RowHeadersWidth = 51;
            this.dgvServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicio.Size = new System.Drawing.Size(530, 449);
            this.dgvServicio.TabIndex = 4;
            this.dgvServicio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicio_CellClick);
            this.dgvServicio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicio_CellContentClick);
            // 
            // Servicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 505);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbl0);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvServicio);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1127, 543);
            this.Name = "Servicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Servicio";
            this.Load += new System.EventHandler(this.Servicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lbl0;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvServicio;
    }
}

