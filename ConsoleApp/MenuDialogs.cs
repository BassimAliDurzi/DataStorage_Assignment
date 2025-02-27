using Business.Dtos;
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
            Console.WriteLine("6. Get Project");
            Console.WriteLine("7. Create Product");
            Console.WriteLine("8. Create Status");
            Console.WriteLine("9. Create User");
            Console.WriteLine("10. Get All Products");
            Console.WriteLine("11. Get All StatusType");
            Console.WriteLine("12. Get All Users");
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
                case "10":
                    GetAllProducts();
                    break;
                case "11":
                    GetAllStatus();
                    break;
                case "12":
                    GetAllUsers();
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
        Console.Clear();
        Console.WriteLine("*** New Project ***");

        Console.Write("Project Title: ");
        string projectTitle = Console.ReadLine()!;

        Console.Write("Project Description: ");
        string projectDescription = Console.ReadLine()!;

        Console.Write("Start Date (YYYY-MM-DD): ");
        DateTime startDate = Convert.ToDateTime(Console.ReadLine()!);

        Console.Write("End Date: (YYYY-MM-DD)");
        DateTime endDate = Convert.ToDateTime(Console.ReadLine()!);

        Console.Write("Customer Id: ");
        int customerId = Convert.ToInt32(Console.ReadLine()!);

        Console.Write("Status Id: ");
        int statusId = Convert.ToInt32(Console.ReadLine()!);

        Console.Write("User Id: ");
        int userId = Convert.ToInt32(Console.ReadLine()!);

        Console.Write("Product Id: ");
        int productId = Convert.ToInt32(Console.ReadLine()!);

        var registrationForm = new ProjectRegistrationForm
        {
            Title = projectTitle,
            Description = projectDescription,
            StartDate = startDate,
            EndDate = endDate,
            CustomerId = customerId,
            StatusId = statusId,
            UserID = userId,
            ProductID = productId
        };

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var dataContext = new DataContext(optionsBuilder.Options))
        {
            var projectRepository = new ProjectRepository(dataContext);
            var projectService = new ProjectService(projectRepository);
            projectService.CreateProjectAsync(registrationForm).Wait();
        }

        Console.WriteLine($"Project '{registrationForm.Title}' created successfully!");


        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void GetAllCustomers()
    {
        Console.Clear();
        Console.WriteLine("*** All Customers ***");
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
        Console.Clear();
        Console.WriteLine("*** All Projects ***");
        Console.WriteLine("");

        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var projectRepository = new ProjectRepository(datacontext);
            var projectService = new ProjectService(projectRepository);

            var projects = projectService.GetProjectsAsync().GetAwaiter().GetResult();

            if (projects.Count() > 0)
            {
                foreach (var project in projects)
                {
                    Console.WriteLine($"Id: {project?.Id}, Title: {project?.Title}");
                    Console.WriteLine($"Description: {project?.Description}");
                    Console.WriteLine($"Product Id: {project?.ProductID}");
                    Console.WriteLine($"Start Date: {project?.StartDate}, End Date: {project?.EndDate}");
                    Console.WriteLine($"Customer Id: {project?.CustomerId}, Status Id: {project?.StatusId}, User Id: {project?.UserID}");
                    Console.WriteLine("------------------------------------------------------");

                }
            }
            else
            {
                Console.WriteLine("There is no project in the list.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
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
        Console.Clear();
        Console.WriteLine("*** Get Project By Title ***");
        Console.WriteLine("");

        Console.Write("Enter project title: ");
        string projectTitle = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(projectTitle))
        {
            Console.WriteLine("Project title cannot be empty.");
            return;
        }

        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var projectRepository = new ProjectRepository(datacontext);
            var projectService = new ProjectService(projectRepository);
            var project = projectService.GetProjectByProjectNameAsync(projectTitle).GetAwaiter().GetResult();
            if (project != null)
            {
                Console.WriteLine($"Id: {project?.Id}, Title: {project?.Title}");
                Console.WriteLine($"Description: {project?.Description}");
                Console.WriteLine($"Product Id: {project?.ProductID}");
                Console.WriteLine($"Start Date: {project?.StartDate}, End Date: {project?.EndDate}");
                Console.WriteLine($"Customer Id: {project?.CustomerId}, Status Id: {project?.StatusId}, User Id: {project?.UserID}");
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
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
        Console.Clear();
        Console.WriteLine("*** New User ***");

        Console.Write("User first name: ");
        string usertName = Console.ReadLine()!;

        Console.Write("User last name: ");
        string userLastName = Console.ReadLine()!;

        Console.Write("User email: ");
        string userEmail = Console.ReadLine()!;



        var registrationForm = new UserRegistrationForm
        {
            FirstName = usertName,
            LastName = userLastName,
            Email = userEmail
        };

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var dataContext = new DataContext(optionsBuilder.Options))
        {
            var userRepository = new UserRepository(dataContext);
            var userService = new UserService(userRepository);
            userService.CreateUserAsync(registrationForm).Wait();
        }

        Console.WriteLine($"User '{registrationForm.FirstName} {registrationForm.LastName}' created successfully!");


        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void GetAllProducts()
    {
        Console.Clear();
        Console.WriteLine("*** All Products ***");
        Console.WriteLine("");

        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var productRepository = new ProductRepository(datacontext);
            var productService = new ProductService(productRepository);

            var products = productService.GetProductAsync().GetAwaiter().GetResult();

            if (products.Count() > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product?.Id}, Name: {product?.ProductName}, Price: {product?.Price}");
                }
            }
            else
            {
                Console.WriteLine("There is no product in the list.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void GetAllStatus()
    {
        Console.Clear();
        Console.WriteLine("*** All Status ***");
        Console.WriteLine("");

        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var statusRepository = new StatusTypeRepository(datacontext);
            var statusService = new StatusTypeService(statusRepository);

            var statusTypes = statusService.GetStatusTypeAsync().GetAwaiter().GetResult();

            if (statusTypes.Count() > 0)
            {
                foreach (var statusType in statusTypes)
                {
                    Console.WriteLine($"Id: {statusType?.Id}, Name: {statusType?.StatusName}");
                }
            }
            else
            {
                Console.WriteLine("There is no status in the list.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void GetAllUsers()
    {
        Console.Clear();
        Console.WriteLine("*** All Users ***");
        Console.WriteLine("");

        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var userRepository = new UserRepository(datacontext);
            var userService = new UserService(userRepository);

            var users = userService.GetUserAsync().GetAwaiter().GetResult();

            if (users.Count() > 0)
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user?.Id}, Name: {user?.FirstName} {user?.LastName}, Email: {user?.Email}");
                }
            }
            else
            {
                Console.WriteLine("There is no user in the list.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

}
