internal class Program
{


	public class EmployeeNode
	{
		public string Name { get; set; } = default!;
		public string Position { get; set; }
		public List<EmployeeNode> Employees { get; set; }


		public EmployeeNode(string name, string position)
		{
			Name = name;
			Position = position;
			Employees = new List<EmployeeNode>();
		}

		public void AddEmployeeChild(EmployeeNode node)
		{
			Employees.Add(node);
		}

	}


	public class CompanyHierarchy
	{
		public EmployeeNode Root { get; set; }

		public CompanyHierarchy()
		{
			Root = null!;
		}


		public void Print()
		{
			Print(Root);
		}


		private void Print(EmployeeNode node, string indent = "")
		{

			if (node == null) return;

			Console.WriteLine($"{indent} {node.Position}: {node.Name}");

			foreach (EmployeeNode child in node.Employees)
			{
				Print(child, indent + "    ");
			}
		}

	}


	private static void Main(string[] args)
	{

		// Create Company Hierarchy
		CompanyHierarchy companyHierarchy = new CompanyHierarchy();

		// Create Root node 

		EmployeeNode root = new EmployeeNode("Mohammed", "CEO");

		// Add the root node
		companyHierarchy.Root = root;

		EmployeeNode vpMarketing = new EmployeeNode("Bob", "VP of Marketing");
		EmployeeNode vpTechno = new EmployeeNode("Lara", "VP of Technology");

		// Add Managed employees by Root
		root.AddEmployeeChild(vpMarketing);
		root.AddEmployeeChild(vpTechno);


		// Create and add vpMarketing Managed employees
		EmployeeNode marketing = new EmployeeNode("Ahmed", "Marketing");
		EmployeeNode manager = new EmployeeNode("Ali", "Manager");

		vpMarketing.AddEmployeeChild(marketing);
		vpMarketing.AddEmployeeChild(manager);

		// Create and add vpTechno Managed employees
		EmployeeNode architect = new EmployeeNode("Tom", "Architect");

		vpTechno.AddEmployeeChild(architect);


		companyHierarchy.Print();

		Console.WriteLine("\nPress any key to exit...");
		Console.ReadKey();




	}

}