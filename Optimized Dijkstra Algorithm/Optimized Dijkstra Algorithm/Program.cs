class Graph
{
	public enum enGraphDirectionType { Directed, unDirected }

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

	// Dijkstra's Algorithm that finds the shortest paths from a source vertex 
	// Optimized Using Priority Queue
	public void Dijkstra(string sourceVertex)
	{

		if (!_vertexDictionary.ContainsKey(sourceVertex))
		{
			Console.WriteLine("Invalid source vertex.");
			return;
		}

		// Initialize distances and visited arrays

		bool[] visited = new bool[_numberOfVertices]; // Trackes processed vertices
		int[] distances = new int[_numberOfVertices];  // Stores shortest distances
		string[] predecessors = new string[_numberOfVertices];  // Tracks the previous vertex on the shortest path

		int sourceIndex = _vertexDictionary[sourceVertex]; // Get start vertex index


		// Initialize distances to infinity and mark all vertices unvisited

		for (int i = 0; i < _numberOfVertices; i++)

		{
			distances[i] = int.MaxValue;
			predecessors[i] = null; // No predecessors initially

			visited[i] = false;

		}



		distances[sourceIndex] = 0; // distance to the source is 0

		// Priority queue (Min-Heap) to store vertices with their distances

		var priorityQueue = new SortedSet<(int distance, int vertexIndex)>
					(Comparer<(int distance, int vertexIndex)>.Create((x, y) =>
						x.distance == y.distance ?
						x.vertexIndex.CompareTo(y.vertexIndex) : x.distance.CompareTo(y.distance)));

		// Add the starting vertex to the priority queue
		priorityQueue.Add((0, sourceIndex));

		// Process all verteces in the priority queue
		while (priorityQueue.Count > 0)
		{
			// Extract the vertex with the smallest distance
			(int currentDistance, int currentIndex) = priorityQueue.Min;
			priorityQueue.Remove((currentDistance, currentIndex));

			// skip the vertex if it is already visited
			if (visited[currentIndex]) continue;

			visited[currentIndex] = true;

			// Update distances for all neighbors of the current vertex
			for (int neighbor = 0; neighbor < _numberOfVertices; neighbor++)
			{
				var newDistance = distances[currentIndex] + _adjacencyMatrix[currentIndex, neighbor];

				if (_adjacencyMatrix[currentIndex, neighbor] > 0 && !visited[neighbor])
				{
					// If the new distance is shorter, update it
					if (newDistance < distances[neighbor])
					{
						priorityQueue.Remove((distances[neighbor], neighbor)); // Remove the old distance
						distances[neighbor] = newDistance; // update the distance
						predecessors[neighbor] = GetVertexName(currentIndex); // update the predecessor
						priorityQueue.Add((newDistance, neighbor)); // add the updated distance to the queue

					}

				}
			}
		}


		// Display the shortest paths and their distances
		for (int i = 0; i < _numberOfVertices; i++)
		{
			Console.WriteLine($"\nFrom {sourceVertex} To {GetVertexName(i)} => Distance : {distances[i]} , Path : {GetPath(predecessors, i)}");

		}

	}

	// Helper method to get the shortest path for a vertex
	private string GetPath(string[] predecessors, int currentIndex)
	{
		if (predecessors[currentIndex] == null)
			return GetVertexName(currentIndex);

		return GetPath(predecessors, _vertexDictionary[predecessors[currentIndex]]) + " -> " + GetVertexName(currentIndex);
	}


	// Helper method to get vertex name by index
	private string GetVertexName(int index)
	{
		foreach (var pair in _vertexDictionary)
		{
			if (pair.Value == index)
				return pair.Key;
		}
		return null;
	}

	// Main method to demonstrate the graph and traversal algorithms
	public static void Main(string[] args)
	{
		// Define vertices
		List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

		// Create an undirected graph
		Graph graph = new Graph(vertices, enGraphDirectionType.unDirected);

		// Add edges with weights
		graph.AddEdge("A", "B", 4);
		graph.AddEdge("A", "C", 1);
		graph.AddEdge("C", "B", 2);
		graph.AddEdge("C", "D", 4);
		graph.AddEdge("B", "E", 4);
		graph.AddEdge("D", "E", 1);



		// Display the graph
		graph.DisplayGraph("Adjacency Matrix (Undirected Graph):");


		graph.Dijkstra("A");
		Console.ReadKey();
	}
}
