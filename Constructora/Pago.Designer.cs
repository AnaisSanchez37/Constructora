namespace Constructora
{
    partial class Pago
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
            this.lbCliente = new System.Windows.Forms.Label();
            this.lbProyecto = new System.Windows.Forms.Label();
            this.lbMonto = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbProyecto = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvPago = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPago)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Location = new System.Drawing.Point(14, 12);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(55, 20);
            this.lbCliente.TabIndex = 0;
            this.lbCliente.Text = "Cliente";
            // 
            // lbProyecto
            // 
            this.lbProyecto.AutoSize = true;
            this.lbProyecto.Location = new System.Drawing.Point(190, 12);
            this.lbProyecto.Name = "lbProyecto";
            this.lbProyecto.Size = new System.Drawing.Size(67, 20);
            this.lbProyecto.TabIndex = 1;
            this.lbProyecto.Text = "Proyecto";
            // 
            // lbMonto
            // 
            this.lbMonto.AutoSize = true;
            this.lbMonto.Location = new System.Drawing.Point(614, 12);
            this.lbMonto.Name = "lbMonto";
            this.lbMonto.Size = new System.Drawing.Size(53, 20);
            this.lbMonto.TabIndex = 2;
            this.lbMonto.Text = "Monto";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(14, 36);
            this.cbCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(167, 28);
            this.cbCliente.TabIndex = 3;
            // 
            // cbProyecto
            // 
            this.cbProyecto.FormattingEnabled = true;
            this.cbProyecto.Location = new System.Drawing.Point(189, 36);
            this.cbProyecto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbProyecto.Name = "cbProyecto";
            this.cbProyecto.Size = new System.Drawing.Size(397, 28);
            this.cbProyecto.TabIndex = 4;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(614, 36);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(114, 27);
            this.txtMonto.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(781, 35);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(86, 31);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(781, 73);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(86, 31);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(781, 112);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 31);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvPago
            // 
            this.dgvPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPago.Location = new System.Drawing.Point(14, 249);
            this.dgvPago.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPago.Name = "dgvPago";
            this.dgvPago.RowHeadersWidth = 51;
            this.dgvPago.RowTemplate.Height = 24;
            this.dgvPago.Size = new System.Drawing.Size(853, 469);
            this.dgvPago.TabIndex = 9;
            // 
            // Pago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 735);
            this.Controls.Add(this.dgvPago);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.cbProyecto);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lbMonto);
            this.Controls.Add(this.lbProyecto);
            this.Controls.Add(this.lbCliente);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Pago";
            this.Text = "Pago";
            Load += Pago_Load;
            ((System.ComponentModel.ISupportInitialize)(this.dgvPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.Label lbProyecto;
        private System.Windows.Forms.Label lbMonto;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.ComboBox cbProyecto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvPago;
    }
}