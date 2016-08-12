// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//------------------------------------------------------------------------------
//Partial class that extends existing Northwind class.
//------------------------------------------------------------------------------

namespace nwind {
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    using System.ComponentModel;
    using System;

    public partial class Northwind {

        //还是没有发现此分部方法在哪里被调用 ！！神马情况！
        // For CUD Override Sample
        partial void InsertRegion(Region instance)
        {
            // This partial method is calling ExecuteDynamicInsert to insert the Region instance.
            // Instead of the ExecuteDynameicInsert method, a stored procedure could be called 
            // here to take in parameters and insert a instance to the table .
            Console.WriteLine("***** Executing InsertRegion Override ******");
            Console.WriteLine("Calling up ExecuteDynamicInsert on a Region instance");
            this.ExecuteDynamicInsert(instance);
        }
        //这TM哪里是个分部方法？绝对不是分部方法，但是也没有发现被调用的地方，我擦 啊！
        // For Load Override Sample
        private IEnumerable<Product> LoadProducts(Category category)
        {
            // This partial method is calling a LinqToSql query to load the products for a category
            // Instead of the LinqToSQL query, A stored procedure can also be also be called here to load products 
            Console.WriteLine("******** Using LinqToSQL query to load products belong to category that are not discontinued. ******");
            return this.Products.Where(p => p.CategoryID == category.CategoryID).Where(p => !p.Discontinued);
        }



    }
    // For Extensible Partial Method
    public partial class Order {

        [System.Diagnostics.DebuggerNonUserCode]
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            switch (action)
            {
                case ChangeAction.Delete:
                    break;
                case ChangeAction.Insert:
                    break;
                case ChangeAction.Update:
                    if (this.ShipVia > 100)
                        throw new Exception("Exception: ShipVia cannot be bigger than 100");
                    break;
                case ChangeAction.None:
                    break;

                default:
                    break;
            }

        }
    }
}
