<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TI_ClinicaVeterinaria.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">

  
   <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="512px" Width="717px">
        <h1>Cadastro de Clientes</h1>
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
                <asp:TextBox ID="comp_txt" CssClass="radiusInput" runat="server" ></asp:TextBox>
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
                <asp:Button ID="bntAdd" CssClass="btn btnAdd" runat="server" Text="Cadastrar" OnClick="bntAdd_Click" />
            </li>
            </ul>
   </asp:Panel>


 
   
</asp:Content>
