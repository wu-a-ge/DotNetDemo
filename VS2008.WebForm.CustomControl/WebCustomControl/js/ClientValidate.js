//主验证函数
function ClientNumValidateFunc(val)
{
    var value = ValidatorGetValue(val.controltovalidate);
    var allowNull = val.allowNull;    
    if( value == "" || value == null)
    {        
        if (allowNull.toUpperCase() == "FALSE")
        {            
            return false;
        }
        else
        {         
            return true;
        }    
    }        
    return RegexMatch(value,/^\d+$/);

}

//正则表达式匹配函数
function RegexMatch(str,exp)
{
      var result = false ;
      r = str.search(exp);
      if (r != -1) {
          result =true ;
      }
      return(result);
}

//重写ValidatorUpdateDisplay方法
function ValidatorUpdateDisplay(val) 
{
   //自定义逻辑
   if(val.useToolTip.toUpperCase() == "TRUE" && val.isvalid == false)
   {
       DisplayTooTipMessage(val);
       return; 
   }   
    
   //默认逻辑 
   if (typeof(val.display) == "string") 
   {
        if (val.display == "None") 
        {
            return;
        }
        if (val.display == "Dynamic") 
        {
            val.style.display = val.isvalid ? "none" : "inline";
            return;
        }
    }
    if ((navigator.userAgent.indexOf("Mac") > -1) &&
        (navigator.userAgent.indexOf("MSIE") > -1)) 
    {
        val.style.display = "inline";
    }
    val.style.visibility = val.isvalid ? "hidden" : "visible";
}

//设置Tooltip内容,并设置为可见状态
function DisplayTooTipMessage(val)
{
   var validateToolTip_Main = document.getElementById("ValidateToolTip_Main");
    var validateToolTip_MessageText = document.getElementById("ValidateToolTip_MessageText");
    var obj = document.getElementById(val.controltovalidate);   
    
    validateToolTip_MessageText.innerText = val.errormessage;
    
    validateToolTip_MessageText.style.color = val.foreColor;
    
     validateToolTip_Main.style.display = 'block';               
     var x = ie_x(obj);
     var y = ie_y(obj); 
     validateToolTip_Main.style.left = x + obj.offsetWidth + 1;
     validateToolTip_Main.style.top = y + obj.offsetHeight/2 - validateToolTip_Main.offsetHeight/2 - 8;     
}

function ie_y(e)
{  
	var t=e.offsetTop;  
	while(e=e.offsetParent){  
		t+=e.offsetTop;  
	}  
	return t;  
}  
function ie_x(e)
{  
	var l=e.offsetLeft;  
	while(e=e.offsetParent){  
		l+=e.offsetLeft;  
	}  
	return l;  
}