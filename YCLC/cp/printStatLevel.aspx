<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printStatLevel.aspx.cs" Inherits="youthNEWADMIN_printACE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <div>
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

                
                 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="English">
                    <ItemTemplate>
                        <span class="nf">

                             <asp:label runat="server" ID="lbllbelEng" ></asp:label>
                        </span>
                    </ItemTemplate>
                            <FooterTemplate>
     <asp:Label ID="lblTotalEng" runat="server"></asp:Label>
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
    </div>
    </form>
</body>
</html>
