<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master.Master" CodeBehind="MovimentoEstoque.aspx.cs" Inherits="TI_ClinicaVeterinaria.MovimentoEstoque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
   <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="512px" Width="717px">
        <h1>Buscar Produto</h1>
        <ul>
            <li ID="controle">
                <asp:Label Text="ID" ID="label6" runat="server">ID do Produto</asp:Label>
                <asp:TextBox ID="idpd_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="MovimentoEstoque" ID="label1" runat="server">Movimento de Estoque</asp:Label>
                <asp:DropDownList runat="Server" ID="ddl" DataTextField="dd">
                    <asp:ListItem Text="Entrada" Value="E"/>
                    <asp:ListItem Text="Saída" Value="S" />       
                </asp:DropDownList>
            </li>  
            <li>
                <asp:Label Text="Quantidade" ID="label4" runat="server">Quantidade</asp:Label>
                <asp:TextBox ID="qtd_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>   
                            
            <li >
                <asp:Button ID="Confirmar" CssClass="btn btnAdd" runat="server" Text="Confirmar" OnClick="Confirmar_Click" />
            </li>
            </ul>
            <h1>Lista de Estoques</h1>

       <asp:GridView ID="gridProduto" runat="server" EmptyDataText="Não Existem Clientes Cadastrados..." AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="ValorReal" HeaderText="Valor" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Estoque" HeaderText="Quantidade" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                </Columns>
            <HeaderStyle BackColor="#6699FF" Font-Bold="True" />
        </asp:GridView>
   </asp:Panel>   
</asp:Content>
