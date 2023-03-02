using System.Text;

namespace Models;

public class Employee {

    public string empName {get;set;}
    public string username {get;set;}
    public string userID {get;set;}
    public string password {get;set;}
    public string employeeType {get;set;}

    // public List<ExpenseTicket>? empTickets {get;set;}

    // public List<Employee> empList {get;set;}

public Employee (){
    // empList = new List<Employee>();
}
    public Employee(string nameIn, string usernameIn, string userIDIn, string passwordIn, string employeeTypeIn) {
        empName = nameIn;
        username = usernameIn;
        userID = userIDIn;
        password = passwordIn;
        employeeType = employeeTypeIn;
        // empTickets = new List<ExpenseTicket>();
    }




    public string PickEmpType(string typeIn){

        typeIn = typeIn.Trim();
        switch(typeIn) {
            case "1":
                return "Employee";
            case "2":
                return "Manager";
            default:
                return "Invalid employee type";
        }

    }

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append($"Employee Name: {this.empName}\nUsername: {this.username}\nUserID: {this.userID}\n");
        sb.Append($"Job Title: {this.employeeType}");
        return sb.ToString();
    }

}