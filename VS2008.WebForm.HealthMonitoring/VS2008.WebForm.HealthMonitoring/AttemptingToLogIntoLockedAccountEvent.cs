using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace VS2008.WebForm.HealthMonitoring
{
    /// <summary>
    /// 这里添加了自定义事件，如果把信息路由到了内置事件，所以在配置文件的
    /// rules节中应该添加相应的基类事件的配置
    /// </summary>
    public class AttemptingToLogIntoLockedAccountEvent : WebAuthenticationFailureAuditEvent
    {
        public AttemptingToLogIntoLockedAccountEvent(string message, object eventSource, string nameToAuthenticate)
            : base(message, eventSource, WebEventCodes.WebExtendedBase + 5000, nameToAuthenticate)
        {

        }
    }
}
