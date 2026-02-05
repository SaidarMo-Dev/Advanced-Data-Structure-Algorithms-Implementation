internal class Program
{

	public class Tree
	{
		public BinaryTreeNode Root { get; set; }

		public Tree()
		{
			Root = null!;

		}

		public void Print()
		{
			Print(Root, 0);
		}
		public void Print(BinaryTreeNode Node, int Space)
		{
			int count = 10;
			if (Node == null)
				return;

			Space += count;


			Print(Node.Right, Space);


			for (int i = count; i < Space; i++)
				Console.Write(" ");

			Console.WriteLine(Node.Value);


			Print(Node.Left, Space);



		}

		public void Insert(int value)
		{
			Root = Insert(Root, value);
		}
		private BinaryTreeNode Insert(BinaryTreeNode node, int value)
		{
			if (node == null)
			{
				return new BinaryTreeNode(value);

			}

			if (node.Value < value)
				node.Right = Insert(node.Right, value);
			if (node.Value > value)
				node.Left = Insert(node.Left, value);

			return node;
		}

		// Method to print the largest value in each level
		public List<int> LargestValuePerTreeLevel()
		{
			var result = new List<int>();

			if (Root == null) return result;

			var queue = new Queue<BinaryTreeNode>();
			queue.Enqueue(Root);

			int level = 0;
			while (queue.Count > 0)
			{
				level++;

				int levelSize = queue.Count;
				int maxValue = int.MinValue;

				for (int i = 0; i < levelSize; i++)
				{
					var node = queue.Dequeue();


					if (node.Value > maxValue)
						maxValue = node.Value;

					if (node.Left != null)
						queue.Enqueue(node.Left);

					if (node.Right != null)
						queue.Enqueue(node.Right);

				}

				result.Add(maxValue);



			}

			return result;

		}


	}

	private static void Main(string[] args)
	{

		var tree = new Tree();


		tree.Insert(101);
		tree.Insert(102);
		tree.Insert(100);
		tree.Insert(45);
		tree.Insert(232);


		Console.WriteLine("Tree");
		Console.WriteLine("==============================================================");
		tree.Print();


		var result = tree.LargestValuePerTreeLevel();

		Console.WriteLine("Max value in each levlel :");
		for (int i = 0; i < result.Count; i++)
		{
			Console.WriteLine($"Level {i}:{result[i]}");
		}


		Console.ReadKey();
	}

	public class BinaryTreeNode
	{
		public int Value { get; set; }
		public BinaryTreeNode Right { get; set; }
		public BinaryTreeNode Left { get; set; }
		public int Height { get; set; }

		public BinaryTreeNode(int value)
		{
			Value = value;
			Right = null!;
			Left = null!;

		}
	}


}