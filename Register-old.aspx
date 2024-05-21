<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Ecommerce.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
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
                  <asp:TextBox ID="TxtPhone" runat="server" TextMode="Phone" CssClass="form-control" /><br />

     

                  <label for="TxtAdd">כתובת :</label>
                  <asp:TextBox ID="TxtAdd" runat="server" CssClass="form-control"  /><br />

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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
