// JavaScript Document
function is_quotes(form_value){
  if(event.keyCode==39){
      window.alert("不可以输入单引号！");
      return false;
   }
  return true;
}
function returnLength(str){
	return str.replace(/[^\x00-xff]/g,'**').length
}
//选择复选框
function selectAll()
{
   for(i=1;i<act.elements.length;i++)
   {
      a=act.elements[i];
	  if(a.name!='checkall')
	     a.checked=act.checkall.checked;
   }
}
//打开窗体函数
function wopen(src,name,top){
   window.open(src,name,"scrollbars=yes,top="+top);
}
//判断跳转页
function is_num(form_value,MAX_NUM){
  if(((event.keyCode>57)||(event.keyCode<48))&&(event.keyCode!=13)){
      alert("你输入的不是数字！");
      return false;
   }
   if((form_value=="")&&((event.keyCode-48)>parseInt(MAX_NUM))){
     alert("你输入的数字超出范围");
      return false;
   }
   if((form_value!="")&&(parseInt(form_value+""+(event.keyCode-48).toString())>parseInt(MAX_NUM))){
     alert("你输入的数字超出范围");
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


//功能:将form中所有的单引号替换成两个单引号操作。
//输入参数:myform(form名)
//输出参数:无
// c-3 textTrim(form名称)
function ReplaceComma(myform){
  	var rExp = /\'/gi;
	for(var i=0;i<myform.elements.length;i++){
  		var etype=myform.elements[i].type;

		switch(etype)
		{
		   case "text" :
		      myform.elements[i].value=myform.elements[i].value.replace(rExp,'‘');
			  break;
		   case "hidden" :
              if(myform.elements[i].name=='content'){
                  //alert('I met content field, ignore..');
                  break;//把word编辑器中的内容不加处理，放到服务器端由Java处理。因为JavaScript处理大的文本时太慢
              }
		      myform.elements[i].value=myform.elements[i].value.replace(rExp,'‘');
			  break;
		   case "textarea" :
              myform.elements[i].value=myform.elements[i].value.replace(rExp,'‘');
			  break;
		   case "password" :
		      myform.elements[i].value=myform.elements[i].value.replace(rExp,'‘');
			  break;
		   default :
		      break;
		}

  	}
}

//功能:上传附件不许手工输入
//输入参数:控件(this)
//输出参数:无
function lost(element){
  	element.blur();
}

/**
 * b2b JavaScript 检查库
 * @author 华炼(hlian@alleasy.net)
 * @version 1.10
 * #@ validate.js
 * 第一类 检查并返回检查结果(true or false)
 * a-1. ifDigit(String)  是否为数字
 * a-2. ifLetter(String) 是否为字母
 * a-3. ifDay(String)    是否为天数
 * a-4. ifMonth(String)  是否为月份
 * a-5. ifYear(String)   是否为年份
 * a-6. ifDate(String)   是否为日期
 * a-7. ifEmail(String)  是否为邮件地址
 * a-8. ifPhone(String)  是否为电话号码
 * a-9. ifGBK(String)    是否为中文字符
 * a-10.ifMoney(String)  是否为合法货币数字
 * a-11 ifMoenyRange(String,int,int) 判断字符串是否为合法钱数,且是否超过限定范围
 * a-12. checkMonthLength(mm, dd, yyyy) 判断是否为合法日期
 * a-13. getSelectedButton(buttonGroup) 判断buttongroup为名的一组radio中有无被选中的项
 * a-14. ifSubCollect(Object obj, String[] strCollect) 判断字符串str是否在字符串集strCollect中
 * a-15 isCheckLeng(str, min, max)  字符串长度是否在指定长度范围内
 * a-16 getSelectedNumber(buttonGroup) 判断复选框或单选纽有几个被选中,返回数字
 * a-17 checkInputIsNumber(e) 当文本框输入不为数字时直接报错
 * a-18 checkMonthData(mm,dd,yyyy) 判断是否为合法日期,包括月份和日期
 * a-19 checkDataF(str) 检查以YYYY-MM-DD形式输入的日期字符串是否为合法日期，允许为空
 *		输出true or false，在false时有输出提示
 * a-20 function ifErrChar( str ) 判断输入字符串中是否有非法字符<、>、&
 * 第二类 检查后直接报错
 * b-1. isDigit(Object)	 是否为数字
 * b-2. isLetter(Object) 是否为字母
 * b-3. isDay(Object)    是否为天数
 * b-4. isMonth(Object)  是否为月份
 * b-5. isYear(Object)   是否为年份
 * b-6. isDate(Object)   是否为日期
 * b-7. isEmail(Object)  是否为邮件地址
 * b-8. isPhone(Object)  是否为电话号码
 * b-9. isGBK(Object)    是否为中文字符
 * b-10. isMoney(Object)  是否为合法货币数字
 * b-11. isMoneyRange(obj,minValue,maxValue)	判断是否合法钱数且是否超过限定额度
 * b-12. checkLeng(Object, min, max) 字符串长度是否在指定长度范围内
 * b-13.1 checkValidDate(mmObject,ddObject,yyObject,allowNull)	对日期进行全面的检查
 * b-13.2 checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2)
 *		检查起始日期及截止日期
 * b-14. errorMsg(Object, String) 显示提示信息String,光标焦点落在Object上,返回false
 * b-15. showMsg(String, Object)  显示提示信息String,光标焦点落在Object上,返回false
 * b-16. isSubCollect(Object obj, String[] strCollect) 判断字符串str是否在字符串集strCollect中
 * b-17. checkDataOS(Object obj,String str)检查以YYYY-MM-DD形式输入的日期字符串是否为合法日期（1900-01-01至今天）
 * 第三类 功能函数，并不报错
 * c-1. getLength(String)  获取字符长度（每个中文字符为2个字符）
 * c-2. trim(String)  去掉字符串前后的空格并返回
 * c-3. textsTrim(formname)	将form中所有的text文本进行trim操作。

 */
//建立者:默认
//判断字符串是否为合法数字
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

//建立者:任勇
//功能:判断字符串是否都是字母
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

//建立者:任勇
//判断字符串是否为合法邮件地址
//程云修改  说明：有且仅有一个“@”，含有“.”，并且“@”在最后一个“.”前，
//                @后不能是“.”，不允许有“..”，最后一个字符不允许是“.”
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

//建立者:任勇
//判断字符串是否为合法钱数
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

//建立者:任勇
//判断字符串是否为合法钱数,且是否超过限定范围
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

//建立者:任勇
//判断是否为合法日期
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

//建立者:任勇
//判断buttongroup为名的一组radio中有无被选中的项
// a-13 getSelectButton(buttonGroup)
function getSelectedButton(buttonGroup){
  	for (var i=0;i<buttonGroup.length;i++){
  		if (buttonGroup[i].checked) return true;
  	}
  	return false;
}

//建立者:顾翔
//判断复选框或单选纽有几个被选中
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


//建立者:顾翔
//当文本框输入不为数字时直接报错
// a-17 checkInputIsNumber(e)
function checkInputIsNumber(e){
   //alert(e.keyCode);
   if((e.keyCode>=48)&&(e.keyCode<=57))
   {
       return true;
   }else
   {
       alert("请输入数字!");
	   return false;
   }
}

//建立者:程云
//功能: 检查是否为合法日期
//示例: checkMonthData(12,12,1977)
//输入参数: 需要检查的年、月、日
//输出参数: true or false;
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


//建立者:程云
//功能: 检查是否为合法日期
//示例: checkDataF("1999-01-01")
//输入参数: 以YYYY-MM-DD形式输入的日期字符串,允许为空
//输出参数: true or false，在false时有输出提示.
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
			alert(" 您输入的《生日》必须是10个字符!（YYYY-MM-DD）");
   			return false;
		}
		if(str.substr(4,1)!="-" || str.substr(7,1)!="-")
		{
			alert(" 您输入的《生日》格式不对!（YYYY-MM-DD）");
   			return false;
		}
		if(!ifDigit(yyyy)||!ifDigit(mm)||!ifDigit(dd))
		{
			alert(" 您输入的《生日》格式不对!年、月、日中必须是数字！（YYYY-MM-DD）");
   			return false;
		}
		if(!checkMonthData(mm,dd,yyyy))
		{
			alert(" 您输入的《生日》格式不对!不是合法日期！（YYYY-MM-DD）");
   			return false;
		}
		return true;

}

