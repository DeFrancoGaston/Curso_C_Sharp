using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;
using SistemaGestionBussiness;

namespace SistemaGestionUI
{
    public partial class frm_Login : Form
    {
        bool ingresar_flag = false;

        public frm_Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreusr = txb_usuario.Text;
            string pass = txb_contraseña.Text;

            if (string.IsNullOrEmpty(nombreusr))
            {
                MessageBox.Show("Ingrese un usuario válido.");
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Ingrese una contraseña válida.");
                return;
            }

            try
            {
                UsuarioResponse usuarioResponse = UsuarioBussiness.IniciarSesion(nombreusr, pass);

                if (usuarioResponse.Mensaje == "OK")
                {
                    ingresar_flag = true;
                    frm_Main frm_main = new frm_Main(this);
                    frm_main.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Usuario/Contraseña incorrectos.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(ingresar_flag))
            {
                Application.Exit();
            }
        }

        private void txb_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txb_contraseña.Focus();
            }
        }

        private void txb_contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
