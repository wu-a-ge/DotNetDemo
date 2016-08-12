<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabJs.aspx.cs" Inherits="VS2010.WebForm.Test.LabJs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script type="text/javascript" src="js/LAB.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script>
        $LAB
            .script("js/jquery-1.9.1.js").wait()
            .script("js/json2.js");
            

</script>
    </div>
    </form>
</body>
</html>
