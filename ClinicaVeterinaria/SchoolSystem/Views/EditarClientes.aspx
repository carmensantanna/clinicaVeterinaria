<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="EditarClientes.aspx.cs" Inherits="TI_ClinicaVeterinaria.EditarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="512px" Width="717px">
        <h1>Editar&nbsp; Clientes</h1>
        <form id="editCliente">
        <ul>
            <li>
                <asp:Label Text="ID" ID="label6" runat="server"></asp:Label>
                <asp:TextBox ID="id_txt" Text="" CssClass="radiusInput" runat="server" ReadOnly="True"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="Nome" ID="label4" runat="server"></asp:Label>
                <asp:TextBox ID="nome_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label5" runat="server" Text="CPF"></asp:Label>
                <asp:TextBox ID="cpf_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label7" runat="server" Text="Data de Nascimento"></asp:Label>
                <asp:TextBox ID="dtnasc_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="email_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label10" runat="server" Text="Telefone"></asp:Label>
                <asp:TextBox ID="tel_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label11" runat="server" Text="Celular"></asp:Label>
                <asp:TextBox ID="cel_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>

            <li>
                <asp:Label ID="Label12" runat="server" Text="Logradouro"></asp:Label>
                <asp:TextBox ID="log_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label13" runat="server" Text="Número"></asp:Label>
                <asp:TextBox ID="num_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label14" runat="server" Text="Complemento"></asp:Label>
                <asp:TextBox ID="comp_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label15" runat="server" Text="Bairro"></asp:Label>
                <asp:TextBox ID="bairro_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label1" runat="server" Text="Cidade"></asp:Label>
                <asp:TextBox ID="cidade_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label2" runat="server" Text="UF"></asp:Label>
                <asp:TextBox ID="uf_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" Text="CEP"></asp:Label>
                <asp:TextBox ID="cep_txt" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            
            <li>
                <asp:Button ID="bntAtualizar" CssClass="btn btnEdit" runat="server" Text="Atualizar" OnClick="bntAtualizar_Click1"/>
            </li>
            <li>
                <asp:Button ID="btnExcluir" CssClass="btn btnEdit" runat="server" 
                    Text="Excluir" OnClientClick = "Confirm()" OnClick="btnExcluir_Click"/>
            </li>
            <li>
                <asp:LinkButton ID="lnkVoltar" CssClass="btn btnEdit" runat="server" PostBackUrl="~/Views/PesquisaCliente.aspx" Text="Voltar" />
            </li>
            <asp:HiddenField ID="confirm_value" runat="server"  />
            </ul>
            </form>
   </asp:Panel>

   <script type = "text/javascript">
       function Confirm() {
           /*var confirm_value = document.createElement("INPUT");
           confirm_value.type = "hidden";
           confirm_value.name = "confirm_value";
           confirm_value.ID = "confirm_value";*/
           var confirm_value = document.getElementById("confirm_value");
           
           if (confirm("Você deseja realmente excluir esse cliente?")) {
               confirm_value.Value = "Sim";
           } else {
               confirm_value.Value = "Não";
           }
           //document.forms[0].appendChild(confirm_value);
       }
    </script>
</asp:Content>