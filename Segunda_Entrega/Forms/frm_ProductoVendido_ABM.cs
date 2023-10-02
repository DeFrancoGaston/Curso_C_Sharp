using System.Windows.Forms;

namespace Segunda_Entrega
{
    using Segunda_Entrega.Classes;
    using Segunda_Entrega.DataServices;

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

                switch (abm)
                {
                    case 'A':
                        productovendido.Stock = int.Parse(nud_stock.Text);
                        productovendido.IdProducto = long.Parse(txtb_IdProducto.Text);
                        productovendido.IdVenta = long.Parse(txtb_IdVenta.Text);

                        ProductoVendidoData.CrearProductoVendido(productovendido);
                        break;
                    case 'B':
                        long id = long.Parse(txtb_id.Text);
                        ProductoVendidoData.EliminarProductoVendido(id);
                        break;
                    case 'M':
                        productovendido.Id = long.Parse(txtb_id.Text);
                        productovendido.Stock = int.Parse(nud_stock.Text);
                        productovendido.IdProducto = long.Parse(txtb_IdProducto.Text);
                        productovendido.IdVenta = long.Parse(txtb_IdVenta.Text);

                        ProductoVendidoData.ModificarProductoVendido(productovendido);
                        break;
                }
            }
            catch (Exception ex) { throw; };

            this.Close();
        }

    }
}
