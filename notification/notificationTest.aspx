<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notificationTest.aspx.cs" Inherits="notification.notificationTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

<div>

 <asp:Button  runat="server" Text="sendMessage" id="sendmessage" onclick="sendmessage_Click"  ></asp:Button>

</div>



<div>

 <asp:Button  runat="server" Text="basedOnTage" id="basedOnTage" onclick="sendmessageBasedOnTag_Click"  ></asp:Button>

</div>


    </form>
</body>
</html>
