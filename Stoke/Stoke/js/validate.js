// JavaScript Document
function is_quotes(form_value){
  if(event.keyCode==39){
      window.alert("���������뵥���ţ�");
      return false;
   }
  return true;
}
function returnLength(str){
	return str.replace(/[^\x00-xff]/g,'**').length
}
//ѡ��ѡ��
function selectAll()
{
   for(i=1;i<act.elements.length;i++)
   {
      a=act.elements[i];
	  if(a.name!='checkall')
	     a.checked=act.checkall.checked;
   }
}
//�򿪴��庯��
function wopen(src,name,top){
   window.open(src,name,"scrollbars=yes,top="+top);
}
//�ж���תҳ
function is_num(form_value,MAX_NUM){
  if(((event.keyCode>57)||(event.keyCode<48))&&(event.keyCode!=13)){
      alert("������Ĳ������֣�");
      return false;
   }
   if((form_value=="")&&((event.keyCode-48)>parseInt(MAX_NUM))){
     alert("����������ֳ�����Χ");
      return false;
   }
   if((form_value!="")&&(parseInt(form_value+""+(event.keyCode-48).toString())>parseInt(MAX_NUM))){
     alert("����������ֳ�����Χ");
      return false;

   }
   return true;
}
function Trim(s){
	s=s.replace(/(^\s*)|(\s*$)/g,"")
	return s
}
function LTrim(s){
	s=s.replace(/(^\s*)/g, "")
	return s
}
function RTrim(s){
	s=s.replace(/(\s*$)/g, "")
	return s
}
function noenter(){
	if(event.keyCode==13){
	return false
	}
}
function checkNum(str){
	return str.match(/\D/)==null
}


//����:��form�����еĵ������滻�����������Ų�����
//�������:myform(form��)
//�������:��
// c-3 textTrim(form����)
function ReplaceComma(myform){
  	var rExp = /\'/gi;
	for(var i=0;i<myform.elements.length;i++){
  		var etype=myform.elements[i].type;

		switch(etype)
		{
		   case "text" :
		      myform.elements[i].value=myform.elements[i].value.replace(rExp,'��');
			  break;
		   case "hidden" :
              if(myform.elements[i].name=='content'){
                  //alert('I met content field, ignore..');
                  break;//��word�༭���е����ݲ��Ӵ����ŵ�����������Java������ΪJavaScript�������ı�ʱ̫��
              }
		      myform.elements[i].value=myform.elements[i].value.replace(rExp,'��');
			  break;
		   case "textarea" :
              myform.elements[i].value=myform.elements[i].value.replace(rExp,'��');
			  break;
		   case "password" :
		      myform.elements[i].value=myform.elements[i].value.replace(rExp,'��');
			  break;
		   default :
		      break;
		}

  	}
}

//����:�ϴ����������ֹ�����
//�������:�ؼ�(this)
//�������:��
function lost(element){
  	element.blur();
}

/**
 * b2b JavaScript ����
 * @author ����(hlian@alleasy.net)
 * @version 1.10
 * #@ validate.js
 * ��һ�� ��鲢���ؼ����(true or false)
 * a-1. ifDigit(String)  �Ƿ�Ϊ����
 * a-2. ifLetter(String) �Ƿ�Ϊ��ĸ
 * a-3. ifDay(String)    �Ƿ�Ϊ����
 * a-4. ifMonth(String)  �Ƿ�Ϊ�·�
 * a-5. ifYear(String)   �Ƿ�Ϊ���
 * a-6. ifDate(String)   �Ƿ�Ϊ����
 * a-7. ifEmail(String)  �Ƿ�Ϊ�ʼ���ַ
 * a-8. ifPhone(String)  �Ƿ�Ϊ�绰����
 * a-9. ifGBK(String)    �Ƿ�Ϊ�����ַ�
 * a-10.ifMoney(String)  �Ƿ�Ϊ�Ϸ���������
 * a-11 ifMoenyRange(String,int,int) �ж��ַ����Ƿ�Ϊ�Ϸ�Ǯ��,���Ƿ񳬹��޶���Χ
 * a-12. checkMonthLength(mm, dd, yyyy) �ж��Ƿ�Ϊ�Ϸ�����
 * a-13. getSelectedButton(buttonGroup) �ж�buttongroupΪ����һ��radio�����ޱ�ѡ�е���
 * a-14. ifSubCollect(Object obj, String[] strCollect) �ж��ַ���str�Ƿ����ַ�����strCollect��
 * a-15 isCheckLeng(str, min, max)  �ַ��������Ƿ���ָ�����ȷ�Χ��
 * a-16 getSelectedNumber(buttonGroup) �жϸ�ѡ���ѡŦ�м�����ѡ��,��������
 * a-17 checkInputIsNumber(e) ���ı������벻Ϊ����ʱֱ�ӱ���
 * a-18 checkMonthData(mm,dd,yyyy) �ж��Ƿ�Ϊ�Ϸ�����,�����·ݺ�����
 * a-19 checkDataF(str) �����YYYY-MM-DD��ʽ����������ַ����Ƿ�Ϊ�Ϸ����ڣ�����Ϊ��
 *		���true or false����falseʱ�������ʾ
 * a-20 function ifErrChar( str ) �ж������ַ������Ƿ��зǷ��ַ�<��>��&
 * �ڶ��� ����ֱ�ӱ���
 * b-1. isDigit(Object)	 �Ƿ�Ϊ����
 * b-2. isLetter(Object) �Ƿ�Ϊ��ĸ
 * b-3. isDay(Object)    �Ƿ�Ϊ����
 * b-4. isMonth(Object)  �Ƿ�Ϊ�·�
 * b-5. isYear(Object)   �Ƿ�Ϊ���
 * b-6. isDate(Object)   �Ƿ�Ϊ����
 * b-7. isEmail(Object)  �Ƿ�Ϊ�ʼ���ַ
 * b-8. isPhone(Object)  �Ƿ�Ϊ�绰����
 * b-9. isGBK(Object)    �Ƿ�Ϊ�����ַ�
 * b-10. isMoney(Object)  �Ƿ�Ϊ�Ϸ���������
 * b-11. isMoneyRange(obj,minValue,maxValue)	�ж��Ƿ�Ϸ�Ǯ�����Ƿ񳬹��޶����
 * b-12. checkLeng(Object, min, max) �ַ��������Ƿ���ָ�����ȷ�Χ��
 * b-13.1 checkValidDate(mmObject,ddObject,yyObject,allowNull)	�����ڽ���ȫ��ļ��
 * b-13.2 checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2)
 *		�����ʼ���ڼ���ֹ����
 * b-14. errorMsg(Object, String) ��ʾ��ʾ��ϢString,��꽹������Object��,����false
 * b-15. showMsg(String, Object)  ��ʾ��ʾ��ϢString,��꽹������Object��,����false
 * b-16. isSubCollect(Object obj, String[] strCollect) �ж��ַ���str�Ƿ����ַ�����strCollect��
 * b-17. checkDataOS(Object obj,String str)�����YYYY-MM-DD��ʽ����������ַ����Ƿ�Ϊ�Ϸ����ڣ�1900-01-01�����죩
 * ������ ���ܺ�������������
 * c-1. getLength(String)  ��ȡ�ַ����ȣ�ÿ�������ַ�Ϊ2���ַ���
 * c-2. trim(String)  ȥ���ַ���ǰ��Ŀո񲢷���
 * c-3. textsTrim(formname)	��form�����е�text�ı�����trim������

 */
