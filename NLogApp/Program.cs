using NLog.Web;
using NLogApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Utilize extension method for adding NLog.
builder.Services.AddNLogExtension();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();