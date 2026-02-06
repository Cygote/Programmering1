using System;

using System.Collections.Generic;

using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
	static void Main()
	{

		//Generate 7 random numbers
		Random rnd = new Random();
		List<int> lotteryNumber = new List<int>();
		while (lotteryNumber.Count < 7)
		{
			int Number = rnd.Next(1, 51);
			if (!lotteryNumber.Contains(Number))
			{
				lotteryNumber.Add(Number);
			}
		}
		//User type in numbers
		List<int> userNumber = new List<int>();
		Console.WriteLine("Type in 7 unique numbers between 1 - 50");

		while (userNumber.Count < 7)
		{
			Console.Write($"Number {userNumber.Count + 1}: ");
			string input = Console.ReadLine();

			if (!int.TryParse(input, out int Number))
			{
				Console.WriteLine("Wrong - Type in a number between 1 - 50.");
				Console.WriteLine();
				continue;
			}

			if (Number < 1 || Number > 50)
			{
				Console.WriteLine("Wrong - Number have to be between 1 - 50");
				Console.WriteLine();
				continue;
			}

			if (userNumber.Contains(Number))
			{
				Console.WriteLine("Wrong - Number already used");
				Console.WriteLine();
				continue;
			}

			userNumber.Add(Number);
			Console.WriteLine("Number accepted");
			Console.WriteLine();

		}

		//Sort numbers
		userNumber.Sort();
		lotteryNumber.Sort();

		//Compare lists
		List<int> correctNumber = new List<int>();
		foreach (int Number in userNumber)
		{
			if (lotteryNumber.Contains(Number))
			{
				correctNumber.Add(Number);
			}
		}

		//Results
		Console.WriteLine("Your numbers are registered");
		Console.WriteLine();

		Console.WriteLine($"Your numbers are: {string.Join(", ", userNumber)}");
		Console.WriteLine($"Lottery results: {string.Join(", ", lotteryNumber)}");
		Console.WriteLine();

		Console.WriteLine($"Amount of correct numbers: {correctNumber.Count}");
		if (correctNumber.Count > 0)
			Console.WriteLine($"Correct numbers are: {string.Join(", ",correctNumber)}");
		else
			Console.WriteLine("Correct numbers guessed: None.");
	}
}








