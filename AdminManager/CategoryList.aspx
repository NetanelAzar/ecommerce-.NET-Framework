<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManager/BackAdmin.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="Ecommerce.AdminManager.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <!-- DataTables CSS -->
    <link href="css/plugins/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">

                   <div class="row">
               <div class="col-lg-12">
                   <h1 class="page-header">ניהול קטגוריות</h1>
               </div>
               <!-- /.col-lg-12 -->
           </div>
           <!-- /.row -->
           <div class="row">
               <div class="col-lg-12">
                   <div class="panel panel-default">
                       <div class="panel-heading">
                           מאגר קטגוריות במערכת
                       </div>
                       <!-- /.panel-heading -->
                       <div class="panel-body">
                           <div class="table-responsive">
                               <table class="table table-striped table-bordered table-hover" id="MainTbl">
                                   <thead>
                                       <tr>
                                           <th>קוד קטגוריה</th>
                                           <th>שם קטגוריה</th>
                                           <th>קוד קטגוריה אב</th>
                                           <th>תמונה ראשית</th>
                                           <th>ניהול</th>
                                       </tr>
                                   </thead>
                                  <tbody>
                   <asp:Repeater ID="RptCat" runat="server">
                       <ItemTemplate>
                           <tr class="odd gradeX">
                               <td><%#Eval("Cid")%></td>
                               <td><%#Eval("Cname")%></td>
                               <td><%#Eval("ParentCid")%></td>
                               <td class="center"><img src="/uploads/prods/<%#Eval("Picname")%>" width="30" /> </td>
                               <td class="center"><a href="CatAddEdit.aspx?Cid=<%#Eval("Cid")%>" >ערוך <span class="fa fa-pencil" /></a></td>
                           </tr>
                       </ItemTemplate>
                   </asp:Repeater>
                                  </tbody>
                               </table>
                           </div>
                           <!-- /.table-responsive -->
                          
                       </div>
                       <!-- /.panel-body -->
                   </div>
                   <!-- /.panel -->
               </div>
               <!-- /.col-lg-12 -->
           </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="underFooter" runat="server">

            <!-- DataTables JavaScript -->
    <script src="js/jquery/jquery.dataTables.min.js"></script>
    <script src="js/bootstrap/dataTables.bootstrap.min.js"></script>
        <!-- Page-Level Demo Scripts - Tables - Use for reference -->
    <script>
        $(document).ready(function() {
            $('#MainTbl').dataTable({
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.0.7/i18n/he.json',
                }
            });
        });
    </script>

</asp:Content>
