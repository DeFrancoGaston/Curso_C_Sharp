using System.Windows.Forms;

namespace Segunda_Entrega
{
    using Segunda_Entrega.Classes;
    using Segunda_Entrega.DataServices;

    public partial class frm_Usuario_ABM : Form
    {
        private char abm;
        public frm_Usuario_ABM()
        {
            InitializeComponent();
            abm = 'A';
        }
        public frm_Usuario_ABM(Usuario usuario, char arg_abm)
        {
            InitializeComponent();
            abm = arg_abm;
            switch (abm)
            {
                case 'M':
                case 'B':
                    txtb_id.Text = usuario.Id.ToString();
                    txtb_nombre.Text = usuario.Nombre;
                    txtb_apellido.Text = usuario.Apellido;
                    txtb_usuario.Text = usuario.NombreUsuario;
                    txtb_contraseña.Text = usuario.Contraseña;
                    txtb_mail.Text = usuario.Mail;
                    break;
            }
        }

        private void frm_Usuario_Nuevo_Load(object sender, EventArgs e)
        {
            switch (abm)
            {
                case 'A':
                    this.Text = "Alta Usuario.";
                    btn_accion.Text = "Crear.";
                    txtb_nombre.ReadOnly = false;
                    txtb_apellido.ReadOnly = false;
                    txtb_usuario.ReadOnly = false;
                    txtb_contraseña.ReadOnly = false;
                    txtb_mail.ReadOnly = false;
                    break;
                case 'B':
                    this.Text = "Borrar Usuario.";
                    btn_accion.Text = "Borrar.";
                    txtb_nombre.ReadOnly = true;
                    txtb_apellido.ReadOnly = true;
                    txtb_usuario.ReadOnly = true;
                    txtb_contraseña.ReadOnly = true;
                    txtb_mail.ReadOnly = true;
                    break;
                case 'M':
                    this.Text = "Editar Usuario.";
                    btn_accion.Text = "Guardar.";
                    txtb_nombre.ReadOnly = false;
                    txtb_apellido.ReadOnly = false;
                    txtb_usuario.ReadOnly = false;
                    txtb_contraseña.ReadOnly = false;
                    txtb_mail.ReadOnly = false;
                    break;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                
                switch (abm)
                {
                    case 'A':
                        usuario.Nombre = txtb_nombre.Text;
                        usuario.Apellido = txtb_apellido.Text;
                        usuario.NombreUsuario = txtb_usuario.Text;
                        usuario.Contraseña = txtb_contraseña.Text;
                        usuario.Mail = txtb_mail.Text;

                        UsuarioData.CrearUsuario(usuario);
                        break;
                    case 'B':
                        long id = long.Parse(txtb_id.Text);
                        UsuarioData.EliminarUsuario(id);
                        break;
                    case 'M':
                        usuario.Id = long.Parse(txtb_id.Text);
                        usuario.Nombre = txtb_nombre.Text;
                        usuario.Apellido = txtb_apellido.Text;
                        usuario.NombreUsuario = txtb_usuario.Text;
                        usuario.Contraseña = txtb_contraseña.Text;
                        usuario.Mail = txtb_mail.Text;
 
                        UsuarioData.ModificarUsuario(usuario);
                        break;
                }
            }
            catch (Exception ex) { throw; };

            this.Close();
        }

    }
}
