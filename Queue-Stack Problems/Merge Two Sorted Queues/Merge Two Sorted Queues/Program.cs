internal class Program
{
	private static void Main(string[] args)
	{
		// Queues must be sorted Asn 
		var queue1 = new Queue<int>([1, 4, 5, 6]);
		var queue2 = new Queue<int>([2, 3, 7]);

		var result = MergeQueues(queue1, queue2);
		Console.WriteLine(string.Join(",", result.ToArray()));
	}

	public static Queue<int> MergeQueues(Queue<int> q1, Queue<int> q2)
	{
		var merge = new Queue<int>();

		while (q1.Count > 0 && q2.Count > 0)
		{
			if (q1.Peek() <= q2.Peek())
			{
				merge.Enqueue(q1.Dequeue());
			}
			else
				merge.Enqueue(q2.Dequeue());
		}

		while (q1.Count > 0)
		{
			merge.Enqueue(q1.Dequeue());
		}

		while (q2.Count > 0)
		{
			merge.Enqueue(q2.Dequeue());
		}

		return merge;
	}
}
