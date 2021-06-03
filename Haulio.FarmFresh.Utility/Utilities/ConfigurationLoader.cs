using System.IO;
using System.Text.Json;

namespace Haulio.FarmFresh.Utility
{
    public class ConfigurationLoader
    {

        private dynamic configJsonData;
        public ConfigurationLoader Load(string configFilePath = "appsettings.json")
        {
            var appSettings = File.ReadAllText(configFilePath);
            this.configJsonData = JsonSerializer.Deserialize(appSettings, typeof(object));
            return this;
        }

        public dynamic GetProperty(string key)
        {
            var properties = key.Split(".");
            dynamic property = this.configJsonData;
            foreach (var prop in properties)
            {
                property = property.GetProperty(prop);
            }

            return property;
        }
    }

}
