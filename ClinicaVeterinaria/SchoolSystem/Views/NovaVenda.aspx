<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="NovaVenda.aspx.cs" Inherits="TI_ClinicaVeterinaria.NovaVenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">

  
   <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="512px" Width="717px">
        <h1>Nova Venda</h1>
        <h3>Dados da Venda</h3>
        <ul>
            <li>
                <asp:Label Text="Data" ID="label1" runat="server"></asp:Label>
                <asp:TextBox ID="data_venda" Text="" CssClass="radiusInput" runat="server" 
                    ReadOnly="True" OnTextChanged="data_venda_TextChanged"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="Horário" ID="label2" runat="server"></asp:Label>
                <asp:TextBox ID="horario_venda" Text="" CssClass="radiusInput" runat="server" 
                    ReadOnly="True"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="Vendedor" ID="label3" runat="server"></asp:Label>
                <asp:TextBox ID="vendedor_venda" Text="" CssClass="radiusInput" runat="server" 
                    ReadOnly="True"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="Valor Total" ID="label4" runat="server"></asp:Label>
                <asp:TextBox ID="valor_venda" Text="" CssClass="radiusInput" runat="server" 
                    ReadOnly="True"></asp:TextBox>
            </li>
            </ul>
            <hr />
            <br />
            <h3>Produtos</h3>
        <ul>
        <li>
                <asp:Label Text="Produto" ID="label9" runat="server"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">1 - Shampoo anti-pulga</asp:ListItem>
                    <asp:ListItem Value="2">2 - Ração purina</asp:ListItem>
                    <asp:ListItem Value="2">3 - Ração especial</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <asp:Label Text="Quantidade" ID="label5" runat="server"></asp:Label>
                <asp:TextBox ID="quantidade_prod" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Button ID="incluirItem" CssClass="btn btnAdd" runat="server" Text="Incluir" OnClick="incluirItem_Click" />
            </li>
 
            </ul>
   </asp:Panel>


 
   
</asp:Content>
