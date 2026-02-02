Console.Write("Skriv in temperatur i Celsius: ");
string Input = Console.ReadLine();

if (!double.TryParse(Input, out double celsius))
{
		Console.WriteLine("Fel, skriv in temperatur med siffror.");
		return;
}

double fahrenheit = celsius * 9 / 5 + 32;

Console.WriteLine($"{celsius:0.0} °C är {fahrenheit:0.0} °F");

