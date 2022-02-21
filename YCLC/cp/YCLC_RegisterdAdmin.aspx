<%@ Page Title="" Language="C#" MasterPageFile="~/YCLC/cp/cpanl.master" AutoEventWireup="true" CodeFile="YCLC_RegisterdAdmin.aspx.cs" Inherits="YCLC_cp_YCLC_RegisterdAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">
    <h4 class="widgettitle">View List Of User 

           <div class="pull-left pd" style="visibility:hidden;">
               <asp:LinkButton ID="btnExport" runat="server" ToolTip="Export to Excel" Text="Export to Excel" OnClick="btnExport_Click"
                   Style="font-size: 21px;">   <i class="fa fa-file-excel-o"></i>  </asp:LinkButton>
               <asp:LinkButton ID="lnlprint" runat="server" OnClick="lnlprint_Click" ToolTip="Print"><span class="fa fa-print" style="font-size: 21px; font-weight: 500; text-shadow: none;"></span>
               </asp:LinkButton>
               &nbsp; &nbsp;
           </div>
    </h4>


    <div class="mediamgr_head">

        <div class="row">
             <div class="col-sm-12">
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Organization</label>

                            <asp:DropDownList ID="DDlOrganization" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="DDlOrganization_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>              
            
                <div class="col-sm-2">
                    <div class="form-group">
                        <label>Mobile</label>
                        <asp:TextBox ID="txtmbl" runat="server" AutoPostBack="true" Width="100%" OnTextChanged="txtmbl_TextChanged"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-2">
                    <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox ID="TextEmail" runat="server" AutoPostBack="true" Width="100%" OnTextChanged="TextEmail_TextChanged"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-2">
                    <div class="form-group">
                        <label>Status</label>
                        <asp:DropDownList ID="drpstatus" runat="server" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="drpstatus_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Pending"></asp:ListItem>
                            <asp:ListItem Value="3" Text="InActive"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="col-md-2">
                    <div class="form-group">
                         <label>&nbsp;</label>
                        <asp:Button runat="server" ID="btClear" CssClass="btn btn-danger" Text="Clear Selection" OnClick="btClear_Click" />
                    </div>
                </div>
            </div>
        </div>
       
       
        <div class="clearall"></div>
    </div>


    <asp:GridView ID="competetionGrid" runat="server" CssClass="table table-bordered" EmptyDataText="No Records Found" AllowSorting="true" AutoGenerateColumns="false" OnRowCommand="competetionGrid_RowCommand" AllowPaging="true"
        OnPageIndexChanging="competetionGrid_PageIndexChanging" OnDataBound="competetionGrid_DataBound" CellPadding="4" PageSize="20" Style="direction: rtl" DataKeyNames="ID" OnRowCreated="competetionGrid_RowCreated" OnRowDataBound="competetionGrid_RowDataBound">

        <AlternatingRowStyle BackColor="White" />

        <Columns>

            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الرقم">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="left"></HeaderStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="ID" Visible="false">
                <ItemTemplate>

                    <asp:Label ID="labelID" runat="server" Text='<%# Eval("id") %>'></asp:Label>


                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Name">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkusername" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="View" Text='<%# Eval("Name") %>'></asp:LinkButton>

                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="OrganizationName">
                <ItemTemplate>
                    <%# Eval("OrganizationName") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Email">
                <ItemTemplate>
                    <%# Eval("Email") %>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Phone">
                <ItemTemplate>
                    <%# Eval("Phone") %>
                </ItemTemplate>
            </asp:TemplateField>

            
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Post Date">
                <ItemTemplate>
                    <%# Eval("CreatedDate") %>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Status">
                <ItemTemplate>
                    <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLStatus_SelectedIndexChanged" ForeColor="White">
                        <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Inactive"></asp:ListItem>
                    </asp:DropDownList>

                    <%-- BackColor='<%# Eval("status") == "Active"?"#1aad1f":"#ad265c" %>'  --%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkadd" runat="server" CommandName="Add" CommandArgument='<%# Eval("id") %>' Text="Add" Visible='<%# Eval("status") == "Active"?true:false %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>



        </Columns>


        <PagerStyle CssClass="dataTables_info" />
        <PagerTemplate>
            <div class="pagination">
                <ul>
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>
                    </li>
                    <li>
                        <asp:Label ID="pmore" runat="server" Text="..."></asp:Label>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Page" CommandArgument="Prev">>></asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="p0" runat="server">LinkButton</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="p1" runat="server">LinkButton</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="p2" runat="server">LinkButton</asp:LinkButton>
                    </li>
                    <li>
                        <asp:Label ID="CurrentPage" runat="server" Text="Label"></asp:Label>
                    </li>
                    <li>
                        <asp:LinkButton ID="p4" runat="server">LinkButton</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="p5" runat="server">LinkButton</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="p6" runat="server">LinkButton</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Page" CommandArgument="Next"><<</asp:LinkButton>
                    </li>
                    <li>
                        <asp:Label ID="nmore" runat="server" Text="..."></asp:Label>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Page" CommandArgument="Last">Last</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </PagerTemplate>
    </asp:GridView>


</asp:Content>

