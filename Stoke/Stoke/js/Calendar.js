/*------------------------------------------------------------------------
  ���ڿؼ�
  function Cal_dropdown(edit,min,max)
    �����������ɲ�������min��max������edit���ޣ����������ͼƬ�ĵ�һ���ֵ�edit��

  function Cal_datevalid(edit,min,max)
    ���edit��ֵ�Ƿ�Ϊ���ڵ���min��С�ڵ���max����Ч���ڸ�ʽ�ַ�����
    ���򷵻� true�����򷵻�false
    �ɲ�������min��max(�ַ�����ʽ)
    ����edit�����У����edit�ޣ�������ǣ�editΪedit��img�ĸ���(��span��div)�ĵ�һ��Ԫ��
  
  �����޸� �ı� 2002-12-25 ������IE 5.0���������
*/

var Cal_popup;
var Cal_edit;
var Cal_editdate = new Date();
var Cal_maxdate;
var Cal_mindate;

function Cal_clearTime(thedate)
{
  thedate.setHours(0);
  thedate.setMinutes(0);
  thedate.setSeconds(0);
  thedate.setMilliseconds(0);
}

var Cal_today = new Date();
Cal_clearTime(Cal_today);

function Cal_decDay(thedate,days)
{
  if(days==0); 
  else if (!days) days = 1;

  thedate.setTime(thedate - days*24*60*60*1000);
}

function Cal_incMonth(year,month)
{
  if (month == 11) {
    month = 0;
    year++;
  } else month++;
  Cal_writeHTML(year,month);
}

function Cal_decMonth(year,month)
{
  if (month == 0) {
    month = 11;
    year--;
  } else month--;
  Cal_writeHTML(year,month);
}

function Cal_decYear(year,month)
{
  Cal_writeHTML(year-1,month);
}

function Cal_incYear(year,month)
{
  Cal_writeHTML(year+1,month);
}

