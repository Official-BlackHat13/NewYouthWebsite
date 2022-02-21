<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_EvalStadium1.aspx.cs" Inherits="Evaluator_Print_EvalStadium" %>

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
<body onload="CallPrint();">
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
                    <asp:Label ID="labMainTitle" runat="server" Text="Evaluation Stadium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="30"></td>
            </tr>

            <asp:Repeater ID="repeater" runat="server">
                <ItemTemplate>



                    <tr>
                        <td align="center">
                            <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td class="">
                                        <span class="labdetails">Stadium Name </span>
                                        <asp:Label ID="Labelstadium" runat="server" Text='<%#Eval("StadiumName") %>'></asp:Label>

                                    </td>
                                    <td class="bdrtblRight">
                                        <span class="labdetails">Evaluation By </span>
                                        <asp:Label ID="LabelEvaluationBy" runat="server" Text='<%#Eval("Name") %>'></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td class="bdrtblTop">
                                        <span class="labdetails">مدخل الملعب : </span>
                                        <asp:Label ID="LabelEntrance" runat="server" Text='<%#Eval("StadiumEntrance") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <span class="labdetails">أرضية الملعب : </span>
                                        <asp:Label ID="LabelField" runat="server" Text='<%#Eval("PlayingField") %>'></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="bdrtblTop">
                                        <span class="labdetails">تحديد الملعب : </span>
                                        <asp:Label ID="LabelPitch" runat="server" Text='<%#Eval("Pitch") %>'></asp:Label>

                                    </td>
                                    <td class="bdrtblTop bdrtblRight">
                                        <span class="labdetails">المرمى : </span>
                                        <asp:Label ID="LabelGoal" runat="server" Text='<%#Eval("Goal") %>'></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td class="bdrtblTop">
                                        <span class="labdetails">شبك المرمى. : </span>
                                        <asp:Label ID="LabelGoalKick" runat="server" Text='<%#Eval("GoalKick") %>'></asp:Label>

                                    </td>
                                    <td class="bdrtblTop bdrtblRight">
                                        <span class="labdetails">ماء(برادة): </span>
                                        <asp:Label ID="LabelWater" runat="server" Text='<%#Eval("Water") %>'></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td class="bdrtblTop">
                                        <span class="labdetails">كشافات إضاءة : </span>
                                        <asp:Label ID="LabelHeadLight" runat="server" Text='<%#Eval("HeadlampLighting") %>'></asp:Label>

                                    </td>
                                    <td class="bdrtblTop bdrtblRight">
                                        <span class="labdetails">حمامات </span>
                                        <asp:Label ID="LabelRooms" runat="server" Text='<%#Eval("BathRooms") %>'></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td class="bdrtblTop">
                                        <span class="labdetails">Note : </span>
                                        <asp:Label ID="LabelNote" runat="server" Text='<%#Eval("Note") %>'></asp:Label>

                                    </td>

                                    <td class="bdrtblTop bdrtblRight">
                                        <span class="labdetails">Honour : </span>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Honour") %>'></asp:Label>
                                    </td>

                                </tr>

                                <tr>
                                    <td class="bdrtblTop">
                                        <span class="labdetails">Administrator : </span>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("DistrictAdministrator") %>'></asp:Label>

                                    </td>

                                    <td class="bdrtblTop bdrtblRight">
                                        <span class="labdetails">TeamLeader : </span>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("TeamLeader") %>'></asp:Label>
                                    </td>

                                </tr>

                            </table>
                        </td>
                    </tr>


                </ItemTemplate>
            </asp:Repeater>

            <tr>
                <td align="center">
                    <table class="btxt_1 bdrtbl" dir="rtl" width="95%" cellpadding="5" cellspacing="0">

                        <tr>

                            <td class="bdrtblTop" runat="server" id="DivTRI">
                                <span class="labdetails">TopRightImage : </span>
                                <%=StrTopRightFile %>

                            </td>

                            <td class="bdrtblTop bdrtblRight" runat="server" id="DivTLI">
                                <span class="labdetails">TopLeftImage </span>
                                <%=StrTopLeftFile %>
                            </td>

                        </tr>


                        <tr>
                            <td class="bdrtblTop" runat="server" id="DivBRI">
                                <span class="labdetails">BotomnRightImage : </span>
                                <%=StrBotomnRightFile %>
                            </td>

                            <td class="bdrtblTop bdrtblRight" runat="server" id="DivBLI">
                                <span class="labdetails">BotomnLeftImage </span>
                                <%=StrBotomnLeftFile %>
                            </td>

                        </tr>

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
