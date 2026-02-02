using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		Random rnd = new Random();

		// Tal 1 slumpas direkt (1-9)
		int tal1 = rnd.Next(1, 10);
        int tal2 = 0;

		int forsokTal1 = 5;
		int forsokTal2 = 5;

		// Sparar alla felaktiga gissningar från tal 1
		List<int> felGissningarTal1 = new List<int>();

		Console.WriteLine("Jag har valt två olika heltal mellan 1-9.");
		Console.WriteLine("Samma tal kan inte förekomma flera gånger.");
		Console.WriteLine();
		Console.WriteLine("Du har 5 försök på tal 1.");
		Console.WriteLine("Du har 5 försök på tal 2.");
		Console.WriteLine();

		// -------------------------
		// Gissa tal 1
		// -------------------------
		bool tal1Ratt = false;

		while (forsokTal1 > 0 && !tal1Ratt)
		{
			Console.Write("Gissa tal 1: ");
			string input = Console.ReadLine();

			if (!int.TryParse(input, out int gissning))
			{
				forsokTal1--;
				Console.WriteLine($"Fel inmatning - skriv ett heltal. Försök kvar: {forsokTal1}");
				continue;
			}

			if (gissning < 1 || gissning > 9)
			{
				forsokTal1--;
				Console.WriteLine($"Fel - talet måste vara mellan 1-9. Försök kvar: {forsokTal1}");
				continue;
			}

			if (gissning == tal1)
			{
				tal1Ratt = true;
				Console.WriteLine("Rätt! Du klarade tal 1.");
			}
			else
			{
				// Spara fel gissning
				if (!felGissningarTal1.Contains(gissning))
					felGissningarTal1.Add(gissning);

				forsokTal1--;
				Console.WriteLine($"Fel! Försök kvar: {forsokTal1}");
			}
		}

		if (!tal1Ratt)
		{
			Console.WriteLine();
			Console.WriteLine($"Spelet är slut. Tal 1 var {tal1}.");
			return;
		}

		// -------------------------
		// Skapa tal 2 EFTER tal 1
		// Tal 2 får inte vara:
		// - samma som tal 1
		// - något av de fel-gissade talen i tal 1
		// -------------------------
		HashSet<int> ejTillatnaForTal2 = new HashSet<int>(felGissningarTal1);
		ejTillatnaForTal2.Add(tal1);

		do
		{
			tal2 = rnd.Next(1, 10);
		} while (ejTillatnaForTal2.Contains(tal2));

		Console.WriteLine();
		Console.WriteLine("Nu ska du gissa tal 2.");
		Console.WriteLine();

		// -------------------------
		// Gissa tal 2
		// -------------------------
		bool tal2Ratt = false;

		while (forsokTal2 > 0 && !tal2Ratt)
		{
			Console.Write("Gissa tal 2: ");
			string input = Console.ReadLine();

			if (!int.TryParse(input, out int gissning))
			{
				forsokTal2--;
				Console.WriteLine($"Fel inmatning - skriv ett heltal. Försök kvar: {forsokTal2}");
				continue;
			}

			if (gissning < 1 || gissning > 9)
			{
				forsokTal2--;
				Console.WriteLine($"Fel - talet måste vara mellan 1-9. Försök kvar: {forsokTal2}");
				continue;
			}

			// Om spelaren försöker gissa ett tal som redan var fel i tal 1,
			// så ska de slippa behöva gissa på dem i tal 2 igen.
			// Vi låter dem gissa om utan att förbruka försök.
			if (felGissningarTal1.Contains(gissning))
			{
				Console.WriteLine("Du har redan gissat det talet fel i tal 1 - välj ett annat tal.");
				continue; // drar inget försök
			}

			// Om spelaren gissar tal 1 igen (som redan är känt) - låt dem gissa om.
			if (gissning == tal1)
			{
				Console.WriteLine("Tal 2 kan inte vara samma som tal 1 - välj ett annat tal.");
				continue; // drar inget försök
			}

			if (gissning == tal2)
			{
				tal2Ratt = true;

				// Rensa rutan och visa de rätta talen + instruktion att addera
				Console.WriteLine();
				Console.WriteLine("Du gissade båda talen rätt!");
				Console.WriteLine($"Rätt svar var: {tal1} och {tal2}");
				Console.WriteLine();
				Console.WriteLine("Tryck Enter för att fortsätta...");
				Console.ReadLine();
				Console.Clear();
			}
			else
			{
				forsokTal2--;
				Console.WriteLine($"Fel! Försök kvar: {forsokTal2}");
			}
		}

		if (!tal2Ratt)
		{
			Console.WriteLine();
			Console.WriteLine($"Spelet är slut. Tal 2 var {tal2}.");
			return;
		}

		// -------------------------
		// DEL 3 - Summa
		// -------------------------
		int summa = tal1 + tal2;

		Console.WriteLine();
		Console.WriteLine($"Hur mycket är {tal1} + {tal2}?");
		Console.WriteLine();
		Console.Write("Svar: ");
		string inputSumma = Console.ReadLine();

		if (!int.TryParse(inputSumma, out int gissadSumma))
		{
			Console.WriteLine("Fel inmatning - du måste skriva ett heltal. Spelet avslutas.");
			return;
		}

		if (gissadSumma == summa)
		{
			Console.WriteLine("Bra! Du klarade det. =)");
		}
		else
		{
			Console.WriteLine($"Tyvärr, fel summa. Rätt svar var {summa}. Spelet avslutas.");
		}
	}
}
