using Lektion5_MainApp.Models;

namespace Lektion5_MainApp.Services;

internal static class MenuService
{
    private static readonly UserService _userService = new UserService();
    private static void CreateUserMenu()
    {
        var user = new User();

        Console.Clear();
        Console.WriteLine("-- CREATE NEW USER --");

        Console.Write("Enter first name: ");
        user.FirstName = Console.ReadLine() ?? "";

        Console.Write("Enter last name: ");
        user.LastName = Console.ReadLine() ?? "";

        Console.Write("Enter e-mail address: ");
        user.Email = Console.ReadLine() ?? "";

        Console.Write("Enter phone number: ");
        user.PhoneNumber = Console.ReadLine() ?? "";

        var response = _userService.CreateUser(user);
        Console.WriteLine(response.Message);

    }

    private static void ListAllUsersMenu()
    {
        Console.Clear();
        Console.WriteLine("-- USER LIST --");

        var users = _userService.GetAllUsers();
        if (users != null)
        {
            foreach (var user in _userService.GetAllUsers())
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} <{user.Email}");
            }
        }
        else
        {
            Console.WriteLine("No users were found.");
        }

        Console.ReadKey();
    }

    private static void ExitApplicationMenu()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit? (y/n)");
        var answer = Console.ReadLine() ?? "n";
        if (answer.ToLower() == "y")
        {
            Environment.Exit(0);
        }
    }

    private static bool MenuOptions(string selectedOption)
    {
        if (int.TryParse(selectedOption, out int option))
        {
            switch (option)
            {
                case 1:
                    CreateUserMenu();
                    Console.ReadKey();
                    break;

                case 2:
                    ListAllUsersMenu();
                    Console.ReadKey();
                    break;

                case 0:
                    ExitApplicationMenu();
                    break;

                default:
                    Console.WriteLine("Invalid option selected");
                    Console.ReadKey();
                    return false;
            }

            return true;
        }

        return false;
    }

    public static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Create New User");
        Console.WriteLine("2. List All Users");
        Console.WriteLine("0. Exit");

        Console.Write("Enter an option: ");

        var result = MenuOptions(Console.ReadLine() ?? "");
        if (!result)
        {
            Console.WriteLine("Invalid option selected!");
        }
    }
}

/* 
internal static class MenuService
{
    public static void MainMenu()
    {
        CreateUser();
    }

    public static void CreateUser()
    {
        Console.WriteLine("-- CREATE USER --");
        var user = new User();
        user.Name = "Hans";

        Console.WriteLine(user.Name);
    }
}

internal class User
{
    public string Name { get; set; } = null!;
}

/*
internal class MenuService
{
    // fields
    private string _fieldName = null!;

    // Properties 
    public string PropertyName { get; set; } = null!;

    // Methods
    public void MethodName_1()
    {

    }

    public static string MethodName_2(string inputParameter)
    {
        return inputParameter;
    }

    public (string, string) MethodName_3(string inputParameter, string inputSecondParameter)
    {
        return (inputParameter, inputSecondParameter);
    }

    public void MethodName_4(string inputParameter, out string outputParameter)
    {
        outputParameter = "";
    }

    // Constructors
    public MenuService(string fieldName, string propertyName)
    {
        _fieldName = fieldName;
        PropertyName = propertyName;
    }
}

*/
