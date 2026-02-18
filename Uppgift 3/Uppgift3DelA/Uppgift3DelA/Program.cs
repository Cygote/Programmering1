using System;
using System.Collections.Generic;

class Program
{
	//SKAPA LISTA FÖR POSTER
	static List<RegisterPost> Poster = new List<RegisterPost>();
	static void Main()
	{
		while (true)
		{
			Meny();
			int val = ValAvAnvandare("Välj ett alternativ: ", 0, 4);

			if (val == 0)
			{
				Console.WriteLine("Program avslutas");
				return;
			}

			if (val == 1)
			{
				LaggTill();
			}

			if (val == 2)
			{
				VisaAlla();
			}

			if (val == 3)
			{
				Sok();
			}

			if (val == 4)
			{
				TaBort();
			}

			StopOchTryckEnter();
		}
	}
	
	//MENY ALTERNATIV
	static void Meny()
	{
		Console.Clear();
		Console.WriteLine("-***- Välj ett alternativ -***-");
		Console.WriteLine();
		Console.WriteLine("1. Lägg till");
		Console.WriteLine("2. Visa alla");
		Console.WriteLine("3. Sök");
		Console.WriteLine("4. Ta bort");
		Console.WriteLine("0. Avsluta");
		Console.WriteLine();
	}

	//LÄGG TILL POST
	static void LaggTill()
	{
		Console.WriteLine("\n-***- LÄGG TILL POST -***-");

		string namn = BlankInmatningInteOk("Namn: ");
		string telefonnummer = BlankInmatningInteOk("Telefonnummer: ");

		RegisterPost nyPost = new RegisterPost(namn, telefonnummer);

		Poster.Add(nyPost);

		Console.WriteLine("Posten har lagts till.");
	}
	
	//VISA ALLA POSTER
	static void VisaAlla()
	{
		Console.WriteLine("\n-***- ALLA POSTER -***-");

		if (Poster.Count == 0)
		{
			Console.WriteLine("Registret är tomt.");
			return;
		}
		// VISAR OCH FORMAR RESULTATET I SNYGG LISTA
		Console.WriteLine($"{"Nr",-3} {"Namn",-20} {"Telefon",-15}");
		Console.WriteLine(new string('*', 38));

		for (int i = 0; i < Poster.Count; i++)
		{
			RegisterPost post = Poster[i];
			Console.WriteLine($"{i + 1,-3} {post.Namn,-20} {post.Telefonnummer,-15}");
		}
	}

	//SÖK I REGISTRET
	static void Sok()
	{
		Console.WriteLine("\n-***- SÖK -***-");

		if (Poster.Count == 0)
		{
			Console.WriteLine("Hoppsan, registret är tomt.");
			return;
		}

		string sokText = BlankInmatningInteOk("Sök på namn eller telefon: ");

		int antalTraffar = 0;

		for (int i = 0; i < Poster.Count; i++)
		{
			RegisterPost post = Poster[i];

			bool matcharNamn =
				post.Namn.Contains(sokText, StringComparison.OrdinalIgnoreCase);

			bool matcharTelefon =
				post.Telefonnummer.Contains(sokText, StringComparison.OrdinalIgnoreCase);

			if (matcharNamn || matcharTelefon)
			{
				if (antalTraffar == 0)
				{   // VISAR OCH FORMAR RESULTATET I SNYGG LISTA
					Console.WriteLine("\nTräffar:");
					Console.WriteLine($"{"Nr",-3} {"Namn",-20} {"Telefon",-15}");
					Console.WriteLine(new string('*', 38));
				}

				Console.WriteLine($"{i + 1,-3} {post.Namn,-20} {post.Telefonnummer,-15}");
				antalTraffar++;
			}
		}
	
			if (antalTraffar == 0)
		{
			Console.WriteLine("Inga träffar hittades.");
		}
		else
		{
			Console.WriteLine($"\nAntal träffar: {antalTraffar}");
		}

	}

	//TA BORT POST
	static void TaBort()
	{
		Console.WriteLine("\n-***- TA BORT POST -***-");

		if (Poster.Count == 0)
		{
			Console.WriteLine("Hoppsan, registret är tomt - inget att ta bort.");
			return;
		}

		// VISA LISTA OCH VÄLJ ETT NUMMER
		Console.WriteLine($"{"Nr",-3} {"Namn",-20} {"Telefon",-15}");
		Console.WriteLine(new string('*', 38));

		for (int i = 0; i < Poster.Count; i++)
		{
			RegisterPost post = Poster[i];
			Console.WriteLine($"{i + 1,-3} {post.Namn,-20} {post.Telefonnummer,-15}");
		}

		Console.WriteLine();
		int nummer = ValAvAnvandare("Ange nummer för att ta bort: ", 1, Poster.Count);

		int index = nummer - 1;

		// TA BORT VALD POST
		RegisterPost borttagen = Poster[index];
		Poster.RemoveAt(index);

		Console.WriteLine($"Post borttagen: {borttagen.Namn} ({borttagen.Telefonnummer})");
	}

	//INGEN BLANK INMATNING ÄR GODKÄND
	static string BlankInmatningInteOk(string prompt)
	{
		while (true)
		{
			Console.Write(prompt);
			string? input = Console.ReadLine();

			if (!string.IsNullOrWhiteSpace(input))
				return input.Trim();

			Console.WriteLine("Fel, ogiltig inmatning - du måste skriva något.");
		}
	}

	static int ValAvAnvandare(string prompt, int min, int max)
	{
		while (true)
		{
			Console.Write(prompt);
			string? input = Console.ReadLine();

			if (int.TryParse(input, out int value) && value >= min && value <= max)
				return value;

			Console.WriteLine($"Ogiltigt inmatning - ange ett tal mellan {min} och {max}.");
		}
	}

	static void StopOchTryckEnter()
	{
		Console.WriteLine("\nTryck Enter för att fortsätta");
		Console.ReadLine();
	}
}

class RegisterPost
{
	public string Namn;
	public string Telefonnummer;

	public RegisterPost(string namn, string telefonnummer)
	{
		Namn = namn;
		Telefonnummer = telefonnummer;
	}
}
	



