using System;
using System.Web;
using UtilityLib.WebHelper;
namespace UtilityLib.CQVip
{
    public sealed  class Tools
    {
 

        #region 公共方法

        /// <summary>
        /// 获取用户浏览器或用户信息
        /// </summary>
        /// <returns></returns>
        public static int SystemInfo()
        {
            int sysinfo = 0;
            string systr = HttpContext.Current.Request.UserAgent.ToString();
            if (systr.IndexOf("NT 5.1") > 0 || systr.IndexOf("NT 5.2") > 0)
            {
                sysinfo = 1;
            }
            return sysinfo;
        }

        /// <summary>
        /// 根据用户ID取SUID
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string UserIDToSUID(int userid)
        {
            string suid = string.Empty;
            if (userid > 0)
            {
                VipIELILib.EncryptString Integrad = new VipIELILib.EncryptStringClass();
                suid = Integrad.CreateString(userid, GetFormatIP());
                Integrad = null;
            }
            return suid;
        }
        /// <summary>
        /// 根据用户SUID取ID
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int SUIDToUserID(string suid)
        {
            
            int userid = -1;
            if (!string.IsNullOrEmpty(suid))
            {
                VipIELILib.EncryptString Integrad = new VipIELILib.EncryptStringClass();
                userid = Integrad.GetUserIdByString(suid, GetFormatIP());
                Integrad = null;
                if (userid <1)
                {
                    userid = -1;
                }
            }
            return userid;
        }
        #endregion

    }
}
