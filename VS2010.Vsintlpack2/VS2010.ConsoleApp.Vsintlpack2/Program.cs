using System;
using System.Globalization;
using Microsoft.International.Formatters;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using Microsoft.International.Converters.PinYinConverter;
namespace VS2010.ConsoleApp.Vsintlpack2
{
    class Program
    {
        static void Main(string[] args)
        {
            //NumericFormatterTest();
            //TraditionalChineseToSimplifiedConverterTest();
           
            Console.Read();
        }

        private static void NumericFormatterTest()
        {
            //简体
            Console.WriteLine("The number of 12345 with Normal format and Chinese-Simplified is: " + InternationalNumericFormatter.FormatWithCulture("L", 12323422045, null, new CultureInfo("zh-CHS")));
            Console.WriteLine("The number of 12345 with Lower format and Chinese-Simplified is: " + InternationalNumericFormatter.FormatWithCulture("Ln", 12323422045, null, new CultureInfo("zh-CHS")));
            Console.WriteLine("The number of 12345 with Currency format and Chinese-Simplified is: " + InternationalNumericFormatter.FormatWithCulture("Lc", 12323422045, null, new CultureInfo("zh-CHS")));
            //繁体
            Console.WriteLine("The number of 12345 with Currency format and Chinese-Traditional is: " + InternationalNumericFormatter.FormatWithCulture("Lc", 12345, null, new CultureInfo("zh-CHT")));
            Console.WriteLine("The number of 12345 with standard format and Japanese is: " + InternationalNumericFormatter.FormatWithCulture("L", 12345, null, new CultureInfo("ja")));
            Console.WriteLine("The number of 12345 with standard format and Korean is: " + InternationalNumericFormatter.FormatWithCulture("L", 12345, null, new CultureInfo("ko")));
            Console.WriteLine("The number of 12345 with standard format and Arabic is: " + InternationalNumericFormatter.FormatWithCulture("L", 12345, null, new CultureInfo("ar")));
            Console.Read();
        }

        private static void TraditionalChineseToSimplifiedConverterTest()
        {
            Console.WriteLine("The simplified format of 北京時間 is {0}.", ChineseConverter.Convert("北京時間", ChineseConversionDirection.TraditionalToSimplified));
            Console.WriteLine("The traditional format of 软件 is {0}.", ChineseConverter.Convert("软件", ChineseConversionDirection.SimplifiedToTraditional));
            Console.ReadLine();

        }
        /// <summary>
        /// 汉字字符串转拼音，全拼
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static void  GetPinyin(string str)
        {
            string r =
            string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar =
                    new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, t.Length -
                    1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            Console.WriteLine(r);
        }
    }
}
