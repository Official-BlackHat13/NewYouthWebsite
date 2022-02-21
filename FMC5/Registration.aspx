<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="FMC_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%-- <script src="../Content/JS/script.js"></script>--%>




    <script type="text/javascript">
        function showpreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                if (input.files[0].size > 3 * 1048576) {
                    alert("Should not exceed 3MB")
                    $(input).val('');
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>

    <style>
        .GenderRadio input[type=radio] {
            margin-right: 24px;
        }


        @media ( max-width:762px ) {


            .table td {
                border-top: none;
            }

            table#PageContent_radioEdu {
                width: 100%;
            }

                table#PageContent_radioEdu tr td {
                    display: block;
                    width: 100%;
                }

                    table#PageContent_radioEdu tr td label {
                        margin-right: 10px;
                    }
        }

        .regi_fmc .checkbox input[type=checkbox], .checkbox-inline input[type=checkbox], .radio input[type=radio], .radio-inline input[type=radio] {
            position: absolute;
            margin-right: 4px;
        }
    </style>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" runat="Server">


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

    <div class="container-fluid">

        <div class="container text-right">

            <div class="text-center mt-50">
                <h3>عذرا، لقد تم تسجيلك مسبقا </h3>

            </div>

            <hr />

            <div class="row" style="direction: rtl;">
                <asp:HiddenField ID="hiddencivil" runat="server" />

                <div class="col-xs-12 col-md-12">



                    <div class="text-right alert alert-danger" id="alert" runat="server" visible="false">

                        <h5 class="red">عذرا، لقد تم تسجيلك مسبقا </h5>

                    </div>

                    <div class="text-right alert alert-danger" id="DivAge" runat="server" visible="false">

                        <h5 class="red">ألا يتجاوز عمر المتقدمة 27 سنة من تاريخ بدأ التسجيل. </h5>

                    </div>

                    <div class="text-right alert alert-danger " id="Divgender" runat="server" visible="false">

                        <h5 class="red">Not Eligible to Apply </h5>

                    </div>


                    <div class="col-lg-12 col-xs-12 ">

                        <asp:Panel ID="pnlForm" runat="server" Visible="true">

                            <div class="col-12 form-group row mb-3">
                                <label class="col-sm-3  ">اسم مقدم الطلب(حسب البطاقة المدنية)  </label>
                                <div class="col-sm-2 col-xs-12 pull-right">
                                    <asp:TextBox ID="txtFname" Style="margin-bottom: 5px;" placeholder="الأول" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtFname"
                                        CssClass="text-danger" Display="Dynamic"
                                        ValidationGroup="submitionform" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-2 col-xs-12 pull-right">
                                    <asp:TextBox ID="txtMname" Style="margin-bottom: 5px;" placeholder="الثاني" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtMname"
                                        CssClass="text-danger" Display="Dynamic"
                                        ValidationGroup="submitionform" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-2 col-xs-12 pull-right">
                                    <asp:TextBox ID="txtThirdName" Style="margin-bottom: 5px;" placeholder="الثالث" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtThirdName"
                                        CssClass="text-danger" Display="Dynamic"
                                        ValidationGroup="submitionform" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 col-xs-12 pull-right">
                                    <asp:TextBox ID="txtsurname" Style="margin-bottom: 5px;" placeholder="الأخير" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtsurname"
                                        CssClass="text-danger" Display="Dynamic"
                                        ValidationGroup="submitionform" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div id="Div1" class="col-12 form-group row mb-3" runat="server">
                                <label class="col-sm-3   pt-2">
                                    الرقــم المـدني :
                                </label>

                                <div class="col-sm-9 col-xs-12 pull-right">
                                    <asp:TextBox runat="server" ID="txtCivil" CssClass="form-control" Enabled="true" OnTextChanged="txtCivil_TextChanged" AutoPostBack="true"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rqdCivil" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtCivil"
                                        CssClass="text-danger" Display="Dynamic"
                                        ValidationGroup="submitionform" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator
                                        EnableClientScript="true"
                                        ID="RegularExpressionValidator2" runat="server"
                                        ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                        ValidationGroup="submitionform"
                                        ControlToValidate="txtCivil" Display="dynamic"
                                        ValidationExpression="^[0-9,٠-٩]{12}$"
                                        CssClass="text-danger" SetFocusOnError="true" />
                                    <asp:Label ID="lblCivil" runat="server" Visible="false" SetFocusOnError="true" Text="الرقم المدني غير صحيح" />

                                </div>
                                <div class="clearfix">
                                </div>

                            </div>

                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    العمر
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" TextMode="Number" Enabled="false"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                        ControlToValidate="txtAge" CssClass="text-danger" Display="Dynamic" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    Phone
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" Enabled="true" AutoPostBack="true" OnTextChanged="txtCivil_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPhone"
                                        CssClass="text-danger" Display="Dynamic"
                                        ValidationGroup="submitionform" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator
                                        EnableClientScript="true"
                                        ID="RegularExpressionValidator10" runat="server"
                                        ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                        ValidationGroup="submitionform"
                                        ControlToValidate="txtPhone" Display="dynamic"
                                        ValidationExpression="^[0-9]{8}$"
                                        CssClass="text-danger"></asp:RegularExpressionValidator>

                                </div>
                            </div>

                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    صورة البطاقة المدنية 
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:FileUpload ID="filecivil" runat="server" ClientIDMode="Static" CssClass="form-control input-rounded" onchange="showpreview(filecivil);" />
                                    <span style="float: none; color: #6cacc5;">الرجاء تحميل صورة البطاقة الأمامية والخلفية</span>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="filecivil"
                                        CssClass="text-danger" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                        ValidationGroup="submitionform">
                                    </asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="text-danger"
                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                        ControlToValidate="filecivil" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                </div>

                            </div>

                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    صورة شخصية حديثة
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:FileUpload ID="Filephoto" runat="server" ClientIDMode="Static" CssClass="form-control input-rounded" onchange="showpreview(Filephoto);" />
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Filephoto"
                                                    CssClass="text-danger" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                    ValidationGroup="submitionform">
                                                </asp:RequiredFieldValidator>--%>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="text-danger"
                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                        ControlToValidate="Filephoto" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                </div>


                            </div>



                            <div class="col-12 form-group row mb-3">

                                <label class="col-lg-3   pt-2" for="inputRounded">
                                    التخصص
                                </label>

                                <div class="col-lg-9 col-12 pull-right radio radio-info  GenderRadio">
                                    <asp:RadioButtonList ID="radioEdu" runat="server" RepeatDirection="Horizontal" Style="display: inline-block;">
                                        <asp:ListItem Value="1" Text="هندسة ميكانيكية"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="هندسة كهربائية"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="هندسة صناعية"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="هندسة مدنية"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="هندسة بيئية"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="هندسة كيميائية"></asp:ListItem>
                                    </asp:RadioButtonList>

                                    <asp:RequiredFieldValidator ID="rqdEdu" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                        ControlToValidate="radioEdu" CssClass="text-danger" Display="Dynamic" SetFocusOnError="true"
                                        ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                </div>

                            </div>

                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    المعدل العام( من أربع نقاط) 
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:TextBox runat="server" ID="txtaverage" CssClass="form-control" TextMode="Number" ClientIDMode="Static"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                        ControlToValidate="txtaverage" CssClass="text-danger" Display="Dynamic" ValidationGroup="submitionform"></asp:RequiredFieldValidator>


                                    <asp:CustomValidator ID="customvalidato" runat="server" ControlToValidate="txtaverage" ErrorMessage="Invalid Range" Display="Dynamic" ValidationGroup="submitionform"
                                        SetFocusOnError="true" CssClass="text-danger" ClientValidationFunction="GetScoreRange"></asp:CustomValidator>


                                </div>
                            </div>

                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    المؤهل الدراسي   
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:FileUpload ID="fpQualification" runat="server" ClientIDMode="Static" CssClass="form-control input-rounded" onchange="showpreview(fpQualification);" />


                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="text-danger"
                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                        ControlToValidate="fpQualification" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                </div>

                            </div>

                            <div class="col-12 form-group row mb-3">

                                <label for="date" class="col-sm-3   pt-2">
                                    تاريخ التخرج
                                </label>

                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">


                                    <%--<asp:TextBox ID="txtGraduationDate" runat="server" CssClass="form-control" onkeypress="return false;" onpaste="return false;"></asp:TextBox>--%>
                                    <asp:TextBox runat="server" ID="txtGraduationDate" TextMode="Date" onkeypress="return false;" ClientIDMode="Static" onpaste="return false;" autocomplete="false" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                        ControlToValidate="txtGraduationDate" CssClass="text-danger" Display="Dynamic" ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                </div>
                            </div>


                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    وكشف الدرجات النهائي معتمد ومتضمناً معدل التخرج النهائي.  
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:FileUpload ID="FileAcademicCertificate" runat="server" ClientIDMode="Static" CssClass="form-control input-rounded" onchange="showpreview(FileAcademicCertificate);" />

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                        ControlToValidate="FileAcademicCertificate" CssClass="text-danger" Display="Dynamic" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="text-danger"
                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                        ControlToValidate="FileAcademicCertificate" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                </div>

                            </div>




                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    شهادة لمن يهمه الامر حديثة صادرة من المؤسسة العامة للتأمينات الاجتماعية.
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:FileUpload ID="FileConcernCertificate" runat="server" ClientIDMode="Static" CssClass="form-control input-rounded" onchange="showpreview(FileConcernCertificate);" />
                                    <span style="float: none; color: #6cacc5;">( الشهادة يجب أن تصدر خلال فترة الاعلان ) ولن يتم قبول الطلب أن كان تاريخ الشهادة قبل تاريخ الإعلان ) </span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                        ControlToValidate="FileConcernCertificate" CssClass="text-danger" Display="Dynamic" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="text-danger"
                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                        ControlToValidate="FileConcernCertificate" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>

                                </div>

                            </div>




                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    معادلة الشهادة الدراسية من وزارة التعليم العالي للحاصلين على المؤهل الجامعي من غير جامعة الكويت.
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:FileUpload ID="FileHigherEdu" runat="server" ClientIDMode="Static" CssClass="form-control input-rounded" onchange="showpreview(FileHigherEdu);" />

                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                    ControlToValidate="FileHigherEdu" CssClass="text-danger" Display="Dynamic" ValidationGroup="submitionform"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="text-danger"
                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                        ControlToValidate="FileHigherEdu" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                </div>

                            </div>

                            <%-- <div class="col-12 form-group row mb-3" style="display:none;">

                                            <label class="col-sm-3   pt-2" for="inputRounded">
                                                شهادة صادرة من جهة التخرج بالمعدل العام الموازي لنظام أربع نقاط أو النظام الرقمي للجامعات.
                                            </label>
                                            <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                                <asp:FileUpload ID="Filegraduation" runat="server" ClientIDMode="Static" CssClass="form-control input-rounded" onchange="showpreview(Filegraduation);" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                    ControlToValidate="Filegraduation" CssClass="text-danger" Display="Dynamic" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                    ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="text-danger"
                                                    ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                                    ControlToValidate="Filegraduation" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                            </div>

                                        </div>--%>

                            <div class="col-12 form-group row mb-3">

                                <label class="col-sm-3   pt-2" for="inputRounded">
                                    السيرة الذاتية في اللغة الإنجليزية.
                                </label>
                                <div class="col-sm-9 col-xs-12 pull-right radio radio-info">
                                    <asp:FileUpload ID="FileCV" runat="server" ClientIDMode="Static" CssClass="form-control input-rounded" onchange="showpreview(FileCV);" />

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                        ControlToValidate="FileCV" CssClass="text-danger" Display="Dynamic" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="text-danger"
                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                        ControlToValidate="FileCV" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                </div>

                            </div>


                            <div class="col-12 form-group row mb-3">
                                <label class="col-sm-3   pt-2" for="inputRounded">
                                </label>
                                <div class="col-sm-8">
                                    <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="submitionform" CssClass="btn btn-lg btn-info m-auto" Text="ارسل" />
                                    <asp:Label ID="lblerror" runat="server" CssClass="text-danger"></asp:Label>
                                </div>
                            </div>


                        </asp:Panel>

                    </div>

                    <div class="heading-f-bg"></div>

                </div>

            </div>

        </div>

        <script>
            function GetScoreRange(source, args) {

                var value = parseFloat($("#txtaverage").val());
                if (typeof value === 'number') {
                    if (value > 4)
                        return (args.IsValid = false);
                    else if (value < 1)
                        return (args.IsValid = false);
                    else
                        return (args.IsValid = true);
                }
                else
                    return (args.IsValid = false);

            }
        </script>

    </div>


</asp:Content>


