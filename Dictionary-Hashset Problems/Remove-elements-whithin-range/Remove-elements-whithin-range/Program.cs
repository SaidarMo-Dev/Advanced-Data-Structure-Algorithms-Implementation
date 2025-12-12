internal class Program
{




	private static void Main(string[] args)
	{

		SortedSet<int> set = [1, 2, 4, 5, 6, 7];

		var range = set.GetViewBetween(4, 6);

		range.Clear();

		Console.WriteLine(string.Join(",", set));
	}
}