using System.Collections.ObjectModel;

internal class Program
{
	private static void Main(string[] args)
	{
		ObservableCollection<string> tasks = new ObservableCollection<string>();

		tasks.CollectionChanged += (sender, e) =>
		{
			// You an log to Db or external files instead of output it in the console

			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
				Console.WriteLine($"New Task Added:{e.NewItems[0]}");
			else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
				Console.WriteLine($"Task Removed:{e.OldItems[0]}");

		};

		tasks.Add("Attend Metting");
		tasks.Add("Completed Metting");
		tasks.Add("Report Completed");

		tasks.Remove("Attend Metting");

		Console.ReadKey();
	}
}