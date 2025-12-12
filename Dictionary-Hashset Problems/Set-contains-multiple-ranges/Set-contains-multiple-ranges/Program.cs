internal class Program
{
	public static bool SetContainsMultipleRanges(SortedSet<int> set, List<(int, int)> ranges)
	{
		foreach ((int low, int heigth) in ranges)
		{
			var range = set.GetViewBetween(low, heigth);

			if (range.Count() != heigth - low + 1) return false;

		}

		return true;
	}


	private static void Main(string[] args)
	{
		SortedSet<int> set = [1, 2, 3, 4, 5, 6];

		List<(int, int)> ranges = [(1, 22), (4, 5)];

		Console.WriteLine(SetContainsMultipleRanges(set, ranges));

		Console.ReadKey();

	}
}