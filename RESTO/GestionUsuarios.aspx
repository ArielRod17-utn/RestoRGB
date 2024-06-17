<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Gestion_Usuarios.aspx.cs" Inherits="RESTO.Gestion_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function resaltarFilaSeleccionada(sender, args) {
            var grid = sender;
            var selectedIndex = args.get_selectedIndex();

            if (selectedIndex !== -1) {
                var selectedRow = grid.get_dataItems()[selectedIndex].get_element();
                selectedRow.style.backgroundColor = '#c0c0c0';  // Color de fondo de la fila seleccionada
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center"  style="color: black" >Empleados</h1>
    <div style="display: flex; flex-direction: column; align-items: flex-start; margin-bottom: 20px;">
        <div style="margin-right: 20px;">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="boton-moderno" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="boton-moderno" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="boton-moderno" />
        </div>
        <asp:GridView ID="dgvUsuario" runat="server" AutoGenerateColumns="false" DataKeyNames="IdUsuario" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged"
            class="table table-dark table-striped" style="width: 220%;" ClientIDMode="Static">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="Fecha de creación" DataField="FechaCreacion" />
                <asp:BoundField HeaderText="Descripción" DataField="Perfil.Descripcion" />
                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
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
            margin: auto;
        }
    </style>
</asp:Content>