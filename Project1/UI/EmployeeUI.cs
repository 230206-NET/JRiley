using Models;
using Services;


namespace UI;

public class EmployeeUI{
    private Employee user {get;set;}

    private readonly UserService _service;
    public EmployeeUI(Employee userIn, UserService serviceIn){
        this.user = userIn;
        _service = serviceIn;
    }

    
    // public EmployeeUI(UserService serviceIn){
    //     _service = serviceIn;
    // }

    public void Begin(){
        Console.WriteLine("Greetings " + user.empName + "!");
        while (true) {
            Console.WriteLine("[1]: View Expense Reimbursement Requests");
            Console.WriteLine("[2]: Make an Expense Reimbursement Request");
            Console.WriteLine("[3]: Log Out");

            int choice = int.Parse(Console.ReadLine()!);

            switch(choice){
                case 1:
                    DisplayTickets();
                    continue;
                case 2:
                    ExpenseMaker();
                    continue;
                case 3:
                    break;
                default:
                    Console.WriteLine("Error, Invalid Option. Please Try Again!");
                break;

            }
            Console.WriteLine("Logging out...\n");
            break;
            //Environment.Exit(0);
        }

    }

    private void DisplayTickets() {
        _service.showUserTickets(user);
    }

    private void ExpenseMaker() {
        while(true) {
            Console.WriteLine("Please Enter the Expense Amount: ");
            double expense = double.Parse(Console.ReadLine()!);
            Console.WriteLine("Please Give a Description of the Expense: ");
            string expenseDescription = Console.ReadLine()!;
            string currentStatus = "Pending";
            ExpenseTicket newTicket = new ExpenseTicket(0,"", 0.0, "", "");

            newTicket.ticketID = _service.generateTicketID();
            newTicket.userID = user.userID;
            newTicket.ticketDescription = expenseDescription;
            newTicket.expenseAmount = expense;
            newTicket.tickStat = currentStatus;

            //user.empTickets.Add(newTicket);

            _service.CreateExpense(newTicket);
            break;
                }
            }
}