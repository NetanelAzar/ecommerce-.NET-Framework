<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecommerce.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .login-container {
            max-width: 400px; /* הגבלת רוחב מקסימלי של הקונטיינר */
            margin: 50px auto; /* מרכז את הקונטיינר עם מרווח עליון ותחתון */
            padding: 15px; /* ריפוד פנימי */
            border-radius: 10px; /* פינות מעוגלות */
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* צל קל */
            background-color: #ffffff; /* צבע רקע לבן */
        }
        .form-title {
            text-align: center; /* ממרכז את הטקסט */
            margin-bottom: 15px; /* מרווח תחתון */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container"> <!-- מרכיב המכיל את כל התוכן המרכזי ומעניק לו רווחים פנימיים -->
        <div class="login-container">
            <h2 class="form-title">התחברות</h2>
            <div class="mb-3"> <!-- מרכיב המוסיף מרווח תחתון של 3 (1.5rem) -->
                <label for="TxtEmail" class="form-label">שם משתמש:</label> <!-- מספק סגנון תקני לתוויות טופס -->
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" /> <!-- הופך את תיבת הטקסט למרכיב טופס תקני של Bootstrap -->
            </div>
            <div class="mb-3"> <!-- מרכיב המוסיף מרווח תחתון של 3 (1.5rem) -->
                <label for="TxtPassword" class="form-label">סיסמא:</label> <!-- מספק סגנון תקני לתוויות טופס -->
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control" /> <!-- הופך את תיבת הטקסט למרכיב טופס תקני של Bootstrap -->
            </div>
            <div class="d-grid gap-2"> <!-- מסדר את הכפתורים עם גריד ורווח של 2 (0.5rem) -->
                <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="הרשמה" CssClass="btn btn-primary" /> <!-- כפתור בסגנון ראשי של Bootstrap -->
            </div>
            <div class="mt-3"> <!-- מרכיב המוסיף מרווח עליון של 3 (1rem) -->
                <asp:Literal ID="LtlMsg" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
