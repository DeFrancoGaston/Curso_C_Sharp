﻿using System.Windows.Forms;

namespace SistemaGestionUI
{
    using SistemaGestionEntities;
    using SistemaGestionEntities.Responses;
    using SistemaGestionBussiness;

    public partial class frm_Venta_ABM : Form
    {
        private char abm;
        public frm_Venta_ABM()
        {
            InitializeComponent();
            abm = 'A';
        }
        public frm_Venta_ABM(Venta venta, char arg_abm)
        {
            InitializeComponent();
            abm = arg_abm;
            switch (abm)
            {
                case 'M':
                case 'B':
                    txtb_id.Text = venta.Id.ToString();
                    txtb_comentarios.Text = venta.Comentarios;
                    txtb_idusuario.Text = venta.IdUsuario.ToString();
                    break;
            }
        }

        private void frm_Venta_Nuevo_Load(object sender, EventArgs e)
        {
            switch (abm)
            {
                case 'A':
                    this.Text = "Alta Venta.";
                    btn_accion.Text = "Crear.";
                    txtb_comentarios.ReadOnly = false;
                    txtb_idusuario.ReadOnly = false;
                    break;
                case 'B':
                    this.Text = "Borrar Venta.";
                    btn_accion.Text = "Borrar.";
                    txtb_comentarios.ReadOnly = true;
                    txtb_idusuario.ReadOnly = true;
                    break;
                case 'M':
                    this.Text = "Editar Venta.";
                    btn_accion.Text = "Guardar.";
                    txtb_comentarios.ReadOnly = false;
                    txtb_idusuario.ReadOnly = false;
                    break;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Venta venta = new Venta();
                VentaResponse ventaResponse = new VentaResponse();
                string msj = "";

                switch (abm)
                {
                    case 'A':
                        venta.Comentarios = txtb_comentarios.Text;
                        venta.IdUsuario = long.Parse(txtb_idusuario.Text);

                        ventaResponse = VentaBussiness.CrearVenta(venta);
                        msj = "Se insertaron los datos correctamente.";
                        break;
                    case 'B':
                        long id = long.Parse(txtb_id.Text);
                        ventaResponse = VentaBussiness.EliminarVenta(id);
                        msj = "Se borro el registro correctamente.";
                        break;
                    case 'M':
                        venta.Id = long.Parse(txtb_id.Text);
                        venta.Comentarios = txtb_comentarios.Text;
                        venta.IdUsuario = long.Parse(txtb_idusuario.Text);

                        ventaResponse = VentaBussiness.ModificarVenta(venta);
                        msj = "Se actualizaron los datos correctamente.";
                        break;
                }
                if (ventaResponse.Mensaje == "OK")
                {
                    MessageBox.Show(msj);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ventaResponse.Mensaje);
                }
            }
            catch (Exception ex) { throw; };
        }

    }
}
