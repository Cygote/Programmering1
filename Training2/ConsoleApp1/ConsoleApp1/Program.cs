Console.WriteLine("Skriv in ett heltal:");
string text = Console.ReadLine();
bool IsNumber = int.TryParse(text, out int tal);
if(!IsNumber)
{
	Console.WriteLine("Otillålig inmatning, måste vara ett heltal");
	return;
}

if (tal > 0)
{

}
else if(tal < 0)
{
	Console.WriteLine("Talet är negativt");
}
else
{
	Console.WriteLine("Talet är noll");
}

