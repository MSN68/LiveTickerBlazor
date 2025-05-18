using Microsoft.AspNetCore.SignalR;
using SignalRServer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddHostedService<MessageSenderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<TestHub>("/marketHub");
    endpoints.MapControllers();
});

app.Run();


