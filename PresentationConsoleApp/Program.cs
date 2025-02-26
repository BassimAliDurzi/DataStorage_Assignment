using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PresentationConsoleApp;

//var services = new ServiceCollection()
//    .AddDbContext<DataContext>(x => x.UseSqlServer())
//    .AddScoped<CustomerRepository>()
//    .AddScoped<ProjectRepository>()
//    .AddScoped<CustomerRepository>()
//    //.AddScoped<ProjectService>()
//    //.AddScoped<MenuDialog>()
//    .BuildServiceProvider();

//var menuDisalogd = services.GetRequiredService<MenuDialog>();
//await menuDisalogd.MenuOptions();

public class Program
{
    public static void Main(string[] args)
    {
        // Kick off your app; optionally set up a host, services, etc.
        Console.WriteLine("App is starting...");
    }
}