//建立者:程云
//功能: 检查是否又非法字符<、>、&
//示例: ifErrChar("abc&<")
//输入参数: str
//输出参数: true or false
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

//建立者:任勇
//功能: 检查字串长度是否在指定范围内
//示例: isChekLeng(String, 4,10)
//输入参数: 需要检查的表单对象名称，最小长度，最大长度
//输出参数: true
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

//建立者:默认
//功能: 检查是否为数字
//示例: isDigit(String)
//输入参数: 需要检查的表单对象名称
//输出参数: true或出错信息
// b-1.1 isDigit(Object)
function isDigit(obj)
{
	slen=obj.value.length;
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if (cc <"0" || cc >"9")
		{
			errorMsg(obj,"必须为数字！");
			return false;
		}
	}
	return true;
}

//建立者:任勇
//功能: 检查是否为数字
//示例: isDigitMaxlength(String obj,int length)
//输入参数: 需要检查的表单对象名称,允许的最大长度
//输出参数: true或出错信息
// b-1.2 isDigitMaxlength(Object,maxlength)
function isDigitMaxlength(obj,maxlength)
{
	obj.value=trim(obj.value);
	slen=obj.value.length;
	if(slen>maxlength){
		errorMsg(obj,"长度最大为"+maxlength+"！");
		return false;
	}

	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if (cc <"0" || cc >"9")
		{
			errorMsg(obj,"必须为数字！");
			return false;
		}
	}
	return true;
}

