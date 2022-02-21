<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Edit_Initiative.aspx.cs" Inherits="ViewInitiative_Edit_Initiative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">المبادر المحترف</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="تعديل"></asp:Label></span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="View_ViewInitiativeDetails.aspx?InitiativeID=<%=Request.QueryString["InitiativeID"] %>"><i class="os-icon os-icon-ui-49"></i><span>رجوع</span></a>
                        </div>
                        <h6 class="element-header">المبادر المحترف</h6>
                        <div class="element-box">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                         <label for="">
                                            مجالات المشروع  :
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="ddlCategory" InitialValue="0" ID="RequiredFieldValidator4" runat="server" ErrorMessage="(يرجى إدخال اسم المشروع)"></asp:RequiredFieldValidator></label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                                       
                                    </div>
                                    <div class="col-md-6">
                                    <label for="">مقدم الطلب : <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="ddlType" InitialValue="0" ID="RequiredFieldValidator5" runat="server" ErrorMessage="(يرجى إدخال اسم المشروع)"></asp:RequiredFieldValidator></label>
                                        
                                     <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            اسم المشروع
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtInitiativeName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(يرجى إدخال اسم المشروع)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtInitiativeName" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control" placeholder="اسم المشروع"></asp:TextBox>
                                        <asp:Label ID="labCat" Visible="false" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            نبذة عن المشروع
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtInitiativeDesc" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(يرجى إدخال نبذة عن المشروع)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtInitiativeDesc" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control" placeholder=" نبذة عن المشروع"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-12 ">
                                    <div class="form-group">
                                        <label for="">
                                            الأهداف
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtInitiativeObjectives" ID="RequiredFieldValidator3" runat="server" ErrorMessage="(يرجى إدخال الأهداف)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtInitiativeObjectives" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control" placeholder="الأهداف"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            الصحيفة الجنائية (حديثة ) :   
                                           
                                        </label>
                                          <input class="form-control" id="uFileCriminalAutorization" style="width: 95%" type="file" name="uFileCriminalAutorization"
                                            runat="server">
                                         <asp:Label ID="labFileCriminalAutorization" runat="server" Text=""></asp:Label>
                                         <asp:Label ID="labFileCriminalAutorization1" Visible="false" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            شهادة آخر مؤهل دراسي :   
                                           
                                        </label>
                                          <input class="form-control" id="uFileAcademicQualification" style="width: 95%" type="file" name="uFileAcademicQualification"
                                            runat="server">
                                        <asp:Label ID="labFileAcademicQualification" runat="server" Text=""></asp:Label>
                                         <asp:Label ID="labFileAcademicQualification1" Visible="false" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6" runat="server" id="PanFileAgriculture">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            ارفق صورة من الرخصة الزراعية :   
                                           
                                        </label>
                                          <input class="form-control" id="uFileAgriculture" style="width: 95%" type="file" name="uFileAgriculture"
                                            runat="server">
                                         <asp:Label ID="labFileAgriculture" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="labFileAgriculture1" runat="server" Visible="false" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                           


                            <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>

                                <asp:LinkButton ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-danger mr-1"><i class="fa fa-refresh" aria-hidden="true"></i>&nbsp;Cancel</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

