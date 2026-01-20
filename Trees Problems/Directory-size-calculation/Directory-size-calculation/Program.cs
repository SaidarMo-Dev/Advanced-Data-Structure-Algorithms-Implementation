internal class Program
{
	public class Node
	{
		public string Name { get; set; } = default!;
		public int Size { get; set; } // File size 0 for Directory
		public List<Node> Children { get; set; }
		public bool IsDirectory { get; set; }


		public Node(string value, int size = 0, bool isDirectory = false)
		{
			Name = value;
			Size = size;
			IsDirectory = isDirectory;

			Children = new List<Node>();
		}

		public void AddChild(Node node)
		{
			if (node == null || !IsDirectory) return;

			Children.Add(node);
		}


		// Recursive method to Calculate the total size of the directory
		public int GetSize()
		{

			int totalSize = Size; // Start with the current size

			foreach (Node child in Children)
			{
				totalSize += child.GetSize();
			}

			return totalSize;
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
				Console.WriteLine($"{indent} Directory: {node.Name}, Size: {node.GetSize()}");

			foreach (Node child in node.Children)
			{
				if (child.IsDirectory)
				{

					Print(child, indent + "    ");
				}
				else Console.WriteLine($"{indent + "   "} File: {child.Name}, Size: {child.Size}");

			}
		}

	}


	private static void Main(string[] args)
	{
		FileSystem<string> fileSystem = new FileSystem<string>();

		// Create the root directory
		Node root = new Node("root", 0, true);

		fileSystem.Root = root;

		// Create Document subdirectory
		Node documents = new Node("Documents", 0, true);

		Node document1 = new Node("Resume.docx", 1200);
		Node document2 = new Node("Projects.pdf", 122);

		documents.AddChild(document1);
		documents.AddChild(document2);

		// Create Photos subdirectory
		Node photos = new Node("Photos", 0, true);

		Node photo1 = new Node("Vacation.jpg", 12);
		Node photo2 = new Node("Diving.jpg", 443);
		Node photo3 = new Node("Familly.jpg", 532);

		photos.AddChild(photo1);
		photos.AddChild(photo2);
		photos.AddChild(photo3);


		// Add Subdirectories to root 
		root.AddChild(documents);
		root.AddChild(photos);



		// Display the file system structure
		fileSystem.Print();


		Console.WriteLine("\nPress any key to exit...");
		Console.ReadKey();



	}
}