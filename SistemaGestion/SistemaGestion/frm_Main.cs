using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionUI
{

    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            CargarDGV("Usuario");
        }

        private void CargarDGV(string entidad)
        {
            dgv_data.AutoGenerateColumns = true;
            switch (entidad)
            {
                case "Usuario":
                    List<Usuario> listaUsuario = UsuarioBussiness.ListarUsuarios();
                    dgv_data.DataSource = listaUsuario;
                    break;
                case "Producto":
                    List<Producto> listaProducto = ProductoBussiness.ListarProductos();
                    dgv_data.DataSource = listaProducto;
                    break;
                case "Venta":
                    List<Venta> listaVenta = VentaBussiness.ListarVentas();
                    dgv_data.DataSource = listaVenta;
                    break;
                case "ProductoVendido":
                    List<ProductoVendido> listaProductoVendido = ProductoVendidoBussiness.ListarProductoVendidos();
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
                frmUsuarioABM.FormClosed += Frm_Main_FormClosed;
                frmUsuarioABM.ShowDialog();
            }

            //Producto.
            if (rbtn_producto.Checked)
            {
                frm_Producto_ABM frmProductoABM = new frm_Producto_ABM();
                frmProductoABM.FormClosed += Frm_Main_FormClosed;
                frmProductoABM.ShowDialog();
            }

            //Venta.
            if (rbtn_venta.Checked)
            {
                frm_Venta_ABM frmVentaABM = new frm_Venta_ABM();
                frmVentaABM.FormClosed += Frm_Main_FormClosed;
                frmVentaABM.ShowDialog();
            }

            //Producto Vendido.
            if (rbtn_productovendido.Checked)
            {
                frm_ProductoVendido_ABM frmProductoVendidoABM = new frm_ProductoVendido_ABM();
                frmProductoVendidoABM.FormClosed += Frm_Main_FormClosed;
                frmProductoVendidoABM.ShowDialog();
            }
        }
        private void Frm_Main_FormClosed(object? sender, FormClosedEventArgs e)
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
                var usuario = UsuarioBussiness.ObtenerUsuario(id_usuario);

                frm_Usuario_ABM frmUsuarioABM = new frm_Usuario_ABM(usuario, 'M');
                frmUsuarioABM.FormClosed += Frm_Main_FormClosed;
                frmUsuarioABM.ShowDialog();
            }

            //Productos
            if (rbtn_producto.Checked)
            {
                long id_producto = (long)dgv_data.CurrentRow.Cells[0].Value;
                var producto = ProductoBussiness.ObtenerProducto(id_producto);

                frm_Producto_ABM frmProductoABM = new frm_Producto_ABM(producto, 'M');
                frmProductoABM.FormClosed += Frm_Main_FormClosed;
                frmProductoABM.ShowDialog();
            }

            //Venta
            if (rbtn_venta.Checked)
            {
                long id_venta = (long)dgv_data.CurrentRow.Cells[0].Value;
                var venta = VentaBussiness.ObtenerVenta(id_venta);

                frm_Venta_ABM frmVentaABM = new frm_Venta_ABM(venta, 'M');
                frmVentaABM.FormClosed += Frm_Main_FormClosed;
                frmVentaABM.ShowDialog();
            }

            //Producto Vendido
            if (rbtn_productovendido.Checked)
            {
                long id_productovendido = (long)dgv_data.CurrentRow.Cells[0].Value;
                var productovendido = ProductoVendidoBussiness.ObtenerProductoVendido(id_productovendido);

                frm_ProductoVendido_ABM frmProductoVendidoABM = new frm_ProductoVendido_ABM(productovendido, 'M');
                frmProductoVendidoABM.FormClosed += Frm_Main_FormClosed;
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
                var usuario = UsuarioBussiness.ObtenerUsuario(id_usuario);

                frm_Usuario_ABM frmUsuarioABM = new frm_Usuario_ABM(usuario, 'B');
                frmUsuarioABM.FormClosed += Frm_Main_FormClosed;
                frmUsuarioABM.ShowDialog();
            }

            //Productos
            if (rbtn_producto.Checked)
            {
                long id_producto = (long)dgv_data.CurrentRow.Cells[0].Value;
                var producto = ProductoBussiness.ObtenerProducto(id_producto);

                frm_Producto_ABM frmProductoABM = new frm_Producto_ABM(producto, 'B');
                frmProductoABM.FormClosed += Frm_Main_FormClosed;
                frmProductoABM.ShowDialog();
            }

            //Venta
            if (rbtn_venta.Checked)
            {
                long id_venta = (long)dgv_data.CurrentRow.Cells[0].Value;
                var venta = VentaBussiness.ObtenerVenta(id_venta);

                frm_Venta_ABM frmVentaABM = new frm_Venta_ABM(venta, 'B');
                frmVentaABM.FormClosed += Frm_Main_FormClosed;
                frmVentaABM.ShowDialog();
            }

            //Producto Vendido
            if (rbtn_productovendido.Checked)
            {
                long id_productovendido = (long)dgv_data.CurrentRow.Cells[0].Value;
                var productovendido = ProductoVendidoBussiness.ObtenerProductoVendido(id_productovendido);

                frm_ProductoVendido_ABM frmProductoVentidoABM = new frm_ProductoVendido_ABM(productovendido, 'B');
                frmProductoVentidoABM.FormClosed += Frm_Main_FormClosed;
                frmProductoVentidoABM.ShowDialog();
            }
        }
    }
}
