using System.ComponentModel.Design;

Console.WriteLine("Vad är din ålder?");
string input = Console.ReadLine();
int age;

try
{
	age = int.Parse(input);

}
catch
{
	Console.WriteLine("Du måste skriva ett heltal, t.ex 18.");
	return; // Avsluta programmet.
}

if(age < 18)
{
	Console.WriteLine("Du är för ung för att köpa biljett.");
	return; 
}

Console.WriteLine("Har du giltig legitimation? ja/nej");
string hasID  = Console.ReadLine();

if (hasID.ToLower() == "ja")
{
	Console.WriteLine("Du får köpa biljetten.");
}
else
{
	Console.WriteLine("Du får inte köpa biljetten utan legitimation");
}
