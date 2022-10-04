//using DeskApi.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;

//namespace DeskApi
//{
//    public static class Startup
//    {
//        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
//        {
//            services.Configure<DeskSettings>(configuration.GetSection(nameof(DeskSettings)));
//            services.Configure<Secrets>(configuration.GetSection(nameof(Secrets)));

//            return services;
//        } 
//    }
//}