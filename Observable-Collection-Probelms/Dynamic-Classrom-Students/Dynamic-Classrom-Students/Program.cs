using System.Collections.ObjectModel;
using System.Collections.Specialized;

internal class Program
{
	private static void Main(string[] args)
	{
		ObservableCollection<string> students = new ObservableCollection<string>();

		students.CollectionChanged += (sender, e) =>
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
				Console.WriteLine($"Information: New Student Added: {e.NewItems[0]}");
			else if (e.Action == NotifyCollectionChangedAction.Remove)
				Console.WriteLine($"Warning: Student  Removed: {e.OldItems[0]}");
		};

		students.Add("Mohammed saidar");
		students.Add("Ahmed Ali");

		students.Remove("Mohammed saidar");
		Console.ReadKey();
	}
}