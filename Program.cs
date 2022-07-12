using SignalServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
options.AddPolicy("CorsPolicy",
    builder =>
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000")
        .AllowCredentials()));

var app = builder.Build();

app.UseCors("CorsPolicy");
app.MapHub<MyHub>("/chat");
app.Run();