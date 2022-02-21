<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     

<div id="main">
  <div class="page_banner"></div>
    <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span>تواصل معنا</div>
        </div>
    </div>


    <div id="content">
        <div class="container container-bg1">

            <div class="row">
            
                <div class="col-sm-6 right-bg">

                    <h3>تواصل معنا</h3>

         <hr />
                    <p style="font-size:16px;"> 
                       
                        الشويخ الصناعية - قطعة (١) - شارع (٢)    <i class="fa fa-home"></i> <br />
                         قسيمة (١٩-٣٣) - المبنى الإداري- الدور الأول  <br />
                       
                           <br/>
                       <%-- <a href="#">Mubaratna@youth.gov.kw</a>--%>

                        <a href="#">mla3ebna@youth.gov.kw</a>
                    </p>

                 <%--   <h4>الهاتف </h4>--%>

                   

                    <div class="social3_wrapper">
                        <ul class="social3 clearfix">
           <%--                 <li><a href="#"><i class="fa fa-facebook-square"></i></a></li>--%>
                            <li><a href="#" style="color:#969a96;"><i class="fa fa-twitter"></i></a></li>                            
                            <li><a href="#" style="color:#969a96;"><i class="fa fa-instagram"></i></a></li>                            
                        </ul>
                    </div>


                </div>
                <div class="col-sm-6 left-bg">

                    <h3>بيانات الإتصال </h3>
                    <hr />
                    <div id="note"></div>
                    <div id="fields">
                        <form id="ajax-contact-form" class="form-horizontal" >
                            <div class="form-group" style="margin: 10px" id="divmodalmsg" runat="server" visible="false"></div>
                            <div id="divspin1" style="display:none" class="spinner"></div>

                            <div class="form-group">
                                <label for="inputName">اسمك</label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" stye="direction:rtl;" placeholder="الإسم الكامل " ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="contact" runat="server" ControlToValidate="txtName" CssClass="text-danger" 
                                            SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label for="inputEmail">بريدك الالكتروني</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="البريد الإلكتروني " autocomplete="off" ></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="contact" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                ControlToValidate="txtEmail" CssClass="text-danger" Display="dynamic"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="contact"></asp:RegularExpressionValidator>
                            </div>


                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label for="inputMessage">المشكلة</label>
                                         <asp:TextBox ID="txtMessage" runat="server" Rows="7" placeholder ="الرسالة " TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="contact" runat="server" ControlToValidate="txtMessage" CssClass="text-danger" 
                                            SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                             <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="btn-default btn-cf-submit" Text="إرسال" OnClick="lnkSubmit_Click" ValidationGroup="contact"></asp:LinkButton>
                        </form>
                    </div>


                </div>

                
            </div>


        </div>
    </div>
 
</div>

</asp:Content>

