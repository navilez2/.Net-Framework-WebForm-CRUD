using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CRUD.Pages
{
    public partial class Produto : System.Web.UI.Page
    {
        protected SiteMaster master { get { return (SiteMaster)this.Master; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
            }
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnEditar = sender as ImageButton;
            Dictionary<String, Object> dic = new Dictionary<String, Object>();

            try
            {
                GridView gridProduto = (GridView)btnEditar.NamingContainer.NamingContainer;

                int index = ((GridViewRow)btnEditar.NamingContainer).DataItemIndex;
                int key = (int)((DataKey)gridProduto.DataKeys[index]).Value;

                hiddenKey.Value = key.ToString();

                dic.Add("@ID_PRODUTO", key);

                DataTable dt = new Controller().ExecuteSelectProcedure("SPS_PRODUTO", dic);

                txtModalNomeProduto.Text = dt.Rows[0]["DC_PRODUTO"].ToString();
                txtModalPrecoProduto.Text = dt.Rows[0]["VL_PRECO"].ToString();
                txtModalUnidadeMedidaProduto.Text = dt.Rows[0]["DC_UNIDADE_MEDIDA"].ToString();
                txtModalMarcaProduto.Text = dt.Rows[0]["DC_MARCA"].ToString();
                txtModalCategoriaProduto.Text = dt.Rows[0]["DC_CATEGORIA"].ToString();

                ScriptManager.RegisterStartupScript(this, GetType(), "myModal", "$('#myModal').modal('show');", true);
            }
            catch(Exception ex)
            {
                master.ErrorModal(ex.Message);
            }
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnExcluir = sender as ImageButton;
            Dictionary<String, Object> dic = new Dictionary<String, Object>();

            try
            {
                GridView gridProduto = (GridView)btnExcluir.NamingContainer.NamingContainer;

                int index = ((GridViewRow)btnExcluir.NamingContainer).DataItemIndex;
                int key = (int)((DataKey)gridProduto.DataKeys[index]).Value;

                dic.Add("@ID_PRODUTO", key);

                new Controller().ExecuteProcedure("SPD_PRODUTO", dic);

                CarregarGridProduto();
            }
            catch (Exception ex)
            {
                master.ErrorModal(ex.Message);
            }
        }
        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            if (Page.IsValid)
            {
                try
                {
                    double preco;

                    double.TryParse(txtPrecoProduto.Text, out preco);

                    dic.Add("@DC_PRODUTO", txtNomeProduto.Text);
                    dic.Add("@DC_MARCA", txtMarcaProduto.Text);
                    dic.Add("@DC_CATEGORIA", txtCategoriaProduto.Text);
                    dic.Add("@DC_UNIDADE_MEDIDA", txtUnidadeMedidaProduto.Text);
                    dic.Add("@VL_PRECO", preco);
                    new Controller().ExecuteProcedure("SPI_PRODUTO", dic);
                    CarregarGridProduto();
                    limpaCampos();
                    master.ShowMessageOnTop("Produto cadastrado com sucesso!", "success");
                    master.ErrorModal("adw");

                }
                catch (Exception ex)
                {
                    master.ErrorModal(ex.Message);
                }

            }

        }

        protected void gridProduto_Init(object sender, EventArgs e)
        {
            try
            {
                CarregarGridProduto();
            }
            catch (Exception ex)
            {
                master.ErrorModal(ex.Message);
            }
        }

        private void CarregarGridProduto()
        {
            GridView gridProduto = (GridView)pnlDados.FindControl("gridProduto");

            Dictionary<String, Object> dic = new Dictionary<String, Object>();

            try
            {
                dic.Add("@DC_PRODUTO", null);
                dic.Add("@DC_MARCA", null);
                dic.Add("@DC_CATEGORIA", null);
                dic.Add("@DC_UNIDADE_MEDIDA", null);

                gridProduto.DataSource = new Controller().ExecuteSelectProcedure("SPS_PRODUTO", dic);
                gridProduto.DataBind();
            }
            catch(Exception ex) 
            { 
                master.ErrorModal(ex.Message); 
            }
        }

        protected void gridProduto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProduto.PageIndex = e.NewPageIndex;
                CarregarGridProduto();
            }
            catch(Exception ex)
            {
                master.ErrorModal(ex.Message);
            }
        }

        protected void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            double preco;

            try
            {
                double.TryParse(txtPrecoProduto.Text, out preco);

                dic.Add("@ID_PRODUTO", int.Parse(hiddenKey.Value));
                dic.Add("@DC_PRODUTO", txtModalNomeProduto.Text);
                dic.Add("@DC_MARCA", txtModalMarcaProduto.Text);
                dic.Add("@DC_CATEGORIA", txtModalCategoriaProduto.Text);
                dic.Add("@DC_UNIDADE_MEDIDA", txtModalUnidadeMedidaProduto.Text);
                dic.Add("@VL_PRECO", preco);
                new Controller().ExecuteProcedure("SPU_PRODUTO", dic);

                CarregarGridProduto();
            }
            catch(Exception ex)
            {
                master.ErrorModal(ex.Message);
            }
        }
        protected void limpaCampos()
        {
            txtCategoriaProduto.Text= string.Empty;
            txtMarcaProduto.Text= string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtPrecoProduto.Text = string.Empty;
        }
    }
}