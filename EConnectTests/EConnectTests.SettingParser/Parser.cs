using EConnectTests.Settings;
using System;
using System.IO;
using Newtonsoft.Json;

namespace EConnectTests.SettingParser
{
    public class Parser
    {
        public Setting ParserConfiguration(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"Parameter {nameof(path)} is null or white space.");
            }
            
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Property {nameof(path)} with value {path} points to not existing file.");
            }

            string content = File.ReadAllText(path);

            Setting setting = JsonConvert.DeserializeObject<Setting>(content);

            return setting;
        }
    }
}
