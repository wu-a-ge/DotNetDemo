using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Reflection;
using System.Web.UI.Adapters;
namespace VS2010.WebForm.Test
{
    public class MyPageAdapter:PageAdapter
    {
        private static readonly Hashtable s_table = Hashtable.Synchronized(new Hashtable());
        private static MethodInvokeInfo[] GetMethodInfo(Type type)
        {
            MethodInvokeInfo[] array = MyPageAdapter.s_table[type.AssemblyQualifiedName] as MethodInvokeInfo[];
            if (array == null)
            {
                array = (
                    from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    let a = m.GetCustomAttributes(typeof(SubmitMethodAttribute), false) as SubmitMethodAttribute[]
                    where a.Length > 0
                    select new MethodInvokeInfo
                    {
                        MethodInfo = m,
                        MethodAttribute = a[0]
                    }).ToArray<MethodInvokeInfo>();
                MyPageAdapter.s_table[type.ToString()] = array;
            }
            return array;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (base.Page.Request.Form.AllKeys.Length != 0)
            {
                MethodInvokeInfo[] methodInfo = MyPageAdapter.GetMethodInfo(base.Page.GetType().BaseType);
                if (methodInfo.Length != 0)
                {
                    MethodInvokeInfo[] array = methodInfo;
                    for (int i = 0; i < array.Length; i++)
                    {
                        MethodInvokeInfo methodInvokeInfo = array[i];
                        if (!string.IsNullOrEmpty(base.Page.Request.Form[methodInvokeInfo.MethodInfo.Name]))
                        {
                            methodInvokeInfo.MethodInfo.Invoke(base.Page, null);
                            if (methodInvokeInfo.MethodAttribute.AutoRedirect && !base.Page.Response.IsRequestBeingRedirected)
                            {
                                base.Page.Response.Redirect(base.Page.Request.RawUrl);
                            }
                            break;
                        }
                    }
                }
            }
        }
        internal sealed class MethodInvokeInfo
        {
            public MethodInfo MethodInfo;
            public SubmitMethodAttribute MethodAttribute;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SubmitMethodAttribute : Attribute
    {
        public bool AutoRedirect
        {
            get;
            set;
        }
    }
}