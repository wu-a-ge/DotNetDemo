using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    public class RegexStringWrapperValidator : ConfigurationValidatorBase
    {
        #region Constructors
        public RegexStringWrapperValidator(string regex) :
            this(regex, 0, 0x7fffffff)
        {
        }

        public RegexStringWrapperValidator(string regex, int minLength) :
            this(regex, minLength, 0x7fffffff)
        {
        }

        public RegexStringWrapperValidator(string regex, int minLength,
                                           int maxLength)
        {
            m_regexValidator = new RegexStringValidator(regex);
            m_stringValidator = new StringValidator(minLength, maxLength);
        }
        #endregion

        #region Fields
        private readonly RegexStringValidator m_regexValidator;
        private readonly StringValidator m_stringValidator;
        #endregion

        #region Overrides
        public override bool CanValidate(Type type)
        {
            return (type == typeof(string));
        }

        public override void Validate(object value)
        {
            m_stringValidator.Validate(value);
            m_regexValidator.Validate(value);
        }
        #endregion
    }
}
