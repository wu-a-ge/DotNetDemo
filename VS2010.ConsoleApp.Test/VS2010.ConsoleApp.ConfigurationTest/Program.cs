using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    class Program
    {
      
        static void Main(string[] args)
        {
            HostToNetwork();
            Console.Read();
            
        }

          static void BitOperation()
        {
            int a = 234244256;

            int b = ((a << 16) >> 16);
            int c = (a % (int)Math.Pow(2, 16));
            short d = (short)a;
            int e = 0xffff & a;
            Console.WriteLine((short)b);
            Console.WriteLine((short)c);
            Console.WriteLine((short)d);
            Console.WriteLine((short)e);
            //Console.WriteLine(Convert.ToString(a,2));
            Console.WriteLine(Convert.ToString(b, 2));
            Console.WriteLine(Convert.ToString(c, 2));
            Console.WriteLine(Convert.ToString(d, 2));
            Console.WriteLine(Convert.ToString(e, 2));
        }

        static void HostToNetwork()
        {
            short x = 6;
            String str = "cba";
           byte[]   strBytes=  System.Text.Encoding.BigEndianUnicode.GetBytes(str);
           strBytes = System.Text.Encoding.UTF8.GetBytes(str); 
            byte[] origanlBytes = System.BitConverter.GetBytes(x);
            short b = System.Net.IPAddress.HostToNetworkOrder(x); //把x转成相应的大端字节数

            byte[] bb = System.BitConverter.GetBytes(b);//这样直接取到的就是大端字节序字节数组。
        }
    }

    internal class ValidatedExampleSectionTest
    {
        public static void Load()
        {
            var example = ConfigurationManager.GetSection("validatedExample") as ValidatedExampleSection;

        }
    }

    internal class ExampleSectionGroupTest
    {
        public static void Load()
        {
            string m_string;
            bool m_bool;
            TimeSpan m_timespan;
            DateTime m_datetime;
            int m_int;
            Configuration config =
              ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var group = config.GetSectionGroup("example.group")
                                        as ExampleSectionGroup;

            ExampleSection section = group.Example;
            m_string = section.StringValue;
            m_bool = section.BooleanValue;
            m_timespan = section.TimeSpanValue;
            m_datetime = section.Nested.DateTimeValue;
            m_int = section.Nested.IntegerValue;
            var thing = section.Things[0];
            AnotherSection section2 = group.Another;
            //修改不成功？
            section.StringValue = "ok";
            config.Save(ConfigurationSaveMode.Modified);
        }
    }

    internal class TypeSaveExampleSectionTest
    {
        public static void Load()
        {
            var typeSafeexample = ConfigurationManager.GetSection("typeSafeExample") as TypeSafeExampleSection;

        }
    }
    /// <summary>
    /// 
    /// </summary>
    internal class  ConfigurationManagerTest
    {
        public static void Load()
        {
 
            //LoadExePath();
            //LoadConfigurationUserLevel();
            //LoadOpenMappedExeConfiguration();
            //AddConfigurationSection();
            Console.ReadLine();
        }
        /// <summary>
        /// 指定可执行文件路径打开它的配置文件
        /// </summary>
        public static void LoadExePath()
        {
            Console.WriteLine("App (before): " +
ConfigurationManager.AppSettings["test"]);

            Console.WriteLine("Loading Library.dll.config...");
            Configuration other =
                ConfigurationManager.OpenExeConfiguration("VS2010.ConsoleApp.TestLibrary.dll");//指定程序集的名称，实际加配置文件

            Console.WriteLine("App (after): " +
                ConfigurationManager.AppSettings["test"]);
            Console.WriteLine("Lib (after): " +
                other.AppSettings.Settings["test"].Value);
        }
        /// <summary>
        /// 指定打开哪个层次的配置文件，打开层次文件时会进行相应的合并
        /// </summary>
        public static void LoadConfigurationUserLevel()
        {
            //可以实际看下这个本地用户配置文件是不存在的，但是对象照样创建成功c:\user\xiaofu\appdata\local\。。。。
             Configuration roamingCfg =
ConfigurationManager.OpenExeConfiguration(
ConfigurationUserLevel.PerUserRoaming);
             CustomSection customSection =
             roamingCfg.GetSection("customSection") as CustomSection;
             //下面是不能保存的具体参看 AddConfigurationSection方法
             if (customSection == null)
             {
                 customSection = new CustomSection();
                 roamingCfg.Sections.Add("customSection", customSection);
             }
             customSection.StringValue = "ok";
             roamingCfg.Save(ConfigurationSaveMode.Minimal);
        }
        /// <summary>
        /// 根据文件映射，可以自定义配置文件的路径，打开层次文件时会进行相应的合并
        /// </summary>
        public static void LoadOpenMappedExeConfiguration()
        {
            string appData = Environment.GetFolderPath(
Environment.SpecialFolder.ApplicationData);
            string localData = Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData);

            ExeConfigurationFileMap exeMap =
            new ExeConfigurationFileMap();
            exeMap.ExeConfigFilename = @"C:\Application\Default.config";
            exeMap.RoamingUserConfigFilename = Path.Combine(appData, @"Company\Application\Roaming.config");
            exeMap.LocalUserConfigFilename = Path.Combine(localData, @"Company\Application\Local.config");
            //根据ConfigurationUserLevel值打不同层次的配置文件
            Configuration exeConfig =
            ConfigurationManager.OpenMappedExeConfiguration(
            exeMap, ConfigurationUserLevel.None);

            Configuration roamingConfig =
            ConfigurationManager.OpenMappedExeConfiguration(exeMap,
            ConfigurationUserLevel.PerUserRoaming);

            Configuration localConfig =
            ConfigurationManager.OpenMappedExeConfiguration(exeMap,
            ConfigurationUserLevel.PerUserRoamingAndLocal);

            Console.WriteLine("MACHINE/EXE: " + exeConfig.FilePath);
            Console.WriteLine(
            "MACHINE/EXE/ROAMING_USER: " + roamingConfig.FilePath);
            Console.WriteLine(
            "MACHINE/EXE/ROAMING_USER/LOCAL_USER: " + localConfig.FilePath);
        }
        /// <summary>
        /// 节可能只被定义在machine和exe级。如果您需要添加新的配置节，
        /// 甚至这个节将只在漫游或本地用户的*.config文件使用，你必须先在exe添加节，然后在用户级修改节设置
        /// </summary>
        public static void AddConfigurationSection()
        {
            Configuration exeConfig =
ConfigurationManager.OpenExeConfiguration(
ConfigurationUserLevel.None);
            if (exeConfig.GetSection("customSection") == null)
            {
                //调试运行的程序是不一样的，所以这里写不入VS2010.ConsoleApp.ConfigurationTest.vshost.exe.Config文件的
                //但是运行VS2010.ConsoleApp.ConfigurationTest.exe就可以写入
                var section = new CustomSection();
                section.SectionInformation.AllowExeDefinition =
            ConfigurationAllowExeDefinition.MachineToLocalUser;
                exeConfig.Sections.Add("customSection", section);
                exeConfig.Save(ConfigurationSaveMode.Minimal);
            }
            //保存成功的路径是，C:\Users\xiaofu\AppData\Local\Microsoft\VS2010.ConsoleApp.Configu_Url_psqertvihc0lp3qcliuvcfguazr0ubbs\1.0.0.0
            Configuration userConfig =
            ConfigurationManager.OpenExeConfiguration(
            ConfigurationUserLevel.PerUserRoamingAndLocal);
            var section1 =
            userConfig.GetSection("customSection") as CustomSection;
            section1.StringValue = "some value";
            userConfig.Save(ConfigurationSaveMode.Minimal);
        }
    }

}
