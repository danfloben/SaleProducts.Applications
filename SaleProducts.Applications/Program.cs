using AgencyApp.Business.Services;
using AgencyApp.Business.Services.interfaces;
using AgencyApp.Data.Context;
using AgencyApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System;
using SaleProducts.Data.Models;

internal class Program
{
    static void Main(string[] args)
    {
        var saleService = ConfigureServices().GetRequiredService<ISaleServices>();
        saleService.CreateAsync(ReadDataToJson());
    }

    private static string ReadDataToJson()
    {
        string? data = null;

        try
        {
            using (StreamReader reader = new StreamReader("data.json"))
            {
                data = reader.ReadToEnd();
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading data.json: " + ex.Message);
        }

        return data;
    }

    private static ServiceProvider ConfigureServices()
    {

        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
  
        var serviceProvider = new ServiceCollection()
                .AddSingleton<ISaleRepository, SaleRepository>()
                .AddSingleton<ISaleServices, SaleServices>()
                .AddDbContext<AppDbContext>(options =>
                    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();

        return serviceProvider;
    }

}


