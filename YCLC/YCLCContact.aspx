<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="YCLCContact.aspx.cs" Inherits="YCLCContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

  <%--  <link href="../Content/CSS/ini-form/bootstrap.css" type="text/css" media="screen" />--%>

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

     
        <div class="container-fluid">
            <div class="container">

                 <div class="text-center mt-50">
            <h2>تواصل مع الدعم الفني</h2>
           
        </div>

        <hr />
                <div class=" bg-white">
                   
                        <div class="row" dir="rtl">
                            <div class="col-xs-12 col-md-12 text-right">
                               <%-- <div class="form-horizontal">--%>

                                    <div id="alert" class="notification msgalert" runat="server" visible="false">
                                        <a class="close"></a>
                                        لقد قمت بإدخال قيمة غير صالحة للتحقق
                                    </div>

                                   
                                    <div id="alert2" class="notification msgerror" runat="server" visible="false">
                                        <a class="close"></a>
                                        Already Existing Details(Name,Civil,Messesge)
                                    </div>

                                    <div id="alert3" class="notification msgerror" runat="server" visible="false">
                                        <a class="close"></a>
                                        Limit exceed(2 queries per day for 1 person ) 
                                    </div>
                                    
                                    <div id="success1" class="alert-success" runat="server" visible="false">
                                        <a class="close"></a>
                                        تم بنجاح ارسال الاستعلام الخاص بك<br />
                                    </div>
                                   
                              <%--  </div>

                              


                                <div class="col-lg-12 col-xs-12 form-bg1">--%>
                                     
                                    <div id="success" runat="server" visible="true">
                                        <h1 style="font-size: 1.521em; color: #6CACC5; margin-bottom: 15px; margin-top: 25px;">عزيزي المستخدم ، لقد تم ارسال المشكلة بنجاح ، سوف نحاول تقديم المساعدة في اقرب وقت ممكن .</h1>
                                    </div>

                                

                                    <div runat="server" id="pnlData" class="form-group">
                                      <%--  <h1 style="font-size: 1.521em; color: #6CACC5; margin-bottom: 15px; margin-top: 25px;">استمارة التواصل</h1>--%>
                                        <div class="form-group" style="height: auto;">
                                            <label>الاسم</label>

                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                                                AutoCompleteType="Disabled" ValidationGroup="inquiryAR"></asp:TextBox>

                                            <div class="clear"></div>

                                            <div class="req">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtName" Display="Dynamic"
                                                    ErrorMessage="مطلوب هذه الخانة" SetFocusOnError="true" CssClass="red"
                                                    ValidationGroup="inquiryAR"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group" style="height: auto;">

                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                <ContentTemplate>

                                                    <label>الرقــم المـدني</label>

                                                    <asp:TextBox ID="txtcivil" runat="server" CssClass="form-control"
                                                        AutoCompleteType="Disabled" ValidationGroup="inquiryAR" MaxLength="12" OnTextChanged="txtcivil_TextChanged" AutoPostBack="true"></asp:TextBox>

                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtcivil"
                                                            CssClass="red" Display="Dynamic"
                                                            ValidationGroup="inquiryAR" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator
                                                            EnableClientScript="true"
                                                            ID="RegularExpressionValidator1" runat="server"
                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                            ValidationGroup="inquiryAR"
                                                            ControlToValidate="txtcivil" Display="dynamic"
                                                            ValidationExpression="^[0-9]{12}$"
                                                            CssClass="red" SetFocusOnError="true" />
                                                        <asp:Label ID="lbl_civil" runat="server" Visible="false" SetFocusOnError="true" Text="الرقم المدني غير صحيح" />

                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </div>

                                        <div class="form-group" style="height: auto;">
                                            <label>البريد الإلكتروني (الإيميل)</label>

                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                                                AutoCompleteType="Disabled" ValidationGroup="inquiryAR"></asp:TextBox>

                                            <div class="clear"></div>
                                            <div class="req">

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                    ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true" CssClass="red"
                                                    ControlToValidate="txtEmail" Display="dynamic"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="inquiryAR"></asp:RegularExpressionValidator>


                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                                                    CssClass="red" Display="Dynamic"
                                                    ValidationGroup="inquiryAR" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                            </div>

                                        </div>

                                        <div class="form-group" style="height: auto;">
                                            <label>رقم الهاتف</label>

                                            <asp:TextBox ID="txtNumber" runat="server" MaxLength="8" CssClass="form-control"
                                                AutoCompleteType="Disabled"
                                                ValidationGroup="inquiryAR"></asp:TextBox>

                                            <div class="clear"></div>
                                            <div class="req">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtNumber"
                                                    CssClass="red" Display="Dynamic"
                                                    ValidationGroup="inquiryAR" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    EnableClientScript="true"
                                                    ID="RegularExpressionValidator2" runat="server"
                                                    ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                                    ValidationGroup="inquiryAR"
                                                    ControlToValidate="txtNumber" Display="dynamic"
                                                    ValidationExpression="^[0-9]{8}$"
                                                    CssClass="red" />
                                            </div>
                                        </div>                                  
                                                                               
                                        <div class="form-group" style="height: auto;">
                                           
                                            <label>لمزيد من التفاصيل او انسخ رابط الصفحة التي واجهتك بها خطأ تقني</label>

                                            <asp:TextBox ID="txtSuggestions" runat="server" Rows="10" Columns="1" CssClass="form-control"
                                                TextMode="MultiLine" AutoCompleteType="Disabled"
                                                ValidationGroup="inquiryAR"></asp:TextBox>



                                            <div class="clear"></div>
                                            <div class="req">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="txtSuggestions" Display="Dynamic" SetFocusOnError="true"
                                                    ErrorMessage="مطلوب هذه الخانة"
                                                    ValidationGroup="inquiryAR"></asp:RequiredFieldValidator>
                                                <div id="counter" class="nf" style="color: red">
                                                </div>
                                                <br />


                                            </div>
                                        </div>

                                        <div class="form-group" style="height: auto;">
                                            <label>الرجاء إدخال رمز التحقق هنا</label>

                                            <asp:TextBox ID="txtTuring" runat="server" AutoCompleteType="Disabled" CssClass="form-control"
                                                ValidationGroup="inquiryAR"></asp:TextBox>
                                            <div class="clear"></div>

                                            <div class="req">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    ControlToValidate="txtTuring" Display="Dynamic" SetFocusOnError="true"
                                                    ErrorMessage="مطلوب هذه الخانة" CssClass="red"
                                                    ValidationGroup="inquiryAR"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>

                                        <div class="form-group" style="text-align: left;">
                                            <asp:UpdatePanel ID="UP1" runat="server">
                                                <ContentTemplate>

                                                    <asp:Image ID="imgCaptcha" runat="server" />

                                                    <asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/assets/images/refresh.png" Width="21px" Height="16px" OnClick="btnRefresh_Click" />

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                       
                                        <div class="submit">
                                            <asp:Button ID="btn_submit" runat="server" Text="ارسل" CssClass="btn btn-info"
                                                ValidationGroup="inquiryAR" OnClick="Button1_Click" />

                                        </div>

                                    </div>


                                  </div>

                                
                            </div>
                        </div>
                    
                </div>
            </div>
        </div>
   

  

</asp:Content>




