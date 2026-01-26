internal class Program
{
	public class Person
	{
		public string Name { get; set; } = default!;
		public List<Person> Friends { get; set; } = new List<Person>();

		public Person(string name)
		{
			Name = name;
		}


		public void PrintFriends(int depth, string indent = "")
		{
			if (depth == 0) return;

			Console.WriteLine(indent + Name);
			foreach (var friend in Friends)
			{
				friend.PrintFriends(depth - 1, indent + "   ");
			}
		}

	}

	private static void Main(string[] args)
	{
		var mohammed = new Person("Mohammed");
		var ali = new Person("Ali");
		var bob = new Person("Bob");

		// Establish friendships
		mohammed.Friends.Add(ali);
		mohammed.Friends.Add(bob);
		bob.Friends.Add(ali);

		// Print mohammed's social network up tp 3 levels deep
		mohammed.PrintFriends(3);
		Console.ReadKey();
	}
}