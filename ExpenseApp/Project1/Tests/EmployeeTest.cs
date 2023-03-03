// See https://aka.ms/new-console-template for more information
using Models;



namespace Test;

public class EmpTests{

    [Fact]

    public void EmptyConstructorTest(){
        Employee emp = new Employee();

        Assert.Equal("",emp.empName);
        Assert.Equal("",emp.username);
        Assert.Equal("", emp.password);
        Assert.Equal("Employee",emp.employeeType);
        Assert.Equal("",emp.userID);

    }
}
