internal class Program
{
	private static void Main(string[] args)
	{
		SortedSet<string> words = new SortedSet<string>
		{
			"Programming",
			"Developer",
			"DevOps",
			"Fron-End",
			"Programming language"
		};

		Console.WriteLine("Enter a prefix...");
		string? userInput = Console.ReadLine();

		if (userInput != null)
		{
			// using built-in function << Where >>
			// var suggestions = words.Where(x => x.StartsWith(userInput, StringComparison.OrdinalIgnoreCase));

			var suggestions = GetSuggestions(words, userInput);

			Console.WriteLine("Soggestions:");
			foreach (var suggestion in suggestions)
			{
				Console.WriteLine(suggestion);
			}
		}
		else Console.WriteLine("Please enter prefix");

		Console.ReadKey();
	}


	private static IEnumerable<string> GetSuggestions(SortedSet<string> words, string prefix)
	{
		foreach (var word in words)
		{
			if (word.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
				yield return word;
		}
	}


}