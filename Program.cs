using DCA.Components;
using DCA.Data;
using DCA.Service;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMudServices();
builder.Services.AddHttpClient<CoinMarketCapClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CoinMarketCap:ApiUrl"]!);
    client.DefaultRequestHeaders.Add(builder.Configuration["CoinMarketCap:HeaderKeyName"]!, builder.Configuration["CoinMarketCap:ApiKey"]); 
});
builder.Services.AddSingleton<BinanceWebSocketClient>();

builder.Services.AddMemoryCache();
builder.Services.AddBinance();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();