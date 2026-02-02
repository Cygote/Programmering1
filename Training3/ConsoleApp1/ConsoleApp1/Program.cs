Console.Write("Ange din ålder: ");
string text  = Console.ReadLine();

if (int.TryParse(text, out int ålder))
{
	if (ålder >= 18)
	{
		Console.WriteLine("Du är tillräckligt gammal för att köra bil.");
	}
	else
	{
		int årKvar = 18 - ålder;
		Console.WriteLine("Du behöver vänta " + årKvar + " år för att få köra bil");
	}
}
else
{
	Console.WriteLine("Otillåten inmatning, använd siffror");
}