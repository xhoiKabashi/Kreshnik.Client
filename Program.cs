using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorDex;
using BlazorDex.Util;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<HeroClient>(); // Correct registration of HeroClient
builder.Services.AddScoped<GameAnimationService>();
builder.Services.AddSingleton<HeroStateService>();




await builder.Build().RunAsync();
