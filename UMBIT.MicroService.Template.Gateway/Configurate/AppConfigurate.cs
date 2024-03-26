namespace UMBIT.MicroService.Template.Gateway.Configurate
{
    public static class AppConfigurate
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            return services;
        }

        public static IApplicationBuilder UseApp(this IApplicationBuilder app, IWebHostEnvironment environment)
        {

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
