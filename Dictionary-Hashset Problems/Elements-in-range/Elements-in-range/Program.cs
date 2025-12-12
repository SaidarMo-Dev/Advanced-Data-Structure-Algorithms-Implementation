internal class Program
{
	private static void Main(string[] args)
	{
		SortedSet<int> set = [1, 2, 3, 4, 5, 44, 7];

		int low = 2, high = 5;

		var result = set.GetViewBetween(low, high);

		Console.WriteLine(string.Join(",", result));

		Console.ReadKey();

	}
}