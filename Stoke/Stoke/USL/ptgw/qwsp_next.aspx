<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qwsp_next.aspx.cs" Inherits="Stoke.USL.ptgw.qwsp_next" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>qwsp_next</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script id="Back" language="javascript"> </script>
		<script language="javascript">
          function keepsession()
          {
             document.all["Back"].src="../SessionKeeper.asp?RandStr="+Math.random();
             //这里的RandStr=Math.random只是为了让每次back.src的值不同，防止同一地址刷新无效的情况
             window.setTimeout("keepsession()",1500000); //每隔1500秒调用一下本身
           }
             keepsession();
		</script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 728px; POSITION: absolute; TOP: 8px; HEIGHT: 27px"
				cellSpacing="0" cellPadding="0" width="728" border="0">
				<TR>
					<TD style="FONT-WEIGHT: bold; FONT-SIZE: larger; COLOR: blue; FONT-FAMILY: 幼圆; FONT-VARIANT: normal"
						align="center" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff">下一步转交</TD>
				</TR>
			</TABLE>
			<TABLE style="Z-INDEX: 102; LEFT: 8px; WIDTH: 730px; POSITION: absolute; TOP: 40px; HEIGHT: 64px"
				cellSpacing="0" cellPadding="0" width="730" border="0">
				<TR>
					<TD style="WIDTH: 717px; HEIGHT: 53px">
						<fieldset style="WIDTH: 716px; HEIGHT: 8px"><LEGEND>请选择下一步骤</LEGEND><asp:radiobuttonlist id="RadioButtonList1" runat="server" Width="720px" Height="16px" AutoPostBack="True"></asp:radiobuttonlist></fieldset>
					</TD>
				</TR>
				<TR>
					<TD>
						<FIELDSET id="fieldset1" style="WIDTH: 729px; HEIGHT: 16px" runat="server"><LEGEND>请选择下一步接收人</LEGEND>
							<TABLE id="Table2" style="WIDTH: 720px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="720"
								border="0">
								<TR>
									<TD align="center"><asp:dropdownlist id="DropDownList1" runat="server" Width="150px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px">
						<fieldset id="fieldset2" style="WIDTH: 729px; HEIGHT: 16px" runat="server"><LEGEND>请选择下一步接收人</LEGEND>
							<TABLE id="Table4" style="WIDTH: 722px; HEIGHT: 8px" cellSpacing="0" cellPadding="0" width="722"
								border="0">
								<TR>
									<TD align="left">
										<TABLE id="Table5" style="WIDTH: 721px; HEIGHT: 8px" cellSpacing="0" cellPadding="0" width="721"
											border="0">
											<TR>
												<TD style="HEIGHT: 6px" align="center"><asp:label id="Label1" runat="server">请选择转发人员</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 6px" align="center">
													<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100" border="1">
														<TR>
															<TD><uc1:slctmember id="SlctMember1" runat="server"></uc1:slctmember></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="center"><asp:button id="Button1" runat="server" Width="100px" CssClass="input4" Text="确定"></asp:button></TD>
											</TR>
											<TR>
												<TD align="center">
													<TABLE id="Table6" style="WIDTH: 720px; HEIGHT: 1px" cellSpacing="0" cellPadding="0" width="720"
														border="1">
														<TR>
															<TD style="WIDTH: 133px" align="center"><FONT face="宋体">已选人员:</FONT></TD>
															<TD align="left"><asp:label id="obj" runat="server">无</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</fieldset>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px">
						<FIELDSET id="fieldset3" style="WIDTH: 729px; HEIGHT: 1px" runat="server"><LEGEND>请选择下一步接收人</LEGEND>
							<TABLE id="Table7" style="WIDTH: 720px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="720"
								border="0">
								<TR>
									<TD align="center">
										<TABLE id="Table8" style="WIDTH: 721px; HEIGHT: 160px" cellSpacing="0" cellPadding="0"
											width="721" border="0">
											<TR>
												<TD style="HEIGHT: 18px" align="center"><asp:label id="Label2" runat="server">请选择转发人员(非必须环节)</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 3px" align="center"><FONT face="宋体">
														<TABLE id="Table11" style="WIDTH: 8px; HEIGHT: 16px" cellSpacing="0" cellPadding="0" width="8"
															border="1">
															<TR>
																<TD><uc1:slctmember id="SlctMember2" runat="server"></uc1:slctmember></TD>
															</TR>
														</TABLE>
													</FONT>
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 3px" align="center"><asp:checkbox id="CheckBox1" runat="server" AutoPostBack="True" Text="抄送秘书"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 4px" align="center">&nbsp;
													<asp:button id="Button3" runat="server" Width="100px" CssClass="input4" Text="确定"></asp:button>
													<TABLE class="body1" id="Table9" style="WIDTH: 720px; HEIGHT: 19px" cellSpacing="0" cellPadding="0"
														width="720" border="1">
														<TR>
															<TD style="WIDTH: 136px" align="center">您已选择的批转人</TD>
															<TD><FONT face="宋体"><asp:label id="obj2" runat="server">无</asp:label></FONT></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 136px" align="center"><FONT face="宋体">内部收件人</FONT></TD>
															<TD><FONT face="宋体"><asp:label id="sjr" runat="server"></asp:label></FONT></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 136px; HEIGHT: 21px" align="center"><FONT face="宋体">内部抄报</FONT></TD>
															<TD style="HEIGHT: 21px"><FONT face="宋体"><asp:label id="cb" runat="server"></asp:label></FONT></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 136px" align="center"><FONT face="宋体">内部抄送</FONT></TD>
															<TD><FONT face="宋体"><asp:label id="cs" runat="server"></asp:label></FONT></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 136px; HEIGHT: 22px" align="center"><FONT face="宋体">抄送秘书</FONT></TD>
															<TD style="HEIGHT: 22px"><asp:label id="ms" runat="server">无</asp:label></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 136px" align="center"><FONT face="宋体">收件人员名单汇总</FONT></TD>
															<TD><FONT face="宋体"><asp:label id="hz" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																	&nbsp;&nbsp;
																	<asp:label id="ts" runat="server" Visible="False" ForeColor="Red">*由于没有内部收件人,邮件转发经办人办理</asp:label></FONT></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
				</TR>
				<TR>
					<TD>
						<FIELDSET style="WIDTH: 729px; HEIGHT: 8px"><LEGEND>确认转交下一步</LEGEND>
							<TABLE id="Table3" style="WIDTH: 720px; HEIGHT: 21px" cellSpacing="0" cellPadding="0" width="720"
								border="0">
								<TR>
									<TD style="WIDTH: 100%" vAlign="middle" align="center">
										<TABLE id="Table10" style="WIDTH: 717px; HEIGHT: 19px" cellSpacing="0" cellPadding="0"
											width="717" border="0">
											<TR>
												<TD style="WIDTH: 133px" vAlign="middle" align="center" colSpan="1" rowSpan="1"><asp:label id="yj" runat="server" Visible="False">当前操作人填写意见</asp:label></TD>
												<TD><FONT face="宋体"><asp:textbox id="tsyj" runat="server" Width="100%" Height="42px" Visible="False" BackColor="White"
															Font-Size="X-Small" TextMode="MultiLine"></asp:textbox></FONT></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 100%" vAlign="middle" align="center"><asp:button id="Button2" runat="server" Width="100px" CssClass="input4" Text="转交下一步"></asp:button><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:button id="Button4" runat="server" Width="100px" CssClass="input4" Text="返回公文"></asp:button></FONT></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></form>
	</body>
</HTML>
