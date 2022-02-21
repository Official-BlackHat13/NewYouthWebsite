<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_EvalStadium.aspx.cs" Inherits="Evaluator_Print_EvalStdium" %>

<!DOCTYPE html>
<head>

    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="Design/scripts/validate.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <script src="https://cdn.jsdelivr.net/jquery.validation/1.15.1/jquery.validate.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Kaushan+Script" rel="stylesheet">
    <link href="Design/css/style.css" rel="stylesheet">

    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">

    <script language="javascript">
        function CallPrint() {

            window.print()
        }
    </script>
</head>
<body onload="CallPrint();">
    <form runat="server">



        <div class="container">

           <%-- <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6"></div>
                   
                    <div class="col-md-3">
                        <asp:LinkButton ID="LNkCancel" runat="server" Text="رجوع" PostBackUrl="~/Evaluator/Eval_Stadium.aspx" CssClass="btn btn-success btn-sm"></asp:LinkButton>
                    </div>
                    <div class="col-md-3"></div>

                </div>
            </div>--%>


            <div class="row py-3">
                <div class="col-md-4">
                    <img src="Design/img/moy-logo.png" />

                </div>
                <div class="col-md-4 text-center">
                    <img src="Design/img/new-kuwait.png" />

                </div>
                <div class="col-md-4 text-right">
                    <img src="Design/img/kwt-gov.png" />

                </div>

            </div>


            <div class="radio-yes-no radius-top">

                <div class="row dir-change ">

                    <div class="col-md-6">
                        مشرف الملعب :
                        <asp:Label ID="LblName" runat="server"></asp:Label>
            
                    </div>


                    <div class="col-md-6">
                        التاريخ :
                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                    </div>


                </div>


                <div class="row dir-change">
                    <div class="col-md-6 py-2">
                        اسم الملعب : 
                
                <asp:Label ID="lblStadiumName" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-6 py-2">
                        المنطقة : 

                <asp:Label ID="lblGovernorateName" runat="server"></asp:Label>

                    </div>




                </div>


            </div>





            <div class="row">
                <div class="col-md-12">

                    <div class="radio-yes-no">
                        <div class="table-color">
                            <table class="table borderless dir-change">
                                <tbody>



                                    <tr class="d-flex">
                                        <td class="col-3">
                                            <label for="yes_no_radio1"><strong>مدخل الملعب</strong></label></td>
                                        <td class="col-9">

                                            <asp:RadioButtonList ID="radioEntrance" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList" Enabled="false" >
                                                <asp:ListItem Value="1" Text="صالح"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="غير صالح">  </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                    </tr>

                                    <tr class="d-flex">
                                        <td class="col-3">
                                            <label for="yes_no_radio1"><strong>أرضية الملعب</strong></label></td>
                                        <td class="col-9">

                                            <asp:RadioButtonList ID="RadioPlayField" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList" Enabled="false">
                                                <asp:ListItem Value="1" Text="صالح"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="غير صالح">  </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                    </tr>

                                    <tr class="d-flex">
                                        <td class="col-3">
                                            <label for="yes_no_radio1"><strong>تحديد الملعب</strong></label></td>
                                        <td class="col-9">

                                            <asp:RadioButtonList ID="RadioPitch" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList" Enabled="false">
                                                <asp:ListItem Value="1" Text="صالح"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="غير صالح">  </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                    </tr>

                                    <tr class="d-flex">
                                        <td class="col-3">
                                            <label for="yes_no_radio1"><strong>المرمى </strong></label>
                                        </td>
                                        <td class="col-9">

                                            <asp:RadioButtonList ID="RadioGoal" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList" Enabled="false">
                                                <asp:ListItem Value="1" Text="صالح"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="غير صالح">  </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                    </tr>



                                    <tr class="d-flex">
                                        <td class="col-3">
                                            <label for="yes_no_radio1"><strong>شبك المرمى.</strong></label></td>
                                        <td class="col-9">

                                            <asp:RadioButtonList ID="RadioGoalKick" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList" Enabled="false">
                                                <asp:ListItem Value="1" Text="يوجد"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="لايوجد">  </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                    </tr>

                                    <tr class="d-flex">
                                        <td class="col-3">
                                            <label for="yes_no_radio1"><strong>ماء(برادة)</strong></label></td>
                                        <td class="col-9">

                                            <asp:RadioButtonList ID="RadioWater" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList" Enabled="false">
                                                <asp:ListItem Value="1" Text="يوجد"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="لايوجد">  </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                    </tr>

                                    <tr class="d-flex">
                                        <td class="col-3">
                                            <label for="yes_no_radio1"><strong>كشافات إضاءة</strong></label></td>
                                        <td class="col-9">

                                            <asp:RadioButtonList ID="RadioHeadLamp" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList" Enabled="false">
                                                <asp:ListItem Value="1" Text="يوجد"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="لايوجد">  </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                    </tr>

                                    <tr class="d-flex">
                                        <td class="col-3">
                                            <label for="yes_no_radio1"><strong>حمامات</strong> </label>
                                        </td>
                                        <td class="col-9">

                                            <asp:RadioButtonList ID="RadioWashooms" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList" Enabled="false">
                                                <asp:ListItem Value="1" Text="يوجد"> </asp:ListItem>
                                                <asp:ListItem Value="2" Text="لايوجد">  </asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                    </tr>


                                    <br />
                                    <tr>

                                        <td class="yellow-color"><strong>ملاحظات :</strong></td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <textarea runat="server" id="TextNote" col="3" rows="3" style="width: 80%;" disabled="disabled"></textarea>

                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>
            </div>

            <div class="ground-bg">
                <div class="row no-gutters">

                    <div class="col-md-6 col-12 col-sm-12 border-white">


                        <h2 class="direction">Top Left Image</h2>

                        <div class="uploadPreview">
                            <img id="StrTopLeftFile" runat="server" src=""  />
                        </div>



                    </div>

                    <div class="col-md-6 col-12 col-sm-12 border-white">

                        <div class="uploadPreview">
                            <img id="StrTopRightFile" runat="server" src="" />
                        </div>



                    </div>
                </div>
                <div class="row  no-gutters">

                    <div class="col-md-6 col-12  col-sm-12 border-white">

                        <div class="uploadPreview">

                            <img runat="server" id="StrBotomnLeftFile" src="" />
                        </div>



                    </div>

                    <div class="col-md-6 col-12 col-sm-12 border-white">

                        <div class="uploadPreview">
                            <img id="StrBotomnRightFile" runat="server" src="" />
                        </div>



                    </div>
                </div>
            </div>

            <div class="foot-sign">
                <form>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="formGroupExampleInput">الشرف :</label>

                                <asp:TextBox ID="TxtHonour" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="formGroupExampleInput">مسؤول المنطقة :</label>
                                <asp:TextBox ID="TextAdmin" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>

                        </div>


                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="formGroupExampleInput">رئيس الفريق : </label>
                                <asp:TextBox ID="TextTeamLeader" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>

                        </div>




                    </div>

                </form>
            </div>




        </div>


    </form>

    <script>

        $(document).ready(function () {
            var _URL = window.URL || window.webkitURL;
            $("h2.direction").hide();
            $("#file").change(function (e) {
                var image, file;
                if ((file = this.files[0])) {
                    image = new Image();
                    image.onload = function () {
                        src = this.src;
                        $('#uploadPreview').html('<img src="' + src + '"></div>');
                        e.preventDefault();
                    }
                    $("h2.direction").show();




                };
                image.src = _URL.createObjectURL(file);
                $("#file").hide();
            });

        });
    </script>


</body>
