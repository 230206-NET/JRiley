// See https://aka.ms/new-console-template for more information


namespace FirstDotNet;

public class firstDotNet{
	public firstDotNet() {
		Console.WriteLine("Starting program...");
		Console.WriteLine("Please enter any number: ");
		//Reading from the terminal
		int userInput = int.Parse(Console.ReadLine()!);

		Console.WriteLine(userInput);

		if (5 > userInput) {
			
			Console.WriteLine("Five is greater than! " + userInput );
		}

		if (userInput > 5) {
			
			Console.WriteLine(userInput + " is greater than 5!");
		}



		Console.WriteLine("Ending Program");
	}
}