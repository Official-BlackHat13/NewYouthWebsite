<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_EvalUsers.aspx.cs" MasterPageFile="StadiumEvalMasterPage.master" Inherits="Evaluator_Manage_EvalUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Eval_Stadium.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">User</a>
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
                            <a class="btn btn-success btn-sm" href="Add_EvalUser.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp; إضافة فريق العمل </span></a>
                        </div>
                        <h6 class="element-header">الملعب</h6>

                        <div class="element-box">

                             <div class="row">
                                <div class="col-lg-4">
                                    <asp:LinkButton ID="lk_del" runat="server" CssClass="btn btn-round btn-sm btn-danger" OnClick="lk_del_Click"><i class="os-icon os-icon-ui-15"></i>&nbsp;Delete</asp:LinkButton>
                                </div>
                                <div class="col-lg-4"></div>
                                <div class="col-lg-4 text-left">
                                    <asp:Label ID="lblCount" runat="server" CssClass="tbl_cell"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                           <asp:GridView Width="100%" ID="GVData" OnPageIndexChanging="OnPageIndexChanging"
                                            AutoGenerateColumns="false" CssClass="table table-padded" 
                                            runat="server" BorderColor="Silver" BorderWidth="0px"
                                            CellPadding="5" CellSpacing="8" 
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true"  ShowFooter="false">  <%-- DataKeyNames="TimeSlotBlockId"--%>
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>   


                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UserID")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="UserID" Visible="false" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="UserName" HeaderText="UserName"></asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                                                <asp:BoundField DataField="CivilID" HeaderText="CivilID"></asp:BoundField>
                                                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                               
                                                <asp:TemplateField HeaderText="الحالة" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ch_Status" OnCheckedChanged="Status_selected" runat="server" AutoPostBack="true"
                                                            Checked='<%# Convert.ToBoolean(Eval("status")) %>'></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="عرض" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        
                                                        <a ID="hyperedit" style="visibility:visible;" href="Add_EvalUser.aspx?UserID=<%#DataBinder.Eval(Container.DataItem, "UserID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-edit" aria-hidden="true"></i></a>                                                      
                                                      
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
