using System.Windows.Forms;

namespace SistemaGestionUI
{
    using SistemaGestionEntities;
    using SistemaGestionEntities.Responses;
    using SistemaGestionBussiness;

    public partial class frm_Producto_ABM : Form
    {
        private char abm;

        public frm_Producto_ABM()
        {
            InitializeComponent();
            abm = 'A';
        }
        public frm_Producto_ABM(Producto producto, char arg_abm)
        {
            InitializeComponent();
            abm = arg_abm;
            switch (abm)
            {
                case 'M':
                case 'B':
                    txtb_id.Text = producto.Id.ToString();
                    txtb_descripciones.Text = producto.Descripcion;
                    nud_costo.Text = producto.Costo.ToString();
                    nud_precioventa.Text = producto.PrecioVenta.ToString();
                    nud_stock.Text = producto.Stock.ToString();
                    txtb_idusuario.Text = producto.IdUsuario.ToString();
                    break;
            }
        }

        private void frm_Producto_Nuevo_Load(object sender, EventArgs e)
        {
            switch (abm)
            {
                case 'A':
                    this.Text = "Alta Producto.";
                    btn_accion.Text = "Crear.";
                    txtb_descripciones.ReadOnly = false;
                    nud_costo.ReadOnly = false;
                    nud_precioventa.ReadOnly = false;
                    nud_stock.ReadOnly = false;
                    txtb_idusuario.ReadOnly = false;
                    break;
                case 'B':
                    this.Text = "Borrar Producto.";
                    btn_accion.Text = "Borrar.";
                    txtb_descripciones.ReadOnly = true;
                    nud_costo.ReadOnly = true;
                    nud_precioventa.ReadOnly = true;
                    nud_stock.ReadOnly = true;
                    txtb_idusuario.ReadOnly = true;
                    break;
                case 'M':
                    this.Text = "Editar Producto.";
                    btn_accion.Text = "Guardar.";
                    txtb_descripciones.ReadOnly = false;
                    nud_costo.ReadOnly = false;
                    nud_precioventa.ReadOnly = false;
                    nud_stock.ReadOnly = false;
                    txtb_idusuario.ReadOnly = false;
                    break;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            ProductoResponse productoResponse = new ProductoResponse();
            string msj = "";

            try
            {
                switch (abm)
                {
                    case 'A':
                        producto.Descripcion = txtb_descripciones.Text;
                        producto.Costo = decimal.Parse(nud_costo.Text);
                        producto.PrecioVenta = decimal.Parse(nud_precioventa.Text);
                        producto.Stock = int.Parse(nud_stock.Text);
                        producto.IdUsuario = long.Parse(txtb_idusuario.Text);

                        productoResponse = ProductoBussiness.CrearProducto(producto);
                        msj = "Se insertaron los datos correctamente.";
                        break;
                    case 'B':
                        long id = long.Parse(txtb_id.Text);
                        productoResponse = ProductoBussiness.EliminarProducto(id);
                        msj = "Se borro el registro correctamente.";
                        break;
                    case 'M':
                        producto.Id = long.Parse(txtb_id.Text);
                        producto.Descripcion = txtb_descripciones.Text;
                        producto.Costo = decimal.Parse(nud_costo.Text);
                        producto.PrecioVenta = decimal.Parse(nud_precioventa.Text);
                        producto.Stock = int.Parse(nud_stock.Text);
                        producto.IdUsuario = long.Parse(txtb_idusuario.Text);

                        productoResponse = ProductoBussiness.ModificarProducto(producto);
                        msj = "Se actualizaron los datos correctamente.";
                        break;
                }

                if (productoResponse.Mensaje == "OK")
                {
                    MessageBox.Show(msj);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(productoResponse.Mensaje);
                }
            }
            catch (Exception ex) { throw; };
        }
    }
}
