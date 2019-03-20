<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cDepositos.aspx.cs" Inherits="PrimerParcialAplicadaDos.UI.Consultas.cDepositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="bg-dark p-5 text-center">
            <h1 class="display-4 text-warning"> DEPOSITOS</h1>
        </div>
    </div>
    <div class="form-row justify-content-center">
        <div class="form-row">
            <div class="form-group">
                <asp:Label Text="Desde" runat="server" />
                <asp:TextBox CssClass="form-control" ID="DesdeTextBox" TextMode="Date" runat="server" />
            </div>

            <div class="form-group">
                <asp:Label Text="Hasta" runat="server" />
                <asp:TextBox CssClass="form-control" ID="HastaTextBox" TextMode="Date" runat="server" />
            </div>
            <div class="form-group col-md-2">
                <asp:Label Text="Filtro" class="text-primary" runat="server" />
                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem>Todo</asp:ListItem>
                    <asp:ListItem>DepositoId</asp:ListItem>
                    <asp:ListItem>Fecha</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
                <asp:TextBox ID="CriterioTextBox" class="form-control input-group" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1 p-0">
                <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
                </asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="form-row justify-content-center">
            <asp:GridView ID="DepositoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="SkyBlue" />
                <Columns>
                    <asp:BoundField DataField="DepositoId" HeaderText="Cuenta Id" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
