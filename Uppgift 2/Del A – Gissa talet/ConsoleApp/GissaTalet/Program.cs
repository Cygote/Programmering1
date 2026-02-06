using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{


		//Random number beween 1-200.
		Random rnd = new Random();
		int secretNumber = rnd.Next(1, 201);

		int maxAttempts = 10;
		int attempts = 0;
		bool correct = false;

		//Save possible numbers in order.
		List<int> guesses = new List<int>();

		Console.WriteLine("Guess the hidden number from 1 - 200");
		Console.WriteLine("You have 10 attempts to find it, good luck!");

		// Invalid Inputs
		while (attempts < maxAttempts && !correct)
		{
			Console.WriteLine();
			Console.Write($"Attempt {attempts + 1} of {maxAttempts} to guess the correct number: ");
			string input = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(input))
			{
				Console.WriteLine("Wrong - You didn't type anything, Type in a number between 1 - 200.");
				continue;
			}

			if (!int.TryParse(input, out int guess))
			{
				Console.WriteLine("Wrong - Type in a number between 1 - 200, try again.");
				continue;
			}

			if (guess < 1 || guess > 200)
			{
				Console.WriteLine("Wrong - The number has to be between 1 - 200, Try again.");
				continue;
			}

			// Here starts the guess loop
			attempts++;
			guesses.Add(guess);

			if (guess < secretNumber)
			{
				Console.WriteLine("Too low, go higher.");
			}
			else if (guess > secretNumber)
			{
				Console.WriteLine("Too high, go lower.");
			}
			else
			{
				correct = true;
				Console.WriteLine($"Correct! You did it in {attempts} attempts");
			}
		}

		if (!correct)
		{
			Console.WriteLine();
			Console.WriteLine("Sorry, you didn't make it this time, try again!");
			Console.WriteLine($"The correct number was {secretNumber}");
		}

		Console.WriteLine();
		Console.WriteLine("STATISTICS:");
		Console.WriteLine($"Nubmer of valid attempts: {guesses.Count}");
		Console.WriteLine("Your guesses in order:");

		for (int i = 0; i < guesses.Count; i++)
		{
			Console.WriteLine($"{i + 1}: {guesses[i]}");
		}

		if (guesses.Count > 0)
		{
			int bestGuess = guesses[0];
			int worstGuess = guesses[0];

			int bestDiff = Math.Abs(bestGuess - secretNumber);
			int worstDiff = Math.Abs(worstGuess - secretNumber);

			foreach (int g in guesses)
			{
				int diff = Math.Abs(g - secretNumber);

				if (diff < bestDiff)
				{
					bestDiff = diff;
					bestGuess = g;
				}
				
				if (diff > worstDiff)
				{
					worstGuess = diff;
					worstGuess = g;
				}
			}

			Console.WriteLine();
			Console.WriteLine($"Your best guess was: {bestGuess} (difference {bestDiff})");
			Console.WriteLine($"Your worst guess was: {worstGuess} (difference {worstDiff})");
		}
	}
}



