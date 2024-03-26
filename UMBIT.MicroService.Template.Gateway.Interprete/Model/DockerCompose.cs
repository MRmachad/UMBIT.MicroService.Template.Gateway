using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UMBIT.MicroService.Template.Gateway.Interprete.Model
{
    public class DockerCompose
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = "3.1";

        [JsonPropertyName("services")]
        public Dictionary<string, object> Services { get; set; }
    }
}
