using Models;

namespace UI;

public class ManagerUI{
    public Employee manager;

    public ManagerUI(Employee managerIn) {
        this.manager = managerIn;
    }

    public void Begin() {
        Console.WriteLine("Greetings " + manager.empName + "!");
        Console.WriteLine("[1]: View Tickets");
        Console.WriteLine("[2]: View Previous Tickets");
        Console.WriteLine("[3] Edit Employee Role");

        int choice = int.Parse(Console.ReadLine()!);

        switch(choice) {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Console.WriteLine("Invalid Option: Please Try Again");
                break;
        }
    }
}