using Models;
using Services;
using Serilog;

namespace UI;

public class ManagerUI{
    public Employee manager {get;set;}

    private readonly UserService _service;

    public ManagerUI(Employee managerIn, UserService serviceIn) {
        this.manager = managerIn;
        _service = serviceIn;
    }

    public void Begin() {
        
        Console.WriteLine("Greetings " + manager.empName + "!");

        while(true){
            Console.WriteLine("[1]: View Tickets");
            Console.WriteLine("[2]: Manage Tickets");
            Console.WriteLine("[3]: Edit Employee Role");
            Console.WriteLine("[0]: Log Out");

            string choice = (Console.ReadLine()!);
            choice = choice.Trim();

            switch(choice) {
                case "0":
                    break;                
                case "1":
                    DisplayTickets();
                    continue;
                case "2":
                    ManageTickets();
                    continue;
                case "3":
                    ChangeRole();
                    continue;
                default:
                    Console.WriteLine("Invalid Option: Please Try Again");
                    continue;
            }
            Console.WriteLine("Logging out...\n");
            break;
        }
    
    }
    private void DisplayTickets() {
        while(true){
            Console.WriteLine("[1]: Pending Tickets");
            Console.WriteLine("[2]: Previous Tickets");
            Console.WriteLine("[0]: Exit");
            string choice = Console.ReadLine()!;
            choice = choice.Trim();
            
            switch(choice){
                case "0":
                    break;
                case "1":
                    _service.showPendingTickets();
                    break;
                case "2":
                    _service.showManagedTickets();
                    break;
                default:
                    Console.WriteLine("Error, That Choice is invalid, please try again");
                    continue;
            }
            break;
        }
    }

    
    private void ManageTickets(){
        try{
            while(true){
                Console.WriteLine("[0]: To Exit: ");
                Console.WriteLine("Please enter the ticket I.D. that you want to manage: ");
                int tickID = int.Parse(Console.ReadLine()!);
                if(tickID == 0){break;}
                _service.manageTickets(tickID, manager);
                break;
            }
        }
        catch(Exception ex){
            Log.Error("Something Went Wrong When managing Tickets", ex);
        }
    }

    private void ChangeRole(){
        Console.WriteLine("Enter the userID of the Employee: ");
        string empID = Console.ReadLine()!;
        empID = empID.Trim();
        _service.RoleManager(empID);
    }
}