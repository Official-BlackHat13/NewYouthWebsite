<%@ Page Title="" Language="C#" MasterPageFile="cpanl.master" AutoEventWireup="true" CodeFile="YCLC_UserBasic.aspx.cs" Inherits="YCLC_cp_YCLC_UserBasic"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">
     <h4 class="widgettitle"> View List Of User 

           <div class="pull-left pd">
              <asp:LinkButton ID="btnExport1" runat="server" ToolTip="Export to Excel" Text="Export to Excel" OnClick="btnExport1_Click"
                  Style="font-size: 21px;">   <i class="fa fa-file-excel-o"></i>  </asp:LinkButton>
              <asp:LinkButton ID="lnlprint" runat="server" OnClick="lnlprint_Click" ToolTip="Print"><span class="fa fa-print" style="font-size: 21px; font-weight: 500; text-shadow: none;"></span>
              </asp:LinkButton>
          </div>
    </h4>
     <asp:HiddenField ID="hdConfirmation" runat="server" />
    <asp:HiddenField ID="hdType" runat="server" />
     <asp:GridView ID="competetionGrid" runat="server" CssClass="table table-bordered" EmptyDataText="No Records Found" AllowSorting="true" AutoGenerateColumns="false"  OnRowCommand="competetionGrid_RowCommand" AllowPaging="true"
        OnPageIndexChanging="competetionGrid_PageIndexChanging" OnDataBound="competetionGrid_DataBound" CellPadding="4" PageSize="20" Style="direction: rtl" OnRowCreated="competetionGrid_RowCreated">

        <alternatingrowstyle backcolor="White" />

        <Columns>
             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الرقم">
                <ItemTemplate>
                         <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
            </asp:TemplateField>

             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="اسم المشارك">
                <ItemTemplate>
                    <%# Eval("اسم المشارك")%> 
                    
                   
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الرقم المدني">
                <ItemTemplate>
                    <%# Eval("الرقم المدني")%> 
                    
                   
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الهاتف">
                <ItemTemplate>
                   <%# Eval("الهاتف") %>
                    
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="البريد الالكتروني">
                <ItemTemplate>
                    <%# Eval("البريد الالكتروني") %>
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="الجنس">
                <ItemTemplate>
                    <%# Eval("الجنس") %>
                </ItemTemplate>
            </asp:TemplateField>

            
               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="اختر مسابقة واحدة فقط">
                <ItemTemplate>
                    <%# Eval("اختر مسابقة واحدة فقط") %>
                </ItemTemplate>
            </asp:TemplateField>

              
               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="تم تسجيلك في المستوى">
                <ItemTemplate>
                    <%# Eval("تم تسجيلك في المستوى") %>
                </ItemTemplate>
            </asp:TemplateField>

                 
               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="المسابقة المتاحة">
                <ItemTemplate>
                    <%# Eval("المسابقة المتاحة") %>
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