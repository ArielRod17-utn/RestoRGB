<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Gestion_Menu.aspx.cs" Inherits="RESTO.Gestion_Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <h1 class="text-center"  style="color: black" > Administrar Menú</h1>
    <br />

    <div class="container">
        <div style="display: flex; align-items: flex-start; flex-direction:column; width:100%;">
            <div style="margin-right: 20px;">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="boton-moderno" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="boton-moderno" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="boton-moderno" />
            </div>
        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="width:100%;">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlCategorias" runat="server" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged" AutoPostBack="true"> </asp:DropDownList>
                
                    <asp:GridView ID="dgvMenu" runat="server" AutoGenerateColumns="false" DataKeyNames="IdMenu" OnSelectedIndexChanged="dgvMenu_SelectedIndexChanged" class="table table-dark table-striped" style="width:100%;" >
                        <Columns>   
                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                            <asp:BoundField HeaderText="Precio" DataField="Precio"/>
                            <%-- <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion"/>--%>
                            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion"/>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <div>
            <h3 class="text-center"  style="color: black"> A revisar </h3>
            <asp:GridView ID="dgvStock" runat="server" AutoGenerateColumns="false"  class="table table-dark table-striped" style="width:100%;">
                <Columns>   
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                    <asp:BoundField HeaderText="Stock" DataField="Stock"/>                             
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <style>

        .container {
            display: grid;
            grid-template-columns: 50% 30%;
            gap: 50px;
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

        .table {
            margin: 0 auto;
        }
    </style>
</asp:Content>
