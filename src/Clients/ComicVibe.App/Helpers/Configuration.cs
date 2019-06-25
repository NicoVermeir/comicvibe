using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json.Linq;

namespace ComicVibe.App.Helpers
{
    public class Configuration : IConfiguration
    {
        private JObject _configRoot;

        public string this[string key]
        {
            get => _configRoot[key].ToString();
            set => throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            return ConfigurationSection.Create(_configRoot[key]);
        }

        public async Task Init()
        {
#if DEBUG
            string configFileName = "ms-appx:///appsettings";
            StorageFile configFile;

            try
            {
                configFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(configFileName + ".development.json"));
            }
            catch (FileNotFoundException)
            {
                configFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(configFileName + ".json"));
            }
#else
            string configFileName = "ms-appx:///appsettings.json";
            StorageFile configFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(configFileName));
#endif
            string json = await FileIO.ReadTextAsync(configFile);

            _configRoot = JObject.Parse(json);
        }

        public override string ToString()
        {
            return _configRoot.ToString();
        }
    }
}
