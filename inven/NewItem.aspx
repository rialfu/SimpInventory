<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewItem.aspx.cs" Inherits="inven.Tambah_Item" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tambah Item</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-success">
        <a class="navbar-brand text-white" href="#">Inventory</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <a class="nav-item nav-link text-white active" href="/home.aspx">Home <span class="sr-only">(current)</span></a>
                <a class="nav-item nav-link text-white" href="/NewItem.aspx">New Item</a>
                <a class="nav-item nav-link text-white" href="/Quantity.aspx">Quantity</a>
               
            </div>
        </div>
    </nav>
    <div class="container"style="margin-top:20px;">
        <h1 class="text-center">Tambah Item</h1>
        <form id="form1" runat="server">
            <div>
                <div class="form-group">
                    <label>Nama Barang</label>
                    <asp:TextBox ID="nama" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Jumlah</label>
                    <asp:TextBox ID="jumlah" runat="server" placeholder="Masukkan bila ada Stok" CssClass="form-control"></asp:TextBox>                
                </div>
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="tambah" />
            </div>
           
        </form>
    </div>
</body>
</html>