//������:Ĭ��
//�ж��ַ����Ƿ�Ϊ�Ϸ�����
// a-1 ifDigit(String)
function ifDigit(obj)
{
	slen=obj.length;
	for (i=0; i<slen; i++){
		cc = obj.charAt(i);
		if (cc <"0" || cc >"9")
		{
			return false;
		}
	}
	return true;
}

//������:����
//����:�ж��ַ����Ƿ�����ĸ
// a-2 ifLetter(String)
function ifLetter( str ){
	if ( str.length == 0 )
		return false;

	str = str.toUpperCase();

	for ( var i = 0 ; i < str.length; i ++ ){
		if ( str.charAt(i) < "A" || str.charAt(i) > "Z" )
			return false;
	}
	return true;
}

// a-3 ifDay(String)
function ifDay(obj)
{
	if (!ifDigit(obj))
	{
		return false;
	}
	if (obj < "01" || obj > "31")
	{
		return false;
	}
	return true;
}

// a-4 ifMonth(String)
function ifMonth(obj)
{
	if (!ifDigit(obj))
	{
		return false;
	}
	if (obj < "01" || obj > "12")
	{
		return false;
	}
}

// a-5 ifYear(String)
function ifYear(obj)
{
	slen=obj.length;
	if (!ifDigit(obj))
	{
		return false;
	}
	if (obj < "1800" || slen < 4)
	{
		return false;
	}
}

// a-6 ifDate(String)
function ifDate(obj)
{
	slen=obj.length;
	if (!ifDigit(obj))
	{
		return false;
	}
	else if (slen < 8)
	{
		return false;
	}
	cc = obj.substr(0,4);
	if (cc < "1800")
	{
		return false;
	}
	cc = obj.substr(4,2);
	if (cc < "01" || cc > "12")
	{
		return false;
	}
	cc = obj.substr(6,2);
	if (cc < "01" || cc > "31")
	{
		return false;
	}
	return true;
}

//������:����
//�ж��ַ����Ƿ�Ϊ�Ϸ��ʼ���ַ
//�����޸�  ˵�������ҽ���һ����@�������С�.�������ҡ�@�������һ����.��ǰ��
//                @�����ǡ�.�����������С�..�������һ���ַ��������ǡ�.��
// a-7 ifEmail(String)
function ifEmail(obj)
{
	i=obj.indexOf("@");
	j=obj.lastIndexOf(".");

	if (i < 1 || j == -1 || obj.indexOf(".")==0 || obj.indexOf(".@")!=-1 || obj.indexOf("..")!=-1 || j==obj.length-1 || i > j || j-i<2 || obj.charAt(i+1)=="." || i!=obj.lastIndexOf("@"))
	{


		return false;
	}
	return true;
}

// a-8 ifPhone(String)
function ifPhone(obj)
{
	slen=obj.length;
	for (i=0; i<slen; i++){
		cc = obj.charAt(i);
		if ((cc <"0" || cc >"9") && cc != "-" && cc!="+" && cc!="(" && cc !=")" && cc !="/")
		{
			return false;
		}
	}
	return true;
}

// a-9 ifGBK(String)
function ifGBK(obj)
{
	slen=obj.length;
	for (i=0; i<slen; i++){
		cc = obj.charAt(i);
		cc = escape(cc);
		if (cc.indexOf("%u") >= 0)
		{
			return false;
		}
	}
	return true;
}

//������:����
//�ж��ַ����Ƿ�Ϊ�Ϸ�Ǯ��
// a-10 ifMoeny(String)
function ifMoney(str){
	if ( ( pos = str.indexOf( "." ) ) != -1 ){
	   if (str.length==1)
	     return false;

	   if ( ( pos = str.indexOf(".", pos + 1) )  != -1 )
	     return false;
	}

	for ( var i = 0 ; i < str.length; i ++ ){
	  if (( str.charAt(i) < "0" || str.charAt(i) > "9" )&&(str.charAt(i)!="."))
	    return false;
	}

	return true;
}

//������:����
//�ж��ַ����Ƿ�Ϊ�Ϸ�Ǯ��,���Ƿ񳬹��޶���Χ
// a-11 ifMoenyRange(String,int,int)
function ifMoneyRange(str,minValue,maxValue)
{
	if(str=="") return true;

	if(!ifMoney(str))
		return false;

	if(parseFloat(str)>=maxValue)
		return false;
	if(parseFloat(str)<minValue)
		return false;
	return true;
}

//������:����
//�ж��Ƿ�Ϊ�Ϸ�����
// a-12 checkMonthLength(mm, dd, yyyy)
function checkMonthLength(mm,dd,yyyy){
    if((mm==4||mm==6||mm==9||mm==11) && dd>30){
      return false;
    }else if(mm==2){
      if(yyyy % 4 >0 && dd>28){
        return false;
      }else if(dd>29){
        return false;
      }
    }else if(dd>31){
      return false;
    }
    return true;
}

//������:����
//�ж�buttongroupΪ����һ��radio�����ޱ�ѡ�е���
// a-13 getSelectButton(buttonGroup)
function getSelectedButton(buttonGroup){
  	for (var i=0;i<buttonGroup.length;i++){
  		if (buttonGroup[i].checked) return true;
  	}
  	return false;
}

//������:����
//�жϸ�ѡ���ѡŦ�м�����ѡ��
// a-16 getSelectedNumber(buttonGroup)
function getSelectedNumber(buttonGroup){
    if(buttonGroup!=null){
  	  j=0;
	  if(buttonGroup.value!=null)
	  {
	    if(buttonGroup.checked){
		       j++;
		}
	  }
	  else{
	    for(i=0;i<buttonGroup.length;i++){
	        if(buttonGroup[i].checked){
		       j++;
		   }
	     }
      }
	  return j;
	}else{
	  return -1;
	}
}


//������:����
//���ı������벻Ϊ����ʱֱ�ӱ���
// a-17 checkInputIsNumber(e)
function checkInputIsNumber(e){
   //alert(e.keyCode);
   if((e.keyCode>=48)&&(e.keyCode<=57))
   {
       return true;
   }else
   {
       alert("����������!");
	   return false;
   }
}

//������:����
//����: ����Ƿ�Ϊ�Ϸ�����
//ʾ��: checkMonthData(12,12,1977)
//�������: ��Ҫ�����ꡢ�¡���
//�������: true or false;
// a-18 function checkMonthData(mm,dd,yyyy)
function checkMonthData(mm,dd,yyyy){

    if(mm<1 || mm>12)
    	return false;
    else{
      if((mm==4||mm==6||mm==9||mm==11) && dd>30){
      		return false;
    	}else if(mm==2){
      		if(( yyyy % 400 ==0 || ( yyyy % 100>0 && yyyy % 4==0)))
      		{
        		if(dd>29)
        			return false;
      		}else if(dd>28){
        		return false;
      		}
    	}else if(dd>31){
      		return false;
      	}
      	if(dd*1==0){
      		return false;
      	}

    	return true;
    }
}


//������:����
//����: ����Ƿ�Ϊ�Ϸ�����
//ʾ��: checkDataF("1999-01-01")
//�������: ��YYYY-MM-DD��ʽ����������ַ���,����Ϊ��
//�������: true or false����falseʱ�������ʾ.
// a-19 function checkDataF(str)
function checkDataF(str)
{
		if(str=="")
			return true;

		var yyyy=str.substr(0,4);
		var mm=str.substr(5,2);
		var dd=str.substr(8,2);

		if(getLength(str)!=10)
		{
			alert(" ������ġ����ա�������10���ַ�!��YYYY-MM-DD��");
   			return false;
		}
		if(str.substr(4,1)!="-" || str.substr(7,1)!="-")
		{
			alert(" ������ġ����ա���ʽ����!��YYYY-MM-DD��");
   			return false;
		}
		if(!ifDigit(yyyy)||!ifDigit(mm)||!ifDigit(dd))
		{
			alert(" ������ġ����ա���ʽ����!�ꡢ�¡����б��������֣���YYYY-MM-DD��");
   			return false;
		}
		if(!checkMonthData(mm,dd,yyyy))
		{
			alert(" ������ġ����ա���ʽ����!���ǺϷ����ڣ���YYYY-MM-DD��");
   			return false;
		}
		return true;

}

