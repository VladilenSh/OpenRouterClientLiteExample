using OpenRouterClientLite;
//using OpenRouterClientLite.Models;

// Создание клиента с обязательным API ключом
using var client = new OpenRouterClient("api_key", "OpenRouterClientNet9", "https://hd0.ru");

// Дополнительно можно указать название приложения и URL сайта
try
{
    var models = await client.GetModelsAsync();
    foreach (var model in models)
    {
        Console.WriteLine($"ID: {model.Id}, Name: {model.Name}");
        Console.WriteLine($"Description: {model.Description}");
        Console.WriteLine($"Pricing: {model.Pricing.Prompt} (prompt) / {model.Pricing.Completion} (completion)");
        Console.WriteLine();
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

    var responseContent = response.ChatCompletionChoice[0].GeneratedMessage.Content;
    Console.WriteLine(responseContent);
    var usage = response.UsageTokens;
    Console.WriteLine($"Tokens used: {usage.PromptTokens} (prompt) + {usage.CompletionTokens} (completion) = {usage.TotalTokens}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
Console.ReadLine( );