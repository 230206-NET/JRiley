// See https://aka.ms/new-console-template for more information
using FirstDotNet;
using RockPaperScissors;
using CoinFlipper;
using BudgetApp;
using HotOrCold;
using Hangman;

Console.WriteLine("Welcome to the Main Menu Application");

Console.WriteLine("\nPlease Select a program using its respective number: ");

while(true) {
    Console.WriteLine("\n[1] FirsDotNet");
    Console.WriteLine("[2] CoinFlipper");
    Console.WriteLine("[3] BudgetApp");
    Console.WriteLine("[4] HotOrCold");
    Console.WriteLine("[5] Hangman");
    Console.WriteLine("[6] RockPaperScissors");
    Console.WriteLine("[0] Exit");
    int selection = int.Parse(Console.ReadLine()!);


    switch (selection)
    {
        case 0:
            break;
        case 1:
            new firstDotNet();
            break;
        case 2:
            new Flipper();
            break;
        case 3: 
            new StartBudgetApp();
            break;
        case 4:
            new HOC();
            break;
        case 5:
            new HangmanGame();
            break;
        case 6:
            new RockPaperGame();
            break;
        default:
        Console.WriteLine("Invalid Entry...");
        break;
    }
    if (selection == 0) {
        Console.WriteLine("Exiting the program...");
        break;
    }
}
