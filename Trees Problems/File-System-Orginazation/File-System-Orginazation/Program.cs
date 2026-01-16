internal class Program
{
	public class Node<T>
	{
		public T Value { get; set; } = default!;
		public List<Node<T>> Children { get; set; }
		public bool IsDirectory { get; set; }

		public Node(T value, bool isDirectory = false)
		{
			Value = value;
			IsDirectory = isDirectory;

			Children = new List<Node<T>>();
		}

		public void AddChild(Node<T> node)
		{
			if (node == null || !IsDirectory) return;

			if (isExist(node.Value)) return;

			Children.Add(node);
		}


		private bool isExist(T value)
		{


			foreach (Node<T> node in Children)
			{
				if (node.Value.Equals(value)) return true;

			}

			return false;
		}
	}


	public class FileSystem<T>
	{
		public Node<T> Root { get; set; }

		public FileSystem()
		{
			Root = null!;
		}


		public void Print()
		{
			Print(Root);
		}


		private void Print(Node<T> node, string indent = "")
		{

			if (node == null) return;



			if (node.IsDirectory)
				Console.WriteLine($"{indent} Directory: {node.Value}");

			foreach (Node<T> child in node.Children)
			{
				if (child.IsDirectory)
				{


					Print(child, indent + "    ");
				}
				else Console.WriteLine($"{indent + "   "} File: {child.Value}");

			}
		}

	}


	private static void Main(string[] args)
	{
		FileSystem<string> fileSystem = new FileSystem<string>();

		// Create the root directory
		Node<string> root = new Node<string>("root", true);

		fileSystem.Root = root;

		// Create Document subdirectory
		Node<string> documents = new Node<string>("Documents", true);

		Node<string> document1 = new Node<string>("Resume.docx");
		Node<string> document2 = new Node<string>("Projects.pdf");

		documents.AddChild(document1);
		documents.AddChild(document2);

		// Create Photos subdirectory
		Node<string> photos = new Node<string>("Photos", true);
		root.AddChild(photos);

		Node<string> photo1 = new Node<string>("Vacation.jpg");
		Node<string> photo2 = new Node<string>("Diving.jpg");
		Node<string> photo3 = new Node<string>("Familly.jpg");

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