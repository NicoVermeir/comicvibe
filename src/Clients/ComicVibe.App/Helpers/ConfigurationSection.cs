using Newtonsoft.Json.Linq;

namespace ComicVibe.App.Helpers
{
    public class ConfigurationSection : IConfigurationSection
    {
        private JToken _config;

        public string this[string key]
        {
            get => _config[key].ToString();
            set => _config[key] = value;
        }

        public IConfigurationSection GetSection(string key)
        {
            return Create(_config[key]);
        }

        public override string ToString()
        {
            return _config.ToString();
        }

        public static IConfigurationSection Create(JToken json)
        {
            return new ConfigurationSection { _config = json };
        }
    }
}
