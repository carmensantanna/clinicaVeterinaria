<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master.Master" CodeBehind="MovimentoEstoque.aspx.cs" Inherits="TI_ClinicaVeterinaria.MovimentoEstoque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
   <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="512px" Width="717px">
        <h1>Movimento de Estoque</h1>
        <ul>
            <li style="display: block" ID="controle">
                <asp:Label Text="ID" ID="label6" runat="server">ID do Produto</asp:Label>
                <asp:TextBox ID="idpd_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li style="display: block">
                <asp:Label Text="MovimentoEstoque" ID="label1" runat="server">Movimento de Estoque</asp:Label>
                <asp:DropDownList runat="Server" ID="ddl" DataTextField="dd">
                    <asp:ListItem Text="Entrada" Value="E"/>
                    <asp:ListItem Text="Saída" Value="S" />       
                </asp:DropDownList>
            </li>  
            <li style="display: block">
                <asp:Label Text="Quantidade" ID="label4" runat="server">Quantidade</asp:Label>
                <asp:TextBox ID="qtd_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>   
                            
            <li style="display: block">
                <asp:Button ID="Confirmar" CssClass="btn btnAdd" runat="server" Text="Confirmar" OnClick="Confirmar_Click" />
            </li>
            </ul>
   </asp:Panel>   
</asp:Content>
