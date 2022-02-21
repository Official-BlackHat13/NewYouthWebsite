<%@ Page Title="" Language="C#" MasterPageFile="cpanl.master" AutoEventWireup="true" CodeFile="StatisticsLevel.aspx.cs" Inherits="MYA2_aceStatistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .footerStyle {

           background-color:#E2EDF2;
            direction:rtl;
           height:30px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">
    <div class="contentinner">
        <h4 class="widgettitle">Catagory View</h4>
        <div class="mediamgr_head" dir="rtl">
            <ul class="mediamgr_menu">
                <li class="field marginleft15"></li>
                <li>
                    <br />
                </li>
                <%-- <li style="text-align: left">
                    <asp:Button CssClass="btn btn-success" runat="server" Text="Advanced Search" ID="lnkAdv" OnClick="lnkAdv_Click"></asp:Button></li>--%>
            </ul>
            <span style="float: left">              
                 
                <asp:LinkButton runat="server" ToolTip="Print" ID="btprint" CssClass="btn btn-success" OnClick="btprint_Click"><span class="fa fa-print"><i></i></span> </asp:LinkButton>
            <asp:LinkButton runat="server" ToolTip="Back" ID="btnBack" CssClass="btn btn-danger" OnClick="btnback_Click"><span class="fa fa-arrow-left "><i></i></span> </asp:LinkButton>
                 </span>
            <br />
        </div>
        <!--mediamgr_head-->
        <h4 class="widgettitle"></h4>
        <div id="success" class="notifySuccess" runat="server" visible="false">
            <a class="close"></a>
            <p>Email Confirmation sent Successfully </p>
        </div>
        <!-- notification msgsuccess -->
        <asp:GridView ID="grdAce" CssClass="table table-bordered"  runat="server" Width="100%" Style="direction: rtl" 
            AllowSorting="True" AutoGenerateColumns="False" PageSize="20" ShowFooter="true" OnRowDataBound="grdAce_RowDataBound"
            CellPadding="4">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
               
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="مجال الترشح">
                    <ItemTemplate>
                        <span class="nf"> <span class="nf"><%# Eval("Catgeory_name")%></span>
                            <asp:label runat="server" ID="lblCatagoryName"  Visible="false" Text='<%# Eval("CategoryId")%>'></asp:label>
                       
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </asp:TemplateField>

                   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="المبتدئ">
                    <ItemTemplate>
                        <span class="nf">

                             <asp:label runat="server" ID="lbllevel1"  ></asp:label>
                        </span>
                    </ItemTemplate>
                            <FooterTemplate>
     <asp:Label ID="lblTotal1" runat="server"></asp:Label>
     </FooterTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </asp:TemplateField>
               
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="المتوسط">
                    <ItemTemplate>
                        <span class="nf">
                             <asp:label runat="server" ID="lbllbel3" ></asp:label>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                          <FooterTemplate>
     <asp:Label ID="lblTotal3" runat="server"></asp:Label>
     </FooterTemplate>
                </asp:TemplateField>
              

                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="المتقدم">
                    <ItemTemplate>
                        <span class="nf">

                             <asp:label runat="server" ID="lbllbel2" ></asp:label>
                        </span>
                    </ItemTemplate>
                            <FooterTemplate>
     <asp:Label ID="lblTotal2" runat="server"></asp:Label>
     </FooterTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </asp:TemplateField>

                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="Total">
                    <ItemTemplate>
                        <span class="nf">
                             <asp:label runat="server" ID="lblCount" ForeColor="Green" ></asp:label>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                          <FooterTemplate>
     <asp:Label ID="lbl" runat="server"></asp:Label>
     </FooterTemplate>
                </asp:TemplateField>
            
              
                
            </Columns>
            
            <PagerStyle CssClass="pagination pagination-centered" />
        </asp:GridView>
        <asp:SqlDataSource ID="sqlace" runat="server"
            SelectCommand="aceStatistics2017" SelectCommandType="StoredProcedure">
               <SelectParameters>
                     <asp:Parameter DefaultValue="1" Name="type" Type="String" />

               </SelectParameters>
                     
        </asp:SqlDataSource>
    </div>
</asp:Content>
