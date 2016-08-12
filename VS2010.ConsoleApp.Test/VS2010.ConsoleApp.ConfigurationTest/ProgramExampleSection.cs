using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    /// <summary>
    /// 编程方式创建配置节
    /// </summary>
    partial class ExampleSection : ConfigurationSection
    {
        #region Constructors
        /// <summary>
        /// Predefines the valid properties and prepares
        /// the property collection.
        /// </summary>
        static ExampleSection()
        {
            // Predefine properties here
            s_propString = new ConfigurationProperty(
                "stringValue",
                typeof(string),
                null,
                ConfigurationPropertyOptions.IsRequired
            );

            s_propBool = new ConfigurationProperty(
                "boolValue",
                typeof(bool),
                false,
                ConfigurationPropertyOptions.None
            );

            s_propTimeSpan = new ConfigurationProperty(
                "timeSpanValue",
                typeof(TimeSpan),
                null,
                ConfigurationPropertyOptions.None
            );
            s_propElement = new ConfigurationProperty(
                "nestedElement",
                typeof(NestedElement),
                null,
                ConfigurationPropertyOptions.IsRequired
            );
            s_propElement = new ConfigurationProperty(
              "nestedElement",
              typeof(NestedElement),
              null,
              ConfigurationPropertyOptions.IsRequired
          );
            propThings=new ConfigurationProperty(
                "things",
                typeof(ExampleThingElementCollection),
                null,
                ConfigurationPropertyOptions.None
                );
            s_properties = new ConfigurationPropertyCollection();
            s_properties.Add(propThings);
            s_properties.Add(s_propString);
            s_properties.Add(s_propBool);
            s_properties.Add(s_propTimeSpan);
            s_properties.Add(s_propElement);
        }
        #endregion

        #region Static Fields
        private static readonly ConfigurationProperty s_propElement;
        private static readonly ConfigurationProperty s_propString;
        private static readonly ConfigurationProperty s_propBool;
        private static readonly ConfigurationProperty s_propTimeSpan;
        private static readonly ConfigurationProperty propThings;
        private static readonly ConfigurationPropertyCollection s_properties;
        #endregion


        #region Properties
        /// <summary>
        /// Gets the StringValue setting.
        /// </summary>
        public string StringValue
        {
            get { return (string)base[s_propString]; }
            set { base[s_propString] = value; }
        }

        /// <summary>
        /// Gets the BooleanValue setting.
        /// </summary>
        public bool BooleanValue
        {
            get { return (bool)base[s_propBool]; }
        }

        /// <summary>
        /// Gets the TimeSpanValue setting.
        /// </summary>
        public TimeSpan TimeSpanValue
        {
            get { return (TimeSpan)base[s_propTimeSpan]; }
        }
        /// <summary>
        /// Gets the NestedElement element.
        /// </summary>
        public NestedElement Nested
        {
            get { return (NestedElement)base[s_propElement]; }
        }
        public ExampleThingElementCollection Things
        {
            get { return (ExampleThingElementCollection)base[propThings]; }
        }
        /// <summary>
        /// 重写集合很重要，用自定义的属性集合
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return s_properties; }
        }
     
        #endregion

    }
}
