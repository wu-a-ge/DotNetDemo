using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
using System.Data.Linq.Mapping;
namespace VS2010.ConsoleApp.Linq
{
    class MappingSourceDemo
    {
        public static void LookMappingSource()
        {
            Northwind nw = new Northwind();
            //var model = new AttributeMappingSource().GetModel(typeof(Northwind));

            //foreach (var mt in model.GetTables())

            //    Console.WriteLine(mt.TableName);

            //var model2 = nw.Mapping;
            //foreach (var mt2 in model2.GetTables())
            //{
            //    Console.WriteLine(mt2.TableName);
            //}
            //Console.Read();
            var model3 = new AttributeMappingSource().GetModel(typeof(Northwind));
            foreach (var mt3 in model3.GetTables())
            {
                Console.WriteLine(mt3.TableName);
                foreach (var dm in mt3.RowType.DataMembers)
                {
                    Console.WriteLine("Column{0}", dm.MappedName);
                    Console.WriteLine(dm.AutoSync);
                    Console.WriteLine(dm.CanBeNull);
                    //Console.WriteLine(dm.DeferredValueAccessor.Type);
                    //Console.WriteLine(dm.DeferredSourceAccessor.Type);
                    Console.WriteLine(dm.UpdateCheck);
                    Console.WriteLine(dm.Member.MemberType);
                    Console.WriteLine(dm.IsPrimaryKey);
                    Console.WriteLine(dm.IsDiscriminator);
                    Console.WriteLine(dm.IsDeferred);


                    //Console.WriteLine(dm.Association.IsMany);
                    //Console.WriteLine(dm.Association.OtherKey);
                    //Console.WriteLine(dm.Association.ThisKeyIsPrimaryKey);
                    //Console.WriteLine(dm.Association.ThisKey);
                    //Console.WriteLine(dm.Association.IsForeignKey);
                    //Console.WriteLine(dm.Association.DeleteRule);
                }
            }
            Console.ReadLine();
        }
    }
}