//������:����
//����: ����Ƿ��ַǷ��ַ�<��>��&
//ʾ��: ifErrChar("abc&<")
//�������: str
//�������: true or false
//a-20 function ifErrChar( str )

function ifErrChar( str ){
	if ( str.length == 0 )
		return true;

	for ( var i = 0 ; i < str.length; i ++ ){
		if ( str.charAt(i) == "\\" || str.charAt(i) == "<" || str.charAt(i) == ">" || str.charAt(i) == "&" || str.charAt(i) == "\"")
			return false;
	}
	return true;
}

//������:����
//����: ����ִ������Ƿ���ָ����Χ��
//ʾ��: isChekLeng(String, 4,10)
//�������: ��Ҫ���ı��������ƣ���С���ȣ���󳤶�
//�������: true
// a-15 isCheckLeng(str, min, max)
function isCheckLeng(str, min, max){
	slen=getLength(str);
	if (slen < min){
		return false;
	}
	if (slen > max){
		return false;
	}
	return true;
}

//������:Ĭ��
//����: ����Ƿ�Ϊ����
//ʾ��: isDigit(String)
//�������: ��Ҫ���ı���������
//�������: true�������Ϣ
// b-1.1 isDigit(Object)
function isDigit(obj)
{
	slen=obj.value.length;
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if (cc <"0" || cc >"9")
		{
			errorMsg(obj,"����Ϊ���֣�");
			return false;
		}
	}
	return true;
}

//������:����
//����: ����Ƿ�Ϊ����
//ʾ��: isDigitMaxlength(String obj,int length)
//�������: ��Ҫ���ı���������,�������󳤶�
//�������: true�������Ϣ
// b-1.2 isDigitMaxlength(Object,maxlength)
function isDigitMaxlength(obj,maxlength)
{
	obj.value=trim(obj.value);
	slen=obj.value.length;
	if(slen>maxlength){
		errorMsg(obj,"�������Ϊ"+maxlength+"��");
		return false;
	}

	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if (cc <"0" || cc >"9")
		{
			errorMsg(obj,"����Ϊ���֣�");
			return false;
		}
	}
	return true;
}

//������:����
//����:�ж��ַ����Ƿ�����ĸ
// b-2 isLetter(Object)
function isLetter(obj){
	str = obj.value;
	if ( str.length == 0 )
		return false;
	str = str.toUpperCase();
	for ( var i = 0 ; i < str.length; i ++ ){
		if ( str.charAt(i) < "A" || str.charAt(i) > "Z" )
			errorMsg(obj, "����Ϊ�ַ���");
			return false;
	}
	return true;
}

// b-3 isDay(Object)
function isDay(obj)
{
	if (!ifDigit(obj.value))
	{
		return false;
	}
	if (obj.value < "01" || obj.value > "31")
	{
		errorMsg(obj,"�ո�ʽ������ȷ�ĸ�ʽΪ��DD,��:02");
		return false;
	}
	return true;
}

// b-4 isMoneth(Object)
function isMonth(obj)
{
	if (!ifDigit(obj.value))
	{
		return false;
	}
	if (obj.value < "01" || obj.value > "12")
	{
		errorMsg(obj,"�·ݸ�ʽ������ȷ�ĸ�ʽΪ��MM,��:01");
		return false;
	}
}

//�����ߣ�Ĭ��
//���ܣ�����Ƿ�Ϸ����
//ʾ����isYear(Object)
//���������������ַ���
//���������true �� ������Ϣ
// b-5 isYear(Object)
function isYear(obj)
{
	slen=obj.value.length;
	if (!ifDigit(obj.value))
	{
		errorMsg(obj,"�������󣬲��ܺ��з����ֵ��ַ���");
		return false;
	}
	if (obj.value < "1800" ||obj.value>"2100"|| slen < 4)
	{
		errorMsg(obj,"��ݸ�ʽ������ȷ�ĸ�ʽΪ��YYYY,��:1999");
		return false;
	}

return true;
}

//�����ߣ�Ĭ��
//���ܣ�����Ƿ�Ϸ�����
//ʾ����isDate(Object)
//���������������ַ���
//���������true �� ������Ϣ
// b-6 isDate(Object)
function isDate(obj)
{
	slen=obj.value.length;
	if (!ifDigit(obj.value))
	{
		errorMsg(obj,"�������󣬲��ܺ��з����ֵ��ַ���");
		return false;
	}
	else if (slen < 8)
	{
		errorMsg(obj,"���ڸ�ʽ������ȷ�ĸ�ʽΪ��YYYYMMDD,��:19990102");
		return false;
	}
	cc = obj.value.substr(0,4);
	if (cc < "1800")
	{
		errorMsg(obj,"��ݸ�ʽ������ȷ�ĸ�ʽΪ��YYYY,��:1999");
		return false;
	}
	cc = obj.value.substr(4,2);
	if (cc < "01" || cc > "12")
	{
		errorMsg(obj,"�·ݸ�ʽ������ȷ�ĸ�ʽΪ��MM,��:01");
		return false;
	}
	cc = obj.value.substr(6,2);
	if (cc < "01" || cc > "31")
	{
		errorMsg(obj,"�ո�ʽ������ȷ�ĸ�ʽΪ��DD,��:02");
		return false;
	}
	return true;
}

// b-7 isEmail(Object)
function isEmail(obj)
{
	i=obj.value.indexOf("@");
	j=obj.value.lastIndexOf(".");
	// if (! ifGBK(obj)) i = -1;
	if (i == -1 || j == -1 || i > j)
	{
		errorMsg(obj,"Email��д����");
		return false;
	}
	return true;
}

// b-8 isPhone(Object)
function isPhone(obj)
{
	slen=obj.value.length;
	if (slen <1)
	{
		errorMsg(obj, "��ϢΪ�գ����޸ģ�");
		return false;
	}
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if ((cc <"0" || cc >"9") && cc != "-" && cc!="+" && cc!="(" && cc !=")" && cc !="/")
		{
			errorMsg(obj,"����Ϊ���֣�");
			return false;
		}
	}
	return true;
}

// b-9 isGBK(Object)
function isGBK(obj)
{
	slen=obj.value.length;
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		cc = escape(cc);
		if (cc.indexOf("%u") >= 0)
		{
			errorMsg(obj,"�����Ϊ���֣�");
			return false;
		}
	}
	return true;
}

//������:����
//�ж��ַ����Ƿ�Ϊ�Ϸ�Ǯ��
// b-10 isMoney(Object)
function isMoney(obj)
{
	if (ifMoney(obj.value))
	{
		return true;
	}
	else
	{
		errorMsg(obj, "���ǺϷ��Ļ�������");
		return false
	}
	return true;
}

//������:����
//�ж��Ƿ�Ϸ�Ǯ�����Ƿ񳬹��޶����
//b-11 isMoneyRange(obj,minValue,maxValue)
function isMoneyRange(obj,minValue,maxValue)
{
	obj.value=trim(obj.value);
	if(obj.value=="") return true;

	if(!ifMoney(obj.value))
		return shoMsg("���ǺϷ��Ļ�������",obj);

	if(parseFloat(obj.value)>=maxValue)
		return showMsg("����ֵ����",obj);
	if(parseFloat(obj.value)<minValue)
		return showMsg("����ֵ��С��",obj);
	return true;
}


