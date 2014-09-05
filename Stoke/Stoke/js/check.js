// JScript 文件

var http_request=false;
    function createRequest()
    { 
       
        try//IE
        {
            http_request=new ActiveXObject("Msxml2.XMLHTTP");
        } 
        catch (e) 
        {
            try 
            {
                http_request = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e2) 
            {
                http_request = false;
            }
        }
        if (!http_request && typeof XMLHttpRequest != 'undefined') //FireFox
        {
            http_request = new XMLHttpRequest();
        }
    }
    function callserver()
    {
        createRequest();
        var strText=document.getElementById("h").value;
        if(strText==""||strText==null)
            return ;
        var url="checkForTravel.aspx?address="+escape(strText);
        http_request.onreadystatechange=updatepage;
        http_request.open("GET",url,true);
        http_request.send(null); 
    }
    function updatepage()
    {   
        var obj=document.getElementById("msgDiv");
        if(http_request.readyState == 4)
        {
            if(http_request.status==200)
            {
                var response=http_request.responseText;	
                if(response.indexOf("150")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于150.00元！";					
				}
				else
				if(response.indexOf("180")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于180.00元！";					
				}
				else
				if(response.indexOf("200")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于200.00元！";					
				}
				else
				if(response.indexOf("240")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于240.00元！";					
				}
				else
				if(response.indexOf("400")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于400.00元！";					
				}
				else
				if(response.indexOf("480")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于480.00元！";					
				}
				else
				if(response.indexOf("500")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于500.00元！";					
				}
				else
				if(response.indexOf("600")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于600.00元！";					
				}
				else
				if(response.indexOf("720")!=-1)
                {
					obj.className="Right";
					obj.innerHTML="提示：根据您的职位及出差地点，您的住宿标准每天不得高于720.00元！";					
				}
				}
        }
        else
        {   //异步传输失败
            obj.innerHTML='链接数据库失败，无法进行住宿标准提示！';
   
        }
    }

