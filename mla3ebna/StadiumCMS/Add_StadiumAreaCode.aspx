<%@ Page Title="" Language="C#" MasterPageFile="~/mla3ebna/StadiumCMS/StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Add_StadiumAreaCode.aspx.cs" Inherits="mla3ebna_StadiumCMS_Add_StadiumAreaCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
        .bottom-right {
            position: absolute;
            bottom: 8px;
            right: 16px;
        }
         .element-wrapper input, select {
             width: 100%;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>

        <li class="breadcrumb-item">
            <span>الملعب</span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="col-md-8">
                    <div class="element-wrapper">
                        <%--<div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Create_Stadium.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp;Add_StadiumAreaCode</span></a>
                        </div>--%>
                    
                        <div class="element-box-tp">


                            <asp:UpdatePanel ID="updatesearch" runat="server">
                                <ContentTemplate>

                                
                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="form-group">
                                     
                                                     <label class="fieldlabels" for="DDLGov">Governorate <span style="color:red;">*</span> </label>
                                                <asp:DropDownList ID="DDLGov" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DDLGov_SelectedIndexChanged">
                                                </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ValidationGroup="report1" InitialValue="0" ControlToValidate="DDLGov" Display="Dynamic" ErrorMessage="field is required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                      </div>
                                    </div>
                                </div>
                                 <div class="row ">
                                <div class="col-md-12">
                                    <div class="form-group">
                                      
                                                       <label class="fieldlabels" for="DDLArea">Area <span style="color:red;">*</span> </label>
                                                    <asp:DropDownList ID="DDLArea" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DDLArea_SelectedIndexChanged">
                                                         </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ValidationGroup="report1" InitialValue="0" ControlToValidate="DDLArea" Display="Dynamic" ErrorMessage="field is required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                                     </div>
                                                     </div>
                                                      <div class="row ">
                                                        <div class="col-md-12">
                                              <div class="form-group">
                                                       <label class="fieldlabels" for="DDLStadium">Stadium <span style="color:red;">*</span> </label>
                                                  <asp:DropDownList ID="DDLStadium" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="DDLStadium_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true" ValidationGroup="report1" InitialValue="0" ControlToValidate="DDLStadium" Display="Dynamic" ErrorMessage="field is required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                     </div>
                                                     </div>
                                                    </div>

                                                  <%-- <div class="row ">
                                                  <div class="col-md-12">
                                              <div class="form-group">
                                               <label class="fieldlabels" for="txtjamiya">Jamiya <span style="color:red;">*</span> </label>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ValidationGroup="report1" ControlToValidate="txtjamiya" Display="Dynamic" ErrorMessage="field is required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtjamiya" runat="server" class="form-control"></asp:TextBox>
                                                       </div>
                                                     </div>
                                                   </div>
                                                      <div class="row ">
                                               <div class="col-md-12">
                                              <div class="form-group">
                                               
                                        
                                               <label class="fieldlabels" for="txtIBANno">IBAN_NO <span style="color:red;">*</span> </label>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ValidationGroup="report1" ControlToValidate="txtIBANno" Display="Dynamic" ErrorMessage="field is required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtIBANno" runat="server"  class="form-control"></asp:TextBox>
                                                    </div>
                                                     </div>
                                                       </div>--%>

                                                    <div class="row ">
                                               <div class="col-md-12">
                                              <div class="form-group">
                                               
                                               <label class="fieldlabels" for="txtAreacode">AreaCode <span style="color:red;">*</span> </label>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" ValidationGroup="report1" ControlToValidate="txtAreacode" Display="Dynamic" ErrorMessage="field is required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtAreacode" runat="server" class="form-control"></asp:TextBox>
                                                       </div>
                                                     </div>
                                                        </div>
                                                         <div class="row ">
                                          <div class="col-md-12">
                                              <div class="form-group">
                                         <label class="fieldlabels" for="txtStadiumcode">StadiumCode <span style="color:red;">*</span> </label>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true" ValidationGroup="report1" ControlToValidate="txtStadiumcode" Display="Dynamic" ErrorMessage="field is required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtStadiumcode" runat="server" class="form-control"></asp:TextBox>
                                          
                                                     </div>
                                     </div>
                                                       </div>
                                     <div class="row ">
                                 <div class="col-md-3">
                                              <div class="form-group">
                                       <asp:Button ID="btnsubmit" ClientIDMode="Static" runat="server" Text="submit"  ValidationGroup="report1" class="btn next btn-success btn-sm action-button itemValidation" OnClick="btnsubmit_Click" />

                                                  </div>
                                     </div>
                                         </div>
                                                </fieldset>
                                        

                         </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                        </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