//������:����
//�ж��Ƿ�Ϸ�Ǯ�����Ƿ񳬹��޶����
//b-11 isMoneyRange(obj,minValue,maxValue)
function isDigitInRange(obj,minValue,maxValue)
{
	obj.value=trim(obj.value);
	if(obj.value=="") return true;

	if(parseFloat(obj.value)>=maxValue)
		return showMsg("����\n\t��ֵ����\n��ֵ�Ϸ�ȡֵ��Χ��" + minValue + "-" + maxValue + ".", obj);
	if(parseFloat(obj.value)<minValue)
		return showMsg("����\n\t��ֵ��С��\n��ֵ�Ϸ�ȡֵ��Χ��" + minValue + "-" + maxValue + ".", obj);
	return true;
}

//������:����
//����: ����ֶγ����Ƿ���ָ����Χ��
//ʾ��: chekLeng(form1.t1, 4,10)
//�������: ��Ҫ���ı��������ƣ���С���ȣ���󳤶�
//�������: true
// b-12 checkLeng(obj, min, max)
function checkLeng(obj, min, max)
{
	slen=getLength(obj.value);
	if (slen < min)
	{
		errorMsg(obj,"���������� " + min + " ���ַ���");
		return false;
	}
	if (slen > max)
	{
		errorMsg(obj,"��������� " + max + " ���ַ���");
		return false;
	}
	return true;
}

function checkLengNotFocus(obj, min, max)
{
	slen=getLength(obj.value);
	if (slen < min)
	{
		errorMsgNotFocus(obj,"���������� " + min + " ���ַ���");
		return false;
	}
	if (slen > max)
	{
		errorMsgNotFocus(obj,"��������� " + max + " ���ַ���");
		return false;
	}
	return true;
}


//������:����
//����:�����ڽ���ȫ��ļ��
//�������:mmObject:�µ�object;ddObject:�յ�object;yyObject:���object;
//�������:allowNull:true��������Ϊ��;false:����ѡ������
//�������:ture of false;
// b-13.1 checkValiDate(mmObject,ddObject,yyObject,allowNull)
function checkValidDate(mmObject,ddObject,yyObject,allowNull){
  	if(allowNull){
  		if(!(((!yyObject.options[0].selected)&&(!mmObject.options[0].selected)&&(!ddObject.options[0].selected)) || ((yyObject.options[0].selected)&&(mmObject.options[0].selected)&&(ddObject.options[0].selected))))
  			return showMsg("���ڱ���ȫ��ѡ�����ȫ����ѡ��!",yyObject);
  	}else{
  		if(yyObject.options[0].selected){
  			return showMsg("��ѡ�����ڵ���!",yyObject);
  		}
  		if(mmObject.options[0].selected){
  			return showMsg("��ѡ�����ڵ���!",mmObject);
  		}
  		if(ddObject.options[0].selected){
  			return showMsg("��ѡ�����ڵ���!",ddObject);
  		}
  	}

  	if(!yyObject.options[0].selected){
  		var my_year=yyObject[yyObject.selectedIndex].value;
  		var my_month=mmObject[mmObject.selectedIndex].value;
  		var my_day=ddObject[ddObject.selectedIndex].value;

  		if(!checkMonthLength(my_month,my_day,my_year))
  			return showMsg("ѡ������ڲ��Ϸ�!",ddObject);
  	}
  	return true;
}


//������:����
//����:�����ڽ���ȫ��ļ��
//�������:mmObject1:��ʼ�µ�object;ddObject1:��ʼ�յ�object;yyObject1:��ʼ���object;
//�������:allowNull1:��ʼ����true��������Ϊ��;false:����ѡ������
//�������:mmObject2:��ֹ�µ�object;ddObject2:��ֹ�յ�object;yyObject2:��ֹ���object;
//�������:allowNull2:��ֹ����true��������Ϊ��;false:����ѡ������
//�������:ture of false;
// b-13.2 checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2)
function checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2){
	if(!checkValidDate(mmObject1,ddObject1,yyObject1,allowNull1)) return false;
	if(!checkValidDate(mmObject2,ddObject2,yyObject2,allowNull2)) return false;

	if((!yyObject1.options[0].selected) && (!yyObject2.options[0].selected)){
		date1=new Date(yyObject1[yyObject1.selectedIndex].value-1900,mmObject1[mmObject1.selectedIndex].value-1,ddObject1[ddObject1.selectedIndex].value);
		date2=new Date(yyObject2[yyObject2.selectedIndex].value-1900,mmObject2[mmObject2.selectedIndex].value-1,ddObject2[ddObject2.selectedIndex].value);
		if(date1>date2){
			return showMsg("��ʼ���ڲ��ܴ��ڽ�ֹ���ڣ�",yyObject1);
		}
	}
	return true;
}

// ����
// b-14 errorMsg(Object, String)
function errorMsg(obj,msg)
{
	//obj.value="";
	alert(msg);
//	obj.focus();
	return false;
}

function errorMsgNotFocus(obj,msg)
{
	//obj.value="";
	alert(msg);
	return false;
}

//������:����
//����:��ʾ��ʾ��ϢMsg,��꽹������Obj��,����false
//     ��Ҫ���ڼ���Ҫ�ֶ��Ƿ���ȷ
//ʾ��:showMsg("�û�������Ϊ��.",myform.username)
//�������:Msg(��ʾ��Ϣ) Obj(��꽹�����)
//�������:false
// b-15 showMsg(String, Object)
function showMsg(Msg, Obj)
{
	alert( Msg );
	Obj.focus();
	return false;
}

// b-17. checkDataOS(Object obj,String str)
//������:����
//����: ����Ƿ�Ϊ�Ϸ�����1900-01-01������
//ʾ��: checkDataOS(form.birthday,"1999-01-01")
//�������: obj,�۽�����; str��YYYY-MM-DD��ʽ����������ַ���,����Ϊ��
//�������: true or false
// b-17. checkDataOS(Object obj,String str)
//�޸���:κ־��
//ԭ�����ڸ�Ϊ__��__��__������
//�������������ֶ���"-"���Ӻ���ã����޸���ʾ��Ϣ
function checkDataOS(obj,str)
{

		if(str=="")
			return true;

		var yyyy=str.substr(0,4);
		var mm=str.substr(5,2);
		var dd=str.substr(8,2);

		if(getLength(str)!=10)
		{
			errorMsg(obj,"ע�⣺\n\    ������ġ����ա���ʽ����!��YYYY��MM��DD�գ�");
   			return false;
		}
		//if(str.substr(4,1)!="-" || str.substr(7,1)!="-")
		//{
		///	errorMsg(obj,"ע�⣺\n\     ������ġ����ա���ʽ����!��YYYY��MM��DD�գ�");
   		//	return false;
		//}

		if(!ifDigit(yyyy)||!ifDigit(mm)||!ifDigit(dd))
		{
			errorMsg(obj,"ע�⣺\n\     ������ġ����ա���ʽ����!�ꡢ�¡����б��������֣���YYYY��MM��DD�գ���");
   			return false;
		}
		if(!checkMonthData(mm,dd,yyyy))
		{
			errorMsg(obj,"ע�⣺\n\     ������ġ����ա���ʽ����!���ǺϷ����ڣ���YYYY��MM��DD�գ�");
   			return false;
		}
		if(yyyy<1900)
		{
			errorMsg(obj,"ע�⣺\n\     �����롶���ա���ʽ����!���ڳ���ϵͳ��Χ����ֲ���������1900�꣡\n  ����������!");
   			return false;
		}
		if(new Date(yyyy,mm-1,dd).getTime()>new Date().getTime())
		{
			errorMsg(obj,"ע�⣺\n\     �����롶���ա���ʽ����!���ڳ���ϵͳ��Χ����������ڽ��죡\n  ����������!");
   			return false;
		}
		return true;

}

