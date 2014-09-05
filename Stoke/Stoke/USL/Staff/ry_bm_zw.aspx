<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ry_bm_zw.aspx.cs" Inherits="Stoke.USL.Staff.ry_bm_zw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>ry_bm_zw</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute" cellSpacing="0" cellPadding="0"
				width="100%" border="0">
				<tr>
					<td class="GbText" style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
						align="center" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" colSpan="5">人员-部门-职位对应信息</td>
				</tr>
				<tr>
					<td style="HEIGHT: 17px" align="center"><FONT face="宋体">职工编号</FONT>
						<asp:textbox id="txt_zgbh" runat="server" Width="50px"></asp:textbox><FONT face="宋体" color="#ff0066">*</FONT></td>
					<td style="HEIGHT: 17px" align="center"><FONT face="宋体">职工姓名</FONT>
						<asp:textbox id="txt_xm" runat="server" Width="70px"></asp:textbox><FONT face="宋体" color="#ff0066">*</FONT></td>
					<td style="HEIGHT: 17px" align="center"><FONT face="宋体">所在部门</FONT>
						<asp:dropdownlist id="cboDepartment" runat="server" Width="250px"></asp:dropdownlist><FONT face="宋体" color="#ff0066">*</FONT></td>
					<td style="HEIGHT: 17px" align="center"><FONT face="宋体">对应职位</FONT>
						<asp:dropdownlist id="cboPosition" runat="server" Width="250px"></asp:dropdownlist><FONT face="宋体" color="#ff0066">*</FONT></td>
					<td style="HEIGHT: 17px" align="center" width="10%"><asp:button id="btn_add" runat="server" Text="添加" CssClass="input4"></asp:button></td>
				</tr>
				<TR>
					<TD align="center" colSpan="5"><asp:datagrid id="dbRyBmZw" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
							PageSize="16">
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#F3F5FA"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" CssClass="title4" VerticalAlign="Middle"></HeaderStyle>
							<FooterStyle Font-Size="X-Small" HorizontalAlign="Right"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ry_id" HeaderText="编号"></asp:BoundColumn>
								<asp:BoundColumn DataField="ry_zgbh" HeaderText="职工编号"></asp:BoundColumn>
								<asp:BoundColumn DataField="ry_xm" HeaderText="职工姓名"></asp:BoundColumn>
								<asp:BoundColumn DataField="ry_bm" HeaderText="所在部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="ry_zw" HeaderText="对应职位"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:LinkButton id="LinkButton1" runat="server" CommandName="sc">删除</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:LinkButton id="Linkbutton2" runat="server" CommandName="add">添加到职位变动情况</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Font-Size="X-Small" HorizontalAlign="Right" CssClass="title4"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5" height="35"><asp:button id="cmdBack" runat="server" Width="60px" Text="返回" CssClass="input4" Height="20px"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
