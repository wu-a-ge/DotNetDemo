using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Reflection;

namespace VS2010.ConsoleApp.EmitVSExpressionTree
{
    public interface IFoo
    {
        Bar Bar { get; set; }
    }
    public class Bar { }

    class Program
    {
        public static void SetPropertyValueViaExpression(IFoo foo, Bar bar)
        {
            var property = typeof(IFoo).GetProperty("Bar");
            var target = Expression.Parameter(typeof(IFoo));
            var propertyValue = Expression.Parameter(typeof(Bar));
            var setPropertyValue = Expression.Call(target, property.GetSetMethod(), propertyValue);
            var setAction = Expression.Lambda<Action<IFoo, Bar>>(setPropertyValue, target, propertyValue).Compile();
            setAction(foo, bar);
        }
        public static void SetPropertyValueViaEmit(IFoo foo, Bar bar)
        {
            var property = typeof(IFoo).GetProperty("Bar");
            DynamicMethod method = new DynamicMethod("SetValue", null, new Type[] { typeof(IFoo), typeof(Bar) });
            ILGenerator ilGenerator = method.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.EmitCall(OpCodes.Callvirt, property.GetSetMethod(), null);
            ilGenerator.Emit(OpCodes.Ret);

            method.DefineParameter(1, ParameterAttributes.In, "obj");
            method.DefineParameter(2, ParameterAttributes.In, "value");
            var setAction = (Action<IFoo, Bar>)method.CreateDelegate(typeof(Action<IFoo, Bar>));
            setAction(foo, bar);
        }
        public static Bar GetPropertyValueViaExpression(IFoo foo)
        {
            var property = typeof(IFoo).GetProperty("Bar");
            var target = Expression.Parameter(typeof(IFoo));
            var getPropertyValue = Expression.Property(target, property);
            var getFunc = Expression.Lambda<Func<IFoo, Bar>>(getPropertyValue, target).Compile();
            return getFunc(foo);
        }
        public static Bar GetPropertyValueViaEmit(IFoo foo)
        {
            var property = typeof(IFoo).GetProperty("Bar");
            DynamicMethod method = new DynamicMethod("GetValue", typeof(Bar), new Type[] { typeof(IFoo) });

            ILGenerator ilGenerator = method.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitCall(OpCodes.Callvirt, property.GetGetMethod(), null);
            ilGenerator.Emit(OpCodes.Ret);

            method.DefineParameter(1, ParameterAttributes.In, "target");
            var getFunc = (Func<IFoo, Bar>)method.CreateDelegate(typeof(Func<IFoo, Bar>));
            return getFunc(foo);
        }

        static void Main(string[] args)
        {
            var property = typeof(IFoo).GetProperty("Bar");
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Artech.EmitVsExpression"), AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("Artech.EmitVsExpression", "Artech.EmitVsExpression.dll");
            var typeBuilder = moduleBuilder.DefineType("Program");

            //GetPropertyValueViaExpression
            var methodBuilder = typeBuilder.DefineMethod("GetPropertyValueViaExpression", MethodAttributes.Static | MethodAttributes.Public, typeof(Bar), new Type[] { typeof(IFoo) });
            var target = Expression.Parameter(typeof(IFoo));
            var getPropertyValue = Expression.Property(target, property);
            Expression.Lambda<Func<IFoo, Bar>>(getPropertyValue, target).CompileToMethod(methodBuilder);

            //SetPropertyValueViaExpression
            methodBuilder = typeBuilder.DefineMethod("SetPropertyValueViaExpression", MethodAttributes.Static | MethodAttributes.Public, typeof(void), new Type[] { typeof(IFoo), typeof(Bar) });
            target = Expression.Parameter(typeof(IFoo));
            var propertyValue = Expression.Parameter(typeof(Bar));
            var setPropertyValue = Expression.Call(target, property.GetSetMethod(), propertyValue);
            Expression.Lambda<Action<IFoo, Bar>>(setPropertyValue, target, propertyValue).CompileToMethod(methodBuilder);

            //GetPropertyValueViaEmit
            methodBuilder = typeBuilder.DefineMethod("GetPropertyValueViaEmit", MethodAttributes.Static | MethodAttributes.Public, typeof(Bar), new Type[] { typeof(IFoo) });
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitCall(OpCodes.Callvirt, property.GetGetMethod(), null);
            ilGenerator.Emit(OpCodes.Ret);

            //SetPropertyValueViaEmit
            methodBuilder = typeBuilder.DefineMethod("SetPropertyValueViaEmit", MethodAttributes.Static | MethodAttributes.Public, typeof(void), new Type[] { typeof(IFoo), typeof(Bar) });
            ilGenerator = methodBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.EmitCall(OpCodes.Callvirt, property.GetSetMethod(), null);
            ilGenerator.Emit(OpCodes.Ret);

            typeBuilder.CreateType();
            assemblyBuilder.Save("Artech.EmitVsExpression.dll");

        }
    }
}