function Cal_writeHTML(theyear,themonth)
{
  var html=
	'<TABLE style="border-bottom:black 1px solid;FONT-SIZE: 9pt;background-color:#CCCCFF;color:white;'+
	'padding-top:2px;font-weight:bold;text-align:center" '+
	'cellSpacing="0" cellPadding="0" width="100%" border="0">'+
	'<TR><TD style="cursor:hand" align="left" width=24 onmouseover="this.style.background=' +
    "'#D8E2F7';" + '"' + ' onmouseout="this.style.background=' + "'#CCCCFF';" + '"' +
    ' onclick="Cal_decYear(' + theyear + ',' + themonth + ');" '+
    '><��</TD>'+
	'<TD style="cursor:hand" align="left" width=24 onmouseover="this.style.background=' +
    "'#D8E2F7';" + '"' + ' onmouseout="this.style.background=' + "'#CCCCFF';" + '"' +
    ' onclick="Cal_decMonth(' + theyear + ',' + themonth + ');" '+
    '><��</TD>'+
	'<TD align="center">';
	
  html += theyear + '��' + (themonth + 1) + '��</TD>'+
    '<TD style="cursor:hand" align="right" width=24 onmouseover="this.style.background=' +
    "'#D8E2F7';" + '"' + ' onmouseout="this.style.background=' + "'#CCCCFF';" + '"' +
    ' onclick="Cal_incMonth(' + theyear + ',' + themonth + ');" '+
    '>��></TD>'+
    '<TD style="cursor:hand" align="right" width=24 onmouseover="this.style.background=' +
    "'#D8E2F7';" + '"' + ' onmouseout="this.style.background=' + "'#CCCCFF';" + '"' +
    ' onclick="Cal_incYear(' + theyear + ',' + themonth + ');" '+
    '>��></TD>';
    
  html +=
	'</TR></TABLE>'+
	'<TABLE style="FONT-SIZE: 9pt;font-weight:bold;text-align:center;border-bottom:black 1px solid" '+
	'cellSpacing="2" cellPadding="0" width="100%" border="0">'+
	'<TR><TD>��</TD><TD>һ</TD><TD>��</TD><TD>��</TD><TD>��</TD><TD>��</TD><TD>��</TD>'+
	'</TR></table>'+
	'<TABLE style="FONT-SIZE: 9pt;text-align:center;cursor:hand" cellSpacing="2" '+
	'cellPadding="0" width="100%" border="0">';

  var day1 = new Date(theyear,themonth,1);
  Cal_decDay(day1,day1.getDay()); // ������ʼ��
  for (var i=1;i<=6;i++) {
    html += '<TR>';
    for (var j=1;j<=7;j++) {
      html += '<TD';
      if (day1.getTime()==Cal_today.getTime())
        html += ' style="color:blue"';
      else
      if (day1.getTime()==Cal_editdate.getTime())
        html += ' style="color:red"';
      else
      if (day1.getMonth() != themonth)
        html += ' style="color:#aaaaaa"';
      html += ' onmouseover="this.style.background=' +
              "'#D8E2F7';" + '"'+
              ' onmouseout="this.style.background=' +
              "'#fffef5';" + '"';
      html += ' onclick="Cal_clickday('+day1.getTime() + ');"';
      html +='>' + day1.getDate() + '</TD>';
      Cal_decDay(day1,-1);
    }
    html += '</TR>';
    if (day1.getMonth() != themonth) break;
  }
	
  html +=
	'</TABLE>'+
	'<div style="border-top:black 1px solid;text-align:center;padding:2px">������ '+
	'<span style="color:blue;cursor:hand;text-decoration:underline" onclick="javascript:Cal_clickday('+
	Cal_today.getTime() + ');">'+
	Cal_today.getFullYear() + '-' + (Cal_today.getMonth()+1) + '-' + Cal_today.getDate() +
	'</span></div>';

  if (!Cal_popup) {
    Cal_popup = document.createElement(
      '<div id="Cal_div1" style="z-index:20000;position: absolute;width:231px;FONT-SIZE:9pt;' +
      'background-color:#fffef5;border:black 1px solid" '+
      'hidefocus=true onclick="Cal_capture_click()" ondblclick="this.click()" '+
      'onmouseover="Cal_capture_mover()" onmouseout="Cal_capture_mout()">');
    document.body.insertAdjacentElement('beforeEnd',Cal_popup);
  }
  Cal_popup.innerHTML = html;
}

function Cal_hide()
{
  Cal_popup.releaseCapture();
  Cal_popup.style.display="none";
}


function Cal_capture_click()
{
  var obj=event.srcElement;
  if (Cal_popup.contains(obj)) {
    if ( (obj!=Cal_popup) && obj.onclick) obj.onclick();
  } else {
    Cal_hide();
  }
}

function Cal_capture_mover()
{
  var obj=event.srcElement;
  if (Cal_popup.contains(obj)) {
    if ( (obj!=Cal_popup) && obj.onmouseover) obj.onmouseover();
  }
}

function Cal_capture_mout()
{
  var obj=event.srcElement;
  if (Cal_popup.contains(obj)) {
    if ( (obj!=Cal_popup) && obj.onmouseout) obj.onmouseout();
  }
}

// �ַ���ת��Ϊ���� 
function Cal_strtodate(str)
{
  var date = Date.parse(str);
  if (isNaN(date)) {
    date = Date.parse(str.replace(/-/g,"/")); // ʶ�����ڸ�ʽ��YYYY-MM-DD 
    if (isNaN(date)) date = 0;
  }
  return(date);
}

//�������ڼ���������
function Cal_DateDiff(Date1, Date2)
{
	return (Date2-Date1)/(24*60*60*1000);
}

