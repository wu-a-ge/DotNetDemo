//argument为控件的Value属性的最初始值
function Default_ClientCallBackResult(argument, context)
{
    var txt = document.getElementById(context.ControlClientID);
    var value;                
    //此方法可以把这样的格式: "5 天", 转化为这样的格式: "5"
    value = parseInt(txt.value);                 
    var strValue;
    switch(context.Direction)
    {
        case 'UP':  strValue = (value+1).toString(); break;
        case 'DOWN':strValue = (value-1).toString(); break;
    }                        
    txt.value = strValue + ' ' + context.UnitText; 
    
    //在点击控件内部"UP"和"DOWN"按钮时把文本框值赋值给隐藏控件
    //document.getElementById(context.HiddenClientID).value = strValue;            
    SetHiddenFieldWhenSubmit(context.ControlClientID,context.HiddenClientID);
    
    if(context.OnClientCallBackResult != null && context.OnClientCallBackResult != '')
    {       
        var func = window.eval(context.OnClientCallBackResult);
        
        context.OnClientCallBackResult = null;
        context.HiddenClientID = null;
        
        func(txt.value, context);
    }
}

//在页面提交时, 把文本框值赋值给隐藏控件. [如果在页面提交时缺少此步骤, 则在第二次提交时数据就会丢失, 第一次提交时值还在是因为刚刚执行了 Default_ClientCallBackResult方法].
function SetHiddenFieldWhenSubmit(txt_clientid, hidden_clientid)
{
    var txt = document.getElementById(txt_clientid);
    var hidden = document.getElementById(hidden_clientid);
    hidden.value = parseInt(txt.value);
}