/**
�����ǵ�����
*/
//������:����
//�����˺��ֵĳ����ж�
// c-1 getLength(String)
function getLength(str){
	var templen=str.length;
	if(navigator.appName=='Netscape') return templen;
	for(var i=0;i<str.length;i++){
    		var rstr=escape(str.substring(i,i+1));
    		if (rstr.substring(0,2)=="%u"){
       			templen++;
    		}
  	}
	return templen;
}
function getChinesLength(str){
	var templen=str.length;
	var asclen=0;
	var chineselen=0;
	var bhaveChines=false;
	if(navigator.appName=='Netscape') return templen;
	for(var i=0;i<str.length;i++){
    		var rstr=escape(str.substring(i,i+1));
    		if (rstr.substring(0,2)=="%u"){
       			chineselen++;
       			bhaveChines=true;
    		}
  	}
  	if(bhaveChines){
  	asclen=templen-chineselen;
  	templen=asclen*1+chineselen*1;
}

	return templen;
	}

//������:����
//����:ȥ���ַ���ǰ��Ŀո񲢷���
//�������:inputStr(��������ַ���)
//�������:inputStr(�������ַ���)
// c-2 trim(String)
function trim(inputStr) {
	var result = inputStr
	while (result.substring(0,1) == " ") {
		result = result.substring(1,result.length)
	}

	while (result.substring(result.length-1, result.length) == " ") {
		result = result.substring(0, result.length-1)
	}

	return result
}


//������:����
//����:��form�����е�text�ı�����trim������
//�������:myform(form��)
//�������:��
// c-3 textTrim(form����)
function textsTrim(myform){
  	for(var i=0;i<myform.elements.length;i++){
  		var etype=myform.elements[i].type;
  		if(etype == "text"){
 			myform.elements[i].value=trim(myform.elements[i].value);
  		}
  	}
}


// �����ߣ�����
// ���ܣ��ж��ַ���str�Ƿ����ַ�����strCollect��
// ���������obj �ַ����ֶ�
// ���������strCollect �ַ�����
// ���������true or false �����򲻰���
function ifSubCollect(obj, strCollect)
{
    str = obj.value;
	var validCount = 0;
	var collectStr = "";
	for(i=0;i<strCollect.length;i++)
	{
		if (str == strCollect[i])
			validCount++;
		collectStr +=strCollect[i] + ",";
	}
	if (validCount < 1)
	    return false;
	else
	    return true;
}

// �����ߣ�����
// ���ܣ��ж��ַ���str�Ƿ����ַ�����strCollect��
// ���������obj �ַ����ֶ�
// ���������strCollect �ַ�����
// ���������true or false �����򲻰���
function isSubCollect(obj, strCollect)
{
    str = obj.value;
	var validCount = 0;
	var collectStr = "";
	for(i=0;i<strCollect.length;i++)
	{
		if (str == strCollect[i])
			validCount++;
		collectStr +=strCollect[i] + ",";
	}
	if (validCount < 1)
	{
	    alert("��Ԥ����Ϣ����\n " +collectStr + "\nû�а�����Ϣ\t" + str );
	    return false;
	}
	else
	    return true;
}

// �����ߣ�����
// �Ƚ� ���� 2001-11-10, 2001-11-11 ����������
// dateStr1 �Ƿ�� dateStr2 С
// dateStr1 �����ַ���1
// dateStr2 �����ַ���2
function compareDate(dateStr1, dateStr2)
{
	dt1 = isoParseDate(dateStr1);
	dt2 = isoParseDate(dateStr2);
	if (dt1 > dt2)
		return false;
	else
		return true;
}

// �����ߣ�����
// �Ƚ� ���� 2001-11-10, 2001-11-11 �����������Ƿ����
// dateStr1 �����ַ���1
// dateStr2 �����ַ���2
function ifDateEq(dateStr1, dateStr2)
{
	dt1 = isoParseDate(dateStr1);
	dt2 = isoParseDate(dateStr2);
	// ��Ҫ�� dt1 == dt2 ����û�з�Ӧ��
	if (dt1 > dt2 || dt1 < dt2)
		return false;
	else
		return true;
}
// �����ߣ�����
// ������ 2001-11-10 ������ת��Ϊjavascript�е����ڶ���
// dateStr1 �����ַ���
// dt ����
function isoParseDate(dateStr1)
{
	re = /-/gi;
	dateStr1 = dateStr1.replace(re, "/");
	dt = new Date();
	dt.setTime(Date.parse(dateStr1))
	return dt;
}

// �����ߣ�����
// ��ȡ���������ַ��������� 2001/11/10
function getTodayStr()
{
       tday = new Date();
       tYear = tday.getYear();
       tMonth = tday.getMonth()+1;
       tDay = tday.getDate();
       tDayString = tYear + "/" + tMonth + "/" + tDay
       return tDayString;
}

// �����ߣ�����
// ��ȡ���쿪ʼʱ�䣬��Javascript�����ڶ����ʽ
function getTodayTime()
{
       tday = new Date();
       tDayString = getTodayStr();
       tday.setTime(Date.parse(tDayString))
       return tday;
}

// �����ߣ�����
// �ж��Ƿ�Ϸ��û���
function ifValidUserName(username)
{
  var validWord = "abcdefghijklmnopqrstuvwxyzABCDEDFHIJKLMNOPQRSTUVWXYZ_.";
  for (i=0; i<username.length; i++)
  {
          cc = username.charAt(i);
          if (!((cc >= 'a' && cc <= 'z') || (cc >= 'A' && cc <= 'Z') || (cc >= '0' && cc <= '9') || cc == '_' || cc == '.'))
          {
         	return false;
          }
  }
  return true;
}

// �����ߣ�����
// �ж��Ƿ�Ϸ��û��б�
function isValidUserName(obj)
{
  var userlist = obj.value;
  if (!ifValidUserList(userlist))
  {
      showMsg("ע�⣺\n    ���ṩ���û��� " + username + " ���ǺϷ����û����������¸������޸��û�����", obj)
      return false;
  }
  else
    return true;
}

// �����ߣ�����
// �ж��Ƿ�Ϸ��û��б�
function ifValidUserList(userlist)
{
//  arrayOfUser = new Array();
//  arrayOfUser = userlist.split(",");
//
//  for (i=0; i<arrayOfUser.length; i++)
//  {
//    if (!ifValidUserName(arrayOfUser[i]))
//      return false;
//  }
  for (i=0; i<userlist.length; i++)
  {
          cc = userlist.charAt(i);
          if (!((cc >= 'a' && cc <= 'z') || (cc >= 'A' && cc <= 'Z') || (cc >= '0' && cc <= '9') || cc == ',' || cc == ' ' || cc == '_' || cc == '.'))
          {
         	return false;
          }
  }
  return true;
}

// �����ߣ�����
// �ж��Ƿ�Ϸ��û��б�
function isValidUserList(obj)
{
  userlist = obj.value;
  arrayOfUser = new Array();
  arrayOfUser = userlist.split(",");

  for (i=0; i<arrayOfUser.length; i++)
  {
    if (!ifValidUserName(arrayOfUser[i]))
    {
      showMsg("ע�⣺\n    ���ṩ���û��� " + arrayOfUser[i] + " ���ǺϷ����û����������¸������޸��û�����", obj)
      return false;
    }
  }
  return true;
}

