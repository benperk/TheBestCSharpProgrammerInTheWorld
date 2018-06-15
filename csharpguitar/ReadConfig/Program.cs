using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Collections.Specialized;
using static System.Console;

namespace ConfigElementAndSection
{
    class Program
    {
        public class ConfigurationMgr
        {
            public void ReadAllAppSettings()
            {
                try
                {
                    NameValueCollection appSettings = ConfigurationManager.AppSettings;

                    if (appSettings.Count == 0)
                    {
                        WriteLine("ReadAppSettings: The AppSettings section is empty.");
                        WriteLine();
                    }

                    for (int i = 0; i < appSettings.Count; i++)
                    {
                        WriteLine($"ReadAppSettings: {i} Key: {appSettings.GetKey(i)} Value: {appSettings[i]}");
                        WriteLine();
                    }
                }
                catch (ConfigurationErrorsException e)
                {
                    WriteLine($"ReadAppSettings: {e.ToString()}");
                    WriteLine();
                }
            }

            public void CreateAppSettings(string sectionName, string key, string value)
            {
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    config.AppSettings.Settings.Add(key, value);

                    config.Save();
                    ConfigurationManager.RefreshSection(sectionName);
                }
                catch (ConfigurationErrorsException e)
                {
                    WriteLine($"[CreateAppSettings: {e.ToString()}]");
                    WriteLine();
                }
            }

            public string GetAppSettingValue(string key)
            {
                try
                {
                    NameValueCollection appSettings = ConfigurationManager.AppSettings;

                    string[] arr = appSettings.GetValues(key);
                    return arr[0];
                }
                catch (ConfigurationErrorsException e)
                {
                    Console.WriteLine($"[CreateAppSettings: {e.ToString()}]");
                    Console.WriteLine();
                    return e.ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[CreateAppSettings: {e.ToString()}]");
                    Console.WriteLine();
                    return e.ToString();
                }
            }
        }

        static void Main(string[] args)
        {
            ConfigurationMgr configMgr = new ConfigurationMgr();

            Console.WriteLine("***** appSettings before adding section, element and element items *****");
            Console.WriteLine();
            configMgr.ReadAllAppSettings();

            configMgr.CreateAppSettings("appSettings", "KEY0", "VALUE0");

            configMgr.CreateAppSettings("appSettings", "KEY1", "VALUE1");

            configMgr.CreateAppSettings("appSettings", "KEY2", "VALUE2");

            Console.WriteLine("***** appSettings after adding section, element and element items *****");
            Console.WriteLine();
            configMgr.ReadAllAppSettings();

            Console.WriteLine("appSettings value for KEY0 is {0}", configMgr.GetAppSettingValue("KEY0"));
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
