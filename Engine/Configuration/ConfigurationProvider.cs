using System;
using System.Configuration;

namespace PostalService.Engine.Configuration
{
    public sealed class ConfigurationProvider : IConfigurationProvider
    {
        public int CustomerCreationDelay
        {
            get
            {
                int result;
                if (!int.TryParse(ConfigurationManager.AppSettings["CustomerCreationDelay_ms"], out result))
                    // ToDO: исключение по-приличнее нужно
                    throw new Exception();
                return result;
            }
        }
    }
}
