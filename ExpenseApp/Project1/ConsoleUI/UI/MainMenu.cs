
using Serilog;
using Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace UI;

public class StartMenu{
    
    private HttpClient _http;

    public StartMenu() {

        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:5240/");
    }

    public async Task Begin() {
        
            Console.WriteLine("Welcome to the Expense Reimbursement Applicaion!");
            Console.WriteLine("Please Select From the Following Menu: ");
        while (true) {
            Console.WriteLine("[1]: User Login");
            Console.WriteLine("[2]: Create User");
            Console.WriteLine("[0]: Exit the Program");

            string response = (Console.ReadLine()!);
            response = response.Trim();

            switch (response) {
                case "0":
                    break;
                case "1":
                    userLogin();
                    continue;
                case "2":
                    // ActivateAccount();
                    break;
                default:
                    Console.WriteLine("Error! Invalid Option... Please Try Again\n");
                    continue;
            }
        break;
        }
    }


    private async Task userLogin(){
        while (true){
        Console.WriteLine("[0]: To Exit");

        Console.Write("Enter username: ");
        string username = Console.ReadLine()!;
        username = username.Trim();
        if(username.Equals("0")){break;};

        Console.Write("Enter password: ");
        string password = Services.UserService.passwordHider.keyStrokes()!;
        password = password.Trim();
        if(password.Equals("0")){break;};

        Employee user = new Employee();
        user.username = username;
        user.password = password;

        Console.WriteLine(user);
        
            if (user == null) {
                Console.WriteLine("Incorrect username or password, please try again.");
                continue;
            }

            if(!user.employeeType.Equals("Manager")){
                new EmployeeUI(user,_http).Begin();
            }
            else {
                new ManagerUI(user, _http).Begin();
            }
            break;
        }
    }

    // private void ActivateAccount() {
    //     while(true){
    //         Console.Write("Enter your first name: ");
    //         string fname = Console.ReadLine()!;
    //         if(fname.Length > 40){Console.WriteLine("Error! First Name Too Long, Please try again...");continue;};
    //         Console.Write("Enter Your Last Name: ");
    //         ln:
    //         string lname = Console.ReadLine()!;
    //         if(lname.Length > 40){Console.WriteLine("Error! Last Name Too Long, Please try again...");goto ln;};
    //         unm:
    //         Console.Write("Create a username: ");
    //         string uName = Console.ReadLine()!;
    //         uName = uName.Trim();
    //         if(_service.usernameChecker(uName) == false){
    //             goto unm;
    //         }
    //         if(uName.Length > 30){Console.WriteLine("Error! Username Too Long, Please try again...");goto unm;}
    //         pwd:
    //         Console.Write("Create a password must be at least 6 characters: ");
    //         string pWord = Console.ReadLine()!;
    //         pWord = pWord.Trim();
    //         if(pWord.Length < 6){Console.WriteLine("Error! Your password it too short, Please Try Again");goto pwd;}
    //         if(pWord.Length > 30){Console.WriteLine("Error! Password Too Long, Please try again...");goto pwd;};


    //         string fullName = fname + " " + lname;
    //         Employee newUser = new Employee(fullName, uName, "", pWord, "");
        
    //         Console.WriteLine("What is Your Job Description: ");
    //         Console.WriteLine("[1]: Employee");
    //         Console.WriteLine("[2]: Manager");
    //         Console.WriteLine("[0]: Exit");

    //         string answer = (Console.ReadLine()!);
    //         answer = answer.Trim();

    //         if (newUser.PickEmpType(answer).Equals("Employee")){
    //             Log.Information("Creating Employee Account...");
    //             newUser.employeeType = "Employee";
    //             Console.WriteLine("Creating Account...");
    //             Console.WriteLine("Please Enter Your user ID: ");
    //             newUser.userID = Console.ReadLine()!;
    //         }
    //         else if (newUser.PickEmpType(answer).Equals("Manager")){
    //             newUser.employeeType = "Manager";
    //             Console.WriteLine("[0]: to Exit");
    //             Console.WriteLine("Please Enter The Manager Key Code: ");
    //             string response = Console.ReadLine()!;
    //             if(response.Equals("0")) {break;};  
    //             if (!response.Equals(Key.getManagerKey())) {
    //                 Console.WriteLine("Invalid Key, please try again or choose another Job Description.");
    //                 continue;
    //             }
    //             else if (response.Equals(Key.getManagerKey())){
    //                 Console.WriteLine("Please Enter Your userID: ");
    //                 newUser.userID = Console.ReadLine()!;
    //                 try{
    //                     _service.CreateAccount(newUser);
    //                     Log.Information("Creating Manager Account...");
    //                 }
    //                 catch(Exception ex){
    //                 Console.WriteLine("Error! Something happened in account creation: ", ex);
    //                 }
    //                 break;
    //             }
    //         }
    //         break;
    //     }
    //     Begin();
    // }

}
