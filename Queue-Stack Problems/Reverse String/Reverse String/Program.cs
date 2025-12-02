internal class Program
{

	public static string ReverseString(string stream)
	{
		var stack = new Stack<char>();

		foreach (char chr in stream)
		{
			stack.Push(chr);
		}

		string reversedString = "";

		while (stack.Count > 0)
		{

			reversedString += stack.Pop();
		}

		return reversedString;
	}

	private static void Main(string[] args)
	{
		string stream = "Test string";

		var result = ReverseString(stream);

		Console.WriteLine($"Original string is :{stream}");
		Console.WriteLine($"Reversed string:{result}");

		Console.ReadKey();
	}


}