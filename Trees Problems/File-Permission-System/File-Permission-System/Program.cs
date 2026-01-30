internal class Program
{
	public class Node
	{
		public string Value { get; set; } = default!;
		public int Permessions { get; set; }

		public List<Node> Children { get; set; }
		public bool IsDirectory { get; set; }

		public Node(string value, bool isDirectory = false, int permessions = 0)
		{
			Value = value;
			IsDirectory = isDirectory;

			Children = new List<Node>();

			Permessions = (permessions > 7 || permessions < 0) ? 0 : permessions;
		}

		public void AddChild(Node node)
		{
			if (node == null || !IsDirectory) return;

			// Dublicated values not alllowed
			if (isExist(node.Value)) return;

			// If the new node has no permessions we inherit them from parent
			if (node.Permessions == 0) node.Permessions = Permessions;

			Children.Add(node);
		}


		private bool isExist(string value)
		{


			foreach (Node node in Children)
			{
				if (node.Value.Equals(value)) return true;

			}

			return false;
		}
	}


	public class FileSystem<T>
	{
		public Node Root { get; set; }

		public FileSystem()
		{
			Root = null!;
		}


		public void Print()
		{
			Print(Root);
		}


		private void Print(Node node, string indent = "")
		{

			if (node == null) return;



			if (node.IsDirectory)
				Console.WriteLine($"{indent} Directory: {node.Value}, Permessions : {GetPermessions(node.Permessions)}");

			foreach (Node child in node.Children)
			{
				if (child.IsDirectory)
				{


					Print(child, indent + "    ");
				}
				else Console.WriteLine($"{indent + "   "} File: {child.Value},  Permessions : {GetPermessions(node.Permessions)}");

			}
		}

		private string GetPermessions(int octal)
		{
			char[] perms = { 'r', 'w', 'x' };

			string Permessions = "";

			if ((octal & 4) != 0) Permessions += "r";
			else Permessions += "-";

			if ((octal & 2) != 0) Permessions += "w";
			else Permessions += "-";

			if ((octal & 1) != 0) Permessions += "x";
			else Permessions += "-";

			return Permessions;
		}

	}


	private static void Main(string[] args)
	{
		FileSystem<string> fileSystem = new FileSystem<string>();

		// Create the root directory
		Node root = new Node("root", true, 7);

		fileSystem.Root = root;

		Node folder1 = new Node("Folder1", true, 5);

		folder1.AddChild(new Node("file1", false));

		Node folder2 = new Node("Folder2", true, 7);

		folder2.AddChild(new Node("file2", false));

		fileSystem.Root.AddChild(folder1);
		fileSystem.Root.AddChild(folder2);


		fileSystem.Print();

		Console.WriteLine("\nPress any key to exit...");
		Console.ReadKey();



	}
}