using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    public class ThingElement : ConfigurationElement
    {
        #region Constructors
        /// <summary>
        ///声明和编程式混合的，两者取其一就可以了
        /// </summary>
        static ThingElement()
        {
            // Predefine properties here
            s_propName = new ConfigurationProperty(
                "name",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            s_propType = new ConfigurationProperty(
                "type",
                typeof(string),
                "Normal",
                ConfigurationPropertyOptions.None
            );

            s_propColor = new ConfigurationProperty(
                "color",
                typeof(string),
                "Green",
                ConfigurationPropertyOptions.None
            );

            s_properties = new ConfigurationPropertyCollection();

            s_properties.Add(s_propName);
            s_properties.Add(s_propType);
            s_properties.Add(s_propColor);
        }
        #endregion

        #region Static Fields
        private static ConfigurationProperty s_propName;
        private static ConfigurationProperty s_propType;
        private static ConfigurationProperty s_propColor;

        private static ConfigurationPropertyCollection s_properties;
        #endregion


        #region Properties
        /// <summary>
        /// Gets the Name setting.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base[s_propName]; }
        }

        /// <summary>
        /// Gets the Type setting.
        /// </summary>
        [ConfigurationProperty("type")]
        public string Type
        {
            get { return (string)base[s_propType]; }
        }

        /// <summary>
        /// Gets the Type setting.
        /// </summary>
        [ConfigurationProperty("color")]
        public string Color
        {
            get { return (string)base[s_propColor]; }
        }

        /// <summary>
        /// Override the Properties collection and return our custom one.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return s_properties; }
        }
        #endregion
    }
}
