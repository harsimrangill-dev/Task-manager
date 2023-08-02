<%@ Page Language="C#" AutoEventWireup="true" CodeFile="taskl.aspx.cs" Inherits="taskl" %>
<link href="layout.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="hed" >
            <b>Tasks To Do</b>
        </div>
        <div class="tbl"  >
            <table>
            </table>
            <asp:Table CssClass="timecard" runat="server" ID="tbl">

                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Serial No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        Tasks
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>Progress</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <br />
            
        </div>
        
        <div class="task">
            <table>
                <tr>
                    <td>Task :</td>
                    <td> <asp:TextBox ID="taskinput" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="Add" runat="server" OnClick="adds" Text="Add" /></td>
                </tr>
            </table>
            <br /><br />
            <table>
                <tr>
                    <td>Serial no.</td>
                    <td><asp:TextBox ID="Update" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="updt" runat="server" OnClick="updte" Text="Update" />
                    </td>
                </tr>
            </table>
            <br /><br />
            <table>
                <tr>
                    <td>Serial No. </td>
                    <td><asp:TextBox ID="deltask" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="del" runat="server" OnClick="delt" Text="DELETE" /></td>
                </tr>
            </table>
        </div>
        <div class="foot">
            <asp:Label ID="lbl" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
