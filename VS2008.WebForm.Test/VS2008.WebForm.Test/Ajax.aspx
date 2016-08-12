<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="VS2008.WebForm.Test.Ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>

    <script type="text/javascript" src="jquery-1.4.4.min.js"></script>

    <script type="text/javascript">
        //对WEBService调用
        //        $.get("/WebService1.asmx/GetXML", function(data) {

//                    alert(data);
//                });
                $.ajax({
                    url: "/WebService1.asmx/GetJSON",
                    type: "get",
                    contentType: "application/json",
                   success: function(data) { alert(data); }

                });
        //        $.post("/WebService1.asmx/PostXML", function(data) {

        //            alert(data);
        //        });
        //        $.ajax({
        //            url: "/WebService1.asmx/PostJSON",
        //            type: "post",
        //            contentType: "application/json",
        //            success: function(data) { alert(data); }

        //        });
        //后台静态方法
//        $.get("/ajax.aspx/GetXML", function(data) {

//            alert(data);
//        });

//        $.ajax({
//            url: "/ajax.aspx/GetJSON",
//            type: "get",
//            contentType: "application/json",
//            success: function(data) { alert(data); }

//        });
//        $.post("/ajax.aspx/PostXML", function(data) {

//            alert(data);
//        });
//        $.ajax({
//            url: "/ajax.aspx/PostJSON",
//            type: "post",
//            contentType: "application/json",
//            success: function(data) { alert(data); }

//        });
        //ajax中对对象数据进行了序列化的，并且进行了编码，所以这里不应该对数据进行编码
//        $.post("/ajax.aspx", { aa: ('中文汉字') }, function(data) {
//            alert(data);
//        });
    </script>

</head>
<body>

</body>
</html>
