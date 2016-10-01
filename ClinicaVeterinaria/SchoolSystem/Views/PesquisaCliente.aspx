<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="PesquisaCliente.aspx.cs" Inherits="TI_ClinicaVeterinaria.PesquisaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">


    <asp:Panel runat="server" ID="pnlShowData" Visible="true" Height="283px">
        <h1>Todos os Clientes Cadastrados
            
        </h1>
        <asp:GridView ID="gridCliente" runat="server" EmptyDataText="Não Existem Clientes Cadastrados..." AutoGenerateColumns="false" OnSelectedIndexChanged="gridCliente_SelectedIndexChanged" OnRowCommand="gridCliente_RowCommand">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CommandName="Editar" Text="Editar Dados"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnPet" runat="server" CommandName="IncluirPet" Text="Incluir Pet"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnAgendar" runat="server" CommandName="AgendarConsulta" Text="Agendar Consulta"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>' />
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
