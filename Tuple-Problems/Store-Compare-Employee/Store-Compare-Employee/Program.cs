internal class Program
{
	private static void Main(string[] args)
	{
		var employee1 = (name: "Ali", salary: 4000);
		var employee2 = (name: "mohammed", salary: 6500);

		Console.WriteLine($"{employee1.name} has {(employee1.salary > employee2.salary ? "higher" : "lower")} salary than {employee2.name}");
		Console.ReadKey();
	}
}