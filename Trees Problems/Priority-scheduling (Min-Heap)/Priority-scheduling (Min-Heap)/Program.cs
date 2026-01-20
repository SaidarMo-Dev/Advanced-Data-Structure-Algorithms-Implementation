internal class Program
{
	public class Task
	{
		public string Description { get; set; } = default!;
		public int Priority { get; set; }

		public Task(string description, int priority)
		{
			Description = description;
			Priority = priority;
		}
	}

	public class MinHeap
	{
		private List<Task> heap = new List<Task>();

		public void Insert(Task task)
		{
			heap.Add(task);
			HeapifyUp(heap.Count - 1);
		}

		public Task ExtractMin()
		{
			if (heap.Count == 0) return null;

			var minTask = heap[0];
			heap[0] = heap[heap.Count - 1];

			heap.RemoveAt(heap.Count - 1);
			HeapifyDown(0);

			return minTask;
		}
		public void HeapifyUp(int index)
		{

			while (index > 0 && heap[index].Priority < heap[(index - 1) / 2].Priority)
			{

				Swap(index, (index - 1) / 2);

				index = (index - 1) / 2;
			}
		}

		private void HeapifyDown(int index)
		{
			int smallest = index;
			int left = 2 * index + 1;
			int right = 2 * index + 2;

			if (left < heap.Count && heap[left].Priority < heap[index].Priority)
			{
				smallest = left;
			}

			if (right < heap.Count && heap[right].Priority < heap[index].Priority)
			{
				smallest = right;
			}

			if (smallest != index)
			{
				Swap(index, smallest);
				HeapifyDown(smallest);
			}

		}

		private void Swap(int i, int j)
		{
			var temp = heap[i];
			heap[i] = heap[j];
			heap[j] = temp;
		}


		public bool isEmtpy()
		{
			return heap.Count == 0;
		}
	}

	private static void Main(string[] args)
	{
		MinHeap scheduler = new MinHeap();

		scheduler.Insert(new Task("Task A", 3));
		scheduler.Insert(new Task("Task B", 2));
		scheduler.Insert(new Task("Task C", 1));

		Console.WriteLine("Executing tasks in priority order:");

		while (!scheduler.isEmtpy())
		{
			var minTask = scheduler.ExtractMin();

			Console.WriteLine($"Task : {minTask.Description}, Priority: {minTask.Priority}");
		}

		Console.ReadKey();
	}
}