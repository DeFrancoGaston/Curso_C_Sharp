using System.Windows.Forms;

namespace SistemaGestionUI
{
    using SistemaGestionEntities;
    using SistemaGestionBussiness;
    using SistemaGestionEntities.Responses;

    public partial class frm_ProductoVendido_ABM : Form
    {
        private char abm;
        public frm_ProductoVendido_ABM()
        {
            InitializeComponent();
            abm = 'A';
        }
        public frm_ProductoVendido_ABM(ProductoVendido productovendido, char arg_abm)
        {
            InitializeComponent();
            abm = arg_abm;
            switch (abm)
            {
                case 'M':
                case 'B':
                    txtb_id.Text = productovendido.Id.ToString();
                    nud_stock.Text = productovendido.Stock.ToString();
                    txtb_IdProducto.Text = productovendido.IdProducto.ToString();
                    txtb_IdVenta.Text = productovendido.IdVenta.ToString();
                    break;
            }
        }

        private void frm_ProductoVendido_Nuevo_Load(object sender, EventArgs e)
        {
            switch (abm)
            {
                case 'A':
                    this.Text = "Alta Producto Vendido.";
                    btn_accion.Text = "Crear.";
                    nud_stock.ReadOnly = false;
                    txtb_IdProducto.ReadOnly = false;
                    txtb_IdVenta.ReadOnly = false;
                    break;
                case 'B':
                    this.Text = "Borrar Producto Vendido.";
                    btn_accion.Text = "Borrar.";
                    nud_stock.ReadOnly = true;
                    txtb_IdProducto.ReadOnly = true;
                    txtb_IdVenta.ReadOnly = true;
                    break;
                case 'M':
                    this.Text = "Editar Producto Vendido.";
                    btn_accion.Text = "Guardar.";
                    nud_stock.ReadOnly = false;
                    txtb_IdProducto.ReadOnly = false;
                    txtb_IdVenta.ReadOnly = false;
                    break;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoVendido productovendido = new ProductoVendido();
                ProductoVendidoResponse productoVendidoResponse = new ProductoVendidoResponse();
                string msj = "";

                switch (abm)
                {
                    case 'A':
                        productovendido.Stock = int.Parse(nud_stock.Text);
                        productovendido.IdProducto = long.Parse(txtb_IdProducto.Text);
                        productovendido.IdVenta = long.Parse(txtb_IdVenta.Text);

                        productoVendidoResponse = ProductoVendidoBussiness.CrearProductoVendido(productovendido);
                        msj = "Se insertaron los datos correctamente.";
                        break;
                    case 'B':
                        long id = long.Parse(txtb_id.Text);
                        productoVendidoResponse = ProductoVendidoBussiness.EliminarProductoVendido(id);
                        msj = "Se borro el registro correctamente.";
                        break;
                    case 'M':
                        productovendido.Id = long.Parse(txtb_id.Text);
                        productovendido.Stock = int.Parse(nud_stock.Text);
                        productovendido.IdProducto = long.Parse(txtb_IdProducto.Text);
                        productovendido.IdVenta = long.Parse(txtb_IdVenta.Text);

                        productoVendidoResponse = ProductoVendidoBussiness.ModificarProductoVendido(productovendido);
                        msj = "Se actualizaron los datos correctamente.";
                        break;
                }
                if (productoVendidoResponse.Mensaje == "OK")
                {
                    MessageBox.Show(msj);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(productoVendidoResponse.Mensaje);
                }
            }
            catch (Exception ex) { throw; };
        }

    }
}
