<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageStaff.aspx.cs" Inherits="Stoke.USL.Staff.ManageStaff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageStaff</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
		<style type="text/css">.STYLE1 { BORDER-RIGHT: #aaaaaa 0px dashed; BORDER-TOP: #aaaaaa 0px dashed; FONT-WEIGHT: bold; FONT-SIZE: 14px; BORDER-LEFT: #aaaaaa 0px dashed; COLOR: #4b82b4; BORDER-BOTTOM: #aaaaaa 2px dashed; HEIGHT: 26px; BACKGROUND-COLOR: #f3f5fa; TEXT-ALIGN: center }
		</style>
	</HEAD>
	<body class="body1" bgColor="#ffffff" leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="ManageStaff" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr style="display:none;">
					<td vAlign="top">
						<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR height="30">
									<TD style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
										align="center" background="../../images/treetopbg.jpg" bgColor="#e8f4ff">职工管理</TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			</TD></TR>
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><asp:dropdownlist id="ddlCondition0" runat="server" Width="110px"></asp:dropdownlist></td>
					<TD style="HEIGHT: 12px" height="12"><asp:dropdownlist id="ddlCondition1" runat="server" Width="110px" AutoPostBack="True">
							<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
							<asp:ListItem Value="ry_xm">职工姓名</asp:ListItem>
							<asp:ListItem Value="ry_zgbh">职工编号</asp:ListItem>
							<asp:ListItem Value="ry_zw">岗位</asp:ListItem>
							<asp:ListItem Value="pylx">用工性质</asp:ListItem>
							<asp:ListItem Value="rylb">人员类别</asp:ListItem>
							<asp:ListItem Value="Sex">性别(1:男,0:女)</asp:ListItem>
							<asp:ListItem Value="Age">年龄</asp:ListItem>
							<asp:ListItem Value="mz">民族</asp:ListItem>
							<asp:ListItem Value="jg">籍贯</asp:ListItem>
							<asp:ListItem Value="zc">职称</asp:ListItem>
							<asp:ListItem Value="zcjb">职称级别</asp:ListItem>
							<asp:ListItem Value="zgxl">最高学历</asp:ListItem>
							<asp:ListItem Value="byxx">毕业学校</asp:ListItem>
							<asp:ListItem Value="zylb">专业类别</asp:ListItem>
							<asp:ListItem Value="sxzy">所学专业</asp:ListItem>
							<asp:ListItem Value="xxxs">学习形式</asp:ListItem>
							<asp:ListItem Value="wysp">外语水平</asp:ListItem>
							<asp:ListItem Value="jsjsp">计算机水平</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 12px" height="12"><asp:textbox id="txtCondition1" runat="server" Width="100px"></asp:textbox><asp:dropdownlist id="ddlZylb" runat="server" Width="100px" AutoPostBack="True" Visible="False">
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
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 12px" height="12"><asp:dropdownlist id="ddlCondition2" runat="server" Width="110px" AutoPostBack="True">
							<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
							<asp:ListItem Value="ry_xm">职工姓名</asp:ListItem>
							<asp:ListItem Value="ry_zgbh">职工编号</asp:ListItem>
							<asp:ListItem Value="ry_zw">职位</asp:ListItem>
							<asp:ListItem Value="pylx">聘用类型</asp:ListItem>
							<asp:ListItem Value="ywm">英文名</asp:ListItem>
							<asp:ListItem Value="cym">曾用名</asp:ListItem>
							<asp:ListItem Value="Sex">性别(1:男,0:女)</asp:ListItem>
							<asp:ListItem Value="shi">所在室</asp:ListItem>
							<asp:ListItem Value="sfzh">身份证号</asp:ListItem>
							<asp:ListItem Value="Age">年龄</asp:ListItem>
							<asp:ListItem Value="mz">民族</asp:ListItem>
							<asp:ListItem Value="jg">籍贯</asp:ListItem>
							<asp:ListItem Value="hkszd">户口所在地</asp:ListItem>
							<asp:ListItem Value="zzmm">政治面貌</asp:ListItem>
							<asp:ListItem Value="jkqk">健康状况</asp:ListItem>
							<asp:ListItem Value="hyzk">婚姻状况</asp:ListItem>
							<asp:ListItem Value="zc">职称</asp:ListItem>
							<asp:ListItem Value="zcjb">职称级别</asp:ListItem>
							<asp:ListItem Value="zgxl">最高学历</asp:ListItem>
							<asp:ListItem Value="byxx">毕业学校</asp:ListItem>
							<asp:ListItem Value="zylb">专业类别</asp:ListItem>
							<asp:ListItem Value="sxzy">所学专业</asp:ListItem>
							<asp:ListItem Value="xxxs">学习形式</asp:ListItem>
							<asp:ListItem Value="wyyz">外语语种</asp:ListItem>
							<asp:ListItem Value="wysp">外语水平</asp:ListItem>
							<asp:ListItem Value="jsjsp">计算机水平</asp:ListItem>
							<asp:ListItem Value="zzrzmc">资质认证名称</asp:ListItem>
							<asp:ListItem Value="bdwcjpxmc">本单位参加培训名称</asp:ListItem>
							<asp:ListItem Value="jtzz">家庭住址</asp:ListItem>
						</asp:dropdownlist></TD>
					<td style="HEIGHT: 12px"><asp:textbox id="txtCondition2" runat="server" Width="100px"></asp:textbox><asp:dropdownlist id="ddlZylb1" runat="server" Width="100px" AutoPostBack="True" Visible="False">
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
						</asp:dropdownlist></td>
					<TD style="HEIGHT: 12px" height="12"><asp:dropdownlist id="ddlCondition3" runat="server" Width="110px">
							<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
							<asp:ListItem Value="gwbdsj">岗位变动时间</asp:ListItem>
							<asp:ListItem Value="Birthday">出生日期</asp:ListItem>
							<asp:ListItem Value="rdpsj">入党派时间</asp:ListItem>
							<asp:ListItem Value="bysj">毕业时间</asp:ListItem>
							<asp:ListItem Value="cjgzsj">参加工作时间</asp:ListItem>
							<asp:ListItem Value="jbdwsj">进本单位时间</asp:ListItem>
							<asp:ListItem Value="zcrdsj">职称认定时间</asp:ListItem>
							<asp:ListItem Value="htqssj">合同起始时间</asp:ListItem>
							<asp:ListItem Value="htzzsj">合同终止时间</asp:ListItem>
							<asp:ListItem Value="pxxyyxsj">培训协议有效时间</asp:ListItem>
						</asp:dropdownlist></TD>
					<td style="HEIGHT: 12px"><asp:textbox id="txtCondition3" runat="server" Width="100px"></asp:textbox></td>
					<td style="HEIGHT: 12px"><asp:button id="btn_Search" runat="server" Text="查  询" CssClass="input4"></asp:button></td>
				</TR>
			</TABLE>
			<tr>
				<TD>
					<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD align=center width=90 
    background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
    height=24><asp:linkbutton id="lbOnline" runat="server" CssClass="Newbutton" ForeColor="White">在职员工</asp:linkbutton></TD>
							<TD align=center width=90 
    background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
    height=24><asp:linkbutton id="lbOffLine" runat="server" CssClass="Newbutton" ForeColor="White">离职员工</asp:linkbutton></TD>
							<TD align="right"><asp:button id="btnPrint" runat="server" Text="打印到Excel" CssClass="input4"></asp:button>&nbsp;&nbsp;<asp:button id="cmdNewStaff" runat="server" Text="新员工" CssClass="input4"></asp:button>&nbsp;
								<asp:button id="btn_ry_photo" Visible="false" runat="server" Text="照片管理" CssClass="input4"></asp:button>&nbsp;<FONT face="宋体">
								</FONT>
							</TD>
						</TR>
					</TABLE>
				</TD>
			</tr>
			<TR>
				<TD><asp:datagrid id="dbStaffList" runat="server" Width="100%" DataKeyField="ry_zgbh" AutoGenerateColumns="False"
						AllowPaging="True" PageSize="20" OnPageIndexChanged="DataGrid_PageChanged">
						<AlternatingItemStyle HorizontalAlign="Center" BackColor="White"></AlternatingItemStyle>
                                <ItemStyle HorizontalAlign="Center" BackColor="#EFF3FB"></ItemStyle>
						<HeaderStyle BackColor="#507CD1" ForeColor="white" Font-Bold="true" HorizontalAlign="Center"
                                    CssClass="title4" />
						<FooterStyle HorizontalAlign="Right"></FooterStyle>
						<Columns>
							<asp:HyperLinkColumn Text="姓名" DataNavigateUrlField="ry_zgbh" DataNavigateUrlFormatString="../Staff/NewStaff.aspx?StaffID={0}&amp;ReturnPage=1"
								DataTextField="ry_xm" HeaderText="姓名">
								<HeaderStyle Width="8%"></HeaderStyle>
							</asp:HyperLinkColumn>
							<asp:BoundColumn DataField="pylx" HeaderText="聘用类型">
								<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="ry_zgbh" HeaderText="职工编号">
								<HeaderStyle Width="8%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="sfzh" HeaderText="身份证号">
								<HeaderStyle Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="Age" HeaderText="年龄">
								<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="SexName" HeaderText="性别">
								<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="zgxl" HeaderText="最高学历">
								<HeaderStyle Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="zc" HeaderText="职称">
								<HeaderStyle Width="10%"></HeaderStyle>
							</asp:BoundColumn>
							<asp:BoundColumn HeaderText="部门-职位">
								<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="lzsj" HeaderText="离职时间"></asp:BoundColumn>
							<asp:TemplateColumn Visible="False" HeaderText="离职">
								<ItemTemplate>
									<asp:LinkButton id="LinkButton2" runat="server" CommandName="delete">离职</asp:LinkButton>&nbsp;
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
							Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
			<tr>
				<TD></TD>
			</tr>
			</TBODY></TABLE></form>
	</body>
</HTML>
