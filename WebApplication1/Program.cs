using System.Net;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using WeatherForecastService;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("app.log", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();
try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // ADD AutoFac DI
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule<WeatherForecastServiceApiModule>());

    builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();

    }

    app.UseHttpsRedirection();
    app.UseHttpLogging();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

}
catch (Exception ex)
{

    throw;
}
finally
{
    Log.CloseAndFlush();
}


