<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Style_worklog.aspx.cs"
    Inherits="Stoke.USL.Staff.Style_worklog" %>

<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>style_gzrz</title>
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
                    <td colspan="6" align="center" style="font-weight: bold; font-size: larger; color: blue;
                        font-family: 幼圆; font-variant: normal; height: 25px;" valign="middle" background="../../images/treetopbg.jpg"
                        bgcolor="#e8f4ff">
                        工作日志
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        姓名</td>
                    <td>
                        <asp:TextBox ID="a" runat="server" Enabled="False"></asp:TextBox></td>
                    <td style="text-align: center">
                        部门</td>
                    <td><asp:DropDownList ID="b" runat="server" Enabled="False" Width="120px"></asp:DropDownList></td>
                    <td style="text-align: center">
                        日期</td>
                    <td><asp:TextBox id="c" runat="server" Enabled="False" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd'})"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        今日工作</td>
                    <td colspan="5"><asp:TextBox id="d" runat="server" TextMode="MultiLine" Enabled="False" Height="70px" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        明日计划</td>
                    <td colspan="5"><asp:TextBox id="e" runat="server" TextMode="MultiLine" Enabled="False" Height="70px" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                         本周工作</td>
                    <td colspan="5"><asp:TextBox id="h" runat="server" TextMode="MultiLine" Enabled="False" Height="70px" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        下周计划</td>
                    <td colspan="5"><asp:TextBox id="i" runat="server" TextMode="MultiLine" Enabled="False" Height="70px" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        主管意见</td>
                    <td colspan="5"><asp:TextBox id="f" runat="server" TextMode="MultiLine" Enabled="False" Height="70px" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        备 &nbsp; &nbsp;&nbsp; 注</td>
                    <td colspan="5"><asp:TextBox id="g" runat="server" TextMode="MultiLine" Enabled="False" Height="70px" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        紧急程度</td>
                    <td colspan="5">
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
