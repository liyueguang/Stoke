//<script language=javascript>
//*******************************
//* This add by Haichuang Xing
//*******************************
function MM_validateForm() { //v4.0
  var i,p,q,nm,test,num,min,max,errors='',args=MM_validateForm.arguments;
  for (i=0; i<(args.length-2); i+=3) { test=args[i+2]; val=MM_findObj(args[i]);
    if (val) { nm=val.name; if ((val=val.value)!="") {
      if (test.indexOf('isEmail')!=-1) { p=val.indexOf('@');
        if (p<1 || p==(val.length-1)) errors+='- '+nm+' must contain an e-mail address.\n';
      } else if (test!='R') {
        if (isNaN(val)) errors+='- '+nm+' must contain a number.\n';
        if (test.indexOf('inRange') != -1) { p=test.indexOf(':');
          min=test.substring(7,p); max=test.substring(p+1);
          if (val<min || max<val) errors+='- '+nm+' must contain a number between '+min+' and '+max+'.\n';
    } } } else if (test.charAt(0) == 'R') errors += '- '+nm+' is required.\n'; }
  } if (errors) alert('The following error(s) occurred:\n'+errors);
  document.MM_returnValue = (errors == '');return document.MM_returnValue;
}

function MM_findObj(n, d) { //v4.0
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && document.getElementById) x=document.getElementById(n); return x;
}

//�˺���ʵ���б�����ѡ�����ɾ�����Ƶ�������һ���б��еĹ���.2001/04/04
//������
//src	Դ�б�
//des	Ŀ���б�(���ʡ����ɾ��Դ�б���ѡ�е���)
//exce	���Դ�б���ĳһ����ı���˲�����ͬ�����ܱ����߻�ɾ��(��ʡ��)
//d1	ָ��Դ�б����ڵĿ�ܻ򴰿�(��ʡ�����ڵ�ǰ��ܻ򴰿��в���)
//d2	ָ��Ŀ���б����ڵĿ�ܻ򴰿�(��ʡ�����ڵ�ǰ��ܻ򴰿��в���)
//
function SelMove(src,des,check,exce,d1,d2,del) { 	if (!src) return false;
        var oSrc=MM_findObj(src,d1);
        if (!oSrc) return false;
        if (!des) {
                for (i=0;i<oSrc.options.length;i++) {
                        if (oSrc.options(i).selected){
                                if (oSrc.options(i).innerText!=exce) {
                                        oSrc.options.remove(i);
                                        i--;
                                }
                        }
                }
        }
        else {
                var oDes=MM_findObj(des,d2);
                if (!oDes) return false;
                for (i=0;i<oSrc.options.length;i++) {
                        var oSrcOption =oSrc.options.item(i);
                        if(oSrcOption.selected){
                                if(check && check(oDes,oSrcOption)){
                                        if(oSrcOption.innerText!=exce) {
                                                var oOption = document.createElement("OPTION");
                                                oDes.options.add(oOption);
                                                oOption.innerText = oSrcOption.innerText;
                                                oOption.value = oSrcOption.value;
												oSrcOption.selected=false;
                                                if(del) {oSrc.options.remove(i);i--;}
                                        }
                                }
                        }
                }
        }
}

function SelSelectedAll(oSrc){
        if(!oSrc) return false;
        var i;
        for(i=0;i<oSrc.options.length;i++){
                oSrc.options.item(i).selected=true;
        }

}

function SelAdd(oDes,text,value){
        if (!oDes) return false;
        var oOption=document.createElement("OPTION");
        oDes.options.add(oOption);
        oOption.innerText=text;
        oOption.value=value;
}
function SelRemove(oSrc,name,value){
        if(!oSrc) return false;
        var i;
        for(i=0;i<oSrc.options.length;i++){
                if(oSrc.options.item(i).innerText==name && oSrc.options.item(i).value==value) {
                        oSrc.options.remove(i);
                        break;
                }
        }
}
function SelClear(des) {
        var oDes=MM_findObj(des);
        var i;
        if (oDes) {
                for (i=0;i<oDes.options.length;i++) {
                        oDes.options.remove(i);
                        i--;
                }
        }
}

//====================Trim serial function====================
function Trim(string)
{
        var ret = new String(string);
        var i=0;

        while(ret.charAt(i) == " ")
                i++;

        ret = ret.substring(i, ret.length);

        i=ret.length;
        while(ret.charAt(i-1) == " ")
                i--;

        ret = ret.substring(0, i);

        return ret;
}
function LTrim(string)
{
        var ret = new String(string);
        var i=0;

        while(ret.charAt(i) == " ")
                i++;

        ret = ret.substring(i, ret.length);

        return ret;
}
function RTrim(string)
{
        var ret = new String(string);
        var i=0;

        i=ret.length;
        while(ret.charAt(i-1) == " ")
                i--;

        ret = ret.substring(0, i);

        return ret;
}


