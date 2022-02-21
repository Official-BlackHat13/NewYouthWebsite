<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProfileUpdate.aspx.cs" Inherits="ProfileUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page_banner"></div>

    <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.html">الرئيسية</a><span>/</span>عن ملعبنا</div>
        </div>
    </div>

<div id="main">
       <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <div id="content">
        <div class="container">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-8">
                        <h3>تسجيل الدخول </h3>
                        <div id="fields">
                            <div id="ajax-contact-form3" class="form-horizontal">
                                <div class="login-box">
                                    
                                    
                                    <p>شروط تسجيل حساب جديد</p>
                                   
                                    <div class="spinner" id="divmodalspin" runat="server" visible="false"></div>

 <asp:UpdatePanel ID="update" runat="server">
                                        <ContentTemplate>
                                    <div class="form-group" style="margin: 10px;" id="divmodalmsg" runat="server" visible="false">
                                        
                                    </div>
                                <%--<asp:Label runat="server" ID="lblmodelmsg" Text="hi1" Visible="true" ></asp:Label>--%>

                                   
                                        
                                  
                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">المحافظة</label>
                                        <div class="col-sm-9">
                                            <asp:DropDownList runat="server" ID="ddlGov"  CssClass="form-control" style="width: 100%;direction: rtl;" AutoPostBack="true" OnSelectedIndexChanged="ddlGov_SelectedIndexChanged">

                                            </asp:DropDownList>
                                          
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="profileupdate" ControlToValidate="ddlGov" 
                                                    SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger" InitialValue="0" ></asp:RequiredFieldValidator>
                                        </div>
                                    </div>


                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">Area</label>
                                        <div class="col-sm-9">

                                               <asp:DropDownList runat="server" ID="ddlArea"  CssClass="form-control" style="width: 100%;direction: rtl;">

                                            </asp:DropDownList>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="profileupdate" ControlToValidate="ddlArea" 
                                                    SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger" InitialValue="0" ></asp:RequiredFieldValidator>

                                        </div>
                                    </div>


                                     <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">الجنس</label>
                                        <div class="col-sm-9">
                                            <select class="form-control" style="width: 100%;direction: rtl;" runat="server" id="cmbGender" data-placeholder="الجنس..">
                                                <option style="text-align:right;" value="0">Select </option>
                                                <option style="text-align:right;" value="ذكر">ذكر </option>
                                                <option style="text-align:right;" value="أنثى">أنثى </option>
                                            </select>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="profileupdate" ControlToValidate="cmbGender" 
                                                    SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger" InitialValue="0" ></asp:RequiredFieldValidator>

                                        </div>
                                    </div>

                                    <p>Refer Your Five Friends. Two of them are must be in your own area.</p>

                                    <div class="form-group row" style="height:0px;margin-bottom: 0px;">
                                         <div class="col-sm-4"></div>
                                         <div class="col-sm-6"  style="height:2px;margin-bottom: 10px;">
                                            <div class="form-group" style="color:red; font-size:x-small;" id="divmsgc1" runat="server"></div>
                                         </div>
                                    </div>

                                    <div class="form-group row" style="margin-bottom: 10px;">
                                        <label for="colFormLabelLg" class="col-sm-3">Civil ID (1)</label>
                                        <div class="col-sm-1">
                                            <%--<button id="btnpl1" type="button" class="btn btn-success btn-number " data-type="plus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Plus',1)">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </button>--%>
                                            <asp:LinkButton ID="lnkFirstPlus" ClientIDMode="Static" runat="server" CssClass="btn btn-success btn-number" OnClick="lnkFirstPlus_Click">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>

                                        </div>

                                        <div class="col-sm-5">
                                            <div class="form-group" style="display: none; color:red;font-size:xx-small;" id="div1"></div>
                                            <%--<input type="text" class="form-control" ng-model="reg.civilID1" id="txtcivil1"   maxlength="12" value="الرقم المدني" >--%>
                                             <asp:TextBox ID="txtFirstCivilID" ClientIDMode="Static" runat="server" CssClass="form-control"  placeholder="الرقم المدني"></asp:TextBox> 
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtFirstCivilID" 
                                                    SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger" ></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator
                                                            EnableClientScript="true"
                                                            ID="RegularExpressionValidator5" runat="server"
                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                            ValidationGroup="profileupdate"
                                                            ControlToValidate="txtFirstCivilID" Display="dynamic"
                                                            ValidationExpression="^[0-9]{12}$"
                                                            CssClass="text-danger" SetFocusOnError="true" ></asp:RegularExpressionValidator> 
                                        </div>
                                        <div class="col-sm-2">      
                                            <img src="images\cross.jpg" alt="Right" style="width:40px;height:40px;" id="c1err" runat="server" visible="false" />
                                            <img src="images\tick.jpg" alt="Right" style="width:40px;height:40px;" id="c1suc" runat="server" visible="false" />                                      
                                            <button type="button" data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success"  id="c1inv" runat="server" visible="false">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                        </div>

                                        
                                    </div>

                                    <div  id="divciv2" runat="server" visible="false">
                                        <div class="form-group row" style="height:0px;margin-bottom: 0px;">
                                             <div class="col-sm-4"></div>
                                             <div class="col-sm-6"  style="height:2px;margin-bottom: 10px;">
                                                <div class="form-group" style="color:red; font-size:x-small;" id="divmsgc2" runat="server" visible="false"></div>
                                             </div>
                                        </div>
                                       
                                        <div class="form-group row" style="margin-bottom: 10px;">
                                            <label for="colFormLabelLg" class="col-sm-3">Civil ID (2)</label>

                                            <div class="col-sm-1">
                                              <%--  <button type="button" id="btnpl2" class="btn btn-success btn-number " data-type="plus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Plus',2)">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </button>--%>

                                                <asp:LinkButton ID="lnkSecondPlus" ClientIDMode="Static" runat="server" CssClass="btn btn-success btn-number" OnClick="lnkSecondPlus_Click">
                                                   <span class="glyphicon glyphicon-plus"></span>
                                                </asp:LinkButton>
                                            </div>

                                            <div class="col-sm-5">                                            
                                                
                                             <asp:TextBox id="txtSecondCivilID" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="12" autocomplete="false" placeholder="الرقم المدني" ></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtSecondCivilID" 
                                                    SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger" ></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator
                                                            EnableClientScript="true"
                                                            ID="RegularExpressionValidator4" runat="server"
                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                            ValidationGroup="profileupdate"
                                                            ControlToValidate="txtSecondCivilID" Display="dynamic"
                                                            ValidationExpression="^[0-9]{12}$"
                                                            CssClass="text-danger" SetFocusOnError="true" ></asp:RegularExpressionValidator> 
                                             </div>
                                            <div class="col-sm-1">
                                               <%-- <button type="button" class="btn btn-danger btn-number " data-type="minus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Minus',2)">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </button>--%>

                                                <asp:LinkButton ID="lnkSecondMinus" runat="server" ClientIDMode="Static" CssClass="btn btn-danger btn-number" OnClick="lnkSecondMinus_Click">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </asp:LinkButton>
                                            </div>
                                            <div class="col-sm-2">    
                                                <img src="images\cross.jpg" alt="Right" style="width:40px;height:40px;" id="c2err" runat="server" visible="false" />
                                                <img src="images\tick.jpg" alt="Right" style="width:40px;height:40px;" id="c2suc" runat="server" visible="false" />                                      
                                                <button type="button"  data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success" runat="server" visible="false" id="c2inv">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                            </div>
                                        </div>
                                    </div>


                                    <div  id="divciv3" runat="server" visible="false">
                                         <div class="form-group row" style="height:0px;margin-bottom: 0px;">
                                             <div class="col-sm-4"></div>
                                             <div class="col-sm-6"  style="height:2px;margin-bottom: 10px;">
                                                <div class="form-group" style="color:red; font-size:x-small;" id="divmsgc3" runat="server" visible="false"></div>
                                             </div>
                                        </div>

                                        <div class="form-group row" style="margin-bottom: 10px;" id="">
                                            <label for="colFormLabelLg" class="col-sm-3">Civil ID (3)</label>
                                            <div class="col-sm-1">
                                               <%-- <button type="button" id="btnpl3"  class="btn btn-success btn-number " data-type="plus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Plus',3)">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </button>--%>
                                                <asp:LinkButton ID="lnkThirdPlus" runat="server" ClientIDMode="Static" CssClass="btn btn-success btn-number" OnClick="lnkThirdPlus_Click">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>

                                            </div>
                                            <div class="col-sm-5">
                                                <%--<input type="text" class="form-control" ng-model="reg.civilID3" id="txtcivil3"  maxlength="12" value="الرقم المدني" >--%>
                                             <asp:TextBox ID="txtThirdCivilID" ClientIDMode="Static" runat="server" CssClass="form-control"  placeholder="الرقم المدني"></asp:TextBox> 
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtThirdCivilID" 
                                                    SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger" ></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator
                                                            EnableClientScript="true"
                                                            ID="RegularExpressionValidator3" runat="server"
                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                            ValidationGroup="profileupdate"
                                                            ControlToValidate="txtThirdCivilID" Display="dynamic"
                                                            ValidationExpression="^[0-9]{12}$"
                                                            CssClass="text-danger" SetFocusOnError="true" ></asp:RegularExpressionValidator> 
                                            </div>
                                            <div class="col-sm-1">
                                               <%-- <button type="button" class="btn btn-danger btn-number " data-type="minus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Minus',3)">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </button>--%>
                                                 <asp:LinkButton ID="lnkThirdMinus" runat="server" ClientIDMode="Static" CssClass="btn btn-danger btn-number" OnClick="lnkThirdMinus_Click">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </asp:LinkButton>

                                            </div>
                                            <div class="col-sm-2">                                            
                                                <img src="images\cross.jpg" alt="Right" style="width:40px;height:40px;" id="c3err" runat="server" visible="false" />
                                                <img src="images\tick.jpg" alt="Right" style="width:40px;height:40px;" id="c3suc" runat="server" visible="false" />                                     
                                                <button type="button"  data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success" runat="server" visible="false"  id="c3inv">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                            </div>
                                        </div>
                                    </div>


                                    <div  id="divciv4" runat="server" visible="false">
                                        <div class="form-group row" style="height:0px;margin-bottom: 0px;">
                                             <div class="col-sm-4"></div>
                                             <div class="col-sm-6"  style="height:2px;margin-bottom: 10px;">
                                                <div class="form-group" style="color:red; font-size:x-small;" id="divmsgc4" runat="server" visible="false"></div>
                                             </div>
                                        </div>

                                        <div class="form-group row" style="margin-bottom: 10px;" id="Div2">
                                            <label for="colFormLabelLg" class="col-sm-3">Civil ID (4)</label>
                                            <div class="col-sm-1">
                                               <%-- <button type="button" id="btnpl4" class="btn btn-success btn-number " data-type="plus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Plus',4)">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </button>--%>
                                                 <asp:LinkButton ID="lnkFourthPlus" runat="server" ClientIDMode="Static" CssClass="btn btn-success btn-number" OnClick="lnkFourthPlus_Click">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>
                                            </div>
                                            <div class="col-sm-5">
                                                <%--<input type="text" class="form-control" ng-model="reg.civilID4" id="txtcivil4"   maxlength="12" value="الرقم المدني"  >--%>
                                             <asp:TextBox ID="txtFourthCivilID" ClientIDMode="Static" runat="server" CssClass="form-control"  placeholder="الرقم المدني"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtFourthCivilID" 
                                                    SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger" ></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator
                                                            EnableClientScript="true"
                                                            ID="RegularExpressionValidator2" runat="server"
                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                            ValidationGroup="profileupdate"
                                                            ControlToValidate="txtFourthCivilID" Display="dynamic"
                                                            ValidationExpression="^[0-9]{12}$"
                                                            CssClass="text-danger" SetFocusOnError="true" ></asp:RegularExpressionValidator> 
                                            </div>
                                            <div class="col-sm-1">
                                             <%--   <button type="button" class="btn btn-danger btn-number " data-type="minus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Minus',4)">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </button>--%>

                                                 <asp:LinkButton ID="lnkFourthMinus" runat="server" ClientIDMode="Static" CssClass="btn btn-danger btn-number" OnClick="lnkFourthMinus_Click">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </asp:LinkButton>
                                            </div>
                                            <div class="col-sm-2">                                            
                                                <img src="images\cross.jpg" alt="Right" style="width:40px;height:40px;" id="c4err" runat="server" visible="false" />
                                                <img src="images\tick.jpg" alt="Right" style="width:40px;height:40px;" id="c4suc" runat="server" visible="false" />                                      
                                                <button type="button"  data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success" runat="server" visible="false" id="c4inv">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                            </div>
                                        </div>
                                    </div>

                                     <div  id="divciv5" runat="server" visible="false">
                                        <div class="form-group row" style="height:0px;margin-bottom: 0px;">
                                             <div class="col-sm-4"></div>
                                             <div class="col-sm-6"  style="height:2px;margin-bottom: 10px;">
                                                <div class="form-group" style="color:red; font-size:x-small;" id="divmsgc5" runat="server" visible="false"></div>
                                             </div>
                                        </div>

                                        <div class="form-group row"style="margin-bottom: 10px;" id="Div3">

                                            <label for="colFormLabelLg" class="col-sm-3">Civil ID (5)</label>
                                            <div class="col-sm-1">
                                               <!-- <button type="button" class="btn btn-success btn-number " data-type="plus" data-field="quant[2]">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </button>-->
                                                <%-- <asp:LinkButton ID="lnkFifthPlus" runat="server" CssClass="btn btn-success btn-number">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>--%>
                                            </div>
                                            <div class="col-sm-5">
                                                <%--<input type="text" class="form-control" ng-model="reg.civilID5" id="txtcivil5" maxlength="12" value="الرقم المدني" >--%>
                                             <asp:TextBox ID="txtFifthCivilID" ClientIDMode="Static" runat="server" CssClass="form-control"  placeholder="الرقم المدني"></asp:TextBox> 
                                                <asp:RequiredFieldValidator ID="rer5" runat="server" ValidationGroup="profileupdate" ControlToValidate="txtFifthCivilID" 
                                                    SetFocusOnError="true" ErrorMessage="Required" CssClass="text-danger" ></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator
                                                            EnableClientScript="true"
                                                            ID="RegularExpressionValidator1" runat="server"
                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                            ValidationGroup="profileupdate"
                                                            ControlToValidate="txtFifthCivilID" Display="dynamic"
                                                            ValidationExpression="^[0-9]{12}$"
                                                            CssClass="text-danger" SetFocusOnError="true" ></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-1">
                                               <%-- <button type="button" class="btn btn-danger btn-number " data-type="minus" data-field="quant[2]" ng-click="DivVisibleOnBtnClick('Minus',5)">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </button>--%>
                                                 <asp:LinkButton ID="lnlFifthMinus" runat="server" ClientIDMode="Static" CssClass="btn btn-danger btn-number" OnClick="lnlFifthMinus_Click">
                                                    <span class="glyphicon glyphicon-minus"></span>
                                                </asp:LinkButton>
                                            </div>
                                            <div class="col-sm-2">                                            
                                                <img src="images\cross.jpg" alt="Right" style="width:40px;height:40px;" id="c5err" runat="server" visible="false" />
                                                <img src="images\tick.jpg" alt="Right" style="width:40px;height:40px;" id="c5suc" runat="server" visible="false" />                                      
                                                <button type="button"  data-toggle="modal" data-target="#modalEmail" data-book-id="{{paramValue}}" class="btn btn-success" runat="server" visible="false" id="c5inv">invite <i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                            </div>
                                        </div>
                                    </div>
                                    
                                     
                                    <%--<button type="submit" class="btn-default btn-cf-submit" ng-click="btnSubmit('Update');">Update Your Profile</button>--%>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" ClientIDMode="Static" ValidationGroup="profileupdate" CssClass="btn-default btn-cf-submit" Text="Update Your Profile" OnClick="lnkUpdate_Click"></asp:LinkButton>
                               </ContentTemplate>
                                    </asp:UpdatePanel>

                                             </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-2"></div>
                </div>
            </div>
        </div>
    </div>



