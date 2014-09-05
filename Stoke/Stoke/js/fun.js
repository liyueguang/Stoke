function ShowCalendar(FieldName)
{
	var height=240;
	var width=310;
	var wHeight=window.screen.availHeight;
	var wWidth=window.screen.availWidth;
			
	var x=(wWidth-width)/2;
	var y=(wHeight-height)/2;

	window.open("../ShowCalendar.aspx?FieldName="+FieldName,"_blank","resizable=no,menubar=no,status=no,toolbar=no,height="+height+",width="+width+",left="+x+",top="+y);
}
function CalcAmount(FieldName1,FieldName2,FieldName3)
{
	
	if(FieldName1.value==""||FieldName2.value=="")
	return;
  FieldName3.value=FieldName1.value*FieldName2.value;
}
function MaterialSearch(FieldName)
{
	var height=540;
	var width=510;
	var wHeight=window.screen.availHeight;
	var wWidth=window.screen.availWidth;
			
	var x=(wWidth-width)/2;
	var y=(wHeight-height)/2;

	window.open("../Test/MaterialSearch.aspx?FieldName="+FieldName,"_blank","resizable=no,menubar=no,status=no,toolbar=no,height="+height+",width="+width+",left="+x+",top="+y);
}
function ShowMachineSearch(FieldName1,FieldName2)
{
var height=440;
	var width=500;
	var wHeight=window.screen.availHeight;
	var wWidth=window.screen.availWidth;
			
	var x=(wWidth-width)/2;
	var y=(wHeight-height)/2;
	window.open("ShowMachineSearch.aspx?FieldName1="+FieldName1+"&FieldName2="+FieldName2,"_blank","resizable=yes,menubar=no,status=no,toolbar=no,height="+height+",width="+width+",left="+x+",top="+y);
}
function ShowNameSpec(FieldName1,FieldName2, FieldName3,FieldName4,FieldName5) 
{
	var height=440;
	var width=500;
	var wHeight=window.screen.availHeight;
	var wWidth=window.screen.availWidth;
			
	var x=(wWidth-width)/2;
	var y=(wHeight-height)/2;
	window.open("ShowNameSpec.aspx?FieldName1="+FieldName1+"&FieldName2="+FieldName2+"&FieldName3="+FieldName3+"&FieldName4="+FieldName4+"&FieldName5="+FieldName5,"_blank","resizable=yes,menubar=no,status=no,toolbar=no,height="+height+",width="+width+",left="+x+",top="+y);
}

function ShowDept(FieldName1,FieldName2,usage) 
{
	var height=410;
	var width=280;
	var wHeight=window.screen.availHeight;
	var wWidth=window.screen.availWidth;
			
	var x=(wWidth-width)/2;
	var y=(wHeight-height)/2;
	window.open("ShowDept.aspx?FieldName1="+FieldName1+"&FieldName2="+FieldName2+"&usage="+usage,"_blank","resizable=yes,menubar=no,status=no,toolbar=no,height="+height+",width="+width+",left="+x+",top="+y);
}

function OpenWindow(href,windowwidth,windowheight)
{
	window.open(href,'_blank','scrollbars=yes, menubar=no,resizable=yes,status=yes,toolbar=no,height='+windowheight+',width='+windowwidth+',left='+(window.screen.availWidth-windowwidth)/2+',top='+(window.screen.availHeight-windowheight)/2);
}

function returnImage1(imagename,width,height) {
	alert('aaa');
	var arr = new Array();
	arr["filename"] = imagename;  
	arr["width"] = width;  
	arr["height"] = height;			 
	window.parent.returnValue = arr;
	alert(imagename);
	window.parent.close();	
}

/**
 *  ²ãµÄÏÔÊ¾Òþ²Ø¿ØÖÆ
 **/  
   function display(obj){
     var o=eval(obj);
     if (o.style.display=="none")
        o.style.display="";
     else
        o.style.display="none";
   }