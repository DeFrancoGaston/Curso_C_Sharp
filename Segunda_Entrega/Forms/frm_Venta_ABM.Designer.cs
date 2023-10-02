namespace Segunda_Entrega
{
    partial class frm_Venta_ABM
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
            txtb_comentarios = new TextBox();
            txtb_idusuario = new TextBox();
            label1 = new Label();
            btn_accion = new Button();
            txtb_id = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_nombre.Location = new Point(21, 69);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(102, 20);
            lbl_nombre.TabIndex = 0;
            lbl_nombre.Text = "Comentarios:";
            // 
            // txtb_comentarios
            // 
            txtb_comentarios.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_comentarios.Location = new Point(133, 64);
            txtb_comentarios.Name = "txtb_comentarios";
            txtb_comentarios.Size = new Size(223, 25);
            txtb_comentarios.TabIndex = 1;
            // 
            // txtb_idusuario
            // 
            txtb_idusuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_idusuario.Location = new Point(133, 102);
            txtb_idusuario.Name = "txtb_idusuario";
            txtb_idusuario.Size = new Size(223, 25);
            txtb_idusuario.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(38, 107);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 2;
            label1.Text = "Id Usuario:";
            // 
            // btn_accion
            // 
            btn_accion.Location = new Point(195, 263);
            btn_accion.Name = "btn_accion";
            btn_accion.Size = new Size(75, 23);
            btn_accion.TabIndex = 10;
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
            // frm_Venta_ABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 309);
            Controls.Add(txtb_id);
            Controls.Add(label5);
            Controls.Add(btn_accion);
            Controls.Add(txtb_idusuario);
            Controls.Add(label1);
            Controls.Add(txtb_comentarios);
            Controls.Add(lbl_nombre);
            Name = "frm_Venta_ABM";
            Text = "Venta ABM.";
            Load += frm_Venta_Nuevo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_nombre;
        private TextBox txtb_comentarios;
        private TextBox txtb_idusuario;
        private Label label1;
        private Button btn_accion;
        private TextBox txtb_id;
        private Label label5;
    }
}