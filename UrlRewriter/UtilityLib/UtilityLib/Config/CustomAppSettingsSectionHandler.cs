using System;
using System.Collections.Generic;
using System.Configuration;

namespace UtilityLib.Config
{
    public class CustomAppSettingsSectionHandler:ConfigurationSection
    {
        [ConfigurationProperty("settings")]
        public SettingsColletion Settings
        {
            get
            {
                return base["settings"] as SettingsColletion;
            }
        }
    }

    public class SettingsColletion : ConfigurationElementCollection
    {
        public new Setting this[string key]
        {
            get
            {
                return base.BaseGet(key) as Setting;
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new Setting();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as Setting).key;
        }
    }
    
    public class Setting : ConfigurationElement
    {
       
        [ConfigurationProperty("key")]
        public string key
        {
            get
            {
                return base["key"] as string;
            }
            set
            {
                base["key"] = value;
            }
        }
        [ConfigurationProperty("value")]
        public string Value
        {
            get
            {
                return base["value"] as string;
            }
            set
            {
                base["value"] = value;
            }
        }
    }

}
