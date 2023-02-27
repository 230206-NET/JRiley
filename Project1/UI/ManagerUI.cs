using Models;
using Services;

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
            Console.WriteLine("[1]: View Pending Tickets");
            Console.WriteLine("[2]: Manage Tickets");
            Console.WriteLine("[3]: Edit Employee Role");
            Console.WriteLine("[4]: Log Out");

            int choice = int.Parse(Console.ReadLine()!);

            switch(choice) {
                case 1:
                    DisplayPendingTickets();
                    continue;
                case 2:
                    ManageTickets();
                    continue;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid Option: Please Try Again");
                    break;
            }
            Console.WriteLine("Logging out...");
            break;
        }
    
    }
    private void DisplayPendingTickets() {
        _service.showPendingTickets();
    }

    
    private void ManageTickets(){
        Console.WriteLine("Please enter the ticket I.D. that you want to manage");
        int tickID = int.Parse(Console.ReadLine()!);
        _service.manageTickets(tickID);
    }
}