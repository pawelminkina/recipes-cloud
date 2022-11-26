using Infrastructure;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((h, s) =>
    {
        s.AddInfrastructure(h.Configuration);
    })
    .Build();
host.Run();