using System;

class Program
{
	static void Main()
	{
		var player = new Player(name: "Adventurer", maxHp: 30, attack: 6);
		var rng = new Random();

		Console.WriteLine("Welcome to the dungeons, where many before you never returned.");
		Console.Write("Whats your name: ");
		var inputName = Console.ReadLine();
		if (!string.IsNullOrWhiteSpace(inputName))
			player.Name = inputName.Trim();

		while (player.IsAlive)
		{
			var enemy = Enemy.CreateRandom(rng);
			Console.WriteLine($"\n {enemy.Name} shows up! (HP: {enemy.Hp})");

			bool fled = Fight(player, enemy, rng);

			if (!player.IsAlive)
			{
				Console.WriteLine("\nYou have died. Game over.");
				break;
			}

			if (!fled)
			{
				int gold = rng.Next(3, 9);
				player.Gold += gold;
				Console.WriteLine($"You won! You found {gold} gold. Total gold: {player.Gold}");
			}

			Console.Write("\nContinue adventure? (y/n): ");
			var again = Console.ReadLine()?.Trim().ToLower();
			if (again != "y" && again != "yes")
				break;
		}

		Console.WriteLine("\nThanks for playing!");
	}

	static bool Fight(Player player, Enemy enemy, Random rng)
	{
		while (player.IsAlive && enemy.IsAlive)
		{
			Console.WriteLine($"\n{player.Name} (HP: {player.Hp}/{player.MaxHp}) vs {enemy.Name} (HP: {enemy.Hp})");
			Console.Write("Välj: [1] Attack  [2] Flee: ");
			var choice = Console.ReadLine()?.Trim();

			if (choice == "2")
			{
				// 50% chance to flee
				bool escape = rng.Next(0, 2) == 1;
				if (escape)
				{
					Console.WriteLine("You succsseded to flee!");
					return true;
				}
				Console.WriteLine("You failed to flee!");
			}
			else
			{
				int damage = player.Attack + rng.Next(0, 3); 
				enemy.Hp -= damage;
				Console.WriteLine($"You hit {enemy.Name} for {damage} damage!");
			}

			if (!enemy.IsAlive)
				break;

			int enemyDamage = enemy.Attack + rng.Next(0, 2);
			player.Hp -= enemyDamage;
			Console.WriteLine($"{enemy.Name} attacks and inflict {enemyDamage} damage!");
		}

		return false;
	}
}

class Player
{
	public string Name { get; set; }
	public int MaxHp { get; }
	public int Hp { get; set; }
	public int Attack { get; }
	public int Gold { get; set; }

	public bool IsAlive => Hp > 0;

	public Player(string name, int maxHp, int attack)
	{
		Name = name;
		MaxHp = maxHp;
		Hp = maxHp;
		Attack = attack;
	}
}

class Enemy
{
	public string Name { get; }
	public int Hp { get; set; }
	public int Attack { get; }

	public bool IsAlive => Hp > 0;

	public Enemy(string name, int hp, int attack)
	{
		Name = name;
		Hp = hp;
		Attack = attack;
	}

	public static Enemy CreateRandom(Random rng)
	{
		int roll = rng.Next(0, 3);
		return roll switch
		{
			0 => new Enemy("Rat", hp: 10, attack: 3),
			1 => new Enemy("Bandit", hp: 16, attack: 4),
			_ => new Enemy("Slime", hp: 12, attack: 2)
		};
	}
}
