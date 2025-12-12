internal class Program
{
	public static bool SentencePangram(string sentence)
	{

		HashSet<char> chars = new HashSet<char>();

		foreach (char c in sentence)
		{
			if (char.IsLetter(c)) chars.Add(c);
		}

		return chars.Count == 26;
	}

	private static void Main(string[] args)
	{
		string sentence = "The quick brown fox jumps over the lazy d";

		Console.WriteLine(SentencePangram(sentence));
		Console.ReadKey();
	}
}