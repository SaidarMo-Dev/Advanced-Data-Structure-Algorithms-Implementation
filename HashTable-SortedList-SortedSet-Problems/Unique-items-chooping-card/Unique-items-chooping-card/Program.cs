internal class Program
{
	private static void Main(string[] args)
	{
		SortedSet<string> items = new SortedSet<string>
		{
			"Orange",
			"Apple",
			"Orange", // Dublicate won't be added
		};

		Console.WriteLine("Items In Chooping card sorted alphabetical:");
		foreach (string item in items)
		{
			Console.Write(item + " ");
		}

		Console.ReadKey();
	}
}