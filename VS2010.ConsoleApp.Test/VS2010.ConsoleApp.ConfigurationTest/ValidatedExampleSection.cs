using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
   /// <summary>
    /// 验证器会对初始值进行验证，也就是在创建ConfigurationProperty对象的时候就会进行验证
   /// </summary>
    public class ValidatedExampleSection : ConfigurationSection
    {
        #region Constructor
        static ValidatedExampleSection()
        {
            s_propMyTimeSpan = new ConfigurationProperty(
                "myTimeSpan",
                typeof(TimeSpan),
                TimeSpan.Zero,
                null,
                new TimeSpanValidator(TimeSpan.Zero, TimeSpan.FromHours(24)),
                ConfigurationPropertyOptions.IsRequired
            );

            s_propMyInt = new ConfigurationProperty(
           "myInt",
           typeof(int),
           0,
           null,
           new CallbackValidator(typeof(int), ModRangeValidatorCallback),
               ConfigurationPropertyOptions.IsRequired
            );
            s_propMyLong = new ConfigurationProperty(
                "myLong",
                typeof(long),
                0L,
                null,
                new LongValidator(Int64.MinValue, Int64.MaxValue),
                ConfigurationPropertyOptions.IsRequired
            );
            propMyString=new ConfigurationProperty(
                "myString",
                typeof(string),
                null,
                null,
                new RegexStringWrapperValidator("success"), 
                ConfigurationPropertyOptions.IsRequired
                );
            s_properties = new ConfigurationPropertyCollection();
            s_properties.Add(propMyString);
            s_properties.Add(s_propMyTimeSpan);
            s_properties.Add(s_propMyInt);
            s_properties.Add(s_propMyLong);
        }
        #endregion

        #region Fields
        private static ConfigurationPropertyCollection s_properties;
        private static ConfigurationProperty s_propMyTimeSpan;
        private static ConfigurationProperty s_propMyInt;
        private static ConfigurationProperty s_propMyLong;
        private static readonly ConfigurationProperty propMyString;
        #endregion

        #region Properties
        [ConfigurationProperty("myString", DefaultValue = "success", IsRequired = true)]
        [RegexStringWrapperValidator("success")]
        public string MyString
        {
            get { return (string)base[propMyString]; }
        }

        [ConfigurationProperty("myTimeSpan",
                               IsRequired = true)]
        [TimeSpanValidator(MinValueString = "0:0:0", MaxValueString = "24:0:0")]
        public TimeSpan MyTimeSpan
        {
            get { return (TimeSpan)base[s_propMyTimeSpan]; }
        }

        [ConfigurationProperty("myInt", IsRequired = true)]
        [CallbackValidator(Type = typeof(ValidatedExampleSection), CallbackMethodName = "ModRangeValidatorCallback")]
        public int MyInt
        {
            get { return (int)base[s_propMyInt]; }
        }
        [ConfigurationProperty("myLong", IsRequired = true)]
        [LongValidator(MinValue = long.MinValue, MaxValue = long.MaxValue)]
        public long MyLong
        {
            get { return (long)base[s_propMyLong]; }
        }
        //protected override ConfigurationPropertyCollection Properties
        //{
        //    get { return s_properties; }
        //}
        #endregion

        #region Helpers
        public static void ModRangeValidatorCallback(object value)
        {
            int intVal = (int)value;
            if (intVal >= -100 && intVal <= 100)
            {
                if (intVal % 10 != 0)
                    throw new ArgumentException("The integer " +
                         "value is not a multiple of 10.");
            }
            else
            {
                throw new ArgumentException("The integer value is not" +
                                            " within the range -100 to 100");
            }
        }
        #endregion
    }
}
