<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PaginaMesero.aspx.cs" Inherits="RESTO.PaginaMesero" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <h1 class="text-center" style="color: black" >Mesas asignadas</h1>  
   
        <div class="reserva-container" style="background-color: black" >
             
            <div style="display: flex; flex-direction: column; gap: 30px;">
                <h3 style="color: white"> RESERVAR  </h3>
                <asp:DropDownList ID="ddlSeleccionMesa" runat="server" AutoPostBack="true" style="margin-bottom: 20px;"></asp:DropDownList>
                <asp:Calendar style="background-color: dimgrey" ID="Calendario" runat="server"></asp:Calendar>
            </div>
            <div style="display: flex; flex-direction: column; gap: 20px;">

                <asp:Label style="color: white" ID="lblHora" runat="server" Text="Hora"></asp:Label>
                <asp:TextBox ID="txtHora" runat="server"></asp:TextBox>
                            
                             
                <asp:Label style="color: white" ID="lblMinutos" runat="server" Text="Minutos"></asp:Label>
                <asp:TextBox ID="txtMinutos" runat="server"></asp:TextBox>
                          

                <asp:Label style="color: white" ID="lblCliente" runat="server" Text="Dni del cliente: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

                <asp:Button style="background-color: dimgrey " ID="btnReservar" runat="server" Text="Reservar" OnClick="btnReservar_Click"  />
            </div>
            <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
            <div>
                <h3 style="color: darkslateblue" > RESERVAS DE HOY </h3>                   
                <asp:GridView ID="dgvReservas" runat="server"  class="table table-dark table-striped scrollable-grid" style="width: 250%;">
                    <Columns>                             
                    </Columns>
                </asp:GridView>
            </div>
                        
        </div>

       

              <div class="card-container row row-cols-1 row-cols-md-4 g-3 mt-4">
                    <asp:Repeater ID="Repetidor" runat="server">
                        <ItemTemplate>
                            <div class="col-6 col-md-3 mb-3">
                                <div class="d-flex flex-column align-items-center">
                                    <div class="mesa mb-2">
                                        <img src="https://tse1.mm.bing.net/th?id=OIP.tfNeweScwwLf1x8y7iNgDAHaFF&pid=Api&P=0&h=180" alt="Mesa" class="icono-mesa" />
                                    </div>
                                    <asp:Button class='<%#"boton-moderno " + Eval("Estado.Descripcion") %>' ID="btnMesa" runat="server" Text='<%#"Mesa " + Eval("NumeroMesa") %>' CommandArgument='<%#Eval("NumeroMesa") %>' CommandName="NumeroMesa"  OnClick="btnMesa_Click" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
             </div>

        
        <h2><asp:Literal runat="server" ID="ltNotify"/></h2>

    </div>

    <style>

        .reserva-container {
            display: flex;
            gap: 100px;
            align-items:start;
            justify-content:start;
        }

        .error {
            color: red;
            font-size: 16px;
        }

        .exito {
            color: darkgreen;
            font-size: 16px;
        }

        .mesa {
            display: flex;
            align-items: center;
        }

        .icono-mesa {
            width: 250px; 
            height: 250px; 
            margin-bottom: 10px; 
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

        .Ocupada {
            background: red;
        }

        .Reservada {
            background: yellow;
            color: darkslategrey;
        }

        .Libre {
            background: green;
        }
        h2{
            color:white;
            margin-left: 20px;
        }

        .scrollable-grid {
            width: 60%;
            border-collapse: collapse;
            max-width: 700px;
            margin: 0 auto; 
        }
        .scrollable-grid th,
        .scrollable-grid td {
            padding: 8px;
            border: 1px solid #ddd;
        }

        .scrollable-grid th {
            background-color: #333;
            color: #fff;
            position: sticky;
            top: 0;
        }

    </style>

</asp:Content>
