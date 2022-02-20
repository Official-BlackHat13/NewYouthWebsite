<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Youngleaders.aspx.cs" Inherits="Forms_Youngleaders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--    <style type="text/css">
        .titlec {
            font-weight: bold;
            padding-top: 10px;
        }

        select {
            height: 37px !important;
        }

        .Ph {
            direction: ltr;
            text-align: center;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div class="main-content">
        <!-- Breadcrumbs Section Start -->
        <div class="rs-breadcrumbs bg-6">
            <div class="container">
                <div class="content-part text-center">
                    <h1 class="breadcrumbs-title white-color mb-0">مجلس الشباب</h1>
                </div>
            </div>
        </div>

    </div>



    <div class="container">
        <div class="text-center mt-50">
            <h2>young leader</h2>
            <p>الرجاء تعبئة النموذج ادناه</p>
        </div>

        <hr class="hr-style" />




        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>

                <%-- <div class="form-group">
                        <div class="col-md-12">--%>
                <div class="row">


                    <div class="col-md-12 col-sm-12">
                        <div class="alert alert-success" runat="server" id="Divalert" visible="false">
                        </div>
                        <div id="alertCivilID" class="alert alert-danger" runat="server" visible="false">

                            <asp:Label ID="lblalert" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-12 PaddingButtom8PX">
                            <div class="titlec">الأسم الثلاثي &nbsp;<span class="color-red">*</span></div>
                            <asp:TextBox ID="txtFirstName" MaxLength="150" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                                ControlToValidate="txtFirstName" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4 ">
                                <div class="titlec">الرقم المدني&nbsp;<span class="color-red">*</span></div>
                                <asp:TextBox ID="txtNatNo" MaxLength="12" CssClass="form-control IsPositiveNumber civil" runat="server" OnTextChanged="txtNatNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6"
                                    ControlToValidate="txtNatNo" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                            </div>


                            <div class="col-md-4">
                                <div class="titlec">تاريخ الميلاد&nbsp;<span class="color-red">*</span></div>
                                <div class="inner-addon left-addon">

                                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                                    <i class="glyphicon glyphicon-calendar TransparentBackColor"></i>
                                </div>

                                <asp:Label ID="lblCivil" runat="server" Text="العمر غير مطابق لشروط" Visible="false" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="col-md-4 ">
                                <div class="titlec">الهاتف&nbsp;<span class="color-red">*</span></div>
                                <asp:TextBox ID="txtPhone" MaxLength="8" CssClass="form-control IsPositiveNumber phone" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7"
                                    ControlToValidate="txtPhone" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="titlec">الجنس&nbsp;<span class="color-red">*</span></div>

                                <asp:DropDownList ID="ddlSex" CssClass="form-control" runat="server">
                                    <asp:ListItem Selected="True" Text="" Value="-1"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="ذكر" Value="1"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="انثى" Value="0"></asp:ListItem>
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator runat="server" ID="rfvSex"
                                    ControlToValidate="ddlSex" ValidationGroup="ContactUs" InitialValue="-1"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-md-8 ">
                                <div class="titlec">المؤهل العلمي &nbsp;<span class="color-red">*</span></div>
                                <asp:TextBox ID="txtcertificate" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3"
                                    ControlToValidate="txtcertificate" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 ">

                        <div class="row">
                        <div class="col-md-6 PaddingButtom8PX">
                            <div class="titlec">الجنسية&nbsp;<span class="color-red">*</span></div>
                            <asp:TextBox ID="ddlNat" Text="الكويت" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>

                        <div class="col-md-6 ">
                            <div class="titlec">البريد الإلكتروني&nbsp;<span class="color-red">*</span></div>
                            <asp:TextBox ID="txtEmail" MaxLength="350" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                                ControlToValidate="txtEmail" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                Display="Dynamic" ErrorMessage="الرجاء اختيار بريد إلكتروني حقيقي" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="ContactUs"></asp:RegularExpressionValidator>
                        </div>

                        </div>
                    </div>

                    <asp:Panel runat="server" ID="pnlPlace" CssClass="col-md-12" Visible="true">
                        <div class="col-md-12">
                            <div class="titlec">نوع النشاط<span class="color-red">*</span></div>
                            <asp:TextBox ID="txtActivityType" MaxLength="50" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13"
                                ControlToValidate="txtActivityType" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                        </div>
                    </asp:Panel>

                    <p class="col-md-12 text-center" style="padding-top: 30px">
                        <asp:LinkButton Font-Bold="true" Width="150px" ID="btnSend" runat="server" CssClass="btn-u btn-brd btn-brd-hover btn-u-dark" Text="تسجيل" OnClick="btnSend_Click"></asp:LinkButton>
                    </p>

                    <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="message col-md-12">

                        <p>
                            <i class="rounded-x fa fa-check"></i>
                            <asp:Label ID="lblMessage" runat="server" Font-Size="Larger" Text="لقد تم ارسال طلبك بنجاح!" EnableViewState="false"></asp:Label>
                            <asp:Label ID="lblerror" runat="server" CssClass="text-red"></asp:Label>
                        </p>
                    </asp:Panel>



                    <asp:Button ID="btnBackToHome" runat="server" Text="Button" Style="display: none" OnClick="btnBackToHome_Click" />

                </div>

            </ContentTemplate>

        </asp:UpdatePanel>

    </div>


    <script type="text/javascript">
        $(function () {
            // Masking
            $("#date").mask('99/99/9999', { placeholder: 'X' });
            $(".phone").mask('99999999', { placeholder: 'X' });
            $(".civil").mask('999999999999', { placeholder: 'X' });
            $("#card").mask('9999-9999-9999-9999', { placeholder: 'X' });
            $("#serial").mask('***-***-***-***-***-***', { placeholder: '_' });
            $("#tax").mask('99-9999999', { placeholder: 'X' });
        });
    </script>

    <script>
        $(document).ready(function () {

            $(document).ready(function () {
                var d = new Date();
                d.setDate(d.getDate());
                $(".Datepicker").datepicker({
                    dateFormat: 'dd/mm/yy',
                    maxDate: d
                });
                var myVar = setInterval(myTimer, 100);
                function myTimer() {

                    $('#ui-datepicker-div').css('right', $('#ui-datepicker-div').css('left'));
                }

                $(".Datepicker2").datepicker({
                    dateFormat: 'dd/mm/yy'
                });
            });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(document).ready(function () {
                var d = new Date();
                d.setDate(d.getDate());
                $(".Datepicker").datepicker({
                    dateFormat: 'dd/mm/yy',
                    maxDate: d
                });

                var myVar = setInterval(myTimer, 100);
                function myTimer() {

                    $('#ui-datepicker-div').css('right', $('#ui-datepicker-div').css('left'));
                }

                $(".Datepicker2").datepicker({
                    dateFormat: 'dd/mm/yy'
                });
            });
        });
        function pageLoad() {
            $(".Datepicker").datepicker({
                dateFormat: 'dd/mm/yy'
            }).val();
        }

    </script>

    <script>

        function getMyOutput() {
            document.getElementById("alertCivilID").innerHTML = "This is the modified content portion";
            alert(document.getElementById("alertCivilID").innerHTML)
        }

        //function chat() {
        //    alert("Error!");
        //    document.getElementById("alertCivilID").innerHTML = "Already applied";
        //}
        //function ShowDivInnerHTML() {
        //    var c = document.getElementById('alertCivilID');
        //    alert("civilID already exist:\n" + c.innerHTML);
        //}
    </script>
</asp:Content>

