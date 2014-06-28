using System;
using System.Configuration;

namespace PostalService.Engine.Configuration
{
    public sealed class ConfigurationProvider : IConfigurationProvider
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
                // ToDO: исключение по-приличнее нужно
                throw new Exception();
            return result;
        }

        private static double GetDoubleSetting(string settingName)
        {
            double result;
            if (!double.TryParse(ConfigurationManager.AppSettings[settingName], out result))
                // ToDO: исключение по-приличнее нужно
                throw new Exception();
            return result;
        }
    }
}
