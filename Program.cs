using Audit.Http;
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
        services.AddHttpClient<IAuditHttpClient, AuditHttpClient>()
            .AddAuditHandler(audit =>
            {
                audit.IncludeRequestBody();
                audit.IncludeResponseBody();
            });

        services.AddScoped<IAuditHttpService, AuditHttpService>();
    })
    .Build();

host.Run();
