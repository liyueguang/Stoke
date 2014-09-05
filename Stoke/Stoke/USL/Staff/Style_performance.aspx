<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Style_performance.aspx.cs"
    Inherits="Stoke.USL.Staff.Style_performance" %>

<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>style_casp</title>
    <meta content="False" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../css/css.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function change_zp()
        {
            var val1 = parseInt(document.getElementById("<%= e.ClientID %>").value);
            var val2 = parseInt(document.getElementById("<%= i.ClientID %>").value);
            var val3 = parseInt(document.getElementById("<%= m.ClientID %>").value);
            var val4 = parseInt(document.getElementById("<%= q.ClientID %>").value);
            var val5 = parseInt(document.getElementById("<%= u.ClientID %>").value);
            var val6 = parseInt(document.getElementById("<%= y.ClientID %>").value); 
            document.getElementById("<%= c1.ClientID %>").value = val1 + val2 + val3 + val4 + val5 + val6;
        }
        function change_bm()
        {
            var val1 = parseInt(document.getElementById("<%= f.ClientID %>").value);
            var val2 = parseInt(document.getElementById("<%= j.ClientID %>").value);
            var val3 = parseInt(document.getElementById("<%= n.ClientID %>").value);
            var val4 = parseInt(document.getElementById("<%= r.ClientID %>").value);
            var val5 = parseInt(document.getElementById("<%= v.ClientID %>").value);
            var val6 = parseInt(document.getElementById("<%= z.ClientID %>").value); 
            document.getElementById("<%= d1.ClientID %>").value = val1 + val2 + val3 + val4 + val5 + val6;
        }
        function change_fg()
        {
            var val1 = parseInt(document.getElementById("<%= g.ClientID %>").value);
            var val2 = parseInt(document.getElementById("<%= k.ClientID %>").value);
            var val3 = parseInt(document.getElementById("<%= o.ClientID %>").value);
            var val4 = parseInt(document.getElementById("<%= s.ClientID %>").value);
            var val5 = parseInt(document.getElementById("<%= w.ClientID %>").value);
            var val6 = parseInt(document.getElementById("<%= a1.ClientID %>").value); 
            document.getElementById("<%= e1.ClientID %>").value = val1 + val2 + val3 + val4 + val5 + val6;
        }
        function change_zjl()
        {
            var val1 = parseInt(document.getElementById("<%= h.ClientID %>").value);
            var val2 = parseInt(document.getElementById("<%= l.ClientID %>").value);
            var val3 = parseInt(document.getElementById("<%= p.ClientID %>").value);
            var val4 = parseInt(document.getElementById("<%= t.ClientID %>").value);
            var val5 = parseInt(document.getElementById("<%= x.ClientID %>").value);
            var val6 = parseInt(document.getElementById("<%= b1.ClientID %>").value); 
            document.getElementById("<%= f1.ClientID %>").value = val1 + val2 + val3 + val4 + val5 + val6;
        }
    </script>
