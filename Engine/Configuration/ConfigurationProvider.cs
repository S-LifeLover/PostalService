using System;
using System.Configuration;

namespace PostalService.Engine.Configuration
{
    internal sealed class ConfigurationProvider : IConfigurationProvider
    {
        public int CustomerCreationDelay
        {
            get { return GetIntSetting("CustomerCreationDelay_ms"); }
        }

        public double PostmanSpeed
        {
            get { return GetDoubleSetting("PostmanSpeed_pps"); }
        }

        public int PostmansCount
        {
            get { return GetIntSetting("PostmansCount"); }
        }

        public double WorldWidth
        {
            get { return GetDoubleSetting("WorldWidth"); }
        }

        public double WorldHeight
        {
            get { return GetDoubleSetting("WorldHeight"); }
        }

        private static int GetIntSetting(string settingName)
        {
            int result;
            if (!int.TryParse(ConfigurationManager.AppSettings[settingName], out result))
                throw ConstructException(settingName, ConfigurationManager.AppSettings[settingName], typeof(int));
            return result;
        }

        private static double GetDoubleSetting(string settingName)
        {
            double result;
            if (!double.TryParse(ConfigurationManager.AppSettings[settingName], out result))
                throw ConstructException(settingName, ConfigurationManager.AppSettings[settingName], typeof(int));
            return result;
        }

        private static PostalServiceException ConstructException(string settingName, string settingValue, Type settingType)
        {
            return new PostalServiceException(
                string.Format(
                    @"Can not read setting {0}: Value {1} can not be parsed to {2} type",
                    settingName,
                    settingValue,
                    settingType.Name));
        }
    }
}
