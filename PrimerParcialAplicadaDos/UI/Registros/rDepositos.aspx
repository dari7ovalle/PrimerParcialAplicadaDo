<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="PrimerParcialAplicadaDos.UI.rDepositos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="form-row justify-content-center">
        <aside class="col-sm-10">
    <div class="card mx-auto mt-5">
            <div class="card-header text-uppercase text-center text-primary">Registro Deposito</div>
            <div class="card-body">
              
                
    <div class="col-md-8 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                </div>
                            </div>
                        </div>
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
       
     <div class="form-row">
  
        <div class="form-group col-md-3">
            <asp:Label Text="Cuenta" runat="server" />
            <asp:DropDownList ID="CuentaDropDownList" class="form-control input-sm" runat="server">
                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CuentaDropDownList" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

        </div>
         </div>
     <div class="form-group col-md-3">
            <asp:Label Text="Concepto" runat="server" />
            <asp:TextBox ID="ConceptoTextBox" class="form-control input-sm"  runat="server"/> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ConceptoTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

        </div>
    <div class="form-group col-md-3">
            <asp:TextBox ID="MontoTextBox" TextMode="Number" class="form-control input-sm" placeholder="0" runat="server" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Guardar" ControlToValidate="MontoTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="MontoTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>

        </div>
         <div class="col-md-4 col-md-offset-3">
                        <div class="card-footer">
                            <div class="form-group">
                                <asp:Button class="btn btn-outline-info btn-md" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click"  />
                                <asp:Button class="btn btn-outline-success btn-md" ValidationGroup="Guardar" ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click1"   />
                                <asp:Button class="btn btn-outline-danger btn-md" ID="eliminarutton" runat="server" Text="Eliminar" OnClick="eliminarutton_Click" />
                            </div>
                        </div>
                    </div>
               
                </div>
        </div>
            
      </div>
    


</asp:Content>
