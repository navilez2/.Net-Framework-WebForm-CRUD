<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="CRUD.Pages.Produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/JavaScript/TabPage.js"></script>
    <%--seção de cadastro--%>

    <div id='divCadastro' style="margin: 1.5rem;" class="collapse show">
        <div id="tabPage" class="m-3">
            <div id="tabPageHeader">
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <button class="nav-link active" aria-current="page" data-type="header-button"
                            data-target="content1" data-default-page="true">
                            Cadastro de Produto</button>
                    </li>
                </ul>
            </div>
            <div id="tabPageContent" style="" class="">
                <div class="collapse collapse-vertical show" id="content1" data-type="page">
                    <div style="margin-top: 10px; display: flex; justify-content: flex-start">
                        <div>
                            <label for="txtNomeProduto">Nome do produto</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNomeProduto" class="form-control" placeholder="Ex.: Coca-Cola 2l" ValidationGroup="CadastroValidation"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="CadastroValidation" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtNomeProduto" ErrorMessage="Campo obrigatório." />
                        </div>
                        <div style="margin-left: 20px">
                            <label for="txtUnidadeMedidaProduto">Medida</label>
                            <asp:DropDownList runat="server" ClientIDMode="Static" ID="txtUnidadeMedidaProduto" class="form-control" placeholder="Medida" ValidationGroup="CadastroValidation">
                                <asp:ListItem>Un</asp:ListItem>
                                <asp:ListItem>Cx</asp:ListItem>
                                <asp:ListItem>Kg</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="CadastroValidation" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtUnidadeMedidaProduto" ErrorMessage="Campo obrigatório." />
                        </div>
                        <div style="margin-left: 20px">
                            <label for="txtPrecoProduto">Preço</label>
                            <asp:TextBox runat="server" onblur="" ClientIDMode="Static" ID="txtPrecoProduto" class="form-control" Width="80px" placeholder="Ex.:0,00" ValidationGroup="CadastroValidation"></asp:TextBox>
                            <%--<div class="row">
                                <asp:RegularExpressionValidator ID="regexPrecoProduto" ValidationGroup="CadastroValidation" runat="server" ForeColor="Red" ControlToValidate="txtPrecoProduto"
                                    ErrorMessage="O campo deve ser um valor numérico." ValidationExpression="^[0-9]+([,.][0-9]+)?$" />
                                <asp:RequiredFieldValidator ValidationGroup="CadastroValidation" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtPrecoProduto" ErrorMessage="Campo obrigatório." />
                            </div>--%>
                        </div>
                    </div>
                    <div style="display: flex; justify-content: flex-start">
                        <div>
                            <label for="txtCategoriaProduto">Categoria do produto</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtCategoriaProduto" class="form-control" placeholder="Ex.: Refrigerante" ValidationGroup="CadastroValidation"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="CadastroValidation" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtCategoriaProduto" ErrorMessage="Campo obrigatório." />
                        </div>
                        <div style="margin-left: 20px; text-align: left">
                            <label for="txtMarcaProduto">Marca do produto</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ValidateRequestMode="Enabled" ID="txtMarcaProduto" class="form-control" placeholder="Ex.: Coca-Cola" ValidationGroup="CadastroValidation"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="CadastroValidation" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtMarcaProduto" ErrorMessage="Campo obrigatório." />
                        </div>
                    </div>
                    <div style="margin-top: 10px; display: flex; justify-content: flex-start">
                        <asp:Button runat="server" ClientIDMode="Static" ID="btnCadastrarProduto" Text="Cadastrar" CssClass="btn btn-dark" Width="100px" ValidationGroup="CadastroValidation" OnClick="btnCadastrarProduto_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <button id="btoDivCadastro" class="btn btn-dark" type="button" data-bs-toggle="collapse"
        data-bs-target="#divCadastro" aria-expanded="true" aria-controls="divCadastro"
        style="width: 100%; border-radius: 0%; height: 29px; padding: 0; background-color: transparent; border-bottom: 1px solid #DEE2E6; border-top: none; border-left: none; border-right: none; color: black;">
        ▲
    </button>

    <%--seção de visualização--%>
    <asp:Panel runat="server" ID="pnlDados" Style="margin: 1.5rem">
        <asp:GridView ID="gridProduto" ClientIDMode="Static" AllowPaging="true" PageSize="10" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" DataKeyNames="ID_PRODUTO" runat="server" class="table table-hover table-bordered table-responsive table-border-factor" OnInit="gridProduto_Init"  OnPageIndexChanging="gridProduto_PageIndexChanging">
            <HeaderStyle CssClass="table-dark " />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Ação
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/images/icon-edit.png" AlternateText="Editar" CssClass="icon"  OnClick="btnEditar_Click" />
                        <asp:ImageButton ID="btnExcluir" CausesValidation="false" runat="server" ImageUrl="~/images/icon-bin.png" AlternateText="Excluir" CssClass="icon"  OnClick="btnExcluir_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="60px" />
                </asp:TemplateField>
                <asp:BoundField DataField="ID_PRODUTO" HeaderText="Produto" Visible="false" />
                <asp:BoundField DataField="DC_PRODUTO" SortExpression="DC_PRODUTO" HeaderText="Produto" />
                <asp:BoundField DataField="DC_MARCA" SortExpression="DC_MARCA" HeaderText="Marca" />
                <asp:BoundField DataField="DC_CATEGORIA" SortExpression="DC_CATEGORIA" HeaderText="Categoria" />
                <asp:BoundField DataField="DC_UNIDADE_MEDIDA" SortExpression="DC_UNIDADE_MEDIDA" HeaderStyle-Width="60px" HeaderText="Un.Medida" />
                <asp:BoundField DataField="VL_PRECO" SortExpression="VL_PRECO" HeaderStyle-Width="90px" DataFormatString="{0:N}" HeaderText="Preço" />
                <asp:BoundField DataField="DT_ALTERACAO" SortExpression="DT_ALTERACAO" HeaderText="Última Alteração" HeaderStyle-Width="160px" />
            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
            <PagerStyle CssClass="pagination justify-content-center custom-pagination" />
        </asp:GridView>
    </asp:Panel>



    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Edição</h5>
                    <button type="button" class="btn-close close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hiddenKey" />

                    <div style="margin-top: 10px; display: flex; justify-content: flex-start">
                        <div>
                            <label for="txtModalNomeProduto">Nome do produto</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtModalNomeProduto" class="form-control" ValidationGroup="ModalUpdateValidation" placeholder="Ex.: Coca-Cola 2l"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="ModalUpdateValidation" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtModalNomeProduto" ErrorMessage="Campo obrigatório." />
                        </div>
                        <div style="margin-left: 20px">
                            <label for="txtModalUnidadeMedidaProduto">Medida</label>
                            <asp:DropDownList runat="server" ClientIDMode="Static" ID="txtModalUnidadeMedidaProduto" class="form-control" placeholder="Medida">
                                <asp:ListItem>Un</asp:ListItem>
                                <asp:ListItem>Cx</asp:ListItem>
                                <asp:ListItem>Kg</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div style="margin-left: 20px">
                            <label for="txtModalPrecoProduto">Preço</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtModalPrecoProduto" onblur="validarNumeroDecimal('txtModalPrecoProduto','btnSalvarAlteracao')" class="form-control" Width="80px" placeholder="Ex.:0,00" ValidationGroup="ModalUpdateValidation"></asp:TextBox>
                            <div class="row">
                                <asp:RegularExpressionValidator ID="regexModalPrecoProduto" runat="server" ForeColor="Red" ControlToValidate="txtModalPrecoProduto"
                                    ErrorMessage="O campo deve ser um valor numérico." ValidationExpression="^[0-9]+([,.][0-9]+)?$" />
                                <asp:RequiredFieldValidator ValidationGroup="ModalUpdateValidation" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtModalPrecoProduto" ErrorMessage="Campo obrigatório." />
                            </div>
                        </div>
                    </div>
                    <div style="display: flex; justify-content: flex-start">
                        <div>
                            <label for="txtModalCategoriaProduto">Categoria do produto</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtModalCategoriaProduto" class="form-control" placeholder="Ex.: Refrigerante" ValidationGroup="ModalUpdateValidation"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="ModalUpdateValidation" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtModalCategoriaProduto" ErrorMessage="Campo obrigatório." />
                        </div>
                        <div style="margin-left: 20px">
                            <label for="txtModalMarcaProduto">Marca do produto</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtModalMarcaProduto" class="form-control" placeholder="Ex.: Coca-Cola" ValidationGroup="ModalUpdateValidation"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="ModalUpdateValidation" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" runat="server" ControlToValidate="txtModalMarcaProduto" ErrorMessage="Campo obrigatório." />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    <asp:Button runat="server" ClientIDMode="Static" ID="btnSalvarAlteracao" type="button" class="btn btn-primary" Text="Salvar" ValidationGroup="ModalUpdateValidation" OnClick="btnSalvarAlteracao_Click" />
                </div>
            </div>
        </div>
    </div>

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const tabPage = new TabPage(document.getElementById('tabPage'))
            tabPage.Init();
        })

        divCadastro.addEventListener('hidden.bs.collapse', function () {
            btoDivCadastro.textContent = '▼'
        });
        divCadastro.addEventListener('shown.bs.collapse', function () {
            btoDivCadastro.textContent = '▲'
        });



    </script>
</asp:Content>
