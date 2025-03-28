using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().
                    ReadFrom.Configuration(builder.Configuration)
                    .CreateBootstrapLogger();

try
{
    Log.Information("Starting Web Host");
    builder.Host.UseSerilog((hostContext, services, configuration) =>
    {
        configuration.ReadFrom.Configuration(builder.Configuration);
    });
    // Add services to the container.
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    builder.Services.AddControllers().AddXmlSerializerFormatters();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        //app.MapOpenApi();
    }

    //app.UseHttpsRedirection();
    //app.UseAuthorization();

    // var summaries = new[]
    // {
    //         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //     };

    // app.MapGet("/weatherforecast", () =>
    // {
    //     var forecast = Enumerable.Range(1, 5).Select(index =>
    //         new WeatherForecast
    //         (
    //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //             Random.Shared.Next(-20, 55),
    //             summaries[Random.Shared.Next(summaries.Length)]
    //         ))
    //         .ToArray();
    //     return forecast;
    // })
    // .WithName("GetWeatherForecast");
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
