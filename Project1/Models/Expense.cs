// See https://aka.ms/new-console-template for more information
using System.Text;

namespace Models;

public class ExpenseTicket{

    public double expenseAmount {get;set;}

    // public int ticketNumber {get;set;}

    public string ticketDescription {get;set;}

    public string tickStat {get;set;}

    public string userID{get;set;}

    public ExpenseTicket(string userIDIn, double expenseAmountIn, string ticketDescriptionIn, string statusIn){
        userID = userIDIn;
        expenseAmount = expenseAmountIn;
        ticketDescription = ticketDescriptionIn;
        tickStat = statusIn;
    }



    // public enum ticketStatus {
    //     Pending,
    //     Accepted,
    //     Denied
    // }

    // public void createExpense() {
    //     while(true) {
    //     Expenses newExpense = new Expenses();

    //     Console.WriteLine("Would you like to record an expense to be reimbursed [yes/no]?");
    //     string response = Console.ReadLine();
    //     response = response.ToLower();
    //     if (response.Equals("no")){
    //         break;
    //     }
    //     else if (response.Equals("yes")) {
    //     Random rand = new Random();
    //     Console.WriteLine("Please Enter an Expense: ");
    //     newExpense.expenseAmount = double.Parse(Console.ReadLine());
    //     Console.WriteLine("Please Enter a description for you expense: ");
    //     newExpense.ticketDescription = Console.ReadLine();
    //     newExpense.ticketNumber = rand.Next(1, 10000000);
    //     expenseList.Add(newExpense);
    //     //Console.WriteLine("ExpenseAmount: {0}\nTicket Description: {1}\nTicket Number: {2}", newExpense.expenseAmount, newExpense.ticketDescription, newExpense.ticketNumber);
    //     }
    // }
    //     Console.WriteLine(expenseList.Count);
    //     printList();
    // }
    
    // public void printList(){
    //     foreach(Expenses e in expenseList){
    //         Console.WriteLine(e + "\n");
    //     }
    // }
    // public override string ToString(){
    //     StringBuilder sb = new();
    //     sb.Append($"Expense: {this.expenseAmount}\nTicket Description: {this.ticketDescription}\nTicket Number: {this.ticketNumber}");
    //     foreach(Expenses e in expenseList){
    //         sb.Append("\n");
    //         sb.Append(e.ToString());
    //     }
    //     return sb.ToString();
    // }

}