</div>


     <!-- Modal -->
<div class="modal fade" id="modalEmail" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">اختيار التاريخ </h5>
         
      </div>
        <div style="display: none;" class="spinner" id="divmodalspinmodal" runat="server"></div>
        <asp:UpdatePanel ID="up" runat="server"><ContentTemplate>
        <div class="form-group"  style="margin: 10px" id="divmodalmsgmodal" runat="server" visible="false"></div>
            </ContentTemplate></asp:UpdatePanel>
      <div class="modal-body" style="direction:ltr;" >
            <div class="col-md-12">
                <div class="col-md-6"><label for="colFormLabelLg" class="col-sm-12">Your Friend Email</label></div>
                    
                    <div class="col-md-6" id="dividmodal">                    
                    <%--<input type="text" name="txtemail" ng-model="friendemail" value=""/>--%>
                        <asp:TextBox ID="txtfriendEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="req" runat="server" ValidationGroup="email" SetFocusOnError="true"  Display="Dynamic" 
                            ControlToValidate="txtfriendEmail" CssClass="text-danger" ErrorMessage="required"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                ControlToValidate="txtfriendEmail" CssClass="text-danger" Display="dynamic"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="personalInfo"></asp:RegularExpressionValidator>    
                   <%-- <input type="text" style="display:none;" name="bookId" value=""/>--%>
                </div>
            </div>
      </div>

        <br />
      <div class="modal-footer">
        <%--<button type="button" class="btn btn-success" ng-click="SendEmail();">Send Email<i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>--%>
          <asp:UpdatePanel ID="sendmail" runat="server">
              <ContentTemplate>
                   <asp:LinkButton ID="lnkSendmail" runat="server" CssClass="btn btn-success" ValidationGroup="email" OnClientClick="showspin();" ClientIDMode="Static" OnClick="lnkSendmail_Click">Send Email<i class="fa fa-paper-plane-o" aria-hidden="true"></i></asp:LinkButton>
              </ContentTemplate>
             <%-- <Triggers>
                  <asp:PostBackTrigger ControlID="lnkSendmail" />
              </Triggers>--%>
          </asp:UpdatePanel>
         
        <button type="button" class="btn btn-secondary" data-dismiss="modal">إغلاق </button>
         
       <!-- <button type="button" class="btn btn-primary">Save changes</button>-->
      </div>
    </div>
  </div>
