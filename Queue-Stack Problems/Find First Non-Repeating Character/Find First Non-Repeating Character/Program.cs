internal class Program
{
	private static void Main(string[] args)
	{
		Console.ReadKey();
	}
	public static void FindFirstNonRepaetingCharacter(string stream)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();

		foreach (var character in stream)
		{
			if (!dictionary.ContainsKey(character.ToString()))
				dictionary[character.ToString()] = 0;

			dictionary[character.ToString()] += 1;

			if (dictionary[character.ToString()] > 1)
				Console.WriteLine(character);
			else
				Console.WriteLine("-");

		}
	}


}