using AuditHttpFunction;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddHttpClient();
        services.AddScoped<IAuditHttpClient, AuditHttpClient>();
        services.AddScoped<IAuditHttpService, AuditHttpService>();
    })
    .Build();

host.Run();
