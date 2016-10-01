<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="EditarPet.aspx.cs" Inherits="TI_ClinicaVeterinaria.EditarPet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">

  
   <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="512px" Width="717px">
        <h1>Edição de Pets</h1>
        <h3>Dados do Cliente</h3>
        <ul>
            <li>
                <asp:Label Text="Nome Cliente" ID="label9" runat="server"></asp:Label>
                <asp:TextBox ID="NomeCliente" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Button ID="pesqCliente" CssClass="btn btnAdd" runat="server" Text="Pesquisar" OnClick="pesqCliente_Click" />
            </li>
            <li style="display: block">
                <asp:Label Text="Código Cliente" ID="label16" runat="server"></asp:Label>
                <asp:TextBox ID="IDCliente" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            </ul>
            <hr />
            <br />
            <h3>Dados do Pet</h3>
        <ul>
            <li style="display: none">
                <asp:Label Text="ID" ID="label6" runat="server"></asp:Label>
                <asp:TextBox ID="id_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="Nome" ID="label4" runat="server"></asp:Label>
                <asp:TextBox ID="nome_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label5" runat="server" Text="Peso"></asp:Label>
                <asp:TextBox ID="peso_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label7" runat="server" Text="Altura"></asp:Label>
                <asp:TextBox ID="altura_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label8" runat="server" Text="Tipo Animal"></asp:Label>
                <asp:DropDownList ID="listAnimais" runat="server">
                </asp:DropDownList>
            </li>
            
            <li>
                <asp:Button ID="bntAtualizar" CssClass="btn btnEdit" runat="server" 
                    Text="Atualizar" OnClick="bntAtualizar_Click" />
            </li>
            <li>
                <asp:Button ID="btnExcluir" CssClass="btn btnEdit" runat="server" 
                    Text="Excluir"/>
            </li>
            <li>
                <asp:LinkButton ID="lnkVoltar" CssClass="btn btnEdit" runat="server" PostBackUrl="~/Views/PesquisaPet.aspx" Text="Voltar" />
            </li>
            </ul>
   </asp:Panel>


 
   
</asp:Content>
