internal class Program
{
	private static void Main(string[] args)
	{
		HashSet<string> candidateSkills = new HashSet<string> { "C#", "Javascript", "SQL", "T-SQL" };

		HashSet<string> jobRequirements = new HashSet<string> { "C#", "SQL", "C++" };

		candidateSkills.IntersectWith(jobRequirements);

		Console.Write($"Matching skills :{string.Join(",", candidateSkills)}");

		Console.ReadKey();
	}


}