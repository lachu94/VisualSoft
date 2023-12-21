using VisualSoft.Services;

namespace VisualSoft.Feature
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {          
            services.AddScoped<IFileConversionService, FileConversionService>();       
            return services;
        }
    }
}
