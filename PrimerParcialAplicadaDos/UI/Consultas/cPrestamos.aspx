﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cPrestamos.aspx.cs" Inherits="PrimerParcialAplicadaDos.UI.Consultas.cPrestamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="bg-dark p-5 text-center">
            <h1 class="display-4 text-warning"> PRESTAMOS</h1>
        </div>
    </div>
    <div class="form-row justify-content-center">
        <div class="form-row">

            <div class="form-row justify-content-center">
                <div class="form-group ">
                    <asp:Label Text="Desde" runat="server" />
                    <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
                <div class="form-group ">
                    <asp:Label Text="HastaTextBox" runat="server"></asp:Label>
                    <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />

                </div>
            </div>

            <div class="form-group col-md-2">
                <asp:Label Text="Filtro" class="text-primary" runat="server" />
                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem>Todo</asp:ListItem>
                    <asp:ListItem>PrestamoId</asp:ListItem>
                    <asp:ListItem>Fecha</asp:ListItem>
                    <asp:ListItem>CuentaId</asp:ListItem>
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
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="ImprimirLinkButton1" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="ImprimirLinkButton1_Click">
                <span class="fas fa-search"></span>
                 Imprimir
            </asp:LinkButton>
        </div>


    </div>


    <div class="form-row justify-content-center">
        <asp:GridView ID="PrestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None ">
            <AlternatingRowStyle BackColor="SkyBlue" />
            <Columns>
                <asp:BoundField DataField="PrestamoId" HeaderText="Prestamo Id" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="CuentaId" HeaderText="Cuenta Id" />
                <asp:BoundField DataField="Capital" HeaderText="Capital" />
                <asp:BoundField DataField="TasaInteres" HeaderText="TasaInteres" />
                <asp:BoundField DataField="Tiempo" HeaderText="Tiempo " />

            </Columns>


        </asp:GridView>

    </div>

</asp:Content>
