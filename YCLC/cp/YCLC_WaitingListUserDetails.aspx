<%@ Page Title="" Language="C#" MasterPageFile="~/YCLC/cp/cpanl.master" AutoEventWireup="true" CodeFile="YCLC_WaitingListUserDetails.aspx.cs" Inherits="YCLC_cp_YCLC_WaitingListUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .pull-left
        {
            float: left!important;
        }

        select
        {
            width: 100%;
            margin-left: 0px;
        }

        @media screen and (max-width: 700px)
        {
            input[type="text"]
            {
                width: 66%;
                margin-bottom: 7px;
            }

            select
            {
                margin-bottom: 7px;
            }
        }

        .drpColor
        {
            background-color: #05436d;
            width: 250px;
            color: #fff;
        }
    </style>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/CSS/style.css" />
    <link rel="stylesheet" href="~/Content/CSS/style.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,400;0,500;1,400&family=Roboto:wght@300;500&display=swap" rel="stylesheet" />
    <script src="Content/JS/scroll.js"></script>
    <script src="~/Content/JS/scroll.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">
    <h4 class="widgettitle"></h4>
    <div class="mediamgr_head">
        <ul class="mediamgr_menu">
            <div id="successAdmin" class="alert alert-success notification msgsuccess" runat="server" visible="false">
                <a class="close"></a><strong>Well done!</strong> You have successfully Changed.
            </div>
            <li class="pull-left pd">
                <asp:LinkButton ID="lnlprint" runat="server" OnClick="lnlprint_Click" Text="Print" ToolTip="Print"><span class="fa fa-print" style="font-size: 21px; font-weight: 500; text-shadow: none;"></span>
                </asp:LinkButton>
                <asp:LinkButton ID="lnkback" runat="server" CssClass="btn btn-danger" Text="Back" PostBackUrl="~/YCLC/cp/YCLC_ViewWaitingList.aspx"></asp:LinkButton>


              
            </li>
            <li class="pull-right pd" >  <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" CssClass="btn btn-danger"  CommandArgument="" OnClientClick="if(!confirm('Are you sure To delete?')) return false;" OnClick="lnkdelete_Click"></asp:LinkButton></li>
        </ul>
        <div class="clearall"></div>
    </div>
    <div class="candidates-item" style="direction: rtl">
        <span class="meta"></span>
        <div class="gridView" style="direction: rtl">
            <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
            <asp:Repeater ID="comptetionrepeater" runat="server" OnItemDataBound="comptetionrepeater_ItemDataBound">
                <ItemTemplate>
                    <table width="100%" cellpadding="10" cellspacing="10" class="table table-bordered nf">
                        <tr>
                            <td colspan="3">
                                <h4 class="widgettitle">User Details </h4>
                                <span class="lblar"></span>
                            </td>
                        </tr>
                        <%-- <tr>
                            <td>UserId </td>
                            <td>
                                <%#Eval("id") %>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>اسم المشارك </td>
                            <td>
                                <%# Eval("اسم المشارك") %>
                                <asp:HiddenField ID="hdid" runat="server" Value=' <%# Eval("id") %>' />
                            </td>
                        </tr>

                        <tr>
                            <td>الرقم المدني </td>
                            <td>
                                <asp:Label ID="lblcivil" runat="server" Text='<%# Eval("الرقم المدني") %>'></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>تاريخ الميلاد</td>
                            <td>
                                <asp:Label ID="lbldob" runat="server" Text='<%#Eval("تاريخ الميلاد") %>'></asp:Label>
                                <%-- <%#Eval("تاريخ الميلاد") %>--%>
                                <asp:HiddenField ID="hidde2" runat="server" Value='<%#Eval("تاريخ الميلاد") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>الهاتف </td>
                            <td>
                                <%# Eval("الهاتف") %>
                            </td>
                        </tr>


                        <tr>
                            <td>البريد الالكتروني </td>
                            <td>
                                <%# Eval("البريد الالكتروني") %>
                            </td>
                        </tr>

                        <tr>
                            <td>الجنس  </td>
                            <td>
                                <%# Eval("الجنس") %>
                            </td>
                        </tr>

                        <tr>
                            <td>اختر مسابقة واحدة فقط </td>
                            <td>
                                <asp:Label ID="lblcategory" runat="server" Text='<%# Eval("اختر مسابقة واحدة فقط") %>'></asp:Label>
                                &nbsp;&nbsp;  &nbsp;&nbsp;     
                                <asp:LinkButton ID="lnkChange" runat="server" OnCommand="lnkChange_Command" > تغيير المسابقة </asp:LinkButton>

                            </td>
                        </tr>


                        <tr>
                            <td>تم تسجيلك في المستوى</td>
                            <td>
                                <%#Eval("تم تسجيلك في المستوى") %>      
                            </td>
                        </tr>

                        <tr runat="server" id="trsubgroup">
                            <td>المسابقة المتاحة</td>
                            <td>
                                <asp:Label ID="lblsubgroup" runat="server" Text='<%#Eval("المسابقة المتاحة") %>'></asp:Label>
                            </td>
                        </tr>



                        <tr style="display:none;">
                            <td colspan="3">
                                <h4 class="widgettitle">Guardian Details</h4>
                                <span class="lblar"></span>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td>اسم ولي الأمر </td>
                            <td>
                                <%# Eval("اسم ولي الأمر") %>
                            </td>
                        </tr>

                        <tr style="display:none;">
                            <td>هاتف ولي الأمر </td>
                            <td>
                                <%# Eval("هاتف ولي الأمر") %>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td>البريد الالكتروني لولي الأمر </td>
                            <td>
                                <%# Eval("البريد الالكتروني لولي الأمر") %>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="3">
                                <h4 class="widgettitle">Address</h4>
                                <span class="lblar"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>المحافظة </td>
                            <td>

                                <asp:Label runat="server" ID="lblgove" Text=' <%#Eval("المحافظة") %>'></asp:Label>


                                  &nbsp;&nbsp;  &nbsp;&nbsp;     
                                <asp:LinkButton ID="lnkGov" runat="server" OnCommand="lnkGov_Command"> تغيير المحافظة </asp:LinkButton>
                               
                            </td>
                        </tr>


                        <tr>
                            <td>منطقة السكن </td>
                            <td>
                                <%# Eval("منطقة السكن") %>
                            </td>
                        </tr>

                        <tr>
                            <td>تاريخ التقديم</td>
                            <td>
                                <%# Eval("تاريخ التقديم") %>
                            </td>
                        </tr>
                        <tr style="visibility: hidden;">
                            <td colspan="3">
                                <h4 class="widgettitle">Files</h4>
                                <span class="lblar"></span>
                            </td>
                        </tr>
                      
                        <tr runat="server" id="trChanges">
                            <td colspan="3">
                                <h4 class="widgettitle">Changes</h4>
                                <span class="lblar"></span>
                            </td>
                        </tr>

                    </table>
                </ItemTemplate>
            </asp:Repeater>



            <asp:Panel runat="server" ID="pnl" Visible="false">
                <table width="100%" cellpadding="10" cellspacing="10" class="table table-bordered nf">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>


                                    <label class="control-label col-sm-3">اختر مسابقة واحدة فقط</label>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" InitialValue="0" 
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDLCatagory"
                                        CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DDLCatagory" runat="server" CssClass="form-control" Width="50%" AutoPostBack="true" OnSelectedIndexChanged="DDLCatagory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    



                                       <label class="control-label"></label>
                                    <div class="clear"></div>

                                    <asp:Panel runat="server" ID="pnlSub" Visible="false">

                                        <label class="control-label col-sm-3">المسابقة المتاحة</label>

                                        <asp:DropDownList ID="DDlSubGroup" runat="server" CssClass="form-control" Width="50%" Enabled="false">
                                        </asp:DropDownList>




                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Display="Dynamic" InitialValue="0"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDlSubGroup"
                                            CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>


                                    </asp:Panel>
                                    </td></tr>

                            
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="col-md-12 text-center" style="padding-top: 30px">

                                <asp:Button runat="server" ID="BtSave" Text="Save Changes " CssClass="btn btn-info"  ValidationGroup="personalInfo"   OnClientClick="if(!confirm('Are you sure to change?')) return false;" OnClick="BtSave_Click" />

                            </p>
                        </td>
                    </tr>
                </table>


            </asp:Panel>



             <asp:Panel runat="server" ID="pnlGov" Visible="false">
                <table width="100%" cellpadding="10" cellspacing="10" class="table table-bordered nf">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>


                                    <label class="control-label col-sm-3">المحافظة</label>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" InitialValue="0" 
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDlGovernarate"
                                        CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                      <asp:DropDownList ID="DDlGovernarate" runat="server" Width="50%"  CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDlGovernarate_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                    



                                       <label class="control-label"></label>
                                    <div class="clear"></div>

                                    <asp:Panel runat="server" ID="pnlAREA" Visible="false">

                                        <label class="control-label col-sm-3">منطقة السكن</label>

                                     <asp:DropDownList ID="DDLArea" runat="server" Width="50%" CssClass="form-control" Enabled="false" AutoPostBack="true">
                                                        </asp:DropDownList>



                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" InitialValue="0"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDLArea"
                                            CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>


                                    </asp:Panel>
                                    </td></tr>

                            
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="col-md-12 text-center" style="padding-top: 30px">

                                <asp:Button runat="server" ID="Btgov" Text="Save Changes " CssClass="btn btn-info"  ValidationGroup="personalInfo"   OnClientClick="if(!confirm('Are you sure to change?')) return false;"  OnClick="Btgov_Click" />

                            </p>
                        </td>
                    </tr>
                </table>


            </asp:Panel>

        </div>
    </div>
</asp:Content>

