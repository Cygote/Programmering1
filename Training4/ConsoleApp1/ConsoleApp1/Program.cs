Console.Write("Skriv in tal 1: ");
string input1 = Console.ReadLine();

if (!int.TryParse(input1, out int tal1))
{
	Console.WriteLine("Fel, skriv in ett heltal.");
	return;
}

Console.Write("Skriv in tal 2: ");
string input2 = Console.ReadLine();

if (!int.TryParse(input2, out int tal2))
{
	Console.WriteLine("Fel, skriv in ett heltal.");
	return;
}

if (tal1 > tal2)
{
	Console.WriteLine("Tal 1 är större än tal 2");
}
else if (tal1 < tal2)
{
	Console.WriteLine("Tal 1 är mindre än tal 2");
}
else
{
	Console.WriteLine("Talen är lika stora");
} 