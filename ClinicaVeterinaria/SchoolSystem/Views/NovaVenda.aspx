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
                    ReadOnly="True"></asp:TextBox>
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
        <li style="display: block">
                <asp:Label Text="Produto" ID="label6" runat="server"></asp:Label>
                <asp:TextBox ID="cod_produto" Text="" CssClass="radiusInput" runat="server" 
                    Width="70%"></asp:TextBox>
            </li>
            <li style="display: block; border: none">
            <table id="tableProdutos">
            <thead>
            <tr>
            <th>
            Produto
            </th>
            <th>
            Quantidade
            </th>
            <th>
            Valor
            </th>
            </tr>
            </thead>
            <tbody>
            </tbody>
            </table>
            </li>
            <li>
                <asp:Button ID="incluirItem" CssClass="btn btnAdd" runat="server" Text="Incluir" OnClick="incluirItem_Click" />
            </li>
 
            </ul>
   </asp:Panel>

   <script type="text/javascript">
       jq(document).ready(function () {
           jq("#cod_produto").focusout(function () {
               //jq("#tableProdutos > tbody:last-child").append("<tr><td>AA</td><td>AA</td><td>AA</td></tr>");
               jq.ajax({
                   type: "POST",
                   url: "NovaVenda.aspx/InserirProduto",
                   data: '{codigo: "'+ this.value +'"}',
                   contentType: "application/json: charset=utf-8",
                   dataType: "json",
                   success: blaa,
                   failure: function (response) {
                       alert(response.d);
                   }
               });

               
           });

           function blaa() {
               alert("blabla");
               /*jq(jsonResult.d).each(function (index, val) {
                   jq("#tableProdutos > tbody:lastchild").append(
                       "<tr><td>" + val.Nome + "</td><td>" + val.Estoque + "</td><td>" + val.ValorReal + "</td></tr>"
                   );
               });*/
           }
       });

       
    </script>
 
   
</asp:Content>
