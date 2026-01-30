internal class Program
{

	public class CategoryNode
	{
		public string Name { get; set; } = default!;
		public List<CategoryNode> SubCategories { get; set; } = new List<CategoryNode>();

		public CategoryNode(string name)
		{
			Name = name;
		}

		public void Print(string indent = "")
		{
			Console.WriteLine(indent + Name);
			foreach (var c in SubCategories)
			{
				c.Print(indent + "   ");
			}
		}
	}

	private static void Main(string[] args)
	{
		CategoryNode root = new CategoryNode("Electronics");

		// Initialize Sub Categories
		CategoryNode mobiles = new CategoryNode("Mobiles");
		CategoryNode laptops = new CategoryNode("Laptops");
		CategoryNode samsung = new CategoryNode("Samsung");
		CategoryNode apple = new CategoryNode("Apple");
		CategoryNode hp = new CategoryNode("Hp");
		CategoryNode macBook = new CategoryNode("Mac-Book");


		mobiles.SubCategories.Add(samsung);
		mobiles.SubCategories.Add(apple);
		laptops.SubCategories.Add(hp);
		laptops.SubCategories.Add(macBook);

		root.SubCategories.Add(mobiles);
		root.SubCategories.Add(laptops);

		root.Print();

		Console.ReadKey();
	}
}