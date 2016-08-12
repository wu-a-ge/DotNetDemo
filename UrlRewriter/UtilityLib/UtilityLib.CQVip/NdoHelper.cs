using System;


namespace UtilityLib.CQVip
{
    /// <summary>
    /// 对NDO库的操作类
    /// </summary>
    public abstract class NdoHelper
    {
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
    }
}
