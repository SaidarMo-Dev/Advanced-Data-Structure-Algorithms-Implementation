using System.Collections.ObjectModel;

internal class Program
{
	private static void Main(string[] args)
	{
		ObservableCollection<string> messages = new ObservableCollection<string>();

		messages.CollectionChanged += (sender, e) =>
		{
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
				Console.WriteLine($"New Message: {e.NewItems[0]}");

		};


		messages.Add("Hello mohammed");
		messages.Add("How Are you");


		Console.ReadKey();
	}
}