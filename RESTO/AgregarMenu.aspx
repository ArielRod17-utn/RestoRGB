<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarMenu.aspx.cs" Inherits="RESTO.AgregarMenu" %>
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
            width: 20%; 
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


         <h1> Agregado/Modificación del Menú</h1>

    <div class="form-group">
        <asp:Label style="color: white" ID="lblDescripcion" runat="server" Text="   Descripcion: "></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label style="color: white" ID="lblPrecio" runat="server" Text="  ** Precio **: "></asp:Label>
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label  style="color: white" ID="lblOpciones" runat="server" Text="Tipo de Menú: "></asp:Label>
        <asp:DropDownList ID="ddlOpciones" runat="server" AutoPostBack="true"> </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label style="color: white" ID="lblRequiereStock" runat="server" Text="Requiere Stock: " ></asp:Label>
        <asp:DropDownList ID="ddlRequiereStock" runat="server">   
            <asp:ListItem Text="No" Value="FALSE" />
            <asp:ListItem Text="Si" Value="TRUE" />
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label style="color: white" ID="LblStock" runat="server" Text="   ** Stock **: "></asp:Label>
        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
    </div>

    <div class="submit-btn">
        <asp:Button ID="btnAgregar" runat="server" Text="Guardar" CssClass="styled-button" OnClick="btnAgregar_Click" />
    </div>
</asp:Content>
