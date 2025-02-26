using System.Text.RegularExpressions;
using Business.Dtos;
using Business.Factories;
using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Presentation.ConsoleApp;

public class MenuDialogs(CustomerService customerService, ProjectService projectService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly ProjectService _projectService = projectService;
    private readonly DbContextOptions<DataContext>? options;

    public void MenuOptions()
    {
        while (true)
        {
            Console.WriteLine("1. Create New Customer");
            Console.WriteLine("2. Create New Project");
            Console.WriteLine("3. Get All Customers");
            Console.WriteLine("4. Get All Projects");
            Console.WriteLine("5. Get Customer");
            Console.WriteLine("6. get Project");
            Console.WriteLine("0. Exit");
            Console.Write("\nChoose your option: ");

            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    CreateCustomer();
                    break;
                case "2":
                    CreateProject();
                    break;
                case "3":
                    GetAllCustomers();
                    break;
                case "4":
                    GetAllProjects();
                    break;
                case "5":
                    GetCustomer();
                    break;
                case "6":
                    GetProject();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void CreateCustomer()
    {
        Console.Clear();
        Console.WriteLine("*** New Customer ***");

        string customerName = ValidateName("Customer name");

        var registrationForm = new CustomerRegistrationForm
        {
            CustomerName = customerName
        };

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var dataContext = new DataContext(optionsBuilder.Options))
        {
            var customerRepository = new CustomerRepository(dataContext);
            var customerService = new CustomerService(customerRepository);
            customerService.CreateCustomerAsync(registrationForm).Wait();
        }

        Console.WriteLine($"Customer '{registrationForm.CustomerName}' created successfully!");


        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    public void CreateProject()
    {
    }

    public void GetAllCustomers()
    {
        Console.Clear();
        Console.WriteLine("*** All Customer ***");
        Console.WriteLine("");

        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var customerRepository = new CustomerRepository(datacontext);
            var customerService = new CustomerService(customerRepository);

            var customers = customerService.GetCustomersAsync().GetAwaiter().GetResult();

            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Id: {customer.Id}, Name: {customer.CustomerName}");
                }
            }
            else
            {
                Console.WriteLine("There is no customer in the list.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void GetAllProjects()
    {
    }
    public void GetCustomer()
    {
    }

    public void GetProject()
    {
    }

    private static string ValidateName(string fieldName)
    {
        while (true)
        {
            Console.Write($"{fieldName}: ");
            string input = (Console.ReadLine() ?? string.Empty).Trim();

            if (Regex.IsMatch(input, @"^[a-zA-ZåäöÅÄÖ -]+$"))
            {
                return input;
            }
            else
            {
                Console.WriteLine($"Invalid {fieldName}. Field must contain letters only.");
            }
        }
    }


}
