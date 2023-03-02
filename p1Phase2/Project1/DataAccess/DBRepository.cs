using Models;
using System.Data.SqlClient;
using Serilog;

namespace DataAccess;
public class DBRepository : IRepository {

    private readonly string _connectString;

    public DBRepository(string connectString){
        _connectString = connectString;
    }

    public List<Employee> GetEveryUser(){

        List<Employee> empList = new();

        using SqlConnection connect = new SqlConnection(_connectString);

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

        try{
            using SqlConnection connect = new SqlConnection(_connectString);
            connect.Open();
            using SqlCommand command = new SqlCommand("INSERT INTO EmployeeTable(EmployeeName, Username, userID, empPassword, EmployeeType) VALUES (@eName, @uName, @uID, @ePwd, @eType)", connect);
            command.Parameters.AddWithValue("@eName", user.empName);
            command.Parameters.AddWithValue("@uName", user.username);
            command.Parameters.AddWithValue("@uID", user.userID);
            command.Parameters.AddWithValue("@ePwd", user.password);
            command.Parameters.AddWithValue("@eType", user.employeeType);
            string userID = (string)command.ExecuteScalar();


            return user;
        }
        catch(SqlException ex) {
            Log.Warning("Error! Couldn't add user because {0}", ex);
            throw;
        }
    }



    public List<ExpenseTicket> GetExpenseTickets(){
        List<ExpenseTicket> ticketList = new();

        using SqlConnection connect = new SqlConnection(_connectString);

        connect.Open();

        using SqlCommand command = new SqlCommand("SELECT * FROM EmployeeTickets", connect);
        using SqlDataReader sdReader = command.ExecuteReader();

        while(sdReader.Read()) {
            ticketList.Add(new ExpenseTicket {
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
        Log.Information("Creating an Expense Ticket in the DB...");

        try{
            using SqlConnection connect = new SqlConnection(_connectString);
            connect.Open();            
            using SqlCommand command = new SqlCommand("INSERT INTO EmployeeTickets(TicketDate, TicketID, userID, ExpenseAmount, ExpenseType, ExpenseDescription, TicketStatus) VALUES (@dateIn, @tickID, @uID, @exAmnt, @exType, @exDesc, @tStat)", connect);
            command.Parameters.AddWithValue("@dateIn", ticket.ticketDate);
            command.Parameters.AddWithValue("@tickID", ticket.ticketID);
            command.Parameters.AddWithValue("@uID", ticket.userID);
            command.Parameters.AddWithValue("@exAmnt", ticket.expenseAmount);
            command.Parameters.AddWithValue("@exType", ticket.ticketType);
            command.Parameters.AddWithValue("@exDesc", ticket.ticketDescription);
            command.Parameters.AddWithValue("@tStat", ticket.tickStat);
            string userID = (string)command.ExecuteScalar();
            return ticket;
        }
        catch(SqlException ex) {
            Log.Warning("Error! Couldn't add ticket because {0}", ex);
            throw;
        }
    }

    public void ManageTickets(int ticketIdIn, Employee manager) {

        try {
            using SqlConnection connect = new SqlConnection(_connectString);
            connect.Open();

            using SqlCommand command1 = new SqlCommand("UPDATE EmployeeTickets SET TicketStatus = @statusIn WHERE TicketID = @tickIDIn", connect);
            using SqlCommand command2 = new SqlCommand("UPDATE EmployeeTickets SET ManagedBy = @manager WHERE TicketID = @tickIDIn", connect);
            while(true){
            Console.WriteLine("[1]: To Approve the Reimbursement Request");
            Console.WriteLine("[2]: To Deny the Reimbursement Request");
            Console.WriteLine("[0]: Exit");
            string choice = Console.ReadLine()!;
            choice = choice.Trim();
            switch(choice) {
                case "0":
                    break;                
                case "1":
                    command1.Parameters.AddWithValue("@statusIn", "Approved");
                    command1.Parameters.AddWithValue("@tickIDIn", ticketIdIn);
                    command2.Parameters.AddWithValue("@manager", manager.empName);
                    command2.Parameters.AddWithValue("@tickIDIn", ticketIdIn);


                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();

                    connect.Close();
                    connect.Close();
                    connect.Close();
                break;
                case "2":
                    command1.Parameters.AddWithValue("@statusIn", "Denied");
                    command1.Parameters.AddWithValue("@tickIDIn", ticketIdIn);
                    command2.Parameters.AddWithValue("@manager", manager.empName);
                    command2.Parameters.AddWithValue("@tickIDIn", ticketIdIn);


                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();

                    connect.Close();
                    connect.Close();
                    connect.Close();
                    break;

                default:
                    Console.WriteLine("Invalid input, please  try again");
                    continue;
                } 
                Console.WriteLine("Exiting...");
                break;           
            }

        }
        catch(SqlException ex){
            Log.Warning("Error! Something went wrong when trying to update ticket: {0}", ex);
            throw;
        }
    }

    public void ManageEmployee(string empIdIn){

        try{
            using SqlConnection connect = new SqlConnection(_connectString);
            connect.Open();

            using SqlCommand command1 = new SqlCommand("UPDATE EmployeeTable SET EmployeeType = @empType WHERE userID = @userIDIn", connect);
            
            
            while(true){
                List<Employee> empList = GetEveryUser();

                for(int i = 0; i < empList.Count; i++){
                    if (!empList[i].userID.Equals(empIdIn) && i == empList.Count - 1){
                        Console.WriteLine("This Employee Does Not Exist");
                        break;
                    }
                    else{
                        Console.WriteLine("[1]: Promote to Manager");
                        Console.WriteLine("[2]: Demote to Employee");
                        Console.WriteLine("[0]: To Exit");
                        string answer = Console.ReadLine()!;
                        answer = answer.Trim();
                        switch(answer){
                            case "0":
                                break;
                            case "1":
                                if(empList[i].employeeType.Equals("Manager") && empList[i].userID.Equals(empIdIn)){Console.WriteLine("Error! {0} is Already a Manager, Cannot be Promoted", empList[i].empName);continue;}
                                command1.Parameters.AddWithValue("@empType", "Manager");
                                command1.Parameters.AddWithValue("@userIdIn", empIdIn);
                                command1.ExecuteScalar();
                                connect.Close();
                                connect.Close();
                                break;
                            case "2":
                                if(empList[i].employeeType.Equals("Employee") && empList[i].userID.Equals(empIdIn)){Console.WriteLine("Error! {0} is Already a Manager, Cannot be Demoted", empList[i].empName);continue;}
                                command1.Parameters.AddWithValue("@empType", "Employee");
                                command1.Parameters.AddWithValue("@userIdIn", empIdIn);
                                command1.ExecuteScalar();
                                connect.Close();
                                connect.Close();
                                break;
                            
                            default:
                                Console.WriteLine("Invalid Input, Please Try Again...");
                                continue;
                        }
                        
                        
                    }
                    break;
                }
                break;
            }
        }
    
        catch(SqlException ex){
            Log.Error("Error! Something Went Wrong During Role Change...{0}", ex);
            throw;
        }
    }
}