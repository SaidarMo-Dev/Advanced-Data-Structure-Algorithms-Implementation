
internal class Program
{
	private static void Main(string[] args)
	{
		// Define a list of activities 
		var activities = new List<(int, int)> { (1, 5), (2, 6), (4, 5), (6, 7), };

		var result = MaxActivities(activities);

		Console.WriteLine("Selected activities: ");
		foreach (var activ in result)
		{
			Console.WriteLine(activ);
		}

	}

	public static List<(int startTime, int endTime)> MaxActivities(List<(int startTime, int endTime)> activities)
	{
		if (activities == null) return new List<(int startTime, int endTime)>();


		var result = new List<(int startTime, int endTime)>();


		// Sort the activities Desn
		activities.Sort((a, b) => a.endTime.CompareTo(b.endTime));

		// add the first activity since it has the smallest endTime
		result.Add(activities[0]);


		for (var i = 1; i < activities.Count; i++)
		{
			if (activities[i].startTime > result[result.Count - 1].endTime)
			{
				result.Add(activities[i]);
			}


		}
		return result;

	}
}