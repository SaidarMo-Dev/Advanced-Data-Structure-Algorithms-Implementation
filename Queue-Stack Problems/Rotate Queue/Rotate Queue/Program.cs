internal class Program
{
	private static void Main(string[] args)
	{
		Queue<int> queue = new Queue<int>([1, 2, 3, 4, 5]);
		int k = 2;

		Console.WriteLine($"Before Rotation by {k}:");
		Console.WriteLine(string.Join(",", queue.ToArray()));


		queue = RotateQueue(queue, k);
		Console.WriteLine($"\nAfter Rotation by {k}:");
		Console.WriteLine(string.Join(",", queue.ToArray()));

	}

	public static Queue<int> RotateQueue(Queue<int> queue, int k)
	{
		for (int i = 0; i < k; i++)
		{
			queue.Enqueue(queue.Dequeue());
		}

		return queue;
	}
}