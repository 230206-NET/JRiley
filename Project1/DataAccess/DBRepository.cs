using Models;
using System.Data.SqlClient;
using Serilog;

namespace DataAccess;
public class DBRepository : IRepository {

    public List<Employee> GetEveryUser(){

        List<Employee> empList = new();

        using SqlConnection connect = new SqlConnection(Secrets.getConnectionString());

        connect.Open();

        using SqlCommand command = new SqlCommand("SELECT * FROM EmployeeTable", connect);
        using SqlDataReader sdReader = command.ExecuteReader();

        while(sdReader.Read()) {
            empList.Add(new Employee {
                empName = (string) sdReader["EmployeeName"],
                username = (string) sdReader["Username"],
                userID = (string) sdReader["userID"],
                password = (string) sdReader["empPassword"],
                employeeType = (string) sdReader["EmployeeType"]
            });
        }
        return empList;
    }

    public Employee AddUser(Employee user){
        Log.Information("Creating a user in the DB...");

        using SqlConnection connect = new SqlConnection(Secrets.getConnectionString());
        connect.Open();

        try{
            using SqlCommand command = new SqlCommand("INSERT INTO EmployeeTable(EmployeeName, Username, userID, empPassword, EmployeeType) VALUES (@eName, @uName, @uID, @ePwd, @eType)", connect);
            command.Parameters.AddWithValue("@eName", user.empName);
            command.Parameters.AddWithValue("@uName", user.username);
            command.Parameters.AddWithValue("@uID", user.userID);
            command.Parameters.AddWithValue("@ePwd", user.password);
            command.Parameters.AddWithValue("@eType", user.employeeType);

            return user;
        }
        catch(SqlException ex) {
            Log.Warning("Error! Couldn't add user because {0}", ex);
            throw;
        }
    }



    public List<ExpenseTicket> GetExpenseTickets(){
        List<ExpenseTicket> ticketList = new();

        using SqlConnection connect = new SqlConnection(Secrets.getConnectionString());

        connect.Open();

        using SqlCommand command = new SqlCommand("SELECT * FROM EmployeeTickets", connect);
        using SqlDataReader sdReader = command.ExecuteReader();

        while(sdReader.Read()) {
            ticketList.Add(new ExpenseTicket {
                // ticketDate = (DateTime) sdReader["Date"],
                ticketID = (int) sdReader["TicketID"],
                userID = (string) sdReader["userID"],
                expenseAmount = (float)(double) sdReader["ExpenseAmount"],
                ticketType = (string) sdReader["ExpenseType"],
                ticketDescription = (string) sdReader["ExpenseDescription"],
                tickStat = (string) sdReader["TicketStatus"]
            });
        }
        return ticketList;
    }

    public ExpenseTicket AddExpense(ExpenseTicket ticket){
        using SqlConnection connect = new SqlConnection(Secrets.getConnectionString());
        connect.Open();

        try{
            using SqlCommand command = new SqlCommand("INSERT INTO EmployeeTicket(TicketID, userID, ExpenseAmount, ExpenseType, ExpenseDescription, TicketStatus) VALUES (@tickID, @uID, @exAmnt, @exType, @exDesc, @tStat)", connect);
            // command.Parameters.AddWithValue("@dateIn", ticket.ticketDate);
            command.Parameters.AddWithValue("@tickID", ticket.ticketID);
            command.Parameters.AddWithValue("@uID", ticket.userID);
            command.Parameters.AddWithValue("@exAmnt", ticket.expenseAmount);
            command.Parameters.AddWithValue("@exType", ticket.ticketType);
            command.Parameters.AddWithValue("@exDesc", ticket.ticketDescription);
            command.Parameters.AddWithValue("@tStat", ticket.tickStat);

            return ticket;
        }
        catch(SqlException ex) {
            Log.Warning("Error! Couldn't add ticket because {0}", ex);
            throw;
        }
    }

    public void ApproveTickets(int ticketIdIn) {

        using SqlConnection connect = new SqlConnection(Secrets.getConnectionString());
        connect.Open();

        try {
            using SqlCommand command = new SqlCommand("UPDATE EmployeeTicket SET TicketStatus = 'Approved' WHERE TicketID = ticketIdIn");
        }
        catch(SqlException){
            Log.Warning("Error! Something went wrong when trying to update ticket");
        }
    }
}