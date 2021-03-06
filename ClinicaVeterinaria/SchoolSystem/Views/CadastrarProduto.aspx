﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="CadastrarProduto.aspx.cs" Inherits="TI_ClinicaVeterinaria.CadastrarProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">

  
   <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="512px" Width="717px">
        <h1>Cadastro de Produtos</h1>
        <ul>
            <li>
                <asp:Label Text="IDProduto" ID="label6" runat="server">Código do Produto</asp:Label>
                <asp:TextBox ID="id_prod" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="NomeProduto" ID="label4" runat="server">Descrição </asp:Label>
                <asp:TextBox ID="nome_prod" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label5" runat="server" Text="Valor">Valor do Produto</asp:Label>
                <asp:TextBox ID="valor_prod" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Button ID="bntAdd" CssClass="btn btnAdd" runat="server" Text="Cadastrar Produto" OnClick="bntAdd_Click" />
            </li>
            </ul>       
   </asp:Panel>


 
   
</asp:Content>
