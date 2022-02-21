<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Eval_Stadium.aspx.cs" Inherits="Evaluator_Eval_Stadium" MasterPageFile="StadiumEvalMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--   <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script> --%>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script src="Design/scripts/validate.js"></script>

    <script src="https://cdn.jsdelivr.net/jquery.validation/1.15.1/jquery.validate.min.js"></script>

    <link href="Design/css/style.css" rel="stylesheet">

    <style>
        .modal {
            margin: 15% 0;
        }

        .modal-header {
            background-color: #437665;
        }

        .close {
            margin-top: 10px;
        }

        .modal-title, .close {
            color: #fff;
        }

        iframe {
            border: none;
        }

        .modal-body {
            background-color: #e5ebe9;
        }

        .table-color table {
            color: #fff !important;
        }

        .element-box .container {
            max-width: 100%;
        }

        .video-upload {
            width: 250px;
            margin-top: 10px;
            background-color: #d3e7c4;
            padding: 10px;
            border: 1px solid #60923b;
            border-radius: 10px;
        }

        .action-button {
            color: #fff;
            background: rgb(167,18,18);
            background: linear-gradient(90deg, rgba(167,18,18,1) 0%, rgba(121,33,9,1) 100%, rgba(255,0,0,1) 100%);
            cursor: pointer;
        }

        .btn:hover {
            color: #ccc;
        }
    </style>

    <script>

        $(document).ready(function () {
            var _URL = window.URL || window.webkitURL;
            $("h2.direction").hide();
            $("input[id$=fpTopRightImg]").change(function (e) {

                var image, file;
                if ((file = this.files[0])) {
                    image = new Image();
                    image.onload = function () {
                        src = this.src;
                        $('#uploadPreview').html('<img src="' + src + '" class="container-fluid"></div>');
                        e.preventDefault();
                    }
                    $("h2.direction").show();




                };
                image.src = _URL.createObjectURL(file);
                //$("input[id$=fpTopRightImg]").hide();
            });

        });
    </script>



    <script>

        $(document).ready(function () {
            var _URL = window.URL || window.webkitURL;
            $("h2.direction").hide();
            $("input[id$=fpTopLeftImg]").change(function (e) {

                var image, file;
                if ((file = this.files[0])) {
                    image = new Image();
                    image.onload = function () {
                        src = this.src;
                        $('#uploadPreviewTL').html('<img src="' + src + '" class="container-fluid"></div>');
                        e.preventDefault();
                    }
                    $("h2.direction").show();




                };
                image.src = _URL.createObjectURL(file);
                // $("input[id$=fpTopLeftImg]").hide();
            });

        });
    </script>



    <script>

        $(document).ready(function () {
            var _URL = window.URL || window.webkitURL;
            $("h2.direction").hide();
            $("input[id$=fpBotomnRightImg]").change(function (e) {

                var image, file;
                if ((file = this.files[0])) {
                    image = new Image();
                    image.onload = function () {
                        src = this.src;
                        $('#uploadPreviewBR').html('<img src="' + src + '" class="container-fluid"></div>');
                        e.preventDefault();
                    }
                    $("h2.direction").show();




                };
                image.src = _URL.createObjectURL(file);
                //  $("input[id$=fpBotomnRightImg]").hide();
            });

        });
    </script>



    <script>

        $(document).ready(function () {
            var _URL = window.URL || window.webkitURL;
            $("h2.direction").hide();
            $("input[id$=fpBotomnLeftImg]").change(function (e) {

                var image, file;
                if ((file = this.files[0])) {
                    image = new Image();
                    image.onload = function () {
                        src = this.src;
                        $('#uploadPreviewBL').html('<img src="' + src + '" class="container-fluid"></div>');
                        e.preventDefault();
                    }
                    $("h2.direction").show();




                };
                image.src = _URL.createObjectURL(file);
                //  $("input[id$=fpBotomnLeftImg]").hide();
            });

        });
    </script>

    <script type="text/javascript">
        function HomecheckBoxValidate(sender, args) {
            var checkBoxList = document.getElementById("<%=chkStadium.ClientID %>");
               var checkboxes = checkBoxList.getElementsByTagName("input");
               
               var isValid = false;
               for (var i = 0; i < checkboxes.length; i++) {
                   if (checkboxes[i].checked) {
                       isValid = true;
                       break;
                      
                   }
               }
               args.IsValid = isValid;
           }
    </script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Eval_Stadium.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">الملعب</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="Evaluation"></asp:Label></span>
        </li>
    </ul>

    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Manage_EvalStadium.aspx" id="manageEvaluation" runat="server"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; View StadiumEvaluation </span></a>
                        </div>
                        <h6 class="element-header">الملعب</h6>

                        <div class="element-box">

                            <%-- <img src="Design/img/ground.jpg" />--%>

                            <div class="container">

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="formGroupExampleInput">
                                                Stadium :  
                                            </label>
                                            <asp:CustomValidator ID="customHome" runat="server" ErrorMessage="Required" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"
                                                ValidationGroup="required" ClientValidationFunction="HomecheckBoxValidate"></asp:CustomValidator>
                                            
                                            <asp:RadioButtonList ID="chkStadium" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                           <%-- <asp:CheckBoxList ID="chkStadium" ClientIDMode="Static" RepeatDirection="Horizontal" runat="server">
                                            </asp:CheckBoxList>--%>




                                        </div>

                                    </div>
                                </div>




                                <div class="row">
                                    <div class="col-md-12">

                                        <div class="radio-yes-no">
                                            <div class="table-color">

                                                <asp:HiddenField ID="HDStadiumID" runat="server" />

                                                <table class="table borderless dir-change">
                                                    <tbody>



                                                        <tr class="d-flex">
                                                            <td class="col-3">
                                                                <label for="yes_no_radio1"><strong>مدخل الملعب</strong></label>
                                                                <asp:RequiredFieldValidator ID="reqradioEntrance" runat="server" ControlToValidate="radioEntrance" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>
                                                            <td class="col-9">

                                                                <asp:RadioButtonList ID="radioEntrance" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList">
                                                                    <asp:ListItem Value="1" Text="صالح"> </asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="غير صالح">  </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>

                                                        </tr>

                                                        <tr class="d-flex">
                                                            <td class="col-3">
                                                                <label for="yes_no_radio1"><strong>أرضية الملعب</strong></label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioPlayField" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>
                                                            <td class="col-9">

                                                                <asp:RadioButtonList ID="RadioPlayField" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList">
                                                                    <asp:ListItem Value="1" Text="صالح"> </asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="غير صالح">  </asp:ListItem>
                                                                </asp:RadioButtonList>

                                                            </td>

                                                        </tr>

                                                        <tr class="d-flex">
                                                            <td class="col-3">
                                                                <label for="yes_no_radio1"><strong>تحديد الملعب</strong></label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioPitch" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>
                                                            <td class="col-9">

                                                                <asp:RadioButtonList ID="RadioPitch" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList">
                                                                    <asp:ListItem Value="1" Text="صالح"> </asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="غير صالح">  </asp:ListItem>
                                                                </asp:RadioButtonList>

                                                            </td>

                                                        </tr>

                                                        <tr class="d-flex">
                                                            <td class="col-3">
                                                                <label for="yes_no_radio1"><strong>المرمى </strong></label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RadioGoal" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>
                                                            <td class="col-9">

                                                                <asp:RadioButtonList ID="RadioGoal" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList">
                                                                    <asp:ListItem Value="1" Text="صالح"> </asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="غير صالح">  </asp:ListItem>
                                                                </asp:RadioButtonList>

                                                            </td>

                                                        </tr>



                                                        <tr class="d-flex">
                                                            <td class="col-3">
                                                                <label for="yes_no_radio1"><strong>شبك المرمى.</strong></label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadioGoalKick" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>
                                                            <td class="col-9">

                                                                <asp:RadioButtonList ID="RadioGoalKick" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList">
                                                                    <asp:ListItem Value="1" Text="يوجد"> </asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="لايوجد">  </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>

                                                        </tr>

                                                        <tr class="d-flex">
                                                            <td class="col-3">
                                                                <label for="yes_no_radio1"><strong>ماء(برادة)</strong></label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RadioWater" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>
                                                            <td class="col-9">

                                                                <asp:RadioButtonList ID="RadioWater" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList">
                                                                    <asp:ListItem Value="1" Text="يوجد"> </asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="لايوجد">  </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>

                                                        </tr>

                                                        <tr class="d-flex">
                                                            <td class="col-3">
                                                                <label for="yes_no_radio1"><strong>كشافات إضاءة</strong></label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="RadioHeadLamp" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>
                                                            <td class="col-9">

                                                                <asp:RadioButtonList ID="RadioHeadLamp" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList">
                                                                    <asp:ListItem Value="1" Text="يوجد"> </asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="لايوجد">  </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>

                                                        </tr>

                                                        <tr class="d-flex">
                                                            <td class="col-3">
                                                                <label for="yes_no_radio1"><strong>حمامات</strong> </label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="RadioWashooms" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>
                                                            <td class="col-9">

                                                                <asp:RadioButtonList ID="RadioWashooms" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtonList">
                                                                    <asp:ListItem Value="1" Text="يوجد"> </asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="لايوجد">  </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>

                                                        </tr>


                                                        <br />
                                                        <tr>

                                                            <td class="yellow-color"><strong>ملاحظات :</strong>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextNote" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <textarea runat="server" id="TextNote" col="3" rows="3" style="width: 80%;"></textarea>

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


                                            <h2 class="direction">Top Right Image</h2>
                                            <asp:FileUpload ID="fpTopRightImg" runat="server" CssClass="File" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="fpTopRightImg" ErrorMessage="Required" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                            <div id="uploadPreview">
                                            </div>



                                        </div>

                                        <div class="col-md-6 col-12 col-sm-12 border-white">
                                            <%-- <input type="file" id="file1" />--%>
                                            <asp:FileUpload ID="fpTopLeftImg" runat="server" CssClass="File" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="fpTopLeftImg" ErrorMessage="Required" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                            <div id="uploadPreviewTL">
                                            </div>
                                        </div>



                                    </div>

                                    <div class="row  no-gutters">

                                        <div class="col-md-6 col-12  col-sm-12 border-white">
                                            <asp:FileUpload ID="fpBotomnRightImg" runat="server" CssClass="File" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="fpBotomnRightImg" ErrorMessage="Required" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                            <div id="uploadPreviewBR">
                                            </div>



                                        </div>

                                        <div class="col-md-6 col-12 col-sm-12 border-white">
                                            <asp:FileUpload ID="fpBotomnLeftImg" runat="server" CssClass="File" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="fpBotomnLeftImg" ErrorMessage="Required" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                            <div id="uploadPreviewBL">
                                            </div>



                                        </div>
                                    </div>
                                </div>


                                <div class="clearfix"></div>
                                <div class="">
                                    <div class="row no-gutters">
                                        <div class="col-md-12 col-12  col-sm-12">


                                            <div class="video-upload">
                                                <label for="formGroupExampleInput">Upload a video :</label>
                                                <input type="button" name="next" class="btn action-button" value="Click Here" id="FileUpload" data-toggle="modal" data-target="#FileModal" />
                                            </div>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>

                                    <div class="foot-sign">
                                        <form>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="formGroupExampleInput">الشرف :</label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextHonour" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                        <asp:TextBox ID="TextHonour" runat="server" CssClass="form-control" placeholder="الشرف"></asp:TextBox>

                                                    </div>

                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="formGroupExampleInput">مسؤول المنطقة :</label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextDistributor" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>


                                                        <asp:TextBox ID="TextDistributor" runat="server" CssClass="form-control" placeholder="مسؤول المنطقة"></asp:TextBox>
                                                    </div>

                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="formGroupExampleInput">رئيس الفريق : </label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextTeamLeader" ErrorMessage="*" CssClass="error" Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>

                                                        <asp:TextBox ID="TextTeamLeader" class="form-control" runat="server" placeholder="رئيس الفريق"></asp:TextBox>
                                                    </div>

                                                </div>




                                            </div>




                                        </form>
                                    </div>

                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label for="formGroupExampleInput">&nbsp;&nbsp;</label>
                                            <asp:LinkButton ID="LinkSubmit" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="LinkSubmit_Click" ValidationGroup="required"></asp:LinkButton>

                                        </div>
                                    </div>
                                </div>


                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>



        <div class="popup-window">
            <div class="modal fade" tabindex="-1" id="FileModal">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Video </h4>
                        </div>


                        <div class="modal-body">

                            <iframe src="EvaluationVideo.aspx" width="100%" height="250px" class="iframe-bg" runat="server" id="FIleIframme"></iframe>

                        </div>


                    </div>
                </div>
            </div>
        </div>




   
</asp:Content>
