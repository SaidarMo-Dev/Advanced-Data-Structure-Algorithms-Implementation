using System.Collections.ObjectModel;

internal class Program
{
	private static void Main(string[] args)
	{
		ObservableCollection<string> notifications = new ObservableCollection<string>();

		notifications.CollectionChanged += (s, e) =>
		{
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
				Console.WriteLine("New Notification:" + e.NewItems[0]);
		};

		notifications.Add("Your Task under processing");
		notifications.Add("Your Task completed");


		Console.ReadKey();
	}
}