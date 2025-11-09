using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SteamPriceBot.Web;
using SteamPriceBot.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Configure base address for API
var apiBase = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5000";

Console.WriteLine($"ApiBaseUrl: {apiBase}");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBase) });
builder.Services.AddScoped<ApiClient>();
await builder.Build().RunAsync();
