<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main2.aspx.cs" Inherits="Stoke.main2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<TITLE>网上办公管理系统</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<STYLE> BODY { SCROLLBAR-FACE-COLOR: #f892cc; SCROLLBAR-HIGHLIGHT-COLOR: #f256c6; SCROLLBAR-SHADOW-COLOR: #fd76c2; SCROLLBAR-3DLIGHT-COLOR: #fd76c2; SCROLLBAR-ARROW-COLOR: #fd76c2; SCROLLBAR-TRACK-COLOR: #fd76c2; SCROLLBAR-DARKSHADOW-COLOR: #f629b9; SCROLLBAR-BASE-COLOR: #e9cfe0 }
	<body style='overflow:scroll;overflow-x:hidden'> 
	</STYLE>
	</HEAD>
	<FRAMESET border="0" name="mainframe" frameSpacing="0" rows="*" frameBorder="NO" cols="190,7,*">
		<FRAME name="left" src="left_all.aspx" scrolling="no">
		<FRAME name="mframe" src="middle.aspx" noResize scrolling="no">
		<FRAMESET border="0" name="rightFrame" frameSpacing="0" rows="*,18" frameBorder="NO" cols="*">
			<FRAME name="rightMain" marginWidth="0" marginHeight="0" src="main.aspx" frameBorder="no"
				noResize scrolling="auto">
			<FRAME name="rightBottom" src="copyright.htm" scrolling="no">
		</FRAMESET>
		<NOFRAMES>
		</NOFRAMES>
	</FRAMESET>
</HTML>