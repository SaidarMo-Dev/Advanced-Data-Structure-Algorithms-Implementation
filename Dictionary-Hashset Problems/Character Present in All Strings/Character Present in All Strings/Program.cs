internal class Program
{
	public static List<char> CharacterPresentInAllStrings(string[] strings)
	{
		Dictionary<char, int> counts = new Dictionary<char, int>();
		int length = strings.Length;

		foreach (char c in strings[0])
		{
			counts[char.ToLower(c)] = 0;
		}

		foreach (var kvp in counts)
		{
			foreach (string s in strings)
			{
				if (s.ToLower().Contains(kvp.Key)) counts[kvp.Key]++;
			}
		}

		List<char> result = new List<char>();

		foreach (var kvp in counts)
		{
			if (kvp.Value == length) result.Add(kvp.Key);
		}

		return result;
	}

	private static void Main(string[] args)
	{
		string[] strings = { "Hello", "Hfreri", "Maher" };

		Console.WriteLine($"Characters present in all strings: {string.Join(",", CharacterPresentInAllStrings(strings))}");

		Console.ReadKey();
	}
}