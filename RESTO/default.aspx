<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RESTO._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>RGB-Resto</title>
    <script type="text/javascript">
        function TriggerButtonClick(e, buttonId) {
            if ((e.which && e.which == 13) || (e.keyCode && e.keyCode == 13)) {
                document.getElementById(buttonId).click();
                return false;
            }
            return true;
        }
    </script>
    <style>
        body {
            background-image: url('https://wallpaperaccess.com/full/3692914.jpg'); 
            background-size: cover; 
            background-repeat: no-repeat; 
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh; 
        }

        h1 {
            font-size: 90px;
            font-family: "Bradley Hand ITC", sans-serif;
            color: black; 
            text-shadow: 4px 4px 4px white;
        }

        h2 {
            font-size: 15px;
            font-family: Arial, sans-serif ;
            color: white; 
            text-shadow: 1px 1px 1px blue;
            text-align: center; 
        }

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

        .styled-button {
            background-color: blue;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-left: 135px;
            font-size: 18px;
            font-family: Arial, sans-serif;
            outline: none; 
        }

        .styled-button:focus {
            outline: none;
            box-shadow: 0 0 10px #719ECE;
        }

        .error-label {
            text-align: center; 
            font-size: 18px;  
            color: white;
            background-color: black; 
            padding: 10px;     
            border: 2px solid black;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <h1>RGB-Resto</h1>
        </div>
        <div class="input-container">
            <asp:Label ID="Label1" runat="server" Text="Usuario" CssClass="input-label"></asp:Label>
            <asp:TextBox ID="TxtUsuario" runat="server" type="text"></asp:TextBox>
        </div>

        <div class="input-container">
            <asp:Label ID="Label2" runat="server" Text="Contraseña" CssClass="input-label"></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server" type="password"></asp:TextBox>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

        <div>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="styled-button" OnClick="btnIngresar_Click" OnClientClick="return TriggerButtonClick(event, '<%= btnIngresar.ClientID %>');" />
        </div>
        <br />
        <div>
        </div>
    </form>
</body>
</html>
