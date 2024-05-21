<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManager/BackAdmin.Master" AutoEventWireup="true" CodeBehind="CatAddEdit.aspx.cs" Inherits="Ecommerce.AdminManager.CatAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">

        <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">ניהול מוצרים</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    הוספה / עריכת מוצר
                       
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:HiddenField ID="HidCid" runat="server" Value="-1" />
                            <div class="form-group">
                                <label>שם המוצר</label>
                                <asp:TextBox ID="TxtCname" CssClass="form-control" runat="server" placeholder="נא הזן שם קטגוריה" />

                            </div>

                            <div class="form-group">
                                <label>קטגורית אב</label>
                                <asp:TextBox ID="TxtParentCid" CssClass="form-control" runat="server" placeholder="נא הזן קטגורית אב" />

                            </div>


                            <div class="form-group">
                                <label>תיאור המוצר</label>
                                <asp:TextBox ID="TxtCdesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="10" Columns="40" placeholder="נא הזן תיאור הקטגוריה" />

                            </div>


                            <div class="form-group">
                                <label>שם תמונה</label>
                                <asp:Image ID="ImgPicname" CssClass="form-control" runat="server"  />

                            </div>
                            

                            <div class="form-group">
                                <label>  מוצר תמונה</label>
                                <asp:FileUpload ID="UploadPic" runat="server" />

                            </div>


                            <asp:button ID="BtnSave" class="btn btn-primary" OnClick="BtnSave_Click" runat="server" Text="שמירה" />


                        </div>
                        <!-- /.col-lg-6 (nested) -->

                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="underFooter" runat="server">
</asp:Content>
