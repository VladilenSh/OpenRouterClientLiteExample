using OpenRouterClientLite;
using OpenRouterClientLite.Models;

// Создание клиента с обязательным API ключом
var client = new OpenRouterClient("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");

// Дополнительно можно указать название приложения и URL сайта
var clientWithHeaders = new OpenRouterClient(
    "your-api-key-here",
    appName: "MyAwesomeApp",
    siteUrl: "https://myapp.com");
try
{
    var models = await client.GetModelsAsync();
    foreach (var model in models)
    {
        Console.WriteLine($"ID: {model.Id}, Name: {model.Name}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
try
{
    var response = await client.GenerateResponseAsync(
        model: "deepseek/deepseek-chat:free",
        prompt: "Привет! Как дела?",
        temperature: 0.7,
        maxTokens: 100);

    Console.WriteLine(response.ChatCompletionChoice[0].GeneratedMessage.Content);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
Console.ReadLine( );