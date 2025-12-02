internal class Program
{
	private static void Main(string[] args)
	{
		string s = "Hello, my name is mohammed saidar";

		Console.WriteLine(IsPalindrome(s));

		Console.ReadKey();
	}

	public static bool IsPalindrome(string s)
	{
		Stack<char> stack = new(s);

		foreach (char c in s)
		{
			if (c != stack.Pop()) return false;
		}

		return true;

	}
}