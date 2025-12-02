internal class Program
{
	private static void Main(string[] args)
	{
		var q = new Queue<int>([1, 2, 3, 4, 5]);

		var clonedqueue = CloneQueue(q);

		var qLength = q.Count;

		Console.WriteLine($"Origin queue Elements: {string.Join(",", q)} ");
		Console.WriteLine($"cloned queue Elements: {string.Join(",", clonedqueue)}");

		Console.ReadKey();
	}

	public static Queue<int> CloneQueue(Queue<int> queue)
	{
		var clonedQueue = new Queue<int>();

		var length = queue.Count;

		for (int i = 0; i < length; i++)
		{
			var front = queue.Dequeue();

			clonedQueue.Enqueue(front);

			queue.Enqueue(front);
		}

		return clonedQueue;
	}

}