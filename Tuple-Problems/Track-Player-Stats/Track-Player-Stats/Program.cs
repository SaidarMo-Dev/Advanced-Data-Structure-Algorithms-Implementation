internal class Program
{
	public static void DisplayPlayers(List<(string name, int age, int helth)> players)
	{
		foreach (var player in players)
		{
			Console.WriteLine($"Player:{player.name},Age:{player.age}, helth:{player.helth}");
		}
	}
	private static void Main(string[] args)
	{
		List<(string name, int age, int helth)> players = new List<(string name, int age, int helth)>
		{
			("Mohammed", 25, 99),
			("Ali", 32, 85),
			("Ahmed", 22, 45),
			("Sami", 27, 98),
		};


		DisplayPlayers(players);

	}
}