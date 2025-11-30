internal class Program
{

	class MyQueue<T>
	{
		Stack<T> Incomming = new();
		Stack<T> Outcomming = new();

		public int Count
		{
			get
			{
				return Incomming.Count + Outcomming.Count;
			}
		}
		public void Enqueue(T value)
		{
			Incomming.Push(value);
		}
		public T Dequeue()
		{
			if (Outcomming.Count == 0)
			{
				while (Incomming.Count > 0)
				{
					Outcomming.Push(Incomming.Pop());
				}
			}

			return Outcomming.Pop();


		}

	}

	private static void Main(string[] args)
	{
		MyQueue<int> queue = new MyQueue<int>();

		queue.Enqueue(11);
		queue.Enqueue(22);
		queue.Enqueue(33);
		queue.Enqueue(34);

		int length = queue.Count;
		for (int i = 0; i < length; i++)
		{
			Console.WriteLine($"Dequeue element {i + 1}:{queue.Dequeue()}");

		}

		Console.ReadKey();
	}
}