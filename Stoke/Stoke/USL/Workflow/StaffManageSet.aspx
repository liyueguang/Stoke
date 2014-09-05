<%@ Page Language="C#" AutoEventWireup="true" Codebehind="StaffManageSet.aspx.cs"
    Inherits="Stoke.USL.Workflow.StaffManageSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td colspan="6" align="center" style="font-weight: bold; font-size: larger; color: blue;
                        font-family: 幼圆; font-variant: normal; height: 25px;" valign="middle" background="../../images/treetopbg.jpg"
                        bgcolor="#e8f4ff">
                        人事管理员人员设定
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; text-align: center;">
                        选择部门：
                    </td>
                    <td colspan="5">
                        <asp:DropDownList ID="bmList" runat="server" Width="216px" AutoPostBack="True" OnSelectedIndexChanged="bmList_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px; text-align: center;">
                        选择人员：
                    </td>
                    <td colspan="5">
                        <asp:CheckBoxList ID="ryList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%"></asp:CheckBoxList>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click"/></div>
    </form>
</body>
</html>
