internal class Program
{
	public static List<string> FindWordsTypedWithOneRow(string[] words)
	{
		string[] rows = { "qwertzuiop", "asdfghjkl", "yxcvbnm" };
		Dictionary<char, int> charRow = new Dictionary<char, int>();

		for (int i = 0; i < rows.Length; i++)
		{
			foreach (char c in rows[i])
			{
				charRow[c] = i;
			}
		}

		List<string> validWords = new();

		foreach (string word in words)
		{
			int row = charRow[char.ToLower(word[0])];
			bool valid = true;

			foreach (char c in word)
			{
				if (charRow[char.ToLower(c)] != row)
				{
					valid = false;
					break;
				}
			}

			if (valid) validWords.Add(word);
		}

		return validWords;
	}

	private static void Main(string[] args)
	{
		string[] words = ["Hello", "Ali", "Power", "Asad"];

		Console.WriteLine($"Words that typed using one row of keyboard are: {string.Join(",", FindWordsTypedWithOneRow(words))}");


		Console.ReadKey();
	}
}