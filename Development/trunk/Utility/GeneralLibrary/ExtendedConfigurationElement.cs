using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public abstract class ExtendedConfigurationElement : ConfigurationElement
    {
        public static TElement MergeToNewElement<TElement>(TElement baseElement, TElement overrideElement, bool recursively)
            where TElement : ExtendedConfigurationElement
        {
            return (TElement)MergeToNewElement(baseElement, overrideElement, typeof(TElement), recursively, ExtendedConfigurationElementOverrideMode.Inherit);
        }

        private static ExtendedConfigurationElement MergeToNewElement(ExtendedConfigurationElement baseElement, ExtendedConfigurationElement overrideElement, Type t, bool recursively, ExtendedConfigurationElementOverrideMode overrideMode)
        {
            ExtendedConfigurationElement ret = (baseElement == null ? overrideElement : baseElement);
            if ((baseElement != null) && (overrideElement != null))
            {
                if (overrideElement.Override != ExtendedConfigurationElementOverrideMode.Inherit)
                {
                    overrideMode = overrideElement.Override;
                }
                if (overrideMode == ExtendedConfigurationElementOverrideMode.Inherit)
                {
                    overrideMode = ExtendedConfigurationElementOverrideMode.Ignore;
                }

                ret = (ExtendedConfigurationElement)Activator.CreateInstance(t);
                foreach (ConfigurationProperty property in baseElement.Properties)
                {
                    object baseValue = baseElement[property];
                    object overrideValue = overrideElement[property];
                    if (typeof(ExtendedConfigurationElement).IsAssignableFrom(property.Type) && recursively)
                    {
                        ret[property] = MergeToNewElement((ExtendedConfigurationElement)baseValue, (ExtendedConfigurationElement)overrideValue, property.Type, recursively, overrideMode);
                    }
                    else
                    {
                        switch (overrideMode)
                        {
                            case ExtendedConfigurationElementOverrideMode.OverrideFromAll:
                                ret[property] = overrideValue;
                                break;
                            case ExtendedConfigurationElementOverrideMode.OverrideFromNotEmpty:
                                ret[property] = (DetermineValueEmpty(overrideValue) ? baseValue : overrideValue);
                                break;
                            case ExtendedConfigurationElementOverrideMode.Ignore:
                                ret[property] = baseValue;
                                break;
                        }
                    }
                }
            }

            return ret;
        }

        private static bool DetermineValueEmpty(object v)
        {
            bool ret = (v == null);
            if (!ret)
            {
                if (v is string)
                {
                    ret = String.IsNullOrEmpty((string)v);
                }
            }

            return ret;
        }


        public string CalculatePath(string path)
        {
            return ConfigurationHelper.CalculatePathRelativeToConfigurationFile(this, path);
        }


        [ConfigurationProperty("override", IsRequired = false, DefaultValue = ExtendedConfigurationElementOverrideMode.Inherit)]
        public ExtendedConfigurationElementOverrideMode Override
        {
            get
            {
                return (ExtendedConfigurationElementOverrideMode)this["override"];
            }
            set
            {
                this["override"] = value;
            }
        }
    }
}
