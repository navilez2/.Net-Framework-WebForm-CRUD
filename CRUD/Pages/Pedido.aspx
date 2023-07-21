<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="CRUD.Pages.Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style>
        html, body {
            margin: 0;
            padding: 0;
            height: 100%;
        }
    </style>
    <%@ Register Src="~/Components/Card.ascx" TagName="Card" TagPrefix="uc" %>
    <link rel="stylesheet" type="text/css" href="../CSS/Pedido.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/Card.css" />
    
    
    <asp:Panel runat="server" class="containerPedido">
        <asp:Panel ID="pnlChildListProduto" runat="server" class="childListProduto">
        </asp:Panel>
        <asp:Panel runat="server" class=" childScreenPedido">
            <asp:Label runat="server" Font-Bold="true" Font-Size="XX-Large" Text="Pedido - Lista de Itens"></asp:Label>
            <asp:GridView runat="server">
            </asp:GridView>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
