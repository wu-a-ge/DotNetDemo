using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.CodeDom;
using System.Xml;
using System.Web.UI;

namespace VS2008.WebForm.CustomExpressionBuilder
{
    /// <summary>
    /// 这个类是仿AppSettingsExpressionBuilder类写的，所以不是很合适。
    /// 而且这种表达式生成器只能使用在服务器端控件中
    /// </summary>
    [ExpressionEditor("VS2008.WebForm.CustomExpressionBuilder.XmlExpressionEditor, VS2008.WebForm.CustomExpressionBuilder"), ExpressionPrefix("Xml")]
    public class XmlExpressionBuilder : ExpressionBuilder
    {
        public override System.CodeDom.CodeExpression GetCodeExpression(System.Web.UI.BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            
            if ((entry.DeclaringType == null) || (entry.PropertyInfo == null))
            {
                //调用只有一个参数的重载方法
                return new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "GetXmlKey", new CodeExpression[] { new CodePrimitiveExpression(entry.Expression.Trim()) });
            }
            //调用有三个参数的重载方法
            return new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "GetXmlKey", new CodeExpression[] { new CodePrimitiveExpression(entry.Expression.Trim()), new CodeTypeOfExpression(entry.DeclaringType), new CodePrimitiveExpression(entry.PropertyInfo.Name) });
        }
        //返回一个值，该值指示是否可在不编译的页中计算表达式
        public override bool SupportsEvaluate
        {
            get
            {
                return true;
            }
        }
        //返回当前表达式的计算结果（禁用页面编译时 ---CompilationMode="Never" ）
        public override object EvaluateExpression(object target, BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            return GetXmlKey(entry.Expression, target.GetType(), entry.PropertyInfo.Name);
        }

        //取得Xml中的key值，为了测试，没有考虑性能和异常的问题
        public static string GetXmlKey(string expresseion, string strFileName)
        {
            string[] keys = expresseion.Split(',');
            string strFile = "";
            if (String.IsNullOrEmpty(strFileName))
            {
                strFile = HttpContext.Current.Server.MapPath("/") + keys[0] + ".xml";
            }
            else
            {
                strFile = strFileName;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFile);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("test").ChildNodes;
            foreach (XmlNode xn in nodeList)
            {
                if (xn is XmlElement)
                {
                    if (xn.Name == keys[1])
                    {
                        return (xn as XmlElement).GetAttribute("value");
                    }
                }
            }
            return "";
        }
        public static object GetXmlKey(string expresseion, Type targetType, string propertyName)
        {
            return GetXmlKey(expresseion, "");
        }
        public static string GetXmlKey(string expresseion)
        {
            return GetXmlKey(expresseion, "");
        }
    }
}
