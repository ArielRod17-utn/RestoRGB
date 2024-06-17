<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionMesa_a_Mesero.aspx.cs" Inherits="RESTO.GestionMesa_a_Mesero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>ASIGNE UN MESERO</h1>
    <h2> Listado</h2>


        <div style="display: flex; align-items: flex-start;">
   
          
            <asp:GridView ID="dgvMeseros" runat="server" AutoGenerateColumns="false" DataKeyNames="IdUsuario" OnSelectedIndexChanged="dgvMeseros_SelectedIndexChanged" class="table table-dark table-striped" style="width: 250%;">
                <Columns>   
                    <asp:BoundField HeaderText="IdUsuario" DataField="IdUsuario"/>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>                             
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion"/>
                </Columns>
            </asp:GridView>
        
        </div>

<style>
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

    .table {
        margin: 0 auto;
    }
</style>











</asp:Content>
