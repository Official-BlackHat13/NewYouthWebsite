<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="Mubaratna2021_Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div id="main">
  <div class="page_banner"></div>
    <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span> الدعم الفني والمساعدة</div>
        </div>
    </div>


    <div id="content">
        <div class="container">

            <div class="row" >
     
                    <div class="col-lg-2"></div>
                <div class="col-lg-8">
                    <div class="form-group" style="margin: 10px" id="divmodalmsg" runat="server" visible="false">
                                 </div>
                    <div class="bg-gray1">

                    <h3>الدعم الفني والمساعدة </h3>
                    <hr />

                    <div id="note"></div>
                    <div id="fields">
                        <div id="ajax-contact-form" class="form-horizontal" >
                            
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
                        </div>
                    </div>

                    </div>
                </div>

            
            </div>


        </div>
    </div>
 
</div>





</asp:Content>

