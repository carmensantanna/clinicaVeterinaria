<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="PesquisaPet.aspx.cs" Inherits="TI_ClinicaVeterinaria.PesquisaPet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">


    <asp:Panel runat="server" ID="pnlShowData" Visible="true" Height="283px">
        <h1>Todos os Pets Cadastrados</h1>
        <asp:GridView ID="gridPet" runat="server" EmptyDataText="Não Existem Pets Cadastrados..." AutoGenerateColumns="false" OnRowCommand="gridPet_RowCommand" OnSelectedIndexChanged="gridPet_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Altura" HeaderText="Altura" />
                <asp:BoundField DataField="Peso" HeaderText="Peso" />
                <asp:BoundField DataField="Animal.Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="Cliente.Nome" HeaderText="Cliente" />
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CommandName="Editar" Text="Editar Dados"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>' />
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
