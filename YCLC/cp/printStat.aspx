<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printStat.aspx.cs" Inherits="youthNEWADMIN_printACE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grdAce" CssClass="table table-bordered" runat="server" Width="100%" Style="direction: rtl" 
            AllowSorting="True" AutoGenerateColumns="False" PageSize="20" ShowFooter="true"
            CellPadding="4">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
           
              
        


                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Height="40" HeaderText="Catagory">
                    <ItemTemplate>
                        <span class="nf"><%# Eval("Catgeory_name")%></span>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </asp:TemplateField>




                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Count">
                    <ItemTemplate>
                        <span class="nf"><%# Eval("val")%></span>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </asp:TemplateField>                   




          
            </Columns>


            <PagerStyle CssClass="pagination pagination-centered" />
        </asp:GridView>
          
                                                <asp:SqlDataSource ID="sqlace" runat="server"
                                                    SelectCommand="aceStatistics2017" SelectCommandType="StoredProcedure">
                                                      <SelectParameters>
                      <asp:SessionParameter Name="type" SessionField="sess_acetype" Type="String" />

               </SelectParameters>
                                                </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
