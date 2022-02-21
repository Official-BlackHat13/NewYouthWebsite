<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_EvalStadium.aspx.cs" Inherits="Evaluator_Manage_EvalStadium" MasterPageFile="StadiumEvalMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Eval_Stadium.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">الملعب</a>
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
                            <a class="btn btn-success btn-sm" href="Eval_stadium.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp; Add Stadium Evaluation </span></a>
                        </div>
                        <h6 class="element-header">الملعب</h6>

                        <div class="element-box">

                            <div class="row">
                                <div class="col-lg-4">
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
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StadiumEvalID")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="StadiumEvalID" Visible="false" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumName" HeaderText="StadiumName"></asp:BoundField>
                                                <asp:BoundField DataField="AreaName" HeaderText="Area"></asp:BoundField>
                                                <asp:BoundField DataField="Note" HeaderText="Note"></asp:BoundField>
                                             
                                               
                                                <asp:TemplateField HeaderText="الحالة" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ch_Status" OnCheckedChanged="Status_selected" runat="server" AutoPostBack="true"
                                                            Checked='<%# Convert.ToBoolean(Eval("Status")) %>'></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="عرض" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        
                                                        <a ID="hyperedit" style="visibility:visible;" href="View_Evalstadium.aspx?StadiumEvalID=<%#DataBinder.Eval(Container.DataItem, "StadiumEvalID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-eye" aria-hidden="true"></i></a>                                                      
                                                      
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


