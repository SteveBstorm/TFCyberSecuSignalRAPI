using SignalRAPI.Controllers;
using SignalRAPI.Hubs;
using SignalRAPI_DAL.Repositories;
using SignalRAPI_DAL.Services;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("myPolicy", options => 
    options.WithOrigins("http://localhost:4200", "https://localhost:7107")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod()));

builder.Services.AddScoped<SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IArticleRepo, ArticleService>();

builder.Services.AddSignalR();

builder.Services.AddSingleton<ChatHub>();
builder.Services.AddSingleton<ArticleHub>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseCors("myPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("chat");
app.MapHub<ArticleHub>("articlehub");

app.Run();
