// See https://aka.ms/new-console-template for more information

using DataAccess;
using Models;

namespace Services;

public class UserService {
    private readonly IRepository _iRepo;

    public UserService(IRepository iRepo){
        _iRepo = iRepo;
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

        List<Employee> userList = _iRepo.GetEveryUser();

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
            List<ExpenseTicket> availableTickets = _iRepo.GetExpenseTickets();
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
            List<ExpenseTicket> pendingTickets = _iRepo.GetExpenseTickets();
            foreach(ExpenseTicket et in pendingTickets){
                if (et.tickStat.Equals("Pending")){
                    Console.WriteLine(et);
                }
            }
        }
        catch(Exception){
            Console.WriteLine("Can't show the pending tickets");
        }
    }

    public int generateTicketID(){
        Random rand = new Random();
        int id = rand.Next(1000, 9999);

        List<ExpenseTicket> ticket = _iRepo.GetExpenseTickets();

        foreach(ExpenseTicket et in ticket){
            if (id == et.ticketID){
                return id + 1;
            }
        }
        return id;
    }

    public void manageTickets(int tickID){

        for(int i = 0; i < _iRepo.GetExpenseTickets().Count; i++){
            if (tickID == _iRepo.GetExpenseTickets()[i].ticketID){
                Console.WriteLine("[1]: To Approve the Reimbursement Request");
                Console.WriteLine("[2]: To Deny the Reimbursement Request");
                Console.WriteLine("[3]: Exit");
                int choice = int.Parse(Console.ReadLine());
                switch(choice){
                    case 1:
                        _iRepo.GetExpenseTickets()[i].tickStat = "Approved";
                        break;
                    case 2:
                        _iRepo.GetExpenseTickets()[i].tickStat = "Denied";
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
            else{
                Console.WriteLine("Error, This Ticket I.D. Does Not Exist");
                break;
            }
        }
    }

}
