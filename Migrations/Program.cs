
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Migrations;

CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<AppDataContext>(options =>
            {
                options.UseNpgsql(
                    hostContext.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(nameof(Migrations))
                ).UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder
                        .AddConsole((_) => { })
                        .AddFilter((category, level) =>
                            category == DbLoggerCategory.Database.Command.Name
                            && level == LogLevel.Information);
                }));
            });
            services.AddScoped<Worker>();
        });