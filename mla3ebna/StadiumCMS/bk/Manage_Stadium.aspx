<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Manage_Stadium.aspx.cs" Inherits="StadiumCMS_Manage_Stadium" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Create_Stadium.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp;إضافة الملعب</span></a>
                        </div>
                        <h6 class="element-header">بحث الملعب</h6>
                        <div class="element-box-tp">

                            <div class="row ">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            المحافظة  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            المنطقة  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLArea" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="">
                                            School  
                                          
                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLSchool" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                             اسم الملعب
                                        </label>
                                        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>



                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="inputFirstName" class="control-label">
                                            &nbsp;<br />
                                            <br />
                                            <br />
                                        </label>


                                         <asp:LinkButton ID="lnkSearch" OnClick="lnkSerach_Click" runat="server" CssClass="btn btn-round  btn-outline-success"><i class="ft-search"></i>&nbsp;بحث</asp:LinkButton>
                                        <asp:LinkButton ID="lnkClear" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-round  btn-outline-danger"><i class="ft-refresh-cw"></i>&nbsp;Clear</asp:LinkButton>


                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row ">
                                <div class="col-md-4">
                                    <asp:LinkButton ID="lnkDelete" Visible="false" runat="server" CssClass="btn btn-round btn-sm btn-danger"><i class="ft-delete"></i>&nbsp;Delete</asp:LinkButton>
                                </div>
                                <div class="col-md-4"></div>
                                <div class="col-md-4 text-left">

                                    <%-- &nbsp; | &nbsp;--%><asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView Width="100%" ID="GVData" OnPageIndexChanging="OnPageIndexChanging"
                                            AutoGenerateColumns="false" CssClass="table table-padded"
                                            runat="server" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="5" CellSpacing="8"
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true" DataKeyNames="StadiumID" ShowFooter="false">
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>
                                           

                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StadiumID")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="StadiumID" Visible="false" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumName" HeaderText="اسم الملعب"></asp:BoundField>
                                                <asp:BoundField DataField="Address" HeaderText="العنوان"></asp:BoundField>

                                              
                                                <asp:TemplateField HeaderText="الحالة" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ch_Status" OnCheckedChanged="Status_selected" runat="server" AutoPostBack="true"
                                                            Checked='<%# DataBinder.Eval(Container.DataItem, "status") %>'></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="عرض" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate> <a href="View_StadiumDetails.aspx?StadiumID=<%#DataBinder.Eval(Container.DataItem, "StadiumID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a><%--<a class="danger" href="#"><i class="os-icon os-icon-ui-15"></i></a> --%>
                                                       <%-- <a href='Create_Stadium.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "StadiumID")%>'
                                                            class="mr-2 mb-2 btn btn-outline-success btn-sm">&nbsp;<i class="os-icon os-icon-ui-49"></i>&nbsp;
                                                            تعديل &nbsp;</a>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

