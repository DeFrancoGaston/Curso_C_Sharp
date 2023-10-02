namespace Segunda_Entrega
{
    partial class frm_Usuario_ABM
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
            txtb_nombre = new TextBox();
            txtb_apellido = new TextBox();
            label1 = new Label();
            txtb_usuario = new TextBox();
            label2 = new Label();
            txtb_contraseña = new TextBox();
            label3 = new Label();
            txtb_mail = new TextBox();
            label4 = new Label();
            btn_accion = new Button();
            txtb_id = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_nombre.Location = new Point(56, 63);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(71, 20);
            lbl_nombre.TabIndex = 0;
            lbl_nombre.Text = "Nombre:";
            // 
            // txtb_nombre
            // 
            txtb_nombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_nombre.Location = new Point(133, 64);
            txtb_nombre.Name = "txtb_nombre";
            txtb_nombre.Size = new Size(223, 25);
            txtb_nombre.TabIndex = 1;
            // 
            // txtb_apellido
            // 
            txtb_apellido.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_apellido.Location = new Point(133, 102);
            txtb_apellido.Name = "txtb_apellido";
            txtb_apellido.Size = new Size(223, 25);
            txtb_apellido.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(56, 101);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 2;
            label1.Text = "Apellido:";
            // 
            // txtb_usuario
            // 
            txtb_usuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_usuario.Location = new Point(133, 137);
            txtb_usuario.Name = "txtb_usuario";
            txtb_usuario.Size = new Size(223, 25);
            txtb_usuario.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(56, 136);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 4;
            label2.Text = "Usuario:";
            // 
            // txtb_contraseña
            // 
            txtb_contraseña.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_contraseña.Location = new Point(133, 175);
            txtb_contraseña.Name = "txtb_contraseña";
            txtb_contraseña.Size = new Size(223, 25);
            txtb_contraseña.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(35, 175);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 6;
            label3.Text = "Contraseña:";
            // 
            // txtb_mail
            // 
            txtb_mail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtb_mail.Location = new Point(133, 210);
            txtb_mail.Name = "txtb_mail";
            txtb_mail.Size = new Size(223, 25);
            txtb_mail.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(80, 210);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 8;
            label4.Text = "Mail:";
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
            // frm_Usuario_Nuevo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 309);
            Controls.Add(txtb_id);
            Controls.Add(label5);
            Controls.Add(btn_accion);
            Controls.Add(txtb_mail);
            Controls.Add(label4);
            Controls.Add(txtb_contraseña);
            Controls.Add(label3);
            Controls.Add(txtb_usuario);
            Controls.Add(label2);
            Controls.Add(txtb_apellido);
            Controls.Add(label1);
            Controls.Add(txtb_nombre);
            Controls.Add(lbl_nombre);
            Name = "frm_Usuario_Nuevo";
            Text = "Usuario ABM.";
            Load += frm_Usuario_Nuevo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_nombre;
        private TextBox txtb_nombre;
        private TextBox txtb_apellido;
        private Label label1;
        private TextBox txtb_usuario;
        private Label label2;
        private TextBox txtb_contraseña;
        private Label label3;
        private TextBox txtb_mail;
        private Label label4;
        private Button btn_accion;
        private TextBox txtb_id;
        private Label label5;
    }
}