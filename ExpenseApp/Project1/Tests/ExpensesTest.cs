using Models;



namespace Test;

public class ExpensesTests{

    [Fact]
    public void EmptyExpenseConstructorTest(){
        ExpenseTicket et = new ExpenseTicket();


        Assert.Equal(0, et.ticketID);
        Assert.Equal("",et.userID);
        Assert.Equal(0, et.expenseAmount);
        Assert.Equal("",et.ticketType);
        Assert.Equal("",et.ticketDescription);
        Assert.Equal("", et.tickStat);

    }

    [Fact]
    public void FilledExpenseConstructorTest(){
        
        ExpenseTicket et = new ExpenseTicket(13579,"testUserID",200,"testType","testScript", "testStat");

        Assert.Equal(13579,et.ticketID);
        Assert.Equal("testUserID",et.userID);
        Assert.Equal(200,et.expenseAmount);
        Assert.Equal("testType", et.ticketType);
        Assert.Equal("testScript", et.ticketDescription);
        Assert.Equal("testStat", et.tickStat);
        
    }


}