//建立者:任勇
//功能:判断字符串是否都是字母
// b-2 isLetter(Object)
function isLetter(obj){
	str = obj.value;
	if ( str.length == 0 )
		return false;
	str = str.toUpperCase();
	for ( var i = 0 ; i < str.length; i ++ ){
		if ( str.charAt(i) < "A" || str.charAt(i) > "Z" )
			errorMsg(obj, "必须为字符！");
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
		errorMsg(obj,"日格式有误，正确的格式为：DD,如:02");
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
		errorMsg(obj,"月份格式有误，正确的格式为：MM,如:01");
		return false;
	}
}

//建立者：默认
//功能：检查是否合法年份
//示例：isYear(Object)
//输入参数：被检查字符串
//输出参数：true 或 错误信息
// b-5 isYear(Object)
function isYear(obj)
{
	slen=obj.value.length;
	if (!ifDigit(obj.value))
	{
		errorMsg(obj,"日期有误，不能含有非数字的字符！");
		return false;
	}
	if (obj.value < "1800" ||obj.value>"2100"|| slen < 4)
	{
		errorMsg(obj,"年份格式有误，正确的格式为：YYYY,如:1999");
		return false;
	}

return true;
}

//建立者：默认
//功能：检查是否合法日期
//示例：isDate(Object)
//输入参数：被检查字符串
//输出参数：true 或 错误信息
// b-6 isDate(Object)
function isDate(obj)
{
	slen=obj.value.length;
	if (!ifDigit(obj.value))
	{
		errorMsg(obj,"日期有误，不能含有非数字的字符！");
		return false;
	}
	else if (slen < 8)
	{
		errorMsg(obj,"日期格式有误，正确的格式为：YYYYMMDD,如:19990102");
		return false;
	}
	cc = obj.value.substr(0,4);
	if (cc < "1800")
	{
		errorMsg(obj,"年份格式有误，正确的格式为：YYYY,如:1999");
		return false;
	}
	cc = obj.value.substr(4,2);
	if (cc < "01" || cc > "12")
	{
		errorMsg(obj,"月份格式有误，正确的格式为：MM,如:01");
		return false;
	}
	cc = obj.value.substr(6,2);
	if (cc < "01" || cc > "31")
	{
		errorMsg(obj,"日格式有误，正确的格式为：DD,如:02");
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
		errorMsg(obj,"Email书写有误！");
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
		errorMsg(obj, "信息为空，请修改！");
		return false;
	}
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if ((cc <"0" || cc >"9") && cc != "-" && cc!="+" && cc!="(" && cc !=")" && cc !="/")
		{
			errorMsg(obj,"必须为数字！");
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
			errorMsg(obj,"该项不能为汉字！");
			return false;
		}
	}
	return true;
}

//建立者:任勇
//判断字符串是否为合法钱数
// b-10 isMoney(Object)
function isMoney(obj)
{
	if (ifMoney(obj.value))
	{
		return true;
	}
	else
	{
		errorMsg(obj, "不是合法的货币数！");
		return false
	}
	return true;
}

//建立者:任勇
//判断是否合法钱数且是否超过限定额度
//b-11 isMoneyRange(obj,minValue,maxValue)
function isMoneyRange(obj,minValue,maxValue)
{
	obj.value=trim(obj.value);
	if(obj.value=="") return true;

	if(!ifMoney(obj.value))
		return shoMsg("不是合法的货币数！",obj);

	if(parseFloat(obj.value)>=maxValue)
		return showMsg("货币值过大！",obj);
	if(parseFloat(obj.value)<minValue)
		return showMsg("货币值过小！",obj);
	return true;
}


//建立者:任勇
//判断是否合法钱数且是否超过限定额度
//b-11 isMoneyRange(obj,minValue,maxValue)
function isDigitInRange(obj,minValue,maxValue)
{
	obj.value=trim(obj.value);
	if(obj.value=="") return true;

	if(parseFloat(obj.value)>=maxValue)
		return showMsg("错误：\n\t数值过大！\n数值合法取值范围：" + minValue + "-" + maxValue + ".", obj);
	if(parseFloat(obj.value)<minValue)
		return showMsg("错误：\n\t数值过小！\n数值合法取值范围：" + minValue + "-" + maxValue + ".", obj);
	return true;
}

