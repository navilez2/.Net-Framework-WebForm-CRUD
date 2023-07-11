using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Pages
{
    public partial class Produto : System.Web.UI.Page
    {
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
            GridView gridProduto = (GridView)btnEditar.NamingContainer.NamingContainer;

            int index = ((GridViewRow)btnEditar.NamingContainer).DataItemIndex;

            int key = (int)((DataKey)gridProduto.DataKeys[index]).Value;

            hiddenKey.Value = key.ToString();

            dic.Add("@ID_PRODUTO", key);
            

            DataTable dt = new Controller().ExecuteSelectProcedure("SPS_PRODUTO", dic);

            txtModalNomeProduto.Text = dt.Rows[0]["DC_PRODUTO"].ToString();
            txtModalPrecoProduto.Text = dt.Rows[0]["VL_PRECO"].ToString();
            txtModalUnidadeMedidaProduto.Text = dt.Rows[0]["DC_UNIDADE_MEDIDA"].ToString();
            txtModalMarcaProduto.Text= dt.Rows[0]["DC_MARCA"].ToString();
            txtModalCategoriaProduto.Text = dt.Rows[0]["DC_CATEGORIA"].ToString();
            



            ScriptManager.RegisterStartupScript(this, GetType(), "myModal", "$('#myModal').modal('show');", true);
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnExcluir = sender as ImageButton;
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            GridView gridProduto = (GridView)btnExcluir.NamingContainer.NamingContainer;

            int index = ((GridViewRow)btnExcluir.NamingContainer).DataItemIndex;


            int key = (int)((DataKey)gridProduto.DataKeys[index]).Value;

            dic.Add("@ID_PRODUTO", key);


            new Controller().ExecuteProcedure("SPD_PRODUTO", dic);

            CarregarGridProduto();
        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();

            dic.Add("@DC_PRODUTO", txtNomeProduto.Text);
            dic.Add("@DC_MARCA", txtMarcaProduto.Text);
            dic.Add("@DC_CATEGORIA", txtCategoriaProduto.Text);
            dic.Add("@DC_UNIDADE_MEDIDA", txtUnidadeMedidaProduto.Text);
            dic.Add("@VL_PRECO", double.Parse(txtPrecoProduto.Text));
            new Controller().ExecuteProcedure("SPI_PRODUTO", dic);

            CarregarGridProduto();

        }

        protected void gridProduto_Init(object sender, EventArgs e)
        {
            CarregarGridProduto();
        }

        private void CarregarGridProduto()
        {
            GridView gridProduto = (GridView)pnlDados.FindControl("gridProduto");

            Dictionary<String, Object> dic = new Dictionary<String, Object>();

            dic.Add("@DC_PRODUTO", null);
            dic.Add("@DC_MARCA", null);
            dic.Add("@DC_CATEGORIA", null);
            dic.Add("@DC_UNIDADE_MEDIDA", null);

            gridProduto.DataSource = new Controller().ExecuteSelectProcedure("SPS_PRODUTO", dic);
            gridProduto.DataBind();
        }

        protected void gridProduto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProduto.PageIndex = e.NewPageIndex;
            CarregarGridProduto();
        }

        protected void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();

            dic.Add("@ID_PRODUTO", int.Parse(hiddenKey.Value));
            dic.Add("@DC_PRODUTO", txtModalNomeProduto.Text);
            dic.Add("@DC_MARCA", txtModalMarcaProduto.Text);
            dic.Add("@DC_CATEGORIA", txtModalCategoriaProduto.Text);
            dic.Add("@DC_UNIDADE_MEDIDA", txtModalUnidadeMedidaProduto.Text);
            dic.Add("@VL_PRECO", double.Parse(txtModalPrecoProduto.Text));
            new Controller().ExecuteProcedure("SPU_PRODUTO", dic);

            CarregarGridProduto();
        }
    }
}