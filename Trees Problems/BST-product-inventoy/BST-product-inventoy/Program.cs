internal class Program
{
	// Represents a single node in the Binary Search Tree
	public class ProductNode
	{
		// Unique identifier used for BST ordering
		public int Id { get; set; }

		// Product name stored in the node
		public string Name { get; set; } = default!;

		// Reference to the left child (Id < current Id)
		public ProductNode? Left { get; set; }

		// Reference to the right child (Id > current Id)
		public ProductNode? Right { get; set; }

		// Node constructor
		public ProductNode(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}

	// Binary Search Tree implementation for ProductNode
	public class ProductBinaryTree
	{
		// Root node of the tree
		public ProductNode? Root { get; set; }

		// Public method to insert a new node into the BST
		public void Insert(ProductNode newNode)
		{
			Root = Insert(Root, newNode);
		}

		// Recursive BST insertion logic
		private ProductNode Insert(ProductNode? currentNode, ProductNode newNode)
		{
			// If current position is empty, insert the new node here
			if (currentNode == null)
			{
				return newNode;
			}

			// Traverse left subtree if new Id is smaller
			if (newNode.Id < currentNode.Id)
				currentNode.Left = Insert(currentNode.Left, newNode);

			// Traverse right subtree if new Id is larger
			else if (newNode.Id > currentNode.Id)
				currentNode.Right = Insert(currentNode.Right, newNode);

			// Return unchanged node reference
			return currentNode;
		}

		// -------- Tree Visualization --------

		// Prints the tree structure sideways (right → root → left)
		public void Print()
		{
			Print(Root, 0);
		}

		// Recursive helper for visual tree printing
		private void Print(ProductNode? node, int space)
		{
			int count = 10;

			// Base case
			if (node == null) return;

			// Increase spacing between levels
			space += count;

			// Print right subtree first
			Print(node.Right, space);

			// Print current node after spacing
			for (int i = count; i < space; i++)
				Console.Write(" ");

			Console.WriteLine(node.Name);

			// Print left subtree
			Print(node.Left, space);
		}

		// -------- Tree Traversals --------

		// InOrder traversal: Left → Root → Right
		// Prints nodes in ascending order of Id
		public void PrintInOrder()
		{
			PrintInOrder(Root);
		}

		private void PrintInOrder(ProductNode? node)
		{
			if (node == null) return;

			PrintInOrder(node.Left);
			Console.WriteLine(node.Name);
			PrintInOrder(node.Right);
		}

		// PreOrder traversal: Root → Left → Right
		public void PrintPreOrder()
		{
			PrintPreOrder(Root);
		}

		private void PrintPreOrder(ProductNode? node)
		{
			if (node == null) return;

			Console.WriteLine(node.Name);
			PrintPreOrder(node.Left);
			PrintPreOrder(node.Right);
		}

		// PostOrder traversal: Left → Right → Root
		public void PrintPostOrder()
		{
			PrintPostOrder(Root);
		}

		private void PrintPostOrder(ProductNode? node)
		{
			if (node == null) return;

			PrintPostOrder(node.Left);
			PrintPostOrder(node.Right);
			Console.WriteLine(node.Name);
		}

		// -------- Search --------

		// Public method to find a product by Id
		public ProductNode? Find(int id)
		{
			return Find(Root, id);
		}

		// Iterative BST search (O(log n) average)
		private ProductNode? Find(ProductNode? node, int id)
		{
			var current = node;

			// Traverse tree until found or null
			while (current != null)
			{
				if (id == current.Id)
					return current;

				current = id < current.Id
					? current.Left
					: current.Right;
			}

			return null;
		}
	}

	private static void Main(string[] args)
	{
		// Create a new product BST
		var products = new ProductBinaryTree();

		// Create product nodes
		var product1 = new ProductNode(1001, "Teshort");
		var product2 = new ProductNode(1002, "Shampoo");
		var product3 = new ProductNode(1000, "Tea");

		// Insert products into the BST
		products.Insert(product1);
		products.Insert(product2);
		products.Insert(product3);

		// Print the tree structure
		Console.WriteLine("Products tree:");
		products.Print();

		Console.WriteLine();

		// Search for a product by Id
		int productToFind = 2;
		Console.WriteLine($"Searching for product with id = {productToFind}...");

		var result = products.Find(productToFind);

		// Display search result
		if (result == null)
			Console.WriteLine("Not Found");
		else
			Console.WriteLine($"Product Found => Id: {result.Id}, Name: {result.Name}");

		Console.ReadKey();
	}
}
