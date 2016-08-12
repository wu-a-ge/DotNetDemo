using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Configuration;

namespace VS2010.ConsoleApp.ConfigurationTest
{
   public class TypeSafeExampleSection: ConfigurationSection
{
    #region Constructor
    static TypeSafeExampleSection()
    {

        s_propMyInt = new ConfigurationProperty(
            "myInt",
            typeof(int),
            "Infinite",
            new InfiniteIntConverter(),
            null,
            ConfigurationPropertyOptions.IsRequired
        );
        propMyStruct = new ConfigurationProperty(
            "myStructConventer",
            typeof(MyStruct),
            null,
            new MyStructConverter(),
            null,
            ConfigurationPropertyOptions.IsRequired);
        s_properties = new ConfigurationPropertyCollection();
        s_properties.Add(propMyStruct);
        s_properties.Add(s_propMyInt);
    }
    #endregion

    #region Fields
    private static ConfigurationPropertyCollection s_properties;
    private static ConfigurationProperty propMyStruct;
    private static ConfigurationProperty s_propMyInt;
    #endregion

    #region Properties
    [ConfigurationProperty("myInt", DefaultValue = "Infinite", IsRequired = true)]
    [TypeConverter(typeof(InfiniteIntConverter))]
    public int MyInt
    {
        get { return (int)base[s_propMyInt]; }
        set { base[s_propMyInt] = value; }
    }
    [ConfigurationProperty("myStructConventer", IsRequired = true)]
    [TypeConverter(typeof(MyStructConverter))]
    public MyStruct MyStructConventer
    {
        get { return (MyStruct) base[propMyStruct]; }

    }
    protected override ConfigurationPropertyCollection Properties
    {
        get
        {
            return s_properties;
        }
    }
    #endregion
}
}
