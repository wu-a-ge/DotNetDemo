/*
以下对jquery类的扩展
功能说明：
//扩展cookie
setCookie:添加cookie
deleteCookie:删除cookie
getCookide:取得cookie值
clearCookie：删除所有的cookie
//扩展事件，以下方法封装了IE和FF之间的差异，使其保持与FF的标准一致
formatEvent:主要是格式化IE中的事件对象event，
getEvent：在事件处理函数中取得事件对象
addEventHandler:对DOM元素添加事件处理函数
removeEventHandler:移出DOM元素中的事件处理函数
//实用方法
checkAll:全选复选框方法
checkItem:单击子组项复选框方法
*/
(function() {
    jQuery.extend({
        setCookie: function(sName, sValue, dExpire, sPath, sDomain, bSecure) {
            document.cookie = sName + "=" + encodeURIComponent(sValue);
            if (dExpire)
                document.cookie += "; expires=" + dExpire.toGMTString();
            if (sPath)
                document.cookie += "; path=" + path;
            if (sDomain) {
                document.cookie += "; domain=" + sDomain;
            }
            if (bSecure) {
                document.cookie += "; secure=";
            }
        },
        deleteCookie: function(sName, sPath, sDomain) {
            var sCookie = sName + "=; expires=" + (new Date(0)).toGMTString();
            if (sPath) {
                sCookie += "; path=" + sPath;
            }

            if (sDomain) {
                sCookie += "; domain=" + sDomain;
            }
            document.cookie = sCookie;
        },
        getCookie: function(name) {

            var reg = new RegExp("(?:; )?" + name + "=([^;]*);?");
            if (!reg.test(document.cookie))
                return "";
            return decodeURIComponent(RegExp.$1);
        },
        clearCookie: function() {
            var arrCookies = document.cookie.split("; ");
            var i;
            var name;
            for (i = 0; i < arrCookies.length; i++) {
                name = arrCookies[i].split("=")[0];
                this.deleteCookie(name);
            }
        }
    });
    //扩展事件
    jQuery.extend({
        formatEvent: function(oEvent) {
            if ($.browser.msie) {
                oEvent.charCode = (oEvent.type == "keypress") ? oEvent.keyCode : 0;
                oEvent.eventPhase = 2;
                oEvent.isChar = (oEvent.charCode > 0);
                oEvent.pageX = oEvent.clientX + document.body.scrollLeft;
                oEvent.pageY = oEvent.clientY + document.body.scrollTop;
                oEvent.preventDefault = function() {
                    this.returnValue = false;
                };
                if (oEvent.type == "mouseout") {
                    oEvent.relatedTarget = oEvent.toElement;
                } else if (oEvent.type == "mouseover") {
                    oEvent.relatedTarget = oEvent.fromElement;
                }
                oEvent.stopPropagation = function() {
                    this.cancelBubble = true;
                };
                oEvent.target = oEvent.srcElement;
                oEvent.time = (new Date).getTime();
            }
            return oEvent;
        },
        getEvent: function() {
            if (window.event) {
                return this.formatEvent(window.event);
            } else {
                return this.getEvent.caller.arguments[0];
            }
        },
        addEventHandler: function(oTarget, sEventType, fnHandler) {
            if (oTarget.addEventListener) {
                oTarget.addEventListener(sEventType, fnHandler, false);
            } else if (oTarget.attachEvent) {
                oTarget.attachEvent("on" + sEventType, fnHandler);
            } else {
                oTarget["on" + sEventType] = fnHandler;
            }
        },
        removeEventHandler: function(oTarget, sEventType, fnHandler) {
            if (oTarget.removeEventListener) {
                oTarget.removeEventListener(sEventType, fnHandler, false);
            } else if (oTarget.detachEvent) {
                oTarget.detachEvent("on" + sEventType, fnHandler);
            } else {
                oTarget["on" + sEventType] = null;
            }
        }
    });
    //扩展一些实用方法
    $.extend({
        //两个参数，第一个参数是事件对象，第二个参数是子组复选框的组名
        checkAll: function() {
            var allDom = arguments[0].target; //已经被修正后的事件对象
            var itemDoms = document.getElementsByName(arguments[1]);
            for (var i = 0; i < itemDoms.length; i++)
                itemDoms[i].checked = allDom.checked;
        },
        //两个参数，第一个参数是事件对象，第二个参数是全选框的ID
        checkItem: function() {
            var itemDom = arguments[0].target; ////已经被修正后的事件对象
            var allDom = document.getElementById(arguments[1]);
            if (itemDom.checked) {
                var itemDoms = document.getElementsByName(itemDom.name);
                allDom.checked = true;
                for (var i = 0; i < itemDoms.length; i++) {
                    if (!itemDoms[i].checked) {
                        allDom.checked = false; break;
                    }
                }
            }
            else
                allDom.checked = false;
        }
    });
    //jquery的ajax扩展，针对asp.net
    $.extend({
        //默认缓存请求，且异步，因为在使用GET方法时有时要用到同步或要求不缓存
        getAspNetJSON: function(url, data, onsuccess, onerror, async,cache) {
            jQuery.ajax({
                async: async === false ? false : true,
                cache: cache === false ? false : true,
                type: "GET",
                url: url,
                data: data,
                error: onerror,
                success: onsuccess,
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            });
        },
        postAspNetJSON: function(url, data, onsuccess, onerror) {
            jQuery.ajax({
                type: "POST",
                url: url,
                data: data,
                error: onerror,
                success: onsuccess,
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            });
        }
    });

})();