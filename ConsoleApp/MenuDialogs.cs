using Business.Dtos;
using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Presentation.ConsoleApp;

public class MenuDialogs(CustomerService customerService, ProjectService projectService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly ProjectService _projectService = projectService;


    public void MenuOptions()
    {
        while (true)
        {
            Console.WriteLine("\n***** Menu Options *****");
            Console.WriteLine("1.  Create New Customer");
            Console.WriteLine("2.  Create New Project");
            Console.WriteLine("3.  Create New Product");
            Console.WriteLine("4.  Create New Status");
            Console.WriteLine("5.  Create New User");

            Console.WriteLine("\n6.  Get Customer");
            Console.WriteLine("7.  Get Project");

            Console.WriteLine("\n8.  Get All Customers");
            Console.WriteLine("9.  Get All Projects");
            Console.WriteLine("10. Get All Products");
            Console.WriteLine("11. Get All StatusType");
            Console.WriteLine("12. Get All Users");

            Console.WriteLine("\n13. Delete Project");
            Console.WriteLine("14. Update Project");

            Console.WriteLine("\n0.  Exit");
            Console.WriteLine("**************************");
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
                    CreateProduct();
                    break;
                case "4":
                    CreateStatus();
                    break;
                case "5":
                    CreateUser();
                    break;
                case "6":
                    GetCustomer();
                    break;
                case "7":
                    GetProject();
                    break;
                case "8":
                    GetAllCustomers();
                    break;
                case "9":
                    GetAllProjects();
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
                case "13":
                    DeleteProject();
                    break;
                case "14":
                    UpdateProject();
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

        Console.Write("End Date: (YYYY-MM-DD): ");
        DateTime endDate = Convert.ToDateTime(Console.ReadLine()!);

        GetAllCustomers();
        Console.Write("\nType Customer Id: ");
        int customerId = Convert.ToInt32(Console.ReadLine()!);

        GetAllStatus();
        Console.Write("\nType Status Id: ");
        int statusId = Convert.ToInt32(Console.ReadLine()!);

        GetAllUsers();
        Console.Write("\nType User Id: ");
        int userId = Convert.ToInt32(Console.ReadLine()!);

        GetAllProducts();
        Console.Write("\nType Product Id: ");
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
                    Console.WriteLine($"Start Date: {project?.StartDate} \nEnd Date: {project?.EndDate}");
                    GetCustomerById(project.CustomerId);
                    GetProduct(project.ProductID);
                    GetStatus(project.StatusId);
                    GetUser(project.UserID);
                    Console.WriteLine("------------------------------------------------------");

                }
            }
            else
            {
                Console.WriteLine("There is no project in the list.");
            }
        }
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
    }

    public void GetCustomerById(int customerId)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var customerRepository = new CustomerRepository(datacontext);
            var customerService = new CustomerService(customerRepository);
            var customer = customerService.GetCustomerByIdAsync(customerId).GetAwaiter().GetResult();

            Console.WriteLine($"Customer Details:: Id: {customer?.Id}, Name: {customer?.CustomerName}");
        }
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
                Console.WriteLine($"Start Date: {project?.StartDate} \nEnd Date: {project?.EndDate}");
                GetCustomerById(project.CustomerId);
                GetProduct(project.ProductID);
                GetStatus(project.StatusId);
                GetUser(project.UserID);
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void GetProduct(int productId)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var productRepository = new ProductRepository(datacontext);
            var productService = new ProductService(productRepository);
            var product = productService.GetProductByIdAsync(productId).GetAwaiter().GetResult();

            Console.WriteLine($"Product Details:: Id: {product?.Id}, Name: {product?.ProductName}, Price: {product?.Price}");
        }
    }

    public void GetStatus(int statusId)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var statusRepository = new StatusTypeRepository(datacontext);
            var statusService = new StatusTypeService(statusRepository);
            var status = statusService.GetStatusTypeByIdAsync(statusId).GetAwaiter().GetResult();

            Console.WriteLine($"Project Status: {status?.StatusName}");
        }
    }

    public void GetUser(int userId)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var datacontext = new DataContext(optionBuilder.Options))
        {
            var userRepository = new UserRepository(datacontext);
            var userService = new UserService(userRepository);
            var user = userService.GetUserByIdAsync(userId).GetAwaiter().GetResult();

            Console.WriteLine($"User Details:: Id: {user?.Id}, Name: {user?.FirstName} {user?.LastName}, Email: {user?.Email}");
        }
    }

    public void DeleteProject()
    {
        Console.Clear();
        Console.WriteLine("*** Delete Project ***");

        GetAllProjects();
        Console.Write("\nType Project Id: ");

        int projectId;
        if (!int.TryParse(Console.ReadLine(), out projectId))
        {
            Console.WriteLine("Invalid project id.");
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
            var isDeleted = projectService.DeleteProjectAsync(projectId).GetAwaiter().GetResult();
            if (isDeleted)
            {
                Console.WriteLine("Project deleted successfully.");
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }

    }

    public void UpdateProject()
    {
        Console.Clear();
        Console.WriteLine("*** Update Project ***");

        GetAllProjects();
        Console.Write("\nType Project Id: ");
        if (!int.TryParse(Console.ReadLine(), out int projectId))
        {
            Console.WriteLine("Invalid project id.");
            return;
        }


        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Cources\\DataStorage_Assignment\\Data\\Databases\\Local_Db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        using (var checkContext = new DataContext(optionsBuilder.Options))
        {
            var existingProject = checkContext.Projects.FirstOrDefault(x => x.Id == projectId);
            if (existingProject == null)
            {
                Console.WriteLine("Project not found. Please try again.");
                Console.WriteLine("\nPress any key to return to the menu.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Project found. You can update project's information.");
            }
        }

        Console.Write("Project Title: ");
        string projectTitle = Console.ReadLine()!;

        Console.Write("Project Description: ");
        string projectDescription = Console.ReadLine()!;

        Console.Write("Start Date (YYYY-MM-DD): ");
        DateTime startDate = Convert.ToDateTime(Console.ReadLine()!);

        Console.Write("End Date (YYYY-MM-DD): ");
        DateTime endDate = Convert.ToDateTime(Console.ReadLine()!);

        GetAllCustomers();
        Console.Write("\nType Customer Id: ");
        int customerId = Convert.ToInt32(Console.ReadLine()!);

        GetAllStatus();
        Console.Write("\nType Status Id: ");
        int statusId = Convert.ToInt32(Console.ReadLine()!);

        GetAllUsers();
        Console.Write("\nType User Id: ");
        int userId = Convert.ToInt32(Console.ReadLine()!);

        GetAllProducts();
        Console.Write("\nType Product Id: ");
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

        using (var updateContext = new DataContext(optionsBuilder.Options))
        {
            var projectRepository = new ProjectRepository(updateContext);
            var projectService = new ProjectService(projectRepository);

            var isUpdated = projectService.UpdateProjectAsync(projectId, registrationForm).GetAwaiter().GetResult();

            if (isUpdated)
            {
                Console.WriteLine("Project updated successfully.");
            }
            else
            {
                Console.WriteLine("Project update failed. Please check the details and try again.");
            }
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }



}
