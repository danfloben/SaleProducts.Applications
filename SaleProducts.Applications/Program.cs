using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AgencyApp.Business.Services;
using AgencyApp.Data.Context;
using AgencyApp.Data.Repositories;
using AgencyApp.Business.Services.interfaces;

internal class Program
{
    static void Main(string[] args)
    {
        var saleService = ConfigureServices().GetRequiredService<ISaleServices>();
        saleService.Create(ReadDataToJson());
    }

    private static string ReadDataToJson()
    {
        string data = string.Empty;

        try
        {
            using (StreamReader reader = new StreamReader("data.json"))
            {
                data = reader.ReadToEnd();
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading data.json: {ex.Message}");
        }

        return data;
    }

    private static ServiceProvider ConfigureServices()
    {
        // Configuración de servicios y DI
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddSingleton<ISaleRepository, SaleRepository>()
            .AddSingleton<ISaleServices, SaleServices>()
            .AddSingleton<IConfiguration>(configuration)
            .AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            .BuildServiceProvider();

        return serviceProvider;
    }
}
