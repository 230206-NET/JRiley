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
        Assert.Equal("",emp.employeeType);
        Assert.Equal("",emp.userID);

    }

    [Fact]
    public void FilledConstructorTest(){
        
        Employee emp = new Employee("testName","testUsername","testID","testPassword","Employee");

        Assert.Equal("testName",emp.empName);
        Assert.Equal("testUsername",emp.username);
        Assert.Equal("testID",emp.userID);
        Assert.Equal("testPassword", emp.password);
        Assert.Equal("Employee",emp.employeeType);
        
    }

    [Fact]

    public void pickEmpTest(){
        Employee emp = new Employee("testName","testUsername","testID","testPassword","");

        Assert.Equal("", emp.employeeType);

        emp.employeeType = emp.PickEmpType("2");

        Assert.Equal("Manager", emp.employeeType);
    }
}