</head>
<body class="body1">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td colspan="8" align="center" style="font-weight: bold; font-size: larger; color: blue;
                        font-family: 幼圆; font-variant: normal; height: 25px;" valign="middle" background="../../images/treetopbg.jpg"
                        bgcolor="#e8f4ff">
                        绩效考核表
                    </td>
                </tr>
                <tr>
                    <td width="15%" style="text-align: center">
                        被考核人</td>
                    <td width="15%">
                        <asp:TextBox ID="a" runat="server" Enabled="False"></asp:TextBox></td>
                    <td width="10%" style="text-align: center">
                        部门</td>
                    <td width="12%" style="text-align: center">
                        <asp:DropDownList runat="server" ID="b" Enabled="False">
                        </asp:DropDownList></td>
                    <td width="12%" style="text-align: center">
                        职位</td>
                    <td width="12%" style="text-align: center">
                        <asp:DropDownList runat="server" ID="c" Enabled="False">
                        </asp:DropDownList></td>
                    <td width="12%" style="text-align: center">
                        考核日期</td>
                    <td width="12%">
                        <asp:TextBox ID="d" runat="server" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy-MM-dd'})"
                            Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        项目</td>
                    <td colspan="2">
                        考核项目</td>
                    <td style="text-align: center">
                        标准分</td>
                    <td style="text-align: center">
                        自评</td>
                    <td style="text-align: center">
                        部门总监</td>
                    <td style="text-align: center">
                        助理总裁</td>
                    <td style="text-align: center">
                        总经理</td>
                </tr>
                <tr>
                    <td rowspan="3" style="text-align: center">
                        重要任务（45%）</td>
                    <td colspan="2">
                        总经理办公会部署任务</td>
                    <td style="text-align: center">
                        15分</td>
                    <td style="text-align: center">
                        <asp:DropDownList ID="e" runat="server" Enabled="false" onchange="change_zp()" width="60px">
                            <asp:ListItem Value="0">0分</asp:ListItem>
                            <asp:ListItem Value="1">1分</asp:ListItem>
                            <asp:ListItem Value="2">2分</asp:ListItem>
                            <asp:ListItem Value="3">3分</asp:ListItem>
                            <asp:ListItem Value="4">4分</asp:ListItem>
                            <asp:ListItem Value="5">5分</asp:ListItem>
                            <asp:ListItem Value="6">6分</asp:ListItem>
                            <asp:ListItem Value="7">7分</asp:ListItem>
                            <asp:ListItem Value="8">8分</asp:ListItem>
                            <asp:ListItem Value="9">9分</asp:ListItem>
                            <asp:ListItem Value="10">10分</asp:ListItem>
                            <asp:ListItem Value="11">11分</asp:ListItem>
                            <asp:ListItem Value="12">12分</asp:ListItem>
                            <asp:ListItem Value="13">13分</asp:ListItem>
                            <asp:ListItem Value="14">14分</asp:ListItem>
                            <asp:ListItem Value="15">15分</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="f" runat="server" Enabled="false" onchange="change_bm()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="g" runat="server" Enabled="false" onchange="change_fg()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="h" runat="server" Enabled="false" onchange="change_zjl()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">
                        专项工作方案</td>
                    <td style="text-align: center">
                        15分</td>
                    <td style="text-align: center"><asp:DropDownList ID="i" runat="server" Enabled="false" onchange="change_zp()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="j" runat="server" Enabled="false" onchange="change_bm()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="k" runat="server" Enabled="false" onchange="change_fg()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="l" runat="server" Enabled="false" onchange="change_zjl()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">
                        批办重要事项</td>
                    <td style="text-align: center">
                        15分</td>
                    <td style="text-align: center"><asp:DropDownList ID="m" runat="server" Enabled="false" onchange="change_zp()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="n" runat="server" Enabled="false" onchange="change_bm()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="o" runat="server" Enabled="false" onchange="change_fg()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="p" runat="server" Enabled="false" onchange="change_zjl()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        岗位职责（45%）</td>
                    <td colspan="2">
                        具体岗位职责中描述的相关工作内容</td>
                    <td style="text-align: center">
                        45分</td>
                    <td style="text-align: center"><asp:DropDownList ID="q" runat="server" Enabled="false" onchange="change_zp()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                        <asp:ListItem Value="16">16分</asp:ListItem>
                        <asp:ListItem Value="17">17分</asp:ListItem>
                        <asp:ListItem Value="18">18分</asp:ListItem>
                        <asp:ListItem Value="19">19分</asp:ListItem>
                        <asp:ListItem Value="20">20分</asp:ListItem>
                        <asp:ListItem Value="21">21分</asp:ListItem>
                        <asp:ListItem Value="22">22分</asp:ListItem>
                        <asp:ListItem Value="23">23分</asp:ListItem>
                        <asp:ListItem Value="24">24分</asp:ListItem>
                        <asp:ListItem Value="25">25分</asp:ListItem>
                        <asp:ListItem Value="26">26分</asp:ListItem>
                        <asp:ListItem Value="27">27分</asp:ListItem>
                        <asp:ListItem Value="28">28分</asp:ListItem>
                        <asp:ListItem Value="29">29分</asp:ListItem>
                        <asp:ListItem Value="30">30分</asp:ListItem>
                        <asp:ListItem Value="31">31分</asp:ListItem>
                        <asp:ListItem Value="32">32分</asp:ListItem>
                        <asp:ListItem Value="33">33分</asp:ListItem>
                        <asp:ListItem Value="34">34分</asp:ListItem>
                        <asp:ListItem Value="35">35分</asp:ListItem>
                        <asp:ListItem Value="36">36分</asp:ListItem>
                        <asp:ListItem Value="37">37分</asp:ListItem>
                        <asp:ListItem Value="38">38分</asp:ListItem>
                        <asp:ListItem Value="39">39分</asp:ListItem>
                        <asp:ListItem Value="40">40分</asp:ListItem>
                        <asp:ListItem Value="41">41分</asp:ListItem>
                        <asp:ListItem Value="42">42分</asp:ListItem>
                        <asp:ListItem Value="43">43分</asp:ListItem>
                        <asp:ListItem Value="44">44分</asp:ListItem>
                        <asp:ListItem Value="45">45分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="r" runat="server" Enabled="false" onchange="change_bm()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                        <asp:ListItem Value="16">16分</asp:ListItem>
                        <asp:ListItem Value="17">17分</asp:ListItem>
                        <asp:ListItem Value="18">18分</asp:ListItem>
                        <asp:ListItem Value="19">19分</asp:ListItem>
                        <asp:ListItem Value="20">20分</asp:ListItem>
                        <asp:ListItem Value="21">21分</asp:ListItem>
                        <asp:ListItem Value="22">22分</asp:ListItem>
                        <asp:ListItem Value="23">23分</asp:ListItem>
                        <asp:ListItem Value="24">24分</asp:ListItem>
                        <asp:ListItem Value="25">25分</asp:ListItem>
                        <asp:ListItem Value="26">26分</asp:ListItem>
                        <asp:ListItem Value="27">27分</asp:ListItem>
                        <asp:ListItem Value="28">28分</asp:ListItem>
                        <asp:ListItem Value="29">29分</asp:ListItem>
                        <asp:ListItem Value="30">30分</asp:ListItem>
                        <asp:ListItem Value="31">31分</asp:ListItem>
                        <asp:ListItem Value="32">32分</asp:ListItem>
                        <asp:ListItem Value="33">33分</asp:ListItem>
                        <asp:ListItem Value="34">34分</asp:ListItem>
                        <asp:ListItem Value="35">35分</asp:ListItem>
                        <asp:ListItem Value="36">36分</asp:ListItem>
                        <asp:ListItem Value="37">37分</asp:ListItem>
                        <asp:ListItem Value="38">38分</asp:ListItem>
                        <asp:ListItem Value="39">39分</asp:ListItem>
                        <asp:ListItem Value="40">40分</asp:ListItem>
                        <asp:ListItem Value="41">41分</asp:ListItem>
                        <asp:ListItem Value="42">42分</asp:ListItem>
                        <asp:ListItem Value="43">43分</asp:ListItem>
                        <asp:ListItem Value="44">44分</asp:ListItem>
                        <asp:ListItem Value="45">45分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="s" runat="server" Enabled="false" onchange="change_fg()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                        <asp:ListItem Value="16">16分</asp:ListItem>
                        <asp:ListItem Value="17">17分</asp:ListItem>
                        <asp:ListItem Value="18">18分</asp:ListItem>
                        <asp:ListItem Value="19">19分</asp:ListItem>
                        <asp:ListItem Value="20">20分</asp:ListItem>
                        <asp:ListItem Value="21">21分</asp:ListItem>
                        <asp:ListItem Value="22">22分</asp:ListItem>
                        <asp:ListItem Value="23">23分</asp:ListItem>
                        <asp:ListItem Value="24">24分</asp:ListItem>
                        <asp:ListItem Value="25">25分</asp:ListItem>
                        <asp:ListItem Value="26">26分</asp:ListItem>
                        <asp:ListItem Value="27">27分</asp:ListItem>
                        <asp:ListItem Value="28">28分</asp:ListItem>
                        <asp:ListItem Value="29">29分</asp:ListItem>
                        <asp:ListItem Value="30">30分</asp:ListItem>
                        <asp:ListItem Value="31">31分</asp:ListItem>
                        <asp:ListItem Value="32">32分</asp:ListItem>
                        <asp:ListItem Value="33">33分</asp:ListItem>
                        <asp:ListItem Value="34">34分</asp:ListItem>
                        <asp:ListItem Value="35">35分</asp:ListItem>
                        <asp:ListItem Value="36">36分</asp:ListItem>
                        <asp:ListItem Value="37">37分</asp:ListItem>
                        <asp:ListItem Value="38">38分</asp:ListItem>
                        <asp:ListItem Value="39">39分</asp:ListItem>
                        <asp:ListItem Value="40">40分</asp:ListItem>
                        <asp:ListItem Value="41">41分</asp:ListItem>
                        <asp:ListItem Value="42">42分</asp:ListItem>
                        <asp:ListItem Value="43">43分</asp:ListItem>
                        <asp:ListItem Value="44">44分</asp:ListItem>
                        <asp:ListItem Value="45">45分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="t" runat="server" Enabled="false" onchange="change_zjl()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                        <asp:ListItem Value="6">6分</asp:ListItem>
                        <asp:ListItem Value="7">7分</asp:ListItem>
                        <asp:ListItem Value="8">8分</asp:ListItem>
                        <asp:ListItem Value="9">9分</asp:ListItem>
                        <asp:ListItem Value="10">10分</asp:ListItem>
                        <asp:ListItem Value="11">11分</asp:ListItem>
                        <asp:ListItem Value="12">12分</asp:ListItem>
                        <asp:ListItem Value="13">13分</asp:ListItem>
                        <asp:ListItem Value="14">14分</asp:ListItem>
                        <asp:ListItem Value="15">15分</asp:ListItem>
                        <asp:ListItem Value="16">16分</asp:ListItem>
                        <asp:ListItem Value="17">17分</asp:ListItem>
                        <asp:ListItem Value="18">18分</asp:ListItem>
                        <asp:ListItem Value="19">19分</asp:ListItem>
                        <asp:ListItem Value="20">20分</asp:ListItem>
                        <asp:ListItem Value="21">21分</asp:ListItem>
                        <asp:ListItem Value="22">22分</asp:ListItem>
                        <asp:ListItem Value="23">23分</asp:ListItem>
                        <asp:ListItem Value="24">24分</asp:ListItem>
                        <asp:ListItem Value="25">25分</asp:ListItem>
                        <asp:ListItem Value="26">26分</asp:ListItem>
                        <asp:ListItem Value="27">27分</asp:ListItem>
                        <asp:ListItem Value="28">28分</asp:ListItem>
                        <asp:ListItem Value="29">29分</asp:ListItem>
                        <asp:ListItem Value="30">30分</asp:ListItem>
                        <asp:ListItem Value="31">31分</asp:ListItem>
                        <asp:ListItem Value="32">32分</asp:ListItem>
                        <asp:ListItem Value="33">33分</asp:ListItem>
                        <asp:ListItem Value="34">34分</asp:ListItem>
                        <asp:ListItem Value="35">35分</asp:ListItem>
                        <asp:ListItem Value="36">36分</asp:ListItem>
                        <asp:ListItem Value="37">37分</asp:ListItem>
                        <asp:ListItem Value="38">38分</asp:ListItem>
                        <asp:ListItem Value="39">39分</asp:ListItem>
                        <asp:ListItem Value="40">40分</asp:ListItem>
                        <asp:ListItem Value="41">41分</asp:ListItem>
                        <asp:ListItem Value="42">42分</asp:ListItem>
                        <asp:ListItem Value="43">43分</asp:ListItem>
                        <asp:ListItem Value="44">44分</asp:ListItem>
                        <asp:ListItem Value="45">45分</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td rowspan="2" style="text-align: center">
                        综合考评（10%）</td>
                    <td colspan="2">
                        遵守《员工奖惩管理办法》，没有小过处罚</td>
                    <td style="text-align: center">
                        5分</td>
                    <td style="text-align: center"><asp:DropDownList ID="u" runat="server" Enabled="false" onchange="change_zp()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="v" runat="server" Enabled="false" onchange="change_bm()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="w" runat="server" Enabled="false" onchange="change_fg()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="x" runat="server" Enabled="false" onchange="change_zjl()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">
                        遵守《员工奖惩管理办法》，没有大过处罚</td>
                    <td style="text-align: center">
                        5分</td>
                    <td style="text-align: center"><asp:DropDownList ID="y" runat="server" Enabled="false" onchange="change_zp()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="z" runat="server" Enabled="false" onchange="change_bm()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="a1" runat="server" Enabled="false" onchange="change_fg()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="text-align: center"><asp:DropDownList ID="b1" runat="server" Enabled="false" onchange="change_zjl()" width="60px">
                        <asp:ListItem Value="0">0分</asp:ListItem>
                        <asp:ListItem Value="1">1分</asp:ListItem>
                        <asp:ListItem Value="2">2分</asp:ListItem>
                        <asp:ListItem Value="3">3分</asp:ListItem>
                        <asp:ListItem Value="4">4分</asp:ListItem>
                        <asp:ListItem Value="5">5分</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        通过以上各项评分，该员工的综合得分是：</td>
                    <td style="text-align: center">
                        100分</td>
                    <td style="text-align: center">
                        <asp:TextBox ID="c1" runat="server" Enabled="False" width="60px"></asp:TextBox>分</td>
                    <td style="text-align: center">
                        <asp:TextBox ID="d1" runat="server" Enabled="False" width="60px"></asp:TextBox>分</td>
                    <td style="text-align: center">
                        <asp:TextBox ID="e1" runat="server" Enabled="False" width="60px"></asp:TextBox>分</td>
                    <td style="text-align: center">
                        <asp:TextBox ID="f1" runat="server" Enabled="False" width="60px"></asp:TextBox>分</td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        员工自我评价与说明：</td>
                    <td colspan="5">
                        <asp:TextBox ID="g1" runat="server" Enabled="False" TextMode="MultiLine" width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        助理总裁评价：</td>
                    <td colspan="5">
                        <asp:TextBox ID="h1" runat="server" Enabled="False" TextMode="MultiLine" width="95%" Height="70px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        总经理评价：</td>
                    <td colspan="5">
                        通过以上各项评分，该员工的综合得分是：<asp:TextBox ID="i1" runat="server" Enabled="False"></asp:TextBox>分</td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        紧急程度：</td>
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
