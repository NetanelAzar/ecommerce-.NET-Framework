<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecommerce.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">

    <div class="container"> <!-- תיבת הכלים -->
       
    <div class="row"> <!-- שורה -->

        <div class="col-sm-2"> <!-- עמודה בחצי הרוחב של מסך בגודל קטן -->

           שם משתמש : <asp:TextBox ID="TxtEmail" runat="server" /><br />
            סיסמא : <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" /><br />
            <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="הרשמה"  /><br />
            <asp:Literal ID="LtlMsg" runat="server" />
        </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
