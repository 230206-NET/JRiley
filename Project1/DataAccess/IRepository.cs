﻿using Models;
namespace DataAccess;

public interface IRepository
{
    List<Employee> GetEveryUser();

    Employee AddUser(Employee user);

    //List<ExpenseTicket> GetExpenseTickets();

}