//�������ڼ���������(������С��һ����)
function Cal_MonthDiff(DateA, DateB)
{
	Date1=new Date();
	Date2=new Date();
	Date1.setTime(DateA);
	Date2.setTime(DateB);
	months = (Date2.getFullYear() - Date1.getFullYear()) * 12;
	addmonths = Date2.getMonth() - Date1.getMonth();
	months = months + addmonths;
	if(Date2.getDate() < Date1.getDate())
		months--;
	return months;
}

// �����������ɲ�������min��max������edit������ 
function Cal_dropdown(edit,min,max) {
  var DateIMG = window.event.srcElement;
  if (!edit) {
    edit = DateIMG.parentElement.children(0);
    if ((!edit.type) || (edit.type.toLowerCase() != "text")) return;
  }
  if(edit.readOnly) return;
  Cal_edit = edit;
  var date = Cal_strtodate(edit.value);
  if (date == 0) date = Cal_today.getTime();
  if (max) Cal_maxdate = Cal_strtodate(max);
  else Cal_maxdate=0;
  if (min) Cal_mindate = Cal_strtodate(min);
  //else Cal_mindate = 0;  // modified by huhao, 2003/4/30: �󲿷ֵ��ö�û�и�min��max��������Date(0)��1970��1��1�ա�max = 0ʱ��Ϊ�������ƣ����øġ�
  else Cal_mindate = new Date(1900, 1, 1);		
  Cal_editdate.setTime(date);
  Cal_writeHTML(Cal_editdate.getFullYear(),Cal_editdate.getMonth());

  // ��λ
  var pos =
    event.clientX - event.offsetX - DateIMG.offsetLeft
     + edit.offsetLeft - document.body.clientLeft + document.body.scrollLeft;
  var max =
    document.body.scrollLeft + document.body.getBoundingClientRect().right
    - Cal_popup.style.pixelWidth;
  // ����������ȳ�����������
  if (pos > max) Cal_popup.style.left = max;
  else Cal_popup.style.left =  pos;
  
  pos = 
    event.clientY - event.offsetY - DateIMG.offsetTop
    + edit.offsetTop + edit.offsetHeight - document.body.clientTop + document.body.scrollTop;
  // ���������߶ȳ��������ϵ���
  if (pos > document.body.scrollTop + document.body.getBoundingClientRect().bottom - Cal_popup.clientHeight)
    pos -= document.body.clientTop + edit.offsetHeight + Cal_popup.clientHeight; 
  Cal_popup.style.top = pos;
  Cal_popup.style.display="";

  // ��������򵯳��󿴲����������ײ��������Զ���ҳ
//  if (Cal_popup.offsetTop + Cal_popup.offsetHeight + document.body.clientTop>= 
//      document.body.offsetHeight + document.body.scrollTop)
//    document.body.doScroll("scrollbarPageDown");
  
  Cal_popup.setCapture();
}

// ������� 
function Cal_clickday(day,edit)
{
  if (Cal_maxdate != 0) day = Math.min(day,Cal_maxdate);
  day = Math.max(day,Cal_mindate);
  Cal_editdate.setTime(day);
  Cal_edit.value = Cal_editdate.getFullYear() + "-" + (Cal_editdate.getMonth()+1) + "-" 
                   + Cal_editdate.getDate();
  Cal_hide();
  Cal_edit.focus();
}

function Cal_datevalid(edit,min,max)
{
  // ���edit��ֵ�Ƿ�Ϊ���ڵ���min��С�ڵ���max����Ч���ڸ�ʽ�ַ����� 
  
  var date = Cal_strtodate(edit.value);
  if (date == 0) return false;
  if (max) {
    var max = Cal_strtodate(max);
    if ((max!=0)&&(date>max)) return false;
  }
  if (min) {
    var min = Cal_strtodate(min);
    if ((min!=0)&&(date<min)) return false;
  }
  date = new Date(date);
  edit.value = date.getFullYear() + "-" + (date.getMonth()+1) +
			   "-" + date.getDate();
  return true;
}
