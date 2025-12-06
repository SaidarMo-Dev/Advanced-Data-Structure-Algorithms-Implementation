internal class Program
{
	public static Dictionary<string, int> CountWordFrequencies(string text)
	{
		Dictionary<string, int> frequencies = new Dictionary<string, int>();

		string[] words = text.Split(" ");

		foreach (string word in words)
		{
			if (!frequencies.ContainsKey(word)) frequencies[word] = 1;
			else frequencies[word]++;
		}

		return frequencies;
	}

	private static void Main(string[] args)
	{
		string text = "hello my name is mohammed mohammed hello name";

		Dictionary<string, int> result = CountWordFrequencies(text);

		foreach (var (key, value) in result)
		{
			Console.WriteLine($"{key}:{value}");
		}

		Console.ReadKey();
	}
}