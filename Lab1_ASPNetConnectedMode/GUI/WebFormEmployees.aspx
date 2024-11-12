<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployees.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebFormEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            color: #FF0000;
            text-align: center;
        }
        .auto-style3 {
            width: 48px;
        }
        .auto-style4 {
            height: 31px;
        }
        .auto-style5 {
            width: 268435456px;
        }
        .auto-style6 {
            color: #00FFFF;
        }
        .auto-style7 {
            text-decoration: underline;
            color: #0000FF;
            text-align: center;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="3" rowspan="2"><strong>Employee Maintenance</strong></td>
                    <td colspan="3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td rowspan="7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Employee ID</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxEmpId" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" Width="94px" />
                    </td>
                    <td colspan="3" rowspan="6"></td>
                </tr>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="TextBoxFirstN" runat="server" Width="274px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
                    </td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="TextBoxLastN" runat="server" Width="271px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="ButtonDelete" runat="server" Text="Delete" Width="96px" OnClick="ButtonDelete_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Job Title</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxJobT" runat="server" Width="425px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonList" runat="server" OnClick="ButtonList_Click" Text="List All" Width="96px" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="LabelDisplay" runat="server" Text="Enter Employee ID"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Search By</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="DropDownListSearchOption" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSearchOption_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4" colspan="4">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    <p>
        &nbsp;</p>
    <p class="auto-style6">
        <strong>Employees List</strong></p>
        <asp:GridView ID="GridViewEmployees" runat="server" Width="1090px">
        </asp:GridView>
    </form>
    <table class="auto-style1">
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</body>
</html>
