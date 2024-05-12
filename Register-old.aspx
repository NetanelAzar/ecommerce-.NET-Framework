<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register-old.aspx.cs" Inherits="Ecommerce.Register_old" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <title>הרשמה</title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container"> <!-- תיבת הכלים -->
     
          <div class="row"> <!-- שורה -->

              <div class="col-md-6"> <!-- עמודה בחצי הרוחב של מסך בגודל בינוני -->

                  <label for="TxtFullname">שם פרטי :</label>
                  <asp:TextBox ID="TxtFullname" runat="server" CssClass="form-control"  /><br />

                  <label for="TxtLastName">שם משפחה</label>
                  <asp:TextBox ID="TxtLastName" runat="server" CssClass="form-control"  /><br />

                  <asp:Literal ID="LtlMsg" runat="server" /><br />

                  <label for="TxtMail">אימייל :</label>
                  <asp:TextBox ID="TxtMail" runat="server" TextMode="Email" CssClass="form-control"  /><br />

                  <asp:Literal ID="MailMsg" runat="server" /><br />

                  <label for="TxtPhone">פלאפון</label>
                  <asp:TextBox ID="TxtPhone" runat="server" TextMode="Phone" CssClass="form-control"  /><br />

     

                  <label for="TxtAdd">כתובת :</label>
                  <asp:TextBox ID="TxtAdd" runat="server" CssClass="form-control" /><br />

                      <label for="DDLCity">עיר</label>
                      <asp:DropDownList ID="DDLCity" runat="server" CssClass="form-control" />
                       

                  <label for="TxtPass">סיסמא :</label><br />
                  <asp:TextBox ID="TxtPass" runat="server" TextMode="Password" CssClass="form-control" /><br />

                  <label for="TxtpassValidation">אימות סיסמא :</label>
                  <asp:TextBox ID="TxtpassValidation" runat="server" TextMode="Password" CssClass="form-control" /><br />
                  <asp:Literal ID="LtlPassMsg" runat="server" /><br />

              </div>

              <div class="col-md-6"> <!-- עמודה בחצי הרוחב של מסך בגודל בינוני -->

                  <label for="TxtBirth">תאריך לידה :</label>
                  <asp:TextBox ID="TxtBirth" runat="server" TextMode="Date" CssClass="form-control" /><br />

                  <label>מגדר :</label>
                  <div>
                      <asp:RadioButton ID="RdMale" runat="server" Text="זכר" GroupName="Gender" />
                      <asp:RadioButton ID="RdFemale" runat="server" Text="נקבה" GroupName="Gender" />
                  </div>
                  <br />

                  <asp:HyperLink ID="HplTerms" runat="server" />   
                  <asp:CheckBox ID="ChkTerms" runat="server" Text="אני מסכים לתקנון האתר" /><br />
                  <asp:Button ID="BtnReg" runat="server" Text="הרשמה" OnClick="BtnReg_Click" CssClass="btn btn-primary" />
              </div>
          </div>
      </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>