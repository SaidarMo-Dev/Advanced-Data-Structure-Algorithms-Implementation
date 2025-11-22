internal class Program
{
	public enum enGraphDirectionType { Directed, unDirected }

	class Graph
	{

		private int[,] _adjacencyMatrix; // Adjacency matrix to represent the graph
		private Dictionary<string, int> _vertexDictionary; // Maps vertex names to matrix indices
		private int _numberOfVertices; // Number of vertices in the graph
		private enGraphDirectionType _GraphDirectionType = enGraphDirectionType.unDirected;

		// Constructor to initialize the graph
		public Graph(List<string> vertices, enGraphDirectionType GraphDirectionType)
		{
			_GraphDirectionType = GraphDirectionType;
			_numberOfVertices = vertices.Count; // Total number of vertices
			_adjacencyMatrix = new int[_numberOfVertices, _numberOfVertices]; // Initialize adjacency matrix
			_vertexDictionary = new Dictionary<string, int>(); // Initialize vertex dictionary

			// Map vertex names to indices
			for (int i = 0; i < vertices.Count; i++)
			{
				_vertexDictionary[vertices[i]] = i;
			}
		}

		// Add a weighted edge between two vertices
		public void AddEdge(string source, string destination, int weight)
		{
			if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
			{
				int sourceIndex = _vertexDictionary[source];
				int destinationIndex = _vertexDictionary[destination];
				_adjacencyMatrix[sourceIndex, destinationIndex] = weight;

				// Add the reverse edge for undirected graphs
				if (_GraphDirectionType == enGraphDirectionType.unDirected)
				{
					_adjacencyMatrix[destinationIndex, sourceIndex] = weight;
				}
			}
			else
			{
				Console.WriteLine($"Invalid vertices: {source} or {destination}");
			}
		}

		// Display the adjacency matrix
		public void DisplayGraph(string message)
		{
			Console.WriteLine("\n" + message + "\n");
			Console.Write("  ");
			foreach (var vertex in _vertexDictionary.Keys)
			{
				Console.Write(vertex + " ");
			}
			Console.WriteLine();

			foreach (var source in _vertexDictionary)
			{
				Console.Write(source.Key + " ");
				for (int j = 0; j < _numberOfVertices; j++)
				{
					Console.Write(_adjacencyMatrix[source.Value, j] + " ");
				}
				Console.WriteLine();
			}
		}

		public void DFS(string startVertex)
		{
			if (!_vertexDictionary.ContainsKey(startVertex))
			{
				Console.WriteLine("Invalid start vertex.");
				return;
			}

			bool[] visited = new bool[_numberOfVertices]; // Keep track of visited vertices

			Stack<int> stack = new Stack<int>(); // Stack for DFS

			int startIndex = _vertexDictionary[startVertex];

			visited[startIndex] = true;

			stack.Push(startIndex);

			Console.WriteLine("\nDepth-First Search:");

			while (stack.Count > 0)
			{
				var currentVertex = stack.Pop();

				Console.Write($"{GetVertexName(currentVertex)} "); // Print the current vertex

				// Add all unvisited neighbors to the queue
				for (int i = 0; i < _numberOfVertices; i++)
				{
					if (_adjacencyMatrix[currentVertex, i] > 0 && !visited[i])
					{
						visited[i] = true;
						stack.Push(i);
					}
				}

			}

		}

		private string GetVertexName(int vertexIndex)
		{
			foreach (var pair in _vertexDictionary)
			{
				if (pair.Value == vertexIndex)
					return pair.Key;
			}

			return "Unknown";
		}
	}
	private static void Main(string[] args)
	{

		List<string> vertices = new List<string> { "0", "1", "2", "3", "4" };

		Graph graph = new Graph(vertices, enGraphDirectionType.unDirected);


		graph.AddEdge("0", "1", 1);
		graph.AddEdge("0", "2", 1);

		graph.AddEdge("1", "2", 1);
		graph.AddEdge("1", "3", 1);

		graph.AddEdge("2", "3", 1);
		graph.AddEdge("2", "4", 1);



		// Display the graph
		graph.DisplayGraph("Adjacency Matrix (Undirected Graph):");

		graph.DFS("1");

		Console.ReadKey();
	}
}