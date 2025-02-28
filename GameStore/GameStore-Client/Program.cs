using GameStore_Client.ApiConnection;
using GameStore_Client.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Tailwind Recompile after each file change
if (builder.Environment.IsDevelopment())
{
  builder.Services.AddHostedService<TailwindHostedService>();
}

var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ?? throw new Exception("GameStoreApiUrl is not set");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<GamesClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
