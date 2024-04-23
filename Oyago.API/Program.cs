using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json.Serialization;
using Oyago.Application.ServiceRegistry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

//builder.Services.AddControllers();
builder.Services.AddCors(options =>
                    options.AddDefaultPolicy(builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    }));

builder.Services.AddControllers(options =>
{
    //Add global filters
    //options.Filters.Add(new ApiExceptionFilter());

}).AddMvcOptions(options =>
{
    options.Filters.Add(
    new ResponseCacheAttribute
    {
        NoStore = true,
        Location = ResponseCacheLocation.None

    });
    //options.Filters.Add<AuthFilter>();

}).AddNewtonsoftJson()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ServiceDependecies(builder.Configuration, builder.Environment);

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
