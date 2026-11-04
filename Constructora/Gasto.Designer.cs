namespace Constructora
{
    partial class Gasto
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
            this.lbDisenio = new System.Windows.Forms.Label();
            this.cbDisenio = new System.Windows.Forms.ComboBox();
            this.lbConcepto = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lbMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvGasto = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGasto)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDisenio
            // 
            this.lbDisenio.AutoSize = true;
            this.lbDisenio.Location = new System.Drawing.Point(14, 12);
            this.lbDisenio.Name = "lbDisenio";
            this.lbDisenio.Size = new System.Drawing.Size(55, 20);
            this.lbDisenio.TabIndex = 0;
            this.lbDisenio.Text = "Diseño";
            // 
            // cbDisenio
            // 
            this.cbDisenio.FormattingEnabled = true;
            this.cbDisenio.Location = new System.Drawing.Point(14, 41);
            this.cbDisenio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDisenio.Name = "cbDisenio";
            this.cbDisenio.Size = new System.Drawing.Size(228, 28);
            this.cbDisenio.TabIndex = 1;
            // 
            // lbConcepto
            // 
            this.lbConcepto.AutoSize = true;
            this.lbConcepto.Location = new System.Drawing.Point(262, 12);
            this.lbConcepto.Name = "lbConcepto";
            this.lbConcepto.Size = new System.Drawing.Size(73, 20);
            this.lbConcepto.TabIndex = 2;
            this.lbConcepto.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(262, 40);
            this.txtConcepto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(356, 27);
            this.txtConcepto.TabIndex = 3;
            // 
            // lbMonto
            // 
            this.lbMonto.AutoSize = true;
            this.lbMonto.Location = new System.Drawing.Point(646, 16);
            this.lbMonto.Name = "lbMonto";
            this.lbMonto.Size = new System.Drawing.Size(53, 20);
            this.lbMonto.TabIndex = 4;
            this.lbMonto.Text = "Monto";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(646, 40);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(114, 27);
            this.txtMonto.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(815, 40);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(86, 31);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(815, 80);
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
            this.btnEliminar.Location = new System.Drawing.Point(815, 119);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 31);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvGasto
            // 
            this.dgvGasto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGasto.Location = new System.Drawing.Point(14, 173);
            this.dgvGasto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvGasto.Name = "dgvGasto";
            this.dgvGasto.RowHeadersWidth = 51;
            this.dgvGasto.RowTemplate.Height = 24;
            this.dgvGasto.Size = new System.Drawing.Size(887, 411);
            this.dgvGasto.TabIndex = 9;
            // 
            // Gasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.dgvGasto);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lbMonto);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.lbConcepto);
            this.Controls.Add(this.cbDisenio);
            this.Controls.Add(this.lbDisenio);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Gasto";
            this.Text = "Gasto";
            this.Load += new System.EventHandler(this.Gasto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGasto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDisenio;
        private System.Windows.Forms.ComboBox cbDisenio;
        private System.Windows.Forms.Label lbConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label lbMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvGasto;
    }
}