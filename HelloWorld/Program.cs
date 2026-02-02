Console.Write("Ange din ålder: ");
int age = int.Parse(Console.ReadLine());

if (age >= 18)
{
	Console.Write("Har du en giltig legitimation? (ja/nej): ");
	string hasId = Console.ReadLine();

	if (hasId.ToLower() == "ja")
	{
		Console.WriteLine("Du får köpa biljetten.");
	}
	else
	{
		Console.WriteLine("Du måste ha en giltig legitimation.");
	}
}
else
{
	Console.WriteLine("Du är för ung för att köpa biljetten.");
}
