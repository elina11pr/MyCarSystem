using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCarSystem.CarServer;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSignalR();
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseKestrel()
            .UseUrls("http://localhost:7054")
            .Configure(app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<CarHub>("/current-time");
                });
            });
    })
    .Build();

await host.RunAsync();