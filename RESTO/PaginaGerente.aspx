<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PaginaGerente.aspx.cs" Inherits="RESTO.PaginaGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image-container {
            position: relative;
            width: 400px; 
            height: 400px; 
            margin: 50px auto; 
        }

        .overlay-image {
            position: absolute;
            width: 400px; 
            height: auto; 
            z-index: 1;
           
        }

        
        .img1 {
            top: -70px; 
            left: 60px;
        }

        .img2 {
            top: 160px; 
            left: 480px;
        }

        .img3 {
            bottom: -20px; 
            left: 60px; 
        }

        .img4 {
            top: 160px; 
            right: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center"  style="color: black" > Gerente</h1>
    <br />
   <div class="image-container">
        <img src="https://tse3.mm.bing.net/th?id=OIP.7PCc9htegOc9b8SAI8ficAHaEI&pid=Api&P=0&h=180" alt="Imagen 1" class="overlay-image img1" />
        <img src="https://tse3.mm.bing.net/th?id=OIP.716Q9XIYIflTSb0gDX7Q7AHaE7&pid=Api&P=0&h=180" alt="Imagen 2" class="overlay-image img2" />
        <img src="https://tse3.mm.bing.net/th?id=OIP.NeNig6q-tq2V9mt_fpbhxgHaEz&pid=Api&P=0&h=180" alt="Imagen 3" class="overlay-image img3" />
        <img src="https://tse4.mm.bing.net/th?id=OIP.fVMu-Ksc136KMKznVvo9iQHaE8&pid=Api&P=0&h=180" alt="Imagen 4" class="overlay-image img4" />
    </div>

</asp:Content>
