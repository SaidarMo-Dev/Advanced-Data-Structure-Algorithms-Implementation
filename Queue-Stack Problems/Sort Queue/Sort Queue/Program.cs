internal class Program
{
	private static void Main(string[] args)
	{
		Queue<int> queue = new Queue<int>([1, 3, 2, 5, 4]);

		queue = SortQueue(queue);
		Console.WriteLine("After sorting the queue:");

		foreach (int i in queue)
		{
			Console.WriteLine(i);
		}
	}

	public static Queue<int> SortQueue(Queue<int> queue)
	{
		var list = new List<int>(queue);

		list.Sort((a, b) => a - b);

		return new(list);
	}
}