Console.WriteLine("Detta är ett program som kan beräkna ditt sparande, tryck enter för att fortsätta.");
Console.ReadLine();
Console.Clear();

//Kod för att lagra data användaren matar in.

Console.Write("Ange ditt namn: ");
string namn = Console.ReadLine();
Console.Clear();

Console.Write("Ange månadsbelopp: ");
if (!double.TryParse(Console.ReadLine(), out double manadsbelopp))
{
	Console.WriteLine("Fel, månadsbelopp måste vara ett tal.");
	return;
}
Console.Clear();

Console.Write("Ange antal månader: ");
if (!int.TryParse(Console.ReadLine(), out int antalManader))
{
	Console.WriteLine("Fel, antal månader måste vara ett heltal");
	return;
}
Console.Clear();

Console.Write("Skriv ränta i procent: ");
if (!double.TryParse(Console.ReadLine(), out double rantaProcent))
{
	Console.WriteLine("Fel - räntan måste vara ett tal.");
	return;
}
Console.Clear();

//Kod för att beräkna inmatad data från användaren.

double totaltInsatt = manadsbelopp * antalManader;
double ranta = rantaProcent / 100;
double totaltMedRanta = totaltInsatt * (1 + ranta);

//Utskrift till användaren

Console.WriteLine();
Console.WriteLine($"{namn}, här är ditt sparande:");
Console.WriteLine($"Totalt insatt belopp: {totaltInsatt:0} kr");
Console.WriteLine($"Totalt belopp inklusive ränta: {totaltMedRanta:0} kr");