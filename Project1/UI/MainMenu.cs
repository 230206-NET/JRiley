using Models;
using Services;

namespace UI;

public class StartMenu{
    
    private readonly UserService _service;

    public StartMenu(UserService serviceIn) {
        _service = serviceIn;
    }

    public void Begin() {
        while (true) {
            Console.WriteLine("Welcome to the Expense Reimbursement Applicaion!");
            Console.WriteLine("Please Select From the Following Menu: ");
            Console.WriteLine("[1] User Login");
            Console.WriteLine("[2] Create User");
            Console.WriteLine("[0] To Exit");

            int response = int.Parse(Console.ReadLine()!);

            switch (response) {
                case 0:
                    break;
                case 1:
                    userLogin();
                    break;
                case 2:
                    ActivateAccount();
                    break;
                default:
                    Console.WriteLine("Error! Invalid Option... Please Try Again");
                    break;
            }
        Console.WriteLine("Exiting the Program...");
        break;
        }
    }


    private void userLogin(){
        while (true){
        const string managerKey = "manPWD!";
        Console.Write("Enter username: ");
        string username = Console.ReadLine()!;
        Console.Write("Enter password: ");
        string password = Console.ReadLine()!;
        
        
        Employee user = _service.VerifyUser(username, password);
            
        
        
            if (user == null) {
                Console.WriteLine("login failed, try again");
                continue;
            }

            if(!user.userID.Equals(managerKey)){
                new EmployeeUI(user).Begin();
            }
            else {
                new ManagerUI(user).Begin();
            }
        }
    }

    private void ActivateAccount() {
        string managerKey = "manPWD!";
        Console.Write("Enter your first name: ");
        string fname = Console.ReadLine()!;
        Console.Write("Enter Your Last Name: ");
        string lname = Console.ReadLine()!;
        Console.Write("Create a username: ");
        string uName = Console.ReadLine()!;
        Console.Write("Create a password: ");
        string pWord = Console.ReadLine()!;

        string fullName = fname + " " + lname;


        Employee newUser = new Employee(fullName, uName, "", pWord, "");

        Console.WriteLine("What is Your Job Description: ");
        Console.WriteLine("[1] Employee: ");
        Console.WriteLine("[2] Manager: ");

        int answer = int.Parse(Console.ReadLine()!);

        if (newUser.PickEmpType(answer).Equals("Employee")){
            newUser.employeeType = "Employee";
            Console.WriteLine("Creating Account...");
            Console.WriteLine("Please Enter Your user ID: ");
            newUser.userID = Console.ReadLine()!;
        }
        else if (newUser.PickEmpType(answer).Equals("Manager")){
            newUser.employeeType = "Manager";
            Console.WriteLine("Please Enter The Manager Key Code: ");
            string response = Console.ReadLine()!;
            if (!response.Equals(managerKey)) {
                Console.WriteLine("Invalid Key, please try again or choose another Job Description.");
            }
            else if (response.Equals(managerKey)){
                Console.WriteLine("Creating Account...");
                Console.WriteLine("Please Enter Your userID: ");
                newUser.userID = Console.ReadLine()!;
            }
        }

        _service.CreateAccount(newUser);

    }
}
