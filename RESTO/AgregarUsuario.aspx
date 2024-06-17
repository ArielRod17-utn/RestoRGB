<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="RESTO.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

          .styled-button {
                  background-color: midnightblue; 
                  color: white; 
                  padding: 10px 20px; 
                  border: none; 
                  border-radius: 5px; 
                  cursor: pointer; 
                  font-size: 16px; 
              }

              .styled-button:hover {
                  background-color: #45a049;
              }


        .form-group {
            text-align: center;
            margin-bottom: 10px;
        }

        .form-group label {
            display: inline-block;
            width: 100px; 
            text-align: right;
            margin-bottom: 5px;
        }

        .form-group input,
        .form-group select {
            width: 200px; 
            box-sizing: border-box;
            margin-bottom: 10px;
            padding: 5px;
        }

        .submit-btn {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Empleados </h1>

    <div class="form-group">
        <asp:Label style="color: white" ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label style="color: white" ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label style="color: white" ID="lblDNI" runat="server" Text="** Dni **: "></asp:Label>
        <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label style="color: white" ID="lblOpciones" runat="server" Text="** Rol**:"></asp:Label>
        <asp:DropDownList ID="ddlOpciones" runat="server">
        </asp:DropDownList>
    </div>

    <div class="submit-btn">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="styled-button" OnClick="btnGuardar_Click"/>
    </div>
 
   




</asp:Content>
