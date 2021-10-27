using Datos;
using Datos.Admin;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTransportes
{
    public partial class vistaAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDropdown();
                mostrarAutos();
            }
        }

        private void mostrarAutos()
        {
            gridAuto.DataSource = AdmAuto.Listar();
            gridAuto.DataBind();
        }

        private void llenarDropdown()
        {
            DataTable dt = AdmAuto.ListarMarcas();
            ddlMarca.DataSource = dt;
            ddlMarca.DataTextField = dt.Columns["Marca"].ToString();

            ddlMarca.DataBind();

           
            ddlBuscarAutosPorMarca.DataSource = dt;
            ddlBuscarAutosPorMarca.DataTextField = dt.Columns["Marca"].ToString();
            DataRow fila = dt.NewRow();
            fila["Marca"] = "TODAS";
            dt.Rows.InsertAt(fila, 0);

            ddlBuscarAutosPorMarca.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarAuto();
        }

        private void guardarAuto()
        {
            Auto auto = new Auto(ddlMarca.SelectedValue, txtModelo.Text, txtMatricula.Text, Decimal.Parse(txtPrecio.Text));


            int filasAfectadas = AdmAuto.Insertar(auto);

            if (filasAfectadas > 0)
            {
                mostrarAutos();
                borrarCampos();
            }
        }

        private void borrarCampos()
        {
            txtModelo.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            modificarAuto();
        }

        private void modificarAuto()
        {
            Auto autoModificado = new Auto(int.Parse(txtId.Text),ddlMarca.SelectedValue, txtModelo.Text, txtMatricula.Text, Decimal.Parse(txtPrecio.Text));


            int filasAfectadas = AdmAuto.Modificar(autoModificado);

            if (filasAfectadas > 0)
            {
                mostrarAutos();
                borrarCampos();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarAuto();
        }

        private void eliminarAuto()
        {
            int autoEliminar = int.Parse(txtId.Text);

            int filasAfectadas = AdmAuto.Eliminar(autoEliminar);

            if (filasAfectadas > 0)
            {
                mostrarAutos();
                borrarCampos();
            }
        }

        protected void ddlBuscarAutosPorMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string marca = ddlBuscarAutosPorMarca.SelectedValue;

            if(marca == "TODAS")
            {
                mostrarAutos();
            }
            else
            {
                gridAuto.DataSource = AdmAuto.Listar(marca);
                gridAuto.DataBind();
            }
            
        }
    }
}