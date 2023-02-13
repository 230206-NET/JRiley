using System;

namespace HotOrCold
{
	public class HOC 
	{
	
		public HOC() 
		{
			Console.WriteLine("Hello, World!");
			
			var rand = new Random();
			
			int target = rand.Next(21); 
			
			
			//Console.WriteLine(target);
			
			
			bool loop = true;
			while (loop)
			{
				Console.WriteLine("Please guess a number between 0 and 20: ");
			
				int guess = Int32.Parse(Console.ReadLine());
			
				if (guess == target) 
				{
					Console.WriteLine("Congratulations, you guessed it!");
					loop = false;
				}
				else if (guess > target) 
				{
					Console.WriteLine("OOPS! That was too high!");
				}
				else 
				{
					Console.WriteLine("Oh no! Too low!");
				}
			}
		}
	}
}
