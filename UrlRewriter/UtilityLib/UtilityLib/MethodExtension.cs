using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;

namespace UtilityLib
{
   public static  class MethodExtension
   {
        

       #region 对字符串的扩展
       /// <summary>
       /// 对字符串扩展实例方法以检测当前实例是否为空
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static bool IsNullOrEmpty(this string str)
       {
            
           return string.IsNullOrEmpty(str);
       }
       public static int ToInt(this string str)
       {
           return int.Parse(str);
       }
       public static long ToLong(this string str)
       {
           return long.Parse(str);
       }
       public static double ToDouble(this string str)
       {
           return double.Parse(str);
       }
       public static float ToFloat(this string str)
       {
           
           return float.Parse(str);
       }
       #endregion

       #region 对object扩展
       public static int ToInt(this object obj)
       {
           return int.Parse(obj as string);
       }
       public static long ToLong(this object obj)
       {
           return long.Parse(obj as string);
       }
       public static double ToDouble(this object obj)
       {
           return double.Parse(obj as string);
       }
       public static float ToFloat(this object obj)
       {
           return float.Parse(obj as string);
       }
       public static bool IsNull(this object obj)
       {
           return null == obj;
       }
       #endregion

       #region 页面绑定表达式扩展
        static object ExpHelper<TEntity, TResult>(Page page, Func<TEntity, TResult> func)
       {
           var item = page.GetDataItem();
           return func((TEntity)item);
       }

       public static object Eval<T>(this Page page, Func<T, object> func)
       {
           return ExpHelper<T, object>(page, func);
       }
       #endregion


   }
}
