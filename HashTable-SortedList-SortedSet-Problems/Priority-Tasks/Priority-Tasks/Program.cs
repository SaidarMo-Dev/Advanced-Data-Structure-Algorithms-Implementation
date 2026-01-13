internal class Program
{
	class Task : IComparable<Task>
	{
		public int Priority { get; set; }
		public required string TaskDescription { get; set; }


		public int CompareTo(Task other)
		{
			var result = this.Priority.CompareTo(other.Priority);

			if (result == 0)
			{
				result = this.TaskDescription.CompareTo(other.TaskDescription);
			}

			return result;
		}


	}
	private static void Main(string[] args)
	{
		SortedSet<Task> tasks = new SortedSet<Task>
		{
			new Task {Priority =1, TaskDescription = "Team meeting"},
			new Task {Priority =3, TaskDescription = "Write report"},
			new Task {Priority =2, TaskDescription = "Complet login endpoint"},
			new Task {Priority =2, TaskDescription = "Fix Logout endpoint crutial bug"},

		};

		Console.WriteLine("Tasks in priority order:");
		foreach (var task in tasks)
		{
			Console.WriteLine($"Priority : {task.Priority}, Description : {task.TaskDescription}");
		}


		Console.WriteLine("Press any key to exit..");
		Console.ReadKey();
	}
}