//建立者:华炼
//功能: 检查字段长度是否在指定范围内
//示例: chekLeng(form1.t1, 4,10)
//输入参数: 需要检查的表单对象名称，最小长度，最大长度
//输出参数: true
// b-12 checkLeng(obj, min, max)
function checkLeng(obj, min, max)
{
	slen=getLength(obj.value);
	if (slen < min)
	{
		errorMsg(obj,"请至少输入 " + min + " 个字符！");
		return false;
	}
	if (slen > max)
	{
		errorMsg(obj,"请最多输入 " + max + " 个字符！");
		return false;
	}
	return true;
}

function checkLengNotFocus(obj, min, max)
{
	slen=getLength(obj.value);
	if (slen < min)
	{
		errorMsgNotFocus(obj,"请至少输入 " + min + " 个字符！");
		return false;
	}
	if (slen > max)
	{
		errorMsgNotFocus(obj,"请最多输入 " + max + " 个字符！");
		return false;
	}
	return true;
}


//建立者:任勇
//功能:对日期进行全面的检查
//输入参数:mmObject:月的object;ddObject:日的object;yyObject:年的object;
//输入参数:allowNull:true允许日期为空;false:必须选择日期
//输出参数:ture of false;
// b-13.1 checkValiDate(mmObject,ddObject,yyObject,allowNull)
function checkValidDate(mmObject,ddObject,yyObject,allowNull){
  	if(allowNull){
  		if(!(((!yyObject.options[0].selected)&&(!mmObject.options[0].selected)&&(!ddObject.options[0].selected)) || ((yyObject.options[0].selected)&&(mmObject.options[0].selected)&&(ddObject.options[0].selected))))
  			return showMsg("日期必须全部选择或者全部不选择!",yyObject);
  	}else{
  		if(yyObject.options[0].selected){
  			return showMsg("请选择日期的年!",yyObject);
  		}
  		if(mmObject.options[0].selected){
  			return showMsg("请选择日期的月!",mmObject);
  		}
  		if(ddObject.options[0].selected){
  			return showMsg("请选择日期的日!",ddObject);
  		}
  	}

  	if(!yyObject.options[0].selected){
  		var my_year=yyObject[yyObject.selectedIndex].value;
  		var my_month=mmObject[mmObject.selectedIndex].value;
  		var my_day=ddObject[ddObject.selectedIndex].value;

  		if(!checkMonthLength(my_month,my_day,my_year))
  			return showMsg("选择的日期不合法!",ddObject);
  	}
  	return true;
}


//建立者:任勇
//功能:对日期进行全面的检查
//输入参数:mmObject1:其始月的object;ddObject1:其始日的object;yyObject1:其始年的object;
//输入参数:allowNull1:起始日期true允许日期为空;false:必须选择日期
//输入参数:mmObject2:截止月的object;ddObject2:截止日的object;yyObject2:截止年的object;
//输入参数:allowNull2:截止日期true允许日期为空;false:必须选择日期
//输出参数:ture of false;
// b-13.2 checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2)
function checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2){
	if(!checkValidDate(mmObject1,ddObject1,yyObject1,allowNull1)) return false;
	if(!checkValidDate(mmObject2,ddObject2,yyObject2,allowNull2)) return false;

	if((!yyObject1.options[0].selected) && (!yyObject2.options[0].selected)){
		date1=new Date(yyObject1[yyObject1.selectedIndex].value-1900,mmObject1[mmObject1.selectedIndex].value-1,ddObject1[ddObject1.selectedIndex].value);
		date2=new Date(yyObject2[yyObject2.selectedIndex].value-1900,mmObject2[mmObject2.selectedIndex].value-1,ddObject2[ddObject2.selectedIndex].value);
		if(date1>date2){
			return showMsg("起始日期不能大于截止日期！",yyObject1);
		}
	}
	return true;
}

// 报错
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

//建立者:任勇
//功能:显示提示信息Msg,光标焦点落在Obj上,返回false
//     主要用于检查必要字段是否正确
//示例:showMsg("用户名不能为空.",myform.username)
//输入参数:Msg(提示信息) Obj(光标焦点对象)
//输出参数:false
// b-15 showMsg(String, Object)
function showMsg(Msg, Obj)
{
	alert( Msg );
	Obj.focus();
	return false;
}

