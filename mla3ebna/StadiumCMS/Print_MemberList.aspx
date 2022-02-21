<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_MemberList.aspx.cs" Inherits="Print_MemberList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>&nbsp;</title>
    <style type="text/css" media="print">
        @page {
            margin: 0px;
            size: auto;
        }
    </style>
    <link href="Design/icon_fonts_assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <style>
        @import url(Design/css/droidarabickufi.css);

        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            font-family: 'Droid Arabic Kufi', Arial;
            font-size: 12px;
        }

        .title {
            font-family: 'Droid Arabic Kufi', Arial;
            font-size: 12px;
            font-weight: bold;
            color: #3D8585;
            padding-top: 0px;
            padding-bottom: 5px;
            border-bottom-style: dashed;
            border-bottom-width: 1px;
            border-bottom-color: #ccc;
        }

        .Legendtitle {
            font-family: 'Droid Arabic Kufi', Arial;
            font-size: 19px;
            font-weight: bold;
            color: #000;
        }

        .Legendtitle_1 {
            font-family: 'Droid Arabic Kufi', Arial;
            font-size: 14px;
            font-weight: bold;
            color: #000;
        }

        .btxt_orange {
            font-weight: bold;
            font-size: 11px;
            color: #469a2f;
            font-style: normal;
            font-family: 'Droid Arabic Kufi', Tahoma;
        }

        .btxt_orange_1 {
            font-weight: bold;
            font-size: 11px;
            color: #C6982F;
            font-style: normal;
            font-family: 'Droid Arabic Kufi', Tahoma;
        }

        .btxt {
            font-weight: bold;
            font-size: 12px;
            color: #666;
            font-style: normal;
            font-family: 'Droid Arabic Kufi', Tahoma;
        }

        .btxt_1 {
            font-weight: bold;
            font-size: 11px;
            color: #666;
            font-style: normal;
            font-family: 'Droid Arabic Kufi', Tahoma;
        }

        .bdrtbl {
            border: solid 1px #000000;
        }

        .txtcenter {
            text-align: center !important;
        }

        .bdrtbl {
            border: dashed 1px #e9e7e7;
        }

        .bdrtblTop {
            border-top: dashed 1px #e9e7e7;
        }

        .bdrtblBottom {
            border-bottom: solid 1px #000000;
        }

        .bdrtblRight {
            border-right: dashed 1px #e9e7e7;
        }

        .bdrtblLeft {
            border-left: solid 1px #000000;
        }

        .fa-2x {
            font-size: 1.25em !important;
        }

        .fa-3x {
            font-size: 1.6em !important;
        }
    </style>

   <script language="javascript">
       // function CallPrint() {
       window.onload = function () {
           window.print()
       }
    </script>

    <style>
        #RptTable {
           border-collapse: collapse;
           width: 100%;
       }

        /*table, td, th {
            /*border: 1px solid black;
            border-bottom: 1px solid #ddd;
              padding: 8px;
           
        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" cellpadding="2" cellspacing="2">
            <tr>
                <td align="center">
                    <img alt="" src="img/MaleabnaLogoH.png">
                </td>
            </tr>
            <tr>
                <td height="30"></td>
            </tr>
            <tr>
                <td align="center" class="Legendtitle">
                    <asp:Label ID="labMainTitle" runat="server" Text="Members List"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="30"></td>
            </tr>
          
            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0" id="RptTable">
                        <tr> 
                            <th>  <span class="btxt_orange ">Name</span></th>
                            <th> <span class="btxt_orange ">Email</span></th>
                            <th> <span class="btxt_orange ">Phone</span> </th>
                           
                            <th> <span class="btxt_orange ">GovernorateName</span> </th>
                           <%-- <th> <span class="btxt_orange ">AreaName</span> </th>
                            <th> <span class="btxt_orange ">اسم الملعب</span> </th>--%>
                           
                        </tr>
                       
                        
                        <asp:Repeater ID="rpdetails" runat="server">
                            <ItemTemplate>



                                <tr align="center">
                                    <td>

                                        <asp:Label ID="LblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>

                                    </td>
                                    <td>

                                        <asp:Label ID="LablEmail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Email")%>'></asp:Label>
                                    </td>


                                    <td>

                                        <asp:Label ID="LblPhn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Phone")%>'></asp:Label>

                                    </td>

                                   
                                    <td>

                                        <asp:Label ID="LblGov" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GovernorateName")%>'></asp:Label>
                                    </td>


                                  
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>

                       

                    </table>
                </td>
            </tr>
           
           
            
        </table>
    </form>
</body>
</html>

