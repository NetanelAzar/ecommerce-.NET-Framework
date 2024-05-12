<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Ecommerce.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">

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
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
