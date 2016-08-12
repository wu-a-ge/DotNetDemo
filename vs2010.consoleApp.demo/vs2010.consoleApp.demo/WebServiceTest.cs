using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vs2010.consoleApp.demo
{
    class WebServiceTest
    {
        public static void TestLocalhost()
        {
            localhost1.WsdlSearchable searchable = new localhost1.WsdlSearchable();
            Console.WriteLine(searchable.getUserHistoryData("user_history_log", "2_1_A0032_1", "0", 2, 1, null, true,
                                                            false, null, "1"));

        }
    }
}
