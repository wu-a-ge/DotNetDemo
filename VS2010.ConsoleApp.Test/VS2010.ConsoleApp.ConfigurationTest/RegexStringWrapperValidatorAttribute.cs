using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
   public sealed class RegexStringWrapperValidatorAttribute: 
                    ConfigurationValidatorAttribute
{
    #region Constructors
    public RegexStringWrapperValidatorAttribute(string regex)
    {
        m_regex = regex;
        m_minLength = 0;
        m_maxLength = 0x7fffffff;
    }
    #endregion

    #region Fields
    private string m_regex;
    private int m_minLength;
    private int m_maxLength;
    #endregion


    #region Properties
    public string Regex
    {
        get { return m_regex; }
    }

    public int MinLength
    {
        get
        {
            return m_minLength;
        }
        set
        {
            if (m_maxLength < value)
            {
                  throw new ArgumentOutOfRangeException("value", 
                        "The upper range limit value must be greater" + 
                        " than the lower range limit value.");
            }
            m_minLength = value;

        }
    }

    public int MaxLength
    {
        get
        {
            return m_maxLength;
        }
        set
        {
            if (m_minLength > value)
            {
                  throw new ArgumentOutOfRangeException("value", 
                        "The upper range limit value must be greater " + 
                        "than the lower range limit value.");
            }
            m_maxLength = value;
        }
    }

    public override ConfigurationValidatorBase ValidatorInstance
    {
        get { return   new RegexStringWrapperValidator(m_regex, m_minLength, 
                                               m_maxLength);  }
      
    }

       #endregion
}
}
