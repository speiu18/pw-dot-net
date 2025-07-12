using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Core
{
    public static class ConfigurationManager
    {
        public static readonly string AppUrl = GetFromConfig("appUrl");

        public static string GetFromConfig(string key)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // Access configuration settings and return the value as a string  
            return config[key] ?? throw new InvalidOperationException($"Configuration key '{key}' not found.");
        }

        public static IConfigurationSection GetConfigurationSection(string sectionName)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            // Access configuration section and return it  
            return config.GetSection(sectionName) ?? throw new InvalidOperationException($"Configuration section '{sectionName}' not found.");
        }
    }
}
