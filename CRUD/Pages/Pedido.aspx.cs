using CRUD.Components;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Pages
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected SiteMaster master { get { return (SiteMaster)this.Master; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                master.AlertModal("ATENÇÃO!!", "Esta página ainda está em desenvolvimento, e seus controles podem não funcionar corretamente. No entanto, deixo-a disponibilizada para que a evolução seja acompanhada.");
            }
            Card card = new Card(pnlChildListProduto)
            {
                TitleFieldName = "DC_PRODUTO",
                DescriptionFieldName = "DC_MARCA",
                KeyFieldName = "ID_PRODUTO",
                DataSource = new Controller().ExecuteSelectProcedure("SPS_PRODUTO", new Dictionary<string, object>())
            };
            card.DataBind();
        }
    }
}