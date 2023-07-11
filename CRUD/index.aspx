<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" type="text/css" href="../CSS/index.css" />

    <div class="jumbotron container-apresentacao text-wrap" >
        <h1>Gerenciamento de Pedidos</h1>
        <p class="lead">Este projeto tem como objetivo demonstrar minhas habilidades com o ASP.NET Web Forms. Para isso, utilizaremos como exemplo um CRUD para gerenciamento de pedidos.</p>
        <p><asp:HyperLink runat="server" NavigateUrl="~/Pages/Produto.aspx" class="btn btn-dark btn-lg" >Vamos lá? &raquo;</asp:HyperLink></p>
        
    </div>

</asp:Content>