// b-17. checkDataOS(Object obj,String str)
//建立者:程云
//功能: 检查是否为合法日期1900-01-01至今天
//示例: checkDataOS(form.birthday,"1999-01-01")
//输入参数: obj,聚焦对象; str以YYYY-MM-DD形式输入的日期字符串,允许为空
//输出参数: true or false
// b-17. checkDataOS(Object obj,String str)
//修改者:魏志辛
//原因：日期改为__年__月__日输入
//方法：将三个字段以"-"连接后调用，并修改提示信息
function checkDataOS(obj,str)
{

		if(str=="")
			return true;

		var yyyy=str.substr(0,4);
		var mm=str.substr(5,2);
		var dd=str.substr(8,2);

		if(getLength(str)!=10)
		{
			errorMsg(obj,"注意：\n\    您输入的《生日》格式不对!（YYYY年MM月DD日）");
   			return false;
		}
		//if(str.substr(4,1)!="-" || str.substr(7,1)!="-")
		//{
		///	errorMsg(obj,"注意：\n\     您输入的《生日》格式不对!（YYYY年MM月DD日）");
   		//	return false;
		//}

		if(!ifDigit(yyyy)||!ifDigit(mm)||!ifDigit(dd))
		{
			errorMsg(obj,"注意：\n\     您输入的《生日》格式不对!年、月、日中必须是数字！（YYYY年MM月DD日））");
   			return false;
		}
		if(!checkMonthData(mm,dd,yyyy))
		{
			errorMsg(obj,"注意：\n\     您输入的《生日》格式不对!不是合法日期！（YYYY年MM月DD日）");
   			return false;
		}
		if(yyyy<1900)
		{
			errorMsg(obj,"注意：\n\     您输入《生日》格式不对!日期超出系统范围！年分不允许早于1900年！\n  请重新输入!");
   			return false;
		}
		if(new Date(yyyy,mm-1,dd).getTime()>new Date().getTime())
		{
			errorMsg(obj,"注意：\n\     您输入《生日》格式不对!日期超出系统范围！不允许迟于今天！\n  请重新输入!");
   			return false;
		}
		return true;

}

/**
以下是第三类
*/
//建立者:任勇
//加入了汉字的长度判断
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

//建立者:任勇
//功能:去掉字符串前后的空格并返回
//输入参数:inputStr(待处理的字符串)
//输出参数:inputStr(处理后的字符串)
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


//建立者:任勇
//功能:将form中所有的text文本进行trim操作。
//输入参数:myform(form名)
//输出参数:无
// c-3 textTrim(form名称)
function textsTrim(myform){
  	for(var i=0;i<myform.elements.length;i++){
  		var etype=myform.elements[i].type;
  		if(etype == "text"){
 			myform.elements[i].value=trim(myform.elements[i].value);
  		}
  	}
}


// 建立者：华炼
// 功能：判断字符串str是否在字符串集strCollect中
// 输入参数：obj 字符串字段
// 输入参数：strCollect 字符串集
// 输出参数：true or false 包含或不包含
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

// 建立者：华炼
// 功能：判断字符串str是否在字符串集strCollect中
// 输入参数：obj 字符串字段
// 输入参数：strCollect 字符串集
// 输出参数：true or false 包含或不包含
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
	    alert("在预定信息集：\n " +collectStr + "\n没有包含信息\t" + str );
	    return false;
	}
	else
	    return true;
}

// 建立者：华炼
// 比较 形如 2001-11-10, 2001-11-11 这样的日期
// dateStr1 是否比 dateStr2 小
// dateStr1 日期字符串1
// dateStr2 日期字符串2
function compareDate(dateStr1, dateStr2)
{
	dt1 = isoParseDate(dateStr1);
	dt2 = isoParseDate(dateStr2);
	if (dt1 > dt2)
		return false;
	else
		return true;
}

// 建立者：华炼
// 比较 形如 2001-11-10, 2001-11-11 这样的日期是否相等
// dateStr1 日期字符串1
// dateStr2 日期字符串2
function ifDateEq(dateStr1, dateStr2)
{
	dt1 = isoParseDate(dateStr1);
	dt2 = isoParseDate(dateStr2);
	// 不要用 dt1 == dt2 ，会没有反应的
	if (dt1 > dt2 || dt1 < dt2)
		return false;
	else
		return true;
}
// 建立者：华炼
// 将形如 2001-11-10 的日期转化为javascript中的日期对象
// dateStr1 日期字符串
// dt 日期
function isoParseDate(dateStr1)
{
	re = /-/gi;
	dateStr1 = dateStr1.replace(re, "/");
	dt = new Date();
	dt.setTime(Date.parse(dateStr1))
	return dt;
}

