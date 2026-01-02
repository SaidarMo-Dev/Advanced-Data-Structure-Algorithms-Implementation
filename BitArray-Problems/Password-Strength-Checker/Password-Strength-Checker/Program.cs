using System.Collections;

internal class Program
{
	private static void Main(string[] args)
	{
		string password = "TestPassword23$";
		BitArray checks = new BitArray(4, false);

		foreach (char c in password)
		{
			if (char.IsUpper(c) && !checks[0]) checks[0] = true;
			else if (char.IsLower(c) && !checks[1]) checks[1] = true;
			else if (char.IsDigit(c) && !checks[2]) checks[2] = true;
			else if (!char.IsLetterOrDigit(c) && !checks[3]) checks[3] = true;

		}

		Console.WriteLine($"{(checks.HasAllSet() ? "Valid Password" : "Invalid Password")}");


		Console.ReadKey();
	}
}