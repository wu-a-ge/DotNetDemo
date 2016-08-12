using System;
using System.Web;
using UtilityLib;
namespace UtilityLib.CQVip
{
    public  abstract  class CQViPTools
    {
        #region 私有方法
        /// <summary>
        /// 格式化IP，每个段为三位数字
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        private static string FormatIP(string IP)
        {
            string[] IPs = IP.Split('.');
            IP = "";
            for (int i = 0; i < IPs.Length; i++)
            {
                IPs[i] = IPs[i].PadLeft(3, '0');
                IP += IPs[i] + ".";
            }
            IP = IP.Remove(IP.Length - 1, 1);
            return IP;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 取得格式化IP
        /// </summary>
        /// <returns></returns>
        public static string GetFormatIP()
        {
            return FormatIP(HttpHelper.GetIP());
        }
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
        /// <summary>
        /// 替换NDO库中不能出现的字符
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string ReplaceChar(string target)
        {
            target = target.Replace(@"\s+", " ");
            target = target.Replace("（", "(");
            target = target.Replace("）", ")");
            target = target.Replace("＋", "+");
            target = target.Replace("＊", "*");
            target = target.Replace("－", "-");
            target = target.Replace("＝", "=");
            target = target.Replace("［", "[");
            target = target.Replace("］", "]");
            target = target.Replace("：", ":");
            target = target.Replace("-", "%0x002D%");
            target = target.Replace("+", "%0x002B%");
            target = target.Replace("*", "%0x002A%");
            target = target.Replace("(", "%0x0028%");
            target = target.Replace(")", "%0x0029%");
            target = target.Replace("[", "%0x005B%");
            target = target.Replace("]", "%0x005D%");
            target = target.Replace(":", "%0x003A%");
            return target;
        }
        #endregion

    }
}
