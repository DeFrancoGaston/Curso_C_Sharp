namespace SistemaGestionUI
{
    partial class frm_ProductoVendido_ABM
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
            lbl_nombre = new Label();
            txtb_IdProducto = new TextBox();
            label1 = new Label();
            txtb_IdVenta = new TextBox();
            label2 = new Label();
            btn_accion = new Button();
            txtb_id = new TextBox();
            label5 = new Label();
            nud_stock = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nud_stock).BeginInit();
            SuspendLayout();
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_nombre.Location = new Point(71, 65);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(52, 20);
            lbl_nombre.TabIndex = 0;
            lbl_nombre.Text = "Stock:";
            // 
            // txtb_IdProducto
            // 
            txtb_IdProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_IdProducto.Location = new Point(133, 102);
            txtb_IdProducto.Name = "txtb_IdProducto";
            txtb_IdProducto.Size = new Size(223, 25);
            txtb_IdProducto.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(28, 107);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 2;
            label1.Text = "Id Producto:";
            // 
            // txtb_IdVenta
            // 
            txtb_IdVenta.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_IdVenta.Location = new Point(133, 137);
            txtb_IdVenta.Name = "txtb_IdVenta";
            txtb_IdVenta.Size = new Size(223, 25);
            txtb_IdVenta.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(52, 138);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 4;
            label2.Text = "Id Venta:";
            // 
            // btn_accion
            // 
            btn_accion.Location = new Point(195, 263);
            btn_accion.Name = "btn_accion";
            btn_accion.Size = new Size(75, 23);
            btn_accion.TabIndex = 4;
            btn_accion.Text = "Accion.";
            btn_accion.UseVisualStyleBackColor = true;
            btn_accion.Click += btn_guardar_Click;
            // 
            // txtb_id
            // 
            txtb_id.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_id.Location = new Point(133, 26);
            txtb_id.Name = "txtb_id";
            txtb_id.ReadOnly = true;
            txtb_id.Size = new Size(223, 25);
            txtb_id.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(96, 26);
            label5.Name = "label5";
            label5.Size = new Size(27, 20);
            label5.TabIndex = 11;
            label5.Text = "Id:";
            // 
            // nud_stock
            // 
            nud_stock.Location = new Point(133, 65);
            nud_stock.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nud_stock.Name = "nud_stock";
            nud_stock.Size = new Size(223, 23);
            nud_stock.TabIndex = 1;
            // 
            // frm_ProductoVendido_ABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 309);
            Controls.Add(nud_stock);
            Controls.Add(txtb_id);
            Controls.Add(label5);
            Controls.Add(btn_accion);
            Controls.Add(txtb_IdVenta);
            Controls.Add(label2);
            Controls.Add(txtb_IdProducto);
            Controls.Add(label1);
            Controls.Add(lbl_nombre);
            Name = "frm_ProductoVendido_ABM";
            Text = "Producto Vendido ABM.";
            Load += frm_ProductoVendido_Nuevo_Load;
            ((System.ComponentModel.ISupportInitialize)nud_stock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_nombre;
        private TextBox txtb_IdProducto;
        private Label label1;
        private TextBox txtb_IdVenta;
        private Label label2;
        private Button btn_accion;
        private TextBox txtb_id;
        private Label label5;
        private NumericUpDown nud_stock;
    }
}