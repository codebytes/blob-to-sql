using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

public class Input
{
    private readonly ILogger _logger;

    public Input(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Input>();
    }

    [Function(nameof(BlobInput))]
    public void BlobInput(
        [BlobTrigger("hero/{name}.json", Connection = "AzureWebJobsStorage")] string blobTrigger, string name,
        [BlobInput("hero/{name}.json", Connection = "AzureWebJobsStorage")] string blobContent
        )
    {
        _logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}.json \n Size: {blobTrigger.Length} Bytes");

        _logger.LogInformation($"{blobContent}");
    }
}




public record Hero(Guid Id, string Name);