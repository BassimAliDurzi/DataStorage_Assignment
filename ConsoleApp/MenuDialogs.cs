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
            Console.WriteLine("7. Create Product");
            Console.WriteLine("8. Create Status");
            Console.WriteLine("9. Create User");
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
                case "7":
                    CreateProduct();
                    break;
                case "8":
                    CreateStatus();
                    break;
                case "9":
                    CreateUser();
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

        Console.Write("Customer name: ");
        string customerName = Console.ReadLine()!;

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


        Console.WriteLine("\nPress any key to return to the menu.");
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

            if (customers.Count() > 0)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Id: {customer?.Id}, Name: {customer?.CustomerName}");
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
        Console.Clear();
        Console.WriteLine("*** Get Customer By Name ***");
        Console.WriteLine("");

        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(customerName))
        {
            Console.WriteLine("Customer name cannot be empty.");
            return;
        }

        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var customerRepository = new CustomerRepository(datacontext);
            var customerService = new CustomerService(customerRepository);
            var customer = customerService.GetCustomerByCustomerNameAsync(customerName).GetAwaiter().GetResult();
            if (customer != null)
            {
                Console.WriteLine($"Id: {customer.Id}, Name: {customer.CustomerName}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();

    }

    public void GetProject()
    {
    }

    public void CreateProduct()
    {
        Console.Clear();
        Console.WriteLine("*** New Product ***");

        Console.Write("Product name: ");
        string productName = Console.ReadLine()!;

        Console.Write("Product price: ");
        decimal productPrice = Convert.ToDecimal(Console.ReadLine()!);

        var registrationForm = new ProductForm
        {
            ProductName = productName,
            Price = productPrice
        };

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var dataContext = new DataContext(optionsBuilder.Options))
        {
            var productRepository = new ProductRepository(dataContext);
            var productService = new ProductService(productRepository);
            productService.CreateProductAsync(registrationForm).Wait();
        }

        Console.WriteLine($"Product '{registrationForm.ProductName}' created successfully!");


        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void CreateStatus()
    {
        Console.Clear();
        Console.WriteLine("*** New Status Type ***");

        Console.Write("Status name: ");
        string statusName = Console.ReadLine()!;

        var registrationForm = new StatusTypeForm
        {
            StatusName = statusName 
        };

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var dataContext = new DataContext(optionsBuilder.Options))
        {
            var statusTypeRepository = new StatusTypeRepository(dataContext);
            var statusTypeService = new StatusTypeService(statusTypeRepository);
            statusTypeService.CreateStatusTypeAsync(registrationForm).Wait();
        }

        Console.WriteLine($"Status '{registrationForm.StatusName}' created successfully!");


        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void CreateUser()
    {
    }

}
