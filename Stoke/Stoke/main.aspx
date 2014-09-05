<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Stoke.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>自定义桌面</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
		<LINK href="css/dragable-boxes.css" type="text/css" rel="stylesheet">
		<LINK href="../../Css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript">
function sack(file){
	this.AjaxFailedAlert = "您的浏览器不支持Ajax";
	this.requestFile = file;
	this.method = "POST";
	this.URLString = "";
	this.encodeURIString = true;
	this.execute = false;

	this.onLoading = function() { };
	this.onLoaded = function() { };
	this.onInteractive = function() { };
	this.onCompletion = function() { };

	this.createAJAX = function() {
		try {
			this.xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e) {
			try {
				this.xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (err) {
				this.xmlhttp = null;
			}
		}
		if(!this.xmlhttp && typeof XMLHttpRequest != "undefined")
			this.xmlhttp = new XMLHttpRequest();
		if (!this.xmlhttp){
			this.failed = true; 
		}
	};
	
	this.setVar = function(name, value){
		if (this.URLString.length < 3){
			this.URLString = name + "=" + value;
		} else {
			this.URLString += "&" + name + "=" + value;
		}
	}
	
	this.encVar = function(name, value){
		var varString = encodeURIComponent(name) + "=" + encodeURIComponent(value);
	return varString;
	}
	
	this.encodeURLString = function(string){
		varArray = string.split('&');
		for (i = 0; i < varArray.length; i++){
			urlVars = varArray[i].split('=');
			if (urlVars[0].indexOf('amp;') != -1){
				urlVars[0] = urlVars[0].substring(4);
			}
			varArray[i] = this.encVar(urlVars[0],urlVars[1]);
		}
	return varArray.join('&');
	}
	
	this.runResponse = function(){
		eval(this.response);
	}
	
	this.runAJAX = function(urlstring){
		this.responseStatus = new Array(2);
		if(this.failed && this.AjaxFailedAlert){ 
			alert(this.AjaxFailedAlert); 
		} else {
			if (urlstring){ 
				if (this.URLString.length){
					this.URLString = this.URLString + "&" + urlstring; 
				} else {
					this.URLString = urlstring; 
				}
			}
			if (this.encodeURIString){
				var timeval = new Date().getTime(); 
				this.URLString = this.encodeURLString(this.URLString);
				this.setVar("rndval", timeval);
			}
			if (this.element) { this.elementObj = document.getElementById(this.element); }
			if (this.xmlhttp) {
				var self = this;
				if (this.method == "GET") {
					var totalurlstring = this.requestFile + "?" + this.URLString;
					this.xmlhttp.open(this.method, totalurlstring, true);
				} else {
					this.xmlhttp.open(this.method, this.requestFile, true);
				}
				if (this.method == "POST"){
  					try {
						this.xmlhttp.setRequestHeader('Content-Type','application/x-www-form-urlencoded')  
					} catch (e) {}
				}

				this.xmlhttp.send(this.URLString);
				this.xmlhttp.onreadystatechange = function() {
					switch (self.xmlhttp.readyState){
						case 1:
							self.onLoading();
						break;
						case 2:
							self.onLoaded();
						break;
						case 3:
							self.onInteractive();
						break;
						case 4:
							self.response = self.xmlhttp.responseText;
							self.responseXML = self.xmlhttp.responseXML;
							self.responseStatus[0] = self.xmlhttp.status;
							self.responseStatus[1] = self.xmlhttp.statusText;
							self.onCompletion();
							if(self.execute){ self.runResponse(); }
							if (self.elementObj) {
								var elemNodeName = self.elementObj.nodeName;
								elemNodeName.toLowerCase();
								if (elemNodeName == "input" || elemNodeName == "select" || elemNodeName == "option" || elemNodeName == "textarea"){
									self.elementObj.value = self.response;
								} else {
									self.elementObj.innerHTML = self.response;
								}
							}
							self.URLString = "";
						break;
					}
				};
			}
		}
	};
this.createAJAX();
}
				
					
	/* USER VARIABLES */
	
	var numberOfColumns = 2;	
	var columnParentBoxId = 'floatingBoxParentContainer';
	var src_rightImage = 'images/arrow_right.gif';
	var src_downImage = 'images/arrow_down.gif';
	var src_refreshSource = 'images/refresh.gif';
	var src_smallRightArrow = 'images/small_arrow.gif';
	
	var transparencyWhenDragging = false;
	var txt_editLink = '编辑';
	var txt_editLink_stop = '结束';
	var autoScrollSpeed = 4;	
	var dragObjectBorderWidth = 1;	
	
	var useCookiesToRememberRSSSources = true;
	
	var nameOfCookie = '<%=_zgbh%>' + 'dragable_rss_boxes';
	// END USER VARIABLES 
	
	
	
	var columnParentBox;
	var dragableBoxesObj;
	
	var ajaxObjects = new Array();
	
	var boxIndex = 0;	
	var autoScrollActive = false;
	var dragableBoxesArray = new Array();
	
	var dragDropCounter = -1;
	var dragObject = false;
	var dragObjectNextSibling = false;
	var dragObjectParent = false;
	var destinationObj = false;
	
	var mouse_x;
	var mouse_y;
	
	var el_x;
	var el_y;	
	
	var rectangleDiv;
	var okToMove = true;

	var documentHeight = false;
	var documentScrollHeight = false;
	var dragableAreaWidth = false;
		
	var opera = navigator.userAgent.toLowerCase().indexOf('opera')>=0?true:false;
	var cookieCounter=0;
	var cookieRSSSources = new Array();
	
	var staticObjectArray = new Array();
	
	var templateInfoArray = new Array(["综合信息"],["日程安排"],["公司文件"],["集团文件"]); 
	
	
	function Get_Cookie(name) { 
	   var start = document.cookie.indexOf(name+"="); 
	   var len = start+name.length+1; 
	   if ((!start) && (name != document.cookie.substring(0,name.length))) return null; 
	   if (start == -1) return null; 
	   var end = document.cookie.indexOf(";",len); 
	   if (end == -1) end = document.cookie.length; 
	   return unescape(document.cookie.substring(len,end)); 
	} 
	
	function Set_Cookie(name,value,expires,path,domain,secure) { 
		expires = expires * 60*60*24*1000;
		var today = new Date();
		var expires_date = new Date( today.getTime() + (expires) );
	    var cookieString = name + "=" +escape(value) + 
	       ( (expires) ? ";expires=" + expires_date.toGMTString() : "") + 
	       ( (path) ? ";path=" + path : "") + 
	       ( (domain) ? ";domain=" + domain : "") + 
	       ( (secure) ? ";secure" : ""); 
	    document.cookie = cookieString; 
	} 
	
	function delCookie(name)
	{
		var exp = new Date();
		exp.setTime(exp.getTime()-1);
		var cval = Get_Cookie(name);
		if(cval!=null) document.cookie= name + "=" +cval + ";expires=" + exp.toGMTString();
	}
	
		
	function autoScroll(direction,yPos)
	{
		if(document.documentElement.scrollHeight>documentScrollHeight && direction>0)return;
		if(opera)return;
		window.scrollBy(0,direction);
		if(!dragObject)return;
		
		if(direction<0){
			if(document.documentElement.scrollTop>0){
				dragObject.style.top = (el_y - mouse_y + yPos + document.documentElement.scrollTop) + 'px';		
			}else{
				autoScrollActive = false;
			}
		}else{
			if(yPos>(documentHeight-50)){	
				dragObject.style.top = (el_y - mouse_y + yPos + document.documentElement.scrollTop) + 'px';			
			}else{
				autoScrollActive = false;
			}
		}
		if(autoScrollActive)setTimeout('autoScroll('+direction+',' + yPos + ')',5);
	}
		
	function initDragDropBox(e)
	{
		
		
		dragDropCounter = 1;
		if(document.all)e = event;
		
		if (e.target) source = e.target;
			else if (e.srcElement) source = e.srcElement;
			if (source.nodeType == 3)
				source = source.parentNode;
		
		if(source.tagName.toLowerCase()=='img' || source.tagName.toLowerCase()=='a' || source.tagName.toLowerCase()=='input' || source.tagName.toLowerCase()=='td' || source.tagName.toLowerCase()=='tr' || source.tagName.toLowerCase()=='table')return;
		
	
		mouse_x = e.clientX;
		mouse_y = e.clientY;	
		var numericId = this.id.replace(/[^0-9]/g,'');
		el_x = getLeftPos(this.parentNode.parentNode)/1;
		el_y = getTopPos(this.parentNode.parentNode)/1 - document.documentElement.scrollTop;
			
		dragObject = this.parentNode.parentNode;
		
		documentScrollHeight = document.documentElement.scrollHeight + 100 + dragObject.offsetHeight;
		
		
		if(dragObject.nextSibling){
			dragObjectNextSibling = dragObject.nextSibling;
			if(dragObjectNextSibling.tagName!='DIV')dragObjectNextSibling = dragObjectNextSibling.nextSibling;
		}
		dragObjectParent = dragableBoxesArray[numericId]['parentObj'];
			
		dragDropCounter = 0;
		initDragDropBoxTimer();	
		
		return false;
	}
	
	
	function initDragDropBoxTimer()
	{
		if(dragDropCounter>=0 && dragDropCounter<10){
			dragDropCounter++;
			setTimeout('initDragDropBoxTimer()',10);
			return;
		}
		if(dragDropCounter==10){
			mouseoutBoxHeader(false,dragObject);
		}
		
	}

	function moveDragableElement(e){
		if(document.all)e = event;
		if(dragDropCounter<10)return;
		
		if(document.all && e.button!=1 && !opera){
			stop_dragDropElement();
			return;
		}
		
		if(document.body!=dragObject.parentNode){
			dragObject.style.width = (dragObject.offsetWidth - (dragObjectBorderWidth*2)) + 'px';
			dragObject.style.position = 'absolute';	
			dragObject.style.textAlign = 'left';
			if(transparencyWhenDragging){	
				dragObject.style.filter = 'alpha(opacity=70)';
				dragObject.style.opacity = '0.7';
			}	
			dragObject.parentNode.insertBefore(rectangleDiv,dragObject);
			rectangleDiv.style.display='block';
			document.body.appendChild(dragObject);

			rectangleDiv.style.width = dragObject.style.width;
			rectangleDiv.style.height = (dragObject.offsetHeight - (dragObjectBorderWidth*2)) + 'px'; 
			
		}
		
		if(e.clientY<50 || e.clientY>(documentHeight-50)){
			if(e.clientY<50 && !autoScrollActive){
				autoScrollActive = true;
				autoScroll((autoScrollSpeed*-1),e.clientY);
			}
			
			if(e.clientY>(documentHeight-50) && document.documentElement.scrollHeight<=documentScrollHeight && !autoScrollActive){
				autoScrollActive = true;
				autoScroll(autoScrollSpeed,e.clientY);
			}
		}else{
			autoScrollActive = false;
		}		

		
		var leftPos = e.clientX;
		var topPos = e.clientY + document.documentElement.scrollTop;
		
		dragObject.style.left = (e.clientX - mouse_x + el_x) + 'px';
		dragObject.style.top = (el_y - mouse_y + e.clientY + document.documentElement.scrollTop) + 'px';
								

		
		if(!okToMove)return;
		okToMove = false;

		destinationObj = false;	
		rectangleDiv.style.display = 'none'; 
		
		var objFound = false;
		var tmpParentArray = new Array();
		
		if(!objFound){
			for(var no=1;no<dragableBoxesArray.length;no++){
				if(dragableBoxesArray[no]['obj']==dragObject)continue;
				tmpParentArray[dragableBoxesArray[no]['obj'].parentNode.id] = true;
				if(!objFound){
					var tmpX = getLeftPos(dragableBoxesArray[no]['obj']);
					var tmpY = getTopPos(dragableBoxesArray[no]['obj']);

					if(leftPos>tmpX && leftPos<(tmpX + dragableBoxesArray[no]['obj'].offsetWidth) && topPos>(tmpY-20) && topPos<(tmpY + (dragableBoxesArray[no]['obj'].offsetHeight/2))){
						destinationObj = dragableBoxesArray[no]['obj'];
						destinationObj.parentNode.insertBefore(rectangleDiv,dragableBoxesArray[no]['obj']);
						rectangleDiv.style.display = 'block';
						objFound = true;
						break;
						
					}
					
					if(leftPos>tmpX && leftPos<(tmpX + dragableBoxesArray[no]['obj'].offsetWidth) && topPos>=(tmpY + (dragableBoxesArray[no]['obj'].offsetHeight/2)) && topPos<(tmpY + dragableBoxesArray[no]['obj'].offsetHeight)){
						objFound = true;
						if(dragableBoxesArray[no]['obj'].nextSibling){
							
							destinationObj = dragableBoxesArray[no]['obj'].nextSibling;
							if(!destinationObj.tagName)destinationObj = destinationObj.nextSibling;
							if(destinationObj!=rectangleDiv)destinationObj.parentNode.insertBefore(rectangleDiv,destinationObj);
						}else{
							destinationObj = dragableBoxesArray[no]['obj'].parentNode;
							dragableBoxesArray[no]['obj'].parentNode.appendChild(rectangleDiv);
						}
						rectangleDiv.style.display = 'block';
						break;					
					}
					
					
					if(!dragableBoxesArray[no]['obj'].nextSibling && leftPos>tmpX && leftPos<(tmpX + dragableBoxesArray[no]['obj'].offsetWidth)
					&& topPos>topPos>(tmpY + (dragableBoxesArray[no]['obj'].offsetHeight))){
						destinationObj = dragableBoxesArray[no]['obj'].parentNode;
						dragableBoxesArray[no]['obj'].parentNode.appendChild(rectangleDiv);	
						rectangleDiv.style.display = 'block';	
						objFound = true;				
						
					}
				}
				
			}
		
		}
		
		if(!objFound){
			
			for(var no=1;no<=numberOfColumns;no++){
				if(!objFound){
					var obj = document.getElementById('dragableBoxesColumn' + no);			
					
						var left = getLeftPos(obj)/1;						
					
						var width = obj.offsetWidth;
						if(leftPos>left && leftPos<(left+width)){
							destinationObj = obj;
							obj.appendChild(rectangleDiv);
							rectangleDiv.style.display='block';
							objFound=true;		
							
						}				
					
				}
			}		
			
		}
	

		setTimeout('okToMove=true',5);
		
	}
	
	function stop_dragDropElement()
	{
		
		if(dragDropCounter<10){
			dragDropCounter = -1
			return;
		}
		dragDropCounter = -1;
		if(transparencyWhenDragging){
			dragObject.style.filter = null;
			dragObject.style.opacity = null;
		}		
		dragObject.style.position = 'static';
		dragObject.style.width = null;
		var numericId = dragObject.id.replace(/[^0-9]/g,'');
		if(destinationObj && destinationObj.id!=dragObject.id){
			
			if(destinationObj.id.indexOf('dragableBoxesColumn')>=0){
				destinationObj.appendChild(dragObject);
				dragableBoxesArray[numericId]['parentObj'] = destinationObj;
			}else{
				destinationObj.parentNode.insertBefore(dragObject,destinationObj);
				dragableBoxesArray[numericId]['parentObj'] = destinationObj.parentNode;
			}


							
		}else{
			if(dragObjectNextSibling){
				dragObjectParent.insertBefore(dragObject,dragObjectNextSibling);	
			}else{
				dragObjectParent.appendChild(dragObject);
			}				
			
			
		}
	

		
		autoScrollActive = false;
		rectangleDiv.style.display = 'none'; 
		dragObject = false;
		dragObjectNextSibling = false;
		destinationObj = false;
		
		if(useCookiesToRememberRSSSources)setTimeout('saveCookies()',100);

		documentHeight = document.documentElement.clientHeight;	
	}

	function saveCookies()
	{
		cookieCounter = 0;
		var tmpUrlArray = new Array();
		for(var no=1;no<=numberOfColumns;no++)
		{
			var parentObj = document.getElementById('dragableBoxesColumn' + no);
			
			var items = parentObj.getElementsByTagName('DIV');
			if(items.length==0)continue;
			
			var item = items[0];
			
			var tmpItemArray = new Array();
			while(item){
				var boxIndex = item.id.replace(/[^0-9]/g,'');
				if(item.id!='rectangleDiv'){
					tmpItemArray[tmpItemArray.length] = boxIndex;
				}	
				item = item.nextSibling;			
			}
			
			var columnIndex = no;
			
			for(var no2=tmpItemArray.length-1;no2>=0;no2--){
				var boxIndex = tmpItemArray[no2];
				var url = dragableBoxesArray[boxIndex]['rssUrl'];
				var heightOfBox = dragableBoxesArray[boxIndex]['heightOfBox'];
				var maxRssItems = dragableBoxesArray[boxIndex]['maxRssItems'];
				var minutesBeforeReload = dragableBoxesArray[boxIndex]['minutesBeforeReload'];
				var uniqueIdentifier = dragableBoxesArray[boxIndex]['uniqueIdentifier'];
				var state = dragableBoxesArray[boxIndex]['boxState'];
				if(!tmpUrlArray[url]){
					tmpUrlArray[url] = true;
					
					Set_Cookie(nameOfCookie + cookieCounter,url + '#;#' + columnIndex + '#;#' + maxRssItems + '#;#' + heightOfBox + '#;#' + minutesBeforeReload + '#;#' + uniqueIdentifier + '#;#' + state ,60000);
					cookieRSSSources[url] = cookieCounter;
					cookieCounter++;	
				
				}else{
					
					Set_Cookie(nameOfCookie + cookieCounter,'' + '#;#' + columnIndex + '#;#' + '' + '#;#' + heightOfBox + '#;#' + '' + '#;#' + uniqueIdentifier ,60000);
					cookieCounter++;
				}		
				
			}
		}
	}
	
	
	function getTopPos(inputObj)
	{		
	  var returnValue = inputObj.offsetTop;
	  while((inputObj = inputObj.offsetParent) != null){
	  	if(inputObj.tagName!='HTML')returnValue += inputObj.offsetTop;
	  }
	  return returnValue;
	}
	
	function getLeftPos(inputObj)
	{
	  var returnValue = inputObj.offsetLeft;
	  while((inputObj = inputObj.offsetParent) != null){
	  	if(inputObj.tagName!='HTML')returnValue += inputObj.offsetLeft;
	  }
	  return returnValue;
	}
			
	
	function createColumns()
	{
		if(!columnParentBoxId){
			alert('No parent box defined for your columns');
			return;
		}
		columnParentBox = document.getElementById(columnParentBoxId);
		var columnWidth = Math.floor(100/numberOfColumns);
		var sumWidth = 0;
		for(var no=0;no<numberOfColumns;no++){
			var div = document.createElement('DIV');
			if(no==(numberOfColumns-1))columnWidth = 99 - sumWidth;
			sumWidth = sumWidth + columnWidth;
			div.style.cssText = 'float:left;width:'+columnWidth+'%;padding:0px;margin:0px;';
			div.style.height='100%';
			div.style.styleFloat='left';
			div.style.width = columnWidth + '%';
			div.style.padding = '0px';
			div.style.margin = '0px';

			div.id = 'dragableBoxesColumn' + (no+1);
			columnParentBox.appendChild(div);
			
			var clearObj = document.createElement('HR');	
			clearObj.style.clear = 'both';
			clearObj.style.visibility = 'hidden';
			div.appendChild(clearObj);
		}
		
		
		
		var clearingDiv = document.createElement('DIV');
		columnParentBox.appendChild(clearingDiv);
		clearingDiv.style.clear='both';
		
	}
	
	function mouseoverBoxHeader()
	{
		if(dragDropCounter==10)return;
		var id = this.id.replace(/[^0-9]/g,'');
		document.getElementById('dragableBoxExpand' + id).style.visibility = 'visible';		
		document.getElementById('dragableBoxRefreshSource' + id).style.visibility = 'visible';	
		if(document.getElementById('dragableBoxEditLink' + id))document.getElementById('dragableBoxEditLink' + id).style.visibility = 'visible';
		
	}
	function mouseoutBoxHeader(e,obj)
	{
		if(!obj)obj=this;
		
		var id = obj.id.replace(/[^0-9]/g,'');
		document.getElementById('dragableBoxExpand' + id).style.visibility = 'hidden';		
		document.getElementById('dragableBoxRefreshSource' + id).style.visibility = 'hidden';	
		if(document.getElementById('dragableBoxEditLink' + id))document.getElementById('dragableBoxEditLink' + id).style.visibility = 'hidden';		
		
	}
	
	function refreshRSS()
	{
		reloadRSSData(this.id.replace(/[^0-9]/g,''));
		setTimeout('dragDropCounter=-5',5);
	}
	
	function showHideBoxContent(e,inputObj)
	{
		if(document.all)e = event;
		if(!inputObj)inputObj=this;
		
		var numericId = inputObj.id.replace(/[^0-9]/g,'');
		var obj = document.getElementById('dragableBoxContent' + numericId);
		
		obj.style.display = inputObj.src.indexOf(src_rightImage)>=0?'none':'block';
		inputObj.src = inputObj.src.indexOf(src_rightImage)>=0?src_downImage:src_rightImage
		
		dragableBoxesArray[numericId]['boxState'] = obj.style.display=='block'?1:0;
		saveCookies();
		setTimeout('dragDropCounter=-5',5);
	}
	
	function mouseover_CloseButton()
	{
		this.className = 'closeButton_over';	
		setTimeout('dragDropCounter=-5',5);
	}
	
	function highlightCloseButton()
	{
		this.className = 'closeButton_over';	
	}
	
	function mouseout_CloseButton()
	{
		this.className = 'closeButton';	
	}
	
	
	function closeDragableBox(e,inputObj)
	{
		if(!inputObj)inputObj = this;
		var numericId = inputObj.id.replace(/[^0-9]/g,'');
		document.getElementById('dragableBox' + numericId).style.display='none';	
		delCookie(nameOfCookie + cookieRSSSources[dragableBoxesArray[numericId]['rssUrl']]);
		setTimeout('dragDropCounter=-5',5);
		
	}
	
	
	function addBoxHeader(parentObj,externalUrl,notDrabable,headText,url)
	{
		var div = document.createElement('DIV');
		div.className = 'dragableBoxHeader';
		
		div.id = 'dragableBoxHeader' + boxIndex;
		div.onmouseover = mouseoverBoxHeader;
		div.onmouseout = mouseoutBoxHeader;
		if(!notDrabable){
			div.onmousedown = initDragDropBox;
			div.style.cursor = 'move';
		}
		
		var image = document.createElement('IMG');
		image.id = 'dragableBoxExpand' + boxIndex;
		image.src = src_rightImage;
		image.style.visibility = 'hidden';	
		image.style.cursor = 'pointer';
		image.onmousedown = showHideBoxContent;	
		div.appendChild(image);
		
		
		var textSpan = document.createElement('SPAN');
		textSpan.id = 'dragableBoxHeader_txt' + boxIndex;
		div.appendChild(textSpan);
				
		parentObj.appendChild(div);	
		
		var image = document.createElement('IMG');
		image.src = src_refreshSource;
		image.id = 'dragableBoxRefreshSource' + boxIndex;
		image.style.cssText = 'float:right';
		image.style.styleFloat = 'right';
		image.style.visibility = 'hidden';
		image.onclick = refreshRSS;
		image.style.cursor = 'pointer';
		image.style.display='none';
		div.appendChild(image);
		
		var word = document.createElement('A');
		word.style.cssText = 'float:right';
		word.style.styleFloat = 'left';
		word.id = 'dragableBoxWord' + boxIndex;
		word.innerHTML = headText;
		div.appendChild(word);
		
		var more = document.createElement('A');
		more.style.cssText = 'float:right;color:#000000';
		more.style.styleFloat = 'right';
		more.id = 'dragableBoxMore' + boxIndex;
		more.innerHTML = '更多...';
		more.href = url;
		div.appendChild(more);		

	}
	
	function addBoxContentContainer(parentObj,heightOfBox)
	{
		var div = document.createElement('DIV');
		div.className = 'dragableBoxContent';
		if(opera)div.style.clear='none';
		div.id = 'dragableBoxContent' + boxIndex;
		parentObj.appendChild(div);			
		if(heightOfBox && heightOfBox/1>40){
			div.style.height = heightOfBox + 'px';
			div.setAttribute('heightOfBox',heightOfBox);
			div.heightOfBox = heightOfBox;	
			if(document.all)div.style.overflowY = 'auto';else div.style.overflow='-moz-scrollbars-vertical;';
			if(opera)div.style.overflow='auto';
		}		
	}
	

	function createABox(columnIndex,heightOfBox,externalUrl,uniqueIdentifier,notDragable,headText,url)
	{
		boxIndex++;
		
		var maindiv = document.createElement('DIV');
		maindiv.className = 'dragableBox';
		maindiv.id = 'dragableBox' + boxIndex;
		
		var div = document.createElement('DIV');
		div.className='dragableBoxInner';
		maindiv.appendChild(div);
		
		
		addBoxHeader(div,externalUrl,notDragable,headText,url);
		addBoxContentContainer(div,heightOfBox);
		
		var obj = document.getElementById('dragableBoxesColumn' + columnIndex);		
		var subs = obj.getElementsByTagName('DIV');
		if(subs.length>0){
			obj.insertBefore(maindiv,subs[0]);
		}else{
			obj.appendChild(maindiv);
		}
		
		dragableBoxesArray[boxIndex] = new Array();
		dragableBoxesArray[boxIndex]['obj'] = maindiv;
		dragableBoxesArray[boxIndex]['parentObj'] = maindiv.parentNode;
		dragableBoxesArray[boxIndex]['uniqueIdentifier'] = uniqueIdentifier;
		dragableBoxesArray[boxIndex]['heightOfBox'] = heightOfBox;
		dragableBoxesArray[boxIndex]['boxState'] = 1;
		
		staticObjectArray[uniqueIdentifier] = boxIndex;
		
		return boxIndex;
		
	}
	
	function showRSSData(ajaxIndex,boxIndex)
	{
		var rssContent = ajaxObjects[ajaxIndex].response;
		tokens = rssContent.split(/\n\n/g);
		
		
		var headerTokens = tokens[0].split(/\n/g);
		if(headerTokens[0]=='0'){
			headerTokens[1] = '';
			headerTokens[0] = 'Invalid source';
			closeDragableBox(false,document.getElementById('dragableBoxHeader_txt' + boxIndex));
			return;			
		}
		document.getElementById('dragableBoxHeader_txt' + boxIndex).innerHTML = '<span>' + headerTokens[0] + '&nbsp;<\/span><span class="rssNumberOfItems">(' + headerTokens[1] + ')<\/span>';	
		
		var string = '<table cellpadding="1" cellspacing="0">';
		for(var no=1;no<tokens.length;no++){
			var itemTokens = tokens[no].split(/##/g);			
			string = string + '<tr><td><img src="' + src_smallRightArrow + '"><td><p class=\"boxItemHeader\"><a class=\"boxItemHeader\" href="' + itemTokens[3] + '" onclick="var w = window.open(this.href);return false">' + itemTokens[0] + '<\/a><\/p><\/td><\/tr>';		
		}
		string = string + '<\/table>';
		document.getElementById('dragableBoxContent' + boxIndex).innerHTML = string;
		ajaxObjects[ajaxIndex] = false;
	}
	
	function reloadRSSData(numericId)
	{
		var ajaxIndex = ajaxObjects.length;
		ajaxObjects[ajaxIndex] = new sack();
		ajaxObjects[ajaxIndex].requestFile = 'readRSS.php?rssURL=' + escape(dragableBoxesArray[numericId]['rssUrl']) + '&maxRssItems=' + dragableBoxesArray[numericId]['maxRssItems'];	
		ajaxObjects[ajaxIndex].onCompletion = function(){ showRSSData(ajaxIndex,numericId); };
		ajaxObjects[ajaxIndex].runAJAX();
		
	}
		
	function createARSSBox(url,columnIndex,heightOfBox,maxRssItems,minutesBeforeReload,uniqueIdentifier,state)
	{
		if(uniqueIdentifier=='staticObject1')
		{		
		var titleOfNewBox = '';		
		var newIndex = createABox(1,130,false,'staticObject1',true,'待办事宜','USL/WorkFlow/Work_Manage.aspx');
		var panel_affair=document.getElementById('panel_affair');
		document.getElementById('dragableBoxContent' + newIndex).appendChild(panel_affair);	
		document.getElementById('dragableBoxHeader_txt' + newIndex).innerHTML = titleOfNewBox;		
		
		hideHeaderOptionsForStaticBoxes(staticObjectArray['staticObject1']);
		}
		else if(uniqueIdentifier=='staticObject2')
		{
		var titleOfNewBox = '';		
		var newIndex = createABox(2,130,false,'staticObject2',true,'电子邮件','USL/person/mail.aspx');
		var panel_mail=document.getElementById('panel_mail');
		document.getElementById('dragableBoxContent' + newIndex).appendChild(panel_mail);		
		document.getElementById('dragableBoxHeader_txt' + newIndex).innerHTML = titleOfNewBox;		
		
		hideHeaderOptionsForStaticBoxes(staticObjectArray['staticObject2']);
		}
		else
		{
		if(!heightOfBox)heightOfBox = '0';
		if(!minutesBeforeReload)minutesBeforeReload = '0';
				
		
		var headText;
		var innerObj;
		if(uniqueIdentifier=='notice')
		{
			headText=templateInfoArray[0];
			innerObj=document.getElementById('panel_notice');
		}
		else if(uniqueIdentifier=='schedule')
		{
			headText=templateInfoArray[1];
			innerObj=document.getElementById('panel_schedule');
		}
		else if(uniqueIdentifier=='log')
		{
			headText=templateInfoArray[2];
			innerObj=document.getElementById('panel_company');
		}
		else if(uniqueIdentifier=='book')
		{
			headText=templateInfoArray[3];
			innerObj=document.getElementById('panel_group');
		}		
					
		var tmpIndex = createABox(columnIndex,heightOfBox,true,uniqueIdentifier,false,headText,url);

		if(useCookiesToRememberRSSSources)
		{
			if(!cookieRSSSources[url]){
				cookieRSSSources[url] = cookieCounter;		
				Set_Cookie(nameOfCookie + cookieCounter,url + '#;#' + columnIndex + '#;#' + maxRssItems + '#;#' + heightOfBox + '#;#' + minutesBeforeReload + '#;#' + uniqueIdentifier + '#;#' + state  ,60000);
				cookieCounter++;
			}
		}		
		
		dragableBoxesArray[tmpIndex]['rssUrl'] = url;
		dragableBoxesArray[tmpIndex]['maxRssItems'] = maxRssItems?maxRssItems:100;
		dragableBoxesArray[tmpIndex]['minutesBeforeReload'] = minutesBeforeReload;
		dragableBoxesArray[tmpIndex]['heightOfBox'] = heightOfBox;
		dragableBoxesArray[tmpIndex]['uniqueIdentifier'] = uniqueIdentifier;
		dragableBoxesArray[tmpIndex]['state'] = state;

		if(state==0){
			showHideBoxContent(false,document.getElementById('dragableBoxExpand' + tmpIndex));
		}
		
		staticObjectArray[uniqueIdentifier] = tmpIndex;

       	var tmpInterval = false;
		if(minutesBeforeReload && minutesBeforeReload>0){
			var tmpInterval = setInterval("reloadRSSData(" + tmpIndex + ")",(minutesBeforeReload*1000*60));
		}

		dragableBoxesArray[tmpIndex]['intervalObj'] = tmpInterval;
			
		document.getElementById('dragableBoxContent' + tmpIndex).appendChild(innerObj);
		
		}	
	}
	
	function createHelpObjects()
	{
		rectangleDiv = document.createElement('DIV');
		rectangleDiv.id='rectangleDiv';
		rectangleDiv.style.display='none';
		document.body.appendChild(rectangleDiv);
		
		 
	}
	
	function cancelSelectionEvent(e)
	{
		if(document.all)e = event;
		
		if (e.target) source = e.target;
			else if (e.srcElement) source = e.srcElement;
			if (source.nodeType == 3)
				source = source.parentNode;
		if(source.tagName.toLowerCase()=='input')return true;
						
		if(dragDropCounter>=0)return false; else return true;	
		
	}
	
	function cancelEvent()
	{
		return false;
	}
	
	function initEvents()
	{
		document.body.onmousemove = moveDragableElement;
		document.body.onmouseup = stop_dragDropElement;
		document.body.onselectstart = cancelSelectionEvent;

		document.body.ondragstart = cancelEvent;	
		
		documentHeight = document.documentElement.clientHeight;	
		
	}
	

function createRSSBoxesFromCookie() 
   { 
      var tmpArray = new Array(); 
      var cookieValue = Get_Cookie(nameOfCookie + '0'); 
      cookieCounter=0; 
      while(cookieValue && cookieValue!='') 
        { 
         var items = cookieValue.split('#;#'); 
         var index = items[0]; 
         if(!items[0])index = items[5]; 
         if(items.length>1 && !tmpArray[index]) 
         { 
            tmpArray[index] = true; 
            createARSSBox(items[0],items[1],items[3],items[2],items[4],items[5],items[6]); 
            cookieRSSSources[items[0]]=cookieCounter-1; 
         } 
         else 
         { 
            cookieCounter++; 
         } 
         var cookieValue = Get_Cookie(nameOfCookie + cookieCounter); 
      } 
   }

	
	function clearCookiesForDragableBoxes()
	{
		var cookieValue = Get_Cookie(nameOfCookie + cookieCounter);
		while(cookieValue && cookieValue!=''){
			delCookie(nameOfCookie + cookieCounter)
			cookieCounter++;
			var cookieValue = Get_Cookie(nameOfCookie + cookieCounter);
		}		
		
	}
	
	function deleteAllDragableBoxes()
	{
		var divs = document.getElementsByTagName('DIV');
		for(var no=0;no<divs.length;no++){
			if(divs[no].className=='dragableBox')closeDragableBox(false,divs[no]);	
		}
			
	}
	

	function resetDragableBoxes()
	{
		cookieCounter = 0;
		clearCookiesForDragableBoxes();
		
		deleteAllDragableBoxes();
		cookieCounter = 0;
		cookieRSSSources = new Array();
		createDefaultBoxes();
	}
	
	function hideHeaderOptionsForStaticBoxes(boxIndex)
	{
		if(document.getElementById('dragableBoxRefreshSource' + boxIndex))document.getElementById('dragableBoxRefreshSource' + boxIndex).style.display='none';
		if(document.getElementById('dragableBoxCloseLink' + boxIndex))document.getElementById('dragableBoxCloseLink' + boxIndex).style.display='none';		
		if(document.getElementById('dragableBoxEditLink' + boxIndex))document.getElementById('dragableBoxEditLink' + boxIndex).style.display='none';		
	}
	
	
	
	function createDefaultBoxes()
	{
		if(cookieCounter==0){
			
		createARSSBox('USL/Gwgl/wdk_xz.aspx',1,108,100,1200,'log',true);		
		createARSSBox('USL/Person/Per_notice.aspx',1,108,100,1200,'notice',true);
		createARSSBox('USL/Gwgl/wdk_jt.aspx',2,108,100,1200,'book',true);
		createARSSBox('USL/Person/Per_schedule.aspx',2,108,100,1200,'schedule',true);						
		
		var titleOfNewBox = '';		
		var newIndex = createABox(1,108,false,'staticObject1',true,'待办事宜','USL/WorkFlow/Work_Manage.aspx');
		var panel_affair=document.getElementById('panel_affair');
		document.getElementById('dragableBoxContent' + newIndex).appendChild(panel_affair);	
		document.getElementById('dragableBoxHeader_txt' + newIndex).innerHTML = titleOfNewBox;		
		
		hideHeaderOptionsForStaticBoxes(staticObjectArray['staticObject1']);
		
		
		var titleOfNewBox = '';		
		var newIndex = createABox(2,108,false,'staticObject2',true,'电子邮件','USL/Person/mail.aspx');	
		document.getElementById('dragableBoxHeader_txt' + newIndex).innerHTML = titleOfNewBox;		
		var panel_mail=document.getElementById('panel_mail');
		document.getElementById('dragableBoxContent' + newIndex).appendChild(panel_mail);
		hideHeaderOptionsForStaticBoxes(staticObjectArray['staticObject2']);
		
		setTimeout('saveCookies()',100);
		}
	}
		
	function disableBoxDrag(boxIndex)
	{
			document.getElementById('dragableBoxHeader' + boxIndex).onmousedown = '';
			document.getElementById('dragableBoxHeader' + boxIndex).style.cursor = 'default';		
		
	}	
	
	function initDragableBoxesScript()
	{
		createColumns();
		createHelpObjects();	
		initEvents();	
		
		if(useCookiesToRememberRSSSources)createRSSBoxesFromCookie();
		createDefaultBoxes();
	}	
	
	window.onload = initDragableBoxesScript;
		</script>
	</HEAD>
	<body class="body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form class="body1" id="form" runat="server">
			<table class="body1" id="main" style="LEFT: 0px; POSITION: absolute; TOP: 0px" height="100%"
				width="100%">
				<tr>
					<td vAlign="top">
						<div id="floatingBoxParentContainer"></div>
					</td>
				<tr>
					<td>
						<DIV id="panel_affair" align="left"><asp:datalist id="grid_affair" Runat="server" Width="100%">
								<ItemTemplate>
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="100%"><A title='<%# DataBinder.Eval(Container.DataItem,"Doc_Title") %>' href='<%# DataBinder.Eval(Container.DataItem,"Style_Remark")%>?step_id=<%#DataBinder.Eval(Container.DataItem,"Step_ID")%>&amp;doc_id=<%#DataBinder.Eval(Container.DataItem,"Doc_ID")%>&amp;zgbh=<%#DataBinder.Eval(Container.DataItem,"Zgbh")%>'><FONT style="COLOR: #0000ff; TEXT-DECORATION: underline"><%# (DataBinder.Eval(Container.DataItem,"Doc_Title").ToString().Length>24)?DataBinder.Eval(Container.DataItem,"Doc_Title").ToString().Substring(0,24)+"...":DataBinder.Eval(Container.DataItem,"Doc_Title").ToString() %></FONT></A>&nbsp;</TD>
											<TD>
												<asp:Label id="Label2" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"Doc_Added_Date")%>
												</asp:Label></TD>
										</TR>
									</TABLE>
								</ItemTemplate>
							</asp:datalist></DIV>
						<DIV></DIV>
					</td>
				</tr>
				<tr>
					<td>
						<DIV id="panel_mail" align="left"><asp:datalist id="grid_mail" Runat="server" Width="100%">
								<ItemTemplate>
									<table cellspacing="0" cellpadding="0" width="100%" border="0">
										<tr>
											<td width="100%">&nbsp;</td>
										</tr>
									</table>
								</ItemTemplate>
							</asp:datalist></DIV>
						<DIV></DIV>
					</td>
				</tr>
				<tr>
					<td>
						<DIV id="panel_notice" align="left"><asp:datalist id="grid_notice" Runat="server" Width="100%" DataKeyField="Zhxx_Xxfb_Id">
								<ItemTemplate>
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="100%"><A title='<%# DataBinder.Eval(Container.DataItem,"Zhxx_Xxfb_Bt") %>' href='USL/Person/notice_details.aspx?Zhxx_Xxfb_Id=<%# DataBinder.Eval(Container.DataItem,"Zhxx_Xxfb_Id") %>'><FONT style="COLOR: #0000ff; TEXT-DECORATION: underline"><%# (DataBinder.Eval(Container.DataItem,"Zhxx_Xxfb_Bt").ToString().Length>20)?DataBinder.Eval(Container.DataItem,"Zhxx_Xxfb_Bt").ToString().Substring(0,20)+"...":DataBinder.Eval(Container.DataItem,"Zhxx_Xxfb_Bt").ToString() %></FONT></A>&nbsp;
												<asp:Image id="Image1" runat="server" ImageUrl="images/newLogo.gif"></asp:Image></TD>
											<TD>
												<asp:Label id="Label1" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"Zhxx_Xxfb_Sqrq")%>
												</asp:Label></TD>
										</TR>
									</TABLE>
								</ItemTemplate>
							</asp:datalist></DIV>
						<DIV><FONT face="宋体"></FONT></DIV>
					</td>
				</tr>
				<tr>
					<td>
						<DIV id="panel_schedule" align="left"><asp:datalist id="grid_schedule" Runat="server" Width="100%" DataKeyField="Id">
								<ItemTemplate>
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="100%"><A title='<%# DataBinder.Eval(Container.DataItem,"Subject") %>' href='USL/Person/schedule_details.aspx?Id=<%# DataBinder.Eval(Container.DataItem,"Id") %>&amp;Type=1'><FONT style="COLOR: #0000ff; TEXT-DECORATION: underline"><%# (DataBinder.Eval(Container.DataItem,"Subject").ToString().Length>24)?DataBinder.Eval(Container.DataItem,"Subject").ToString().Substring(0,24)+"...":DataBinder.Eval(Container.DataItem,"Subject").ToString() %></FONT></A>&nbsp;</TD>
											<TD>
												<asp:Label id="Label3" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"StartTime")%>
												</asp:Label></TD>
										</TR>
									</TABLE>
								</ItemTemplate>
							</asp:datalist></DIV>
						<DIV><FONT face="宋体"></FONT></DIV>
					</td>
				</tr>
				<tr>
					<td>
						<DIV id="panel_company" align="left"><asp:datalist id="grid_company" Runat="server" Width="100%" DataKeyField="Id">
								<ItemTemplate>
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="100%"><A title='<%# DataBinder.Eval(Container.DataItem,"doc_name") %>' href='<%# DataBinder.Eval(Container.DataItem, "doc_type")%>?id=<%# DataBinder.Eval(Container.DataItem,"id") %>&amp;filename=<%# DataBinder.Eval(Container.DataItem,"DocNamePara")%>'><FONT style="COLOR: #0000ff; TEXT-DECORATION: underline"><%# (DataBinder.Eval(Container.DataItem,"doc_name").ToString().Length>20)?DataBinder.Eval(Container.DataItem,"doc_name").ToString().Substring(0,20)+"...":DataBinder.Eval(Container.DataItem,"doc_name").ToString() %></FONT></A>&nbsp;
												<asp:Image id="Image2" runat="server" ImageUrl="images/newLogo.gif"></asp:Image></TD>
											<TD>
												<asp:Label id="Label4" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"doc_time")%>
												</asp:Label></TD>
										</TR>
									</TABLE>
								</ItemTemplate>
							</asp:datalist></DIV>
						<DIV><FONT face="宋体"></FONT></DIV>
					</td>
				</tr>
				<tr>
					<td>
						<DIV id="panel_group" align="left"><asp:datalist id="grid_group" Runat="server" Width="100%" DataKeyField="Id">
								<ItemTemplate>
									<table cellspacing="0" cellpadding="0" width="100%" border="0">
										<TR>
											<TD width="100%"><A title='<%# DataBinder.Eval(Container.DataItem,"doc_name") %>' href='USL/filetosql/Download_fj.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id") %>&amp;filename=<%# DataBinder.Eval(Container.DataItem,"DocNamePara")%>'><FONT style="COLOR: #0000ff; TEXT-DECORATION: underline"><%# (DataBinder.Eval(Container.DataItem,"doc_name").ToString().Length>20)?DataBinder.Eval(Container.DataItem,"doc_name").ToString().Substring(0,20)+"...":DataBinder.Eval(Container.DataItem,"doc_name").ToString() %></FONT></A>&nbsp;
												<asp:Image id="Image3" runat="server" ImageUrl="images/newLogo.gif"></asp:Image></TD>
											<TD>
												<asp:Label id="Label5" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"doc_time")%>
												</asp:Label></TD>
										</TR>
									</table>
								</ItemTemplate>
							</asp:datalist></DIV>
						<DIV><FONT face="宋体"></FONT></DIV>
					</td>
				</tr>
				</tr></table>
		</form>
	</body>
</HTML>