internal class Program
{
	private static void Main(string[] args)
	{
		var q = new Queue<int>([1, 2, 3, 5]);

		Console.WriteLine($"The Median of the queue is :{FindMedian(q)}");
	}

	public static int FindMedian(Queue<int> queue)
	{

		var list = new List<int>(queue);

		return list[list.Count / 2];
	}
}