<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="PesquisaConsulta.aspx.cs" Inherits="TI_ClinicaVeterinaria.PesquisaConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">


    <asp:Panel runat="server" ID="pnlShowData" Visible="true" Height="283px">
        <h1>Consultas agendadas
            
        </h1>
        <asp:GridView ID="gridConsulta" runat="server" EmptyDataText="Não Existem Consultas Cadastrados..." AutoGenerateColumns="false" OnSelectedIndexChanged="gridConsulta_SelectedIndexChanged" OnRowCommand="gridConsulta_RowCommand">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Pet.Nome" HeaderText="Pet" />
                <asp:BoundField DataField="Cliente.Nome" HeaderText="Dono" />
                <asp:BoundField DataField="Horario.Data.DataTxt" HeaderText="Data" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Horario.Data.HoraMin" HeaderText="Horario" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CommandName="Consultar" Text="Consultar"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>' />
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
