<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CambiarContrasenia.aspx.cs" Inherits="RESTO.CambiarContrasenia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    .input-container {
        margin: 15px 0;
        display: flex;
        align-items: center;
        text-align: center; 
    }
    .input-label {
        width: 100px;
        font-size: 20px;
        color: white;
    }
    .boton-moderno {
        background-color: midnightblue;
        color: white;
        border: none;
        padding: 10px 20px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        margin: 4px 2px;
        cursor: pointer;
        border-radius: 4px;
    }
</style>

   

                    <div class="input-container">
                <asp:Label  style="color: black" ID="Label1" runat="server" Text="Dni" CssClass="input-label"></asp:Label>
                <asp:TextBox ID="txtDNI" runat="server" type="text" ReadOnly="true"></asp:TextBox>
            </div>
             <div class="input-container">
                 <asp:Label style="color: black" ID="Label2" runat="server" Text="Nueva Contraseña" CssClass="input-label"></asp:Label>
                 <asp:TextBox ID="txtPassword" runat="server" type="password"></asp:TextBox>
             </div>
            <div class="input-container">
                 <asp:Label style="color: black" ID="Label" runat="server" Text="Reingrese Contraseña" CssClass="input-label"></asp:Label>
                 <asp:TextBox ID="txtPasswordConfirmation" runat="server" type="password"></asp:TextBox>
             </div>


            <div>
                <asp:Button CssClass="boton-moderno" ID="btnCambiarPass" runat="server" Text="Cambiar contraseña" OnClick="btnCambiarPass_Click"/>
            </div>

   
    
     


</asp:Content>