</div>

  <script>

      function validate(evt) {
          var theEvent = evt || window.event;
          var key = theEvent.keyCode || theEvent.which;
          key = String.fromCharCode(key);
          var regex = /[0-9]|\./;
          if (!regex.test(key)) {
              theEvent.returnValue = false;
              if (theEvent.preventDefault) theEvent.preventDefault();
          }
      }
      function validatecivilno(evt) {
          var theEvent = evt || window.event;
          var key = theEvent.keyCode || theEvent.which;
          key = String.fromCharCode(key);
          var regex = /[0-9]|\./;
          if (!regex.test(key)) {
              theEvent.returnValue = false;
              if (theEvent.preventDefault) theEvent.preventDefault();
          }

      }
      $("#txtcivil").on('keypress', function () {
          if ($(this).val().length > 11) {
              alert("Civil Id No must be 12 letters long.");
              return false;
          }
      });

      function isValidEmail(emailAddress) {
          var userinput = $('#Email').val();
          var pattern = /^\b[A-Z0-9._%-]+@@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i

          if (!pattern.test(userinput))
              alert('not a valid e-mail address');
          return false;
      };

      $('#modalEmail').on('show.bs.modal', function (e) {
          var bookId = $(e.relatedTarget).data('book-id');
          $(e.currentTarget).find('input[name="bookId"]').val(bookId);
      });

    </script>
    
<script type="text/javascript">
    $("#lnkSendmail").click(function () {
        alert("inside");
       // $("#divmodalmsgmodal").style.display = "block";
    });
    function showspin() {
        document.getElementById("divmodalspinmodal").style.display = "block";     
       
    }
</script>  

   


</asp:Content>

