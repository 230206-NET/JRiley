using Models;
namespace DataAccess;

public interface IRepository
{
    List<Employee> GetEveryUser();

    Employee AddUser(Employee user);

    List<ExpenseTicket> GetExpenseTickets();

    ExpenseTicket AddExpense(ExpenseTicket ticket);

    void ManageTickets(int ticketID, Employee manager);

    void ManageEmployee(string empID);

}
