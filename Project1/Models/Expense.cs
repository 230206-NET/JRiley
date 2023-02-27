// See https://aka.ms/new-console-template for more information
using System.Text;

namespace Models;

public class ExpenseTicket{

    public double expenseAmount {get;set;}

    public string ticketDescription {get;set;}

    public string tickStat {get;set;}

    public string userID{get;set;}

    public int ticketID {get;set;}

    public DateTime ticketDate {get;set;} = DateTime.Now;

    public ExpenseTicket(){

    }



    public ExpenseTicket(int ticketIdIn, string userIDIn, double expenseAmountIn, string ticketDescriptionIn, string statusIn){
        ticketID = ticketIdIn;
        userID = userIDIn;
        expenseAmount = expenseAmountIn;
        ticketDescription = ticketDescriptionIn;
        tickStat = statusIn;
    }

    public override string ToString(){
        StringBuilder sb = new();
        sb.Append($"Date: {this.ticketDate}");
        sb.Append($"Ticket ID: {this.ticketID}\n");
        sb.Append($"User ID: {this.userID}\nExpense Description: {this.ticketDescription}\nExpense Amount: {this.expenseAmount}\n");
        sb.Append($"Status: {this.tickStat}\n");
        return sb.ToString();
    }

}
