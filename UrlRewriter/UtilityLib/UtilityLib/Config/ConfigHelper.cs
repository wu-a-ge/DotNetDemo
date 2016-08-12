using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Configuration;
using System.Web.Configuration;
namespace UtilityLib.Config
{
    public sealed class ConfigHelper
    {
        private readonly static Dictionary<string, object> sectionCache = new Dictionary<string, object>();
        private readonly static object objLock = new object();
        //private static CustomAppSettingsSectionHandler customAppSettings = null;

        #region 私有构造函数
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private ConfigHelper() { }
        #endregion

        /// <summary>
        /// 获得ConnectionStrings指定名称的值
        /// </summary>
        /// <param name="Key">标记字符串</param>
        /// <returns></returns>
        public static string ConnectionStrings(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString.Trim();
        }
        /// <summary>
        /// 获取AppSettings指定名称的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key].Trim();
        }
        /// <summary>
        /// 取得配置文件中的指定配置节
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static object GetSection(string sectionName)
        {
            if (!sectionCache.ContainsKey(sectionName))
            {
                sectionCache.Add(sectionName, ConfigurationManager.GetSection(sectionName));
            }
            return sectionCache[sectionName];
        }
        /// <summary>
        /// 取得配置文件中的指定配置节,泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static T GetSection<T>(string sectionName) where T : ConfigurationSection
        {
            return (T)GetSection(sectionName);
        }
        /// <summary>
        ///  根据指定的名字获取自定义配置节，此配置节放在web.config的外部
        /// </summary>
        /// <returns></returns>
        public static CustomAppSettingsSectionHandler GetCustomAppSettings(string sectionName)
        {
            if (null == HttpRuntime.Cache[sectionName])
            {
                lock (objLock)
                {
                    if (null == HttpRuntime.Cache[sectionName])
                    {
                        //获取配置节
                        CustomAppSettingsSectionHandler customAppSettings = ConfigurationManager.GetSection(sectionName) as CustomAppSettingsSectionHandler;
                        if (customAppSettings == null)
                            throw new ConfigurationErrorsException("缺少必需的配置节" + sectionName);
                        //获取外部文件路径
                        SectionInformation sectionInfo = customAppSettings.SectionInformation;
                        //得到文件物理路径
                        string appSettingsFile = HttpRuntime.AppDomainAppPath + sectionInfo.ConfigSource;
                        if (!File.Exists(appSettingsFile))
                        {
                            throw new FileNotFoundException("缺少外部配置文件", sectionInfo.ConfigSource);
                        }
                        //将外部配置文件放入缓存
                        HttpRuntime.Cache.Insert(sectionName, customAppSettings, new CacheDependency(appSettingsFile));
                    }
                }
            }

            return HttpRuntime.Cache[sectionName] as CustomAppSettingsSectionHandler;
        }
        /// <summary>
        /// 根据默认的名字(customAppSettings)获取自定义配置节，此配置节放在web.config的外部
        /// </summary>
        /// <returns></returns>
        public static CustomAppSettingsSectionHandler GetCustomAppSettings()
        {
            return GetCustomAppSettings("customAppSettings");
        }
    }
}
