<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsList-old.aspx.cs" Inherits="Ecommerce.ProductsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.rtl.min.css" />
    <title></title>
</head>
<body>





    <form id="form1" runat="server">
        <div class="container" >
            <div class="row">
                <div class="col-2">
                    שם מלא
                </div>
                <div class="col-4"><asp:TextBox ID="TxtFullName" runat="server"/></div>
            </div>
            <div class="row">
                <div class="col-md-3 col-sm-4 col-xs-6 bg-danger">A</div>
                <div class="col-md-3 col-sm-4 col-xs-6 bg-success">B</div>
                <div class="col-md-3 col-sm-4 col-xs-6 bg-info">C</div>
                <div class="col-md-3 col-sm-4 col-xs-6 bg-primary">D</div>

            </div>
        </div>

     
            <div class="container">
                <div class="row">
                    <asp:Repeater ID="RptProducts" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4">
                                <div class="card" style="width: 18rem;">
                                    <img src="/uploads/prods/<%#Eval("Picname") %>" class="card-img-top" alt="...">
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("Pname") %></h5>
                                        <p class="card-text"><%#Eval("Pdesc") %></p>
                                        <a href="#" class="btn btn-primary">Go somewhere</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
    



    </form>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
