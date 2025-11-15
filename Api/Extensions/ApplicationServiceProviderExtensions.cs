public static class ApplicationServiceProviderExtensions
{
    public static IServiceProvider AddCustomService(
        this IServiceProvider services,
        IConfiguration configuration
    )
    {
        using var scope = services.CreateScope();
        var Initialize = scope.ServiceProvider.GetRequiredService<IInitializer>();
        Initialize.Initialize();


        return services;
    }
}