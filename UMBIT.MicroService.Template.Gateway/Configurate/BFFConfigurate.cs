using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

namespace UMBIT.MicroService.Template.Gateway.Configurate
{
    public static class BFFConfigurate
    {
        public static IServiceCollection AddBFF(this IServiceCollection services, IConfigurationBuilder configuration, IWebHostEnvironment  webHostEnvironment)
        {
            var authenticationProviderKey = "IdentityApiKey";

            configuration.AddJsonFile("Ocelot/ocelot.json", optional: false, reloadOnChange: true);

            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.Authority = "https://localhost:7112";
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationProviderKey))

                };
            });

            var _config = configuration.Build();

            services.AddSwaggerForOcelot(_config);
            services.AddOcelot(_config);
            return services;
        }

        public static IApplicationBuilder UseBFF(this IApplicationBuilder app)
        {
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.DownstreamSwaggerEndPointBasePath = "/swagger";
                opt.PathToSwaggerGenerator = "/swagger/docs";
            }).UseOcelot().Wait();

            return app;
        }
    }
}
