<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_BlockStadiums.aspx.cs" Inherits="Print_BlockStadiums" %>

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
    <link href="Design/icon_fonts_assets/font-awesome/css/font-awesome.min.css" rel="stylesheet">
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
            color: #C6982F;
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
            border-right: solid 0px #000000;
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
        function CallPrint() {
            window.print()
        }
    </script>
</head>
<body onload="CallPrint()">
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
                    <asp:Label ID="labMainTitle" runat="server" Text="View Block Stadium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="30"></td>
            </tr>
           
            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0">
                        <tr>
                            <td class="">
                                <span class="btxt_orange ">Stadium Block By :</span>
                                <asp:Label ID="lblstadiumblockby" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblRight">
                                <span class="btxt_orange "> Date From :</span>
                                <asp:Label ID="lbldetefrom" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="bdrtblTop">
                                <span class="btxt_orange ">Date To  :</span>
                                <asp:Label ID="lbldateto" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">Block By :</span>
                                <asp:Label ID="Labblockby" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                         <tr runat="server" id="trgov">
                            <td class="bdrtblTop">
                                <span class="btxt_orange ">Governorate :</span>
                                <asp:Label ID="LabGovernorate" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">Area :</span>
                                <asp:Label ID="LabArea" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr runat="server" id="trschool">
                            <td class="bdrtblTop">
                                <span class="btxt_orange ">School :</span>
                                <asp:Label ID="LabSchool" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">Stadium :</span>
                                <asp:Label ID="LabStadium" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>

                        <tr runat="server" id="trtimeslot">
                            <td class="bdrtblTop">
                                <span class="btxt_orange ">Court :</span>
                                <asp:Label ID="LabCourt" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">Time Slot :</span>
                                <asp:Label ID="Labtimeslot" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>    
                        <tr >
                            <td class="bdrtblTop">
                                <span class="btxt_orange ">Comment :</span>
                                <asp:Label ID="lblcomment" runat="server" Text=""></asp:Label>

                            </td>
                           
                        </tr>  
                        <tr runat="server" id="trmsg">
                            <td class="bdrtblTop">
                                <span class="btxt_orange ">Message :</span>
                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>

                            </td>
                           
                        </tr>                         
                      
                    </table>
                </td>
            </tr>
            <tr>
                <td height="20"></td>
            </tr>
            
            <tr>
                <td align="center">
                   
                </td>
            </tr>
        </table>
         <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
    </form>
</body>
</html>

