<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs_Reply.aspx.cs" Inherits="ContactUs_Reply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Design/css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

       <div class="content-i">
            <div class="content-box">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="element-wrapper">
                            <h6 class="element-header">Reply To Email</h6>
                            <div class="element-box">
                                
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label for="">
                                                To</label>
                                           <asp:TextBox ID="TxtToEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                           
                                        </div>
                                    </div>


                                </div>


                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label for="">
                                                ReplyMessage</label>
                                            <asp:TextBox ID="TxtReplyMessage" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>


                                </div>

                                <div class="form-buttons-w">
                                    <asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" CssClass="btn" Text="Send" ValidationGroup="MainValidate" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        

    </form>
</body>
</html>



