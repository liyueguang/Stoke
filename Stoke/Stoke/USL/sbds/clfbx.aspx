<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clfbx.aspx.cs" Inherits="Stoke.USL.sbds.clfbx" %>

<%@ Register Src="../../UserControls/EmergencySelector.ascx" TagName="EmergencySelector"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<HTML>
	<HEAD>
		<title>clfbx</title>
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../My97DatePicker/WdatePicker.js"></SCRIPT>
		<SCRIPT language="JavaScript" src="../../js/check.js"></SCRIPT>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" height="118"
				cellSpacing="1" cellPadding="1" width="95%" border="0">
				<TR>
					<TD align="center" colSpan="2" height="5"><FONT face="宋体"></FONT></TD>
				</TR>
				<TR style="display: none;">
					<TD align="center" colSpan="2"><asp:label id="Label" runat="server" Font-Size="Large" Width="387px" Height="24px">大连船舶重工集团海洋工程有限公司</asp:label></TD>
				</TR>
				<TR style="display: none;">
					<TD align="center" colSpan="2"><asp:label id="Label3" runat="server" Font-Size="X-Small" Font-Bold="True">Dalian Shipbuilding Offshore CO.,LTD.</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:label id="Label5" runat="server" Font-Size="Small" Font-Bold="True">差旅费报销单</asp:label></TD>
				</TR>
				<TR>
					<TD align="left"><asp:label id="Label1" runat="server">报销单号:</asp:label><asp:textbox id="a" runat="server" Width="186px" CssClass="myline" BackColor="Transparent" ReadOnly="True"></asp:textbox></TD>
					<TD align="right"><asp:label id="Label2" runat="server">日期:</asp:label><asp:textbox id="b" runat="server" Width="90px" CssClass="myline" BackColor="Transparent" ReadOnly="True"></asp:textbox></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 128px" cellSpacing="0"
				cellPadding="0" width="95%" border="0">
				<TR>
					<TD class="Tborder">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="Tborder_2" colSpan="8">
									<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
									</TABLE>
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="center" width="177" style="WIDTH: 177px"><FONT face="宋体">部门</FONT></TD>
											<TD align="center" width="6%"><FONT face="宋体">姓名</FONT></TD>
											<TD align="center" width="8%" colSpan="1" rowSpan="1"><FONT face="宋体">职务</FONT></TD>
											<TD align="center" width="18%"><FONT face="宋体">事由</FONT></TD>
											<TD align="center" width="8%"><FONT face="宋体">出差地点</FONT></TD>
											<TD align="center" width="44%"><FONT face="宋体">往返日期</FONT></TD>
										</TR>
										<TR>
											<TD align="center" style="WIDTH: 177px"><asp:textbox id="c11" runat="server" Width="80%" CssClass="myline"></asp:textbox><asp:image id="Image4" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="baseline" align="center"><FONT face="宋体"><asp:textbox id="c12" runat="server" Width="95%" CssClass="myline"></asp:textbox></FONT></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="c13" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD align="center"><asp:image id="Image19" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="c14" runat="server" Width="70%" CssClass="myline"></asp:textbox><asp:image id="Image7" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="bottom"><asp:textbox id="c15" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD><asp:image id="Image13" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox class="Wdate" id="c16" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月'})"
													runat="server" Width="35%" CssClass="myline"></asp:textbox><FONT face="宋体">&nbsp;</FONT><asp:textbox id="c17" runat="server" Width="35%" CssClass="myline" AutoPostBack="True"></asp:textbox><FONT face="宋体">&nbsp;</FONT><asp:textbox id="c18" runat="server" Width="15%" CssClass="myline"></asp:textbox></TD>
										</TR>
										<TR>
											<TD align="center" style="WIDTH: 177px"><asp:textbox id="d11" runat="server" Width="80%" CssClass="myline"></asp:textbox><asp:image id="Image1" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="d12" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="d13" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD align="center"><FONT face="宋体"><asp:image id="Image20" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="d14" runat="server" Width="70%" CssClass="myline"></asp:textbox><asp:image id="Image8" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
											<TD vAlign="bottom"><asp:textbox id="d15" runat="server" Width="95%" CssClass="myline" DESIGNTIMEDRAGDROP="6778"></asp:textbox></TD>
											<TD><FONT face="宋体"><asp:image id="Image14" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="d16" runat="server" Width="35%" CssClass="myline"></asp:textbox>&nbsp;<asp:textbox id="d17" runat="server" Width="35%" CssClass="myline" AutoPostBack="True"></asp:textbox>&nbsp;<asp:textbox id="d18" runat="server" Width="15%" CssClass="myline"></asp:textbox></FONT></TD>
										</TR>
										<TR>
											<TD align="center" style="WIDTH: 177px"><asp:textbox id="e11" runat="server" Width="80%" CssClass="myline"></asp:textbox><asp:image id="Image2" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="e12" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="e13" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD align="center"><asp:image id="Image21" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="e14" runat="server" Width="70%" CssClass="myline"></asp:textbox><asp:image id="Image9" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="bottom"><asp:textbox id="e15" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD><FONT face="宋体"><asp:image id="Image15" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="e16" runat="server" Width="35%" CssClass="myline"></asp:textbox>&nbsp;<asp:textbox id="e17" runat="server" Width="35%" CssClass="myline" AutoPostBack="True"></asp:textbox>&nbsp;<asp:textbox id="e18" runat="server" Width="15%" CssClass="myline"></asp:textbox></FONT></TD>
										</TR>
										<TR>
											<TD align="center" style="WIDTH: 177px"><asp:textbox id="f11" runat="server" Width="80%" CssClass="myline"></asp:textbox><asp:image id="Image3" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="f12" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="f13" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD align="center"><asp:image id="Image22" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="f14" runat="server" Width="70%" CssClass="myline"></asp:textbox><asp:image id="Image10" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="bottom"><asp:textbox id="f15" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD><asp:image id="Image16" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="f16" runat="server" Width="35%" CssClass="myline"></asp:textbox><FONT face="宋体">&nbsp;</FONT><asp:textbox id="f17" runat="server" Width="35%" CssClass="myline" AutoPostBack="True"></asp:textbox><FONT face="宋体">&nbsp;</FONT><asp:textbox id="f18" runat="server" Width="15%" CssClass="myline"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 177px; HEIGHT: 25px" align="center"><asp:textbox id="g11" runat="server" Width="80%" CssClass="myline"></asp:textbox><asp:image id="Image5" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="g12" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="g13" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD style="HEIGHT: 25px" align="center"><asp:image id="Image23" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="g14" runat="server" Width="70%" CssClass="myline"></asp:textbox><asp:image id="Image11" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD style="HEIGHT: 25px" vAlign="bottom"><asp:textbox id="g15" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD style="HEIGHT: 25px"><asp:image id="Image17" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="g16" runat="server" Width="35%" CssClass="myline"></asp:textbox><FONT face="宋体">&nbsp;</FONT><asp:textbox id="g17" runat="server" Width="35%" CssClass="myline" AutoPostBack="True"></asp:textbox><FONT face="宋体">&nbsp;</FONT><asp:textbox id="g18" runat="server" Width="15%" CssClass="myline"></asp:textbox></TD>
										</TR>
										<TR>
											<TD align="center" style="WIDTH: 177px"><asp:textbox id="h11" runat="server" Width="80%" CssClass="myline"></asp:textbox><asp:image id="Image6" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="h12" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD vAlign="baseline" align="center"><asp:textbox id="h13" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD align="center"><asp:image id="Image24" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="h14" runat="server" Width="70%" CssClass="myline"></asp:textbox><asp:image id="Image12" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
											<TD vAlign="bottom"><asp:textbox id="h15" runat="server" Width="95%" CssClass="myline"></asp:textbox></TD>
											<TD><asp:image id="Image18" runat="server" ImageUrl="../../images/L4.gif"></asp:image><asp:textbox id="h16" runat="server" Width="35%" CssClass="myline"></asp:textbox><FONT face="宋体">&nbsp;</FONT><asp:textbox id="h17" runat="server" Width="35%" CssClass="myline" AutoPostBack="True"></asp:textbox><FONT face="宋体">&nbsp;</FONT><asp:textbox id="h18" runat="server" Width="15%" CssClass="myline"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="Tborder_2" style="HEIGHT: 230px" colSpan="8"><FONT face="宋体">
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD colSpan="2">
													<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD align="center" width="30%" colSpan="2">时间</TD>
														</TR>
														<TR>
															<TD align="center" width="14%">出发</TD>
															<TD align="center" width="16%">到达</TD>
														</TR>
													</TABLE>
												</TD>
												<TD colSpan="2">
													<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD align="center" width="26%" colSpan="2">地点</TD>
														</TR>
														<TR>
															<TD align="center" width="12%">起点</TD>
															<TD align="center" width="14%">终点</TD>
														</TR>
													</TABLE>
												</TD>
												<TD align="center" width="8%">票价(元)</TD>
												<TD align="center" width="8%">交通费(元)</TD>
												<TD align="center" width="8%">住宿费(元)</TD>
												<TD align="center" width="8%">其他(元)</TD>
												<TD align="center" width="9%">合计(元)</TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="center" width="14%"><asp:textbox id="i11" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center" width="16%"><asp:textbox id="i12" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center" width="12%"><asp:textbox id="i13" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD align="center" width="14%"><asp:textbox id="i14" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox><asp:image id="Image31" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="i15" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="i16" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="i17" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="i18" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="i19" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="center" colSpan="1" rowSpan="1"><asp:textbox id="j11" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="j12" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="j13" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="j14" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox><asp:image id="Image32" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="j15" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="j16" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="WIDTH: 158px; HEIGHT: 24px" vAlign="baseline" align="center"><asp:textbox id="j17" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="j18" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="j19" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="center"><asp:textbox id="k11" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="k12" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="k13" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="k14" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox><asp:image id="Image33" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="k15" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="k16" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="WIDTH: 158px" vAlign="baseline" align="center"><asp:textbox id="k17" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="k18" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="k19" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="center"><asp:textbox id="l11" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="l12" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="l13" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="l14" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox><asp:image id="Image34" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="l15" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="l16" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="WIDTH: 158px" vAlign="baseline" align="center"><asp:textbox id="l17" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="l18" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="l19" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="m11" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="m12" runat="server" Width="80%" CssClass="myline"></asp:textbox></TD>
												<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="m13" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="HEIGHT: 25px" align="center"><asp:textbox id="m14" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox><asp:image id="Image35" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="m15" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="m16" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="WIDTH: 158px; HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="m17" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="m18" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="HEIGHT: 25px" vAlign="baseline" align="center"><asp:textbox id="m19" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="center"><asp:textbox id="n11" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="n12" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="n13" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD align="center"><asp:textbox id="n14" runat="server" Width="80%" CssClass="myline" EnableViewState="False"></asp:textbox><asp:image id="Image36" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="n15" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="n16" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="WIDTH: 158px" vAlign="baseline" align="center"><asp:textbox id="n17" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="n18" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="baseline" align="center"><asp:textbox id="n19" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="center" height="30"></TD>
												<TD height="30"></TD>
												<TD height="30"></TD>
												<TD align="right" height="30"><asp:button id="Button1" runat="server" CssClass="input6" Text="累计"></asp:button>&nbsp;
													<asp:image id="Image25" runat="server" ImageUrl="../../images/L4.gif"></asp:image></TD>
												<TD vAlign="bottom" align="center" height="30"><asp:textbox id="f1" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="bottom" align="center" height="30"><asp:textbox id="g1" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD style="WIDTH: 158px" vAlign="bottom" align="center" height="30"><asp:textbox id="h1" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="bottom" align="center" height="30"><asp:textbox id="i1" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
												<TD vAlign="bottom" align="center" height="30"><asp:textbox id="j1" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
											</TR>
										</TABLE>
									</FONT>
								</TD>
							</TR>
							<TR style="display: none;">
								<TD class="Tborder_2" colSpan="8">
									<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="right" width="9%"><FONT face="宋体">财务核定数
													<asp:image id="Image26" runat="server" ImageUrl="../../images/L41.gif"></asp:image></FONT></TD>
											<TD>
												<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="center" width="18%"><FONT face="宋体">票价(元)</FONT></TD>
														<TD align="center" width="12%"><FONT face="宋体">交通费(元)</FONT></TD>
														<TD align="center" width="14%"><FONT face="宋体">住宿费(元)</FONT></TD>
														<TD align="center" width="8%"><FONT face="宋体">其他费用(元)</FONT></TD>
														<TD align="center"><FONT face="宋体">交通补贴(元)</FONT></TD>
														<TD align="center" width="8%"><FONT face="宋体">伙食补贴(元)</FONT></TD>
														<TD align="center" width="17%"><FONT face="宋体"><asp:button id="Button2" runat="server" CssClass="input6" Text="累计"></asp:button></FONT></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="1" height="30" rowSpan="1"><asp:textbox id="o" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
														<TD align="center" height="30"><asp:textbox id="p" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
														<TD align="center" height="30"><asp:textbox id="q" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
														<TD align="center" height="30"><asp:textbox id="r" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
														<TD align="center" width="8%" height="30"><asp:textbox id="s" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
														<TD align="center" height="30"><asp:textbox id="t" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
														<TD align="center" height="30"><asp:textbox id="u" runat="server" Width="95%" CssClass="myline" EnableViewState="False"></asp:textbox></TD>
													</TR>
													<TR>
														<TD colSpan="7" height="30"><FONT face="宋体">金额大写
																<asp:textbox id="v" runat="server" Width="85%" CssClass="myline" EnableViewState="False"></asp:textbox></FONT></TD>
													</TR>
													<TR>
														<TD colSpan="4" height="30" rowSpan="1"><FONT face="宋体">原借款数(元)
																<asp:textbox id="w" runat="server" Width="85%" CssClass="myline" AutoPostBack="True" EnableViewState="False"></asp:textbox></FONT></TD>
														<TD colSpan="3" height="30" width="40%"><FONT face="宋体">应退余款(元)
																<asp:textbox id="x" runat="server" Width="60%" CssClass="myline" EnableViewState="False"></asp:textbox></FONT></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR style="display: none;">
								<TD class="Tborder_2" colSpan="8">
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="bottom" align="right" width="9%"><FONT face="宋体">&nbsp;部门总监
													<asp:image id="Image38" runat="server" ImageUrl="../../images/L41.gif"></asp:image></FONT></TD>
											<TD vAlign="bottom" align="right" width="15%"><FONT face="宋体"><asp:textbox id="o1" runat="server" Width="100%" Height="110px" TextMode="MultiLine" BorderStyle="Groove"
														BorderColor="LightGray" Enabled="False"></asp:textbox></FONT></TD>
											<TD vAlign="top" align="right" width="12%"><FONT face="宋体">部门负责人
													<asp:image id="Image27" runat="server" ImageUrl="../../images/L41.gif"></asp:image></FONT></TD>
											<TD vAlign="bottom" width="15%"><FONT face="宋体"><asp:textbox id="y" runat="server" Width="100%" Height="110px" TextMode="MultiLine" BorderStyle="Groove"
														BorderColor="LightGray" Enabled="False"></asp:textbox></FONT></TD>
											<TD align="right" width="9%"><FONT face="宋体">
													<asp:image id="Image28" runat="server" ImageUrl="../../images/L41.gif"></asp:image></FONT></TD>
											<TD vAlign="bottom" width="15%"><FONT face="宋体"><asp:textbox id="z" runat="server" Width="100%" Height="110px" TextMode="MultiLine" BorderStyle="Groove"
														BorderColor="LightGray" Enabled="False" Visible="False"></asp:textbox></FONT></TD>
											<TD align="right" width="9%"><FONT face="宋体">
													<asp:image id="Image29" runat="server" ImageUrl="../../images/L41.gif"></asp:image></FONT></TD>
											<TD vAlign="bottom" width="15%"><asp:textbox id="a1" runat="server" Width="100%" Height="110px" TextMode="MultiLine" BorderStyle="Groove"
													BorderColor="LightGray" Enabled="False" Visible="False"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="Tborder_2" vAlign="bottom" colSpan="8" height="45">
									<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
                                            <td align="right" colspan="1" height="45" rowspan="1" style="width: 13%"><FONT face="宋体">部门总监签字
													<asp:image id="Image39" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT>
                                            </td>
                                            <td align="right" colspan="1" height="45" rowspan="1" width="20%"><asp:textbox id="d1" runat="server" Width="100%" CssClass="myline" EnableViewState="False" Enabled="False"></asp:textbox>
                                            </td>
											<TD align="right" colSpan="1" height="45" rowSpan="1" style="width: 13%"><FONT face="宋体">助理总裁签字
													<asp:image id="Image30" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
											<TD height="45" style="width: 20%"><FONT face="宋体"><asp:textbox id="b1" runat="server" Width="100%" CssClass="myline" EnableViewState="False" Enabled="False"></asp:textbox></FONT></TD>
											<TD align="right" width="10%" height="45"><FONT face="宋体">总经理签字
													<asp:image id="Image37" runat="server" ImageUrl="../../images/L4.gif"></asp:image></FONT></TD>
											<TD height="45" style="width: 20%"><asp:textbox id="c1" runat="server" Width="100%" CssClass="myline" EnableViewState="False" Enabled="False"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<tr>
							    <td>
							        <table cellpadding="0" cellspacing="0" border="0" width="100%">
							            <tr>
							                <td style="text-align: center; width: 15%;">紧急程度：</td>
							                <td><uc1:EmergencySelector ID="EmergencySelector1" runat="server" Enabled="false" /></td>
							            </tr>
							        </table>
							    </td>
							</tr>
							<TR>
								<TD class="Tborder_2" colSpan="8">
									<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
									</TABLE>
									<asp:textbox id="c" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="d" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="e" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="f" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="g" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="h" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="i" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="j" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="k" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="l" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="m" runat="server" Width="10px" Visible="False"></asp:textbox><asp:textbox id="n" runat="server" Width="10px" Visible="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="Tborder_2" id="TD1" align="center" colSpan="8"><FONT face="宋体"></FONT></TD>
							</TR>
							<TR>
								<TD class="Tborder_2" id="TD2" align="center" colSpan="8" runat="server"><FONT face="宋体"></FONT></TD>
							</TR>
							<TR class="Tborder_2">
								<TD colSpan="8"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR height="40">
												<TD width="38%"></TD>
												<TD align="center" width="8%"><asp:button id="submitBtn" runat="server" CssClass="input4" Text="处  理"></asp:button></TD>
												<TD align="center" width="8%"><asp:button id="storeBtn" runat="server" CssClass="input4" Text="保  存" CausesValidation="False"></asp:button></TD>
												<TD align="center" width="8%"><asp:button id="cancelBtn" runat="server" CssClass="input4" Text="返  回" CausesValidation="False"></asp:button></TD>
												<TD width="38%"></TD>
											</TR>
										</TABLE>
									</FONT>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="right"><FONT face="宋体">注意：在正式提交表单数据前，请保证进行过累计计算，且累计计算为最新填写的数据信息！</FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
