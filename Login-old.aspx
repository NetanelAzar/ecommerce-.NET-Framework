<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login-old.aspx.cs" Inherits="Ecommerce.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

</body>
</html>
