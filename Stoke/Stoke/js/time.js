var enable=0; today=new Date();
var day; var date;
var time_start = new Date();
var clock_start = time_start.getTime();
if(today.getDay()==0)day="������"
if(today.getDay()==1)day="����һ"
if(today.getDay()==2)day="���ڶ�"
if(today.getDay()==3)day="������"
if(today.getDay()==4)day="������"
if(today.getDay()==5)day="������"
if(today.getDay()==6)day="������"
date=(today.getYear())+"��"+(today.getMonth()+1)+"��"+today.getDate()+"�� ";
document.write("<span>"+date+"&nbsp;&nbsp;");
document.write(day+"</span>");