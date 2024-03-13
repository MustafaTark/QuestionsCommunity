using BrightWeb.Extensions;
using Domain.Models.Identity;
using Domain.SeedWork;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
               policy =>
               {
                   policy.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
               });
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.ConfigureLifeTime();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity<User>();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ApiExceptionFilter()); // Add your custom exception filter here if needed
}).ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            Type = "https://httpstatuses.com/400",
            Title = "One or more validation errors occurred.",
            Status = StatusCodes.Status400BadRequest,
            Detail = "See the errors property for details.",
            Instance = context.HttpContext.Request.Path
        };

        return new BadRequestObjectResult(problemDetails)
        {
            ContentTypes = { "application/problem+json" }
        };
    };
});



//    .AddJsonOptions(
//  //opt =>
//  //    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
//);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Place to add JWT with Bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    s.AddSecurityRequirement(new OpenApiSecurityRequirement()
{

    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Name = "Bearer",
        },
        new List<string>()
    }
});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
//var summaries = new[]
//{
//	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//	var forecast = Enumerable.Range(1, 5).Select(index =>
//		new WeatherForecast
//		(
//			DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//			Random.Shared.Next(-20, 55),
//			summaries[Random.Shared.Next(summaries.Length)]
//		))
//		.ToArray();
//	return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();
app.MapControllers();
app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
