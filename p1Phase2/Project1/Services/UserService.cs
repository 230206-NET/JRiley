// See https://aka.ms/new-console-template for more information

using DataAccess;
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
    public void CreateAccount(Employee newEmp){
        try{
            _iRepo.AddUser(newEmp);
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

    public void CreateExpense(ExpenseTicket newExpense){
        try{
            _iRepo.AddExpense(newExpense);
        }
        catch (Exception) {
            Console.WriteLine("Error, Could Not Create Expense!");
            throw;
        }
    }

    public void showUserTickets(Employee user) {
        try{
            List<ExpenseTicket> availableTickets = getAllTickets();
            for(int i = 0; i < availableTickets.Count; i++){
                if (availableTickets[i].userID.Equals(user.userID)){
                    Console.WriteLine(availableTickets[i]);
                }
            }
        }
        catch(Exception){
            Console.WriteLine("Error, couldn't get user tickets!");
            throw;
        }
    }

    public void showPendingTickets(){
        try{
            int count = 0;
            List<ExpenseTicket> pendingTickets = getAllTickets();
            for(int i = 0; i < pendingTickets.Count; i++){
                if (pendingTickets[i].tickStat.Equals("Pending")){
                    count++;
                    Console.WriteLine(pendingTickets[i]);
                }
            }
            if(count == 0){
                Console.WriteLine("No Pending Tickets!");
            }
        }
        catch(Exception){
            Console.WriteLine("Can't show the pending tickets");
        }
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

    public void manageTickets(int tickID, Employee manager){
        
        for(int i = 0; i < getAllTickets().Count; i++){
            if (tickID == getAllTickets()[i].ticketID){
                Log.Information("Managing Employee Ticket...");
                _iRepo.ManageTickets(tickID, manager);
                break;
            }
            if(i == getAllTickets().Count - 1 && !tickID.Equals(getAllTickets()[i].ticketID)){
                Log.Error("Ticket I.D. Does Not Exist...");
                break;
            }
        }
    }

    public void RoleManager(string empID){
        try{
            for(int i = 0; i < getEmployees().Count; i++){
                if (empID.Equals(getEmployees()[i].userID)){
                    Log.Information("Managing Employee Role...");
                    _iRepo.ManageEmployee(empID);
                    break;
                }
                if(i == getAllTickets().Count - 1 && !empID.Equals(getAllTickets()[i].userID)){
                    Console.WriteLine("User Does Not Exist...");
                }
        }
        }
        catch(Exception ex){
            Log.Error("Something Went Wrong in Role Manager {0}", ex);
            throw;
        }
    }



}
