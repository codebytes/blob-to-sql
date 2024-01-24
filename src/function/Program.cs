using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

var credential = new DefaultAzureCredential();
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(config =>
        config.AddAzureKeyVault(new Uri(Environment.GetEnvironmentVariable("AZURE_KEY_VAULT_ENDPOINT")!), credential))
    .ConfigureServices((config, services) => { })
    .Build();

await using (var scope = host.Services.CreateAsyncScope())
{
}
await host.RunAsync();
