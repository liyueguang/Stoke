<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zpyjsp_next.aspx.cs" Inherits="Stoke.USL.sbds.zpyjsp_next" %>
<%@ Register TagPrefix="uc1" TagName="SlctMember" Src="../../COMMON/SlctMember.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>zpyjsp_next</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta content="text/html; charset=gb2312" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../../css/css.css">
		<script type="text/javascript" src="../Scripts/ymPrompt.js"></script>
		<script id="Back" language="javascript"> </script>
		<script language="javascript">
          function keepsession()
          {
             document.all["Back"].src="../SessionKeeper.asp?RandStr="+Math.random();
             //�����RandStr=Math.randomֻ��Ϊ����ÿ��back.src��ֵ��ͬ����ֹͬһ��ַˢ����Ч�����
             window.setTimeout("keepsession()",1500000); //ÿ��1500�����һ�±���
           }
             keepsession();
		</script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 728px; HEIGHT: 27px; TOP: 8px; LEFT: 8px"
				id="Table1" border="0" cellSpacing="0" cellPadding="0" width="728">
				<TR>
					<TD style="FONT-VARIANT: normal; FONT-FAMILY: ��Բ; COLOR: blue; FONT-SIZE: larger; FONT-WEIGHT: bold"
						bgColor="#e8f4ff" background="../../Images/treetopbg.jpg" align="center">��һ��ת��</TD>
				</TR>
			</TABLE>
			<TABLE style="Z-INDEX: 102; POSITION: absolute; WIDTH: 728px; HEIGHT: 80px; TOP: 40px; LEFT: 8px"
				id="Table5" border="0" cellSpacing="0" cellPadding="0" width="728">
				<TR>
					<TD style="WIDTH: 717px; HEIGHT: 61px">
						<fieldset style="WIDTH: 716px;" id="fieldset1" runat="server"><LEGEND>��ѡ����һ����</LEGEND><asp:radiobuttonlist id="RadioButtonList1" runat="server" AutoPostBack="True" Height="8px"></asp:radiobuttonlist></fieldset>
					</TD>
				</TR>
				<TR>
					<TD>
						<fieldset id="fieldset2" runat="server"><LEGEND>��ѡ����һ����Ա</LEGEND>
							<TABLE style="HEIGHT: 86px" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="HEIGHT: 32px" align="left">&nbsp;<font style="FONT-STYLE: normal; FONT-WEIGHT: bold" color="#ff3300">��ѡ��Ա:</font>
										<asp:label id="obj" runat="server">��</asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 32px" align="left"><asp:label id="labObjZgbh" runat="server" Visible="False">��</asp:label></TD>
								</TR>
								<TR>
									<TD vAlign="middle" width="100%" align="center"><asp:listbox id="LB_All" runat="server" Height="96px" Rows="5" Width="200px"></asp:listbox><uc1:slctmember id="SlctMember1" runat="server" Visible="False"></uc1:slctmember></TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center">
										<P>&nbsp;</P>
										<P><asp:button id="Button1" runat="server" Width="100px" CssClass="input4" Text="ȷ��"></asp:button></P>
									</TD>
								</TR>
							</TABLE>
						</fieldset>
						<fieldset id="fieldset3" runat="server"><LEGEND>ȷ��ת����һ��</LEGEND>
							<TABLE style="WIDTH: 720px; HEIGHT: 21px" id="Table3" border="0" cellSpacing="0" cellPadding="0"
								width="720">
								<TR>
									<TD style="WIDTH: 100%" vAlign="middle" align="center"><asp:button id="Button2" runat="server" Width="100px" CssClass="input4" Text="ת����һ��"></asp:button></TD>
								</TR>
							</TABLE>
						</fieldset>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
