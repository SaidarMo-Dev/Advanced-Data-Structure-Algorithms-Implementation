internal class Program
{
	public class QuetionNode
	{
		public string Quetion { get; set; } = default!;
		public QuetionNode Yes { get; set; } = default!;
		public QuetionNode No { get; set; } = default!;

		public QuetionNode(string quetion)
		{
			Quetion = quetion;
		}
	}

	private static void Main(string[] args)
	{
		QuetionNode root = new QuetionNode("Do you like active pets");

		root.Yes = new QuetionNode("Do you have a lot of space");
		root.Yes.Yes = new QuetionNode("Recommended: Dog");
		root.Yes.No = new QuetionNode("Recommended: Cat");

		root.No = new QuetionNode("Do you prefer low-maintenance pets?");
		root.No.Yes = new QuetionNode("Recommended : Fish");
		root.No.No = new QuetionNode("Recommended : Hamster");


		// start traversal from the root node
		var currentNode = root;


		while (currentNode.Yes != null && currentNode.No != null)
		{
			Console.WriteLine(currentNode.Quetion);
			string answer = Console.ReadLine().Trim().ToLower();

			// Navigate to the next node based on the answer
			if (answer == "yes")
				currentNode = currentNode.Yes;

			else if (answer == "no")
				currentNode = currentNode.No;

			else Console.WriteLine("Please answer with 'yes' or 'no' ");

		}


		// Display the recommendation (leaf node)
		Console.WriteLine(currentNode.Quetion);

		Console.ReadKey();
	}
}