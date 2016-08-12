(function () {
    //保存修改密码
    function serverLogin() {
        var $newpass = $('#txtNewPass');
        var $rePass = $('#txtRePass');
        if ($newpass.val() == '') {
            msgShow('系统提示', '请输入密码！', 'warning');
            return false;
        }
        if ($rePass.val() == '') {
            msgShow('系统提示', '请在一次输入密码！', 'warning');
            return false;
        }
        if ($newpass.val() != $rePass.val()) {
            msgShow('系统提示', '两次密码不一至！请重新输入', 'warning');
            return false;
        }
        //            $.post('/ajax/editpassword.ashx?newpass=' + $newpass.val(), function (msg) {
        //                msgShow('系统提示', '恭喜，密码修改成功！<br>您的新密码为：' + msg, 'info');
        //                $newpass.val('');
        //                $rePass.val('');
        //                close();
        //            })

    }
    $(function () {
        $('#editpass').click(function () {
            $('#modifypwd').window('open');
        });
        $('#btnEp').click(function () {
            serverLogin();
        })
        $('#btnCancel').click(function () { $('#modifypwd').window('close'); })
        $('#loginOut').click(function () {
            $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (r) {
                if (r) {
                    location.href = '/ajax/loginout.ashx';
                }
            });
        })
    });
    //初始化左侧
    function initLeftMenu(json) {
        var jqLeftAccordion = $(".easyui-accordion");
        jqLeftAccordion.empty();
        $.each(json.root.menu, function (i, menu) {
            var panelCotent = "";
            panelCotent += '<ul>';
            $.each(menu.item, function (j, item) {
                panelCotent += '<li><div><a ref="' + item["@id"] + '" href="javascript:void(0)" rel="' + item["@url"] + '" ><span class="icon ' + item["@icon"] + '" >&nbsp;</span><span class="nav">' + item["@menuname"] + '</span></a></div></li> ';
            })
            panelCotent += '</ul>';
            var panel = {
                title: menu["@menuname"],
                iconCls: menu["@icon"],
                //                style: { overflow: auto },
                selected: false,
                content: panelCotent

            };
            jqLeftAccordion.accordion('add', panel);

        });
        jqLeftAccordion.accordion("select", 0);

        //为每个左侧菜单每一项绑定事件，点击时提取相关信息显示到右侧tab上
        $("#west").on({
            click: function () {
                var jqHref = $(this);
                var tabTitle = jqHref.children('.nav').text();
                var url = jqHref.prop("rel");
                var menuid = jqHref.prop("ref");
                var icon = jqHref.find("span:first").prop("className");
                //相关信息显示到右侧tab上
                addTab(tabTitle, url, icon);
                //设置被选中时的样式 
                jqLeftAccordion.find('li div').removeClass("selected");
                jqHref.parent().addClass("selected");
            },
            mouseenter: function (e) { $(this).parent().addClass("selected") },
            mouseleave: function (e) { $(this).parent().removeClass("selected") }
        }
        , "div.easyui-accordion  li a");
    }
    //新建一个tab或选中一个tab
    function addTab(subtitle, url, icon) {
        if (!$('#tabs').tabs('exists', subtitle)) {
            $('#tabs').tabs('add', {
                title: subtitle,
                content: createFrame(url),
                fit:true,
                closable: true,
                iconCls: icon
            });
        } else {
            $('#tabs').tabs('select', subtitle);
        }
    }
    //tab的内容放在iframe中，远程载入
    function createFrame(url) {
        var s = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
        return s;
    }
    //绑定tab的关闭事件和弹出菜单事件
    function initialTabClose() {
        var jqTabs = $("#tabs");
        var jqTabMenu = $('#tabmenu');
        //事件委派，为后续添加的tab绑定关闭事件和弹出菜单事件
        jqTabs.on({
            dbclick: function () {
                var subtitle = $(this).text();
                jqTabs.tabs('close', subtitle);
            }
        ,
            contextmenu: function (e) {
                jqTabMenu.menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
                var subtitle = $(this).text();
                jqTabMenu.data("currtab", subtitle);
                jqTabs.tabs('select', subtitle);
                return false;

            }
        }
        , "a.tabs-inner");
        //关闭当前
        $('#mm-tabclose').click(function () {
            var currtab_title = jqTabMenu.data("currtab");
            jqTabs.tabs('close', currtab_title);
        })
        //全部关闭
        $('#mm-tabcloseall').click(function () {
            jqTabs.find('a.tabs-inner span:first-child').each(function (i, n) {
                var title = $(n).text();
                jqTabs.tabs('close', title);
            });
        });
        //关闭除当前之外的TAB
        $('#mm-tabcloseother').click(function () {
            var currtab_title = jqTabMenu.data("currtab");
            jqTabs.find('a.tabs-inner span:first-child').each(function (i, n) {
                var t = $(n).text();
                if (t != currtab_title)
                    jqTabs.tabs('close', t);
            });
        });
        //关闭当前右侧的TAB
        $('#mm-tabcloseright').click(function () {
            var nextall = jqTabs.find('li.tabs-selected').nextAll();
            if (nextall.length == 0) {
                return false;
            }
            nextall.each(function (i, n) {
                var t = $(n).find('a:first span:first').text();
                jqTabs.tabs('close', t);
            });
            return false;
        });
        //关闭当前左侧的TAB
        $('#mm-tabcloseleft').click(function () {
            var prevall = jqTabs.find('li.tabs-selected').prevAll();
            if (prevall.length == 0) {
                return false;
            }
            prevall.each(function (i, n) {
                var t = $(n).find('a:first span:first').text();
                jqTabs.tabs('close', t);
            });
            return false;
        });

        //退出
        $("#mm-exit").click(function () {
            jqTabMenu.menu('hide');
        })
    }
    //本地时钟
    function showTime() {
        var now = new Date();
        var year = now.getFullYear(); //getFullYear getYear
        var month = now.getMonth();
        var date = now.getDate();
        var day = now.getDay();
        var hour = now.getHours();
        var minu = now.getMinutes();
        var sec = now.getSeconds();
        var week;
        month = month + 1;
        if (month < 10) month = "0" + month;
        if (date < 10) date = "0" + date;
        if (hour < 10) hour = "0" + hour;
        if (minu < 10) minu = "0" + minu;
        if (sec < 10) sec = "0" + sec;
        var arr_week = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六");
        week = arr_week[day];
        var time = "";
        time = year + "年" + month + "月" + date + "日" + " " + hour + ":" + minu + ":" + sec + " " + week;
        $("#bgclock").html(time);
        var timer = setTimeout(showTime, 200);
    }
    $(function () {
        initialTabClose();
        showTime();
        $.getJSON("/ajax/menuconfig.ashx").done(initLeftMenu).fail(function () {
            alert("系统初始化失败！");
        });
    })
})();
