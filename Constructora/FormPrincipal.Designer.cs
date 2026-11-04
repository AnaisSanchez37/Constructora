namespace Constructora
{
    partial class FormPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnArquitecto = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnProveedor = new System.Windows.Forms.Button();
            this.btnProyecto = new System.Windows.Forms.Button();
            this.btnGasto = new System.Windows.Forms.Button();
            this.btnPago = new System.Windows.Forms.Button();
            this.btnDisenio = new System.Windows.Forms.Button();
            this.btnServicio = new System.Windows.Forms.Button();
            this.btnServicio_Disenio = new System.Windows.Forms.Button();
            this.btnProveedor_Servicio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Haga clic en un botón para acceder a las operaciones de la tabla:";
            // 
            // btnArquitecto
            // 
            this.btnArquitecto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArquitecto.Location = new System.Drawing.Point(35, 99);
            this.btnArquitecto.Name = "btnArquitecto";
            this.btnArquitecto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnArquitecto.Size = new System.Drawing.Size(121, 37);
            this.btnArquitecto.TabIndex = 1;
            this.btnArquitecto.Text = "Arquitecto";
            this.btnArquitecto.UseVisualStyleBackColor = true;
            this.btnArquitecto.Click += new System.EventHandler(this.btnArquitecto_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCliente.Location = new System.Drawing.Point(191, 99);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(121, 37);
            this.btnCliente.TabIndex = 2;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedor.Location = new System.Drawing.Point(352, 99);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(121, 37);
            this.btnProveedor.TabIndex = 3;
            this.btnProveedor.Text = "Proveedor";
            this.btnProveedor.UseVisualStyleBackColor = true;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // btnProyecto
            // 
            this.btnProyecto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProyecto.Location = new System.Drawing.Point(516, 99);
            this.btnProyecto.Name = "btnProyecto";
            this.btnProyecto.Size = new System.Drawing.Size(121, 37);
            this.btnProyecto.TabIndex = 5;
            this.btnProyecto.Text = "Proyecto";
            this.btnProyecto.UseVisualStyleBackColor = true;
            this.btnProyecto.Click += new System.EventHandler(this.btnProyecto_Click);
            // 
            // btnGasto
            // 
            this.btnGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGasto.Location = new System.Drawing.Point(352, 172);
            this.btnGasto.Name = "btnGasto";
            this.btnGasto.Size = new System.Drawing.Size(121, 37);
            this.btnGasto.TabIndex = 7;
            this.btnGasto.Text = "Gasto";
            this.btnGasto.UseVisualStyleBackColor = true;
            this.btnGasto.Click += new System.EventHandler(this.btnGasto_Click);
            // 
            // btnPago
            // 
            this.btnPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPago.Location = new System.Drawing.Point(516, 172);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(121, 37);
            this.btnPago.TabIndex = 8;
            this.btnPago.Text = "Pago";
            this.btnPago.UseVisualStyleBackColor = true;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // btnDisenio
            // 
            this.btnDisenio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisenio.Location = new System.Drawing.Point(35, 172);
            this.btnDisenio.Name = "btnDisenio";
            this.btnDisenio.Size = new System.Drawing.Size(121, 37);
            this.btnDisenio.TabIndex = 9;
            this.btnDisenio.Text = "Diseño";
            this.btnDisenio.UseVisualStyleBackColor = true;
            this.btnDisenio.Click += new System.EventHandler(this.btnDisenio_Click);
            // 
            // btnServicio
            // 
            this.btnServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicio.Location = new System.Drawing.Point(191, 172);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(121, 37);
            this.btnServicio.TabIndex = 10;
            this.btnServicio.Text = "Servicio";
            this.btnServicio.UseVisualStyleBackColor = true;
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click);
            // 
            // btnServicio_Disenio
            // 
            this.btnServicio_Disenio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicio_Disenio.Location = new System.Drawing.Point(35, 242);
            this.btnServicio_Disenio.Name = "btnServicio_Disenio";
            this.btnServicio_Disenio.Size = new System.Drawing.Size(151, 37);
            this.btnServicio_Disenio.TabIndex = 11;
            this.btnServicio_Disenio.Text = "Servicio por Diseño";
            this.btnServicio_Disenio.UseVisualStyleBackColor = true;
            // 
            // btnProveedor_Servicio
            // 
            this.btnProveedor_Servicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedor_Servicio.Location = new System.Drawing.Point(222, 242);
            this.btnProveedor_Servicio.Name = "btnProveedor_Servicio";
            this.btnProveedor_Servicio.Size = new System.Drawing.Size(151, 37);
            this.btnProveedor_Servicio.TabIndex = 13;
            this.btnProveedor_Servicio.Text = "Proveedor Servicio";
            this.btnProveedor_Servicio.UseVisualStyleBackColor = true;
            this.btnProveedor_Servicio.Click += new System.EventHandler(this.btnProveedorServicio_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 450);
            this.Controls.Add(this.btnProveedor_Servicio);
            this.Controls.Add(this.btnServicio_Disenio);
            this.Controls.Add(this.btnServicio);
            this.Controls.Add(this.btnDisenio);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.btnGasto);
            this.Controls.Add(this.btnProyecto);
            this.Controls.Add(this.btnProveedor);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.btnArquitecto);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnArquitecto;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnProveedor;
        private System.Windows.Forms.Button btnProyecto;
        private System.Windows.Forms.Button btnGasto;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.Button btnDisenio;
        private System.Windows.Forms.Button btnServicio;
        private System.Windows.Forms.Button btnServicio_Disenio;
        private System.Windows.Forms.Button btnProveedor_Servicio;
    }
}



