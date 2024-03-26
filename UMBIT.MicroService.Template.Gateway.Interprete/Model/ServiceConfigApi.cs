using System.Text.Json.Serialization;

namespace UMBIT.MicroService.Template.Gateway.Interprete.Model
{
    public class ServiceConfigApi
    {
        [JsonPropertyName("NameSolutionService")]
        public string NameSolutionService { get; set; }

        [JsonPropertyName("DirectoryDockerFile")]
        public string DirectoryDockerFile { get; set; }

        [JsonPropertyName("DirectorySolutionService")]
        public string DirectorySolutionService { get; set; }

    }


}