// 建立者：华炼
// 获取今天日期字符串，形如 2001/11/10
function getTodayStr()
{
       tday = new Date();
       tYear = tday.getYear();
       tMonth = tday.getMonth()+1;
       tDay = tday.getDate();
       tDayString = tYear + "/" + tMonth + "/" + tDay
       return tDayString;
}

// 建立者：华炼
// 获取今天开始时间，以Javascript中日期对象格式
function getTodayTime()
{
       tday = new Date();
       tDayString = getTodayStr();
       tday.setTime(Date.parse(tDayString))
       return tday;
}

// 建立者：华炼
// 判断是否合法用户名
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

// 建立者：华炼
// 判断是否合法用户列表
function isValidUserName(obj)
{
  var userlist = obj.value;
  if (!ifValidUserList(userlist))
  {
      showMsg("注意：\n    您提供的用户名 " + username + " 不是合法的用户名。请重新更换或修改用户名。", obj)
      return false;
  }
  else
    return true;
}

// 建立者：华炼
// 判断是否合法用户列表
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

// 建立者：华炼
// 判断是否合法用户列表
function isValidUserList(obj)
{
  userlist = obj.value;
  arrayOfUser = new Array();
  arrayOfUser = userlist.split(",");

  for (i=0; i<arrayOfUser.length; i++)
  {
    if (!ifValidUserName(arrayOfUser[i]))
    {
      showMsg("注意：\n    您提供的用户名 " + arrayOfUser[i] + " 不是合法的用户名。请重新更换或修改用户名。", obj)
      return false;
    }
  }
  return true;
}

// 建立者：华炼
// 将数组精简
// 参数：userlist 字符串数组
// 返回：newlist 新字符串数组
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

// 建立者：华炼
// 判断一个字符串是否在一个列表中
// 参数：userlist 字符串数组
// 参数：username 字符串
// 返回：true 此用户在列表中
//	false 此用户不在列表中
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

// 建立者：华炼
// 将一个字符串数组转换为列表信息
// 参数：userlist 字符串数组
// 返回：字符串数组列表信息
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


// 只允许输入数字
function onlyDigit(obj, e){
  if((e.keyCode>=48)&&(e.keyCode<=57)){
    return true;
  }else if(e.keyCode==13){
    return true;
  }else{
    e.keyCode=0;
    alert("注意：\n    只允许输入数字。\n    请修改后重新提交！");
    return false;
  }
}

// 检查ECM系统密码，只允许为数字
// 2002-04-01
function checkEcmPass(obj)
{
	var ecmpass = obj.value;

	if (getLength(ecmpass) < 1)
	{
  		alert("注意：\n    您没有输入《密码》信息!\n    请输入规定长度内的数字!");
  		obj.focus();
   		return false;
	}
	if (getLength(ecmpass) < 6 )
	{
        	alert("注意：\n    为了安全起见，您的《密码》必须为6位!\n    请输入规定长度内的数字!");
        	obj.focus();
        	return false;
	}
	if (getLength(ecmpass) > 6 )
	{
        	alert("注意：\n    您输入的《密码》超过了规定的6位!\n    请输入规定长度内的数字!");
        	obj.focus();
        	return false;
	}
        if (!ifGBK(ecmpass))
        {
           alert("注意：\n\    您输入的《密码》不可以为中文!\n    请修改后重新提交。");
           obj.focus();
           return false;
        }
	if (!ifDigit(ecmpass))
	{
           alert("注意：\n    《密码》仅允许使用数字，您输入了不是数字的字符。\n    请修改后重新提交。");
           obj.focus();
           return false;
	}
	return true;
}

