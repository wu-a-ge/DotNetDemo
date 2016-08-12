<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWebWorkers.aspx.cs" Inherits="VS2010.WebForm.Test.TestWebWorkers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/json2.js"></script>
    <script>
        var jsonText = {a:"ok",b:"b"};
        var worker = new Worker("/js/test.js");
        //when the data is available, this event handler is called
        worker.onmessage = function (event) {
            //the JSON structure is passed back
            var jsonData = event.data;
            //the JSON structure is used
            alert(jsonData.a);
        };
        //pass in the large JSON string to parse
        worker.postMessage(JSON.stringify(jsonText));
    </script>
    <script>
      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
