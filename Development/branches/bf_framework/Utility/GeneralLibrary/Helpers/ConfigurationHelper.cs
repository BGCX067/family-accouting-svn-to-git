using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public static class ConfigurationHelper
    {
        public static Configuration LoadExeConfigurationFile(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            ExeConfigurationFileMap ecm = new ExeConfigurationFileMap();
            ecm.ExeConfigFilename = path;
            return ConfigurationManager.OpenMappedExeConfiguration(ecm, ConfigurationUserLevel.None);
        }

        public static string CalculatePathRelativeToConfigurationFile(ConfigurationElement element, string path)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            return Path.Combine(Path.GetDirectoryName(element.ElementInformation.Source), path);
        }

        public static Configuration GetConfigurationByRelativePath(ConfigurationElement element, string path)
        {
            string target = CalculatePathRelativeToConfigurationFile(element, path);
            return LoadExeConfigurationFile(target);
        }
    }
}
