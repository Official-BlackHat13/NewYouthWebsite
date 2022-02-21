<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_Booking.aspx.cs" Inherits="StadiumCMS_Print_Booking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        function CallPrint() {
            window.print()
        }
    </script>
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
                    <asp:Label ID="labMainTitle" runat="server" Text="تفاصيل Booking"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="30"></td>
            </tr>
            <%-- <tr>
                <td align="center" class="Legendtitle_1">مقدم الطلب معلومات</td>
            </tr>--%>
            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0">
                        <tr>
                            <td class="" colspan="2">
                                <span class="btxt_orange ">اسم الملعب :</span>
                                <asp:Label ID="LabStadiumName" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                        <tr>
                            <td class="bdrtblTop ">
                                <span class="btxt_orange ">تاريخ الحجز :</span>
                                <asp:Label ID="LabBookingDate" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">وقت الحجز  :</span>
                                <asp:Label ID="LabBookingTime" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                        <tr>
                            <td class="bdrtblTop ">
                                <span class="btxt_orange ">حالة الحجز :</span>
                                <asp:Label ID="LabBookingStatus" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">Payment Status  :</span>
                                <asp:Label ID="LabPaymentStatus" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>

                    </table>
                </td>
            </tr>
            <tr>
                <td height="20"></td>
            </tr>
            <tr>
                <td align="center" class="Legendtitle_1">مقدم الطلب معلومات</td>
            </tr>
            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0">
                        <tr>
                            <td class=" ">
                                <span class="btxt_orange ">الاسم الثلاثي :</span>
                                <asp:Label ID="LabFullName" runat="server" Text=""></asp:Label>

                            </td>
                            <td class=" bdrtblRight">
                                <span class="btxt_orange ">الرقم المدني  :</span>
                                <asp:Label ID="LabCivilID" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                        <tr>
                            <td class="bdrtblTop ">
                                <span class="btxt_orange ">البريد الإلكتروني :</span>
                                <asp:Label ID="LabEmail" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">رقم الهاتف النقال  :</span>
                                <asp:Label ID="LabPhone" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                    </table>
                </td>
            </tr>

             <tr>
                <td height="20"></td>
            </tr>
            <tr>
                <td align="center" class="Legendtitle_1">تفاصيل Payment</td>
            </tr>
            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0">
                        <tr>
                            <td class=" ">
                                <span class="btxt_orange ">Payment ID :</span>
                                <asp:Label ID="LabPaymentID" runat="server" Text=""></asp:Label>

                            </td>
                            <td class=" bdrtblRight">
                                <span class="btxt_orange ">Tran ID :</span>
                                <asp:Label ID="LabTranID" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                        <tr>
                            <td class="bdrtblTop ">
                                <span class="btxt_orange ">Ref :</span>
                                <asp:Label ID="LabRef" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">Auth  :</span>
                                <asp:Label ID="LabAuth" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                         <tr>
                            <td class="bdrtblTop ">
                                <span class="btxt_orange ">Track ID :</span>
                                <asp:Label ID="LabTrackID" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange ">Payment Date  :</span>
                                <asp:Label ID="LabPaymentDate" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
        </table>
         <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
    </form>
</body>
</html>
