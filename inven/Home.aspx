<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="inven.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <title>Home</title>
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
        <%
            if (message != null)
            {
                //Response.Write
                Response.Write("<div class=\"alert alert-primary\" role=\"alert\">Terjadi masalah</div>");
            }
        %>
        <div class="container"style="margin-top:20px;">
            <h2 class="text-center">Jumlah Barang</h2>
            <asp:GridView ID="TableUser" CssClass="table table-bordered"  runat="server" AutoGenerateColumns="false">
                <Columns>   
                    <asp:TemplateField HeaderText="No">   
                         <ItemTemplate>
                                 <%# Container.DataItemIndex + 1 %>   
                         </ItemTemplate>
                     </asp:TemplateField>
                    <asp:BoundField HeaderText="Name" DataField="nama" />  
                    <asp:BoundField HeaderText="Jumlah" DataField="jumlah" />  
                </Columns> 
            </asp:GridView>
            <h2>Riwayat Barang</h2>
            <asp:GridView ID="Riwayat" AutoGenerateColumns="false" CssClass="table table-bordered" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="nama" />  
                    <asp:BoundField HeaderText="Jumlah" DataField="jumlah" /> 
                    <asp:BoundField HeaderText="User" DataField="username" />
                    
                    <asp:TemplateField HeaderText="Tanggal">
                        <ItemTemplate>
                             <%# string.Format("{0:dddd, dd MMMM yyyy HH:mm}", Eval("tanggal"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
            </asp:GridView>
        </div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
        
    </form>
    </body>
</html>
