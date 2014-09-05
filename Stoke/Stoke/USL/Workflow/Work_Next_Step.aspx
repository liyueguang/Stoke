<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Work_Next_Step.aspx.cs" Inherits="Stoke.USL.Workflow.Work_Next_Step" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Work_Next_Step</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<script src="../Scripts/ymPrompt.js" type="text/javascript"></script>
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
			<TABLE id="Table5" style="Z-INDEX: 102; LEFT: 8px; WIDTH: 728px; POSITION: absolute; TOP: 40px; HEIGHT: 80px"
				cellSpacing="0" cellPadding="0" width="728" border="0">
				<TR>
					<TD style="WIDTH: 717px; HEIGHT: 61px">
						<fieldset id="fieldset1" runat="server" style="WIDTH: 716px;"><LEGEND>请选择下一步骤</LEGEND><asp:radiobuttonlist id="RadioButtonList1" runat="server" Height="8px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1"></asp:radiobuttonlist></fieldset>
					</TD>
				</TR>
				<TR>
					<TD>
						<fieldset id="fieldset2" runat="server"><LEGEND>请选择下一步人员</LEGEND>
							<TABLE id="Table2" style="HEIGHT: 86px" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="HEIGHT: 32px" align="left">&nbsp;<font color="#ff3300" style="FONT-WEIGHT: bold; FONT-STYLE: normal">已选人员:</font>
										<asp:Label id="obj" runat="server">无</asp:Label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 32px" align="left">
										<asp:Label id="labObjZgbh" runat="server" Visible="False">无</asp:Label></TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center" width="100%"><asp:listbox id="LB_All" runat="server" Width="200px" Rows="5" Height="96px"></asp:listbox><uc1:slctmember id="SlctMember1" runat="server" Visible="False"></uc1:slctmember></TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center">
										<P>&nbsp;</P>
										<P><asp:button id="Button1" runat="server" Width="100px" Text="确定" CssClass="input4" OnClick="Button1_Click1"></asp:button></P>
									</TD>
								</TR>
							</TABLE>
						</fieldset>
						<fieldset id="fieldset3" runat="server"><LEGEND>确认转交下一步</LEGEND>
							<TABLE id="Table3" style="WIDTH: 720px; HEIGHT: 21px" cellSpacing="0" cellPadding="0" width="720"
								border="0">
								<TR id="returnTr" runat="server">
									<TD style="WIDTH: 100%" vAlign="middle" align="center">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD vAlign="middle" align="right" width="15%">填写退回意见：</TD>
												<TD>
													<asp:textbox id="tsyj" runat="server" Height="80px" Width="100%" BackColor="White" Font-Size="X-Small"
														TextMode="MultiLine"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 100%" vAlign="middle" align="center"><asp:button id="Button2" runat="server" Width="100px" Text="转交下一步" CssClass="input4" OnClick="Button2_Click1"></asp:button></TD>
								</TR>
							</TABLE>
						</fieldset>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
