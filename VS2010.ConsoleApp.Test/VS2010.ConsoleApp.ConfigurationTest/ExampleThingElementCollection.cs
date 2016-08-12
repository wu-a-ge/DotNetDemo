using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.ConfigurationTest
{
    /// <summary>
    /// 配置元素集合也可以是编程式和声明式的
    /// </summary>
    //[ConfigurationCollection(typeof(ThingElement),
    // CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ExampleThingElementCollection : ConfigurationElementCollection
    {
        #region Constructors
        static ExampleThingElementCollection()
        {
            m_properties = new ConfigurationPropertyCollection();
        }

        #endregion

        #region Fields
        private static ConfigurationPropertyCollection m_properties;
        #endregion

        #region Properties
        protected override ConfigurationPropertyCollection Properties
        {
            get { return m_properties; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
        #endregion

        #region Indexers
        public ThingElement this[int index]
        {
            get { return (ThingElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }

        public ThingElement this[string name]
        {
            get { return (ThingElement)base.BaseGet(name); }
        }
        #endregion

        #region Overrides
        protected override ConfigurationElement CreateNewElement()
        {
            return new ThingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as ThingElement).Name;
        }
        #endregion

        #region Methods
        public void Add(ThingElement thing)
        {
            base.BaseAdd(thing);
        }

        public void Remove(string name)
        {
            base.BaseRemove(name);
        }

        public void Remove(ThingElement thing)
        {
            base.BaseRemove(GetElementKey(thing));
        }

        public void Clear()
        {
            base.BaseClear();
        }

        public void RemoveAt(int index)
        {
            base.BaseRemoveAt(index);
        }

        public string GetKey(int index)
        {
            return (string)base.BaseGetKey(index);
        }
        #endregion
    }
}
