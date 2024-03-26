using System.Text.Json.Serialization;

namespace UMBIT.MicroService.Template.Gateway.Interprete.Model
{
    public class OcelotConfigurate
    {
        [JsonPropertyName("Routes")]
        public List<Settings> Routes { get; set; }

        [JsonPropertyName("GlobalConfiguration")]
        public Settings GlobalConfiguration { get; set; }

        [JsonPropertyName("SwaggerEndPoints")]
        public List<SwaggerEndPoint> SwaggerEndPoints { get; set; }
    }
}
