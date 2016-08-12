<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsUnity.aspx.cs" Inherits="VS2010.WebForm.Test.JsUnity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="js/jsunity-0.6注释版.js"></script>
    <script type="text/javascript">
    function sampleTestSuite() {
	function setUp() {
		jsUnity.log("set up");
	}

	function tearDown() {
		jsUnity.log("tear down");
	}

	function testLessThan() {
		assertTrue(1 < 2);
	}
	
	function testPi() {
		assertEquals(Math.PI, 22 / 7);
	}
}

// optionally wire the log function to write to the context
jsUnity.log = function (s) { document.write(s + "\r\n"); };
// expose the default assertion functions to the current scope
jsUnity.attachAssertions();
var results = jsUnity.run(sampleTestSuite);
//alert(results);
// if result is not false,
// access results.total, results.passed, results.failed
    </script>
<%--    <script type="text/javascript" src="js/jquery-1.5.1.debug.js"></script>
    <script type="text/javascript">
        function ajaxtest() {
            $.get("/JsUnity.aspx", { ajax: true }, function (data) {
                alert(data);
                $(data).find("item").each(function () {
                    $(document.getElementById("show")).html($(this).text());
//                    alert($(this).html());
                });
            });
        }
           
       
    </script>--%>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" name="name" value=" " onclick="ajaxtest()" />
        <ul id="show">
        </ul>
    </div>
    </form>
</body>
</html>
