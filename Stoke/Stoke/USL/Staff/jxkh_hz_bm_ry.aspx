<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jxkh_hz_bm_ry.aspx.cs" Inherits="Stoke.USL.Staff.jxkh_hz_bm_ry" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>jxkh_hz_bm_ry</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table6" style="LEFT: 272px; POSITION: absolute; TOP: 128px" cellSpacing="0"
				cellPadding="0" width="166" bgColor="#ffffff" border="1" runat="server">
				<tr>
					<td>
						<uc1:SlctMember id="SlctMember1" runat="server"></uc1:SlctMember></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 0px" align="center"><asp:button id="btnBack" runat="server" Width="66px" Text="确定" CssClass="input4"></asp:button><asp:button id="Button3" runat="server" Width="66px" Text="关闭" CssClass="input4"></asp:button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR style="display:none;" >
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
								<TD align="center" width="150">起始时间</TD>
								<TD align="left" width="75">
									<asp:TextBox id="txtQsNf" runat="server" Width="50px" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy'})"></asp:TextBox>
								</TD>
								<TD align="right" width="75">
									<asp:TextBox id="txtQsYf" runat="server" Width="50px" onfocus="WdatePicker({skin:'simple',dateFmt:'M'})"></asp:TextBox>
								</TD>
								<TD align="center" width="150">截止时间</TD>
								<TD width="75" align="left">
									<asp:TextBox id="txtJzNf" runat="server" Width="50px" onfocus="WdatePicker({skin:'simple',dateFmt:'yyyy'})"></asp:TextBox>
								</TD>
								<TD width="75" align="right">
									<asp:TextBox id="txtJzYf" runat="server" Width="50px" onfocus="WdatePicker({skin:'simple',dateFmt:'M'})"></asp:TextBox>
								</TD>
								<TD><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD align="center">统计部门</TD>
								<TD align="left" colSpan="2">
									<asp:dropdownlist id="ddlBm" runat="server" Width="150px">
										<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
										<asp:ListItem Value="M">在职人员</asp:ListItem>
										<asp:ListItem Value="PM">聘管人员</asp:ListItem>
										<asp:ListItem Value="PW">聘工人员</asp:ListItem>
									</asp:dropdownlist></FONT></TD>
								<TD align="center"><FONT face="宋体">
										<asp:Button id="btnStatBm" runat="server" Text="统计" CssClass="input4"></asp:Button></FONT></TD>
								<TD colSpan="2"><FONT face="宋体"></FONT></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:LinkButton id="lbtnRy" runat="server">统计人员</asp:LinkButton></TD>
								<TD align="left">
									<asp:TextBox id="txtZgbh" runat="server" Width="75px"></asp:TextBox></TD>
								<td><asp:TextBox id="txtXm" runat="server" Width="75px"></asp:TextBox></td>
								<TD align="center">
									<asp:Button id="btnStatRy" runat="server" Text="统计" CssClass="input4"></asp:Button></TD>
								<TD colSpan="2"><FONT face="宋体"></FONT></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD><FONT style="COLOR: red" face="宋体">
							<asp:Label id="labStat" runat="server"></asp:Label></FONT></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgJxkh" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="20">
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
								<asp:BoundColumn DataField="jxkh_nf" HeaderText="年份"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_yf" HeaderText="月份"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_zfhz" ReadOnly="True" HeaderText="考核分数"></asp:BoundColumn>
								<asp:BoundColumn DataField="jxkh_xshz" ReadOnly="True" HeaderText="绩效系数" DataFormatString="{0:0.00}"></asp:BoundColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Visible="False" HorizontalAlign="Right" BackColor="#F3F5FA"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
