<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" EnableEventValidation="false" Inherits="YCLC_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script src="../assets/js/jquery.min.js"></script>
  
    <style>
        .txt-content {
            padding: 20px 30px;
            background-color: #2e99b0;
            margin: 20px 0;
            border-radius: 10px 10px 10px 10px !important;
            color: #fff;
        }

        .dir-rtl {
            direction: rtl;
            text-align: right;
        }

        body {
            font-family: 'Neo Sans Arabic';

        }

        .input-group-text {
            margin-left: -4px;
        }



        .reg-group-form {
            display: none;
        }



        .reg-group-form {
            padding: 0 40px 0 0;
        }

            .reg-group-form .input-group .form-control {
                margin-right: 20px;
            }

            .reg-group-form .input-group-prepend {
       position: absolute;
    top: 8px;
    right: -17px;
    font-size: 20px;
    /* border: 1px solid #ccc; */
    width: 100%;
    padding: 2px 1px;
    /* background-color: #2e99b0; */
    color: #fff;
    width: 35px;
    /* padding-right: 10px; */
            }

            .reg-group-form .custom-select {
                position: absolute;
                right: 22px;
                height: 32px;
            }

        .phone-number {
            margin-right: 80px !important;
    
        }

        .reg-group-form select {
            height: 32px !important;
        }

        .reg-group-form .input-group .form-control {
            min-width: 900px;
        }

        .reg-group-form .phone-number {
            min-width: 780px !important;
        }

        .inside-page h2, .inside-page h3, .inside-page p {
            color: #fff !important;
        }

        .reg-group-form {
            background-color: #fff;
            padding: 50px;
            margin-top: 50px;
            margin-bottom: 50px;
            border: 1px solid #ccc;
            border-radius: 50px 0 50px 0;
            box-shadow: 2px 2px 20px #b1acac;
        }

        .btn-style {
            width: 280px;
            padding: 20px;
            font-size: 23px;
            border-radius: 15px 0 15px 0;
            box-shadow: 2px 2px 0px #000;
        }

        .mt-50 {
            margin-top: 50px;
        }

        @media (max-width:768px) {

            .reg-group-form .input-group .form-control {
                min-width: 300px;
            }

            .reg-group-form {
                padding: 10px !important;
                border: 0;
                box-shadow: none;
                background-color: none;
            }

                .reg-group-form .phone-number {
                    min-width: 240px !important;
                }

            .form-bg1 {
                padding: 0 !important;
            }

            .reg-group-form .input-group .form-control {
                max-width: 192px !important;
            }

            .phone-number {
                /*max-width: 162px !important;*/
            }
        }

        .btn-style {
            width: 280px;
            padding: 20px;
            font-size: 23px;
            border-radius: 15px 10px 15px 10px !important;
            box-shadow: 2px 2px 0px #000;
        }

        .mt-50 {
            margin-top: 50px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
   

     <div class="main-content">      
        <div class="rs-breadcrumbs bg-6">
            <div class="container">
                <div class="content-part text-center">
                    <h1 class="breadcrumbs-title white-color mb-0">مجلس الشباب</h1>
                </div>
            </div>
        </div>

    </div>

    <div class="container-fluid">

        <div class="container-bg dir-rtl py-5 mt-50 inside-page ">
      

                <div class="container ">
                    <div class="row">


                        <div class="col-md-12 txt-content">
                            <h3>نرحب بانضمامكم إلى مسابقات دوري الإبداع الشبابي   
                                    
                                    
                                       (الموسم الثالث)  


                            </h3>

                            <br />
                            
                            <h3>تسجيل الجهات </h3>

                            <p>إضغط على تسجيل الجهات لتقديم البيانات اللازمة من أجل الحصول على إسم مستخدم لإستعماله في تسجيل المشاركين من جهتكم (سوف يتم إرسال إسم المستخدم على البريد الإلكتروني ) </p>

                        </div>

                    </div>

                    <div class="row mt-25 ">
                       
                        <div class="col-md-6 col-xs-12  text-center">

                            <button class="btn btn-info btn-style reg-group text-center">تسجيل الجهات </button>


                        </div>
                        <div class="col-md-6  col-xs-12 text-center mt-xs-25">

                              
                           <%-- <asp:LinkButton ID="linkIndividual" runat="server" OnClick="linkIndividual_Click" CssClass="btn btn-info btn-style" Text="تسجيل الأفراد"></asp:LinkButton>--%>

                             <button class="btn btn-info btn-style text-center" id="btnjointype"> تسجيل الأفراد </button>
                        </div>

                    </div>
                    <br />



                    <div class="row mt-30 form-bg1 px-5">

                        <div class="col-md-10.reg-group-form .input-group .form-control">

                            <div class="reg-group-form">

                                <h1>تسجيل الجهات</h1>
                                <hr />

                                <div class="form-group input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-user"></i></span>
                                    </div>
                                    <asp:TextBox ID="TxtName" runat="server" placeholder="اسم الموظف المسئول" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtName"
                                        CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator27" ControlToValidate="TxtName" CssClass="text-danger"
                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                        ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                </div>
                                <!-- form-group// -->
                                <div class="form-group input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-envelope"></i></span>
                                    </div>

                                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="personalInfo" CssClass="form-control" placeholder="البريد الالكتروني"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="rqdEmail1" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                                        CssClass="text-danger"
                                        ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                        ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true"
                                        ControlToValidate="txtEmail" CssClass="text-danger" Display="dynamic"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="personalInfo"></asp:RegularExpressionValidator>

                                </div>
                                <!-- form-group// -->
                                <div class="form-group input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fa fa-phone"></i></span>
                                    </div>
                                    <select class="custom-select" style="max-width: 120px;">
                                        <option selected="">+965</option>

                                    </select>
                                    <asp:TextBox ID="TxtPhone" runat="server" class="form-control phone-number" placeholder="رقم الهاتف" MaxLength="8"></asp:TextBox>
                                     <div class="clearfix"></div>
                                    <asp:RequiredFieldValidator ID="rqdContactnumber1" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtPhone"
                                        CssClass="text-danger"  ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator
                                        EnableClientScript="true"
                                        ID="RegularExpressionValidator2" runat="server"
                                        ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                        ValidationGroup="personalInfo" SetFocusOnError="true"
                                        ControlToValidate="TxtPhone" Display="dynamic"
                                        ValidationExpression="^[0-9,٠-٩]{8}$"
                                        CssClass="text-danger" />
                                </div>
                                <!-- form-group// -->
                                <asp:UpdatePanel ID="updatepannel" runat="server">
                                    <ContentTemplate>


                                        <div class="form-group input-group" runat="server" visible="false">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fa fa-building"></i></span>
                                            </div>
                                            <asp:DropDownList ID="DDlOrganization" runat="server" CssClass="form-control org" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDlOrganization" InitialValue="0"
                                                CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>


                                        </div>


                                    </ContentTemplate>
                                </asp:UpdatePanel>

                               
                                <div class="form-group input-group dispOrg" runat="server" visible="true">
                                    <div class="input-group-prepend dispOrg">
                                        <span class="input-group-text"><i class="fa fa-building"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtOrganization" class="form-control dispOrg" placeholder="اسم الجهة " runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtOrganization"
                                        CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>

                                </div>
                               

                                <div class="form-group">
                                    <%--<button type="submit" class="btn btn-info" data-toggle="modal" data-target="#success">Submit </button>--%>
                                    <asp:LinkButton ID="LnkSubmit" runat="server" class="btn btn-info" ValidationGroup="personalInfo" Text="ارسال" OnClick="LnkSubmit_Click"></asp:LinkButton>
                                    <button class="btn btn-danger cancel-btn">الغاء  </button>
                                </div>
                                <!-- form-group// -->

                                <%-- <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#success"> model</button> --%>

                                <div class="modal fade" id="success" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel">شكرا جزيلا</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <h3></h3>
                                                <p>لقد تم التسجيل بنجاح </p>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">الغاء </button>

                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <div class="modal fade" id="EmailExists" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="H1">&nbsp;</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">

                                                <p>عذرا! هذا البريد الالكتروني مسجل من قبل </p>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">الغاء </button>

                                            </div>
                                        </div>
                                    </div>
                                </div>


                               

                            </div>

                        </div>


                    </div>


                     <div class="modal fade" id="DivJoinType" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="H2">&nbsp;</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">

                                                <div class="row">
                                                    <div class="col-md-8 col-sm-12 col-xs-12 offset-2 text-center">
                                                        <asp:RadioButtonList ID="ddlJoinType" runat="server" RepeatDirection="Horizontal" >                                                           
                                                            <asp:ListItem Value="1" Text="إنضم للمسابقة مباشرة من غير تدريب" style="margin-left:20px;"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="انضم للمسابقة مع التدريب" style="margin-left:20px;"></asp:ListItem>
                                                        </asp:RadioButtonList>

                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="ddlJoinType"
                                                CssClass="text-danger" ValidationGroup="join"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-8 col-sm-12 col-xs-12 text-center">
                                                       <asp:LinkButton ID="lnkJoinSubmit" runat="server" CssClass="btn btn-success btn-lg" Text="Submit" OnClick="lnkJoinSubmit_Click" ValidationGroup="join"></asp:LinkButton>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">الغاء </button>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                </div>
       
        </div>
    </div>


   <%-- <div class="clearfix"></div>
    <div class="clearfix"></div>
    <div class="clearfix"></div>--%>

    <script>
        $(document).ready(function () {
            $(".reg-group").click(function () {
                $(".reg-group-form").toggle("slow");

            });
            $(".cancel-btn").click(function (e) {
                $(".reg-group-form").hide("slow");
                e.preventDefault(); // prevents default
                return false;

            });

            $("form").submit(function (e) {
                e.preventDefault();
            });

        });
    </script>

    <script type="text/javascript">
        function openModal() {

            $('#success').appendTo("body").modal('show');
        }
    </script>

    <script type="text/javascript">
        function openEmailExistsModel() {
            $('#EmailExists').appendTo("body").modal('show');
        }
    </script>
    

     <script type="text/javascript">
         function openJoinTypeModel() {
             $('#DivJoinType').appendTo("body").modal('show');
         }
    </script>

    <script type="text/javascript">
        $('#btnjointype').click(function () {

            $(".reg-group-form").hide("slow");
           
            $('#DivJoinType').modal('show');
        });
    </script>


</asp:Content>