// �����ߣ�����
// �����龫��
// ������userlist �ַ�������
// ���أ�newlist ���ַ�������
function marrowArray(userlist)
{
	newlist = new Array();
	var j = 0;
	for (var i = 0; i < userlist.length; i++)
	{
		if (!isContains(newlist, userlist[i]))
		{
			newlist[j] = userlist[i];
			j++
		}
	}
	return newlist;

}

// �����ߣ�����
// �ж�һ���ַ����Ƿ���һ���б���
// ������userlist �ַ�������
// ������username �ַ���
// ���أ�true ���û����б���
//	false ���û������б���
function isContains(userlist, username)
{
	var userCount = 0;
	for(var i = 0 ; i < userlist.length; i++)
	{
		if (userlist[i] == username)
			return true;
	}
	return false;
}

// �����ߣ�����
// ��һ���ַ�������ת��Ϊ�б���Ϣ
// ������userlist �ַ�������
// ���أ��ַ��������б���Ϣ
function arrayToString(userlist)
{
	var userstr = "";
	for(var i = 0 ; i < userlist.length; i++)
	{
		userstr+= userlist[i];
		if (i < userlist.length-1)
			userstr+=",";
	}
	return userstr;
}


// ֻ������������
function onlyDigit(obj, e){
  if((e.keyCode>=48)&&(e.keyCode<=57)){
    return true;
  }else if(e.keyCode==13){
    return true;
  }else{
    e.keyCode=0;
    alert("ע�⣺\n    ֻ�����������֡�\n    ���޸ĺ������ύ��");
    return false;
  }
}

// ���ECMϵͳ���룬ֻ����Ϊ����
// 2002-04-01
function checkEcmPass(obj)
{
	var ecmpass = obj.value;

	if (getLength(ecmpass) < 1)
	{
  		alert("ע�⣺\n    ��û�����롶���롷��Ϣ!\n    ������涨�����ڵ�����!");
  		obj.focus();
   		return false;
	}
	if (getLength(ecmpass) < 6 )
	{
        	alert("ע�⣺\n    Ϊ�˰�ȫ��������ġ����롷����Ϊ6λ!\n    ������涨�����ڵ�����!");
        	obj.focus();
        	return false;
	}
	if (getLength(ecmpass) > 6 )
	{
        	alert("ע�⣺\n    ������ġ����롷�����˹涨��6λ!\n    ������涨�����ڵ�����!");
        	obj.focus();
        	return false;
	}
        if (!ifGBK(ecmpass))
        {
           alert("ע�⣺\n\    ������ġ����롷������Ϊ����!\n    ���޸ĺ������ύ��");
           obj.focus();
           return false;
        }
	if (!ifDigit(ecmpass))
	{
           alert("ע�⣺\n    �����롷������ʹ�����֣��������˲������ֵ��ַ���\n    ���޸ĺ������ύ��");
           obj.focus();
           return false;
	}
	return true;
}

/**
 * ��ȡһ�������Ӵ�
 * cnstr �������ĵ��ַ�����Ϣ
 * getleng ��ȡ����
 * result �����ַ���
 */
function getSubString(cnstr, getleng)
{
	if(navigator.appName=='Netscape')
		return cnstr.substring(0, getleng);
	var templen = 0;
	var result ="";
	for(var i=0; i<cnstr.length; i++)
	{
    		var rstr=escape(cnstr.substring(i,i+1));
    		if (rstr.substring(0,2)=="%u")
      			templen+=2;
       		else
    			templen++;
    		if (templen > getleng)
    		{
    			result = cnstr.substring(0, i);
    			return result;
    		}

  	}
}
function showpart(aTitles,len_show)
{
  var sTemp="";
  var slen=aTitles.length;
  var i=1;

  if(slen>len_show*1)
   {
   for(i=1;(len_show*1)*i<slen;i++){
    sTemp+= aTitles.substring(len_show*(i-1),len_show*i)+" ";
    }
     sTemp+=aTitles.substring(len_show*(i-1),slen);
   }
   else
     sTemp=aTitles;

 document.write(sTemp);
}

function getPartString(sourceStr,len_show)
{
  var sTemp="";
  var slen=sourceStr.length;
  var i=1;

   if(slen>(len_show*1+2))
   {
   	sTemp = sourceStr.substring(0,len_show);
   	sTemp = sTemp+"...";
   }
   else
     sTemp=sourceStr;

   return sTemp;
}

function writeName(strCid)
{
	if(strCid=="")
		return;
	var cids = strCid.split(",");
	if(cids.length==1)
	{
		document.write(getNameByCID(strCid));
	}
	else
	{
		var myNames;
		myNames = getNameByCID(cids[0]);
		for(i=1;i<cids.length;i++)
		{
			myNames = myNames + "," + getNameByCID(cids[i]);
		}
		document.write(getPartString(myNames,8));
	}
}

function writeAllName(strCid)
{
	if(strCid=="")
		return;
	var cids = strCid.split(",");
	if(cids.length==1)
	{
		document.write(getNameByCID(strCid));
	}
	else
	{
		var myNames;
		myNames = getNameByCID(cids[0]);
		for(i=1;i<cids.length;i++)
		{
			myNames = myNames + "," + getNameByCID(cids[i]);
		}
		document.write(myNames);
	}
}


function getAllName(strCid)
{
	if(strCid=="")
		return;
	var cids = strCid.split(",");
	if(cids.length==1)
	{
		return getNameByCID(strCid);
	}
	else
	{
		var myNames;
		myNames = getNameByCID(cids[0]);
		for(i=1;i<cids.length;i++)
		{
			myNames = myNames + "," + getNameByCID(cids[i]);
		}
		return myNames;
	}
}

//�����ַ������ӻ���
function getLinesString(sourceStr,len_show)
{
  var sTemp="";
  var slen=sourceStr.length;
  var i=1;
  var lenchars=slen/2;
  if(lenchars<20)
  	lenchars=len_show;
   if(slen>(len_show*1))
   {
   	sTemp = sourceStr.substring(0,lenchars);
   	sTemp = sTemp+" ";
   	sTemp = sTemp+sourceStr.substring(lenchars,sourceStr.length);
   }
   else
     sTemp=sourceStr;

   return sTemp;
}

function realTimeCheckPassword(obj, e)
{
   if(obj.value.length>=6 && e.keyCode!=13)
   {
   	alert("ע�⣺\n    ֻ��������6λ���֡�\n    ���޸ĺ������ύ��");
   	return false;
   }
   return onlyDigit(obj, e);
}

