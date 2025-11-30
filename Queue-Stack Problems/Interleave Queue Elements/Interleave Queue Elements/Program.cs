internal class Program
{
	private static void Main(string[] args)
	{

		Queue<int> queue = new Queue<int>([1, 2, 3, 4, 5, 6, 72, 23, 31]);

		Console.WriteLine("After interleave elements:");
		queue = InterleaveElements(queue);
		Console.WriteLine(string.Join(",", queue.ToArray()));
		Console.ReadKey();
	}

	public static Queue<int> InterleaveElements(Queue<int> queue)
	{
		var halfQueue = new Queue<int>();

		int halfSize = queue.Count / 2;

		for (int i = 0; i < halfSize; i++)
		{
			halfQueue.Enqueue(queue.Dequeue());
		}

		for (int i = 0; i < halfSize; i++)
		{
			queue.Enqueue(halfQueue.Dequeue());
			queue.Enqueue(queue.Dequeue());
		}


		return queue;
	}
}