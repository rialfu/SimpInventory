<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quantity.aspx.cs" Inherits="inven.Quantity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <title>Masuk Keluar Barang</title>
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
    <form id="form1" runat="server">
        <div class="container"style="margin-top:20px;">
            <div class="form-group">
                <label>Nama Barang :</label>
                <asp:DropDownList ID="barang" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="changeValue">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Jumlah :</label>
                <asp:TextBox ID="jumlah" runat="server" placeholder="masukkan jumlah" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:DropDownList ID="Tipe" runat="server"  CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="changeValueTipe">
                <asp:ListItem Text = "--Select Tipe--" Value = ""></asp:ListItem>
                <asp:ListItem Text = "Barang Masuk" Value = "1"></asp:ListItem>
                <asp:ListItem Text = "Barang Keluar" Value = "0"></asp:ListItem>
            </asp:DropDownList>
            
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="tambah" />

            

        </div>
    </form>
</body>
</html>
