<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="middle.aspx.cs" Inherits="Stoke.middle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<TITLE>无标题文档</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
	var screen=true;i=0;width=0;
	function  shiftwindow()
	{
		if(screen==false)
		{
		   document.all("AtMovePic2").style.display=""
		   document.all("AtMovePic1").style.display="none"
		   parent.mainframe.cols='0,7,*';
			screen=true;		
		}
		else if(screen==true)
		{
			parent.mainframe.cols='181,7,*';
			screen=false;	
  		    document.all("AtMovePic2").style.display="none"
		    document.all("AtMovePic1").style.display=""
		}
	}	
		</SCRIPT>
		<META content="MSHTML 6.00.2900.3268" name="GENERATOR">
		<style type="text/css">
<!--
body {
	background-image: url(images/bbs_07.gif);
}
-->
		</style>
	</HEAD>
	<BODY class="body3" onload="shiftwindow()">
		<TABLE height="100%" cellSpacing="0" cellPadding="0" border="0" background="images/bbs_07.gif">
			<TBODY>
				<TR id="AtMovePic1">
					<TD><A href="javascript:shiftwindow()"><IMG height="74" alt="关闭左栏" src="images/md_b1.gif" width="7" border="0" name="Image1"></A></TD>
				</TR>
				<TR id="AtMovePic2">
					<TD><A href="javascript:shiftwindow()"><IMG height="74" alt="打开左栏" src="images/md_b2.gif" width="7" border="0" name="Image1"></A></TD>
				</TR>
			</TBODY>
		</TABLE>
	</BODY>
</HTML>