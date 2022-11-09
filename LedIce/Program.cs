using LedIce.Data;
using LedIce.Services;

using Microsoft.EntityFrameworkCore;

internal static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.ConfigureServices();

        var app = builder.Build();
        app.ConfigurePipeline();

        app.Run();
    }

    private static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        builder.Services.ConfigureResponseCompression();
        builder.Services.AddResponseCaching();

        builder.Services.AddLocalization();

        builder.ConfigureDbContext();
        builder.Services.AddCustomServices();

        builder.Services.ConfigureRouting();
    }

    private static void ConfigurePipeline(this WebApplication app)
    {
#if DEBUG
        app.SeedDatabase();
#endif

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.ConfigureStaticFiles();

        app.UseRouting();
        app.UseAuthorization();

        app.UseResponseCompression();
        app.UseResponseCaching();

        app.MapRazorPages();
    }

    private static void ConfigureResponseCompression(this IServiceCollection services)
    {
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
        });
    }

    private static void ConfigureDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<Context>(options =>
        {
            var connectionString = builder.Configuration["ConnectionString"];
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            options
                .UseLazyLoadingProxies()
                .UseMySql(connectionString, serverVersion, options =>
                {
                    options
                        .EnableRetryOnFailure()
                        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
        });
    }

    private static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<PageMetaService>();
        services.AddScoped<LocationService>();
        services.AddScoped<SlideService>();
        services.AddScoped<ManagerService>();
        services.AddScoped<SocialService>();
    }

    private static void ConfigureRouting(this IServiceCollection services)
    {
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });
    }

    private static void SeedDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        SeedData.Initialize(serviceProvider);
    }

    private static void ConfigureStaticFiles(this WebApplication app)
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = context =>
            {
                context.Context.Response.Headers.Add("cache-control", "public,max-age=31536000");
            }
        });
    }
}
