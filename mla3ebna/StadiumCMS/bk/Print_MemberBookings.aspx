<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_MemberBookings.aspx.cs" Inherits="Print_MemberBookings" %>

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
                    <asp:Label ID="labMainTitle" runat="server" Text="الملف الشخصي"></asp:Label>
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

                       
                        <asp:Repeater ID="rpPersonaldetails" runat="server">
                            <ItemTemplate>

                                <tr>
                                    <td>Name</td>
                                    <td><%#Eval("Name")%> </td>
                                </tr>

                                <tr>
                                    <td>CivilID</td>
                                    <td><%#Eval("CivilID")%> </td>
                                </tr>

                                <tr>
                                    <td>Email</td>
                                    <td><%#Eval("Email")%> </td>
                                </tr>

                                <tr>
                                    <td>Phone</td>
                                    <td><%#Eval("Phone")%> </td>
                                </tr>

                                <tr>
                                    <td>Governate</td>
                                    <td><%#Eval("GovernorateName")%> </td>
                                </tr>



                            </ItemTemplate>
                        </asp:Repeater>
                        </table>

                    
                </td>
            </tr>

             <tr>
                <td align="center" class="Legendtitle">
                    <asp:Label ID="Label1" runat="server" Text="تفاصيل Booking "></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="30"></td>
            </tr>

            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0">
                        
                        <tr>
                            <th><span class="btxt_orange ">StadiumName</span></th>
                            <th><span class="btxt_orange ">BookingDate</span></th>
                            <th><span class="btxt_orange ">BookingTime</span> </th>
                            <th><span class="btxt_orange ">BookingStatus</span> </th>
                            <th><span class="btxt_orange ">PaymentStatus</span> </th>
                            <th><span class="btxt_orange ">Reserved Date</span> </th>
                        </tr>


                        <asp:Repeater ID="rpBookingdetails" runat="server">
                            <ItemTemplate>

                                <tr>
                                    <td>

                                        <%#DataBinder.Eval(Container.DataItem, "StadiumName")%>

                                    </td>
                                    <td>

                                        <%#DataBinder.Eval(Container.DataItem, "BookingDate")%>
                                    </td>


                                    <td>

                                        <%#DataBinder.Eval(Container.DataItem, "BookingTime")%>

                                    </td>

                                    <td>

                                        <%#GetBookingStatus(Eval("BookingStatus"))%>
                                    </td>


                                    <td>

                                        <%#GetPaymentStatus(Eval("PaymentStatus"))%>

                                    </td>

                                    <td>

                                        <%#DataBinder.Eval(Container.DataItem, "CreatedAt")%>

                                    </td>
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>


                    </table>
                </td>
            </tr>
            <tr>
                <td height="20"></td>
            </tr>

            <tr>
                <td align="center"></td>
            </tr>
        </table>
    </form>
</body>
</html>
