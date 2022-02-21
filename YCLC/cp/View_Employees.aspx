<%@ Page Title="" Language="C#" MasterPageFile="~/YCLC/cp/cpanl.master" AutoEventWireup="true" CodeFile="View_Employees.aspx.cs" Inherits="YCLC_cp_View_Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         <style>
        .pull-left {
            float: left!important;
        }

        select {
            width: 100%;
            margin-left: 0px;
        }

        @media screen and (max-width: 700px) {
            input[type="text"] {
                width: 66%;
                margin-bottom: 7px;
            }

            select {
                margin-bottom: 7px;
            }
        }
         .drpColor {
            background-color: #05436d;
            width: 250px;
            color: #fff;
        }
         input[type="text"], input[type="textarea"], input[type="password"]
         {
             width: 100%;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" Runat="Server">
     <h4 class="widgettitle"> View List Of Employees 

           <div class="pull-left pd">
              <asp:LinkButton ID="lnkExport" runat="server" ToolTip="Export to Excel" Text="Export to Excel" OnClick="lnkExport_Click"
                  Style="font-size: 21px;">   <i class="fa fa-file-excel-o"></i>  </asp:LinkButton>
              <asp:LinkButton ID="lnkprint" runat="server" OnClick="lnkprint_Click" ToolTip="Print"><span class="fa fa-print" style="font-size: 21px; font-weight: 500; text-shadow: none;"></span>
              </asp:LinkButton> &nbsp; &nbsp;
              
          </div>
    </h4>

     <div class="mediamgr_head">
        <ul class="mediamgr_menu">

           
             <li class="col-md-12 col-sm-12 col-xs-12 pd">
                 <div class="col-sm-3 pull-right ad_input">
                    <div class="form-group">
                        <label>Organization</label>

                        <asp:DropDownList ID="DDlOrganization" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="DDlOrganization_SelectedIndexChanged">
                           
                        </asp:DropDownList>
                    </div>
                </div>

                 <div class="col-sm-3 pull-right ad_input">
                    <div class="form-group">
                        <label>Mobile</label>
                       <asp:TextBox ID="txtmbl" runat="server" AutoPostBack="true" OnTextChanged="txtmbl_TextChanged"></asp:TextBox>
                    </div>
                </div>

                 <div class="col-sm-3 pull-right ad_input">
                    <div class="form-group">
                        <label>Email</label>
                       <asp:TextBox ID="TextEmail" runat="server" AutoPostBack="true" OnTextChanged="TextEmail_TextChanged"></asp:TextBox>
                    </div>
                </div>

                  <div class="col-md-2 col-sm-3 pull-right ad_input">
                    <div class="form-group">
                         <label> &nbsp;</label>
                        <asp:Button runat="server" ID="btClear" CssClass="btn btn-danger" Text="Clear Selection" OnClick="btClear_Click" />
                    </div>
                </div>

             </li>
            <div class="clearall"></div>
        </ul>
    </div>


    <asp:GridView ID="adminGrid" runat="server" CssClass="table table-bordered" EmptyDataText="No Records Found" AllowSorting="true" AutoGenerateColumns="false"  OnRowCommand="adminGrid_RowCommand" AllowPaging="true"
        OnPageIndexChanging="adminGrid_PageIndexChanging" OnDataBound="adminGrid_DataBound" CellPadding="4" PageSize="20" Style="direction: rtl" OnRowCreated="adminGrid_RowCreated">

        <alternatingrowstyle backcolor="White" />
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الرقم">
                <ItemTemplate>
                         <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
            </asp:TemplateField>
            
            

            <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderText="Name">
               <ItemTemplate> 
                   <%--<asp:LinkButton ID="lnkusername" runat="server" Text='<%# Eval("اسم المشارك") %>'></asp:LinkButton> --%>     <%-- CommandArgument='<%# Eval("ID") %>' CommandName="View" --%>
                  <%# Eval("Name") %>
               </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Name in English" Visible="true">
                <ItemTemplate>
                    <%# Eval("EnglishName") %>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="OrganizationName" Visible="true"> <%--orgname--%>
                <ItemTemplate>
                    <%# Eval("OrganizationName") %>
                </ItemTemplate>
            </asp:TemplateField>   
            
             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Email" Visible="true">  <%--email--%>
                <ItemTemplate>
                    <%# Eval("Email") %>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Phone" Visible="true">  <%--mobile--%>
                <ItemTemplate>
                    <%# Eval("Phone") %>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Password" Visible="true"> <%-- password--%>
                <ItemTemplate>
                    <asp:Label ID="lblpwd" runat="server" type="Password" Text="******"></asp:Label>

                    <asp:LinkButton ID="lnkshowPwd" runat="server" CommandArgument='<%# Eval("Password") %>' CommandName="View"><span class="fa fa-eye"></span></asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>


                     

           


            
        </Columns>

        <pagerstyle cssclass="dataTables_info" />
            <pagertemplate>
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
              <asp:LinkButton ID="p0" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p1" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p2" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:Label ID="CurrentPage" runat="server" Text="Label"></asp:Label>
            </li>
            <li>
              <asp:LinkButton ID="p4" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p5" runat="server" >LinkButton</asp:LinkButton>
            </li>
            <li>
              <asp:LinkButton ID="p6" runat="server" >LinkButton</asp:LinkButton>
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
      </pagertemplate>
    </asp:GridView>

</asp:Content>

