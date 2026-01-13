internal class Program
{
	private static void Main(string[] args)
	{
		List<int> list = new List<int> { 45, 2, 2, 4, 66 };

		SortedSet<int> sortedSet = new SortedSet<int>(list);

		Console.WriteLine("Sorted Unique set :");
		foreach (int i in sortedSet)
		{
			Console.Write(i + " ");
		}

		Console.WriteLine("\nPress any key to continue...");

		Console.ReadKey();
	}

}