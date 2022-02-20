<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="OnlineCourseReg.aspx.cs" Inherits="YouthValley_OnlineCourseReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

  <%--  <style type="text/css">
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



     <script src="../assets/plugins/sky-forms-pro/skyforms/js/jquery.maskedinput.min.js"></script>
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
           <h2>نموذج التسجيل الدورات اون لاين</h2>
            <p>الرجاء تعبئة النموذج ادناه</p>
        </div>

           <hr class="hr-style" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                     <div class="row">
                  <%--  <div class="form-group">--%>

                        <div class="col-md-12 col-sm-12">
                            <div class="alert alert-success" runat="server" id="Divalert" visible="false">
                               لقد تم ارسال طلبك بنجاح!
                            </div>

                             <div class="alert alert-danger" runat="server" id="Divalert1" visible="false">
                               Already Registered!!!!
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="row">
                            <div class="col-md-4 PaddingButtom8PX">
                                <div class="titlec">الاسم الأول &nbsp;<span class="color-red">*</span></div>
                                <asp:TextBox ID="txtFirstName" MaxLength="150" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfv3"
                                    ControlToValidate="txtFirstName" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-md-4 PaddingButtom8PX">
                                <div class="titlec">اسم الأب&nbsp;<span class="color-red">*</span></div>
                                <asp:TextBox ID="txtFatherName" MaxLength="150" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
                                    ControlToValidate="txtFatherName" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-md-4 PaddingButtom8PX">
                                <div class="titlec">اسم العائلة&nbsp;<span class="color-red">*</span></div>
                                <asp:TextBox ID="txtFamilyName" MaxLength="150" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                                    ControlToValidate="txtFamilyName" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>

                            </div>
                                </div>
                        </div>

                        <div class="col-md-12">
                           
                            <asp:UpdatePanel ID="updatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                     <div class="row">
                                    <div class="col-md-6 ">
                                        <div class="titlec">الرقم المدني&nbsp;<span class="color-red">*</span></div>
                                        <asp:TextBox ID="txtNatNo" MaxLength="12" CssClass="form-control IsPositiveNumber civil" runat="server" OnTextChanged="txtNatNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6"
                                            ControlToValidate="txtNatNo" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lblCivil" runat="server" Text="العمر غير مطابق لشروط" Visible="false" ForeColor="Red"></asp:Label>
                                    </div>


                                    <div class="col-md-6 ">
                                        <div class="titlec">الهاتف&nbsp;<span class="color-red">*</span></div>
                                        <asp:TextBox ID="txtPhone" MaxLength="8" CssClass="form-control IsPositiveNumber phone" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7"
                                            ControlToValidate="txtPhone" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                                    </div>

                                           </div>
                                </ContentTemplate>

                            </asp:UpdatePanel>
                          

                        </div>

                        <div class="col-md-12">
                            <div class="row">
                            <div class="col-md-4 PaddingButtom8PX">
                                <div class="titlec">الجنس&nbsp;<span class="color-red">*</span></div>

                                <asp:DropDownList ID="ddlSex" CssClass="form-control" runat="server">
                                    <asp:ListItem Selected="True" Text="" Value="-1"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="ذكر" Value="1"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="انثى" Value="0"></asp:ListItem>
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator runat="server" ID="rfvSex"
                                    ControlToValidate="ddlSex" ValidationGroup="ContactUs" InitialValue="-1"></asp:RequiredFieldValidator>


                            </div>
                            <div class="col-md-4 PaddingButtom8PX">
                                <div class="titlec">تاريخ الميلاد&nbsp;<span class="color-red">*</span></div>
                                <div class="inner-addon left-addon">

                                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                                </div>



                                <asp:Label ID="lblage" runat="server" Text="العمر غير مطابق لشروط" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="col-md-4 PaddingButtom8PX">


                                <div class="titlec">الجنسية&nbsp;<span class="color-red"></span></div>
                                <asp:DropDownList ID="ddlNat" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="AW" Text="آروبا"></asp:ListItem>
                                    <asp:ListItem Value="AZ" Text="أذربيجان"></asp:ListItem>
                                    <asp:ListItem Value="AM" Text="أرمينيا"></asp:ListItem>
                                    <asp:ListItem Value="ES" Text="أسبانيا"></asp:ListItem>
                                    <asp:ListItem Value="AU" Text="أستراليا"></asp:ListItem>
                                    <asp:ListItem Value="AF" Text="أفغانستان"></asp:ListItem>
                                    <asp:ListItem Value="AL" Text="ألبانيا"></asp:ListItem>
                                    <asp:ListItem Value="DE" Text="ألمانيا"></asp:ListItem>
                                    <asp:ListItem Value="AG" Text="أنتيجوا وبربودا"></asp:ListItem>
                                    <asp:ListItem Value="AO" Text="أنجولا"></asp:ListItem>
                                    <asp:ListItem Value="AI" Text="أنجويلا"></asp:ListItem>
                                    <asp:ListItem Value="AD" Text="أندورا"></asp:ListItem>
                                    <asp:ListItem Value="UY" Text="أورجواي"></asp:ListItem>
                                    <asp:ListItem Value="UZ" Text="أوزبكستان"></asp:ListItem>
                                    <asp:ListItem Value="UG" Text="أوغندا"></asp:ListItem>
                                    <asp:ListItem Value="UA" Text="أوكرانيا"></asp:ListItem>
                                    <asp:ListItem Value="IE" Text="أيرلندا"></asp:ListItem>
                                    <asp:ListItem Value="IS" Text="أيسلندا"></asp:ListItem>
                                    <asp:ListItem Value="ET" Text="اثيوبيا"></asp:ListItem>
                                    <asp:ListItem Value="ER" Text="اريتريا"></asp:ListItem>
                                    <asp:ListItem Value="EE" Text="استونيا"></asp:ListItem>
                                    <asp:ListItem Value="IL" Text="اسرائيل"></asp:ListItem>
                                    <asp:ListItem Value="AR" Text="الأرجنتين"></asp:ListItem>
                                    <asp:ListItem Value="JO" Text="الأردن"></asp:ListItem>
                                    <asp:ListItem Value="EC" Text="الاكوادور"></asp:ListItem>
                                    <asp:ListItem Value="AE" Text="الامارات العربية المتحدة"></asp:ListItem>
                                    <asp:ListItem Value="BS" Text="الباهاما"></asp:ListItem>
                                    <asp:ListItem Value="BH" Text="البحرين"></asp:ListItem>
                                    <asp:ListItem Value="BR" Text="البرازيل"></asp:ListItem>
                                    <asp:ListItem Value="PT" Text="البرتغال"></asp:ListItem>
                                    <asp:ListItem Value="BA" Text="البوسنة والهرسك"></asp:ListItem>
                                    <asp:ListItem Value="GA" Text="الجابون"></asp:ListItem>
                                    <asp:ListItem Value="ME" Text="الجبل الأسود"></asp:ListItem>
                                    <asp:ListItem Value="DZ" Text="الجزائر"></asp:ListItem>
                                    <asp:ListItem Value="DK" Text="الدانمرك"></asp:ListItem>
                                    <asp:ListItem Value="CV" Text="الرأس الأخضر"></asp:ListItem>
                                    <asp:ListItem Value="SV" Text="السلفادور"></asp:ListItem>
                                    <asp:ListItem Value="SN" Text="السنغال"></asp:ListItem>
                                    <asp:ListItem Value="SD" Text="السودان"></asp:ListItem>
                                    <asp:ListItem Value="SE" Text="السويد"></asp:ListItem>
                                    <asp:ListItem Value="EH" Text="الصحراء الغربية"></asp:ListItem>
                                    <asp:ListItem Value="SO" Text="الصومال"></asp:ListItem>
                                    <asp:ListItem Value="CN" Text="الصين"></asp:ListItem>
                                    <asp:ListItem Value="IQ" Text="العراق"></asp:ListItem>
                                    <asp:ListItem Value="VA" Text="الفاتيكان"></asp:ListItem>
                                    <asp:ListItem Value="PH" Text="الفيلبين"></asp:ListItem>
                                    <asp:ListItem Value="AQ" Text="القطب الجنوبي"></asp:ListItem>
                                    <asp:ListItem Value="CM" Text="الكاميرون"></asp:ListItem>
                                    <asp:ListItem Value="CG" Text="الكونغو - برازافيل"></asp:ListItem>
                                    <asp:ListItem Value="KW" Text="الكويت" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="HU" Text="المجر"></asp:ListItem>
                                    <asp:ListItem Value="IO" Text="المحيط الهندي البريطاني"></asp:ListItem>
                                    <asp:ListItem Value="MA" Text="المغرب"></asp:ListItem>
                                    <asp:ListItem Value="TF" Text="المقاطعات الجنوبية الفرنسية"></asp:ListItem>
                                    <asp:ListItem Value="MX" Text="المكسيك"></asp:ListItem>
                                    <asp:ListItem Value="SA" Text="المملكة العربية السعودية"></asp:ListItem>
                                    <asp:ListItem Value="GB" Text="المملكة المتحدة"></asp:ListItem>
                                    <asp:ListItem Value="NO" Text="النرويج"></asp:ListItem>
                                    <asp:ListItem Value="AT" Text="النمسا"></asp:ListItem>
                                    <asp:ListItem Value="NE" Text="النيجر"></asp:ListItem>
                                    <asp:ListItem Value="IN" Text="الهند"></asp:ListItem>
                                    <asp:ListItem Value="US" Text="الولايات المتحدة الأمريكية"></asp:ListItem>
                                    <asp:ListItem Value="JP" Text="اليابان"></asp:ListItem>
                                    <asp:ListItem Value="YE" Text="اليمن"></asp:ListItem>
                                    <asp:ListItem Value="GR" Text="اليونان"></asp:ListItem>
                                    <asp:ListItem Value="ID" Text="اندونيسيا"></asp:ListItem>
                                    <asp:ListItem Value="IR" Text="ايران"></asp:ListItem>
                                    <asp:ListItem Value="IT" Text="ايطاليا"></asp:ListItem>
                                    <asp:ListItem Value="PG" Text="بابوا غينيا الجديدة"></asp:ListItem>
                                    <asp:ListItem Value="PY" Text="باراجواي"></asp:ListItem>
                                    <asp:ListItem Value="PK" Text="باكستان"></asp:ListItem>
                                    <asp:ListItem Value="PW" Text="بالاو"></asp:ListItem>
                                    <asp:ListItem Value="BW" Text="بتسوانا"></asp:ListItem>
                                    <asp:ListItem Value="PN" Text="بتكايرن"></asp:ListItem>
                                    <asp:ListItem Value="BB" Text="بربادوس"></asp:ListItem>
                                    <asp:ListItem Value="BM" Text="برمودا"></asp:ListItem>
                                    <asp:ListItem Value="BN" Text="بروناي"></asp:ListItem>
                                    <asp:ListItem Value="BE" Text="بلجيكا"></asp:ListItem>
                                    <asp:ListItem Value="BG" Text="بلغاريا"></asp:ListItem>
                                    <asp:ListItem Value="BZ" Text="بليز"></asp:ListItem>
                                    <asp:ListItem Value="BD" Text="بنجلاديش"></asp:ListItem>
                                    <asp:ListItem Value="PA" Text="بنما"></asp:ListItem>
                                    <asp:ListItem Value="BJ" Text="بنين"></asp:ListItem>
                                    <asp:ListItem Value="BT" Text="بوتان"></asp:ListItem>
                                    <asp:ListItem Value="PR" Text="بورتوريكو"></asp:ListItem>
                                    <asp:ListItem Value="BF" Text="بوركينا فاسو"></asp:ListItem>
                                    <asp:ListItem Value="BI" Text="بوروندي"></asp:ListItem>
                                    <asp:ListItem Value="PL" Text="بولندا"></asp:ListItem>
                                    <asp:ListItem Value="BO" Text="بوليفيا"></asp:ListItem>
                                    <asp:ListItem Value="PF" Text="بولينيزيا الفرنسية"></asp:ListItem>
                                    <asp:ListItem Value="PE" Text="بيرو"></asp:ListItem>
                                    <asp:ListItem Value="TZ" Text="تانزانيا"></asp:ListItem>
                                    <asp:ListItem Value="TH" Text="تايلند"></asp:ListItem>
                                    <asp:ListItem Value="TW" Text="تايوان"></asp:ListItem>
                                    <asp:ListItem Value="TM" Text="تركمانستان"></asp:ListItem>
                                    <asp:ListItem Value="TR" Text="تركيا"></asp:ListItem>
                                    <asp:ListItem Value="TT" Text="ترينيداد وتوباغو"></asp:ListItem>
                                    <asp:ListItem Value="TD" Text="تشاد"></asp:ListItem>
                                    <asp:ListItem Value="TG" Text="توجو"></asp:ListItem>
                                    <asp:ListItem Value="TV" Text="توفالو"></asp:ListItem>
                                    <asp:ListItem Value="TK" Text="توكيلو"></asp:ListItem>
                                    <asp:ListItem Value="TO" Text="تونجا"></asp:ListItem>
                                    <asp:ListItem Value="TN" Text="تونس"></asp:ListItem>
                                    <asp:ListItem Value="TL" Text="تيمور الشرقية"></asp:ListItem>
                                    <asp:ListItem Value="JM" Text="جامايكا"></asp:ListItem>
                                    <asp:ListItem Value="GI" Text="جبل طارق"></asp:ListItem>
                                    <asp:ListItem Value="GD" Text="جرينادا"></asp:ListItem>
                                    <asp:ListItem Value="GL" Text="جرينلاند"></asp:ListItem>
                                    <asp:ListItem Value="AX" Text="جزر أولان"></asp:ListItem>
                                    <asp:ListItem Value="AN" Text="جزر الأنتيل الهولندية"></asp:ListItem>
                                    <asp:ListItem Value="TC" Text="جزر الترك وجايكوس"></asp:ListItem>
                                    <asp:ListItem Value="KM" Text="جزر القمر"></asp:ListItem>
                                    <asp:ListItem Value="KY" Text="جزر الكايمن"></asp:ListItem>
                                    <asp:ListItem Value="MH" Text="جزر المارشال"></asp:ListItem>
                                    <asp:ListItem Value="MV" Text="جزر الملديف"></asp:ListItem>
                                    <asp:ListItem Value="UM" Text="جزر الولايات المتحدة البعيدة الصغيرة"></asp:ListItem>
                                    <asp:ListItem Value="SB" Text="جزر سليمان"></asp:ListItem>
                                    <asp:ListItem Value="FO" Text="جزر فارو"></asp:ListItem>
                                    <asp:ListItem Value="VI" Text="جزر فرجين الأمريكية"></asp:ListItem>
                                    <asp:ListItem Value="VG" Text="جزر فرجين البريطانية"></asp:ListItem>
                                    <asp:ListItem Value="FK" Text="جزر فوكلاند"></asp:ListItem>
                                    <asp:ListItem Value="CK" Text="جزر كوك"></asp:ListItem>
                                    <asp:ListItem Value="CC" Text="جزر كوكوس"></asp:ListItem>
                                    <asp:ListItem Value="MP" Text="جزر ماريانا الشمالية"></asp:ListItem>
                                    <asp:ListItem Value="WF" Text="جزر والس وفوتونا"></asp:ListItem>
                                    <asp:ListItem Value="CX" Text="جزيرة الكريسماس"></asp:ListItem>
                                    <asp:ListItem Value="BV" Text="جزيرة بوفيه"></asp:ListItem>
                                    <asp:ListItem Value="IM" Text="جزيرة مان"></asp:ListItem>
                                    <asp:ListItem Value="NF" Text="جزيرة نورفوك"></asp:ListItem>
                                    <asp:ListItem Value="HM" Text="جزيرة هيرد وماكدونالد"></asp:ListItem>
                                    <asp:ListItem Value="CF" Text="جمهورية افريقيا الوسطى"></asp:ListItem>
                                    <asp:ListItem Value="CZ" Text="جمهورية التشيك"></asp:ListItem>
                                    <asp:ListItem Value="DO" Text="جمهورية الدومينيك"></asp:ListItem>
                                    <asp:ListItem Value="CD" Text="جمهورية الكونغو الديمقراطية"></asp:ListItem>
                                    <asp:ListItem Value="ZA" Text="جمهورية جنوب افريقيا"></asp:ListItem>
                                    <asp:ListItem Value="GT" Text="جواتيمالا"></asp:ListItem>
                                    <asp:ListItem Value="GP" Text="جوادلوب"></asp:ListItem>
                                    <asp:ListItem Value="GU" Text="جوام"></asp:ListItem>
                                    <asp:ListItem Value="GE" Text="جورجيا"></asp:ListItem>
                                    <asp:ListItem Value="GS" Text="جورجيا الجنوبية وجزر ساندويتش الجنوبية"></asp:ListItem>
                                    <asp:ListItem Value="DJ" Text="جيبوتي"></asp:ListItem>
                                    <asp:ListItem Value="JE" Text="جيرسي"></asp:ListItem>
                                    <asp:ListItem Value="DM" Text="دومينيكا"></asp:ListItem>
                                    <asp:ListItem Value="RW" Text="رواندا"></asp:ListItem>
                                    <asp:ListItem Value="RU" Text="روسيا"></asp:ListItem>
                                    <asp:ListItem Value="BY" Text="روسيا البيضاء"></asp:ListItem>
                                    <asp:ListItem Value="RO" Text="رومانيا"></asp:ListItem>
                                    <asp:ListItem Value="RE" Text="روينيون"></asp:ListItem>
                                    <asp:ListItem Value="ZM" Text="زامبيا"></asp:ListItem>
                                    <asp:ListItem Value="ZW" Text="زيمبابوي"></asp:ListItem>
                                    <asp:ListItem Value="CI" Text="ساحل العاج"></asp:ListItem>
                                    <asp:ListItem Value="WS" Text="ساموا"></asp:ListItem>
                                    <asp:ListItem Value="AS" Text="ساموا الأمريكية"></asp:ListItem>
                                    <asp:ListItem Value="SM" Text="سان مارينو"></asp:ListItem>
                                    <asp:ListItem Value="PM" Text="سانت بيير وميكولون"></asp:ListItem>
                                    <asp:ListItem Value="VC" Text="سانت فنسنت وغرنادين"></asp:ListItem>
                                    <asp:ListItem Value="KN" Text="سانت كيتس ونيفيس"></asp:ListItem>
                                    <asp:ListItem Value="LC" Text="سانت لوسيا"></asp:ListItem>
                                    <asp:ListItem Value="MF" Text="سانت مارتين"></asp:ListItem>
                                    <asp:ListItem Value="SH" Text="سانت هيلنا"></asp:ListItem>
                                    <asp:ListItem Value="ST" Text="ساو تومي وبرينسيبي"></asp:ListItem>
                                    <asp:ListItem Value="LK" Text="سريلانكا"></asp:ListItem>
                                    <asp:ListItem Value="SJ" Text="سفالبارد وجان مايان"></asp:ListItem>
                                    <asp:ListItem Value="SK" Text="سلوفاكيا"></asp:ListItem>
                                    <asp:ListItem Value="SI" Text="سلوفينيا"></asp:ListItem>
                                    <asp:ListItem Value="SG" Text="سنغافورة"></asp:ListItem>
                                    <asp:ListItem Value="SZ" Text="سوازيلاند"></asp:ListItem>
                                    <asp:ListItem Value="SY" Text="سوريا"></asp:ListItem>
                                    <asp:ListItem Value="SR" Text="سورينام"></asp:ListItem>
                                    <asp:ListItem Value="CH" Text="سويسرا"></asp:ListItem>
                                    <asp:ListItem Value="SL" Text="سيراليون"></asp:ListItem>
                                    <asp:ListItem Value="SC" Text="سيشل"></asp:ListItem>
                                    <asp:ListItem Value="CL" Text="شيلي"></asp:ListItem>
                                    <asp:ListItem Value="RS" Text="صربيا"></asp:ListItem>
                                    <asp:ListItem Value="CS" Text="صربيا والجبل الأسود"></asp:ListItem>
                                    <asp:ListItem Value="TJ" Text="طاجكستان"></asp:ListItem>
                                    <asp:ListItem Value="OM" Text="عمان"></asp:ListItem>
                                    <asp:ListItem Value="GM" Text="غامبيا"></asp:ListItem>
                                    <asp:ListItem Value="GH" Text="غانا"></asp:ListItem>
                                    <asp:ListItem Value="GF" Text="غويانا"></asp:ListItem>
                                    <asp:ListItem Value="GY" Text="غيانا"></asp:ListItem>
                                    <asp:ListItem Value="GN" Text="غينيا"></asp:ListItem>
                                    <asp:ListItem Value="GQ" Text="غينيا الاستوائية"></asp:ListItem>
                                    <asp:ListItem Value="GW" Text="غينيا بيساو"></asp:ListItem>
                                    <asp:ListItem Value="VU" Text="فانواتو"></asp:ListItem>
                                    <asp:ListItem Value="FR" Text="فرنسا"></asp:ListItem>
                                    <asp:ListItem Value="PS" Text="فلسطين"></asp:ListItem>
                                    <asp:ListItem Value="VE" Text="فنزويلا"></asp:ListItem>
                                    <asp:ListItem Value="FI" Text="فنلندا"></asp:ListItem>
                                    <asp:ListItem Value="VN" Text="فيتنام"></asp:ListItem>
                                    <asp:ListItem Value="FJ" Text="فيجي"></asp:ListItem>
                                    <asp:ListItem Value="CY" Text="قبرص"></asp:ListItem>
                                    <asp:ListItem Value="KG" Text="قرغيزستان"></asp:ListItem>
                                    <asp:ListItem Value="QA" Text="قطر"></asp:ListItem>
                                    <asp:ListItem Value="KZ" Text="كازاخستان"></asp:ListItem>
                                    <asp:ListItem Value="NC" Text="كاليدونيا الجديدة"></asp:ListItem>
                                    <asp:ListItem Value="HR" Text="كرواتيا"></asp:ListItem>
                                    <asp:ListItem Value="KH" Text="كمبوديا"></asp:ListItem>
                                    <asp:ListItem Value="CA" Text="كندا"></asp:ListItem>
                                    <asp:ListItem Value="CU" Text="كوبا"></asp:ListItem>
                                    <asp:ListItem Value="KR" Text="كوريا الجنوبية"></asp:ListItem>
                                    <asp:ListItem Value="KP" Text="كوريا الشمالية"></asp:ListItem>
                                    <asp:ListItem Value="CR" Text="كوستاريكا"></asp:ListItem>
                                    <asp:ListItem Value="CO" Text="كولومبيا"></asp:ListItem>
                                    <asp:ListItem Value="KI" Text="كيريباتي"></asp:ListItem>
                                    <asp:ListItem Value="KE" Text="كينيا"></asp:ListItem>
                                    <asp:ListItem Value="LV" Text="لاتفيا"></asp:ListItem>
                                    <asp:ListItem Value="LA" Text="لاوس"></asp:ListItem>
                                    <asp:ListItem Value="LB" Text="لبنان"></asp:ListItem>
                                    <asp:ListItem Value="LU" Text="لوكسمبورج"></asp:ListItem>
                                    <asp:ListItem Value="LY" Text="ليبيا"></asp:ListItem>
                                    <asp:ListItem Value="LR" Text="ليبيريا"></asp:ListItem>
                                    <asp:ListItem Value="LT" Text="ليتوانيا"></asp:ListItem>
                                    <asp:ListItem Value="LI" Text="ليختنشتاين"></asp:ListItem>
                                    <asp:ListItem Value="LS" Text="ليسوتو"></asp:ListItem>
                                    <asp:ListItem Value="MQ" Text="مارتينيك"></asp:ListItem>
                                    <asp:ListItem Value="MO" Text="ماكاو الصينية"></asp:ListItem>
                                    <asp:ListItem Value="MT" Text="مالطا"></asp:ListItem>
                                    <asp:ListItem Value="ML" Text="مالي"></asp:ListItem>
                                    <asp:ListItem Value="MY" Text="ماليزيا"></asp:ListItem>
                                    <asp:ListItem Value="YT" Text="مايوت"></asp:ListItem>
                                    <asp:ListItem Value="MG" Text="مدغشقر"></asp:ListItem>
                                    <asp:ListItem Value="EG" Text="مصر"></asp:ListItem>
                                    <asp:ListItem Value="MK" Text="مقدونيا"></asp:ListItem>
                                    <asp:ListItem Value="MW" Text="ملاوي"></asp:ListItem>
                                    <asp:ListItem Value="ZZ" Text="منطقة غير معرفة"></asp:ListItem>
                                    <asp:ListItem Value="MN" Text="منغوليا"></asp:ListItem>
                                    <asp:ListItem Value="MR" Text="موريتانيا"></asp:ListItem>
                                    <asp:ListItem Value="MU" Text="موريشيوس"></asp:ListItem>
                                    <asp:ListItem Value="MZ" Text="موزمبيق"></asp:ListItem>
                                    <asp:ListItem Value="MD" Text="مولدافيا"></asp:ListItem>
                                    <asp:ListItem Value="MC" Text="موناكو"></asp:ListItem>
                                    <asp:ListItem Value="MS" Text="مونتسرات"></asp:ListItem>
                                    <asp:ListItem Value="MM" Text="ميانمار"></asp:ListItem>
                                    <asp:ListItem Value="FM" Text="ميكرونيزيا"></asp:ListItem>
                                    <asp:ListItem Value="NA" Text="ناميبيا"></asp:ListItem>
                                    <asp:ListItem Value="NR" Text="نورو"></asp:ListItem>
                                    <asp:ListItem Value="NP" Text="نيبال"></asp:ListItem>
                                    <asp:ListItem Value="NG" Text="نيجيريا"></asp:ListItem>
                                    <asp:ListItem Value="NI" Text="نيكاراجوا"></asp:ListItem>
                                    <asp:ListItem Value="NZ" Text="نيوزيلاندا"></asp:ListItem>
                                    <asp:ListItem Value="NU" Text="نيوي"></asp:ListItem>
                                    <asp:ListItem Value="HT" Text="هايتي"></asp:ListItem>
                                    <asp:ListItem Value="HN" Text="هندوراس"></asp:ListItem>
                                    <asp:ListItem Value="NL" Text="هولندا"></asp:ListItem>
                                    <asp:ListItem Value="HK" Text="هونج كونج الصينية"></asp:ListItem>
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator runat="server" ID="rfvNat"
                                    ControlToValidate="ddlNat" ValidationGroup="ContactUs" InitialValue="-1"></asp:RequiredFieldValidator>


                            </div>
                                </div>
                        </div>

                        <div class="col-md-12">
                            <div class="row">
                            <div class="col-md-6 ">

                                <div class="titlec">المنطقة&nbsp;<span class="color-red">*</span></div>


                                <asp:DropDownList ID="ddlArea" runat="server" OnLoad="ddlarea_Load" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control">


                                    <asp:ListItem Selected="True" Text="" Value="-1"></asp:ListItem>
                                    <asp:ListItem Value="A" Text="محافظة العاصمة" Selected="false"></asp:ListItem>
                                    <asp:ListItem Value="A1" Selected="false" Text="الصوابر"></asp:ListItem>
                                    <asp:ListItem Value="A2" Selected="false" Text="المرقاب"></asp:ListItem>
                                    <asp:ListItem Value="A3" Selected="false" Text="القبلة"></asp:ListItem>
                                    <asp:ListItem Value="A4" Selected="false" Text="الصالحية"></asp:ListItem>
                                    <asp:ListItem Value="A5" Selected="false" Text="الوطية"></asp:ListItem>
                                    <asp:ListItem Value="A6" Selected="false" Text="بنيد القار"></asp:ListItem>
                                    <asp:ListItem Value="A7" Selected="false" Text="الدسمة"></asp:ListItem>
                                    <asp:ListItem Value="A8" Selected="false" Text="الدعية"></asp:ListItem>
                                    <asp:ListItem Value="A9" Selected="false" Text="المنصورية"></asp:ListItem>
                                    <asp:ListItem Value="A10" Selected="false" Text="ضاحية عبدالله السالم"></asp:ListItem>
                                    <asp:ListItem Value="A11" Selected="false" Text="النزهه"></asp:ListItem>
                                    <asp:ListItem Value="A12" Selected="false" Text="الفيحاء"></asp:ListItem>
                                    <asp:ListItem Value="A13" Selected="false" Text="الشامية"></asp:ListItem>
                                    <asp:ListItem Value="A14" Selected="false" Text="الروضة"></asp:ListItem>
                                    <asp:ListItem Value="A15" Selected="false" Text="العديلية"></asp:ListItem>
                                    <asp:ListItem Value="A16" Selected="false" Text="الخالدية"></asp:ListItem>
                                    <asp:ListItem Value="A17" Selected="false" Text="كيفان"></asp:ListItem>
                                    <asp:ListItem Value="A18" Selected="false" Text="القادسية"></asp:ListItem>
                                    <asp:ListItem Value="A19" Selected="false" Text="قرطبة"></asp:ListItem>
                                    <asp:ListItem Value="A20" Selected="false" Text="السرة"></asp:ListItem>
                                    <asp:ListItem Value="A21" Selected="false" Text="اليرموك"></asp:ListItem>
                                    <asp:ListItem Value="A22" Selected="false" Text="الشويخ"></asp:ListItem>
                                    <asp:ListItem Value="A23" Selected="false" Text="الري"></asp:ListItem>
                                    <asp:ListItem Value="A24" Selected="false" Text="غرناطة"></asp:ListItem>
                                    <asp:ListItem Value="A25" Selected="false" Text="الصليبيخات"></asp:ListItem>
                                    <asp:ListItem Value="A26" Selected="false" Text="الدوحة"></asp:ListItem>
                                    <asp:ListItem Value="A27" Selected="false" Text="النهضة"></asp:ListItem>
                                    <asp:ListItem Value="A28" Selected="false" Text="مدينة جابر الاحمد"></asp:ListItem>
                                    <asp:ListItem Value="A29" Selected="false" Text="دسمان"></asp:ListItem>
                                    <asp:ListItem Value="A30" Selected="false" Text="شرق"></asp:ListItem>
                                    <asp:ListItem Value="A31" Selected="false" Text="القيروان"></asp:ListItem>
                                    <asp:ListItem Value="A32" Selected="false" Text="شمال غرب صليبيخات"></asp:ListItem>

                                    <asp:ListItem Value="B" Text="محافظة الجهراء" Selected="false"></asp:ListItem>

                                    <%--  <asp:ListItem value="B1" Selected="false" Text="دسمان"></asp:ListItem>       
       <asp:ListItem value="B2" Selected="false" Text="شرق"></asp:ListItem>  --%>
                                    <%--<asp:ListItem value="B3" Selected="false" Text="المناطق"></asp:ListItem>     --%>
                                    <asp:ListItem Value="B4" Selected="false" Text="الواحة"></asp:ListItem>
                                    <asp:ListItem Value="B5" Selected="false" Text="العيون"></asp:ListItem>
                                    <asp:ListItem Value="B6" Selected="false" Text="القصر"></asp:ListItem>
                                    <asp:ListItem Value="B7" Selected="false" Text="الجهراء"></asp:ListItem>
                                    <asp:ListItem Value="B8" Selected="false" Text="النسيم"></asp:ListItem>
                                    <asp:ListItem Value="B9" Selected="false" Text="تيماء"></asp:ListItem>
                                    <asp:ListItem Value="B10" Selected="false" Text="النعيم"></asp:ListItem>

                                    <asp:ListItem Value="B11" Selected="false" Text="مدينة سعد العبد الله"></asp:ListItem>
                                    <asp:ListItem Value="B12" Selected="false" Text="الجهراء الصناعية"></asp:ListItem>
                                    <asp:ListItem Value="B13" Selected="false" Text="الصليبية"></asp:ListItem>
                                    <asp:ListItem Value="B14" Selected="false" Text="الصليبية الصناعية"></asp:ListItem>
                                    <asp:ListItem Value="B15" Selected="false" Text="الصليبية الزراعية"></asp:ListItem>
                                    <asp:ListItem Value="B16" Selected="false" Text="امغرا"></asp:ListItem>
                                    <asp:ListItem Value="B17" Selected="false" Text="مدينة الصبية"></asp:ListItem>
                                    <asp:ListItem Value="B18" Selected="false" Text="المطلاع"></asp:ListItem>
                                    <asp:ListItem Value="B19" Selected="false" Text="العبدلي "></asp:ListItem>


                                    <asp:ListItem Value="C" Text="محافظة حولي" Selected="false"></asp:ListItem>

                                    <asp:ListItem Value="C1" Selected="false" Text="حولي"></asp:ListItem>
                                    <asp:ListItem Value="C2" Selected="false" Text="الشعب"></asp:ListItem>
                                    <asp:ListItem Value="C3" Selected="false" Text="السالمية"></asp:ListItem>
                                    <asp:ListItem Value="C4" Selected="false" Text="الرميثية"></asp:ListItem>
                                    <asp:ListItem Value="C5" Selected="false" Text="الجابرية"></asp:ListItem>
                                    <asp:ListItem Value="C6" Selected="false" Text="مشرف"></asp:ListItem>
                                    <asp:ListItem Value="C7" Selected="false" Text="سلوى"></asp:ListItem>
                                    <asp:ListItem Value="C8" Selected="false" Text="بيان"></asp:ListItem>
                                    <asp:ListItem Value="C9" Selected="false" Text="حطين"></asp:ListItem>
                                    <asp:ListItem Value="C10" Selected="false" Text="السلام"></asp:ListItem>
                                    <asp:ListItem Value="C11" Selected="false" Text="الزهراء"></asp:ListItem>
                                    <asp:ListItem Value="C12" Selected="false" Text="الشهداء"></asp:ListItem>
                                    <asp:ListItem Value="C13" Selected="false" Text="مبارك عبدالله الجابر"></asp:ListItem>
                                    <asp:ListItem Value="C14" Selected="false" Text="الصديق"></asp:ListItem>

                                    <asp:ListItem Value="D" Text="محافظة الفروانية" Selected="false"></asp:ListItem>

                                    <asp:ListItem Value="D1" Selected="false" Text="ابرق خيطان"></asp:ListItem>
                                    <asp:ListItem Value="D2" Selected="false" Text="الاندلس"></asp:ListItem>
                                    <asp:ListItem Value="D3" Selected="false" Text="اشبيلية"></asp:ListItem>
                                    <asp:ListItem Value="D4" Selected="false" Text="خيطان "></asp:ListItem>
                                    <asp:ListItem Value="D5" Selected="false" Text="الفروانية"></asp:ListItem>
                                    <asp:ListItem Value="D6" Selected="false" Text="الفردوس"></asp:ListItem>
                                    <asp:ListItem Value="D7" Selected="false" Text="ضاحية صباح الناصر"></asp:ListItem>
                                    <asp:ListItem Value="D8" Selected="false" Text="العميرية"></asp:ListItem>
                                    <asp:ListItem Value="D9" Selected="false" Text="العارضية "></asp:ListItem>
                                    <asp:ListItem Value="D10" Selected="false" Text="العارضية الصناعية"></asp:ListItem>
                                    <asp:ListItem Value="D11" Selected="false" Text="الرقعي"></asp:ListItem>
                                    <asp:ListItem Value="D12" Selected="false" Text="الرابية"></asp:ListItem>
                                    <asp:ListItem Value="D13" Selected="false" Text="الرحاب"></asp:ListItem>
                                    <asp:ListItem Value="D14" Selected="false" Text="الري الصناعية"></asp:ListItem>
                                    <asp:ListItem Value="D15" Selected="false" Text="جليب الشيوخ"></asp:ListItem>
                                    <asp:ListItem Value="D16" Selected="false" Text="الضجيج"></asp:ListItem>
                                    <asp:ListItem Value="D17" Selected="false" Text="الشدادية"></asp:ListItem>
                                    <asp:ListItem Value="D18" Selected="false" Text="ضاحية عبدالله المبارك"></asp:ListItem>

                                    <asp:ListItem Value="E" Text="محافظة مبارك الكبير" Selected="false"></asp:ListItem>

                                    <asp:ListItem Value="E1" Selected="false" Text="ضاحية صباح السالم"></asp:ListItem>
                                    <asp:ListItem Value="E2" Selected="false" Text="ضاحية المسيلة"></asp:ListItem>
                                    <asp:ListItem Value="E3" Selected="false" Text="ضاحية العدان"></asp:ListItem>
                                    <asp:ListItem Value="E4" Selected="false" Text="ضاحية القصور"></asp:ListItem>
                                    <asp:ListItem Value="E5" Selected="false" Text="ضاحية القرين"></asp:ListItem>
                                    <asp:ListItem Value="E6" Selected="false" Text="ضاحية أبو فطيرة"></asp:ListItem>
                                    <asp:ListItem Value="E7" Selected="false" Text="منطقة صبحان"></asp:ListItem>
                                    <asp:ListItem Value="E8" Selected="false" Text=" الفنيطيس"></asp:ListItem>
                                    <%-- <asp:ListItem value="E9" Selected="false" Text="ضاحية الفنطاس"></asp:ListItem> --%>
                                    <asp:ListItem Value="E10" Selected="false" Text="ضاحية مبارك الكبير"></asp:ListItem>

                                    <asp:ListItem Value="F" Text="محافظة الاحمدي" Selected="false"></asp:ListItem>

                                    <asp:ListItem Value="F1" Selected="false" Text="الظهر"></asp:ListItem>
                                    <asp:ListItem Value="F2" Selected="false" Text="الرقة"></asp:ListItem>
                                    <asp:ListItem Value="F3" Selected="false" Text="هدية"></asp:ListItem>
                                    <asp:ListItem Value="F4" Selected="false" Text="المنقف"></asp:ListItem>
                                    <asp:ListItem Value="F5" Selected="false" Text="ابو حليفة"></asp:ListItem>
                                    <asp:ListItem Value="F6" Selected="false" Text="الفنطاس"></asp:ListItem>
                                    <%-- <asp:ListItem  value="F7" Selected="false" Text="الفنيطيس"></asp:ListItem>--%>
                                    <asp:ListItem Value="F8" Selected="false" Text="الصباحية"></asp:ListItem>
                                    <asp:ListItem Value="F9" Selected="false" Text="الأحمدي"></asp:ListItem>
                                    <asp:ListItem Value="F10" Selected="false" Text="الفحيحيل"></asp:ListItem>
                                    <asp:ListItem Value="F11" Selected="false" Text="ضاحية علي صباح السالم"></asp:ListItem>
                                    <asp:ListItem Value="F12" Selected="false" Text="ميناء عبدالله"></asp:ListItem>
                                    <asp:ListItem Value="F13" Selected="false" Text="الشعيبة"></asp:ListItem>
                                    <asp:ListItem Value="F14" Selected="false" Text="بنيدر"></asp:ListItem>
                                    <asp:ListItem Value="F15" Selected="false" Text="الزور"></asp:ListItem>
                                    <asp:ListItem Value="F16" Selected="false" Text="الخيران"></asp:ListItem>
                                    <asp:ListItem Value="F17" Selected="false" Text="الوفرة"></asp:ListItem>
                                    <asp:ListItem Value="F18" Selected="false" Text="ضاحية فهد الاحمد"></asp:ListItem>
                                    <asp:ListItem Value="F19" Selected="false" Text="ضاحية جابر العلي"></asp:ListItem>
                                    <asp:ListItem Value="F20" Selected="false" Text="مدينة صباح الاحمد "></asp:ListItem>
                                    <asp:ListItem Value="F21" Selected="false" Text="العقيلة"></asp:ListItem>

                                </asp:DropDownList>












                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="ddlarea" ValidationGroup="ContactUs" InitialValue="-1"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-md-6 ">
                                <div class="titlec">البريد الإلكتروني&nbsp;<span class="color-red">*</span></div>
                                <asp:TextBox ID="txtEmail" MaxLength="350" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9"
                                    ControlToValidate="txtEmail" ValidationGroup="ContactUs"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rvx_email" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="الرجاء اختيار بريد إلكتروني حقيقي" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="ContactUs"></asp:RegularExpressionValidator>
                            </div>
                            </div>
                        </div>

                        <div class="col-md-12">


                            <div class="col-md-12 PaddingButtom8PX">
                                <div class="titlec">اسم الدورة التدريبية&nbsp;<span class="color-red">*</span></div>
                                <%--<asp:DropDownList ID="drpHobbies" CssClass="form-control" runat="server" AutoPostBack="true"  >--%>

                                <asp:TextBox ID="txtHobbies" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:DropDownList ID="drpHobbies" CssClass="form-control" runat="server" AutoPostBack="true" Visible="false">
                                    <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Linux from Zero to Hero"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="IoT"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Coding Web"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Raspberry Pi"></asp:ListItem>
                                    
                                    <%--<asp:ListItem Selected="False" Text=" Internet of Things - IoT  Start date- 14/11/2021 End Date- 18/11/2021 " Value="1"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="Arduino Start date- 21/11/2021 End Date- 25/11/2021" Value="2"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="Web Design Start date- 28/11/2021 End Date- 2/12/2021" Value="3"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text=" Solar Energy Start date- 5/12/2021 End Date- 9/12/2021" Value="4"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="Raspberry piStart date- 5/12/2021 End Date- 9/12/2021" Value="5"></asp:ListItem>--%>


                                    <%--  <asp:ListItem Selected="False" Text="اساسيات الرسم الزيتي" Value="6" Enabled="false"></asp:ListItem>
                                      <asp:ListItem Selected="False" Text="الشخصية الأتكيتية" Value="7" Enabled="false"></asp:ListItem>
                                      <asp:ListItem Selected="False" Text="Adobe photoshop المستوى الاول " Value="8" Enabled="false"></asp:ListItem>
                                      <asp:ListItem Selected="False" Text="منتج فيديوك بسبع خطوات ببرنامج premiere " Value="9" Enabled="false"></asp:ListItem>
                                      <asp:ListItem Selected="False" Text="Swift برمج تطبيقك مع لغة " Value="10" Enabled="false"></asp:ListItem>
                                   <asp:ListItem Selected="False" Text="الذكاء الاجتماعي " Value="11" Enabled="false"></asp:ListItem>
                                   <asp:ListItem Selected="False" Text="تصميم الشعارات والهويات البصرية" Value="12" Enabled="false"></asp:ListItem>
                                   <asp:ListItem Selected="False" Text="الرسم على الحقائب والمنتجات الجلدية" Value="13"></asp:ListItem>
                                   <asp:ListItem Selected="False" Text="أساسيات التصوير الفوتوغرافي" Value="14" Enabled="false"></asp:ListItem>
                                   <asp:ListItem Selected="False" Text="تعلم الرسم الرقمي واساسيات ادوبي الستريتر" Value="15" Enabled="false"></asp:ListItem>--%>
                                    <%--<asp:ListItem Selected="False" Text="اساسيات الالكترونيات" Value="16" ></asp:ListItem>
                                   <asp:ListItem Selected="False" Text="اوبوتكس للمبتدئين" Value="17" ></asp:ListItem>
                                   <asp:ListItem Selected="False" Text="اردينو مبتدئين" Value="18" ></asp:ListItem>--%>
                                </asp:DropDownList>
                                <%-- <asp:LinkButton ID="lnkDownloadDetailas" runat="server" style='color:mediumblue;font-size: 16px;' OnClick="lnkDownloadDetailas_Click"  >&nbsp;<span class="color-red">*</span> (تفاصيل الدورات) للتحميل</asp:LinkButton> --%>

                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11"
                                    ControlToValidate="drpHobbies" ValidationGroup="ContactUs" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>

                        </div>

                        <div class="col-md-12 PaddingButtom8PX">


                            <div class="titlec">دورات مشروع وادي الشباب<span class="color-red">*</span></div>
                            <asp:TextBox ID="txtActivityType" MaxLength="50" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>




                        </div>

                        <p class="col-md-12 text-center" style="padding-top: 30px">
                            <asp:Button Font-Bold="true" Width="150px" ID="btnSend" runat="server" ValidationGroup="ContactUs" CssClass="btn-u btn-brd btn-brd-hover btn-u-dark" Text="تسجيل" OnClick="btnSend_Click" />
                        </p>
                        <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="message col-md-12">

                            <p>
                                <i class="rounded-x fa fa-check"></i>
                                <asp:Label ID="lblMessage" runat="server" Font-Size="20px" Text="" ForeColor="Red" EnableViewState="false"></asp:Label>
                            </p>
                        </asp:Panel>


                        <asp:ValidationSummary ID="ValidationSummary1"
                            runat="server"
                            HeaderText="الرجاء ادخال جميع الحقول المطلوبة"
                            ShowMessageBox="false"
                            DisplayMode="BulletList"
                            ShowSummary="true"
                            Width="450"
                            ForeColor="Red"
                            Font-Size="X-Large"
                            CssClass="message col-md-12"
                            Style="padding-right: 40px;"
                            Font-Italic="true" ValidationGroup="ContactUs" />


                        <asp:Button ID="btnBackToHome" runat="server" Text="Button" Style="display: none" OnClick="btnBackToHome_Click" />
                   <%-- </div>--%>
                         </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSend" />
                </Triggers>


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
        $(document).on('change', '.FileSize', function (event) {
            var fileUpload1 = $(this);
            var uploadType = $(this).parent().data('uploadtype');

            $('#ctl00_MainContent_hfUploadType').val(uploadType);
            var _URL = window.URL || window.webkitURL;
            var file;

            if ((file = this.files[0])) {

                if (this.files[0].size > 1048576) {
                    AlertMessage('انت تحاول رفع ملف  ' + (this.files[0].size / 1048576).toFixed(2) + 'MB. يجب ان يكون الحد الاقصى للحجم 1 ميغابايت ', 'يتجاوز حجم الملف ..', BootstrapDialog.TYPE_DANGER, null);
                    this.value = null;
                    return;
                }

            }

        });
    </script>
</asp:Content>

