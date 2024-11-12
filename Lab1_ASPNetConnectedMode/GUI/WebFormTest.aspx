<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTest.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebFormTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="lblState" runat="server" Text="Database Connection"></asp:Label>
            <asp:Button ID="ButtonConnectDB" runat="server" Height="56px" OnClick="ButtonConnectDB_Click" Text="Connect Database" Width="177px" />
        </div>
    </form>
</body>
</html>
