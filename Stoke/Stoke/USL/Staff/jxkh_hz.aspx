<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jxkh_hz.aspx.cs" Inherits="Stoke.USL.Staff.jxkh_hz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>jxkh_hz</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR style="display:none;">
					<TD style="HEIGHT: 32px" align="center"><B style="mso-bidi-font-weight: normal"><SPAN lang="EN-US" style="FONT-SIZE: 16pt; FONT-FAMILY: 仿宋_GB2312; mso-hansi-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: ZH-CN; mso-bidi-language: AR-SA; mso-font-kerning: 1.0pt">绩效考核统计</SPAN></B></TD>
				</TR>
				<tr>
					<TD>
						<TABLE class="gbtext" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align=center width=90 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
          height=24><asp:linkbutton id="lbOnline" runat="server" CssClass="Newbutton" ForeColor="White">聘用类型统计</asp:linkbutton></TD>
								<TD align=center width=90 
          background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          height=24><asp:linkbutton id="lbOffLine" runat="server" CssClass="Newbutton" ForeColor="White">部门/人员统计</asp:linkbutton></TD>
								<TD align="right">&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<tr>
					<td align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="600" border="0">
							<TR>
								<TD width="20%">汇总条件</TD>
								<TD style="HEIGHT: 12px" width="20%"><asp:dropdownlist id="ddlPylx" runat="server" Width="120px">
										<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
										<asp:ListItem Value="M">在职人员</asp:ListItem>
										<asp:ListItem Value="PM">聘管人员</asp:ListItem>
										<asp:ListItem Value="PW">聘工人员</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 12px" align="center" width="100">考核日期</TD>
								<TD style="HEIGHT: 12px" align="left" width="150"><asp:dropdownlist id="ddlNf" runat="server" Width="55px">
										<asp:ListItem Value="年份">年份</asp:ListItem>
										<asp:ListItem Value="2009">2009</asp:ListItem>
										<asp:ListItem Value="2010">2010</asp:ListItem>
										<asp:ListItem Value="2011">2011</asp:ListItem>
										<asp:ListItem Value="2012">2012</asp:ListItem>
										<asp:ListItem Value="2013">2013</asp:ListItem>
										<asp:ListItem Value="2014">2014</asp:ListItem>
										<asp:ListItem Value="2015">2015</asp:ListItem>
										<asp:ListItem Value="2016">2016</asp:ListItem>
										<asp:ListItem Value="2017">2017</asp:ListItem>
										<asp:ListItem Value="2018">2018</asp:ListItem>
										<asp:ListItem Value="2019">2019</asp:ListItem>
										<asp:ListItem Value="2020">2020</asp:ListItem>
										<asp:ListItem Value="2021">2021</asp:ListItem>
										<asp:ListItem Value="2022">2022</asp:ListItem>
										<asp:ListItem Value="2023">2023</asp:ListItem>
										<asp:ListItem Value="2024">2024</asp:ListItem>
										<asp:ListItem Value="2025">2025</asp:ListItem>
										<asp:ListItem Value="2026">2026</asp:ListItem>
										<asp:ListItem Value="2027">2027</asp:ListItem>
										<asp:ListItem Value="2028">2028</asp:ListItem>
										<asp:ListItem Value="2029">2029</asp:ListItem>
										<asp:ListItem Value="2030">2030</asp:ListItem>
									</asp:dropdownlist><FONT face="宋体">&nbsp; </FONT>
									<asp:dropdownlist id="ddlYf" runat="server" Width="55px">
										<asp:ListItem Value="月份">月份</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 12px" colSpan="2"><FONT face="宋体"><asp:button id="btnSearch" runat="server" Text="查询" CssClass="input4"></asp:button></FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<FONT style="COLOR: red" face="宋体">
							<asp:Label id="labStat" runat="server"></asp:Label></FONT></td>
				</tr>
				<TR>
					<td><asp:datagrid id="dgJxkh" runat="server" Width="100%" PageSize="20" AutoGenerateColumns="False">
							<AlternatingItemStyle HorizontalAlign="Center" BackColor="White"></AlternatingItemStyle>
                                <ItemStyle HorizontalAlign="Center" BackColor="#EFF3FB"></ItemStyle>
						<HeaderStyle BackColor="#507CD1" ForeColor="white" Font-Bold="true" HorizontalAlign="Center"
                                    CssClass="title4" />
							<Columns>
								<asp:TemplateColumn HeaderText="编号">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<%#Container.ItemIndex+1%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="jxkh_id" ReadOnly="True" HeaderText="编号"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_zgbh" ReadOnly="True" HeaderText="职号"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_xm" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_zf" ReadOnly="True" HeaderText="考核分数"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_xs" ReadOnly="True" HeaderText="绩效系数"></asp:BoundColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Visible="False" HorizontalAlign="Right" BackColor="#F3F5FA"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
