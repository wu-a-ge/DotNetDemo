using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.Design;
namespace VS2008.WebForm.CustomExpressionBuilder
{
    public class XmlExpressionEditor : ExpressionEditor
    {
        public override object EvaluateExpression(string expression, object parseTimeData, Type propertyType, IServiceProvider serviceProvider)
        {
            if (serviceProvider != null)
            {
                IWebApplication service = (IWebApplication)serviceProvider.GetService(typeof(IWebApplication));
                if (service != null)
                {
                    System.Configuration.Configuration configuration = service.OpenWebConfiguration(true);
                    if (configuration != null)
                    {
                        string strFile = configuration.FilePath.Substring(0, configuration.FilePath.LastIndexOf("\\"));
                        string[] keys = expression.Split(',');
                        strFile = strFile + "\\" + keys[0] + ".xml";
                        return XmlExpressionBuilder.GetXmlKey(expression, strFile);
                    }
                }
            }

            return "";
        }
    }
}
