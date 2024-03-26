using Microsoft.Extensions.Configuration;
using UMBIT.MicroService.Template.Gateway.Interprete.Model;
using UMBIT.MicroService.Template.Gateway.Interprete.Service;


internal class Program
{
    private static void Main(string[] args)
    {
        var authenticationProviderKey = "IdentityApiKey";
        var basepath = Directory.GetParent(Environment.CurrentDirectory).FullName + "\\UMBIT.MicroService.Template.Gateway.Interprete";

        var builder = new ConfigurationBuilder()
            .SetBasePath(basepath)
            .AddJsonFile("services.json", optional: false);

        IConfiguration config = builder.Build();

        var serviceSettings = config.Get<ServiceSettings>();

        InterpreteService.RegistreServicesConfigurate(Environment.GetCommandLineArgs().Count() > 1 ?  Environment.GetCommandLineArgs()[1] : ".", authenticationProviderKey, serviceSettings);
    }
}