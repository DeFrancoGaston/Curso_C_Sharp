using System.Windows.Forms;

namespace Segunda_Entrega
{
    using Segunda_Entrega.Classes;
    using Segunda_Entrega.DataServices;

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CargarDGV("Usuario");
        }

        private void CargarDGV(string entidad)
        {
            dgv_data.AutoGenerateColumns = true;
            switch (entidad)
            {
                case "Usuario":
                    List<Usuario> listaUsuario = UsuarioData.ListarUsuarios();
                    dgv_data.DataSource = listaUsuario;
                    break;
                case "Producto":
                    List<Producto> listaProducto = ProductoData.ListarProductos();
                    dgv_data.DataSource = listaProducto;
                    break;
                case "Venta":
                    List<Venta> listaVenta = VentaData.ListarVentas();
                    dgv_data.DataSource = listaVenta;
                    break;
                case "ProductoVendido":
                    List<ProductoVendido> listaProductoVendido = ProductoVendidoData.ListarProductosVendidos();
                    dgv_data.DataSource = listaProductoVendido;
                    break;
            }
        }

        private void rbtn_usuario_CheckedChanged(object sender, EventArgs e)
        {
            CargarDGV("Usuario");
        }

        private void rbtn_producto_CheckedChanged(object sender, EventArgs e)
        {
            CargarDGV("Producto");
        }

        private void rbtn_venta_CheckedChanged(object sender, EventArgs e)
        {
            CargarDGV("Venta");
        }

        private void rbtn_productovendido_CheckedChanged(object sender, EventArgs e)
        {
            CargarDGV("ProductoVendido");
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            //Usuario.
            if (rbtn_usuario.Checked)
            {
                frm_Usuario_ABM frmUsuarioABM = new frm_Usuario_ABM();
                frmUsuarioABM.FormClosed += FrmABM_FormClosed;
                frmUsuarioABM.ShowDialog();
            }

            //Producto.
            if (rbtn_producto.Checked)
            {
                frm_Producto_ABM frmProductoABM = new frm_Producto_ABM();
                frmProductoABM.FormClosed += FrmABM_FormClosed;
                frmProductoABM.ShowDialog();
            }

            //Venta.
            if (rbtn_venta.Checked)
            {
                frm_Venta_ABM frmVentaABM = new frm_Venta_ABM();
                frmVentaABM.FormClosed += FrmABM_FormClosed;
                frmVentaABM.ShowDialog();
            }

            //Producto Vendido.
            if (rbtn_productovendido.Checked)
            {
                frm_ProductoVendido_ABM frmProductoVendidoABM = new frm_ProductoVendido_ABM();
                frmProductoVendidoABM.FormClosed += FrmABM_FormClosed;
                frmProductoVendidoABM.ShowDialog();
            }
        }
        private void FrmABM_FormClosed(object? sender, FormClosedEventArgs e)
        {
            //Usuario.
            if (rbtn_usuario.Checked)
            {
                CargarDGV("Usuario");
            }

            //Producto.
            if (rbtn_producto.Checked)
            {
                CargarDGV("Producto");
            }

            //Venta.
            if (rbtn_venta.Checked)
            {
                CargarDGV("Venta");
            }

            //Producto Vendido.
            if (rbtn_productovendido.Checked)
            {
                CargarDGV("ProductoVendido");
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dgv_data.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 0) { return; };

            //Usuario
            if (rbtn_usuario.Checked)
            {
                long id_usuario = (long)dgv_data.CurrentRow.Cells[0].Value;
                var usuario = UsuarioData.ObtenerUsuario(id_usuario);

                frm_Usuario_ABM frmUsuarioABM = new frm_Usuario_ABM(usuario, 'M');
                frmUsuarioABM.FormClosed += FrmABM_FormClosed;
                frmUsuarioABM.ShowDialog();
            }

            //Productos
            if (rbtn_producto.Checked)
            {
                long id_producto = (long)dgv_data.CurrentRow.Cells[0].Value;
                var producto = ProductoData.ObtenerProducto(id_producto);

                frm_Producto_ABM frmProductoABM = new frm_Producto_ABM(producto, 'M');
                frmProductoABM.FormClosed += FrmABM_FormClosed;
                frmProductoABM.ShowDialog();
            }

            //Venta
            if (rbtn_venta.Checked)
            {
                long id_venta = (long)dgv_data.CurrentRow.Cells[0].Value;
                var venta = VentaData.ObtenerVenta(id_venta);

                frm_Venta_ABM frmVentaABM = new frm_Venta_ABM(venta, 'M');
                frmVentaABM.FormClosed += FrmABM_FormClosed;
                frmVentaABM.ShowDialog();
            }

            //Producto Vendido
            if (rbtn_productovendido.Checked)
            {
                long id_productovendido = (long)dgv_data.CurrentRow.Cells[0].Value;
                var productovendido = ProductoVendidoData.ObtenerProductoVendido(id_productovendido);

                frm_ProductoVendido_ABM frmProductoVendidoABM = new frm_ProductoVendido_ABM(productovendido, 'M');
                frmProductoVendidoABM.FormClosed += FrmABM_FormClosed;
                frmProductoVendidoABM.ShowDialog();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dgv_data.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 0) { return; };

            //Usuario
            if (rbtn_usuario.Checked)
            {
                long id_usuario = (long)dgv_data.CurrentRow.Cells[0].Value;
                var usuario = UsuarioData.ObtenerUsuario(id_usuario);

                frm_Usuario_ABM frmUsuarioABM = new frm_Usuario_ABM(usuario, 'B');
                frmUsuarioABM.FormClosed += FrmABM_FormClosed;
                frmUsuarioABM.ShowDialog();
            }

            //Productos
            if (rbtn_producto.Checked)
            {
                long id_producto = (long)dgv_data.CurrentRow.Cells[0].Value;
                var producto = ProductoData.ObtenerProducto(id_producto);

                frm_Producto_ABM frmProductoABM = new frm_Producto_ABM(producto, 'B');
                frmProductoABM.FormClosed += FrmABM_FormClosed;
                frmProductoABM.ShowDialog();
            }

            //Venta
            if (rbtn_venta.Checked)
            {
                long id_venta = (long)dgv_data.CurrentRow.Cells[0].Value;
                var venta = VentaData.ObtenerVenta(id_venta);

                frm_Venta_ABM frmVentaABM = new frm_Venta_ABM(venta, 'B');
                frmVentaABM.FormClosed += FrmABM_FormClosed;
                frmVentaABM.ShowDialog();
            }

            //Producto Vendido
            if (rbtn_productovendido.Checked)
            {
                long id_productovendido = (long)dgv_data.CurrentRow.Cells[0].Value;
                var productovendido = ProductoVendidoData.ObtenerProductoVendido(id_productovendido);

                frm_ProductoVendido_ABM frmProductoVentidoABM = new frm_ProductoVendido_ABM(productovendido, 'B');
                frmProductoVentidoABM.FormClosed += FrmABM_FormClosed;
                frmProductoVentidoABM.ShowDialog();
            }
        }
    }
}