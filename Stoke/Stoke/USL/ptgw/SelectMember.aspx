<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectMember.aspx.cs" Inherits="Stoke.USL.gwgl.SelectMember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>SelectMember</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<script language="javascript">
		function RemoveItem(ControlName)
	    { 
		Control = null;
		switch (ControlName){
		 case "btnReceSendToLeft" : 
		   Control=eval("document.SelectMember.listSendTo");  
		   break;
		 case "btnCcSendToLeft" : 
		   Control=eval("document.SelectMember.listCcTo");  
		   break;
		 case "btnBccSendToLeft" : 
		   Control=eval("document.SelectMember.listBccTo");  
		   break;
		  } 
				
				var j=Control.length;
				if(j==0) return;
				for(j;j>0;j--)
				{
					if(Control.options[j-1].selected==true)
					{ 
 						Control.remove(j-1);
					}
				}
		   	
	}

	function AddItem(ControlName)
	{
		Control = null;
		switch (ControlName){
		 case "btnReceSendToRight" : 
		   Control=eval("document.SelectMember.listSendTo");  
		   break;
		 case "btnCcSendToRight" : 
		   Control=eval("document.SelectMember.listCcTo");  
		   break;
		 case "btnBccSendToRight" : 
		   Control=eval("document.SelectMember.listBccTo");  
		   break;
		} 
		
		var i=0;
		listAccount=eval("document.SelectMember.listAccount");
		var j=listAccount.length;
		for(i=0;i<j;i++)
		{
			if(listAccount.options[i].selected==true)
			{ 
				     
				Control.add(new Option(listAccount[i].text,listAccount.options[i].value));				         
			}
		}
	
	}

	function setStatusright()
	{
		document.SelectMember.btnReceSendToRight.disabled = false;
		document.SelectMember.btnCcSendToRight.disabled=false;
		document.SelectMember.btnBccSendToRight.disabled=false;
	}

	function setStatusleft()
	{
		document.SelectMember.btnReceSendToLeft .disabled =false;
		document.SelectMember.btnCcSendToLeft.disabled=false;
		document.SelectMember.btnBccSendToLeft.disabled=false;
	}
	
	function PopulateData()
	{
	   if (window.dialogArguments != null) 
		{
			var parwin = window.dialogArguments;	
					
			if(parwin.document.all.hdnTxtSendTo.value!="")
			{
			    Control=eval("document.SelectMember.listSendTo");  
				var SendToValueArray = parwin.document.all.hdnTxtSendTo.value.split(",");
				var SendToTxtArray = parwin.document.all.txtSendTo.value.split(",");
				for(i=0;i<SendToValueArray.length-1;i++)
				{
					Control.add(new Option(SendToTxtArray[i],SendToValueArray[i]));
				}
			}
			
			if(parwin.document.all.hdnTxtCcTo.value!="")
			{
			    Control=eval("document.SelectMember.listCcTo");  
				var CcToValueArray = parwin.document.all.hdnTxtCcTo.value.split(",");
				var CcToTxtArray = parwin.document.all.txtCcTo.value.split(",");
				for(i=0;i<CcToValueArray.length-1;i++)
				{
					Control.add(new Option(CcToTxtArray[i],CcToValueArray[i]));
				}
			}
			
			if(parwin.document.all.hdnTxtSendTo.value!="")
			{
			    Control=eval("document.SelectMember.listBccTo");  
				var BccToValueArray = parwin.document.all.hdnTxtBccTo.value.split(",");
				var BccToTxtArray = parwin.document.all.txtBccTo.value.split(",");
				for(i=0;i<BccToValueArray.length-1;i++)
				{
					Control.add(new Option(BccToTxtArray[i],BccToValueArray[i]));
				}
			}
			
			
		}
	}
	function ReturnValue()
	{
		if (window.dialogArguments != null) 
		{
			var parwin = window.dialogArguments;	
		}
		
		 var listSendToTxtStr = "";
		 var listSendToValueStr = "";	
		 var listCcToTxtStr = "";
		 var listCcToValueStr = "";
		 var listBccToTxtStr = "";
		 var listBccToValueStr = "";
		 var listSendToCompleteStr = "";
		 
		 listSendTo = eval("document.SelectMember.listSendTo"); 
		 listCcTo = eval("document.SelectMember.listCcTo"); 
		 listBccTo = eval("document.SelectMember.listBccTo"); 
		 
		 
		 for(i=0;i<listSendTo.length;i++)
		 {
			  listSendToTxtStr+=listSendTo.options[i].text+",";
			  //listSendToValueStr+=listSendTo.options[i].value+","; 
		 }
	     //parwin.document.all.qwsp.txtSendTo.value = listSendToTxtStr;
	    // parwin.document.all.qwsp.hdnTxtSendTo.value = listSendToValueStr;
	     
		
		 for(i=0;i<listCcTo.length;i++)
		 {
			  listCcToTxtStr+=listCcTo.options[i].text+",";
			 // listCcToValueStr+=listCcTo.options[i].value+","; 
		 }
		//parwin.document.all.qwsp.txtCcTo.value = listCcToTxtStr;
	    // parwin.document.all.qwsp.hdnTxtCcTo.value = listCcToValueStr;
	     
		
		 for(i=0;i<listBccTo.length;i++)
		 {
			  listBccToTxtStr+=listBccTo.options[i].text+",";
			 // listBccToValueStr+=listBccTo.options[i].value+","; 
		 }
		// parwin.document.all.qwsp.txtBccTo.value = listBccToTxtStr;
	     //parwin.document.all.qwsp.hdnTxtBccTo.value = listBccToValueStr;
		parent.document.all.reload();
		 window.close();
	}

	function SaveValue()
	{
		if (window.dialogArguments != null) 
		{
			var parwin = window.dialogArguments;	
		}
		
		 var listSendToTxtStr = "";
		 var listSendToValueStr = "";	
		 var listCcToTxtStr = "";
		 var listCcToValueStr = "";
		 var listBccToTxtStr = "";
		 var listBccToValueStr = "";
		 var listSendToCompleteStr = "";
		 
		 listSendTo = eval("document.SelectMember.listSendTo"); 
		 listCcTo = eval("document.SelectMember.listCcTo"); 
		 listBccTo = eval("document.SelectMember.listBccTo"); 
		 
		 
		 for(i=0;i<listSendTo.length;i++)
		 {
			  listSendToTxtStr+=listSendTo.options[i].text+",";
			  listSendToValueStr+=listSendTo.options[i].value+","; 
		 }
	     parwin.document.all.qwsp.txtSendTo.value = listSendToTxtStr;
	     parwin.document.all.qwsp.hdnTxtSendTo.value = listSendToValueStr;
	     
		
		 for(i=0;i<listCcTo.length;i++)
		 {
			  listCcToTxtStr+=listCcTo.options[i].text+",";
			  listCcToValueStr+=listCcTo.options[i].value+","; 
		 }
		 parwin.document.all.qwsp.txtCcTo.value = listCcToTxtStr;
	     parwin.document.all.qwsp.hdnTxtCcTo.value = listCcToValueStr;
	     
		
		 for(i=0;i<listBccTo.length;i++)
		 {
			  listBccToTxtStr+=listBccTo.options[i].text+",";
			  listBccToValueStr+=listBccTo.options[i].value+","; 
		 }
		 parwin.document.all.qwsp.txtBccTo.value = listBccToTxtStr;
	     parwin.document.all.qwsp.hdnTxtBccTo.value = listBccToValueStr;
	     
	
	}
			
		</script>
	</HEAD>
	<body class="body1" MS_POSITIONING="GridLayout">
		<form id="SelectMember" method="post" runat="server">
			<asp:dropdownlist id="listAccount" style="Z-INDEX: 101; LEFT: 72px; POSITION: absolute; TOP: 48px"
				runat="server" Width="148px" Height="312px" multiple ondblclick="AddItem('btnReceSendToRight')"></asp:dropdownlist>
			<INPUT class="buttoncss" style="Z-INDEX: 102; LEFT: 240px; WIDTH: 81px; POSITION: absolute; TOP: 72px; HEIGHT: 24px"
				onclick="AddItem(this.name)" type="button" value=">>>>" name="btnReceSendToRight">
			<INPUT class="buttoncss" style="Z-INDEX: 103; LEFT: 240px; WIDTH: 81px; POSITION: absolute; TOP: 96px; HEIGHT: 24px"
				onclick="RemoveItem(this.name)" type="button" value="<<<<" name="btnReceSendToLeft">
			<asp:DropDownList id="listDept" style="Z-INDEX: 104; LEFT: 72px; POSITION: absolute; TOP: 16px" runat="server"
				Width="100px" AutoPostBack="True" Font-Size="X-Small"></asp:DropDownList><INPUT class="buttoncss" style="Z-INDEX: 105; LEFT: 240px; WIDTH: 81px; POSITION: absolute; TOP: 288px; HEIGHT: 24px"
				onclick="AddItem(this.name)" type="button" value=">>>>" name="btnBccSendToRight"><INPUT class="buttoncss" style="Z-INDEX: 106; LEFT: 240px; WIDTH: 81px; POSITION: absolute; TOP: 312px; HEIGHT: 24px"
				onclick="RemoveItem(this.name)" type="button" value="<<<<" name="btnBccSendToLeft"><INPUT class="buttoncss" style="Z-INDEX: 107; LEFT: 240px; WIDTH: 81px; POSITION: absolute; TOP: 176px; HEIGHT: 24px"
				onclick="AddItem(this.name)" type="button" value=">>>>" name="btnCcSendToRight"><INPUT class="buttoncss" style="Z-INDEX: 108; LEFT: 240px; WIDTH: 81px; POSITION: absolute; TOP: 200px; HEIGHT: 24px"
				onclick="RemoveItem(this.name)" type="button" value="<<<<" name="btnCcSendToLeft">
			<TABLE id="Table1" style="Z-INDEX: 109; LEFT: 344px; WIDTH: 112px; POSITION: absolute; TOP: 32px; HEIGHT: 333px"
				cellSpacing="0" cellPadding="0" width="112" border="0">
				<TR>
					<TD align="center">收件人</TD>
				</TR>
				<TR>
					<TD>
						<SELECT id="listSendTo" style="WIDTH: 181px; HEIGHT: 92px" multiple size="5" name="listSendTo">
						</SELECT></TD>
				</TR>
				<TR>
					<TD align="center">抄报人</TD>
				</TR>
				<TR>
					<TD><SELECT id="listCcTo" style="WIDTH: 181px; HEIGHT: 92px" multiple size="5" name="listCcTo"></SELECT></TD>
				</TR>
				<TR>
					<TD align="center">抄送人</TD>
				</TR>
				<TR>
					<TD><SELECT id="listBccTo" style="WIDTH: 181px; HEIGHT: 92px" multiple size="6" name="listBccTo"></SELECT></TD>
				</TR>
			</TABLE>
			<INPUT class="buttoncss" style="Z-INDEX: 110; LEFT: 200px; WIDTH: 61px; POSITION: absolute; TOP: 384px; HEIGHT: 24px"
				onclick="ReturnValue()" type="button" value="确定"><INPUT class="buttoncss" style="Z-INDEX: 111; LEFT: 336px; WIDTH: 61px; POSITION: absolute; TOP: 384px; HEIGHT: 24px"
				onclick="window.close()" type="button" value="取消">
			<asp:DropDownList id="listZw" style="Z-INDEX: 112; LEFT: 184px; POSITION: absolute; TOP: 16px" runat="server"
				Width="100px" Font-Size="X-Small" AutoPostBack="True" CssClass="input4"></asp:DropDownList>
			<asp:Button id="Button1" style="Z-INDEX: 113; LEFT: 88px; POSITION: absolute; TOP: 384px" runat="server"
				Text="Button"></asp:Button>
		</form>
	</body>
</HTML>
