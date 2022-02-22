<%@ Page Title="" Language="C#" MasterPageFile="~/En_SiteMaster.master" AutoEventWireup="true" CodeFile="Register_AR.aspx.cs" Inherits="User_Register_AR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .form-horizontal .control-label { text-align:left; direction:ltr;
        }
        .onlineTraining_inner h1 { margin:0 0 10px 0;
                                   text-align:left;
        }
        .radio label, .checkbox label { padding-left:0px;
        }
        input[type="text"], input[type="email"], textarea, input[type="password"], input[type="file"] { text-align:left;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContainerAR" runat="Server">
  <div class="breadcrumb breadcrumb__t">
    <div class="cap">User Register</div>
  </div>
  <div id="ContainerAR">
    <div class="cont col-lg-12">
      <div class="onlineTraining_inner">
        <div class="col-lg-10 col-xs-12">
          <h1>في حال الرغبة بالتسجيل كجهة يرجى التسجيل بإسم الشخص المفوض</h1>
            <hr />
          <div class="form-horizontal">
            <div id="alertEmail" class="alert alert-warning" runat="server" visible="false">Email ID already Exist</div>
            <div id="alertCivil" class="alert alert-warning" runat="server" visible="false"> Civil ID already Exist</div>
            <div class="form-group">
              <label class="control-label col-sm-2 pull-left">Name: </label>
             
                                <div class="col-sm-10">
                                      <div class="col-sm-3 col-xs-12 pull-right">
                                        <asp:TextBox ID="txtLname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأخير"></asp:TextBox>

                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtLname"
                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                          <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator7" ControlToValidate="txtLname" CssClass="red"
                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                        ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                    </div>
                                      <div class="col-sm-3 col-xs-12 pull-right">
                                        <asp:TextBox ID="txtTname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثالث"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtTname"
                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                           <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtTname" CssClass="red"
                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                        ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>


                                    </div>
                                      <div class="col-sm-2 col-xs-12 pull-right">
                                        <asp:TextBox ID="txtMname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثاني"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtMname"
                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                          <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtMname" CssClass="red"
                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                        ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                    </div>
                                  
                                    <div class="col-sm-3 col-xs-12 pull-right">
                                        <asp:TextBox ID="txtName" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأول"></asp:TextBox>

                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtName"
                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                           <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator27" ControlToValidate="txtName" CssClass="red"
                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                        ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>

                                    </div>
                                  
                                

                                    <div class="clearfix"></div>
                                </div>
                        
              <div class="clear"></div>
              <div class="req">
                <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" Display="Dynamic"
                                                    ErrorMessage="Name field is required." ControlToValidate="txtName"
                                                    CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
              </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
              <ContentTemplate>
                <div class="form-group">
                  <label class="control-label col-sm-3 pull-left">Civil Id : </label>
                      <div class="col-sm-9">
                  <asp:TextBox ID="txtCivil" runat="server" MaxLength="12" ValidationGroup="personalInfo" OnTextChanged="txtCivil_TextChanged" AutoPostBack="true" CssClass="form-control"> </asp:TextBox>
                          </div>
                  <div class="req">
                    <asp:RequiredFieldValidator ID="rqdCivil" runat="server"
                                                    ErrorMessage="Civil ID field is required." ControlToValidate="txtCivil"
                                                    CssClass="red" Display="Dynamic"
                                                    ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                                                    EnableClientScript="true"
                                                    ID="RegularExpressionValidator1" runat="server"
                                                    ErrorMessage="Civil ID must be only 12 digits!"
                                                    ValidationGroup="personalInfo"
                                                    ControlToValidate="txtCivil" Display="dynamic"
                                                    ValidationExpression="^[0-9]{12}$"
                                                    CssClass="red" />
                    <asp:Label ID="lblCivil" runat="server" Visible="false" SetFocusOnError="true" Text="Civil ID is not Correct" />
                  </div>
                </div>
                <div class="form-group" runat="server" visible="false">
                  <label class="control-label col-sm-3 pull-left">Date of Birth:</label>
                    <div class="col-sm-7">
                  <asp:TextBox ID="datepicker" runat="server" ValidationGroup="personalInfo" AutoCompleteType="Disabled" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div></div>
              </ContentTemplate>
            </asp:UpdatePanel>
              
                        <div class="form-group">
                            <label class="control-label col-sm-3 pull-left">Copy of Civil ID: </label>
                            <div class="col-sm-3"></div>
                            <div class="col-sm-9 col-xs-12">
                                <asp:FileUpload ID="fbCiviID" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fbCiviID);" />
                            </div>
                            <div class="clear"></div>
                            <div class="req">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-6">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fbCiviID"
                                        CssClass="red" ErrorMessage="Field is required " Display="Dynamic" SetFocusOnError="true"
                                        ValidationGroup="personalInfo">
                                    </asp:RequiredFieldValidator>
                                    <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                    ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                    ValidationExpression="^.*\.(pdf|PDF)$"
                                    ControlToValidate="fbCiviID" Display="Dynamic" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="red"
                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                        ControlToValidate="fbCiviID" Display="Dynamic" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>
            <div class="form-group">
              <label class="control-label col-sm-3 pull-left">Email:</label>
                <div class="col-sm-9">
              <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                                                    ValidationGroup="personalInfo " ReadOnly="False"></asp:TextBox>
                    </div>
              <div class="clear"></div>
              <div class="req">
                <asp:RequiredFieldValidator ID="rqdEmail" runat="server"
                                                    ErrorMessage="Email ID field is required" ControlToValidate="txtEmail"
                                                    CssClass="red"
                                                    ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                    ErrorMessage="Enter valid E-mail ID"
                                                    ControlToValidate="txtEmail" CssClass="red" Display="dynamic"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
              </div>
            </div>
            <div class="form-group">
              <label class="control-label col-sm-3 pull-left">Telephone: </label>
                <div class="col-sm-9">
              <asp:TextBox ID="txtContactNo" MaxLength="8" runat="server" CssClass="form-control"
                                                    ValidationGroup="personalInfo"></asp:TextBox>
                    </div>
              <div class="clear"></div>
              <div class="req">
                <asp:RequiredFieldValidator ID="rqdContactnumber" runat="server" Display="Dynamic"
                                                    ErrorMessage="Phone no. field is required" ControlToValidate="txtContactNo"
                                                    CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                                                    EnableClientScript="true"
                                                    ID="rqdPersonalInfo" runat="server"
                                                    ErrorMessage="Phone no. should be 8 digits!"
                                                    ValidationGroup="personalInfo"
                                                    ControlToValidate="txtContactNo" Display="dynamic"
                                                    ValidationExpression="^[0-9]{8}$"
                                                    CssClass="red" />
              </div>
              <%--<div class="clear"></div>
              <div class="req">
                <asp:RequiredFieldValidator ID="datepickerValidator1" runat="server" ErrorMessage="Date of Birth is required."
                                                    ControlToValidate="datepicker" CssClass="red" ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                    ErrorMessage="Please insert date in correct format." ValidationGroup="personalInfo"
                                                    ControlToValidate="datepicker"
                                                    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" />
              </div>--%>
            </div>
            <div class="form-group">
              <label class="control-label col-sm-3 pull-left">Gender:</label>
              
            <div class="col-sm-4 radio radio-info">
                      <asp:RadioButtonList runat="server" ID="gender" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Text="Female" Value="أنثى"></asp:ListItem>
                          <asp:ListItem Text="Male" Value="ذكر"></asp:ListItem>
                        
                      </asp:RadioButtonList>
                    </div>
                 
              <div class="clear"></div>
              <div class="req">
                <asp:RequiredFieldValidator ID="rqdGender" runat="server" ErrorMessage="Gender field is required"
                                                    ControlToValidate="gender" CssClass="red" Display="Dynamic"
                                                    ValidationGroup="personalInfo" ></asp:RequiredFieldValidator>
              </div>
            </div>
            <div class="form-group">
              <label class="control-label col-sm-3 pull-left">Password:</label>
                <div class="col-sm-9">
              <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"
                                                    ValidationGroup="personalInfo" 
                                                    AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox></div>
              <div class="clear"></div>
              <div class="req">
                <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server" Display="Dynamic"
                                                    ErrorMessage="Password field is required" ControlToValidate="txtPassword" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regular" runat="server"
                                                    ControlToValidate="txtPassword" ErrorMessage="Password must be atleast 6 characters long" Display="Dynamic"
                                                    ValidationExpression="^.{6,}$" CssClass="red nf" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
              </div>
            </div>
            <div class="form-group">
              <label class="control-label col-sm-3 pull-left">Confirm Password:</label>
                <div class="col-sm-9">
              <asp:TextBox ID="txtConfirmPwd" runat="server" CssClass="form-control"
                                                    ValidationGroup="personalInfo" TextMode="Password"></asp:TextBox></div>
              <div class="clear"></div>
              <div class="req">
                <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" Display="Dynamic"
                                                    ErrorMessage="Password field is required" ControlToValidate="txtConfirmPwd" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic"
                                                    ControlToCompare="txtPassword"
                                                    ControlToValidate="txtConfirmPwd"
                                                    ErrorMessage="Password does not match." CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>
              </div>
            </div>
              <hr />
            <div class="form-group" style="text-align:center;">
              <asp:Button ID="btnSubmit" runat="server" class="btn btn-info" Text="Submit" ValidationGroup="personalInfo" OnClick="btnSubmit_Click" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