/**
 * 获取一定长度子串
 * cnstr 包含中文的字符串信息
 * getleng 获取长度
 * result 返回字符串
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

//超长字符串增加换行
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
   	alert("注意：\n    只允许输入6位数字。\n    请修改后重新提交！");
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
						     alert("您输入了非数字的短信号码，请核实后输入！");
						 if(area=="mobile")
							 alert("您输入了非数字的移动电话号码，请核实后输入！");
			             return false;
		              }
	            }
            //国际
			if (temp[a].charAt(0) == "0" && temp[a].charAt(1) == "0")
			{
				if (temp[a].length > 20)
				{
					if(area=="sms")
				    alert("您输入的手机短信号码有误，请核实后输入！");
				    if(area=="mobile")
					alert("您输入的移动电话号码位数有误，请核实后输入！");
				    return false;
				}
			}else{
			if(temp[a].length != 11 && temp[a].length != 12)
			{
				//alert("1");
				if(area=="sms")
				    alert("您输入的手机短信号码有误，请核实后输入！");
				if(area=="mobile")
					alert("您输入的移动电话号码位数有误，请核实后输入！");
				return false;
			}
			if(temp[a].length == 11)
		    {
				if((temp[a].charAt(0) != "1")||(temp[a].charAt(1) != "3"))
				{
					if(area=="sms")
				    alert("您输入的手机短信号码有误，请核实后输入！");
				if(area=="mobile")
					alert("您输入的移动电话号码位数有误，请核实后输入！");
				return false;
				}
		    }
		    if(temp[a].length == 12)
		    {
				//alert("test");
				if(temp[a].charAt(0) != "0")
				{
					if(area=="sms")
				    alert("您输入的手机短信号码有误，请核实后输入！");
				if(area=="mobile")
					alert("您输入的移动电话号码位数有误，请核实后输入！");
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
		alert("您输入的邮件地址有误，请重新输入！");
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
			             alert("您输入了非数字的传真号码，请重新输入！");
			             return false;
		              }
	            }

		if(temp[a].split("-").length == 1)
		{
		//是否国际长途
		   if(temp[a].charAt(0)=="0" && temp[a].charAt(1)=="0")
			{
			    alert("您输入的传真号码位数有误，请重新输入！");
				return false;
			 }else{
		   //国内
		      if(temp[a].charAt(0) == '0' || temp[a].length > 8 || temp[a].length < 6)
			   {
			     alert("您输入的传真号码位数有误，请重新输入！");
				 return false;
			   }
		     }
		 last_num = "-" + temp[a];
        }

	   if(temp[a].split("-").length == 2)
		{
		   temp1 = temp[a].split("-");

		   //是否国际长途
		   if(temp1[0].charAt(0)=="0" && temp1[0].charAt(1)=="0")
			{
			   tmp_value = temp1[0] + temp1[1];
			   if (tmp_value.length > 20)
			   {
			      alert("您输入的传真号码位数有误，请重新输入！");
			      return false;
			   }
			   last_num = temp1[0] + "-" + temp1[1];
			}else{
		   //国内
		      if(temp1[0].charAt(0) != "0" || temp1[0].length <3 || temp1[0].length >4 || temp1[1].length >8 || temp1[1].length <6)
			   {
			     alert("您输入的传真号码位数有误，请重新输入！");
			     return false;
			   }
               last_num = temp1[0] + "-" + temp1[1];
		    }
		}

	   if(temp[a].split("-").length >= 3)
		{
		    alert("您输入的传真号码位数有误，请重新输入！");
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
			             alert("您输入了非数字的固定电话号码，请重新输入！");
			             return false;
		              }
	             }

	    if(temp[a].split("-").length == 1)
		{
		//是否国际长途
		   if(temp[a].charAt(0)=="0" && temp[a].charAt(1)=="0")
			{
			    alert("您输入的固定电话号码位数有误，请重新输入！");
				return false;
			 }else{
		   //国内
		       if(temp[a].charAt(0) == '0' || temp[a].length > 8 || temp[a].length < 1)
			   {
			     alert("您输入的固定电话号码位数有误，请重新输入！");
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

		   //是否国际长途
		   if(temp1[0].charAt(0)=="0" && temp1[0].charAt(1)=="0")
			{
			   tmp_value = temp1[0] + temp1[1];
			   if (tmp_value.length > 20)
			   {
			      alert("您输入的固定电话号码位数有误，请重新输入！");
			      return false;
			   }
			   last_num = temp1[0] + "-" + temp1[1] + "-";
			}else{
		   //国内
		       if((temp1[0].length > 8 && temp1[1].length > 8) || (temp1[0].length < 5 && temp1[1].length < 1))
			   {
			      alert("您输入的固定电话号码位数有误，请重新输入！");
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
			   //是否国际长途
		       if(temp2[0].charAt(0)=="0" && temp2[0].charAt(1)=="0")
			   {
			   //last_num = temp1[0] + "-" + temp1[1] + "-";
			      cru = temp2[0] + temp2[1];
			      if(cru.length > 20)
				  {
			       alert("您输入的固定电话号码位数有误，请重新输入！");
			       return false;
				  }
			   }else{
		        //国内
		        if(temp2[0].length > 4 || temp2[0].length < 3 || temp2[1].length > 8 || temp2[1].length < 6 || temp2[2].length > 8)
			      {
		           alert("您输入的固定电话号码位数有误，请重新输入！");
			       return false;
			      }
		       }
			}
			last_num = temp[a];
		}

		if(temp[a].split("-").length > 3)
		{
			alert("您输入的固定电话号码位数有误，请重新输入！");
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
		alert("您输入的邮件地址有误，请重新输入！");
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
			      //       alert("您输入了非数字的传真号码，请重新输入！");
			             return false;
		              }
	            }

		if(temp[a].split("-").length == 1)
		{
		//是否国际长途
		   if(temp[a].charAt(0)=="0" && temp[a].charAt(1)=="0")
			{
			    //alert("您输入的传真号码位数有误，请重新输入！");
				return false;
			 }else{
		   //国内
		      if(temp[a].charAt(0) == '0' || temp[a].length > 8 || temp[a].length < 6)
			   {
			     //alert("您输入的传真号码位数有误，请重新输入！");
				 return false;
			   }
		     }
		 last_num = "-" + temp[a];
        }

	   if(temp[a].split("-").length == 2)
		{
		   temp1 = temp[a].split("-");

		   //是否国际长途
		   if(temp1[0].charAt(0)=="0" && temp1[0].charAt(1)=="0")
			{
			   tmp_value = temp1[0] + temp1[1];
			   if (tmp_value.length > 20)
			   {
			    //  alert("您输入的传真号码位数有误，请重新输入！");
			      return false;
			   }
			   last_num = temp1[0] + "-" + temp1[1];
			}else{
		   //国内
		      if(temp1[0].charAt(0) != "0" || temp1[0].length <3 || temp1[0].length >4 || temp1[1].length >8 || temp1[1].length <6)
			   {
			  //   alert("您输入的传真号码位数有误，请重新输入！");
			     return false;
			   }
               last_num = temp1[0] + "-" + temp1[1];
		    }
		}

	   if(temp[a].split("-").length >= 3)
		{
		    //alert("您输入的传真号码位数有误，请重新输入！");
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
			      //       alert("您输入了非数字的固定电话号码，请重新输入！");
			             return false;
		              }
	             }

	    if(temp[a].split("-").length == 1)
		{
		//是否国际长途
		   if(temp[a].charAt(0)=="0" && temp[a].charAt(1)=="0")
			{
			    //alert("您输入的固定电话号码位数有误，请重新输入！");
				return false;
			 }else{
		   //国内
		       if(temp[a].charAt(0) == '0' || temp[a].length > 8 || temp[a].length < 6)
			   {
			     //alert("您输入的固定电话号码位数有误，请重新输入！");
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

		   //是否国际长途
		   if(temp1[0].charAt(0)=="0" && temp1[0].charAt(1)=="0")
			{
			   tmp_value = temp1[0] + temp1[1];
			   if (tmp_value.length > 20)
			   {
			      //alert("您输入的固定电话号码位数有误，请重新输入！");
			      return false;
			   }
			   last_num = temp1[0] + "-" + temp1[1] + "-";
			}else{
		   //国内
		       if((temp1[0].length > 8 && temp1[1].length > 8) || (temp1[0].length < 5 && temp1[1].length < 1))
			   {
			      //alert("您输入的固定电话号码位数有误，请重新输入！");
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
			   //是否国际长途
		       if(temp2[0].charAt(0)=="0" && temp2[0].charAt(1)=="0")
			   {
			   //last_num = temp1[0] + "-" + temp1[1] + "-";
			      cru = temp2[0] + temp2[1];
			      if(cru.length > 20)
				  {
			       //alert("您输入的固定电话号码位数有误，请重新输入！");
			       return false;
				  }
			   }else{
		        //国内
		        if(temp2[0].length > 4 || temp2[0].length < 3 || temp2[1].length > 8 || temp2[1].length < 6 || temp2[2].length > 8)
			      {
		           //alert("您输入的固定电话号码位数有误，请重新输入！");
			       return false;
			      }
		       }
			}
			last_num = temp[a];
		}

		if(temp[a].split("-").length > 3)
		{
			//alert("您输入的固定电话号码位数有误，请重新输入！");
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
	alert("您选择的时间年份有错误！");
	return false;
    }
	 if(check_Y*1 <= year*1 && check_M*1 < month*1)
	{
	alert("您选择的时间月份有错误！");
	return false;
	}
	 if(check_Y*1 <= year*1 && check_M*1 <= month*1 && check_D*1 < day*1)
	{
		  alert("您选择的时间日期有错误！");
		 // alert(hour);
	    //  alert(minn);
		  return false;
	}*/
	if(check_Y*1 == year*1 && check_M*1 == month*1 && check_D*1 == day*1)
	{
	if(input_hour !="" && input_hour < hour)
	{

		alert("您输入的小时应该比当前时间晚！");
		return false;
	}
	if(input_min != "" && input_hour <= hour && input_min < minn)
	{
		alert("您输入的分钟应该比当前时间晚！");
		return false;
	}
	}
}