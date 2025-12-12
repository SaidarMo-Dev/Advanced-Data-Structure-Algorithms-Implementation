internal class Program
{
	private static void Main(string[] args)
	{
		SortedSet<int> set = [1, 3, 4, 5, 6];

		SortedSet<int> result = set.GetViewBetween(int.MinValue, 3);

		Console.WriteLine(string.Join(",", result));
		Console.ReadKey();
	}
}