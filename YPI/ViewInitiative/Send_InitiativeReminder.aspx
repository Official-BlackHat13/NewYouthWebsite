<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="Send_InitiativeReminder.aspx.cs" Inherits="ViewInitiative_Send_InitiativeReminder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">برنامج المبادر المحترف</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="Send Reminder"></asp:Label>
            </span>
        </li>
    </ul>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <%--  <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Create_Quotation.aspx"><i class="os-icon os-icon-ui-22"></i><span>Create مبادراتنا</span></a>
                        </div>--%>
                        <h6 class="element-header">Send Reminder</h6>
                        <div class="element-box-tp">
                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:TextBox ID="TxtSendMailText" CssClass="form-control" TextMode="MultiLine" Rows="10" runat="server"></asp:TextBox>
                                     

                                    </div>
                                </div>


                            </div>
                               <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Send</asp:LinkButton>

                                <asp:LinkButton ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-danger mr-1"><i class="fa fa-refresh" aria-hidden="true"></i>&nbsp;Cancel</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

