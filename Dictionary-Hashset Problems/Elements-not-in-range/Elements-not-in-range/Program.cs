internal class Program
{
	public static IEnumerable<int> ElementsOutsideRange(SortedSet<int> set, int low, int height)
	{
		var range = set.GetViewBetween(low, height);

		SortedSet<int> result = new SortedSet<int>(set);

		result.ExceptWith(range);

		return result;
	}

	private static void Main(string[] args)
	{
		SortedSet<int> set = [1, 2, 3, 4, 5, 6];

		var result = ElementsOutsideRange(set, 2, 4);


		Console.WriteLine($"Elements Outside the range :{string.Join(",", result)}");

		Console.ReadKey();
	}
}