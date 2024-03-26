using System.Text.Json.Serialization;

namespace UMBIT.MicroService.Template.Gateway.Interprete.Model
{
    public class SwaggerEndPoint
    {
        [JsonPropertyName("Key")]
        public string Key { get; set; }

        [JsonPropertyName("TransformByOcelotConfig")]
        public bool? TransformByOcelotConfig { get; set; }
        

        [JsonPropertyName("Config")]
        public List<Config> Config { get; set; }
    }
    public class Config
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Version")]
        public string Version { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }
    }

}
