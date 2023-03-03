// See https://aka.ms/new-console-template for more information

using DataAccess;
using System;
using Models;
using Serilog;

namespace Services;

public class UserService {
    private readonly IRepository _iRepo;

    public UserService(IRepository iRepo){
        _iRepo = iRepo;
    }

    public List<Employee> getEmployees(){
        return _iRepo.GetEveryUser();
    }

        public List<ExpenseTicket> getAllTickets(){
        return _iRepo.GetExpenseTickets();
    }

public bool usernameChecker(string uName){
    List<Employee> empList = getEmployees();
    foreach (Employee emp in empList){
        if(uName.Equals(emp.username)){
            Console.WriteLine("Error, Account creation failed This username has already been taken");
            return false;
        }
    }
    return true;
}
    public Employee CreateAccount(Employee newEmp){
        try{
            return _iRepo.AddUser(newEmp);
        }
        catch (Exception) {
            
            Console.WriteLine("Error, Could Not Create Account!");
            throw;
        }
    }

    public Employee VerifyUser(string usernameIn, string passwordIn) {

        List<Employee> userList = getEmployees();
        for(int i = 0; i < userList.Count; i++){
            if (userList[i].username.Equals(usernameIn) && userList[i].password.Equals(passwordIn)){
                return userList[i];
            }
        }
        return null;
        
    }

    public ExpenseTicket CreateExpense(ExpenseTicket newExpense){
        try{
            return _iRepo.AddExpense(newExpense);
        }
        catch (Exception) {
            Console.WriteLine("Error, Could Not Create Expense!");
            throw;
        }
    }

    public List<ExpenseTicket> showUserTickets(string uID) {
        try{
            List<ExpenseTicket> availableTickets = getAllTickets();
            List<ExpenseTicket> newList = new();
            for(int i = 0; i < availableTickets.Count; i++){
                if (availableTickets[i].userID.Equals(uID)){
                    newList.Add(availableTickets[i]);
                }
            }
            return newList;
        }
        catch(Exception){
            Console.WriteLine("Error, couldn't get user tickets!");
            throw;
        }
    }

    public List<ExpenseTicket> showPendingTickets(string empID){
        try{
            List<ExpenseTicket> tickList = new();
            for(int i = 0; i < getAllTickets().Count; i++){
                if(getAllTickets()[i].tickStat.Equals("Pending") && getAllTickets()[i].userID.Equals(empID)){
                    tickList.Add(getAllTickets()[i]);
                }
            }
            return tickList;
        }
        catch(Exception){
            Console.WriteLine("Can't show the pending tickets");
        }
        return null;
    }


    public void showManagedTickets(){
        try{
            List<ExpenseTicket> managedTickets = getAllTickets();
            foreach(ExpenseTicket et in managedTickets){
                if (!et.tickStat.Equals("Pending")){
                    Console.WriteLine(et);
                }
            }
        }
        catch(Exception ex){
            Log.Error("There was an error when trying to show Managed Tickets {0}", ex);
            throw;
        }
    }

    public int generateTicketID(){
        Random rand = new Random();
        int id = rand.Next(1000, 9999);
        List<ExpenseTicket> ticket = getAllTickets();
        foreach(ExpenseTicket et in ticket){
            if (id == et.ticketID){
                return id + 1;
            }
        }
        return id;
    }

    public ExpenseTicket AcceptTickets(int tickID, string managerID){
        
        for(int i = 0; i < getAllTickets().Count; i++){
            if (tickID == getAllTickets()[i].ticketID){
                Log.Information("Managing Employee Ticket...");
                return _iRepo.AcceptTickets(tickID, managerID);
                
            }
            if(i == getAllTickets().Count - 1 && !tickID.Equals(getAllTickets()[i].ticketID)){
                Log.Error("Ticket I.D. Does Not Exist...");
                break;
            }
        }
        return null;
    }

    public ExpenseTicket DenyTickets(int tickID, string managerID){
        
        for(int i = 0; i < getAllTickets().Count; i++){
            if (tickID == getAllTickets()[i].ticketID){
                Log.Information("Managing Employee Ticket...");
                return _iRepo.DenyTickets(tickID, managerID);
                
            }
            if(i == getAllTickets().Count - 1 && !tickID.Equals(getAllTickets()[i].ticketID)){
                Log.Error("Ticket I.D. Does Not Exist...");
                break;
            }
        }
        return null;
    }

    // public void RoleManager(string empID){
    //     try{
    //         for(int i = 0; i < getEmployees().Count; i++){
    //             if (empID.Equals(getEmployees()[i].userID)){
    //                 Log.Information("Managing Employee Role...");
    //                 _iRepo.ManageEmployee(empID);
    //                 break;
    //             }
    //             if(i == getAllTickets().Count - 1 && !empID.Equals(getAllTickets()[i].userID)){
    //                 Console.WriteLine("User Does Not Exist...");
    //             }
    //     }
    //     }
    //     catch(Exception ex){
    //         Log.Error("Something Went Wrong in Role Manager {0}", ex);
    //         throw;
    //     }
    // }

    public Employee PromoteEmployee(string empIdIn){
        return _iRepo.PromoteEmployee(empIdIn);
    }

    
    public Employee DemoteEmployee(string empIdIn){
        return _iRepo.DemoteEmployee(empIdIn);
    }

    public static class passwordHider{
        public static string keyStrokes(){
            var pwd = string.Empty;
            ConsoleKey keys;

            do {
                var keyStroke = Console.ReadKey(intercept: true);
                keys = keyStroke.Key;

                if (keys == ConsoleKey.Backspace && pwd.Length > 0){
                    Console.Write("\b \b");
                    pwd = pwd[0..^1];
                }
                else if (!char.IsControl(keyStroke.KeyChar)){
                    Console.Write("*");
                    pwd += keyStroke.KeyChar;
                }
            }
            while(keys != ConsoleKey.Enter);
                return pwd;
            }   
        }
    }