//����������ΪУ��ĳҳ���е�ĳ�ı������������ֵ�Ƿ񸺺�Ҫ�����ڿ�����ɵ�У���У�
//		�Ƿ�Ϊ��						��R��
//		�Ƿ���һ���Ϸ���Email��ַ		��isEmail��
//		�Ƿ���һ������������			��isDate��
//		�Ƿ���һ����ֵ������			��isNum��
//		�Ƿ�����һ����ָ����Χ�ڵ���ֵ������	��inRangeXX:YY�� ��XXΪ��Сֵ��YYΪ���ֵ
//
//������һ�ο���ɶ���ֶε�У�飬ʹ�÷������£�
//����������Ϊ����һ�飬ÿ��������ĵ�һ������ΪҪ�����ֶε����ƣ��ڶ���������������һ����ֵ���ɣ�
//����������Ϊ���ֶε��������ͣ���ο����������Ĳ���ֵʹ�ã���ĳ�ֶ�Ҫ��������룬�����������Ϊ��R����
//�����ΪһEmail��ַ�������������Ϊ��isEmail��������ֶα������룬�ұ���ΪһEmail��ַ�������������Ϊ��RisEmail����
//�����һ����˵����
//
//	������ҳ�����������ı��������ı�������Ʒֱ�Ϊ��"Name","Email","Age","Money"���ĸ��ֶε�Ҫ��ֱ�Ϊ��
//	Name:			����Ϊ�գ������������κ��ַ���
//	Email:			����Ϊ�գ��ұ�������һ��Email��ַ��
//	Age:			����Ϊ�գ��ұ���Ϊ���֣��ҷ�Χ������18-40֮�䡣
//	Money:			����Ϊ�գ��ұ���Ϊ���֣�����ָ����Χ��
//	����Ҫ���������ֶν��м�飬��ô����Ϊ��
//		X_validateForm("Name","","R","Email","","RisEmail","Age","","RinRange18:40","Money","","RisNum");
//	���Ҫ���Form���м��飬����д��Form��Onsubmit�¼��л��ύ��ť��Onclick�¼���;������������£�
//	onsubmit='return X_validateForm("Name","","R","Email","","RisEmail","Age","","RinRange18:40","Money","","RisNum");'
//
//�˺������÷�Χ��
//�˺���ֻ����������ı���ؼ��ڵ�ֵ���ҿ�����Ӧ���ı���������ͬ������������Щ�ı��򶼽��м�飻
//�������б��������ؼ��ڵ�ֵ������ʹ�ñ���������һ�汾��������ΪMM_validateForm()���÷�����һ����ֻ���䲻�ܼ��
//����ı�����ͬ�����������������»���ʾ����

