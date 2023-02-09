// See https://aka.ms/new-console-template for more information


int budgetAmount = 0;
string expenseDesription = "";

StartHere:
Console.WriteLine("Please enter your intial budget amount: ");

budgetAmount = int.Parse(Console.ReadLine()!);




if (budgetAmount <= 0) {
    Console.WriteLine("Error! Budget must be greater than 0.");
    goto StartHere;
}

bool running = true;

void calcExpenses(int expense, string description) {
    Console.WriteLine("You spent $" + expense + " on " + description);
    budgetAmount -= expense;
    expenseDesription = description;
    Console.WriteLine("Now your budget is: $" + budgetAmount);
}

while (running) {
    Console.WriteLine("Would you like to add an expense (y/n): ");

    string response = Console.ReadLine()!;

    if (response == "y") {

        returnHere:
        Console.WriteLine("Please enter an expense amount: ");
        int expenseAmount = int.Parse(Console.ReadLine()!);
        if (expenseAmount <= 0) {
            Console.WriteLine("Error! Expense amount must be greater than 0");
            goto returnHere;
        }
        else {
            Console.WriteLine("Please enter a description for the current expense: ");
            expenseDesription = Console.ReadLine()!;
            calcExpenses(expenseAmount, expenseDesription);
        }
        if(budgetAmount < 0) {
            Console.WriteLine("Woah! You went over the budget :(");
            break;
        }
        
    }
    else {
        running = false;
        if (budgetAmount >= 0) {
            Console.WriteLine("You've mastered \"The Art of the Budget\"");
        }
        else {
            Console.WriteLine("You've failed to budget wisely...");
        }
    }
}