function check_information(info,area)
{
   temp = info.value.split(",");
   //alert(temp.length);
   last_num = "";

  for(a=0;a<temp.length;a++)
  {
	//alert(temp[a]);
    if(area=="sms" || area =="mobile")
	  {
		for (i=0; i<temp[a].length; i++)
				{
		           cc = temp[a].charAt(i);
		           if ((cc <"0" || cc >"9") && cc!="+")
		              {
			             if(area=="sms")
						     alert("�������˷����ֵĶ��ź��룬���ʵ�����룡");
						 if(area=="mobile")
							 alert("�������˷����ֵ��ƶ��绰���룬���ʵ�����룡");
			             return false;
		              }
	            }
            //����
			if (temp[a].charAt(0) == "0" && temp[a].charAt(1) == "0")
			{
				if (temp[a].length > 20)
				{
					if(area=="sms")
				    alert("��������ֻ����ź����������ʵ�����룡");
				    if(area=="mobile")
					alert("��������ƶ��绰����λ���������ʵ�����룡");
				    return false;
				}
			}else{
			if(temp[a].length != 11 && temp[a].length != 12)
			{
				//alert("1");
				if(area=="sms")
				    alert("��������ֻ����ź����������ʵ�����룡");
				if(area=="mobile")
					alert("��������ƶ��绰����λ���������ʵ�����룡");
				return false;
			}
			if(temp[a].length == 11)
		    {
				if((temp[a].charAt(0) != "1")||(temp[a].charAt(1) != "3"))
				{
					if(area=="sms")
				    alert("��������ֻ����ź����������ʵ�����룡");
				if(area=="mobile")
					alert("��������ƶ��绰����λ���������ʵ�����룡");
				return false;
				}
		    }
		    if(temp[a].length == 12)
		    {
				//alert("test");
				if(temp[a].charAt(0) != "0")
				{
					if(area=="sms")
				    alert("��������ֻ����ź����������ʵ�����룡");
				if(area=="mobile")
					alert("��������ƶ��绰����λ���������ʵ�����룡");
				return false;
				}
		    }
			}
		}

   if(area == "mail")
	{
	   i=temp[a].indexOf("@");
	   j=temp[a].lastIndexOf(".");

	if (i < 1 || j == -1 || temp[a].indexOf(".")==0 || temp[a].indexOf(".@")!=-1 || temp[a].indexOf("..")!=-1 || j==temp[a].length-1 || i > j || j-i<2 || temp[a].charAt(i+1)=="." || i!=temp[a].lastIndexOf("@"))
	{
		alert("��������ʼ���ַ�������������룡");
		return false;
	}
	}

   if(area == "fax")
	{
	    for (k=0; k<temp[a].length; k++)
				{
		           cc = temp[a].charAt(k);
		           if ((cc <"0" || cc >"9") && cc != "-")
		              {
			             alert("�������˷����ֵĴ�����룬���������룡");
			             return false;
		              }
	            }

		if(temp[a].split("-").length == 1)
		{
		//�Ƿ���ʳ�;
		   if(temp[a].charAt(0)=="0" && temp[a].charAt(1)=="0")
			{
			    alert("������Ĵ������λ���������������룡");
				return false;
			 }else{
		   //����
		      if(temp[a].charAt(0) == '0' || temp[a].length > 8 || temp[a].length < 6)
			   {
			     alert("������Ĵ������λ���������������룡");
				 return false;
			   }
		     }
		 last_num = "-" + temp[a];
        }

	   if(temp[a].split("-").length == 2)
		{
		   temp1 = temp[a].split("-");

		   //�Ƿ���ʳ�;
		   if(temp1[0].charAt(0)=="0" && temp1[0].charAt(1)=="0")
			{
			   tmp_value = temp1[0] + temp1[1];
			   if (tmp_value.length > 20)
			   {
			      alert("������Ĵ������λ���������������룡");
			      return false;
			   }
			   last_num = temp1[0] + "-" + temp1[1];
			}else{
		   //����
		      if(temp1[0].charAt(0) != "0" || temp1[0].length <3 || temp1[0].length >4 || temp1[1].length >8 || temp1[1].length <6)
			   {
			     alert("������Ĵ������λ���������������룡");
			     return false;
			   }
               last_num = temp1[0] + "-" + temp1[1];
		    }
		}

	   if(temp[a].split("-").length >= 3)
		{
		    alert("������Ĵ������λ���������������룡");
			return false;
		}

    temp[a] = last_num;
    }

   if(area == "telephone")
	{
	    for (k=0; k<temp[a].length; k++)
				{
		           cc = temp[a].charAt(k);
		           if ((cc <"0" || cc >"9") && cc != "-")
		              {
			             alert("�������˷����ֵĹ̶��绰���룬���������룡");
			             return false;
		              }
	             }

	    if(temp[a].split("-").length == 1)
		{
		//�Ƿ���ʳ�;
		   if(temp[a].charAt(0)=="0" && temp[a].charAt(1)=="0")
			{
			    alert("������Ĺ̶��绰����λ���������������룡");
				return false;
			 }else{
		   //����
		       if(temp[a].charAt(0) == '0' || temp[a].length > 8 || temp[a].length < 1)
			   {
			     alert("������Ĺ̶��绰����λ���������������룡");
				 return false;
			   }
		     }
		if (temp[a].length >= 6)
		last_num = "-" + temp[a] + "-";
		if (temp[a].length < 6)
	    last_num = "--" + temp[a];
        }

	   if(temp[a].split("-").length == 2)
		{
		   temp1 = temp[a].split("-");

		   //�Ƿ���ʳ�;
		   if(temp1[0].charAt(0)=="0" && temp1[0].charAt(1)=="0")
			{
			   tmp_value = temp1[0] + temp1[1];
			   if (tmp_value.length > 20)
			   {
			      alert("������Ĺ̶��绰����λ���������������룡");
			      return false;
			   }
			   last_num = temp1[0] + "-" + temp1[1] + "-";
			}else{
		   //����
		       if((temp1[0].length > 8 && temp1[1].length > 8) || (temp1[0].length < 5 && temp1[1].length < 1))
			   {
			      alert("������Ĺ̶��绰����λ���������������룡");
			      return false;
			   }
		       if(temp1[0].length < 5)
				{
				   if(temp1[1].length > 5)
                       last_num = temp1[0] + "-" + temp1[1] + "-";
				   if(temp1[1].length < 6)
					   last_num = "--" + temp1[1];
			    }
			   else
			      last_num = "-" + temp1[0] + "-" + temp1[1];
                 }
		}


	   if(temp[a].split("-").length == 3)
		{
		   temp2 = temp[a].split("-");

		   if(temp2[0] != "" && temp2[1] != "")
			{
			   //�Ƿ���ʳ�;
		       if(temp2[0].charAt(0)=="0" && temp2[0].charAt(1)=="0")
			   {
			   //last_num = temp1[0] + "-" + temp1[1] + "-";
			      cru = temp2[0] + temp2[1];
			      if(cru.length > 20)
				  {
			       alert("������Ĺ̶��绰����λ���������������룡");
			       return false;
				  }
			   }else{
		        //����
		        if(temp2[0].length > 4 || temp2[0].length < 3 || temp2[1].length > 8 || temp2[1].length < 6 || temp2[2].length > 8)
			      {
		           alert("������Ĺ̶��绰����λ���������������룡");
			       return false;
			      }
		       }
			}
			last_num = temp[a];
		}

		if(temp[a].split("-").length > 3)
		{
			alert("������Ĺ̶��绰����λ���������������룡");
			return false;
		}
    temp[a] = last_num;
  }
  }

  if(area == "fax" || area == "telephone")
	{
       info.value = temp;
       //alert(temp);
	}
   // alert(document.all.telephone.value);
	//alert(temp);
	return true;
}


