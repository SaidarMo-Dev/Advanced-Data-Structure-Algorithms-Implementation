class Coin
{
	public int Amount { get; set; }
	public List<int>? Coins { get; set; }

	public Coin(int amount, List<int> coins)
	{
		Amount = amount;
		Coins = coins;
	}

	public List<int> Discount()
	{
		// Return if there is no coins to change
		if (Coins == null) return new List<int>();

		// Sort the list Desn
		Coins.Sort((a, b) => b - a);

		// A list to store the result
		List<int> result = new List<int>();

		foreach (var coin in Coins)
		{
			while (Amount >= coin)
			{
				Amount -= coin;
				result.Add(coin);
			}
		}


		return result;
	}


	public static void Main()
	{
		// Define list of coins to change
		var coins = new List<int> { 1, 5, 10, 20, 50, 100 };
		var coin = new Coin(33, coins);

		// Call Discount method
		var result = coin.Discount();


		// Print the result
		Console.WriteLine("Coins to change :");

		foreach (int item in result)
		{
			Console.WriteLine(item);
		}

		Console.WriteLine($"Total coins: {result.Count}");

		Console.ReadKey();
	}
}