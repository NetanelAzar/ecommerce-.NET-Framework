<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Ecommerce.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/5.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .product-card {
            margin-bottom: 20px; /* מרווח תחתון */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container"> <!-- מכיל את כל התוכן המרכזי -->
        <div class="row"> <!-- שורה של מוצרים -->
            <asp:Repeater ID="RptProducts" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 product-card"> <!-- עמודה בגודל בינוני -->
                        <div class="card h-100"> <!-- כרטיס Bootstrap עם גובה מלא -->
                            <img src="/uploads/prods/<%#Eval("Picname") %>" class="card-img-top" alt="<%#Eval("Pname") %>">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Pname") %></h5>
                                <p class="card-text"><%#Eval("Pdesc") %></p>
                                <a href="#" class="btn btn-primary">קנה עכשיו</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
