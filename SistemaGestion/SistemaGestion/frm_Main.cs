using SistemaGestionBussiness;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;
using System.Security.Cryptography;

namespace SistemaGestionUI
{

    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        public frm_Main(frm_Login frm_login)
        {
            InitializeComponent();

            frm_login.Close();
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
                    UsuarioResponse usuarioResponse = UsuarioBussiness.ListarUsuarios();

                    if (usuarioResponse.Mensaje == "OK")
                    {
                        dgv_data.DataSource = usuarioResponse.Usuarios;
                    }
                    else
                    {
                        MessageBox.Show(usuarioResponse.Mensaje);
                    }
                    break;
                case "Producto":
                    ProductoResponse productoResponse = ProductoBussiness.ListarProductos();

                    if (productoResponse.Mensaje == "OK")
                    {
                        dgv_data.DataSource = productoResponse.Productos;
                    }
                    else
                    {
                        MessageBox.Show(productoResponse.Mensaje);
                    }
                    break;
                case "Venta":
                    VentaResponse ventaResponse = VentaBussiness.ListarVentas();

                    if (ventaResponse.Mensaje == "OK")
                    {
                        dgv_data.DataSource = ventaResponse.Ventas;
                    }
                    else
                    {
                        MessageBox.Show(ventaResponse.Mensaje);
                    }
                    break;
                case "ProductoVendido":
                    ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.ListarProductoVendidos();

                    if (productoVendidoResponse.Mensaje == "OK")
                    {
                        dgv_data.DataSource = productoVendidoResponse.ProductosVendidos;
                    }
                    else
                    {
                        MessageBox.Show(productoVendidoResponse.Mensaje);
                    }
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
                UsuarioResponse usuarioResponse = UsuarioBussiness.ObtenerUsuario(id_usuario);

                if (usuarioResponse.Mensaje == "OK")
                {
                    frm_Usuario_ABM frmUsuarioABM = new frm_Usuario_ABM(usuarioResponse.Usuario, 'M');
                    frmUsuarioABM.FormClosed += Frm_Main_FormClosed;
                    frmUsuarioABM.ShowDialog();
                }
            }

            //Productos
            if (rbtn_producto.Checked)
            {
                long id_producto = (long)dgv_data.CurrentRow.Cells[0].Value;
                ProductoResponse productoResponse = ProductoBussiness.ObtenerProducto(id_producto);

                if (productoResponse.Mensaje == "OK")
                {
                    frm_Producto_ABM frmProductoABM = new frm_Producto_ABM(productoResponse.Producto, 'M');
                    frmProductoABM.FormClosed += Frm_Main_FormClosed;
                    frmProductoABM.ShowDialog();
                }
            }

            //Venta
            if (rbtn_venta.Checked)
            {
                long id_venta = (long)dgv_data.CurrentRow.Cells[0].Value;
                VentaResponse ventaResponse = VentaBussiness.ObtenerVenta(id_venta);

                frm_Venta_ABM frmVentaABM = new frm_Venta_ABM(ventaResponse.Venta, 'M');
                frmVentaABM.FormClosed += Frm_Main_FormClosed;
                frmVentaABM.ShowDialog();
            }

            //Producto Vendido
            if (rbtn_productovendido.Checked)
            {
                long id_productovendido = (long)dgv_data.CurrentRow.Cells[0].Value;
                ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.ObtenerProductoVendido(id_productovendido);

                if (productoVendidoResponse.Mensaje == "OK")
                {
                    frm_ProductoVendido_ABM frmProductoVendidoABM = new frm_ProductoVendido_ABM(productoVendidoResponse.ProductoVendido, 'M');
                    frmProductoVendidoABM.FormClosed += Frm_Main_FormClosed;
                    frmProductoVendidoABM.ShowDialog();
                }
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
                UsuarioResponse usuarioResponse = UsuarioBussiness.ObtenerUsuario(id_usuario);

                if (usuarioResponse.Mensaje == "OK")
                {
                    frm_Usuario_ABM frmUsuarioABM = new frm_Usuario_ABM(usuarioResponse.Usuario, 'B');
                    frmUsuarioABM.FormClosed += Frm_Main_FormClosed;
                    frmUsuarioABM.ShowDialog();
                }
            }

            //Productos
            if (rbtn_producto.Checked)
            {
                long id_producto = (long)dgv_data.CurrentRow.Cells[0].Value;
                ProductoResponse productoResponse = ProductoBussiness.ObtenerProducto(id_producto);

                if (productoResponse.Mensaje == "OK")
                {
                    frm_Producto_ABM frmProductoABM = new frm_Producto_ABM(productoResponse.Producto, 'B');
                    frmProductoABM.FormClosed += Frm_Main_FormClosed;
                    frmProductoABM.ShowDialog();
                }
            }

            //Venta
            if (rbtn_venta.Checked)
            {
                long id_venta = (long)dgv_data.CurrentRow.Cells[0].Value;
                VentaResponse ventaResponse = VentaBussiness.ObtenerVenta(id_venta);

                if (ventaResponse.Mensaje == "OK")
                {
                    frm_Venta_ABM frmVentaABM = new frm_Venta_ABM(ventaResponse.Venta, 'B');
                    frmVentaABM.FormClosed += Frm_Main_FormClosed;
                    frmVentaABM.ShowDialog();
                }
            }

            //Producto Vendido
            if (rbtn_productovendido.Checked)
            {
                long id_productovendido = (long)dgv_data.CurrentRow.Cells[0].Value;
                ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.ObtenerProductoVendido(id_productovendido);

                if (productoVendidoResponse.Mensaje == "OK")
                {
                    frm_ProductoVendido_ABM frmProductoVentidoABM = new frm_ProductoVendido_ABM(productoVendidoResponse.ProductoVendido, 'B');
                    frmProductoVentidoABM.FormClosed += Frm_Main_FormClosed;
                    frmProductoVentidoABM.ShowDialog();
                }
            }
        }

        private void frm_Main_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
