<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="PrimerParcialAplicadaDos.UI.rDepositos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-row">
        <div class="form-group col-md-3">
            <asp:Label Text="Deposito Id" class="text-primary" runat="server" />
            <asp:TextBox ID="DepositoIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
        </div>
        </div>
        <div class="form-group col-md-3">
            <asp:Label Text="Fecha" runat="server" />
            <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" />
        Buscar
                    </asp:LinkButton>
    </div>
     <div class="form-row">
  
        <div class="form-group col-md-3">
            <asp:Label Text="Cuenta" runat="server" />
            <asp:DropDownList ID="CuentaDropDownList" class="form-control input-sm" runat="server">
                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
            </asp:DropDownList>
        </div>
         </div>
     <div class="form-group col-md-3">
            <asp:Label Text="Concepto" runat="server" />
            <asp:TextBox ID="ConceptoTextBox" class="form-control input-sm" Text="Consepto" runat="server"/>    
        </div>
    <div class="form-group col-md-3">
            <asp:TextBox ID="MontoTextBox" TextMode="Number" class="form-control input-sm" placeholder="0" runat="server" />
        </div>
         <div class="col-md-4 col-md-offset-3">
                        <div class="card-footer">
                            <div class="form-group">
                                <asp:Button class="btn btn-primary" ID="nuevoButton" runat="server" Text="Nuevo"  />
                                <asp:Button class="btn btn-success" ValidationGroup="Guardar" ID="guardarButton" runat="server" Text="Guardar" OnClick="guardarButton_Click"  />
                                <asp:Button class="btn btn-danger" ID="eliminarutton" runat="server" Text="Eliminar" />
                            </div>
                        </div>
                    </div>


</asp:Content>