function X_validateForm() { //v4.0
  var i,p,q,nm,test,num,min,max,errors='',args=X_validateForm.arguments;
  for (i=0; i<(args.length-2); i+=3) { test=args[i+2]; oval=MM_findObj(args[i]); msg=args[i+1];
	if (!oval) continue;
	if(oval.tagName) llength=1;
	else llength=oval.length;
    for(j=0;j<llength;j++) {
		if (llength==1) val=oval;
		else val=oval(j);
	    if (val) { nm=val.name; if ((val=val.value)!="") {
		  if (test.indexOf('isEmail')!=-1) { p=val.indexOf('@');
			if (p<1 || p==(val.length-1)) errors+='- '+(msg==''?nm+' must contain an e-mail address.\n':msg+'\n');
		} else if (test.indexOf('isDate')!=-1) { 
					if (!checkDate(val)) errors+='- '+(msg==''?nm+' must contain a date.(like dd/mm/yyyy")\n':msg+'\n');
			   }
			   else if (test!='R') {
						if (isNaN(val)) errors+='- '+(msg==''?nm+' must contain a number.\n':msg+'\n');
						if (test.indexOf('inRange') != -1) { p=test.indexOf(':');
						min=test.substring(7,p); max=test.substring(p+1);
						if (parseFloat(val)<parseFloat(min) || parseFloat(max)<parseFloat(val)) errors+='- '+(msg==''?nm+' must contain a number between '+min+' and '+max+'.\n':msg+'\n');
		}
		else if(val<0) errors+='- '+(msg==''?nm+' must contain a positive number.\n':msg+'\n');
		} } else if (test.charAt(0) == 'R') errors += '- '+(msg==''?nm+' is required.\n':msg+'\n'); }
	}  
  } if (errors) alert('The following error(s) occurred:\n'+errors);
  document.X_returnValue = (errors == '');
  return document.X_returnValue;
}
/*
��鼰ת������
*/
function checkDate(strDate) {
        strDate=Trim(strDate);
		//alert("sec" + strDate);
        if (strDate.length>10 || strDate.length < 6) return false;
        var j=0;
        for(i=0;i<strDate.length;i++)
                if(isNaN(parseInt(strDate.substring(i,i+1)))) j++;
        if(j!=2) return false;
        var separater="-";
        //if(strDate.indexOf(".")!=-1) separater=".";
        if (strDate.lastIndexOf(separater)==strDate.indexOf(separater)) return false;
        //var dd=strDate.substr(0,strDate.indexOf(separater));
        //var mm=strDate.substring(strDate.indexOf(separater)+1,strDate.lastIndexOf(separater));
        //var yy=strDate.substr(strDate.lastIndexOf(separater)+1);
		var yy=strDate.substr(0,strDate.indexOf(separater));
        var mm=strDate.substring(strDate.indexOf(separater)+1,strDate.lastIndexOf(separater));
        var dd=strDate.substr(strDate.lastIndexOf(separater)+1);
		//alert(dd);
		//alert(mm);
		//alert(yy);
        if (yy.length!=2 && yy.length!=4) return false;
        if (yy.length==2) {
                if (isNaN(parseInt(yy))) return false;
                if (parseInt(yy)<0) return false;
                if (parseInt(yy)>=50) yy="19"+yy;
                else yy="20"+yy;
        }
        if (!isdate(yy+"-"+mm+"-"+dd))	return false;
        return true;
}
/*
���ߣ���־ǿ[hhzqq@21cn.com]
���ڣ�2003-08-09
�汾��1.0
���ܣ��ж�һ���ַ����Ƿ�Ϊ�Ϸ�����
*/

//���ڸ�ʽ��YYYY-MM-DD
function isdate(strDate){
   var strSeparator = "-"; //���ڷָ���
   var strDateArray;
   var intYear;
   var intMonth;
   var intDay;
   var boolLeapYear;

   strDateArray = strDate.split(strSeparator);

   if(strDateArray.length!=3) return false;

   intYear = parseInt(strDateArray[0],10);
   intMonth = parseInt(strDateArray[1],10);
   intDay = parseInt(strDateArray[2],10);

   if(isNaN(intYear)||isNaN(intMonth)||isNaN(intDay)) return false;

   if(intMonth>12||intMonth<1) return false;

   if((intMonth==1||intMonth==3||intMonth==5||intMonth==7||intMonth==8||intMonth==10||intMonth==12)&&(intDay>31||intDay<1)) return false;

   if((intMonth==4||intMonth==6||intMonth==9||intMonth==11)&&(intDay>30||intDay<1)) return false;

   if(intMonth==2){
      if(intDay<1) return false;

      boolLeapYear = false;
      if((intYear%100)==0){
         if((intYear%400)==0) boolLeapYear = true;
      }
      else{
         if((intYear%4)==0) boolLeapYear = true;
      }

      if(boolLeapYear){
         if(intDay>29) return false;
      }
      else{
         if(intDay>28) return false;
      }
   }

   return true;
}
function checkkey(){
        if(event.keyCode==13){
                switch(event.srcElement.tagName){
                        case "INPUT" :
                        {
                                if(event.srcElement.type!="button" && event.srcElement.type!="submit" && event.srcElement.type!="reset")
                                        event.keyCode=9;
                                break;
                        }
                        case "TEXTAREA" :
                        {
                                break;
                        }
                        case "SELECT" :
                                break;
                }
        }
}
//document.onkeydown=checkkey;
//****End*****
//��������ĺ���.
function FormatNumeric(numValue,n){
        if (isNaN(numValue))	//is not numeric
                return numValue;
        if (String(numValue).indexOf(".")==-1)	//no decimal
                return numValue;
        if (String(numValue).substr(String(numValue).indexOf(".")+1).length<=n)
                return numValue;		// decimal less than n
        return String(numValue).substr(0,String(numValue).indexOf(".")+1+n);
}

// ���ֵ�Ƿ�淶��email��ʽ
function checkemail(a)
{	var i=a.length;
        var temp = a.indexOf('@');
        var tempd = a.indexOf('.');
        if (temp > 1) {
                if ((i-temp) > 3){

                                if ((i-tempd)>0){
                                        return true;
                                }

                }
        }
        return false;
}
//</script>
