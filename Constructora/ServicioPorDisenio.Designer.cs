namespace Constructora
{
    partial class ServicioPorDisenio
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
            this.cmbDisenio = new System.Windows.Forms.ComboBox();
            this.lbProveedorServicio = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbDuracion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDisenio
            // 
            this.lbDisenio.AutoSize = true;
            this.lbDisenio.Location = new System.Drawing.Point(12, 9);
            this.lbDisenio.Name = "lbDisenio";
            this.lbDisenio.Size = new System.Drawing.Size(151, 20);
            this.lbDisenio.TabIndex = 0;
            this.lbDisenio.Text = "Seleccione un diseño.";
            // 
            // cmbDisenio
            // 
            this.cmbDisenio.FormattingEnabled = true;
            this.cmbDisenio.Location = new System.Drawing.Point(16, 32);
            this.cmbDisenio.Name = "cmbDisenio";
            this.cmbDisenio.Size = new System.Drawing.Size(221, 28);
            this.cmbDisenio.TabIndex = 1;
            // 
            // lbProveedorServicio
            // 
            this.lbProveedorServicio.AutoSize = true;
            this.lbProveedorServicio.Location = new System.Drawing.Point(12, 72);
            this.lbProveedorServicio.Name = "lbProveedorServicio";
            this.lbProveedorServicio.Size = new System.Drawing.Size(228, 20);
            this.lbProveedorServicio.TabIndex = 2;
            this.lbProveedorServicio.Text = "Seleccione el proveedor/servicio.";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 28);
            this.comboBox1.TabIndex = 3;
            // 
            // lbDuracion
            // 
            this.lbDuracion.AutoSize = true;
            this.lbDuracion.Location = new System.Drawing.Point(12, 139);
            this.lbDuracion.Name = "lbDuracion";
            this.lbDuracion.Size = new System.Drawing.Size(164, 20);
            this.lbDuracion.TabIndex = 4;
            this.lbDuracion.Text = "Duración (por semana).";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(16, 162);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(221, 27);
            this.txtDuracion.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(16, 214);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(131, 36);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ServicioPorDisenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.lbDuracion);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbProveedorServicio);
            this.Controls.Add(this.cmbDisenio);
            this.Controls.Add(this.lbDisenio);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ServicioPorDisenio";
            this.Text = "Servicio por diseño";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDisenio;
        private System.Windows.Forms.ComboBox cmbDisenio;
        private System.Windows.Forms.Label lbProveedorServicio;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbDuracion;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button button1;
    }
}