using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.Json;
using UMBIT.MicroService.Template.Gateway.Interprete.Basicos.Extensores;
using UMBIT.MicroService.Template.Gateway.Interprete.Basicos.Utilitarios;
using UMBIT.MicroService.Template.Gateway.Interprete.Model;

namespace UMBIT.MicroService.Template.Gateway.Interprete.Service
{
    public static class InterpreteService
    {
        public const string API_FIX = "API";
        public const string FILES_PATTERN = "*.json";
        public const string CONTRACT_FIX = "CONTRACT";
        public const string PATH_SERVICE = "/services";
        public static void RegistreServicesConfigurate(string path, string IdentityApiKey, ServiceSettings serviceSettings)
        {
            var result = GereOcelotConfigurate(IdentityApiKey, serviceSettings);
            CrieAquivoOcelotJson(result, path);

            var resultServices = GereDockerCompose(serviceSettings);
            CrieDockerCompose(resultServices, path);
        }

        private static DockerCompose GereDockerCompose(ServiceSettings serviceSettings)
        {
            var resultServicesConfigApi = new List<Model.ServiceConfigApi>();
            var compose = new DockerCompose()
            {
                Services = new Dictionary<string, object>()
                {
                    {
                        "gateway", new {
                                        container_name = "gateway",
                                        build = ".",
                                        ports = new List<string> { $"5000:8080" }
                                        }
                    }
                }
            };

            var servicesFolder = new DirectoryInfo(DiretorioDeConfiguracao.ObtenhaDiretorioPadrao() + PATH_SERVICE);
            if (!servicesFolder.Exists)
                return compose;

            var servicesApiConfig = servicesFolder.GetDirectories()
                                            .Where(t => t.Name.ToUpper().Contains(API_FIX)).Where(t => serviceSettings.Services.Any(m => t.Name.Contains(m.ServiceName)));

            foreach (var serviceApiConfig in servicesApiConfig)
            {
                var configFiles = serviceApiConfig.GetFiles(FILES_PATTERN, SearchOption.TopDirectoryOnly);
                foreach (var configFile in configFiles)
                {
                    using (StreamReader reader = new StreamReader(configFile.FullName))
                    {
                        var jsonstring = reader.ReadToEnd();
                        resultServicesConfigApi.Add(JsonConvert.DeserializeObject<Model.ServiceConfigApi>(jsonstring));
                    }
                }
            }

            foreach (var resultServiceConfigApi in resultServicesConfigApi)
            {
                var serviceSetting = serviceSettings.Services.Find(t => t.ServiceName.Contains(resultServiceConfigApi.NameSolutionService));

                compose.Services.Add(serviceSetting?.Apelido.ToLower(), new
                {
                    container_name = serviceSetting.Apelido,
                    build = resultServiceConfigApi.DirectorySolutionService,
                    ports = new List<string> { ($"{serviceSetting.Port}:8080") }
                });

            }

            return compose;
        }
        private static OcelotConfigurate GereOcelotConfigurate(string IdentityApiKey, ServiceSettings serviceSettings)
        {
            var ocelotConfig = new OcelotConfigurate()
            {
                Routes = new List<Settings>(),
                GlobalConfiguration = new Settings()
                {
                    BaseUrl = "http://localhost",
                    DangerousAcceptAnyServerCertificateValidator = true
                },
                SwaggerEndPoints = new List<SwaggerEndPoint>()
            };

            var servicesFolder = new DirectoryInfo(DiretorioDeConfiguracao.ObtenhaDiretorioPadrao() + PATH_SERVICE);
            if (!servicesFolder.Exists)
                return ocelotConfig;

            var servicesContract = servicesFolder.GetDirectories()
                                                 .Where(t => t.Name.ToUpper().Contains(CONTRACT_FIX)).Where(t => serviceSettings.Services.Any(m => t.Name.Contains(m.ServiceName)));

            foreach (var serviceContract in servicesContract)
            {
                var contractFiles = serviceContract.GetFiles(FILES_PATTERN, SearchOption.TopDirectoryOnly);
                var serviceName = serviceContract.Name.Remove(serviceContract.Name.Length - CONTRACT_FIX.Length - 1);
                var serviceSetting = serviceSettings.Services.Find(t => t.ServiceName.Contains(serviceName));

                foreach (var contractFile in contractFiles)
                {
                    using (StreamReader reader = new StreamReader(contractFile.FullName))
                    {
                        var jsonstring = reader.ReadToEnd();
                        var contractJson = (JObject)JsonConvert.DeserializeObject(jsonstring);

                        foreach (var path in contractJson["paths"])
                        {
                            var settings = new Settings();

                            settings.DownstreamScheme = "http";
                            settings.SwaggerKey = serviceSetting.Apelido;
                            settings.DangerousAcceptAnyServerCertificateValidator = true;
                            settings.DownstreamPathTemplate = $"/{((JProperty)path).Name}".RemovaBarraDupla();
                            settings.UpstreamPathTemplate = $"/{serviceSetting.Apelido}/{((JProperty)path).Name}".RemovaBarraDupla();
                            settings.UpstreamHttpMethod = path.Children().Select(method => ((JProperty)method.First).Name).ToList();
                            settings.DownstreamHostAndPorts = new List<DownstreamHostAndPort>()
                            {
                                new DownstreamHostAndPort()
                                {
                                    Host = "localhost",
                                    Port = 4500
                                }
                            };

                            if (((JContainer)path).First["security"] != null && (bool)((JContainer)path).First["security"])
                            {
                                settings.AuthenticationOptions = new AuthenticationOptions()
                                {
                                    AuthenticationProviderKey = IdentityApiKey
                                };
                            }

                            ocelotConfig.Routes.Add(settings);
                        }
                    }
                }

                ocelotConfig.SwaggerEndPoints.Add(new SwaggerEndPoint()
                {
                    Key = serviceSetting.Apelido,
                    Config = new List<Config>()
                    {
                        new Config() 
                        {
                            Name = serviceSetting.ServiceName,
                            Version = "v1",
                            Url = $"http://localhost:{serviceSetting.Port}/swagger/v1/swagger.json"
                        }
                    }
                });
            }

            return ocelotConfig;
        }

        private static void CrieDockerCompose(DockerCompose dockerCompose, string path)
        {
            var JsonString = System.Text.Json.JsonSerializer.Serialize(dockerCompose, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            File.WriteAllText(path + "\\docker-compose.json", JsonString);
        }
        private static void CrieAquivoOcelotJson(OcelotConfigurate ocelotConfigurate, string path)
        {
            var JsonString = System.Text.Json.JsonSerializer.Serialize(ocelotConfigurate, new JsonSerializerOptions()
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });

            File.WriteAllText(path + "\\Ocelot\\ocelot.json", JsonString);
        }
    }
}
