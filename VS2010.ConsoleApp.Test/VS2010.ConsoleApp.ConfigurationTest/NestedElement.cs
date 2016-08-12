using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    /// <summary>
    ///声明和编程式混合的，两者取其一就可以了
    /// </summary>
    public class NestedElement : ConfigurationElement
    {
        #region Constructors

        /// <summary>
        /// Predefines the valid properties and prepares
        /// the property collection.
        /// </summary>
        static NestedElement()
        {
            // Predefine properties here
            s_propDateTime = new ConfigurationProperty(
                "dateTimeValue",
                typeof(DateTime),
                null,
                ConfigurationPropertyOptions.IsRequired
                );

            s_propInteger = new ConfigurationProperty(
                "integerValue",
                typeof(int),
                0,
                ConfigurationPropertyOptions.IsRequired
                );

            s_properties = new ConfigurationPropertyCollection();

            s_properties.Add(s_propDateTime);
            s_properties.Add(s_propInteger);
        }

        #endregion

        #region Static Fields

        private static ConfigurationProperty s_propDateTime;
        private static ConfigurationProperty s_propInteger;

        private static ConfigurationPropertyCollection s_properties;

        #endregion


        #region Properties

        /// <summary>
        /// Gets the DateTimeValue setting.
        /// </summary>
        [ConfigurationProperty("dateTimeValue", IsRequired = true)]
        public DateTime DateTimeValue
        {
            get { return (DateTime)base[s_propDateTime]; }
        }

        /// <summary>
        /// Gets the IntegerValue setting.
        /// </summary>
        [ConfigurationProperty("integerValue", IsRequired = true)]
        public int IntegerValue
        {
            get { return (int)base[s_propInteger]; }
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
