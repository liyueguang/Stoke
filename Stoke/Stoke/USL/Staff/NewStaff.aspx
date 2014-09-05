<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NewStaff.aspx.cs" Inherits="Stoke.USL.Staff.NewStaff" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>NewStaff</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../css/sysstyle.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/css.css" type="text/css" rel="stylesheet">
    <style type="text/css">.STYLE1 { BORDER-RIGHT: #aaaaaa 0px dashed; BORDER-TOP: #aaaaaa 0px dashed; FONT-WEIGHT: bold; FONT-SIZE: 14px; BORDER-LEFT: #aaaaaa 0px dashed; COLOR: #4b82b4; BORDER-BOTTOM: #aaaaaa 2px dashed; HEIGHT: 26px; BACKGROUND-COLOR: #f3f5fa; TEXT-ALIGN: center }
		</style>
    <style>.td { FONT-SIZE: 14px; COLOR: #0000ff }
		</style>

    <script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>

    <script language="javascript">
		function htzzsjChange()
		{
			if (document.getElementById('htlb').options[document.getElementById('htlb').options.selectedIndex].value == '无固定期限')
			{
				document.getElementById('htzzsj').value = '无固定';
			}
		}
		function htlbChange()
		{
			if (document.getElementById('htlb').options[document.getElementById('htlb').options.selectedIndex].value == '无固定期限')
			{
				document.getElementById('htzzsj').value = '无固定';
			}
			else
			{
				if (document.getElementById('htzzsj').value == '无固定')
					document.getElementById('htzzsj').value = '';
			}
		}

    </script>

</head>
<body class="body1" leftmargin="0" topmargin="0">
    <form id="NewStaff" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr height="30">
                <td style="font-weight: bold; font-size: larger; color: blue; font-family: 幼圆; font-variant: normal"
                    align="center" background="../../images/treetopbg.jpg" bgcolor="#e8f4ff">
                    职工信息
                    <asp:TextBox ID="txtYwm" Width="140px" runat="server" BorderStyle="None" Visible="False"></asp:TextBox><font
                        face="宋体">
                        <asp:TextBox ID="txtCym" Width="140px" runat="server" BorderStyle="None" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="shi" Width="140px" runat="server" BorderStyle="None" Visible="False"></asp:TextBox></font></td>
            </tr>
        </table>
        <table class="gbtext" bordercolor="#93bee2" cellspacing="0" cellpadding="0" width="100%"
            border="1">
            <tr>
                <td id="TD1" align="right" colspan="6" runat="server">
                    <asp:Button ID="btn_xg" runat="server" CausesValidation="False" CssClass="input4"
                        Width="60px" Text="修改"></asp:Button></td>
            </tr>
            <tr bgcolor="#f3f5fa">
                <td align="left" width="20%" height="30">
                    职工姓名<font face="宋体" color="#ff0066">*</font></td>
                <td height="30">
                    <asp:TextBox ID="txtRealName" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                <td align="left" width="30%" height="30">
                    职工编号<font face="宋体" color="#ff0066">*</font></td>
                <td height="30">
                    <asp:TextBox ID="zh" Width="140px" BorderStyle="None" runat="server"></asp:TextBox><font
                        face="宋体" color="#ff0000"></font></td>
                <td align="left" width="20%" height="30">
                    <font face="宋体">
                        <asp:RegularExpressionValidator ID="check_zgbh" ErrorMessage="格式错误" ValidationExpression="[0-9][0-9][0-9][0-9]"
                            ControlToValidate="zh" runat="server"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt_bm" Width="20%" BorderStyle="None" runat="server" Enabled="False"
                            Visible="False"></asp:TextBox></font></td>
                <td align="center" height="30" rowspan="5">
                    <font face="宋体">
                        <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" Visible="False"></asp:Image></font></td>
            </tr>
            <tr bgcolor="#f3f5fa">
                <td align="left" width="20%" height="30">
                    <font face="宋体"><font face="宋体" color="#ff0066"><font color="#000000">用工性质<span style="color: #ff0066">*</span></font></font></font></td>
                <td height="30">
                    <asp:DropDownList ID="ddlPylx" runat="server" Width="140px">
                        <asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
                        <asp:ListItem Value="M">在职人员</asp:ListItem>
                        <asp:ListItem Value="PM">聘管人员</asp:ListItem>
                        <asp:ListItem Value="PW">聘工人员</asp:ListItem>
                        <asp:ListItem Value="FP">返聘人员</asp:ListItem>
                        <asp:ListItem Value="QT">其他人员</asp:ListItem>
                    </asp:DropDownList></td>
                <td align="left" width="20%" height="30">
                    <font face="宋体">性&nbsp;&nbsp;&nbsp; 别</font></td>
                <td height="30">
                    &nbsp;
                    <asp:RadioButton ID="rb_male" Text="男" BorderStyle="None" runat="server" GroupName="rSex"
                        Checked="True"></asp:RadioButton><asp:RadioButton ID="rb_female" Text="女" runat="server"
                            GroupName="rSex" Checked="False"></asp:RadioButton></td>
                <td align="left" width="23%" height="30">
                    <font face="宋体"></font>
                </td>
            </tr>
            <tr bgcolor="#f3f5fa">
                <td align="left" width="20%" height="30">
                    所在部门/项目组<font face="宋体" color="#ff0066">*</font></td>
                <td colspan="3" height="30">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="544px">
                    </asp:DropDownList></td>
                <td height="30" style="text-align: center">
                    <font face="宋体">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Enabled="false" Text="上传头像"
                            Width="88px" /></font></td>
            </tr>
            <!--tr>
					<td align="left" width="20%" height="30">所在项目组</td>
					<td colSpan="2" height="30">&nbsp;<asp:textbox id="txt_xmz" Runat="server" Width="95%"></asp:textbox></td>
					<td colSpan="3" height="30">&nbsp;<asp:dropdownlist id="cboXmz" runat="server" Width="155px"></asp:dropdownlist></td>
				</tr-->
            <tr bgcolor="#f3f5fa">
                <td align="left" width="20%" height="30">
                    所属岗位<font face="宋体" color="#ff0066">*</font></td>
                <td colspan="3" height="30">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="543px">
                    </asp:DropDownList></td>
                <td align="left" width="20%" height="30">
                    <font face="宋体">
                        <asp:Button ID="btn_bm_zw" runat="server" CausesValidation="False" CssClass="input4"
                            Width="60px" Text="职务信息" Visible="False"></asp:Button>
                        <asp:TextBox ID="txt_zw" Width="15%" BorderStyle="None" runat="server" Enabled="False"
                            Visible="False"></asp:TextBox></font></td>
            </tr>
            <tr bgcolor="#f3f5fa">
                <td align="left" width="20%" height="30">
                    <font face="宋体">人员类别</font></td>
                <td height="30">
                    <font face="宋体">
                        <asp:DropDownList ID="rylb" runat="server" Width="140px">
                            <asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
                            <asp:ListItem Value="管理人员">管理人员</asp:ListItem>
                            <asp:ListItem Value="技术人员">技术人员</asp:ListItem>
                            <asp:ListItem Value="操作人员">操作人员</asp:ListItem>
                        </asp:DropDownList></font></td>
                <td align="left" width="20%" height="30">
                    <font face="宋体"><font style="background-color: #f3f5fa">岗位变动时间</font></font></td>
                <td height="30">
                    <asp:TextBox ID="gwbdsj" onfocus="WdatePicker({skin:'simple'})" Width="140px" runat="server"
                        BorderStyle="None"></asp:TextBox></td>
                <td align="left" width="20%" height="30">
                    <font face="宋体">
                        <asp:Button ID="BtnZwChange" runat="server" Text="职位变动情况" Width="86px" CssClass="input4"
                            CausesValidation="False" Visible="False"></asp:Button></font></td>
            </tr>
            <tr bgcolor="#f3f5fa">
                <td align="left" width="20%" bgcolor="#f3f5fa" height="30">
                    <font face="宋体" color="#ff0066"><font style="background-color: #f3f5fa" color="#000000">
                        身份证号 </font>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ValidationExpression="^\d{15}(\d{2}[A-Za-z0-9])?$"
                            ErrorMessage="格式错误" ControlToValidate="sfzh"></asp:RegularExpressionValidator></font></td>
                <td height="30">
                    <asp:TextBox ID="sfzh" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                <td align="left" width="20%" height="30">
                    出生日期<font face="宋体" color="#ff0066">*</font></td>
                <td height="30">
                    <asp:TextBox ID="txtBirthday" onfocus="WdatePicker({skin:'simple'})" Width="140px"
                        BorderStyle="None" runat="server" AutoPostBack="True"></asp:TextBox></td>
                <td align="left" width="20%" height="30">
                    年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;龄</td>
                <td height="30">
                    <asp:TextBox ID="txtAge" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="20%" height="30">
                        民&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 族</td>
                    <td height="30">
                        <asp:TextBox ID="mz" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        籍&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 贯</td>
                    <td height="30">
                        <asp:TextBox ID="jg" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        户口所在地</td>
                    <td height="30">
                        <asp:TextBox ID="hkszd" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="20%" height="30">
                        政治面貌</td>
                    <td height="30">
                        <asp:TextBox ID="zzmm" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        入党派时间</td>
                    <td height="30">
                        <asp:TextBox ID="rdpsj" onfocus="WdatePicker({skin:'simple'})" Width="140px" BorderStyle="None"
                            runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        健康情况</td>
                    <td height="30">
                        <asp:TextBox ID="jkqk" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="20%" height="30">
                        <font style="background-color: #f3f5fa" face="宋体">婚姻状况</font></td>
                    <td height="30">
                        <asp:TextBox ID="hyzk" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font style="background-color: #f3f5fa">参加工作时间</font></font></td>
                    <td height="30">
                        <font face="宋体">
                            <asp:TextBox ID="cjgzsj" onfocus="WdatePicker({skin:'simple'})" Width="140px" BorderStyle="None"
                                runat="server"></asp:TextBox></font></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体">进本单位时间</font></td>
                    <td height="30">
                        <asp:TextBox ID="jbdwsj" onfocus="WdatePicker({skin:'simple'})" Width="140px" BorderStyle="None"
                            runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="20%" height="30">
                        <font face="宋体">职&nbsp;&nbsp;&nbsp;&nbsp;称</font></td>
                    <td height="30">
                        <asp:TextBox ID="zc" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体">职称级别</font></font></td>
                    <td height="30">
                        <font face="宋体">
                            <asp:DropDownList ID="zcjb" runat="server" Width="140px">
                                <asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
                                <asp:ListItem Value="无">无</asp:ListItem>
                                <asp:ListItem Value="初级">初级</asp:ListItem>
                                <asp:ListItem Value="中级">中级</asp:ListItem>
                                <asp:ListItem Value="高级">高级</asp:ListItem>
                            </asp:DropDownList></font></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体">职称认定时间</font></td>
                    <td height="30">
                        <asp:TextBox ID="zcrdsj" onfocus="WdatePicker({skin:'simple'})" Width="140px" BorderStyle="None"
                            runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="20%" height="29" style="height: 29px">
                        <font face="宋体">合同起始时间</font></td>
                    <td height="29" style="height: 29px">
                        <asp:TextBox ID="htqssj" onfocus="WdatePicker({skin:'simple'})" Width="140px" BorderStyle="None"
                            runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="29" style="height: 29px">
                        <font face="宋体"><font face="宋体">合同终止时间</font></font></td>
                    <td height="29" style="height: 29px">
                        <asp:TextBox ID="htzzsj" onfocus="WdatePicker({skin:'simple'})" Width="140px" BorderStyle="None"
                            runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="29" style="height: 29px">
                        <font face="宋体"><font face="宋体">合同类别<span style="color: #ff0066">*</span></font></font></td>
                    <td height="29" style="height: 29px">
                        <font face="宋体">
                            <asp:DropDownList ID="htlb" runat="server" Width="140px">
                                <asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
                                <asp:ListItem Value="固定期限">固定期限</asp:ListItem>
                                <asp:ListItem Value="无固定期限">无固定期限</asp:ListItem>
                                <asp:ListItem Value="劳务合同">劳务合同</asp:ListItem>
                                <asp:ListItem Value="派遣协议">派遣协议</asp:ListItem>
                            </asp:DropDownList></font></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td style="height: 30px" align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体">最高学历<span style="color: #ff0066">*</span></font></font></td>
                    <td style="height: 30px" height="30">
                        <asp:DropDownList ID="ddlZgxl" runat="server" Width="140px">
                            <asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
                            <asp:ListItem Value="博士">博士</asp:ListItem>
                            <asp:ListItem Value="研究生（硕士）">研究生（硕士）</asp:ListItem>
                            <asp:ListItem Value="研究生（双学位）">研究生（双学位）</asp:ListItem>
                            <asp:ListItem Value="研究生（学历）">研究生（学历）</asp:ListItem>
                            <asp:ListItem Value="本科">本科</asp:ListItem>
                            <asp:ListItem Value="大专">大专</asp:ListItem>
                            <asp:ListItem Value="中专">中专</asp:ListItem>
                            <asp:ListItem Value="技校（职高）">技校（职高）</asp:ListItem>
                            <asp:ListItem Value="高中">高中</asp:ListItem>
                            <asp:ListItem Value="初中">初中</asp:ListItem>
                            <asp:ListItem Value="小学">小学</asp:ListItem>
                            <asp:ListItem Value="其它">其它</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="height: 30px" align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体">毕业时间</font></font></font></td>
                    <td style="height: 30px" height="30">
                        <font face="宋体">
                            <asp:TextBox ID="bysj" onfocus="WdatePicker({skin:'simple'})" Width="140px" BorderStyle="None"
                                runat="server"></asp:TextBox></font></td>
                    <td style="height: 30px" align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体">毕业学校</font></font></font></font></td>
                    <td style="height: 30px" height="30">
                        <asp:TextBox ID="byxx" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体">所学专业</font></font></td>
                    <td height="30">
                        <asp:TextBox ID="sxzy" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体">专业类别<span style="color: #ff0066">*</span></font></font></font></td>
                    <td height="30">
                        <font face="宋体">
                            <asp:DropDownList ID="ddlZylb" runat="server" Width="140px">
                                <asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
                                <asp:ListItem Value="结构类">结构类</asp:ListItem>
                                <asp:ListItem Value="电气类">电气类</asp:ListItem>
                                <asp:ListItem Value="机械类">机械类</asp:ListItem>
                                <asp:ListItem Value="理工其他类">理工其他类</asp:ListItem>
                                <asp:ListItem Value="文科类">文科类</asp:ListItem>
                                <asp:ListItem Value="语言类">语言类</asp:ListItem>
                                <asp:ListItem Value="IT类">IT类</asp:ListItem>
                                <asp:ListItem Value="经济类">经济类</asp:ListItem>
                                <asp:ListItem Value="财会类">财会类</asp:ListItem>
                                <asp:ListItem Value="管理类">管理类</asp:ListItem>
                                <asp:ListItem Value="其它类">其它类</asp:ListItem>
                            </asp:DropDownList></font></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体">学习形式</font></font></font></font></td>
                    <td height="30">
                        <asp:TextBox ID="xxxs" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="22%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体">外语语种</font></font></font></td>
                    <td height="30">
                        <asp:TextBox ID="wyyz" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体">外语水平</font></font></td>
                    <td height="30">
                        <asp:TextBox ID="wysp" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体">计算机水平</font></font></td>
                    <td height="30">
                        <asp:TextBox ID="jsjsp" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td style="height: 31px" align="left" width="20%" height="31">
                        <font face="宋体"><font face="宋体">资质认证名称</font></font></td>
                    <td style="height: 31px" height="31">
                        <font face="宋体">
                            <asp:TextBox ID="zzrzmc" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></font></td>
                    <td style="height: 31px" align="left" width="20%" height="31">
                        <font face="宋体">本单位参加培训名称</font></td>
                    <td style="height: 31px" height="31">
                        <asp:TextBox ID="bdwcjpxmc" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td style="height: 31px" align="left" width="20%" height="31">
                        培训协议有效时间</td>
                    <td style="height: 31px" height="31">
                        <asp:TextBox ID="pxxyyxsj" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="20%" height="30">
                        <font style="background-color: #f3f5fa" face="宋体">家庭住址</font></td>
                    <td height="30">
                        <font face="宋体">
                            <asp:TextBox ID="jtzz" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></font></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font style="background-color: #f3f5fa">邮编
                            <asp:RegularExpressionValidator ID="checkyb" runat="server" ValidationExpression="^[1-9]\d{5}$"
                                ErrorMessage="格式错误" ControlToValidate="txtYb" Display="Dynamic"></asp:RegularExpressionValidator></font></font></td>
                    <td height="30">
                        <asp:TextBox ID="txtYb" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体"><font style="background-color: #f3f5fa">
                            住宅电话</font>
                            <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" ValidationExpression="^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$"
                                ErrorMessage="格式错误" ControlToValidate="txtPhone"></asp:RegularExpressionValidator></font></font></font></td>
                    <td height="30">
                        <asp:TextBox ID="txtPhone" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                </tr>
                <tr bgcolor="#f3f5fa">
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font
                            face="宋体"><font face="宋体">移动电话1
                                <asp:RegularExpressionValidator ID="checkmobile" runat="server" ValidationExpression="^(\+86)?(1[0-9]{10})$"
                                    ErrorMessage="格式错误" ControlToValidate="txtMobile"></asp:RegularExpressionValidator></font></font></font></font></font></font></font></td>
                    <td height="30">
                        <font face="宋体">
                            <asp:TextBox ID="txtMobile" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></font></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font
                            face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体">
                                <font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体">电子邮件
                                    <asp:RegularExpressionValidator ID="checkmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage="格式错误" ControlToValidate="txtEmail" Display="Dynamic"></asp:RegularExpressionValidator></font></font></font></font></font></font></font></font></font></font></font></font></font></font></font></td>
                    <td height="30">
                        <font face="宋体">
                            <asp:TextBox ID="txtEmail" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></font></td>
                    <td align="left" width="20%" height="30">
                        <font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font
                            face="宋体"><font face="宋体"><font face="宋体">紧急联系人姓名</font></font></font></font></font></font></font></font></td>
                    <td height="30">
                        <asp:TextBox ID="jjlxrxm" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 29px" align="left" width="20%" height="29">
                        <font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体"><font face="宋体">移动电话2</font></font></font></font></font></td>
                    <td style="height: 29px" height="29">
                        <asp:TextBox ID="jjlxrdh" Width="140px" BorderStyle="None" runat="server"></asp:TextBox></td>
                    <td style="height: 29px" align="left" width="20%" height="29">
                        <font face="宋体">离职原因</font></td>
                    <td style="height: 29px" height="29">
                        <font face="宋体">
                            <asp:TextBox ID="txtLzyy" Width="140px" runat="server" BorderStyle="None"></asp:TextBox></font></td>
                    <td style="height: 29px" align="left" width="20%" height="29">
                        <font face="宋体">离职时间</font></td>
                    <td style="height: 29px" height="29">
                        <font face="宋体">
                            <asp:TextBox ID="txtLzsj" onfocus="WdatePicker({skin:'simple'})" Width="140px" runat="server"
                                BorderStyle="None"></asp:TextBox></font></td>
                </tr>
                <tr runat="server" id="roleTr">
                    <td colspan="6" height="29" style="height: 29px">
                        <div class="ManageLine" onmouseover="this.className='ManageLine-hover'" onmouseout="this.className='ManageLine'">
                            <br />
                            <span class="ManageLineTitle">用户角色：</span><span class="ManageLineInput" style="width: 207px">
                                <span class="ManageLineDesc" style="color: red">用户已选角色</span>&nbsp;<br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:ListBox ID="roleLbx" runat="server" Height="200px" Width="180px"></asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span><span class="ManageLineInput" style="width: 115px">
                                <br />
                                <br />
                                <span class="ManageLineDesc" style="color: red">为用户添加角色</span><br />
                                &nbsp; &nbsp;&nbsp;&nbsp;
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        &nbsp; &nbsp;
                                        <asp:Button ID="roleAddBtn" runat="server" CausesValidation="True" CssClass="btn12"
                                            OnClick="roleAddBtn_Click" Text="<<    <<" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                &nbsp;
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        &nbsp; &nbsp;
                                        <asp:Button ID="roleDelBtn" runat="server" CausesValidation="True" CssClass="btn12"
                                            OnClick="roleDelBtn_Click" Text=">>    >>" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <span class="ManageLineDesc" style="color: red">删除已选角色</span><br />
                                &nbsp;<br />
                                <br />
                                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                                <br />
                            </span><span class="ManageLineInput" style="color: red"><span class="ManageLineDesc"
                                style="color: red">候选角色</span>&nbsp;<br />
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:ListBox ID="CandidateRoleLbx" runat="server" Height="200px" Width="180px"></asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                            <div class="clear">
                            </div>
                        </div>
                    </td>
                </tr>
                <tr runat="server" id="pwdTr">
                    <td align="left" height="29" style="height: 29px" width="20%">
                        用户密码<span style="color: #ff0066">*</span></td>
                    <td height="29" style="height: 29px">
                        <asp:TextBox ID="password" runat="server" BorderStyle="None" Width="140px" TextMode="Password"></asp:TextBox></td>
                    <td align="left" height="29" style="height: 29px" width="20%">
                        密码确认<span style="color: #ff0066">*</span></td>
                    <td height="29" style="height: 29px">
                        <asp:TextBox ID="passwordConfirm" runat="server" BorderStyle="None" TextMode="Password"
                            Width="140px"></asp:TextBox></td>
                    <td align="left" height="29" style="height: 29px" width="20%">
                    </td>
                    <td height="29" style="height: 29px">
                    </td>
                </tr>
                <tr>
                    <td align="left" width="20%" height="30">
                        备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                    <td colspan="5" height="30">
                        <font face="宋体">
                            <asp:TextBox ID="bz" Width="100%" BorderStyle="None" runat="server" TextMode="MultiLine"></asp:TextBox></font></td>
                </tr>
                <tr>
                    <td align="center" colspan="6" height="35">
                        <font face="宋体">
                            <asp:Button ID="cmdSubmit" runat="server" CssClass="input4" Width="60px" Text="确定"
                                Height="20px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="cmdBack" runat="server" CausesValidation="False" CssClass="input4"
                                Width="60px" Text="返回" Height="20px"></asp:Button></font></td>
                </tr>
        </table>
        <div id="doing" runat="server" visible="false" style="z-index: 12000; left: 0px;
            width: 100%; cursor: wait; position: absolute; top: 0px; height: 1000px; background-color: #f9fff6;
            filter: alpha(Opacity=75); opacity: 0.8;">
        </div>
        <div id="topwindow" runat="server" visible="false" style="position: absolute;
            height: auto; text-align: center; vertical-align: middle; left: 30px; top: 80px;
            z-index: 15000;">
            <div style="padding: 3px 15px 3px 15px; text-align: left; vertical-align: middle;">

                <script src="../../js/jquery.min.js"></script>

                <script src="../../js/jquery.Jcrop.js"></script>

                <script type="text/javascript">

                  jQuery(function($){

                    // Create variables (in this scope) to hold the API and image size
                    var jcrop_api,
                        boundx,
                        boundy,

                        // Grab some information about the preview pane
                        $preview = $('#preview-pane'),
                        $pcnt = $('#preview-pane .preview-container'),
                        $pimg = $('#preview-pane .preview-container img'),

                        xsize = $pcnt.width(),
                        ysize = $pcnt.height();

                    //console.log('init',[xsize,ysize]);

                    $('#target').Jcrop({
                      onChange: updatePreview,
                      onSelect: updatePreview,
                      aspectRatio: 1
                    },function(){
                      // Use the API to get the real image size
                      var bounds = this.getBounds();
                      boundx = bounds[0];
                      boundy = bounds[1];
                      // Store the API in the jcrop_api variable
                      jcrop_api = this;

                      // Move the preview into the jcrop container for css positioning
                      $preview.appendTo(jcrop_api.ui.holder);
                    });

                    function updatePreview(c)
                    {
                      if (parseInt(c.w) > 0)
                      {

                        var rx = xsize / c.w;
                        var ry = ysize / c.h;

                        $pimg.css({
                          width: Math.round(rx * boundx) + 'px',
                          height: Math.round(ry * boundy) + 'px',
                          marginLeft: '-' + Math.round(rx * c.x) + 'px',
                          marginTop: '-' + Math.round(ry * c.y) + 'px'
                        });
                      }
                      $('#<%= x1.ClientID %>').val(c.x);
                      $('#<%= y1.ClientID %>').val(c.y);
                      $('#<%= x2.ClientID %>').val(c.x2);
                      $('#<%= y2.ClientID %>').val(c.y2);
                      $('#<%= Iwidth.ClientID %>').val(c.w);
                      $('#<%= Iheight.ClientID %>').val(c.h);
                    };

                  });


                </script>

                <link rel="stylesheet" href="../../css/main.css" type="text/css" />
                <link rel="stylesheet" href="../../css/pic.css" type="text/css" />
                <link rel="stylesheet" href="../../css/jquery.Jcrop.css" type="text/css" />
                <style type="text/css">

                    /* Apply these styles only when #preview-pane has
                       been placed within the Jcrop widget */
                    .jcrop-holder #preview-pane {
                      display: block;
                      position: absolute;
                      z-index: 2000;
                      top: 10px;
                      right: -300px;
                      padding: 6px;
                      border: 1px rgba(0,0,0,.4) solid;
                      background-color: white;

                      -webkit-border-radius: 6px;
                      -moz-border-radius: 6px;
                      border-radius: 6px;

                      -webkit-box-shadow: 1px 1px 5px 2px rgba(0, 0, 0, 0.2);
                      -moz-box-shadow: 1px 1px 5px 2px rgba(0, 0, 0, 0.2);
                      box-shadow: 1px 1px 5px 2px rgba(0, 0, 0, 0.2);
                    }

                    /* The Javascript code will set the aspect ratio of the crop
                       area based on the size of the thumbnail preview,
                       specified here */
                    #preview-pane .preview-container {
                      width: 200px;
                      height: 200px;
                      overflow: hidden;
                    }
                    
                    .jcrop-holder{
                        width:900px;                        
                    }
                    
                </style>
                <div class="container" style="width: 920px;">
                    <div class="row">
                        <div class="span12" style="margin-left:0px;">
                            <div class="jc-demo-box">
                                <div class="page-header">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<asp:Button ID="Button2"
                                        runat="server" Text="上传" OnClick="Button2_Click" />
                                </div>
                                <img src="<%= ImageUrl %>" id="target" alt="[Jcrop Example]" height="300px" />
                                <div id="preview-pane">
                                    <div class="preview-container">
                                        <img src="<%= ImageUrl %>" class="jcrop-preview" alt="Preview" />
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="text-align: center;">
                    <asp:Button runat="server" ID="uploadBtn" Text="确定" OnClick="uploadBtn_Click" /></div>
                <div style="display: none;">
                    <asp:TextBox ID="x1" runat="server"></asp:TextBox>
                    <asp:TextBox ID="y1" runat="server"></asp:TextBox>
                    <asp:TextBox ID="x2" runat="server"></asp:TextBox>
                    <asp:TextBox ID="y2" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Iwidth" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Iheight" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="text-align: center; display: none;">
                <asp:Button runat="server" ID="closeBtn" Text="关闭" OnClick="closeBtn_Click" /></div>
        </div>
    </form>
</body>
</html>
