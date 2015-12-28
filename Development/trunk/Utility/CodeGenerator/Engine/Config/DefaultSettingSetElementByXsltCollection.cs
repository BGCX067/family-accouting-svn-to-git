using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.CodeGenerator.Engine
{
    public class DefaultSettingSetElementByXsltCollection : ConfigurationElementCollection
    {
        private Dictionary<string, DefaultSettingSetElement> defaultSettings = new Dictionary<string, DefaultSettingSetElement>();


        public DefaultSettingSetElementByXsltCollection()
        {
            this.AddElementName = "mappedByXslt";
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new DefaultSettingSetElementByXslt();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DefaultSettingSetElementByXslt)element).XsltFilePathes;
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            base.BaseAdd(element);
            this.AddToDefaultSettings((DefaultSettingSetElementByXslt)element);
        }

        protected override void BaseAdd(int index, ConfigurationElement element)
        {
            base.BaseAdd(index, element);
            this.RefreshDefaultSettings();
        }

        public DefaultSettingSetElement GetDefaultSetByXsltExactPath(string path)
        {
            DefaultSettingSetElement ret = null;
            if (path != null)
            {
                lock (this.defaultSettings)
                {
                    this.defaultSettings.TryGetValue(path, out ret);
                }
            }

            return ret;
        }


        private void AddToDefaultSettings(DefaultSettingSetElementByXslt element)
        {
            lock (this.defaultSettings)
            {
                string[] xsltPathes = element.GetExactXsltFilePathes();
                foreach (string path in xsltPathes)
                {
                    this.defaultSettings[path] = element;
                }
            }
        }

        private void RefreshDefaultSettings()
        {
            lock (this.defaultSettings)
            {
                foreach (DefaultSettingSetElementByXslt element in this)
                {
                    this.AddToDefaultSettings(element);
                }
            }
        }
    }
}
