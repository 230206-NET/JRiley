using Models;

namespace UI;

public class EmployeeUI{
    private Employee user {get;set;}

    public EmployeeUI(Employee userIn){
        this.user = userIn;
    }

    public void Begin(){
        Console.WriteLine("Greetings " + user.empName + "!");
        while (true) {
            Console.WriteLine("[1]: View Expense Reimbursement Requests");
            Console.WriteLine("[2]: Make an Expense Reimbursement Request");
            Console.WriteLine("[3]: Edit an Expense Reimbursement Request");
            Console.WriteLine("[0]: To Log Out");

            int choice = int.Parse(Console.ReadLine()!);

            switch(choice){
                case 0:
                    break;
                case 1:
                    DisplayTickets();
                    break;
                case 2:
                    ExpenseMaker();
                    break;
                case 3:
                    Console.WriteLine("Case 3");
                    break;
                default:
                Console.WriteLine("Error, Invalid Option. Please Try Again!");
                break;

            }
            Console.WriteLine("Logging out...");
            break;
        }

    }

    private void DisplayTickets() {
        foreach (ExpenseTicket et in user.empTickets){
            Console.WriteLine(et);
        }
    }

    private void ExpenseMaker() {
        Console.WriteLine("Please Enter the Expense Amount: ");
        double expense = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Please Give a Description of the Expense: ");
        string expenseDescription = Console.ReadLine()!;
        string currentStatus = "Pending";
        
        user.empTickets.Add(new ExpenseTicket(user.userID, expense, expenseDescription, currentStatus));
    }
}