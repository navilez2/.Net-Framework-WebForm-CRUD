using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;

namespace CRUD.Components
{
    public partial class Card : System.Web.UI.UserControl
    {
        public DataTable DataSource { get; set; }
        public string TitleFieldName { get; set; }
        public string DescriptionFieldName { get; set; }
        public string KeyFieldName { get; set; }
        private Panel _CardContainer { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        public Card(Panel cardContainer)
        {
            this._CardContainer= cardContainer;
        }
        public override void DataBind()
        {
            foreach(DataRow row in DataSource.Rows)
            {
                Panel card = CreateCard(row[TitleFieldName].ToString(), row[DescriptionFieldName].ToString(), row[KeyFieldName].ToString(), "~/images/noImage.png", DataSource.Rows.IndexOf(row));
                _CardContainer.Controls.Add(card);                
            }         
        }
        private Panel CreateCard(string titleText, string titleDescription, string key, string imageURL, int seq)
        {
            Panel pnlCard = new Panel { ID= "pnlCard#" + seq.ToString() , ClientIDMode = ClientIDMode.Static, CssClass= "card panelCard" };
            Panel pnlCardBody= new Panel { ID = "pnlCardBody#" + seq.ToString(), ClientIDMode = ClientIDMode.Static };
            Panel pnlCardImage= new Panel { ID = "pnlCardImage#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, CssClass = "card-img-top" };
            Panel pnlCarBodyText= new Panel { ID = "pnlCarBodyText#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, CssClass = "cardBodyText row" };
            Panel pnlCardQuantidade = new Panel { ID = "pnlCardQuantidade#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, CssClass = "cardQuantidadePanel" };

            Image imgImagem= new Image { ID = "imgImagem#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, CssClass = "card-img-top",Height = Unit.Percentage(50), ImageUrl= imageURL };
            Label lblTitulo= new Label { ID = "lblTitulo#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, CssClass= "cardTitle", Text= titleText };
            Label lblDescricao = new Label { ID = "lblDescricao#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, CssClass = "cardDescription", Text = titleDescription };
            HiddenField hiddenID = new HiddenField { ID = "hiddenID#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, Value = key };
            Button btoAdicionar = new Button { ID = "btoAdicionar#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, Visible = true, Text = "Adicionar", CssClass = "btn btn-success btnCard" };
            Button btoRemover = new Button { ID = "btoRemover#" + seq.ToString(), ClientIDMode = ClientIDMode.Static, Visible = false, Text = "Remover", CssClass = "btn btn-danger btnCard" };
            TextBox txtQuantidade = new TextBox { ID = "txtQuantidade" + seq.ToString(), ClientIDMode = ClientIDMode.Static, TextMode = TextBoxMode.Number, CssClass = "form-control cardTxtQuantidade"};

            txtQuantidade.Attributes["min"] = "0";
            txtQuantidade.Attributes["value"] = "0";

            pnlCardImage.Controls.Add(imgImagem);
            pnlCardBody.Controls.Add(pnlCardImage);
            pnlCarBodyText.Controls.Add(lblTitulo);
            pnlCarBodyText.Controls.Add(lblDescricao);
            pnlCardBody.Controls.Add(pnlCarBodyText);
            pnlCardBody.Controls.Add(hiddenID);

            pnlCard.Controls.Add(pnlCardBody);
            pnlCard.Controls.Add(txtQuantidade);
            pnlCardQuantidade.Controls.Add(txtQuantidade);
            pnlCardQuantidade.Controls.Add(btoAdicionar);
            pnlCardQuantidade.Controls.Add(btoRemover);
            pnlCard.Controls.Add(pnlCardQuantidade);

            return pnlCard;
        }

    }
}