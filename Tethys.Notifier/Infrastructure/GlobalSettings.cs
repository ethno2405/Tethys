using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Tethys.Notifier.Infrastructure
{
    public class GlobalSettings
    {
        private static GlobalSettings current;
        private static object mutex = new object();

        private GlobalSettings()
        {
        }

        public static GlobalSettings Current
        {
            get
            {
                if (current == null)
                {
                    lock (mutex)
                    {
                        if (current == null)
                        {
                            current = new GlobalSettings();
                        }
                    }
                }

                return current;
            }
        }

        public string ObserverWebApiBaseUrl
        {
            get
            {
                return GetValue<string>("ObserverWebApiBaseUrl");
            }
        }

        public string ServerPhysicalAddress
        {
            get
            {
                return GetValue<string>("ServerPhysicalAddress");
            }
        }

        private T GetValue<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            var value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                throw new ConfigurationErrorsException(string.Format("Setting with key {0} was not found in configuration file.", key));
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}