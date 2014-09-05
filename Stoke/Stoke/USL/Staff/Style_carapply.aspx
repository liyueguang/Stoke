<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Style_carapply.aspx.cs"
    Inherits="Stoke.USL.Staff.Style_carapply" %>

<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>style_casp</title>
    <meta content="False" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../css/css.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>

</head>
<body class="body1">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td colspan="8" align="center" style="font-weight: bold; font-size: larger; color: blue;
                        font-family: 幼圆; font-variant: normal; height: 25px;" valign="middle" background="../../images/treetopbg.jpg"
                        bgcolor="#e8f4ff">
                        公车请单
                    </td>
                </tr>
                <tr>
                    <td width="10%" style="text-align: center">
                        姓名</td>
                    <td width="15%">
                        <asp:TextBox ID="a" runat="server" Enabled="False" Width="80%"></asp:TextBox></td>
                    <td width="10%" style="text-align: center">
                        部门</td>
                    <td width="15%">
                        <asp:DropDownList runat="server" ID="b" Enabled="False" Width="80%">
                        </asp:DropDownList></td>
                    <td width="10%" style="text-align: center">
                        职位</td>
                    <td width="15%">
                        <asp:DropDownList runat="server" ID="c" Enabled="False" Width="80%">
                        </asp:DropDownList></td>
                    <td width="10%" style="text-align: center">
                        申请日</td>
                    <td width="15%">
                        <asp:TextBox ID="d" runat="server" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd'})"
                            Enabled="False" Width="80%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        预定出发时间</td>
                    <td colspan="6">
                        <asp:TextBox ID="e" runat="server" Enabled="False" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm'})" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        预定返回时间</td>
                    <td colspan="6">
                        <asp:TextBox ID="f" runat="server" Enabled="False" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd HH:mm'})" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        事由</td>
                    <td colspan="6">
                        <asp:TextBox ID="g" runat="server" Enabled="False" Width="95%" TextMode="MultiLine" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        出发地</td>
                    <td colspan="6">
                        <asp:TextBox ID="h" runat="server" Enabled="False" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        目的地</td>
                    <td colspan="6">
                        <asp:TextBox ID="i" runat="server" Enabled="False" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        部门意见</td>
                    <td colspan="6">
                        <asp:RadioButtonList ID="j" runat="server" Enabled="false" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">同意</asp:ListItem>
                            <asp:ListItem Value="1">不同意（予以备注）</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        部门备注</td>
                    <td colspan="6">
                        <asp:TextBox ID="k" runat="server" Enabled="False" Width="95%" TextMode="MultiLine" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        公司意见</td>
                    <td colspan="6">
                        <asp:TextBox ID="l" runat="server" Enabled="False" Width="95%" TextMode="MultiLine" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        紧急程度</td>
                    <td colspan="6">
                        <uc1:EmergencySelector ID="EmergencySelector1" runat="server" Enabled="false" />
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <asp:Button ID="submitBtn" runat="server" Text="处理" OnClick="submitBtn_Click" />
            <asp:Button ID="saveBtn" runat="server" Text="保存" OnClick="saveBtn_Click" />
            <asp:Button ID="backBtn" runat="server" Text="返回" OnClick="backBtn_Click" /></div>
    </form>
</body>
</html>
