namespace SistemaGestionUI
{
    partial class frm_Login
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
            btn_ingresar = new Button();
            btn_salir = new Button();
            label1 = new Label();
            label2 = new Label();
            txb_usuario = new TextBox();
            txb_contraseña = new TextBox();
            SuspendLayout();
            // 
            // btn_ingresar
            // 
            btn_ingresar.Location = new Point(69, 169);
            btn_ingresar.Name = "btn_ingresar";
            btn_ingresar.Size = new Size(75, 23);
            btn_ingresar.TabIndex = 3;
            btn_ingresar.Text = "Ingresar.";
            btn_ingresar.UseVisualStyleBackColor = true;
            btn_ingresar.Click += button1_Click;
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(220, 169);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(75, 23);
            btn_salir.TabIndex = 4;
            btn_salir.Text = "Salir.";
            btn_salir.UseVisualStyleBackColor = true;
            btn_salir.Click += btn_salir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 58);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuario:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 111);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 3;
            label2.Text = "Contraseña:";
            // 
            // txb_usuario
            // 
            txb_usuario.Location = new Point(135, 55);
            txb_usuario.Name = "txb_usuario";
            txb_usuario.Size = new Size(160, 23);
            txb_usuario.TabIndex = 1;
            txb_usuario.TextChanged += txb_usuario_TextChanged;
            txb_usuario.KeyDown += txb_usuario_KeyDown;
            // 
            // txb_contraseña
            // 
            txb_contraseña.Location = new Point(135, 108);
            txb_contraseña.Name = "txb_contraseña";
            txb_contraseña.PasswordChar = '*';
            txb_contraseña.Size = new Size(160, 23);
            txb_contraseña.TabIndex = 2;
            txb_contraseña.KeyDown += txb_contraseña_KeyDown;
            // 
            // frm_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 223);
            Controls.Add(txb_contraseña);
            Controls.Add(txb_usuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_salir);
            Controls.Add(btn_ingresar);
            Name = "frm_Login";
            Text = "Sistema Gestion.";
            FormClosed += frm_Login_FormClosed;
            Load += frm_Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_ingresar;
        private Button btn_salir;
        private Label label1;
        private Label label2;
        private TextBox txb_usuario;
        private TextBox txb_contraseña;
    }
}