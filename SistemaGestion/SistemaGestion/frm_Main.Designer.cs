namespace SistemaGestionUI
{
    partial class frm_Main
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
            btn_editar = new Button();
            btn_eliminar = new Button();
            btn_nuevo = new Button();
            dgv_data = new DataGridView();
            rbtn_productovendido = new RadioButton();
            rbtn_venta = new RadioButton();
            rbtn_producto = new RadioButton();
            rbtn_usuario = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgv_data).BeginInit();
            SuspendLayout();
            // 
            // btn_editar
            // 
            btn_editar.Location = new Point(713, 68);
            btn_editar.Name = "btn_editar";
            btn_editar.Size = new Size(75, 23);
            btn_editar.TabIndex = 15;
            btn_editar.Text = "Editar.";
            btn_editar.UseVisualStyleBackColor = true;
            btn_editar.Click += btn_editar_Click;
            // 
            // btn_eliminar
            // 
            btn_eliminar.Location = new Point(713, 97);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(75, 23);
            btn_eliminar.TabIndex = 14;
            btn_eliminar.Text = "Eliminar.";
            btn_eliminar.UseVisualStyleBackColor = true;
            btn_eliminar.Click += btn_eliminar_Click;
            // 
            // btn_nuevo
            // 
            btn_nuevo.Location = new Point(713, 39);
            btn_nuevo.Name = "btn_nuevo";
            btn_nuevo.Size = new Size(75, 23);
            btn_nuevo.TabIndex = 13;
            btn_nuevo.Text = "Nuevo.";
            btn_nuevo.UseVisualStyleBackColor = true;
            btn_nuevo.Click += btn_nuevo_Click;
            // 
            // dgv_data
            // 
            dgv_data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_data.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_data.Location = new Point(12, 39);
            dgv_data.MultiSelect = false;
            dgv_data.Name = "dgv_data";
            dgv_data.ReadOnly = true;
            dgv_data.RowTemplate.Height = 25;
            dgv_data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_data.Size = new Size(681, 398);
            dgv_data.TabIndex = 12;
            // 
            // rbtn_productovendido
            // 
            rbtn_productovendido.AutoSize = true;
            rbtn_productovendido.Location = new Point(301, 14);
            rbtn_productovendido.Name = "rbtn_productovendido";
            rbtn_productovendido.Size = new Size(123, 19);
            rbtn_productovendido.TabIndex = 11;
            rbtn_productovendido.Text = "Producto Vendido.";
            rbtn_productovendido.UseVisualStyleBackColor = true;
            rbtn_productovendido.CheckedChanged += rbtn_productovendido_CheckedChanged;
            // 
            // rbtn_venta
            // 
            rbtn_venta.AutoSize = true;
            rbtn_venta.Location = new Point(213, 14);
            rbtn_venta.Name = "rbtn_venta";
            rbtn_venta.Size = new Size(57, 19);
            rbtn_venta.TabIndex = 10;
            rbtn_venta.Text = "Venta.";
            rbtn_venta.UseVisualStyleBackColor = true;
            rbtn_venta.CheckedChanged += rbtn_venta_CheckedChanged;
            // 
            // rbtn_producto
            // 
            rbtn_producto.AutoSize = true;
            rbtn_producto.Location = new Point(115, 14);
            rbtn_producto.Name = "rbtn_producto";
            rbtn_producto.Size = new Size(77, 19);
            rbtn_producto.TabIndex = 9;
            rbtn_producto.Text = "Producto.";
            rbtn_producto.UseVisualStyleBackColor = true;
            rbtn_producto.CheckedChanged += rbtn_producto_CheckedChanged;
            // 
            // rbtn_usuario
            // 
            rbtn_usuario.AutoSize = true;
            rbtn_usuario.Checked = true;
            rbtn_usuario.Location = new Point(24, 14);
            rbtn_usuario.Name = "rbtn_usuario";
            rbtn_usuario.Size = new Size(68, 19);
            rbtn_usuario.TabIndex = 8;
            rbtn_usuario.TabStop = true;
            rbtn_usuario.Text = "Usuario.";
            rbtn_usuario.UseVisualStyleBackColor = true;
            rbtn_usuario.CheckedChanged += rbtn_usuario_CheckedChanged;
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_editar);
            Controls.Add(btn_eliminar);
            Controls.Add(btn_nuevo);
            Controls.Add(dgv_data);
            Controls.Add(rbtn_productovendido);
            Controls.Add(rbtn_venta);
            Controls.Add(rbtn_producto);
            Controls.Add(rbtn_usuario);
            Name = "frm_Main";
            Text = "Sistema Gestión";
            FormClosed += frm_Main_FormClosed_1;
            Load += frm_Main_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_data).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_editar;
        private Button btn_eliminar;
        private Button btn_nuevo;
        private DataGridView dgv_data;
        private RadioButton rbtn_productovendido;
        private RadioButton rbtn_venta;
        private RadioButton rbtn_producto;
        private RadioButton rbtn_usuario;
    }
}