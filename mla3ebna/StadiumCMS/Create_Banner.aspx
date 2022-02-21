<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Create_Banner.aspx.cs" Inherits="StadiumCMS_Create_Banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">Banner</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="Manage"></asp:Label></span>
        </li>
    </ul>

    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Manage_Banner.aspx"><i class="os-icon os-icon-ui-49"></i><span>Manage Banner</span></a>
                        </div>
                        <h6 class="element-header">Banner</h6>
                        <div class="element-box">

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            Title
                                        </label>
                                        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" placeholder="Title "></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="req" runat="server" ControlToValidate="TxtName" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Required" ValidationGroup="MainValidate" CssClass="require"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            Image
                                        </label>
                                        <input class="txt" id="uFile1" style="width: 100%" type="file" name="uFile1" runat="server">
                                        <br />
                                        <img id="img_pic" width="100" height="100" runat="server">
                                        <asp:Label ID="labPhotoFile" Visible="false" runat="server" Text=""></asp:Label>

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
         <script type="text/javascript" src="Design/Scripts/1.7.2/jquery.min.js"></script>
    </div>
</asp:Content>

