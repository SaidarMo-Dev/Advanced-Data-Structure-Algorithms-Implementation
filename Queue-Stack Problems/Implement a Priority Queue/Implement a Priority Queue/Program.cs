internal class Program
{
	class PriorityQueue
	{
		SortedSet<(int, int)> _priorityQueue;

		public PriorityQueue()
		{
			_priorityQueue = new SortedSet<(int value, int priority)>
				(Comparer<(int value, int priority)>.Create((x, y) =>
					x.priority == y.priority ?
					x.value.CompareTo(y.value) : x.priority.CompareTo(y.priority)));
		}

		public void Enqueue(int value, int priority)
		{
			_priorityQueue.Add((value, priority));
		}
		public (int, int) Dequeue()
		{
			var target = _priorityQueue.Min;
			_priorityQueue.Remove(target);
			return target;
		}

		public (int value, int priority) Peek()
		{
			return _priorityQueue.Min;
		}
	}


	private static void Main(string[] args)
	{
		var queue = new PriorityQueue();

		queue.Enqueue(2, 1);
		queue.Enqueue(3, 1);
		queue.Enqueue(4, 5);

		Console.WriteLine("Dequeue the first element :");
		Console.WriteLine(queue.Dequeue());
		Console.WriteLine("Dequeue the second element :");
		Console.WriteLine(queue.Dequeue());

		Console.ReadKey();
	}
}