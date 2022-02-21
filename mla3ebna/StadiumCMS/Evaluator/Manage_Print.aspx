<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_Print.aspx.cs" Inherits="Evaluator_Manage_Print" MasterPageFile="StadiumEvalMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript">

         function openPopup(id) {
            
             window.open("Print_Evalstadium.aspx?StadiumEvalID="+id, "popupwindow", "width=800,height=600,left=200,top=5,scrollbars,toolbar=0,resizable"); return false;

         }
    </script>
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
                <asp:Label ID="labtitle1" runat="server" Text="Print"></asp:Label></span>
        </li>
    </ul>

    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <%--<a class="btn btn-success btn-sm" href="Add_EvalUser.aspx"><i class="os-icon os-icon-ui-22"></i><span>&nbsp; إضافة فريق العمل </span></a>--%>
                        </div>
                        <h6 class="element-header">الملعب</h6>

                        <div class="element-box">

                             <div class="row">
                                <div class="col-lg-4">
                                    <%--<asp:LinkButton ID="lk_del" runat="server" CssClass="btn btn-round btn-sm btn-danger" OnClick="lk_del_Click"><i class="os-icon os-icon-ui-15"></i>&nbsp;Delete</asp:LinkButton>
                                --%>
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
                                            CellPadding="5" CellSpacing="8" OnDataBound="GVData_DataBound" 
                                            PageSize="50" GridLines="Horizontal" AllowPaging="true"  ShowFooter="false">  <%-- DataKeyNames="TimeSlotBlockId"--%>
                                            <HeaderStyle CssClass="panel-blue"></HeaderStyle>   


                                            <Columns>
                                                <asp:TemplateField Visible="true">
                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                    <HeaderTemplate>
                                                       <%-- <asp:CheckBox ID="cb0" OnCheckedChanged="cb0_change" runat="server" AutoPostBack="True"></asp:CheckBox>--%>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="labItemID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StadiumEvalID")%>'></asp:Label>
                                                        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="StadiumEvalID" Visible="false" ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="StadiumName" HeaderText="StadiumName"></asp:BoundField>
                                                <asp:BoundField DataField="Note" HeaderText="Note"></asp:BoundField>
                                             
                                               
                                              
                                                <asp:TemplateField HeaderText="عرض" ItemStyle-Width="10%" ItemStyle-CssClass="text-center"
                                                    HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        
                                                        <%--<a ID="hyperedit"  href="Print_Evalstadium.aspx?StadiumEvalID=<%#DataBinder.Eval(Container.DataItem, "StadiumEvalID")%>" class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-print" aria-hidden="true"></i></a>--%>  
                                                                                                            
                                                       <asp:LinkButton ID="lnk" runat="server" OnClientClick='<%# "openPopup(" +Eval("StadiumEvalID") + " );" %>' class="mr-2 mb-2 btn btn-outline-success btn-sm"><i class="fa fa-print" aria-hidden="true"></i></asp:LinkButton>
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

