using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    public sealed class MyStructConverter : ConfigurationConverterBase
    {
        public MyStructConverter() { }

        /// <summary>Converts a string to a MyStruct.</summary>
        /// <returns>A new MyStruct value.</returns>
        /// The <see 
        /// cref="T:System.ComponentModel.ITypeDescriptorContext">
        /// </see> object used for type conversions.
        /// The <see 
        /// cref="T:System.Globalization.CultureInfo">
        /// </see> object used during conversion.
        /// The <see cref="T:System.String">
        /// </see> object to convert.
        public override object ConvertFrom(ITypeDescriptorContext ctx,
                                           CultureInfo ci, object data)
        {
            string dataStr = ((string)data).ToLower();
            string[] values = dataStr.Split(',');
            if (values.Length == 6)
            {
                try
                {
                    var myStruct = new MyStruct();
                    foreach (string value in values)
                    {
                        string[] varval = value.Split(':');
                        switch (varval[0].Trim())
                        {
                            case "l":
                                myStruct.Length = Convert.ToInt32(varval[1]); break;
                            case "w":
                                myStruct.Width = Convert.ToInt32(varval[1]); break;
                            case "h":
                                myStruct.Height = Convert.ToInt32(varval[1]); break;
                            case "x":
                                myStruct.X = Convert.ToDouble(varval[1]); break;
                            case "y":
                                myStruct.Y = Convert.ToDouble(varval[1]); break;
                            case "z":
                                myStruct.Z = Convert.ToDouble(varval[1]); break;
                        }
                    }
                    return myStruct;
                }
                catch
                {
                    throw new ArgumentException("The string contained invalid data.");
                }
            }

            throw new ArgumentException("The string did not contain all six, " +
                                        "or contained more than six, values.");
        }

        /// <summary>Converts a MyStruct to a string value.</summary>
        /// <returns>The string representing the value 
        ///           parameter.</returns>
        /// The <see 
        /// cref="T:System.ComponentModel.ITypeDescriptorContext">
        /// </see> object used for type conversions.
        /// The <see 
        /// cref="T:System.Globalization.CultureInfo">
        /// </see> object used during conversion.
        /// The <see cref="T:System.String">
        /// </see> object to convert.
        /// The type to convert to.
        public override object ConvertTo(ITypeDescriptorContext ctx,
               CultureInfo ci, object value, Type type)
        {
            return value.ToString();
        }
    }
}
