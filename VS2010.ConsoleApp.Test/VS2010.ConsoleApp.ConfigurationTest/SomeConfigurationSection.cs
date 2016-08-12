using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    public class SomeConfigurationSection:ConfigurationSection
    {
        static SomeConfigurationSection()
        {
            // Preparation...
        }

        // Properties...

        #region GetSection Pattern
        // Dictionary to store cached instances of the configuration object
        private static Dictionary<string,
                SomeConfigurationSection> m_sections;

        /// <summary>
        /// Finds a cached section with the specified defined name.
        /// </summary>
        private static SomeConfigurationSection
                FindCachedSection(string definedName)
        {
            if (m_sections == null)
            {
                m_sections = new Dictionary<string,
                                 SomeConfigurationSection>();
                return null;
            }

            SomeConfigurationSection section;
            if (m_sections.TryGetValue(definedName, out section))
            {
                return section;
            }

            return null;
        }

        /// <summary>
        /// Adds the specified section to the cache under the defined name.
        /// </summary>
        private static void AddCachedSection(string definedName,
                       SomeConfigurationSection section)
        {
            if (m_sections != null)
                m_sections.Add(definedName, section);
        }

        /// <summary>
        /// Removes a cached section with the specified defined name.
        /// </summary>
        public static void RemoveCachedSection(string definedName)
        {
            m_sections.Remove(definedName);
        }

        /// <summary>
        /// Gets the configuration section using the default element name.
        /// </summary>
        /// <remarks>
        /// If an HttpContext exists, uses the WebConfigurationManager
        /// to get the configuration section from web.config. This method
        /// will cache the instance of this configuration section under the
        /// specified defined name.
        /// </remarks>
        public static SomeConfigurationSection GetSection()
        {
            return GetSection("someConfiguration");
        }

        /// <summary>
        /// Gets the configuration section using the specified element name.
        /// </summary>
        /// <remarks>
        /// If an HttpContext exists, uses the WebConfigurationManager
        /// to get the configuration section from web.config. This method
        /// will cache the instance of this configuration section under the
        /// specified defined name.
        /// </remarks>
        public static SomeConfigurationSection GetSection(string definedName)
        {
            if (String.IsNullOrEmpty(definedName))
                definedName = "someConfiguration";

            SomeConfigurationSection section = FindCachedSection(definedName);
            if (section == null)
            {
                string cfgFileName = ".config";
                //我觉得完全完全可以不用区别是web还是c/s程序的配置文件
                if (HttpContext.Current == null)
                {
                    section = ConfigurationManager.GetSection(definedName)
                              as SomeConfigurationSection;
                }
                else
                {
                    section = WebConfigurationManager.GetSection(definedName)
                              as SomeConfigurationSection;
                    cfgFileName = "web.config";
                }

                if (section == null)
                    throw new ConfigurationException("The <" + definedName +
                       "> section is not defined in your " + cfgFileName +
                       " file!");

                AddCachedSection(definedName, section);
            }

            return section;
        }

        /// <summary>
        /// Gets the configuration section using the default element name 
        /// from the specified Configuration object.
        /// </summary>
        /// <remarks>
        /// If an HttpContext exists, uses the WebConfigurationManager
        /// to get the configuration section from web.config.
        /// </remarks>
        public static SomeConfigurationSection GetSection(Configuration config)
        {
            return GetSection(config, "someConfiguration");
        }

        /// <summary>
        /// Gets the configuration section using the specified element name 
        /// from the specified Configuration object.
        /// </summary>
        /// <remarks>
        /// If an HttpContext exists, uses the WebConfigurationManager
        /// to get the configuration section from web.config.
        /// </remarks>
        public static SomeConfigurationSection GetSection(Configuration config,
                                               string definedName)
        {
            if (config == null)
                throw new ArgumentNullException("config",
                      "The Configuration object can not be null.");

            if (String.IsNullOrEmpty(definedName))
                definedName = "someConfiguration";

            SomeConfigurationSection section = config.GetSection(definedName)
                                               as SomeConfigurationSection;

            if (section == null)
                throw new ConfigurationException("The <" + definedName +
                      "> section is not defined in your .config file!");

            return section;
        }
        #endregion
    }
}
