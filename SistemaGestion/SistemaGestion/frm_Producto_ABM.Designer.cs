namespace SistemaGestionUI
{
    partial class frm_Producto_ABM
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
            lbl_descripciones = new Label();
            txtb_descripciones = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtb_idusuario = new TextBox();
            label4 = new Label();
            btn_accion = new Button();
            txtb_id = new TextBox();
            label5 = new Label();
            nud_costo = new NumericUpDown();
            nud_stock = new NumericUpDown();
            nud_precioventa = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nud_costo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_stock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_precioventa).BeginInit();
            SuspendLayout();
            // 
            // lbl_descripciones
            // 
            lbl_descripciones.AutoSize = true;
            lbl_descripciones.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_descripciones.Location = new Point(21, 65);
            lbl_descripciones.Name = "lbl_descripciones";
            lbl_descripciones.Size = new Size(102, 20);
            lbl_descripciones.TabIndex = 0;
            lbl_descripciones.Text = "Descripcione:";
            // 
            // txtb_descripciones
            // 
            txtb_descripciones.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_descripciones.Location = new Point(133, 64);
            txtb_descripciones.Name = "txtb_descripciones";
            txtb_descripciones.Size = new Size(223, 25);
            txtb_descripciones.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(70, 102);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 2;
            label1.Text = "Costo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(23, 138);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 4;
            label2.Text = "Precio Venta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(71, 176);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 6;
            label3.Text = "Stock:";
            // 
            // txtb_idusuario
            // 
            txtb_idusuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_idusuario.Location = new Point(133, 210);
            txtb_idusuario.Name = "txtb_idusuario";
            txtb_idusuario.Size = new Size(223, 25);
            txtb_idusuario.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(38, 211);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 8;
            label4.Text = "Id Usuario:";
            // 
            // btn_accion
            // 
            btn_accion.Location = new Point(195, 263);
            btn_accion.Name = "btn_accion";
            btn_accion.Size = new Size(75, 23);
            btn_accion.TabIndex = 6;
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
            // nud_costo
            // 
            nud_costo.DecimalPlaces = 2;
            nud_costo.Location = new Point(133, 102);
            nud_costo.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nud_costo.Name = "nud_costo";
            nud_costo.Size = new Size(223, 23);
            nud_costo.TabIndex = 2;
            // 
            // nud_stock
            // 
            nud_stock.Location = new Point(133, 173);
            nud_stock.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nud_stock.Name = "nud_stock";
            nud_stock.Size = new Size(223, 23);
            nud_stock.TabIndex = 4;
            // 
            // nud_precioventa
            // 
            nud_precioventa.DecimalPlaces = 2;
            nud_precioventa.Location = new Point(133, 135);
            nud_precioventa.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nud_precioventa.Name = "nud_precioventa";
            nud_precioventa.Size = new Size(223, 23);
            nud_precioventa.TabIndex = 3;
            // 
            // frm_Producto_ABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 309);
            Controls.Add(nud_precioventa);
            Controls.Add(nud_stock);
            Controls.Add(nud_costo);
            Controls.Add(txtb_id);
            Controls.Add(label5);
            Controls.Add(btn_accion);
            Controls.Add(txtb_idusuario);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtb_descripciones);
            Controls.Add(lbl_descripciones);
            Name = "frm_Producto_ABM";
            Text = "Producto ABM.";
            Load += frm_Producto_Nuevo_Load;
            ((System.ComponentModel.ISupportInitialize)nud_costo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_stock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_precioventa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_descripciones;
        private TextBox txtb_descripciones;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtb_idusuario;
        private Label label4;
        private Button btn_accion;
        private TextBox txtb_id;
        private Label label5;
        private NumericUpDown nud_costo;
        private NumericUpDown nud_stock;
        private NumericUpDown nud_precioventa;
    }
}