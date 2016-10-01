<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="IncluirConsulta.aspx.cs" Inherits="TI_ClinicaVeterinaria.IncluirConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
   <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="512px" Width="717px">
        <h1>Agendar Consulta</h1>
        <h3>Dados do Veterinário</h3>
        <ul>
            <li>
                <asp:Label Text="IDConsulta" ID="label5" runat="server">ID Consulta</asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="Veterinario" ID="label1" runat="server"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">Marcio Ferreira</asp:ListItem>
                    <asp:ListItem Value="2">José Antonio</asp:ListItem>
                </asp:DropDownList>
            </li>        
            <li>
                <asp:Label Text="Data da Consulta" ID="label3" runat="server">Data de Consulta</asp:Label>             
                <input type="date" />
            </li>         
            <li>
                <asp:Label Text="Horários" ID="label2" runat="server"></asp:Label>             
                  <input type="time" name="usr_time">
            </li>                        
            <li style="display: block">
                <asp:Button ID="pesqCliente" CssClass="btn btnAdd" runat="server" Text="Pesquisar Horário" OnClick="pesqCliente_Click" />
            </li>
            </ul>
            <hr />
            <br />
            <h3>Dados do Pet</h3>
        <ul>
            <li>
                <asp:Label Text="CódigoCliente" ID="label16" runat="server">Código Cliente</asp:Label>
                <asp:TextBox ID="IDCliente" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="Cliente" ID="label4" runat="server">Nome Cliente</asp:Label>
                 <asp:TextBox ID="NomeCliente" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="NomePet" ID="label6" runat="server">Nome do Pet</asp:Label>
                <asp:DropDownList ID="DropDownPet" runat="server">
                </asp:DropDownList>
            </li>
            </ul>
       
       <asp:Button ID="peqClienteConsulta" CssClass="btn btnAdd" runat="server" Text="Pesquisar" OnClick="Button1_Click" />
   </asp:Panel>


 
   
</asp:Content>
