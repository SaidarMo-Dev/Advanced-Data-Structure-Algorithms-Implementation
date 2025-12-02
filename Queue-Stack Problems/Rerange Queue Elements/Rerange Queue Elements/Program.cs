internal class Program
{
	public static Queue<int> RerangeQueue(Queue<int> q)
	{
		var q2 = new Queue<int>();

		var result = new Queue<int>();

		Stack<int> stack = new Stack<int>();

		int halfSize = q.Count / 2;

		for (int i = 0; i < halfSize; i++)
		{
			q2.Enqueue(q.Dequeue());
		}

		while (q.Count > 0)
		{
			stack.Push(q.Dequeue());
		}

		while (stack.Count > 0 && q2.Count > 0)
		{
			result.Enqueue(q2.Dequeue());
			result.Enqueue(stack.Pop());

		}

		while (q2.Count > 0)
		{
			result.Enqueue(q2.Dequeue());
		}

		while (stack.Count > 0)
		{
			result.Enqueue(stack.Pop());
		}

		return result;
	}



	private static void Main(string[] args)
	{
		// input
		Queue<int> q = new Queue<int>([1, 2, 3, 4, 5, 6]);

		// output 
		//[1,6,2,5,3,4]

		q = RerangeQueue(q);
		Console.WriteLine(string.Join(",", q));
		Console.ReadKey();
	}
}