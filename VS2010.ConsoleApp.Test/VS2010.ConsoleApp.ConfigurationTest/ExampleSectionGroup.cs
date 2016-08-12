using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    internal sealed class ExampleSectionGroup : ConfigurationSectionGroup
    {
        #region Constructors

        public ExampleSectionGroup()
        {
        }

        #endregion

        #region Properties

        [ConfigurationProperty("example")]
        public ExampleSection Example
        {
            get { return (ExampleSection) Sections["example"]; }
        }

        [ConfigurationProperty("another")]
        public AnotherSection Another
        {
            get { return (AnotherSection) base.Sections["another"]; }
        }

        #endregion
    }
}
