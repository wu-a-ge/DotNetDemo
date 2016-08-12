using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Linq.Expressions;

namespace FastReflection
{
    public class Bar { }
    public interface IFoo
    {
        Bar Bar { get; set; }
    }
    public class Foo1 : IFoo
    {
        public Bar Bar { get; set; }
    }
    public class Foo2 : IFoo
    {
        public Bar Bar { get; set; }
    }
    public class Foo3 : IFoo
    {
        public Bar Bar { get; set; }
    }

    public delegate Bar GetPropertyValue();
    public delegate void SetPropertyValue(Bar bar);

    public class Program
    {
        public static GetPropertyValue CreateGetPropertyValueDelegate(IFoo foo)
        {
            return (GetPropertyValue)Delegate.CreateDelegate(typeof(GetPropertyValue), foo, typeof(IFoo).GetProperty("Bar").GetGetMethod());
        }
        public static SetPropertyValue CreateSetPropertyValueDelegate(IFoo foo)
        {
            return (SetPropertyValue)Delegate.CreateDelegate(typeof(SetPropertyValue), foo, typeof(IFoo).GetProperty("Bar").GetSetMethod());
        }
        public static Func<IFoo, Bar> CreateGetPropertyValueFunc()
        {
            //var property = typeof(IFoo).GetProperty("Bar");
            //var target = Expression.Parameter(typeof(object));
            //var castTarget = Expression.Convert(target, typeof(IFoo));
            //var getPropertyValue = Expression.Property(castTarget, property);
            //var castPropertyvalue = Expression.Convert(getPropertyValue, typeof(object));
            //return Expression.Lambda<Func<object, object>>(getPropertyValue, target).Compile();
            var property = typeof(IFoo).GetProperty("Bar");
            var target = Expression.Parameter(typeof(IFoo));
            var getPropertyValue = Expression.Property(target, property);
            return Expression.Lambda<Func<IFoo, Bar>>(getPropertyValue, target).Compile();
        }
        public static Action<IFoo, Bar> CreateSetPropertyValueAction()
        {

            //var property = typeof(IFoo).GetProperty("Bar");
            //var target = Expression.Parameter(typeof(object));
            //var propertyValue = Expression.Parameter(typeof(object));
            //var castTarget = Expression.Convert(target, typeof(IFoo));
            //var castPropertyValue = Expression.Convert(propertyValue, property.PropertyType);
            //var setPropertyValue = Expression.Call(castTarget, property.GetSetMethod(), castPropertyValue);
            //return Expression.Lambda<Action<object, object>>(setPropertyValue, target, propertyValue).Compile();
            var property = typeof(IFoo).GetProperty("Bar");
            var target = Expression.Parameter(typeof(IFoo));
            var propertyValue = Expression.Parameter(typeof(Bar));
            var setPropertyValue = Expression.Call(target, property.GetSetMethod(), propertyValue);
            return Expression.Lambda<Action<IFoo, Bar>>(setPropertyValue, target, propertyValue).Compile();
        }
        public static void TestSetPropertyValue(int times)
        {
            var foo1 = new Foo1();
            var foo2 = new Foo2();
            var foo3 = new Foo3();
            var bar = new Bar();
            var property = typeof(IFoo).GetProperty("Bar");
            var setAction = CreateSetPropertyValueAction();
            var setDelegate1 = CreateSetPropertyValueDelegate(foo1);
            var setDelegate2 = CreateSetPropertyValueDelegate(foo2);
            var setDelegate3 = CreateSetPropertyValueDelegate(foo3);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < times; i++)
            {
                property.SetValue(foo1, bar, null);
                property.SetValue(foo2, bar, null);
                property.SetValue(foo3, bar, null);
            }
            var duration1 = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            for (int i = 0; i < times; i++)
            {
                setAction(foo1, bar);
                setAction(foo2, bar);
                setAction(foo3, bar);
            }
            var duration2 = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            for (int i = 0; i < times; i++)
            {
                setDelegate1(bar);
                setDelegate2(bar);
                setDelegate3(bar);
            }
            var duration3 = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("{0, -15}{1,-15}{2,-15}{3,-15}", times, duration1, duration2, duration3);
        }

        public static void TestGetPropertyValue(int times)
        {
            var foo1 = new Foo1 { Bar = new Bar() };
            var foo2 = new Foo2 { Bar = new Bar() };
            var foo3 = new Foo3 { Bar = new Bar() };

            var property = typeof(IFoo).GetProperty("Bar");
            var getFunc = CreateGetPropertyValueFunc();
            var getDelegate1 = CreateGetPropertyValueDelegate(foo1);
            var getDelegate2 = CreateGetPropertyValueDelegate(foo2);
            var getDelegate3 = CreateGetPropertyValueDelegate(foo3);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < times; i++)
            {
                var bar1 = property.GetValue(foo1, null);
                var bar2 = property.GetValue(foo2, null);
                var bar3 = property.GetValue(foo3, null);
            }
            var duration1 = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            for (int i = 0; i < times; i++)
            {
                var bar1 = getFunc(foo1);
                var bar2 = getFunc(foo2);
                var bar3 = getFunc(foo3);
            }
            var duration2 = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            for (int i = 0; i < times; i++)
            {
                var bar1 = getDelegate1();
                var bar2 = getDelegate2();
                var bar3 = getDelegate3();
            }
            var duration3 = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("{0, -15}{1,-15}{2,-15}{3,-15}", times, duration1, duration2, duration3);
        }

        static void Main()
        {
            Console.WriteLine("{0, -15}{1,-15}{2,-15}{3,-15}", "Times", "Reflection", "Expression", "Delegate");
            //TestSetPropertyValue(10000);
            //TestSetPropertyValue(100000);
            //TestSetPropertyValue(1000000);

            Console.WriteLine();

            TestGetPropertyValue(10000);
            TestGetPropertyValue(100000);
            TestGetPropertyValue(1000000);
        }
    }
}