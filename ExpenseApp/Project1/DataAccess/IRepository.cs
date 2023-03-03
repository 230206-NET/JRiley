using Models;
namespace DataAccess;

public interface IRepository
{
    List<Employee> GetEveryUser();

    Employee AddUser(Employee user);

    List<ExpenseTicket> GetExpenseTickets();

    ExpenseTicket AddExpense(ExpenseTicket ticket);

    ExpenseTicket AcceptTickets(int ticketID, string managerID);

    ExpenseTicket DenyTickets(int ticketID, string managerID);

    Employee PromoteEmployee(string empID);

    Employee DemoteEmployee(string empID);

}
