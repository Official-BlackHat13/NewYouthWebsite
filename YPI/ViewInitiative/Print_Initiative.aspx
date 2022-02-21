<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_Initiative.aspx.cs" Inherits="Print_Initiative" %>

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
    <link href="icon_fonts_assets/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <style>
        @import url(css/droidarabickufi.css);

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
            border: solid 0px #000000;
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
    <%----%>
    <form id="form1" runat="server">
        <br />
        <table width="98%" cellpadding="2" align="center" cellspacing="2">
            <tr>
                <td align="center">
                    <img alt="" src="img/MYALogoH.png">
                </td>
            </tr>
            <tr>
                <td height="10"></td>
            </tr>
            <tr>
                <td align="center" class="Legendtitle">
                    <asp:Label ID="labMainTitle" runat="server" Text="المبادر المحترف"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="30"></td>
            </tr>
            <tr>
                <td align="center" class="Legendtitle_1">مقدم الطلب معلومات</td>
            </tr>

             <tr>
                <td align="center" class="Legendtitle_1">Ref:   <asp:Label ID="lblLabelRef" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="8" cellspacing="0">
                        <tr>
                            <td class="" colspan="2">
                                <span class="btxt_orange "><i class="fa fa-user-circle-o fa-2x" aria-hidden="true"></i>&nbsp;اسم  :</span>
                                <asp:Label ID="labName" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                        <tr>
                            <td class="bdrtblTop ">
                                <span class="btxt_orange "><i class="fa fa-mobile fa-3x" aria-hidden="true"></i>&nbsp; الهاتف :</span>
                                <asp:Label ID="labMobile" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange "><i class="fa fa-envelope fa-2x" aria-hidden="true"></i>&nbsp; البريد الالكتروني  :</span>
                                <asp:Label ID="labEmail" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                        <tr>
                            <td class="bdrtblTop ">
                                <span class="btxt_orange "><i class="fa fa-id-card-o fa-2x" aria-hidden="true"></i>&nbsp; الرقم المدني :</span>
                                <asp:Label ID="labCivilID" runat="server" Text=""></asp:Label>

                            </td>
                            <td class="bdrtblTop bdrtblRight">
                                <span class="btxt_orange "><i class="fa fa-university fa-2x" aria-hidden="true"></i>&nbsp; المؤهل الدراسي  :</span>
                                <asp:Label ID="labEducationQualification" runat="server" Text=""></asp:Label>

                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="40"></td>
            </tr>
            <tr>
                <td align="center" class="Legendtitle_1">معلومات برنامج المبادر المحترف</td>
            </tr>
            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0">
                        <tr>

                            <td class="">
                                <span class="btxt_orange ">مجالات المشروع  :</span>
                                <asp:Label ID="labcategory" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>

                            <td class="bdrtblTop">
                                <span class="btxt_orange ">اسم المشروع :</span>
                                <asp:Label ID="labInitiativeName" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>

                            <td class=" bdrtblTop">
                                <span class="btxt_orange ">مقدم الطلب :</span>
                                <asp:Label ID="LabType" runat="server" Text=""></asp:Label>
                            </td>
                            <%-- <td class="btxt_orange bdrtblRight bdrtblTop">نوع الطلب :
                            </td>
                            <td class="bdrtblRight bdrtblTop">
                                <asp:Label ID="labRequestType" runat="server" Text=""></asp:Label>
                            </td>--%>
                        </tr>

                       
                        <tr id="PanExperience" runat="server">
                            <td>
                                <table class="btxt_1 " dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                                    <tr>

                                        <td height="30" class=" bdrtblTop"><span class="btxt_orange ">هل سبق لك أن قدمت مشروع مشابه :</span>
                                            <asp:Label ID="labSimilarProject" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="PanSimilarProjectYes" runat="server">
                                        <td>
                                            <table class="btxt_1 " dir="rtl" width="100%" cellpadding="0" cellspacing="0">
                                                <tr>

                                                    <td height="30" class=" bdrtblTop"><span class="btxt_orange ">طبيعة المشروع :</span>
                                                        <asp:Label ID="labExperienceType" runat="server" Text=""></asp:Label>

                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td height="30" class=" bdrtblTop"><span class="btxt_orange ">نبذة عن المشروع :</span>
                                                        <asp:Label ID="labOldDesc" runat="server" Text=""></asp:Label>

                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td height="30" class=" bdrtblTop"><span class="btxt_orange ">هل كانت تجربتك بالمشروع ناجحة أم واجهتك معوقات؟ :</span>
                                                        <asp:Label ID="labWastheproject" runat="server" Text=""></asp:Label>

                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td height="30" class=" bdrtblTop" colspan="3">
                                                        <span class=" btxt_orange" id="labdesc" runat="server"></span>:
                                                        <asp:Label ID="lablabWastheprojectdesc" runat="server" Text=""></asp:Label>

                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>

                        <tr>

                            <td class=" bdrtblTop">
                                <span class="btxt_orange ">نبذة عن المشروع :</span>
                                <asp:Label ID="labInitiativeDesc" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>

                            <td class=" bdrtblTop">
                                <span class="btxt_orange ">الأهداف :</span>
                                <asp:Label ID="labInitiativeObjectives" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                           <tr>

                            <td class=" bdrtblTop">
                                <span class="btxt_orange ">كيف علمت بنا  :</span>
                                <asp:Label ID="lblHowtoKnow" runat="server" Text=""></asp:Label>
                            </td>
                          
                        </tr>
                         <tr>

                            <td class=" bdrtblTop">
                                <span class="btxt_orange ">Incubator :</span>
                                <asp:Label ID="lblIncubator" runat="server" Text=""></asp:Label>
                            </td>
                          
                        </tr>
                            <tr runat="server" id="tdIncu" visible="false">

                            <td class=" bdrtblTop">
                                <span class="btxt_orange ">   أختار أحد حاضنات الأعمال  :</span>
                                <asp:Label ID="lblChoosenIncubator" runat="server" Text=""></asp:Label>
                            </td>
                          
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td align="center">
                    <asp:Label ID="labPostDate" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
