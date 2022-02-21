<%@ Page Title="" Language="C#" MasterPageFile="cpanl.master" AutoEventWireup="true" CodeFile="competitionDate.aspx.cs" Inherits="YCLC_cp_competitionDate" EnableEventValidation="false" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">
    <h4 class="widgettitle"></h4>

    <div class="mediamgr_head">
        <ul class="mediamgr_menu">
            <li class="pull-left pd">           
                <asp:LinkButton ID="lnkback" runat="server" CssClass="btn btn-danger" Text="Back" PostBackUrl="~/YCLC/cp/YCLC_ViewUsers.aspx"></asp:LinkButton>
            </li>
        </ul>
        <div class="clearall"></div>
    </div>


    <div class="widgetcontent bordered shadowed stdform">
        <div id="contentdiv" runat="server">

            <div class="col-lg-12 col-lg-12 col-xs-12 pull-right" style="margin-top: 18px;">
                <div class="form-group">
                    <div class="col-sm-2">
                        <asp:Label ID="Label3" runat="server" class="control-label" Text="start date"></asp:Label>

                    </div>
                    <div class="col-sm-9">
                        <asp:RequiredFieldValidator ID="filerequire" runat="server" ControlToValidate="datepicker1" CssClass="error" ErrorMessage="مطلوب هذه الخانة"
                            ValidationGroup="ycldate" Display="Dynamic"></asp:RequiredFieldValidator>

                        <asp:TextBox ID="datepicker1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="datepicker1" Display="Dynamic"
                            CssClass="error" ValidationGroup="ycldate"></asp:RequiredFieldValidator>
                    </div>

                </div>


            </div>
            <div class="clearfix"></div>

            <div class="col-lg-12 col-lg-12 col-xs-12 pull-right" style="margin-top: 18px;">
                <div class="form-group">
                    <div class="col-sm-2">
                        <asp:Label ID="Label1" runat="server" class="control-label" Text="End date"></asp:Label>

                    </div>
                    <div class="col-sm-9">

                        <asp:TextBox ID="datepicker2" runat="server"></asp:TextBox>
                    </div>

                </div>


            </div>
            <div class="clearfix"></div>

            <div class="col-lg-8 " style="padding-top: 25px;">
                <i class="iconfa-upload-alt"></i>
                <div class="col-sm-10" style="text-align: center;">
                    <asp:Button runat="server" ID="btnadd" CssClass="btn btn-info" Text="حفظ" ValidationGroup="topbanner" OnClientClick="confirm(Are you Sure);" OnClick="btnadd_Click" />
                    <asp:Button runat="server" ID="btCancel" CssClass="btn btn-danger" Text="الغاء" PostBackUrl="YCLC_UserDetails.aspx" />
                </div>
            </div>
            <div class="clearall"></div>
            <hr />

        </div>
        <div runat="server" id="emaillistgrid" style="display: none;">
            <asp:GridView ID="emailgrid" runat="server" AllowPaging="false" EmptyDataText="No Records Found" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="اسم المشارك" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("اسم المشارك") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الجنس" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("الجنس") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الهاتف" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("الهاتف") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="الرقم المدني" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("الرقم المدني") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="اختر مسابقة واحدة فقط" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("اختر مسابقة واحدة فقط") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="البريد الالكتروني" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("البريد الالكتروني") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ChildDOB" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval("ChildDOB") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="المحافظة" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval("المحافظة") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="منطقة السكن" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("منطقة السكن") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" تم تسجيلك في المستوى" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval(" تم تسجيلك في المستوى") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="اسم ولي الأمر" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("اسم ولي الأمر") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="البريد الالكتروني لولي الأمر" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("البريد الالكتروني لولي الأمر") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="هاتف ولي الأمر" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("هاتف ولي الأمر") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>                    <asp:TemplateField HeaderText="DateOfApply" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval("DateOfApply") %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="الرقم" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a id="A1" href='<%# "https://www.youth.gov.kw/"+ Eval("صورة البطاقة المدنية")  %>' runat="server">View </a>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hdfile" runat="server" />
        </div>
    </div>
</asp:Content>



