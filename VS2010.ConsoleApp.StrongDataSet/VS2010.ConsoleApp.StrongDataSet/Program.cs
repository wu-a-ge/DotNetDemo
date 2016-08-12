using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VS2010.ConsoleApp.StrongDataSet.DataSet1TableAdapters;

namespace VS2010.ConsoleApp.StrongDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersTableAdapter cda = new CustomersTableAdapter();
             DataSet1.CustomersDataTable cdt= cda.GetData();
        }
    }
}
