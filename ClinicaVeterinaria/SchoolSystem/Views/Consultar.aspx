<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="TI_ClinicaVeterinaria.Consultar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
   <asp:Panel runat="server" ID="pnlUpdate" Visible="true" Height="1000px" 
        Width="717px">
        <h1>Consultar</h1>
        <h3>Dados da Consulta</h3>
        <ul>
            <li>
                <asp:Label Text="IDConsulta" ID="label1" runat="server">Consulta</asp:Label>
                <asp:TextBox ID="idConsulta_txt" runat="server" CssClass="radiusInput"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="DataConsulta" ID="label2" runat="server">Data</asp:Label>
                <asp:TextBox ID="dtConsulta_txt" runat="server" CssClass="radiusInput"></asp:TextBox>
            </li>
            <li>
                <asp:Label Text="HoraConsulta" ID="label3" runat="server">Hora</asp:Label>
                <asp:TextBox ID="horaConsulta_txt" runat="server" CssClass="radiusInput"></asp:TextBox>
            </li>
            </ul>
            <br />
            <hr />
            <br />
            <h3>Dados do Pet</h3>
            <ul>
            <li>
                <asp:Label Text="NomePet" ID="label4" runat="server">Nome Pet</asp:Label>
                <asp:TextBox ID="pet_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>        
            <li>
                <asp:Label Text="PesoPet" ID="label5" runat="server">Peso Pet</asp:Label>
                <asp:TextBox ID="pesoPet_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>       
            <li>
                <asp:Label Text="AlturaPet" ID="label6" runat="server">Altura Pet</asp:Label>
                <asp:TextBox ID="altPet_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li>  
            <li>
                <asp:Label Text="NomeCliente" ID="label7" runat="server">Dono</asp:Label>
                <asp:TextBox ID="cliente_txt" Text="" CssClass="radiusInput" runat="server"></asp:TextBox>
            </li> 
            </ul>
            <hr />
            <br />
            <h3>Diagnosticar</h3>
        <ul>
            <li style="display: block">
                <asp:Label Text="Diagnostico" ID="label8" runat="server">Diagnóstico</asp:Label>
                <asp:TextBox ID="diagnostico_txt" runat="server" EnableViewState="False" 
                    Height="150px" Rows="7" Width="600px" BorderColor="Gray" 
                    BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </li>
            <li style="display: block">
                <asp:Label Text="Receita" ID="label9" runat="server">Receita</asp:Label>
                <asp:TextBox ID="receita_txt" runat="server" Height="150px" Width="600px" 
                    BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </li>
            </ul>
       <br />
       <br />
       <asp:Button ID="confirmaConsultar" CssClass="btn btnAdd" runat="server" Text="Confirmar" OnClick="btnAtualizar_Click" />
   </asp:Panel>


 
   
</asp:Content>
