using Models;
// using Services;


namespace UI;
using System.Net.Http;
using System.Net.Http.Json;

public class EmployeeUI{
    private Employee user {get;set;}
    private HttpClient _http;

    


    public EmployeeUI(Employee userIn, HttpClient httpIn) {
        _http = httpIn;
        user = userIn;
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

            string choice = Console.ReadLine()!;
            choice = choice.Trim();

            switch(choice){
                case "1":
                    DisplayTickets();
                    continue;
                case "2":
                    ExpenseMaker();
                    continue;
                case "3":
                    break;
                default:
                    Console.WriteLine("Error, Invalid Option. Please Try Again!");
                break;

            }
            Console.WriteLine("Logging out...\n");
            break;
        }

    }

    private void DisplayTickets() {
        string uID = user.userID;
        // _service.showUserTickets(uID);
    }

    private void ExpenseMaker() {
        while(true) {
            Console.Write("Please Enter the Expense Amount: $");
            float expense = float.Parse(Console.ReadLine()!);
            Console.Write("What Kind of Expense is it [ex. Plane Ticket]?: ");
            string tickType = Console.ReadLine()!;
            Console.WriteLine("Please Give a Description of the Expense: ");
            string expenseDescription = Console.ReadLine()!;
            string currentStatus = "Pending";
            ExpenseTicket newTicket = new ExpenseTicket();

            // newTicket.ticketID = _service.generateTicketID();
            newTicket.userID = user.userID;
            newTicket.ticketType = tickType;
            newTicket.ticketDescription = expenseDescription;
            newTicket.expenseAmount = expense;
            newTicket.tickStat = currentStatus;


            // _service.CreateExpense(newTicket);
            break;
                }
            }
}