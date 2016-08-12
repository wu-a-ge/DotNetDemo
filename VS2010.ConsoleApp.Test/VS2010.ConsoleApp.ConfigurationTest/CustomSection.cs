using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    class CustomSection : ConfigurationSection
    {
        [ConfigurationProperty("stringValue", IsRequired = true)]
        public string StringValue
        {
            get { return (string)base["stringValue"]; }
            set { base["stringValue"] = value; }
        }

    }
}
