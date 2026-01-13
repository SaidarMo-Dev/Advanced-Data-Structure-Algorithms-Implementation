internal class Program
{
	private static void Main(string[] args)
	{
		// Comparer to compare users by login time,
		// if they have equal login time we compare the name

		var comparer = Comparer<(string name, DateTime loginTime)>.Create((a, b) =>
						a.loginTime == b.loginTime ?
						a.name.CompareTo(b.name) : a.loginTime.CompareTo(b.loginTime));


		// Unique users 

		SortedSet<(string name, DateTime loginTime)> users =
			new SortedSet<(string name, DateTime loginTime)>(comparer)
		{
			("Mohammed", new DateTime(2024, 10, 10, 4, 1, 33)),
			("Ali", new DateTime(2024, 10, 4, 2, 0, 0)),
			("Alice", new DateTime(2024, 11, 5, 6, 0, 33))
		};


		foreach (var user in users)
		{
			Console.WriteLine($"User :{user.name}, Active Time:{user.loginTime}");
		}


		Console.ReadKey();
	}
}