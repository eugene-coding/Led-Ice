using LedIce.Data;
using LedIce.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddRazorPages();

services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

services.AddResponseCaching();

services.AddLocalization();

services.AddDbContext<Context>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
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

services.AddScoped<PageMetaService>();
services.AddScoped<LocationService>();
services.AddScoped<SlideService>();
services.AddScoped<ManagerService>();
services.AddScoped<SocialService>();

services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

#if DEBUG
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    SeedData.Initialize(serviceProvider);
}
#endif

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        context.Context.Response.Headers.Add("cache-control", "public,max-age=31536000");
    }
});

app.UseRouting();

app.UseAuthorization();

app.UseResponseCompression();
app.UseResponseCaching();
app.MapRazorPages();

app.Run();
