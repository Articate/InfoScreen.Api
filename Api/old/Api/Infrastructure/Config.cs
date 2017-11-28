using System;
using System.Configuration;

namespace InfoScreen.Api.Infrastructure
{
    public class Config : IConfig
    {
        public static string Get(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
            {
                // TODO: Literals
                throw new ArgumentException("Key missing");
            }

            return value;
        }

        public static int GetInt(string key)
        {
            if (!int.TryParse(Get(key), out int value))
            {
                throw new ArgumentException("Invalid int value");
            }

            return value;
        }
    }
}