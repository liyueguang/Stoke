<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default_rights_set.aspx.cs"
    Inherits="Stoke.USL.Workflow.Default_rights_set" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body class="body1">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td colspan="6" align="center" style="font-weight: bold; font-size: larger; color: blue;
                        font-family: 幼圆; font-variant: normal; height: 25px;" valign="middle" background="../../images/treetopbg.jpg"
                        bgcolor="#e8f4ff">
                        工作流初始化权限设置
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                        </asp:CheckBoxList></td>
                </tr>
            </table>
        </div>
        <div align="center">
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" /></div>
    </form>
</body>
</html>
