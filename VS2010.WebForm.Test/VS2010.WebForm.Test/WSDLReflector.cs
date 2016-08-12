using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace VS2010.WebForm.Test
{
    public class WSDLReflector: SoapExtensionReflector
    {

        public override void ReflectMethod()
        {
            
        }
        /// <summary>
        /// 继承修改描述方法
        /// </summary>
        public override void ReflectDescription()
        {

            ServiceDescription description = ReflectionContext.ServiceDescription;

            foreach (Service service in description.Services)
            {
                Console.WriteLine(service.ServiceDescription.DocumentationElement);
                for (int i = 0; i < service.ServiceDescription.Messages.Count; i++)
                {
                    var message= service.ServiceDescription.Messages[i];
                    
                }
                

            }

        }
    }
}