function check_information_alert(info,area)
{
   temp = info.split(",");
   //alert(temp.length);
   last_num = "";

  for(a=0;a<temp.length;a++)
  {
	//alert(temp[a]);
    if(area=="sms" || area =="mobile")
	  {
			if(temp[a].length > 12)
			{
				return false;
			} else {

			if(temp[a].length == 12) {
                        if(temp[a].charAt(0) != "0")
				return false;

                        }
                        }
			for (i=0; i<temp[a].length; i++)
				{
		           cc = temp[a].charAt(i);
		           if ((cc <"0" || cc >"9") && cc!="+")
		              {

			             return false;
		              }
	            }
		}

   if(area == "mail")
	{
	   i=temp[a].indexOf("@");
	   j=temp[a].lastIndexOf(".");

	if (i < 1 || j == -1 || temp[a].indexOf(".")==0 || temp[a].indexOf(".@")!=-1 || temp[a].indexOf("..")!=-1 || j==temp[a].length-1 || i > j || j-i<2 || temp[a].charAt(i+1)=="." || i!=temp[a].lastIndexOf("@"))
	{
		alert("��������ʼ���ַ�������������룡");
		return false;
	}
	}
   if(area == "fax")
	{
	    for (k=0; k<temp[a].length; k++)
				{
		           cc = temp[a].charAt(k);
		           if ((cc <"0" || cc >"9") && cc != "-")
		              {
			      //       alert("�������˷����ֵĴ�����룬���������룡");
			             return false;
		              }
	            }

		if(temp[a].split("-").length == 1)
		{
		//�Ƿ���ʳ�;
		   if(temp[a].charAt(0)=="0" && temp[a].charAt(1)=="0")
			{
			    //alert("������Ĵ������λ���������������룡");
				return false;
			 }else{
		   //����
		      if(temp[a].charAt(0) == '0' || temp[a].length > 8 || temp[a].length < 6)
			   {
			     //alert("������Ĵ������λ���������������룡");
				 return false;
			   }
		     }
		 last_num = "-" + temp[a];
        }

	   if(temp[a].split("-").length == 2)
		{
		   temp1 = temp[a].split("-");

		   //�Ƿ���ʳ�;
		   if(temp1[0].charAt(0)=="0" && temp1[0].charAt(1)=="0")
			{
			   tmp_value = temp1[0] + temp1[1];
			   if (tmp_value.length > 20)
			   {
			    //  alert("������Ĵ������λ���������������룡");
			      return false;
			   }
			   last_num = temp1[0] + "-" + temp1[1];
			}else{
		   //����
		      if(temp1[0].charAt(0) != "0" || temp1[0].length <3 || temp1[0].length >4 || temp1[1].length >8 || temp1[1].length <6)
			   {
			  //   alert("������Ĵ������λ���������������룡");
			     return false;
			   }
               last_num = temp1[0] + "-" + temp1[1];
		    }
		}

	   if(temp[a].split("-").length >= 3)
		{
		    //alert("������Ĵ������λ���������������룡");
			return false;
		}

    temp[a] = last_num;
    }

   if(area == "telephone")
	{
	    for (k=0; k<temp[a].length; k++)
				{
		           cc = temp[a].charAt(k);
		           if ((cc <"0" || cc >"9") && cc != "-")
		              {
			      //       alert("�������˷����ֵĹ̶��绰���룬���������룡");
			             return false;
		              }
	             }

	    if(temp[a].split("-").length == 1)
		{
		//�Ƿ���ʳ�;
		   if(temp[a].charAt(0)=="0" && temp[a].charAt(1)=="0")
			{
			    //alert("������Ĺ̶��绰����λ���������������룡");
				return false;
			 }else{
		   //����
		       if(temp[a].charAt(0) == '0' || temp[a].length > 8 || temp[a].length < 6)
			   {
			     //alert("������Ĺ̶��绰����λ���������������룡");
				 return false;
			   }
		     }
		if (temp[a].length >= 6)
		last_num = "-" + temp[a] + "-";
		if (temp[a].length < 6)
	    last_num = "--" + temp[a];
        }

	   if(temp[a].split("-").length == 2)
		{
		   temp1 = temp[a].split("-");

		   //�Ƿ���ʳ�;
		   if(temp1[0].charAt(0)=="0" && temp1[0].charAt(1)=="0")
			{
			   tmp_value = temp1[0] + temp1[1];
			   if (tmp_value.length > 20)
			   {
			      //alert("������Ĺ̶��绰����λ���������������룡");
			      return false;
			   }
			   last_num = temp1[0] + "-" + temp1[1] + "-";
			}else{
		   //����
		       if((temp1[0].length > 8 && temp1[1].length > 8) || (temp1[0].length < 5 && temp1[1].length < 1))
			   {
			      //alert("������Ĺ̶��绰����λ���������������룡");
			      return false;
			   }
		       if(temp1[0].length < 5)
				{
                  if(temp1[1].length > 5)
                       last_num = temp1[0] + "-" + temp1[1] + "-";
				   if(temp1[1].length < 6)
					   last_num = "--" + temp1[1];
				}
			   else
			      last_num = "-" + temp1[0] + "-" + temp1[1];
                 }
		}


	   if(temp[a].split("-").length == 3)
		{
		   temp2 = temp[a].split("-");

		   if(temp2[0] != "" && temp2[1] != "")
			{
			   //�Ƿ���ʳ�;
		       if(temp2[0].charAt(0)=="0" && temp2[0].charAt(1)=="0")
			   {
			   //last_num = temp1[0] + "-" + temp1[1] + "-";
			      cru = temp2[0] + temp2[1];
			      if(cru.length > 20)
				  {
			       //alert("������Ĺ̶��绰����λ���������������룡");
			       return false;
				  }
			   }else{
		        //����
		        if(temp2[0].length > 4 || temp2[0].length < 3 || temp2[1].length > 8 || temp2[1].length < 6 || temp2[2].length > 8)
			      {
		           //alert("������Ĺ̶��绰����λ���������������룡");
			       return false;
			      }
		       }
			}
			last_num = temp[a];
		}

		if(temp[a].split("-").length > 3)
		{
			//alert("������Ĺ̶��绰����λ���������������룡");
			return false;
		}
    temp[a] = last_num;
  }
  }
  if(area == "fax")
	{
       info = temp;
       //alert(temp);
	}
   if(area == "telephone")
	{
       info = temp;
       //alert(temp);
	}
	return true;
}

function checkdate(object,input_hour,input_min)
{
    var today = new Date();
    var year = today.getYear();
	var day = today.getDate();
	var month = today.getMonth()+1;
	var hour = today.getHours();
	var minn = today.getMinutes();

	//j = document.all.TheForm.cm_limit_day.value.lastIndexOf("/");
	//var check_Y = document.all.TheForm.cm_limit_day.value.substring(j+1);
   // var check_D = document.all.TheForm.cm_limit_day.value.substring(3,j);
	//var check_M = document.all.TheForm.cm_limit_day.value.substring(0,2);
	one = object.indexOf("/");
	j = object.lastIndexOf("/");
	var check_Y = object.substring(j+1);
    var check_D = object.substring(one+1,j);
	var check_M = object.substring(0,one);

	//if(check_M.indexOf('0')>= 0 && check_M.indexOf('0')==0)
	//	check_M = check_M.substring(1);
	//if(check_D.indexOf('0')>= 0 && check_D.indexOf('0')==0)
	//	check_D = check_D.substring(1);
	/*if(check_Y*1 < year*1)
	{
	alert("��ѡ���ʱ������д���");
	return false;
    }
	 if(check_Y*1 <= year*1 && check_M*1 < month*1)
	{
	alert("��ѡ���ʱ���·��д���");
	return false;
	}
	 if(check_Y*1 <= year*1 && check_M*1 <= month*1 && check_D*1 < day*1)
	{
		  alert("��ѡ���ʱ�������д���");
		 // alert(hour);
	    //  alert(minn);
		  return false;
	}*/
	if(check_Y*1 == year*1 && check_M*1 == month*1 && check_D*1 == day*1)
	{
	if(input_hour !="" && input_hour < hour)
	{

		alert("�������СʱӦ�ñȵ�ǰʱ����");
		return false;
	}
	if(input_min != "" && input_hour <= hour && input_min < minn)
	{
		alert("������ķ���Ӧ�ñȵ�ǰʱ����");
		return false;
	}
	}
}